#pragma checksum "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87113a2a5eed629b12fc4a2cbef2f3be4e61c3d0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OperaPagination_Index), @"mvc.1.0.view", @"/Views/OperaPagination/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\_ViewImports.cshtml"
using Opera.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\_ViewImports.cshtml"
using Opera.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
using Operas.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
using Operas.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87113a2a5eed629b12fc4a2cbef2f3be4e61c3d0", @"/Views/OperaPagination/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"372da44bd6460d78f6ffcfc68b8ade5aad8c8caf", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_OperaPagination_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedResult<OperaEntity>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "OperaPagination", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<h4>Operas</h4>\r\n<hr />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "87113a2a5eed629b12fc4a2cbef2f3be4e61c3d04916", async() => {
                WriteLiteral(@"
    <table class=""table table-striped"">
        <tr>
            <th scope=""col"">ID</th>
            <th scope=""col"">Title</th>
            <th scope=""col"">Year</th>
            <th scope=""col"">Composers</th>
            <td scope=""col"">Action</td>
        </tr>
");
#nullable restore
#line 17 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
         foreach (var opera in Model.Results)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\r\n                <td scope=\"row\">");
#nullable restore
#line 20 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
                           Write(opera.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 21 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
               Write(opera.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
               Write(opera.Year);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
               Write(opera.Composer);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td> ");
#nullable restore
#line 24 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
                Write(Html.ActionLink("Details", "Details", "Opera", new { id=opera.Id }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 26 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </table>\r\n    <br />\r\n\r\n    <nav aria-label=\"Page navigation example\">\r\n        <ul class=\"pagination\">\r\n");
#nullable restore
#line 32 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
             for (int pageIndex = 1; pageIndex <= Model.PageCount; pageIndex++)
            {

                

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
                 if (pageIndex != Model.CurrentPage)
                {


#line default
#line hidden
#nullable disable
                WriteLiteral("                    <li class=\"page-item\"><a class=\"page-link\"");
                BeginWriteAttribute("href", " href=\"", 1176, "\"", 1217, 3);
                WriteAttributeValue("", 1183, "javascript:pagerClick(", 1183, 22, true);
#nullable restore
#line 38 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
WriteAttributeValue("", 1205, pageIndex, 1205, 10, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1215, ");", 1215, 2, true);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 38 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
                                                                                                    Write(pageIndex);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></li>\r\n");
#nullable restore
#line 39 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <li class=\"page-item active\">\r\n                        <a class=\"page-link\" href=\"#\">");
#nullable restore
#line 43 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
                                                 Write(pageIndex);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <span class=\"sr-only\">(current)</span></a>\r\n                    </li>\r\n");
#nullable restore
#line 45 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\OperaWithPagination\Opera.Web\Views\OperaPagination\Index.cshtml"
                 

            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </ul>\r\n    </nav>\r\n    <input type=\"hidden\" id=\"currentPageIndex\" name=\"currentPageIndex\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    function pagerClick(index) {\r\n        document.getElementById(\"currentPageIndex\").value = index;\r\n        document.forms[0].submit();\r\n    }\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedResult<OperaEntity>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591