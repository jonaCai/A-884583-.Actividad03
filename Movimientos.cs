using System;

namespace A_884583_.Actividad03
{
    public class Movimientos
    {

        public int Nro_asiento { get; set; }
        public DateTime Fecha_asiento { get; set; }
        public int Codigo_Cuenta { get; set; }
        public int haber { get; set; }
        public int debe { get; set; }

        public Movimientos(int numero_asiento, DateTime? fecha)
        {
           if(numero_asiento>0 && fecha!= null)
            {
                Nro_asiento = numero_asiento;
                Fecha_asiento = DateTime.Parse(fecha.ToString());
                Codigo_Cuenta = validarint("Código de cuenta", true);
                haber = validarint("Haber", false);
                debe = validarint("Debe", false);

            }
            else
            {
                Nro_asiento = validarint("Numéro de asiento", false);
                Fecha_asiento = validarFecha("Fecha");
                Codigo_Cuenta = validarint("Código de cuenta", true);
                haber = validarint("Haber", false);
                debe = validarint("Debe", false);

            }
            

        }

        int validarint( string mensaje, bool flag)
        {
            int numero;
            string entrada;
            bool ok_codigo;

            do
            {
                ok_codigo = true;
                Console.Write(mensaje + "?: ");
                entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out numero))
                {
                    Console.WriteLine("Debe ingresar un valor numérico para " + mensaje);

                }
                if (numero<0)
                {

                    Console.WriteLine("Debe ingresar números positivos");
                }
                else
                {
                    if (flag == true)
                    {
                        if (!PlanDeCuentas.ValidarNroCuenta(numero))
                        {
                            Console.WriteLine("El código de cuenta no se encuentra en el plan de cuentas.");
                            ok_codigo = false;
                        }

                    }

                }

            } while (numero < 0 || ok_codigo==false);
            
            

            return numero;
        }



        DateTime validarFecha(string mensaje)
        {
            DateTime fecha;
            string entrada;
            bool flag;
            do
            {
                flag = true;
                Console.Write(mensaje + "?: ");
                entrada = Console.ReadLine();

                if (!DateTime.TryParse(entrada, out fecha))
                {
                    Console.WriteLine("Debe ingresar una fecha valida, con el formato: dd/mm/aaaa");
                    flag = false;
                }
               


            } while (flag==false);


            return fecha;

        }
    }
}