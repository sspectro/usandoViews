# Usando Views em Aspnet Core 6 e Bootstrap5 C#

>Criando uma aplicação AspNet Core 6 C# - usandoViews - Treinamento Youtube Ricardo Maroquio. 
> 
>>Ricardo Maroquio [Desenvolvimento Web com ASP.NET - Criando a Aplicação Web Partindo de um Template Mínimo](https://www.youtube.com/watch?v=qom0aOGSDRs&list=PL0YuSuacUEWuN8xnvk2b5yW_koKbkHh_m&index=8)
Youtuber - [Ricardo Maroquio](https://www.youtube.com/@maroquio)

## Ambiente de Desenvolvimento e Tecnologias:
    C#, Windows, Bootstrap5, CSS, HTML

## Documentação
- [C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)
- [Bootstrap5](https://getbootstrap.com/)


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
    2. size="2">Criar pastas Views/Home e arquivo Index.cshtml  
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

    Após execução da instalação do libman, deve reiniciar projeto ou fechar e abrir terminal novamente para executar os próximos comandos  

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
        ><font size="2">No vs code pressione shift+ctr+p. Procure por cache - selecione "Cache CSS class definitions"</font>
        para atualizar o cache.
    2. Envolver um trecho de html por algum elemento  
        ><font size="2">Selecione o trecho html que deseja -  shift+ctr+p
        procure por "wrap" - Selecione "Emmet: Wrap with Abbreviation" - Informar o elemento.
        Pode configurar uma combinação de teclas para estes comandos:
        shift+ctr+p -> wrap - Emmet: Wrap with Abbreviation - clicar na engrenagem colocar combinação desejada "shift+alt+w"</font>
    </p>

    </details> 

    ---

7. <span style="color:383E42"><b>Criando CRUD</b></span>
    <details><summary><span style="color:Chocolate">Detalhes</span></summary>
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
    2. Criar Pasta Models e Modelo/classe `Usuario.cs`  
        <font size="2">Cria Modelo com uma lista de usuários que são adicionados no construtor.</font>
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
    4. Testar abrir form sem passar parâmetro (Id) na url - Testar passando parâmetro.
    5. Informar o modelo que a view irá receber e TagHelper em Cadastrar.cshtml:  
        <font size="2">
        No topo antes do código html - Cadastrar.cshtml. Melhora o code complete - identifica erro, caso não reconheça o campo como do modelo. Não há necessidade de passar um objeto vazio para view, Pois a view já faz isso automaticamente. Mas deve usar tag helper nos campos</font>

        ```htm
        @model UsandoViews.Models.Usuario
        @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
        ```
    6. Criar action "Usuarios()" em HomeController.cs:  
        <font size="2">Retorna lista de usuários para view Usuarios.cshtml</font>
        ```cs
        public IActionResult Usuarios()
        {
            return View(Usuario.Listagem);
        }
        ```
    7. Criar view Usuarios.cshtml:  
        <font size="2">Exibe a lista de usuários e permite edição:</font>
        ```html
        @model IQueryable<UsandoViews.Models.Usuario>
        @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
        <!DOCTYPE html>
        <html lang="pt-br">

        <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <link rel="stylesheet" href="/lib/bootstrap5/dist/css/bootstrap.css">
            <title>Usuários</title>
        </head>

        <body>

            <div class="container">
                <h1 class="text-primary">Usuários</h1>
                <hr>
                <a href="/Home/Cadastrar" class="btn btn-primary">Novo Usuário</a>
                <table class="table">
                    <thead>
                        <tr>
                            <th>Nome</th>
                            <th>E-mail</th>
                            <th>Ações</th>
                        </tr>
                    </thead>

                    <tbody>
                        @foreach (var u in Model)
                        {
                            <tr>
                                <td>@u.Nome</td>
                                <td>@u.Email</td>
                                <td>
                                    <a asp-action="Cadastrar" asp-route-id="@u.IdUsuario"
                                        class="btn btn-sm btn-secondary">Alterar</a>
                                </td>
                            </tr>
                        }
                    </tbody>

                </table>
            </div>
        </body>

        </html>
        ```
    8. Adicionar action `Cadastrar` do tipo Post em HomeController.cs:  
        <font size="2">Action Responsável por salvar o Usuário - Recebe objeto usuário como parâmetro.</font>
        ```cs
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            Usuario.Salvar(usuario);
            return RedirectToAction("Usuarios");
        }
        ```
    9. Adicionar metodo "Salvar" em Usuario.cs:  
        <font size="2">Método responsável por adicionar objeto na lista de Usuários.</font>
        ```cs
        public static void Salvar(Usuario usuario)
        {
            var usuarioExistente = Usuario.listagem.Find(u => u.IdUsuario == usuario.IdUsuario);
            if (usuarioExistente != null)
            {
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Email = usuario.Email;
            }
            else
            {
                int maiorId = Usuario.Listagem.Max(u => u.IdUsuario);
                usuario.IdUsuario = maiorId + 1;
                Usuario.listagem.Add(usuario);
            }
        }
        ```
    10. Adicionar botão "Ecluir" junto ao botão salvar view Usuarios.cshtml:  
        <font size="2">Método responsável por adicionar objeto na lista de Usuários.</font>
        ```html
        <a asp-action="Excluir" asp-route-id="@u.IdUsuario" class="btn btn-sm btn-danger">Excluir</a>
        ```
    11. Método responsáve pela exclusão do usuários da lista:  
        ```cs
        public static void Excluir(int IdUsuario)
        {
            var usuarioExistente = Usuario.listagem.Find(u => u.IdUsuario == IdUsuario);
            if (usuarioExistente != null)
            {
                Usuario.listagem.Remove(usuarioExistente);
            }
        }
        ```
    12. Adicionar action "Excluir" do tipo Get e Post ao HomeController.cs:  
        <font size="2">Método do tipo Get exibe a view "Excluir" logo após clicar em "Excluir" no usuário na tabela - Ao confirmar, executa o submit - que usa o método do tipo Post, que então efetua a exclusão.</font>
        ```cs
        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            var usuario = new Usuario();
            if (id.HasValue && Usuario.Listagem.Any(u => u.IdUsuario == id))
            {
                usuario = Usuario.Listagem.Single(u => u.IdUsuario == id);
                return View(usuario);
            }
            return RedirectToAction("Usuarios");
        }

        [HttpPost]
        public IActionResult Excluir(Usuario usuario)
        {
            Usuario.Excluir(usuario.IdUsuario);
            return RedirectToAction("Usuarios");
        }
        ```
    </p>

    </details> 
    
    ---

8. <span style="color:383E42"><b>Usando Páginas de Layout e ViewBag em um CRUD</b></span>
    <details><summary><span style="color:Chocolate">Detalhes</span></summary>
    <p>

    - Criar pasta shared e arquivo `Views\Shared\_Layout.cshtml`  
        `_Layout` contém o `hml` padrão para todas as views
        - Inluído [navbar bootstrap5](https://getbootstrap.com/docs/5.0/components/navbar/)
        - Incluir fundo escuro navbar - `<nav class="navbar navbar-expand-lg navbar-dark bg-dark">`
        - Incluir opção `Cadastrar` - `<a class="nav-link" asp-action="Cadastrar">Cadastrar</a>`
        - Uso de ViewBag `<title>Usuário :: @ViewBag.Subtitulo</title>`
        ```c#
        @{
            var actionAtual = ViewContext.RouteData.Values["action"].ToString();
        }

        <!DOCTYPE html>
        <html lang="pt-br">

        <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <link rel="stylesheet" href="/lib/bootstrap5/dist/css/bootstrap.css">
            <title>Usuário :: @ViewBag.Subtitulo</title>
        </head>

        <body>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
                <div class="container">
                    <a class="navbar-brand" href="#">Controle de Usuários</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarMain">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarMain">
                        <div class="navbar-nav">
                            <a class="nav-link @(actionAtual == "Index" ? "active" : "")" asp-action="Index">Home</a>
                            <a class="nav-link @(actionAtual == "Usuarios" ? "active" : "")"" asp-action="
                                Usuarios">Usuários</a>
                            <a class="nav-link @(actionAtual == "Cadastrar" ? "active" : "")"" asp-action="
                                Cadastrar">Cadastro</a>

                        </div>
                    </div>
                </div>
            </nav>

            <div class="container mt-2">
                @RenderBody()
            </div>
        </body>

        </html>
        ```
    - Criar view `Views\_ViewStart.cshtml`  
        Para conter os códigos repetitivos, diminuindo a redundância - Arquivo que por convenção é executado primeiro na renderização de todas as views.
        É incluído de forma automática em todas as views. Então podemos Colocar neste arquivo a configurção `Layout`
        ```C#
        @{
            Layout = "_Layout";
        }
        ```
    
    - Criar view `Views\_ViewImports.cshtml`  
        Também para diminuir redundância, tirando códigos repetitivos das outras views e concentrando nesta.
        Adicionado `tagHelper`
        ```C#
        @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
        @namespace UsandoViews.Models
        ```

    - View `Views\Home\Index.cshtml` modificada e incluído uso de `ViewBag`
        ```C#
        @{
            ViewBag.Subtitulo = "Página Principal";
        }

        <h1 class="text-primary">CRUD com ASP.NET Core</h1>
        <hr>
        <h3 class="text-info">Usuários Cadastrados: @ViewBag.QtdeUsuarios</h3>
        <a href="/Home/Usuarios" class="btn btn-primary">Usuário</a>
        ```
        Caso precise, pode enviar a configuração do subtitulo da página da action, basta comentar ou remover a configuração na página html
        ```cs
        public IActionResult Index()
        {
            ViewBag.Subtitulo = "Página Principal";
             //...
        ```

    - Atribuindo valor a  `ViewBag.QtdeUsuarios` em Action Index `Controllers\HomeController.cs`
        ```C#
        public IActionResult Index()
        {
            ViewBag.QtdeUsuarios = Usuario.Listagem.Count();
            return View();
        }
        ```
    </p>

    </details> 
    
    ---

9. <span style="color:383E42"><b>Usando Views Parciais e TempData em um CRUD</b></span>
    <details><summary><span style="color:Chocolate">Detalhes</span></summary>
    <p>
    
    - Modificar o método `Excluir` em `Usuario.cs`  
        `Incluir retorno bool`
        ```cs
        public static bool Excluir(int IdUsuario)
        {
            var usuarioExistente = Usuario.listagem.Find(u => u.IdUsuario == IdUsuario);
            if (usuarioExistente != null)
            {
                //Retorna um booleano 
                return Usuario.listagem.Remove(usuarioExistente);
            }
            return false;
        }
        ```
    - Modificar action HttpPost `Excluir`  
        `Retorna O resultado da exclusão`
        ```cs
        [HttpPost]
        public IActionResult Excluir(Usuario usuario)
        {
            //Usando ViewBag ao reprocessar página - perde o valor passado
            //ViewBag.Excluiu = Usuario.Excluir(usuario.IdUsuario);

            //Não perde o valor ao reprocessar página - fica armazenado em cookies - tempo de vida é de uma requisição
            TempData["Excluiu"] = Usuario.Excluir(usuario.IdUsuario);

            return RedirectToAction("Usuarios");
        }
        ```
    - Modificar `Usuarios.cshtml`  
        Mostrar mensagem de status da exclusão na página - [bootstrap Alert](https://getbootstrap.com/docs/5.3/components/alerts/)
        ```cs
        //...
        <a href="/Home/Cadastrar" class="btn btn-primary">Novo Usuário</a>
        @* se renderizada após exclusão de usuário, será diferente de null *@
        @* @if(ViewBag.Excluiu != null) *@
        @if (TempData.ContainsKey("Excluiu"))
        {
            var excluiu = (bool)TempData["Excluiu"];
            if (excluiu)
            {
                @* <h5>Usuário excluído com sucesso.</h5> *@
                <div class="alert alert-success alert-dismissible fade show" role="alert">
                    <strong>Usuário excluído com sucesso!</strong>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
            }
            else
            {
                @* <h5>Não foi possível excluir o usuário.</h5> *@
                <div class="alert alert-warning alert-dismissible fade show" role="alert">
                    <strong>Não foi possível excluir o usuário.</strong>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
            }
        }
        //...
        ```
    - `Opção1` JavaScript  bootstrap  
        Adicionar java script bootstrap em `_Layout.cshtml` que adiciona código de script é adicionado a todas as páginas
        ```html
        //...
        <script src="/lib/bootstrap5/dist/js/bootstrap.js"></script>
        </body>
        </html>
        ```
    - `Opção2` JavaScript  bootstrap  
        Adicionar section com tag do javaScript do bootstrap em `Usuarios.cshtml`. Desta forma, só será incluído o JavaScript bootstrap caso esteja definido em uma section da página
        ```cs
        //...
        @section Scripts{
            <script src="/lib/bootstrap5/dist/js/bootstrap.js"></script>
        }
        ```
        Adicionar `RenderSection` em `_Layout.cshtml`  
        Aqui(nesta posição do código html) será renderizada a section de nome `Scripts`.  Não importa qual posição da view está a section.  
        ```cs
        //...
        @* O parâmetro false, indica que não é obrigatório existir esta section nas páginas que herdam _Layout. As views só definem se quiserem *@

        @RenderSection("Scripts", false)
        </body>

        </html>
        ```
    - Adicionar Footer  
        Adicionar Footer com um renderSection Footer em _Layout.cshtml  
        ```cs
        <div class="text-light bg-dark p-3 fixed-bottom text-center">
            Todos os direitos reservados<br>
            @RenderSection("Footer",false)
        </div>
        ```  
        Adicionar section Footer em index.cshtml  
        ```cs
        //...
        @section Footer{
            <span>Página Principal</span>
        }
        ``` 
        Adiciona RenderSection LogoPagina em _Layout.cshtml  
        Caso a pagina que herda layout possua uma sessão LogoPagina, então, mostra imagem definida nesta sessão, senão, mostra uma imagem padrão.  
        ```cs
        <body>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
                <div class="container">
                    <a class="navbar-brand" href="#">
                        @if (IsSectionDefined("LogoPagina"))
                        {
                            @RenderSection("LogoPagina", false)
                        }else
                        {
                            <img src="/img/pagina.png" height="24" class="d-inline-block align-text-bottom">
                        }
                        Controle de Usuários
                    </a>
        //...
        ```  
    - Adicionar pasta wwwroot/img com 3 imagens  
        `form.png, pagina.png e usuarios.png`  
    - Adicionar section `LogoPagina` e `Usuarios.cshtml`  
        ```cs
        //...
        @section LogoPagina{
            <img src="/img/usuarios.png" height="24" class="d-inline-block align-text-bottom">
        }
        ``` 
    - Adicionar section `LogoPagina` e `Cadastrar.cshtml ` 
        ```cs
        //...
        @section LogoPagina {
            <img src="/img/form.png" height="24" class="d-inline-block align-text-bottom">
        }
        ```
    - Incluir view parcial `MensagemInfo.cshtml`  
        Irá conter o html com mensagem de alerta `success`
        ```cshtml
        @* Define o modelo desta view como do tipo string *@
        @model String
        <div class="alert alert-success alert-dismissible fade show" role="alert">
            @* O model String informado acima será renderizado aqui *@
            @Model
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
        ```
    - Incluir view parcial `MensagemErro.cshtml`  
        Irá conter o html com mensagem de alerta warning
        ```cs

        ```

        
        
        




    </p>

    </details> 
    
    ---



## Autor
><span style="color:383E42"><b>Cristiano Mendonça Gueivara</b> </span>
>
>>[<img src="https://sspectro.github.io/images/githubIcon.png">](https://github.com/sspectro "Meu perfil no github")
>
>><a href="https://linkedin.com/in/cristiano-m-gueivara/"><img src="https://sspectro.github.io/images/linkedinIcon.png"></a> 
>
>>[<img src="https://sspectro.github.io/images/cristiano.jpg" height="25" width="25"> - Minha Página Github](https://sspectro.github.io/#home "Minha Página no github")<br>

><span style="color:383E42"><b>Licença:</b> </span> Distribuído sobre a licença `Software Livre`. Veja Licença **[MIT](https://github.com/sspectro/Net-Core6-Com-Bootstrap5/blob/main/LICENSE)**.
