#pragma checksum "E:\csharp\DataArchives\DataArchives\Views\Archives\CreateSection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "084a58b7dbe99ca576cbf8d240593828a73d6c5e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Archives_CreateSection), @"mvc.1.0.view", @"/Views/Archives/CreateSection.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Archives/CreateSection.cshtml", typeof(AspNetCore.Views_Archives_CreateSection))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "E:\csharp\DataArchives\DataArchives\Views\_ViewImports.cshtml"
using DataArchives;

#line default
#line hidden
#line 2 "E:\csharp\DataArchives\DataArchives\Views\_ViewImports.cshtml"
using DataArchives.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"084a58b7dbe99ca576cbf8d240593828a73d6c5e", @"/Views/Archives/CreateSection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c07cf65ef6e31872980b18ba10426ca95b3e65e", @"/Views/_ViewImports.cshtml")]
    public class Views_Archives_CreateSection : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataArchives.Models.ViewModel.OneSectionV>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(55, 66, false);
#line 4 "E:\csharp\DataArchives\DataArchives\Views\Archives\CreateSection.cshtml"
Write(await Html.PartialAsync("/Views/Partial/OneSection.cshtml", Model));

#line default
#line hidden
            EndContext();
            BeginContext(121, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataArchives.Models.ViewModel.OneSectionV> Html { get; private set; }
    }
}
#pragma warning restore 1591