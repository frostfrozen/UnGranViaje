using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace UnGranViaje
{
    class Program
    {
        static void Main(string[] args)
        {
            var corolla = new Auto("mazda", 100);

            corolla.Encender();

            Console.Write($"Combustible inicial: ");
            corolla.CantidadCombustible();

            corolla.Acelerar(10);
            Thread.Sleep(5000);
            corolla.Acelerar(20);

            corolla.EstadoCombustible();

            corolla.Apagar();

            //estos 2 ultimos no deberian aparecer ya que el auto esta apagado
            corolla.Acelerar(10);
            corolla.EstadoCombustible();
            Console.Write($"Combustible final: ");
            corolla.CantidadCombustible();

            Console.ReadKey();

            //expected output
            /* Acelere
             * Termine Evento Acelerar
             * Acelere
             * Termine Evento Acelerar
             * OK
             * Termine Evento Acelerar*/
        }
    }
}
