# Usando Views em Aspnet Core 6 C#

>Criando uma aplicação AspNet Core 6 C# - usandoViews - Treinamento Youtube Ricardo Maroquio. 
> 
>>Ricardo Maroquio [Desenvolvimento Web com ASP.NET - Criando a Aplicação Web Partindo de um Template Mínimo](https://www.youtube.com/watch?v=qom0aOGSDRs&list=PL0YuSuacUEWuN8xnvk2b5yW_koKbkHh_m&index=8)
Youtuber - [Ricardo Maroquio](https://www.youtube.com/@maroquio)

## Desenvolvimento:
1. <span style="color:383E42"><b>Incluir/Criar arquivos iniciais</b></span>
    <details><summary><span style="color:Chocolate">Detalhes</span></summary>
    <p>

    1. Inclusão README (estrutura básica), gitignore e imagens para o README
    2. Criação arquivo `global.json`
        ```sh
        dotnet new globaljson --sdk-version 6.0
        ```
    3. Criar Projeto web com template mínimo
        ```sh
        dotnet new web --no-https --framework net6.0
        ```
    </p>

    </details> 

    ---

2. <span style="color:383E42"><b>Suporte ao processamento de Views e RuntimeCompilation</b></span>
    <details><summary><span style="color:Chocolate">Detalhes</span></summary>
    <p>

    1. Habilitar RuntimeCompilation - Instalar pacote para que o projeto reflita as alterações feitas imediatamente - Obs.: Somente alterações nas Views
        ```sh
        dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation --version 6.0.0
        ```
    2. Habilitar suporte ao processamento de views - em Program.cs
    e incluir configuração do RazorRuntime
        ```sh
        // Add services to the container.
        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
        ```
    </p>

    </details> 

    ---

3. <span style="color:383E42"><b>Incluir middleware em Program -  ExceptionPage - StaticFiles - UseRouting - Route</b></span>
    <details><summary><span style="color:Chocolate">Detalhes</span></summary>
    <p>

    ```cs
    var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.
    builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

    var app = builder.Build();

    // Detalhes de exceções não tratadas
    // Como é uma aplicação que não será publica num servidor real, sempre mostrará os erros
    app.UseDeveloperExceptionPage();

    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    // Mesmo resultado que acima
    //app.MapDefaultControllerRoute();
    app.Run();

    ```
    </p>

    </details> 

    ---



4. <span style="color:383E42"><b>Criar pastas/arquivo para Controllers e Views </b></span>
    <details><summary><span style="color:Chocolate">Detalhes</span></summary>
    <p>

    1. Criar pasta Controllers e arquivo HomeController.cs
        ```cs
        using Microsoft.AspNetCore.Mvc;
        namespace UsandoViews.Controllers
        {
            public class HomeController : Controller
            {
                public IActionResult Index()
                {
                    return View();
                }
            }
        }
        ```
    2. Criar pastas Views/Home e arquivo Index.cshtml
        ```html
        <!DOCTYPE html>
        <html lang="pt-br">

        <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <title>Página Principal</title>
        </head>

        <body>
            <h1>Página Principal</h1>
            <p>Bem vindo ao ASP.NET Core 5!</p>
        </body>

        </html>
        ```
    3. Testar
        ```sh
        dotnet run --project .\usandoViews.csproj
        ou
        dotnet run
        ```

    </p>

    </details> 

    ---

5. <span style="color:383E42"><b>Instalação [LibMan](https://learn.microsoft.com/pt-br/aspnet/core/client-side/libman/libman-cli?view=aspnetcore-7.0), Bootstrap5 e criação arquivo libman.json</b></span>
    <details><summary><span style="color:Chocolate">Detalhes</span>
    </summary>
    <p>

    1. Cria arquivo com indicação `libman.json` padrão para onde buscar as bibliotecas - neste caso o jsdelivr - onde encontramos bootrap e outros
        ```sh
        dotnet tool install -g Microsoft.Web.LibraryManager.Cli
        libman init -p jsdelivr
        ```
    2. Instala o bootstrap5 e cria diretorio wwwroot - bibliotecas client side devem fica dentro da pasta lib
        ```sh
        libman install bootstrap -d wwwroot/lib/bootstrap5
        ```
    </p>

    </details> 

    ---

6. <span style="color:383E42"><b>Configurar vs code para auto/code complete bootstrap</b></span>
    <details><summary><span style="color:Chocolate">Detalhes</span></summary>
    <p>

    1. Instale o plugin "IntelliSense for CSS class names in HTML"
        >No vs code pressione shift+ctr+p. Procure por cache - selecione "Cache CSS class definitions"
        para atualizar o cache.
    2. Envolver um trecho de html por algum elemento
        >Selecione o trecho html que deseja -  shift+ctr+p
        procure por "wrap" - Selecione "Emmet: Wrap with Abbreviation" - Informar o elemento.
        Pode configurar uma combinação de teclas para estes comandos:
        shift+ctr+p -> wrap - Emmet: Wrap with Abbreviation - clicar na engrenagem colocar combinação desejada "shift+alt+w"


## Meta
><span style="color:383E42"><b>Cristiano Mendonça Gueivara</b> </span>
>
>>[<img src="readmeImages/githubIcon.png">](https://github.com/sspectro "Meu perfil no github")
>
>><a href="https://linkedin.com/in/cristiano-m-gueivara/"><img src="https://img.shields.io/badge/-LinkedIn-%230077B5?style=for-the-badge&logo=linkedin&logoColor=white"></a> 
>
>>[Minha Página Github - <img src="readmeImages/favicon.ico">](https://sspectro.github.io/#home "Minha Página no github")<br>



><span style="color:383E42"><b>Licença:</b> </span> Distribuído sobre a licença `Software Livre`. Veja Licença **[ISC](https://opensource.org/license/isc-license-txt/)**. para mais informações.
