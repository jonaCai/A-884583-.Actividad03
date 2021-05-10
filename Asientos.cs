using System;
using System.Collections.Generic;
using System.IO;
namespace A_884583_.Actividad03
{
    static class Asientos
    {
        static Dictionary<int, Movimientos> DICasientos = new Dictionary<int, Movimientos>();
        static string nombreArchivo = "Diario.txt";
        public static void IngresarAsientos()
        {
            string respuesta="S";
            int count = DICasientos.Count+1;
            var movimiento = new Movimientos(0,null);
            DICasientos.Add(count, movimiento);

            while (respuesta == "S")
            {
                Console.Write("¿Ingresar otro movimiento?: s/n:  ");
                respuesta = Console.ReadLine().ToUpper();
                switch(respuesta)
                {
                    case "S":
                        count = count+1;
                        var movimiento1 = new Movimientos(movimiento.Nro_asiento,movimiento.Fecha_asiento);
                        DICasientos.Add(count,movimiento1);

                        ; break;
                    case "N":
                        if (!Asientos.validarAsiento())
                        {
                            Console.WriteLine("Los asientos ingresados no respetan la regla:  Debe = Haber.");

                        }else { Console.WriteLine("Los asientos han sido ingresados de manera correcta."); }
                        Asientos.GenerarDiario();
                        ; break;
                    default:Console.WriteLine("Debe ingresar: s o n.");break;
                };

            } ;
        }

        private static bool validarAsiento()
        {
            int sumaDebe=0;
            int sumaHaber=0;
            bool flag;


            foreach(var a in DICasientos)
            {
                sumaHaber = sumaHaber + a.Value.haber;
                sumaDebe = sumaDebe+a.Value.debe;
                

            }

            if (sumaDebe!=sumaHaber)
            {
                flag = false;

            }
            else { flag = true; }
            return flag;
        }

        private static void GenerarDiario()
        {
            

            using (var Writer = new StreamWriter(nombreArchivo, append:false))
            {
                Writer.WriteLine("NroAsiento |Fecha                    |CodigoCuenta    |Debe       |Haber      ");
                                
                foreach (var a in DICasientos)
                {
                                       
                    Writer.WriteLine($"{a.Value.Nro_asiento,11}|{a.Value.Fecha_asiento,25}|{a.Value.Codigo_Cuenta,16}|{a.Value.debe,11}|{a.Value.haber,10}");
                    
                }




            }


        }

        
        
    }
}