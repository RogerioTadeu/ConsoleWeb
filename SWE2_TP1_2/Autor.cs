using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE2_TP1
{
    public class Autor
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }

        public Autor(string nome, string email, char genero)
        {
            Nome = nome;
            Email = email;
            Gender = genero;
        }

        
        public override string ToString()
        {
            return $"Autor = {Nome} - Email = {Email} - Genero = {Gender}";
        }


    }
}
