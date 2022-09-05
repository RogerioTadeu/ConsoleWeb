using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE2_TP1
{
    public class Inicial
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
              builder.MapRoute("Livros", ExibeLivros);
              builder.MapRoute("Livros/Tudo", ExibeTudo);
            //builder.MapRoute("Livros/Lido", LivrosLidos);
            //builder.MapRoute("Cadastro/NovoLivro/", ExibeFormulario);
            //builder.MapRoute("Cadastro/Incluir", ProcessaFormulario);
            var rotas = builder.Build();

            //http://localhost:5000/Livros/
            //http://localhost:5000/Livros/Tudo

            app.UseRouter(rotas);
            //app.Run(Roteamento);
        }

        public Task ExibeLivros(HttpContext context)
        {
            // var _repo = new LivroRepositorioCSV();
            var ini = new Repositorio();
            var conteudoArquivo = CarregaArquivoHTML("Page");
            List<Book> arrayBook = ini.DevolveLista();

            foreach (var livro in arrayBook)
            {
                conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM", $"<li>{livro.Nome}</li>#NOVO-ITEM#");

            }
            conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", "");
            return context.Response.WriteAsync(conteudoArquivo);
        }

        public Task ExibeTudo(HttpContext context)
        {
            // var _repo = new LivroRepositorioCSV();
            var ini = new Repositorio();
            var conteudoArquivo = CarregaArquivoHTML("Page");
            List<Book> arrayBook = ini.DevolveLista();

            //var titulo = CarregaArquivoHTML("Page");
            //titulo = titulo.Replace("#NOVO-ITEM1", "Livros disponiveis");
            //conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", $"<h1>Livros disponíveis</h1>");
            foreach (var livro in arrayBook)
            {
                conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", $"<li>{livro.MudaNome(livro.Nome)}</li>#NOVO-ITEM#");

            }
            conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", "#####################");
            return context.Response.WriteAsync(conteudoArquivo);
        }


        private string CarregaArquivoHTML(string nomeArquivo)
        {
            //var nomeCompletoArquivo = $"HTML/{nomeArquivo}.html";
            var nomeCompletoArquivo = $"{nomeArquivo}.html";
            using (var arquivo = File.OpenText(nomeCompletoArquivo))
            {
                return arquivo.ReadToEnd();
            }
        }

    }//class
}
