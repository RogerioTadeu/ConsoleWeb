using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE2_TP1
{
    public class Repositorio
    {
        private static readonly string nomeArquivoCSV = "livros2.csv";
        
        List<Book> arrayBook = new List<Book>();
        public Repositorio()
        {
            
            using (var file = File.OpenText(Repositorio.nomeArquivoCSV))
            {
                while (!file.EndOfStream)
                {
                    List<Autor> arrayAutor = new List<Autor>();
                    var textoLivro = file.ReadLine();
                    if (string.IsNullOrEmpty(textoLivro))
                    {
                        continue;
                    }
                    var infoLivro = textoLivro.Split(';');
                    string nome = infoLivro[0];
                    double price = Convert.ToDouble(infoLivro[1]);
                    int qty = Convert.ToInt16(infoLivro[2]);
                    string autor = infoLivro[3];
                    string email = infoLivro[4];
                    char genero = Convert.ToChar(infoLivro[5]);
                    string autor1 = infoLivro[6];
                    string email1 = infoLivro[7];
                    char genero1 = Convert.ToChar(infoLivro[8]);

                    Autor _autor = new Autor(autor, email, genero);
                    arrayAutor.Add(_autor);
                    if (autor1!="")
                    {
                        Autor _autor1 = new Autor(autor1, email1, genero1);
                        arrayAutor.Add(_autor1);
                    }

                    Book book = new Book(nome, price, qty, arrayAutor);
                    arrayBook.Add(book);
                    
                }//while

            }
        }
        public void ImprimeLista()
        {
            foreach (var book in arrayBook)
            {
                Console.WriteLine(book.MudaNome(book.Nome));
            }
        }

        public List<Book> DevolveLista()
        {
            return arrayBook;
        }
    }//class
}
