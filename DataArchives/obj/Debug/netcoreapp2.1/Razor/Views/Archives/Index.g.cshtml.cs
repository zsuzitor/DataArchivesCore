#pragma checksum "E:\csharp\DataArchives\DataArchives\Views\Archives\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd6229004edaf50c3dda7f94fda677daa4cf7f9b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Archives_Index), @"mvc.1.0.view", @"/Views/Archives/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Archives/Index.cshtml", typeof(AspNetCore.Views_Archives_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd6229004edaf50c3dda7f94fda677daa4cf7f9b", @"/Views/Archives/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c07cf65ef6e31872980b18ba10426ca95b3e65e", @"/Views/_ViewImports.cshtml")]
    public class Views_Archives_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataArchives.Models.ViewModel.ArchiveIndexV>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(160, 441, true);
            WriteLiteral(@"


    <div class=""tab-content"">
        <div class=""tab-pane fade show active"" id=""OwnDatasBlock"" role=""tabpanel"" aria-labelledby=""OwnDatasBlock-tab""></div>
        <div class=""tab-pane fade show active"" id=""SearchBlock"" role=""tabpanel"" aria-labelledby=""SearchBlock-tab""></div>
        <div class=""tab-pane fade show active"" id=""ForegnDatasBlock"" role=""tabpanel"" aria-labelledby=""ForegnDatasBlock-tab""></div>
      

    </div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataArchives.Models.ViewModel.ArchiveIndexV> Html { get; private set; }
    }
}
#pragma warning restore 1591