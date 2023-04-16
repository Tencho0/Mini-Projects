namespace SoftUniSystem.MxcFramework.ViewEngine;

public interface IViewEngine
{
    string GetHtml(string templateCode, object viewModel);
}