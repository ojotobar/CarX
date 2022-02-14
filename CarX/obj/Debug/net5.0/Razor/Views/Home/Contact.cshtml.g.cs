#pragma checksum "C:\CarX\CarX\Views\Home\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f81762ee0d97b4b3ccbeb870dbd924a7e88e60cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Contact), @"mvc.1.0.view", @"/Views/Home/Contact.cshtml")]
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
#line 1 "C:\CarX\CarX\Views\_ViewImports.cshtml"
using CarX;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\CarX\CarX\Views\_ViewImports.cshtml"
using CarX.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f81762ee0d97b4b3ccbeb870dbd924a7e88e60cd", @"/Views/Home/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dde783be840c17aa693a0748e908c1675f00d23a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Contact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CarX.Models.Contact>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("https://formsubmit.co/ojotobar@gmail.com"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<section class=\"contact py-5\">\r\n    <div class=\"container py-5\">\r\n        <h1 class=\"text-center\">Contact Us</h1>\r\n        <div class=\"row py-5\">\r\n");
#nullable restore
#line 6 "C:\CarX\CarX\Views\Home\Contact.cshtml"
             if (Model.Count() > 0)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\CarX\CarX\Views\Home\Contact.cshtml"
                 foreach (var contact in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""col-lg-10 mx-auto"">
                        <div class=""row text-center"">
                            <div class=""col-lg-4"">
                                <div class=""circle"">
                                    <i class=""fas fa-map-marker-alt""></i>
                                </div>
                                <h5>Address</h5>
                                <p>");
#nullable restore
#line 17 "C:\CarX\CarX\Views\Home\Contact.cshtml"
                              Write(contact.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n\r\n                            <div class=\"col-lg-4\">\r\n                                <div class=\"circle\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 927, "\"", 955, 2);
            WriteAttributeValue("", 934, "mailto:", 934, 7, true);
#nullable restore
#line 22 "C:\CarX\CarX\Views\Home\Contact.cshtml"
WriteAttributeValue("", 941, contact.Email, 941, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"text-dark\" style=\"text-decoration:none;\"><i class=\"fas fa-envelope\"></i></a>\r\n                                </div>\r\n                                <h5>Email </h5>\r\n                                <p>");
#nullable restore
#line 25 "C:\CarX\CarX\Views\Home\Contact.cshtml"
                              Write(contact.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n\r\n                            <div class=\"col-lg-4\">\r\n                                <div class=\"circle\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1368, "\"", 1393, 2);
            WriteAttributeValue("", 1375, "tel:", 1375, 4, true);
#nullable restore
#line 30 "C:\CarX\CarX\Views\Home\Contact.cshtml"
WriteAttributeValue("", 1379, contact.Phone, 1379, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"text-dark\" style=\"text-decoration:none;\"><i class=\"fas fa-phone\"></i></a>\r\n                                </div>\r\n                                <h5>Phone </h5>\r\n                                <p>");
#nullable restore
#line 33 "C:\CarX\CarX\Views\Home\Contact.cshtml"
                              Write(contact.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 37 "C:\CarX\CarX\Views\Home\Contact.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\CarX\CarX\Views\Home\Contact.cshtml"
                 
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p></p>\r\n");
#nullable restore
#line 42 "C:\CarX\CarX\Views\Home\Contact.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-9 mx-auto\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f81762ee0d97b4b3ccbeb870dbd924a7e88e60cd7793", async() => {
                WriteLiteral(@"
                    <div class=""form-row"">
                        <div class=""col-lg-6"">
                            <input type=""text"" name=""name"" id=""name"" class=""form-control bg-light mb-3"" placeholder=""Name"" required/>
                        </div>

                        <div class=""col-lg-6"">
                            <input type=""email"" name=""email"" id=""email"" class=""form-control bg-light mb-3"" placeholder=""Email"" required/>
                        </div>
                    </div>
                    <input type=""hidden"" name=""_captcha"" value=""false"" />
                    <div class=""form-row"">
                        <div class=""col-lg-12"">
                            <textarea name=""message"" id=""message"" rows=""5"" class=""form-control bg-light"" placeholder=""Message"" required></textarea>
                        </div>
                    </div>

                    <button type=""submit"" class=""btn3 my-4 font-weight-bold"">SEND</button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CarX.Models.Contact>> Html { get; private set; }
    }
}
#pragma warning restore 1591
