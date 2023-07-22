# Usando Views em Aspnet Core 6 C#

<!-- Variáveis de Referência-->
{% capture nameOfVariableToCapture %}`OOPPPP`{% endcapture %}

Content before variable.
{{ nameOfVariableToCapture }}
Content after variable.



Nome: Cris

{{Nome}}


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
    </p>

    </details> 

    ---

7. ### <span style="color:383E42"><b>Criando CRUD</b></span>
    <!-- <details><summary><span style="color:Chocolate">Detalhes</span></summary> -->
    <p>

    1. Criar a `Views/Home/Cadastrar.cshtml`
        ```html
        <!DOCTYPE html>
        <html lang="pt-br">

        <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <link rel="stylesheet" href="/lib/bootstrap5/dist/css/bootstrap.css">
            <title>Cadastro de Usuário</title>
        </head>

        <body>

            <div class="container">
                <h1 class="text-primary">Cadastro de Usuário</h1>
                <hr>
                <form method="POST" class="w-25" action="">
                    <div class="form-group">
                        <label for="txtNome">Nome:</label><br>
                        <input type="text" class="form-control" name="Nome" id="txtNome">
                    </div>
                    <div class="form-group">
                        <label for="txtEmail">E-mail:</label><br>
                        <input type="text" class="form-control" name="Email" id="txtEmail">
                    </div>
                    <div class="mt-3">
                        <button class="btn btn-primary" type="submit">Salvar</button>
                    </div>
                </form>

            </div>
        </body>

        </html>
        ```
    2. Criar Pasta Momdels e Modelo/classe `Usuario.cs`
        Cria Modelo com uma lista de usuários que são adicionados no construtor.
        ```cs
        namespace UsandoViews.Models
        {
            public class Usuario
            {
                public int Id { get; set; }
                public string Nome { get; set; }
                public string Email { get; set; }
                private static List<Usuario> listagem = new List<Usuario>();
                // Lista de usuário apenas para consulta
                public static IQueryable<Usuario> Listagem
                {
                    get
                    {
                        return listagem.AsQueryable();
                    }
                }
                
                static Usuario()
                {
                    Usuario.listagem.Add(
                        new Usuario { Id = 1, Nome = "Fulano", Email = "fulano@email.com" });
                    Usuario.listagem.Add(
                        new Usuario { Id = 2, Nome = "Cicrano", Email = "cicrano@email.com" });
                    Usuario.listagem.Add(
                        new Usuario { Id = 3, Nome = "Beltrano", Email = "beltrano@email.com" });
                    Usuario.listagem.Add(
                        new Usuario { Id = 3, Nome = "João", Email = "joao@email.com" });
                    Usuario.listagem.Add(
                        new Usuario { Id = 3, Nome = "Maria", Email = "maria@email.com" });
                }
            }
        }
        ```
    3. Criar IActionResult Cadastrar
        ```cs
        //Parametro id da url é opcional, por isso deve ser do tipo anulável -?-
        //Quando não é passado na rota, esse parametro vai entrar como valor nulo
        public IActionResult Cadastrar(int? id)
        {
            var usuario = new Usuario();
            if (id.HasValue)
            {
                if (Usuario.Listagem.Any(u => u.Id == id))
                    usuario = Usuario.Listagem.Single(u => u.Id == id);
            }
            return View(usuario);
        }
        ```
    4. Testar abrir form sem passar parametro na url e passando parametro
    </p>

    </details> 
    ---



## Meta
><span style="color:383E42"><b>Cristiano Mendonça Gueivara</b> </span>
>
>>[<img src="readmeImages/githubIcon.png">](https://github.com/sspectro "Meu perfil no github")
>
>><a href="https://linkedin.com/in/cristiano-m-gueivara/"><img src="https://img.shields.io/badge/-LinkedIn-%230077B5?style=for-the-badge&logo=linkedin&logoColor=white"></a> 
>
>>[Minha Página Github - <img src="readmeImages/favicon.ico">](https://sspectro.github.io/#home "Minha Página no github")<br>



><span style="color:383E42"><b>Licença:</b> </span> Distribuído sobre a licença `Software Livre`. Veja Licença **[ISC](https://opensource.org/license/isc-license-txt/)**. para mais informações.
