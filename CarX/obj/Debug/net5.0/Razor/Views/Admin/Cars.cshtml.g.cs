#pragma checksum "C:\CarX\CarX\Views\Admin\Cars.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1225f7645a030c258e167305e6de53e817f2892a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Cars), @"mvc.1.0.view", @"/Views/Admin/Cars.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1225f7645a030c258e167305e6de53e817f2892a", @"/Views/Admin/Cars.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dde783be840c17aa693a0748e908c1675f00d23a", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Cars : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CarX.Models.Car>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddCar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditCar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary mx-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteCar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger mx-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container p-3\">\r\n    <div class=\"row\">\r\n        \r\n        <div class=\"col-md-4 p-3 border\">\r\n            <div class=\"col text-right\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1225f7645a030c258e167305e6de53e817f2892a5413", async() => {
                WriteLiteral("\r\n                    <i class=\"fas fa-plus\"></i> &nbsp; Add Car\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                <div class=""col p-3 border"">
                    <input class=""form-control"" id=""myInput"" type=""text"" placeholder=""Search.."">
                </div>

            </div>
        </div>
        <div class=""col-md-8 p-3 text-dark border"">

");
#nullable restore
#line 20 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
             if (Model.Count() > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <table class=\"table\">\r\n                    <tbody id=\"myTable\">\r\n");
#nullable restore
#line 24 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
                         foreach (var car in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <tr>
                                <td>
                                    <div class=""row m-2"" style=""background: #fefefe;border: 2px solid #1861ac; border-radius: 5px"">
                                        <div class=""col-sm-6 p-3"">
                                            <img");
            BeginWriteAttribute("src", " src=\"", 1157, "\"", 1173, 1);
#nullable restore
#line 30 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
WriteAttributeValue("", 1163, car.Image, 1163, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:100%\" class=\"rounded\"");
            BeginWriteAttribute("alt", " alt=\"", 1209, "\"", 1235, 2);
#nullable restore
#line 30 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
WriteAttributeValue("", 1215, car.Make, 1215, 9, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
WriteAttributeValue(" ", 1224, car.Model, 1225, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        </div>\r\n                                        <div class=\"col-sm-6 p-2\">\r\n                                            <div class=\"font-weight-bolder pt-2 m-0\">\r\n                                                ");
#nullable restore
#line 34 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
                                           Write(car.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 34 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
                                                     Write(car.Make);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 34 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
                                                               Write(car.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 34 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
                                                                          Write(car.Trim);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </div>\r\n\r\n                                            <div class=\"text-muted d-flex justify-content-between m-0\">\r\n                                                <p>");
#nullable restore
#line 38 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
                                              Write(car.Transmission);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                                <p>");
#nullable restore
#line 39 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
                                              Write(car.Engine);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                                <p>");
#nullable restore
#line 40 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
                                              Write(car.DriveTrain);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                            </div>\r\n                                            <div class=\"d-flex text-muted justify-content-between m-0\">\r\n                                                <p>Ext. <div");
            BeginWriteAttribute("style", " style=\"", 2122, "\"", 2217, 5);
            WriteAttributeValue("", 2130, "border:", 2130, 7, true);
            WriteAttributeValue(" ", 2137, "1px", 2138, 4, true);
            WriteAttributeValue(" ", 2141, "solid", 2142, 6, true);
            WriteAttributeValue(" ", 2147, "black;padding:10px;height:50%;border-radius:50%;background:", 2148, 60, true);
#nullable restore
#line 43 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
WriteAttributeValue("", 2207, car.Color, 2207, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></div></p>\r\n                                                <p>Int. <div");
            BeginWriteAttribute("style", " style=\"", 2291, "\"", 2389, 5);
            WriteAttributeValue("", 2299, "border:", 2299, 7, true);
            WriteAttributeValue(" ", 2306, "1px", 2307, 4, true);
            WriteAttributeValue(" ", 2310, "solid", 2311, 6, true);
            WriteAttributeValue(" ", 2316, "black;padding:10px;height:50%;border-radius:50%;background:", 2317, 60, true);
#nullable restore
#line 44 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
WriteAttributeValue("", 2376, car.Interior, 2376, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></div></p>\r\n                                                <small class=\"text-muted float-right\">");
#nullable restore
#line 45 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
                                                                                 Write(String.Format("{0:N0}", car.Odometer));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" miles</small>
                                            </div>
                                            <div class=""d-flex text-muted justify-content-between font-weight-bolder text-primary m-0"">
                                                <p>₦");
#nullable restore
#line 48 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
                                               Write(String.Format("{0:N2}", car.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                                <div class=\"btn-group m-1\" role=\"group\">\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1225f7645a030c258e167305e6de53e817f2892a13719", async() => {
                WriteLiteral("\r\n                                                        <i class=\"fas fa-edit\"></i>\r\n                                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 50 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
                                                                                WriteLiteral(car.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1225f7645a030c258e167305e6de53e817f2892a16346", async() => {
                WriteLiteral("\r\n                                                        <i class=\"fas fa-trash-alt\"></i>\r\n                                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 53 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
                                                                                WriteLiteral(car.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </td>
                            </tr>
");
#nullable restore
#line 63 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n");
#nullable restore
#line 66 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
            }

            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>Nothing to show here!</p>\r\n");
#nullable restore
#line 71 "C:\CarX\CarX\Views\Admin\Cars.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
    </div>
    <a href=""#"" class=""fixed-bottom mb-4 mx-4 d-flex justify-content-center align-items-center"" style=""background: #1861ac;border-radius:50%;height:50px;width:50px;color:#fefefe;text-decoration:none;font-size:30px;font-weight:900"">
        <p>↑</p>
    </a>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CarX.Models.Car>> Html { get; private set; }
    }
}
#pragma warning restore 1591
