using System;

namespace A_884583_.Actividad03
{
    public class Cuentas
    {
        public int codigo_cuenta { get; set; }
        public string nombre_cuenta { get; set; }
        public string tipo_cuenta { get; set; }

        public Cuentas(string linea)
        {
            var datos = linea.Split('|');

            codigo_cuenta = validarint(datos[0]);
            nombre_cuenta = datos[1];
            tipo_cuenta = datos[2];
        }


        int validarint(string entrada)
        {
            int numero;
            do
            {
                if (!int.TryParse(entrada, out numero))
                {
                    Console.WriteLine("Debe ingresar un valor numérico como código de cuenta.");

                }


            } while (numero == 0);


            return numero;
        }

    }
}