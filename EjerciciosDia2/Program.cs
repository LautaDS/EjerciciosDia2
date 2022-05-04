using System;
using System.Collections;
using System.Collections.Generic;

namespace EjerciciosDia2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int ej;
            do
            {
                Console.WriteLine("Por favor elija que ejercicio quiere ver:");
                Console.WriteLine("(1) Ejercicio 5");
                Console.WriteLine("(2) Ejercicio 6");
                Console.WriteLine("(3) Ejercicio 12");
                Console.WriteLine("(4) Ejercicio Pilas");
                Console.WriteLine("(0) Salir");

                try
                {
                    ej = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("No hay un ejercicio cargado con ese input, recuerde ponerlo con numeros.");
                    ej = 99999;
                }
                switch (ej)
                {
                    case (1):
                        program.Ejercicio5Dia1();
                        break;

                    case (2):
                        program.Ejercicio6Dia1();
                        break;
                    case (3):
                        program.Ejercicio12Dia1();
                        break;

                    case (4):
                        program.EjercicioPilas();
                        break;

                    case (0):
                        break;

                    case (99999):
                        break;

                    default:
                        break;
                }

            } while (ej != 0);

            Console.WriteLine("Gracias por revisar mis ejercicios");
            Console.ReadLine();
        }

        #region Ejercicios
        public void Ejercicio5Dia1()
        {
            int contadorCochesquePasaron = 0, errores = 0, biciContador = 0, motoContador = 0, cocheContador = 0, camionContador = 0, sumarTodoslosvehiculos = 0, intervaloEntreCoches = 0, tempintervaloEntreCoches = 0;
            bool lastWasError = false, tooManyErrors = false;
            int vehiculo = 0;

            double tempPercentage = 0;



            do
            {
                Console.WriteLine("Ingrese el vehiculo que acaba de pasar");
                try
                {
                    vehiculo = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("No hay un vehiculo cargado con ese input, sera tratado como un error.");
                    vehiculo = 4;
                }

                switch (vehiculo)
                {
                    case (0):
                        biciContador++;
                        lastWasError = false;
                        tempintervaloEntreCoches++;
                        break;
                    case (1):
                        motoContador++;
                        lastWasError = false;
                        tempintervaloEntreCoches++;
                        break;
                    case (2):
                        cocheContador++;
                        lastWasError = false;
                        if (tempintervaloEntreCoches > intervaloEntreCoches)
                        {
                            intervaloEntreCoches = tempintervaloEntreCoches;
                            tempintervaloEntreCoches = 0;
                        }
                        else
                        {
                            tempintervaloEntreCoches = 0;
                        }
                        break;
                    case (3):
                        camionContador++;
                        lastWasError = false;
                        tempintervaloEntreCoches++;
                        break;
                    case (4):
                        errores++;
                        if (lastWasError)
                        {
                            tooManyErrors = true;
                            break;
                        }
                        else
                        {
                            lastWasError = true;
                        }
                        break;

                    default:
                        break;
                }

            } while (contadorCochesquePasaron < 1000 || tooManyErrors);

            sumarTodoslosvehiculos = biciContador + motoContador + cocheContador + camionContador;
            Console.WriteLine("La cantidad total de vehiculos que pasaron fue: " + sumarTodoslosvehiculos);


            tempPercentage = (biciContador / sumarTodoslosvehiculos) * 100;
            Console.WriteLine("El porcentaje de bicis que pasaron es de " + tempPercentage + "%");

            tempPercentage = (motoContador / sumarTodoslosvehiculos) * 100;
            Console.WriteLine("El porcentaje de motos que pasaron es de " + tempPercentage + "%");

            tempPercentage = (cocheContador / sumarTodoslosvehiculos) * 100;
            Console.WriteLine("El porcentaje de bicis que pasaron es de " + tempPercentage + "%");

            tempPercentage = (camionContador / sumarTodoslosvehiculos) * 100;
            Console.WriteLine("El porcentaje de camiones que pasaron es de " + tempPercentage + "%");

            Console.WriteLine("El maximo intervalo entre dos coches fue de " + intervaloEntreCoches + " de vehiculos");

        }

        public void Ejercicio6Dia1()
        {
            double montoAPagar = 0;
            int horasUsandoCabina = 0;
            
            Console.WriteLine("El monto a pagar por hora por una cabina de internet es de $1,5. Cada cinco horas te regalan una hora gratis.");
            montoAPagar = CalcularHorasAPagar(12) * 1.5f;
            Console.WriteLine("En caso de haber estado 12 horas, por lo tanto, usted deberia pagar: " + montoAPagar+"$");
            montoAPagar = 0;
            
           
            do
            {
                Console.WriteLine("Por favor ingrese la cantidad de horas que estuvo en la cabina.");
                try
                {
                    horasUsandoCabina = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("El numero ingresado es incorrecto");
                    horasUsandoCabina = 0;
                }
            } while (horasUsandoCabina == 0);

            montoAPagar = CalcularHorasAPagar(horasUsandoCabina) * 1.5f;
            Console.WriteLine("Usted estuvo " + horasUsandoCabina + " usando una cabina, por lo tanto debe abonar " + montoAPagar + "$");

        }

        public void Ejercicio12Dia1()
        {
            string codigoBrutoProducto;
            int[] codigoProducto = new int[7];
            int producto = 0;
            int departamentoDeProducto = 0;
            float precioDelProducto = 0;
            bool consulta = true;
            float constanteDeBeneficio = 3.5f;
            
            do
            {
                Console.WriteLine("Por favor ingrese el codigo del producto que quiere escanear");
                codigoBrutoProducto = Console.ReadLine();
                
                // El area de Try and catch es para revisar que lo ingresado sea una cadena de 7 numeros especificamente.
                    try
                    {
                        for(int i = 0; i == codigoBrutoProducto.Length; i++)
                        {
                            codigoProducto[i] = Convert.ToInt32(codigoBrutoProducto[i]);
                        }
                   
                    }
                    catch
                    {
                        Console.WriteLine("El codigo que ingreso es incorrecto, recuerde que es una secuencia numerica de 7 digitos");
                        consulta = true;
                    // limpiar el array.
                    }

                // Una vez confirmado que lo que guardamos son 7 numeros, revisamos segmento por segmento que sea valido acorde al formato del ejercicio
                if(codigoProducto[0] == 0)
                {
                    Console.WriteLine("El area de departamento no puede ser 0");
                    consulta = true;
                } else
                {
                    departamentoDeProducto = codigoProducto[0];
                    if(codigoProducto[1] == 0 && codigoProducto[2] == 0)
                    {
                        Console.WriteLine("El tipo de articulo es incorrecto, no puede ser 0 0 ");
                        consulta = true;
                    } else
                        {
                            string productoString = string.Concat(codigoProducto[1]) + string.Concat(codigoProducto[2]);
                            producto = int.Parse(productoString);
                            string precioString = string.Concat(codigoProducto[3]) + string.Concat(codigoProducto[4]) + string.Concat(codigoProducto[5]) + string.Concat(codigoProducto[6]);
                            precioDelProducto = int.Parse(precioString);

                            precioDelProducto = ((precioDelProducto * departamentoDeProducto) / 100) * constanteDeBeneficio;

                            Console.WriteLine("El departamento es: " + departamentoDeProducto);
                            Console.WriteLine("El articulo es: " + producto);
                            Console.WriteLine("El precio unitario es: " + precioDelProducto);

                             Console.WriteLine("Quiere hacer otra consulta? S/N");
                                string otraConsulta = Console.ReadLine();
                               if (otraConsulta == "S" || otraConsulta == "Si")
                                {
                                    consulta = true;
                                } else
                                    {
                                        consulta = false;
                                    }
                    }
                }
   
            } while (consulta);

            
        }

        public void EjercicioPilas()
        {
            Stack<double> pilaDeNumero = new Stack<double>();

            bool flagEstaTodoBien = true;
            int cuantos = 0;
            Console.Write("Cuantos numeros quiere poner en esta pila? ");

            do
            {
                try
                {
                    cuantos = int.Parse(Console.ReadLine());
                    flagEstaTodoBien = true;
                }
                catch
                {
                    Console.Write("Error al ingresar el numero, ingreselo nuevamente ");
                    flagEstaTodoBien = false;
                }

            } while (flagEstaTodoBien == false);

            flagEstaTodoBien = true;

            for (int i = 0; i < cuantos; i++)
            {
                do
                {
                    try
                    {
                        Console.Write("ingrese un numero ");
                        pilaDeNumero.Push(double.Parse(Console.ReadLine()));
                        flagEstaTodoBien = true;
                    }
                    catch
                    {
                        Console.Write("lo ingresado es erroneo, ingrese otro numero ");
                        flagEstaTodoBien = false;
                    }
                } while (flagEstaTodoBien == false);
            }


            for (int i = 0; i < cuantos; i++)
            {
                Console.WriteLine(pilaDeNumero.Pop());
            }
            Console.ReadLine();
        }

        #endregion

        #region metodos generales
        public int CalcularHorasAPagar (int horas)
        {
            int horasDeRegalo = horas % 5;
            horas -= horasDeRegalo;
            return horas;
        }

        #endregion
    }




  


}
