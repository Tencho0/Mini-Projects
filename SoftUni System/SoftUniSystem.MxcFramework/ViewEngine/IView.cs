﻿namespace SoftUniSystem.MvcFramework.ViewEngine;

public interface IView
{
    string ExecuteTemplate(object viewModel, string user);
}