using System;
//using ExemploAula02.Negocio;
//using ExemploAula02.Repositorio;
//using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SWE2_TP1
{

    class Program
    {

        static void Main(string[] args)
        {
            //Repositorio ini = new Repositorio();


            IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Inicial>()
                .Build();
            host.Run();


            //ini.ImprimeLista();



        }//main

        

    }
}
