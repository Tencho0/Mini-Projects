namespace SoftUniSystem.MxcFramework.ViewEngine;

public interface IView
{
    string GetHtml(object viewModel);
}