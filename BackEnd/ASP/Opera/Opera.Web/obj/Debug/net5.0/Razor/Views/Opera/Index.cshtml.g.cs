#pragma checksum "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\Opera\Opera.Web\Views\Opera\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f305e64f30746808f16a8ade29e023ac99ba5f39"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Opera_Index), @"mvc.1.0.view", @"/Views/Opera/Index.cshtml")]
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
#line 1 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\Opera\Opera.Web\Views\_ViewImports.cshtml"
using Operas.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\Opera\Opera.Web\Views\_ViewImports.cshtml"
using Operas.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f305e64f30746808f16a8ade29e023ac99ba5f39", @"/Views/Opera/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d2b228cf67d8045405c459897291311cafa805f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Opera_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Operas.Data.Models.Opera>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<table class=\"table\">\r\n    <tr>\r\n        <th>\r\n            ");
#nullable restore
#line 5 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\Opera\Opera.Web\Views\Opera\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 8 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\Opera\Opera.Web\Views\Opera\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n         <th>\r\n            ");
#nullable restore
#line 11 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\Opera\Opera.Web\Views\Opera\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Composer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n         <th></th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 16 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\Opera\Opera.Web\Views\Opera\Index.cshtml"
     foreach(var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 20 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\Opera\Opera.Web\Views\Opera\Index.cshtml"
           Write(Html.DisplayFor(model => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 23 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\Opera\Opera.Web\Views\Opera\Index.cshtml"
           Write(Html.DisplayFor(model => item.Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 26 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\Opera\Opera.Web\Views\Opera\Index.cshtml"
           Write(Html.DisplayFor(model => item.Composer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 29 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\Opera\Opera.Web\Views\Opera\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 30 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\Opera\Opera.Web\Views\Opera\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 31 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\Opera\Opera.Web\Views\Opera\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n    </tr>\r\n");
#nullable restore
#line 34 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\Opera\Opera.Web\Views\Opera\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Operas.Data.Models.Opera>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
