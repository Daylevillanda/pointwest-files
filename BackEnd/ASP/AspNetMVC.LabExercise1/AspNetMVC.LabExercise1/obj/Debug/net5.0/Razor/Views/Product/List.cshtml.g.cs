#pragma checksum "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspNetMVC.LabExercise1\AspNetMVC.LabExercise1\Views\Product\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9de3c365821f720663894eaaf5eccf848d91a597"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_List), @"mvc.1.0.view", @"/Views/Product/List.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspNetMVC.LabExercise1\AspNetMVC.LabExercise1\Views\_ViewImports.cshtml"
using AspNetMVC.LabExercise1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspNetMVC.LabExercise1\AspNetMVC.LabExercise1\Views\Product\List.cshtml"
using AspNetMVC.LabExercise1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspNetMVC.LabExercise1\AspNetMVC.LabExercise1\Views\Product\List.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9de3c365821f720663894eaaf5eccf848d91a597", @"/Views/Product/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed60b1b79549b1428db8ee66de98133811b73821", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Product_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspNetMVC.LabExercise1\AspNetMVC.LabExercise1\Views\Product\List.cshtml"
  
    var products = ViewData["Products"] as List<Product>;
    var grandTotal = ViewData["GrandTotal"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div>
    <table class=""table table-striped"">
        <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Description</th>
            <th>Quantity</th>
            <th>Price</th>
            <th>Total Price</th>
        </tr>
");
#nullable restore
#line 17 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspNetMVC.LabExercise1\AspNetMVC.LabExercise1\Views\Product\List.cshtml"
         foreach(var product in products)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 20 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspNetMVC.LabExercise1\AspNetMVC.LabExercise1\Views\Product\List.cshtml"
               Write(product.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 21 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspNetMVC.LabExercise1\AspNetMVC.LabExercise1\Views\Product\List.cshtml"
               Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspNetMVC.LabExercise1\AspNetMVC.LabExercise1\Views\Product\List.cshtml"
               Write(product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspNetMVC.LabExercise1\AspNetMVC.LabExercise1\Views\Product\List.cshtml"
               Write(product.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspNetMVC.LabExercise1\AspNetMVC.LabExercise1\Views\Product\List.cshtml"
               Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspNetMVC.LabExercise1\AspNetMVC.LabExercise1\Views\Product\List.cshtml"
               Write(product.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 27 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspNetMVC.LabExercise1\AspNetMVC.LabExercise1\Views\Product\List.cshtml"
        }        

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td colspan=\"4\"></td>\r\n            <td>Grand Total:</td>\r\n            <td>");
#nullable restore
#line 31 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspNetMVC.LabExercise1\AspNetMVC.LabExercise1\Views\Product\List.cshtml"
           Write(grandTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n    </table>\r\n</div>");
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
