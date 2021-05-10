using System;
using System.Collections.Generic;
using System.IO;

namespace A_884583_.Actividad03
{

    
    static class PlanDeCuentas
    {
        static Dictionary<int, Cuentas> plan = new Dictionary<int, Cuentas>();
        static string nombreArchivo = "Plan de cuentas.txt";

        public static void CargarPlanDeCuentas()
        {
            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {

                    while(!reader.EndOfStream)
                    {

                        var linea = reader.ReadLine();
                        if (!linea.Contains("Codigo"))
                        {
                            var cuenta = new Cuentas(linea);
                            plan.Add(cuenta.codigo_cuenta, cuenta);

                        }
                        
                        
                    }
                    
                }
                    
            }

        }
        public static void MostrarPlan()
        {
            
            Console.WriteLine("Plan de cuentas: ");
            Console.WriteLine("  Codigo Cuenta  |    Nombre Cuenta            |    Tipo Cuenta ");
     
            foreach (var a in plan)
            {
                string codigo = a.Value.codigo_cuenta.ToString();
                string nombre = a.Value.nombre_cuenta;
                string tipo = a.Value.tipo_cuenta;
                


                if (nombre.Length > 18)
                {
                    nombre = nombre.Substring(0, 17) + "...";
                };

                string linea = codigo.PadRight(18) + nombre.PadLeft(18) + tipo.PadLeft(18);

                Console.WriteLine(linea);
            }
        }


        public static bool ValidarNroCuenta(int numero_cuenta)
        {
            bool flag = false;

            foreach (var a in plan)
            {
                
                if (numero_cuenta== a.Value.codigo_cuenta)
                {
                    flag = true;
                };

                
            }


            return flag;
        }


    }
}