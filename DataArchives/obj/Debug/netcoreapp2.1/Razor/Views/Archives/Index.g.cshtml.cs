#pragma checksum "E:\csharp\DataArchives\DataArchives\Views\Archives\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3ae3f14338437c9e786c2a6792ccd10f420f1e2"
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
#line 2 "E:\csharp\DataArchives\DataArchives\Views\Archives\Index.cshtml"
using DataArchives.Models.ViewModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3ae3f14338437c9e786c2a6792ccd10f420f1e2", @"/Views/Archives/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c07cf65ef6e31872980b18ba10426ca95b3e65e", @"/Views/_ViewImports.cshtml")]
    public class Views_Archives_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataArchives.Models.ViewModel.ArchiveIndexV>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/archives.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "E:\csharp\DataArchives\DataArchives\Views\Archives\Index.cshtml"
  
    ViewData["Title"] = "Index";
    //Layout = "~/Areas/Identity/Pages/Account/Login.cshtml";

#line default
#line hidden
            BeginContext(194, 160, true);
            WriteLiteral("\r\n\r\n\r\n    <div class=\"tab-content\">\r\n        <div class=\"tab-pane fade show active in\" id=\"OwnDatasBlock\" role=\"tabpanel\" aria-labelledby=\"OwnDatasBlock-tab\">\r\n");
            EndContext();
#line 13 "E:\csharp\DataArchives\DataArchives\Views\Archives\Index.cshtml"
             if (Model.UserId != null)
            {
                
                

#line default
#line hidden
            BeginContext(488, 125, false);
#line 16 "E:\csharp\DataArchives\DataArchives\Views\Archives\Index.cshtml"
           Write(await Html.PartialAsync("/Views/Partial/OneSection.cshtml",new OneSectionV() {Section= Model.MySection,UserId=Model.UserId }));

#line default
#line hidden
            EndContext();
#line 16 "E:\csharp\DataArchives\DataArchives\Views\Archives\Index.cshtml"
                                                                                                                                              
            }
            else
            {

#line default
#line hidden
            BeginContext(663, 56, true);
            WriteLiteral("                <h1>Вам необходимо авторизоваться</h1>\r\n");
            EndContext();
#line 21 "E:\csharp\DataArchives\DataArchives\Views\Archives\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(734, 1383, true);
            WriteLiteral(@"

        </div>


        <div class=""tab-pane fade show"" id=""SearchBlock"" role=""tabpanel"" aria-labelledby=""SearchBlock-tab"">
            <input type=""text"" id=""searchStr"" /> <button onclick=""goSearch()"">Поиск</button>
            <input type=""email"" id=""searchEmail"" />
            <div id=""searchResultPreload"" style=""display:none;"">
                <div class=""text-center"">
                    <div class=""spinner-border text-primary square-100-100"" role=""status"">
                        <span class=""sr-only"">Загрузка...</span>
                    </div>
                </div>
            </div>
            <div id=""searchResult"">

            </div>

        </div>


        <div class=""tab-pane fade show"" id=""ForeignDatasBlock"" role=""tabpanel"" aria-labelledby=""ForeignDatasBlock-tab"">

            <input type=""email"" id=""foreignEmail"" /> <button onclick=""getForeign()"">Получить доступ</button>
            <div id=""ForeignResultPreload"" style=""display:none;"">
                <div cla");
            WriteLiteral(@"ss=""text-center"">
                    <div class=""spinner-border text-primary square-100-100"" role=""status"">
                        <span class=""sr-only"">Загрузка...</span>
                    </div>
                </div>
            </div>
            <div id=""ForeignResult"">

            </div>


        </div>


    </div>

    



");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2134, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2140, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "adfa207d7fe3489eabec5b13d87f04be", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2180, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(2185, 2, true);
            WriteLiteral("\r\n");
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
