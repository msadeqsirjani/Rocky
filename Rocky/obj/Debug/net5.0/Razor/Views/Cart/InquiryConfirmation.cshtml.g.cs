#pragma checksum "F:\Code\C#\Rocky\Rocky\Views\Cart\InquiryConfirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "271f5f69dec6f3b5072459b6edd558d5a57302a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_InquiryConfirmation), @"mvc.1.0.view", @"/Views/Cart/InquiryConfirmation.cshtml")]
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
#line 1 "F:\Code\C#\Rocky\Rocky\Views\_ViewImports.cshtml"
using Rocky;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"271f5f69dec6f3b5072459b6edd558d5a57302a1", @"/Views/Cart/InquiryConfirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a84b3f39299965dc76d9adc8b2dffde4628843b9", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_InquiryConfirmation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Rocky.Application.ViewModels.Dtos.OrderHeader.OrderHeaderGetDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"text-center\">\r\n");
#nullable restore
#line 4 "F:\Code\C#\Rocky\Rocky\Views\Cart\InquiryConfirmation.cshtml"
     if (Model.IsNotNull())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1 class=\"text-info\">Order Created</h1>\r\n                <p>Order #");
#nullable restore
#line 7 "F:\Code\C#\Rocky\Rocky\Views\Cart\InquiryConfirmation.cshtml"
                     Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(" has been created successfully</p> ");
#nullable restore
#line 7 "F:\Code\C#\Rocky\Rocky\Views\Cart\InquiryConfirmation.cshtml"
                                                                      }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1 class=\"text-info\">Inquiry Confirmation</h1>\r\n");
            WriteLiteral("                <p>We have received your inquiry and someone from our team will contact you shortly!</p>");
#nullable restore
#line 12 "F:\Code\C#\Rocky\Rocky\Views\Cart\InquiryConfirmation.cshtml"
                                                                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <img src=\"/images/patio.jpg\" width=\"80%\"");
            BeginWriteAttribute("alt", " alt=\"", 488, "\"", 494, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Rocky.Application.ViewModels.Dtos.OrderHeader.OrderHeaderGetDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
