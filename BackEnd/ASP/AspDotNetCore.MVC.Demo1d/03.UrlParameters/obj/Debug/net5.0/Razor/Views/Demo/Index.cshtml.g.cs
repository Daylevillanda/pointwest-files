#pragma checksum "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNetCore.MVC.Demo1d\03.UrlParameters\Views\Demo\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10f4ea3734417f1284e45fbb4defcb32aa5c059d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Demo_Index), @"mvc.1.0.view", @"/Views/Demo/Index.cshtml")]
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
#line 1 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNetCore.MVC.Demo1d\03.UrlParameters\Views\_ViewImports.cshtml"
using _03.UrlParameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNetCore.MVC.Demo1d\03.UrlParameters\Views\_ViewImports.cshtml"
using _03.UrlParameters.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10f4ea3734417f1284e45fbb4defcb32aa5c059d", @"/Views/Demo/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7e344a9f86c99f66a1a80fdd9bc701bd60f1e70", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Demo_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNetCore.MVC.Demo1d\03.UrlParameters\Views\Demo\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h3>URL Parameters</h3>\r\n<a");
            BeginWriteAttribute("href", " href=\"", 66, "\"", 121, 1);
#nullable restore
#line 6 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNetCore.MVC.Demo1d\03.UrlParameters\Views\Demo\Index.cshtml"
WriteAttributeValue("", 73, Url.Action("Demo1", "Demo", new { id = "p01" }), 73, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">One Parameter</a>\r\n<br />\r\n<a");
            BeginWriteAttribute("href", " href=\"", 152, "\"", 212, 1);
#nullable restore
#line 8 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNetCore.MVC.Demo1d\03.UrlParameters\Views\Demo\Index.cshtml"
WriteAttributeValue("", 159, Url.Action("Demo2", "Demo", new { id = 4, id2 = 7 }), 159, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Multiple Parameters</a>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591