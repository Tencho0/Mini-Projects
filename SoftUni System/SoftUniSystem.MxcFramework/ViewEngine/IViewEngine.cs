﻿namespace SoftUniSystem.MvcFramework.ViewEngine;

public interface IViewEngine
{
    string GetHtml(string templateCode, object viewModel, string user);
}