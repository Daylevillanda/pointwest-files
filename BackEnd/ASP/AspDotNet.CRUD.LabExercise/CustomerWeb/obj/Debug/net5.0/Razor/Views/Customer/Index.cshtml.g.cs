#pragma checksum "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e98ef2f0a131c0a98741acd53da593214af77f97"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_Index), @"mvc.1.0.view", @"/Views/Customer/Index.cshtml")]
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
#line 1 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\_ViewImports.cshtml"
using CustomerWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\_ViewImports.cshtml"
using CustomerWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e98ef2f0a131c0a98741acd53da593214af77f97", @"/Views/Customer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"deaf54ec1741b565fdee1f7542c273efa07eff09", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Customer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CustomerData.Models.Customer>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
  
    ViewBag.Title = "Customer";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Customer</h2>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
 if(Model.Count() > 0) 

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
                                        
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-hover\">\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n             <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n             <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n\r\n");
#nullable restore
#line 28 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
         foreach(var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 32 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
               Write(Html.DisplayFor(model => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 35 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
               Write(Html.DisplayFor(model => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 38 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
               Write(Html.DisplayFor(model => item.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 41 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
               Write(Html.DisplayFor(model => item.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 44 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { id=item.Id, action="edit" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 45 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
               Write(Html.ActionLink("Details", "Details", new { id=item.Id,  }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 46 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 49 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 51 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
    }
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span>Customer Table is Empty</span>\r\n");
#nullable restore
#line 55 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<p>\r\n    ");
#nullable restore
#line 58 "C:\Users\dayle.villanda\Documents\Github\pointwest-files\BackEnd\ASP\AspDotNet.CRUD.LabExercise\CustomerWeb\Views\Customer\Index.cshtml"
Write(Html.ActionLink("Create New Customer", "New"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CustomerData.Models.Customer>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
