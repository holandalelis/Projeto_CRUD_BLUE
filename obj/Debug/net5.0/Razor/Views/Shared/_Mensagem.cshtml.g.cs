#pragma checksum "C:\Users\pedro\Desktop\CRUD_TESTE_BLUE\ProjetoAgenda\Views\Shared\_Mensagem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6316d3bebaa3587e7808e84ad9116156a14a726c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ProjetoAgenda.Models.Shared.Views_Shared__Mensagem), @"mvc.1.0.view", @"/Views/Shared/_Mensagem.cshtml")]
namespace ProjetoAgenda.Models.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6316d3bebaa3587e7808e84ad9116156a14a726c", @"/Views/Shared/_Mensagem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d54a34dd2b40e3f1459c0bea551b3e968d4a9e84", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Mensagem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\pedro\Desktop\CRUD_TESTE_BLUE\ProjetoAgenda\Views\Shared\_Mensagem.cshtml"
 if (TempData.ContainsKey("mensagem"))
{
    var mensagem = MensagemModel.Desserializar(TempData["mensagem"].ToString());
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\pedro\Desktop\CRUD_TESTE_BLUE\ProjetoAgenda\Views\Shared\_Mensagem.cshtml"
     if (mensagem.Tipo == TipoMensagem.Erro)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-warning mt-3 alert-dismissible fade show\" role=\"alert\">\r\n            ");
#nullable restore
#line 7 "C:\Users\pedro\Desktop\CRUD_TESTE_BLUE\ProjetoAgenda\Views\Shared\_Mensagem.cshtml"
       Write(mensagem.Texto);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\"></button>\r\n        </div>\r\n");
#nullable restore
#line 10 "C:\Users\pedro\Desktop\CRUD_TESTE_BLUE\ProjetoAgenda\Views\Shared\_Mensagem.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success mt-3 alert-dismissible fade show\" role=\"alert\">\r\n        ");
#nullable restore
#line 14 "C:\Users\pedro\Desktop\CRUD_TESTE_BLUE\ProjetoAgenda\Views\Shared\_Mensagem.cshtml"
   Write(mensagem.Texto);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\"></button>\r\n    </div>\r\n");
#nullable restore
#line 17 "C:\Users\pedro\Desktop\CRUD_TESTE_BLUE\ProjetoAgenda\Views\Shared\_Mensagem.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\pedro\Desktop\CRUD_TESTE_BLUE\ProjetoAgenda\Views\Shared\_Mensagem.cshtml"
     
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
