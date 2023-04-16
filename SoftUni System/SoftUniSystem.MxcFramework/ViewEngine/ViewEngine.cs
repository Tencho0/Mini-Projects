using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace SoftUniSystem.MxcFramework.ViewEngine;

public class ViewEngine : IViewEngine
{
    public string GetHtml(string templateCode, object viewModel)
    {
        string csharpCode = GenerateCsharpFromTemplate(templateCode);
        IView executableObject = GenerateExecutableCode(csharpCode, viewModel);
        string html = executableObject.GetHtml(viewModel);
        return html;
    }

    private IView GenerateExecutableCode(string csharpCode, object viewModel)
    {
        var compileResult = CSharpCompilation.Create("ViewAssembly")
            .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
            .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
            .AddReferences(MetadataReference.CreateFromFile(typeof(IView).Assembly.Location));

        if (viewModel != null)
        {
            if (viewModel.GetType().IsGenericType)
            {
                var genericArguments = viewModel.GetType().GenericTypeArguments;
                foreach (var genericArgument in genericArguments)
                {
                    compileResult = compileResult
                        .AddReferences(MetadataReference.CreateFromFile(genericArgument.Assembly.Location));
                }
            }

            compileResult = compileResult
                .AddReferences(MetadataReference.CreateFromFile(viewModel.GetType().Assembly.Location));
        }

        var libraries = Assembly.Load(
            new AssemblyName("netstandard")).GetReferencedAssemblies();
        foreach (var library in libraries)
        {
            compileResult = compileResult.AddReferences(MetadataReference.CreateFromFile(Assembly.Load(library).Location));
        }

        compileResult = compileResult.AddSyntaxTrees(SyntaxFactory.ParseSyntaxTree(csharpCode));

        using (MemoryStream memoryStream = new MemoryStream())
        {
            EmitResult result = compileResult.Emit(memoryStream);
            if (!result.Success)
            {
                return new ErrorView(result.Diagnostics
                    .Where(x => x.Severity == DiagnosticSeverity.Error)
                    .Select(x => x.GetMessage()), csharpCode);
            }

            try
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                var byteAssembly = memoryStream.ToArray();
                var assembly = Assembly.Load(byteAssembly);
                var viewType = assembly.GetType("ViewNamespace.ViewClass");
                var instance = Activator.CreateInstance(viewType);
                return (instance as IView)
                       ?? new ErrorView(new List<string> { "Instance is null!" }, csharpCode);
            }
            catch (Exception ex)
            {
                return new ErrorView(new List<string> { ex.ToString() }, csharpCode);
            }
        }
    }

    private string GenerateCsharpFromTemplate(string templateCode)
    {
        string methodBody = GetMethodBody(templateCode);
        string csharpCode = @"
using System;
using System.Text;
using System.Linq;
using System.Collection.Generic;
using SoftUniSystem.MxcFramework.ViewEngine;

namespace ViewNamespace
{
    public class ViewClass : IView
    {
        public string GetHtml(object viewModel);
        {
            var html = new StringBuilder();
                " + methodBody + @"
            return html.ToString();
        }
    }
}
";

        return csharpCode;
    }

    private string GetMethodBody(string templateCode)
    {
        return string.Empty;
    }
}