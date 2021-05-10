using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_884583_.Actividad03
{
    class Program
    {
        static void Main(string[] args)
        {

            string respuesta;

            PlanDeCuentas.CargarPlanDeCuentas();
            do
            {
                Console.WriteLine("Elija una de las siguientes opciones: \n * 1. Ver plan de cuentas; \n * 2. Ingresar asientos; \n * 3. Salir; ");
                Console.Write("Eleccion: ");
                respuesta = Console.ReadLine();
                
                switch (respuesta)
                {
                    case "1":
                        PlanDeCuentas.MostrarPlan();
                        ; break;

                    case "2":
                        Asientos.IngresarAsientos();

                        ; break;

                    case "3":
                        Console.WriteLine("Presione una tecla para terminar:")
                        ; break;
                    default: Console.WriteLine("Debe ingresar 1, 2 o 3.");break;
                        
                }




            } while (respuesta != "3");

            Console.ReadKey();
        }
    }
}
