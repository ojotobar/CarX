#pragma checksum "C:\Projects\CarX\CarX\Views\Home\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3dbb44bbe85a3788b66ff7d7c3fd05d1225e696b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
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
#line 1 "C:\Projects\CarX\CarX\Views\_ViewImports.cshtml"
using CarX;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\CarX\CarX\Views\_ViewImports.cshtml"
using CarX.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dbb44bbe85a3788b66ff7d7c3fd05d1225e696b", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dde783be840c17aa693a0748e908c1675f00d23a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CarX.Models.About>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<section class=\"about py-5\">\r\n    <div class=\"container py-5\"  >\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 5 "C:\Projects\CarX\CarX\Views\Home\About.cshtml"
             foreach (var about in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-lg-5\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 247, "\"", 266, 1);
#nullable restore
#line 8 "C:\Projects\CarX\CarX\Views\Home\About.cshtml"
WriteAttributeValue("", 253, about.ImgUrl, 253, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\" alt=\"car\" />\r\n                </div>\r\n");
            WriteLiteral("                <div class=\"col-lg-7 pt-3\">\r\n                    <h1>About Us</h1>\r\n                    <p class=\"text-muted font-weight-bold\" style=\"text-transform:capitalize;\">");
#nullable restore
#line 13 "C:\Projects\CarX\CarX\Views\Home\About.cshtml"
                                                                                         Write(about.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p class=\"py-1\">");
#nullable restore
#line 14 "C:\Projects\CarX\CarX\Views\Home\About.cshtml"
                               Write(about.Details);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n");
#nullable restore
#line 16 "C:\Projects\CarX\CarX\Views\Home\About.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CarX.Models.About>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
