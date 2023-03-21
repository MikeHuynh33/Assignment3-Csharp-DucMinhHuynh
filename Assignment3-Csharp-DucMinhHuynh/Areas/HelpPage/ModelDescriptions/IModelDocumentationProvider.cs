using System;
using System.Reflection;

namespace Assignment3_Csharp_DucMinhHuynh.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}