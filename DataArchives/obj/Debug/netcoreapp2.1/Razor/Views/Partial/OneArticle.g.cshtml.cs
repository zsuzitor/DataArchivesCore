#pragma checksum "E:\csharp\DataArchives\DataArchives\Views\Partial\OneArticle.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3fbe21ff63f432866b061f9f270b2a11aae0c835"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Partial_OneArticle), @"mvc.1.0.view", @"/Views/Partial/OneArticle.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Partial/OneArticle.cshtml", typeof(AspNetCore.Views_Partial_OneArticle))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fbe21ff63f432866b061f9f270b2a11aae0c835", @"/Views/Partial/OneArticle.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c07cf65ef6e31872980b18ba10426ca95b3e65e", @"/Views/_ViewImports.cshtml")]
    public class Views_Partial_OneArticle : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataArchives.Models.ViewModel.OneArticleV>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 50, true);
            WriteLiteral("\r\n\r\n    <div class=\"rounded border border-warning\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 100, "\"", 137, 2);
            WriteAttributeValue("", 105, "OneArticleFull_", 105, 15, true);
#line 4 "E:\csharp\DataArchives\DataArchives\Views\Partial\OneArticle.cshtml"
WriteAttributeValue("", 120, Model.Article.Id, 120, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(138, 57, true);
            WriteLiteral(">\r\n        <div class=\"row no-gutters\">\r\n            <div");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 195, "\"", 239, 3);
            WriteAttributeValue("", 205, "OpenArticlePage(", 205, 16, true);
#line 6 "E:\csharp\DataArchives\DataArchives\Views\Partial\OneArticle.cshtml"
WriteAttributeValue("", 221, Model.Article.Id, 221, 17, false);

#line default
#line hidden
            WriteAttributeValue("", 238, ")", 238, 1, true);
            EndWriteAttribute();
            BeginContext(240, 28, true);
            WriteLiteral(" class=\"col-2 bg-warning\">\r\n");
            EndContext();
            BeginContext(384, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(401, 17, false);
#line 8 "E:\csharp\DataArchives\DataArchives\Views\Partial\OneArticle.cshtml"
           Write(Model.Article.Lvl);

#line default
#line hidden
            EndContext();
            BeginContext(418, 75, true);
            WriteLiteral("\r\n               \r\n            </div>\r\n\r\n            <div class=\"col-10\">\r\n");
            EndContext();
            BeginContext(575, 20, true);
            WriteLiteral("                <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 595, "\"", 632, 2);
            WriteAttributeValue("", 600, "oneArticleHead_", 600, 15, true);
#line 14 "E:\csharp\DataArchives\DataArchives\Views\Partial\OneArticle.cshtml"
WriteAttributeValue("", 615, Model.Article.Id, 615, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(633, 48, true);
            WriteLiteral(" class=\"text-break\">\r\n                    <label");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 681, "\"", 723, 2);
            WriteAttributeValue("", 686, "oneArticleHeadLabel_", 686, 20, true);
#line 15 "E:\csharp\DataArchives\DataArchives\Views\Partial\OneArticle.cshtml"
WriteAttributeValue("", 706, Model.Article.Id, 706, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(724, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(726, 18, false);
#line 15 "E:\csharp\DataArchives\DataArchives\Views\Partial\OneArticle.cshtml"
                                                                 Write(Model.Article.Head);

#line default
#line hidden
            EndContext();
            BeginContext(744, 70, true);
            WriteLiteral("</label>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 19 "E:\csharp\DataArchives\DataArchives\Views\Partial\OneArticle.cshtml"
         if (Model.UserId == Model.Article.UserId)
        {

#line default
#line hidden
            BeginContext(877, 48, true);
            WriteLiteral("            <div class=\"\">\r\n                <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 925, "\"", 968, 2);
            WriteAttributeValue("", 930, "actionsArticleButton_", 930, 21, true);
#line 22 "E:\csharp\DataArchives\DataArchives\Views\Partial\OneArticle.cshtml"
WriteAttributeValue("", 951, Model.Article.Id, 951, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 969, "\"", 1014, 3);
            WriteAttributeValue("", 979, "actionsArticle(\'", 979, 16, true);
#line 22 "E:\csharp\DataArchives\DataArchives\Views\Partial\OneArticle.cshtml"
WriteAttributeValue("", 995, Model.Article.Id, 995, 17, false);

#line default
#line hidden
            WriteAttributeValue("", 1012, "\')", 1012, 2, true);
            EndWriteAttribute();
            BeginContext(1015, 184, true);
            WriteLiteral(" class=\"text-center btn btn-default btn-sm btn-block border-top\">\r\n                    <small class=\"text-muted\">Показать действия</small>\r\n                </div>\r\n                <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1199, "\"", 1236, 2);
            WriteAttributeValue("", 1204, "articleActions_", 1204, 15, true);
#line 25 "E:\csharp\DataArchives\DataArchives\Views\Partial\OneArticle.cshtml"
WriteAttributeValue("", 1219, Model.Article.Id, 1219, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1237, 95, true);
            WriteLiteral(" class=\"one-article-actions\" style=\"height:0;\">\r\n\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 29 "E:\csharp\DataArchives\DataArchives\Views\Partial\OneArticle.cshtml"
        }

#line default
#line hidden
            BeginContext(1343, 24, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataArchives.Models.ViewModel.OneArticleV> Html { get; private set; }
    }
}
#pragma warning restore 1591
