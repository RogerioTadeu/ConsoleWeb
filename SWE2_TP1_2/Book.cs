using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE2_TP1
{
    public class Book
    {
        public double Price { get; set; }
        public int Qty { get; set; }
        public string Nome { get; set; }

        List<Autor> _autors = new List<Autor>();//{ get; set; }

        public Book(string nome, double price, params Autor[] autors )
        {
            Nome = nome;
            Price = price;
            _autors = autors.ToList();
        }

        public Book(string nome, double price, int qty, List<Autor> autors )
        {
            Nome = nome;
            Price = price;
            Qty = qty;
            _autors = autors;//.ToList();
          
        }
        public string MudaNome(string nome)
        {
            var linhas = new StringBuilder();
            linhas.AppendLine("Título - " + nome);
            linhas.AppendLine("<br>");
            linhas.AppendLine("============");
            linhas.AppendLine("<br>");
            linhas.AppendLine("Preço R$" + Price + " - Quant. " + Qty);
            linhas.AppendLine("<br>");
            //linhas.AppendLine(" Quant. " + Qty);
            linhas.AppendLine("============");
            linhas.AppendLine("<br>");
            foreach (var livro in _autors)
            {
                linhas.AppendLine(livro.ToString());
                linhas.AppendLine("<br>");
            }
            
            linhas.AppendLine("=x=x=x=x=x=x=x=x=");
            linhas.AppendLine("<br>");
            linhas.AppendLine("<br>");
            return linhas.ToString();
        }

        //public string RecuperaBook()
        //{
        //    var linhas = new StringBuilder();

        //}

    }//class
}
