using System;
using System.Diagnostics.Tracing;

namespace Programs
{
    class Fecha
    {
        private int dia;
        private int mes;
        private int anio;
        private int hora;
        private int minutos;

        public Fecha(int dia, int mes, int anio, int hora, int minutos)
        {
            this.dia = dia;
            this.mes = mes;
            this.anio = anio;
            this.hora = hora;
            this.minutos = minutos;

        }

        public Fecha()
        {
            dia = 0;
            mes = 0;
            anio = 0;
            hora = 0;
            minutos = 0;
        }

        public int Dia
        {
            get{ return dia; }//get permite obtener el valor del atributo
            set{ dia = value; }//set permite asignar un valor al atributo
        }
        public int Mes
        {
            get{return mes;}
            set{dia = value;}
        }
        public int Anio
        {
            get{return anio;}
            set{anio = value;}
        }
        public int Hora
        {
            get{return hora;}
            set{hora =  value;}
        }
        public int Minutos
        {
            get{return minutos;}
            set{ minutos = value;}
        }

        //formato fechas
        public string Formatofecha()
        {
            return $"{dia}/{mes}/{anio}";
        }
        public string Formatohora()
        {
            return $"{hora}:{minutos}";
        }

        public static Fecha sumar(Fecha nuvFecha1, Fecha nuvFecha2)
        {
            int nuevoDia = nuvFecha1.dia + nuvFecha2.dia;
            int nuevoMes = nuvFecha1.mes + nuvFecha2.mes;
            int nuevoAnio =  nuvFecha1.anio + nuvFecha2.anio;
            int nuevaHora = nuvFecha1.hora + nuvFecha2.hora;
            int nuevoMinutos = nuvFecha1.minutos + nuvFecha2.minutos;

            if (nuevoDia >= 31)
            {
                nuevoMes++;
                nuevoDia -= 31;
            }
            if (nuevoMes >= 12)
            {
                nuevoAnio++;
                nuevoMes = 1;
            }
            if (nuevoMinutos >= 60)
            {
                nuevaHora++;
                nuevoMinutos =- 60;
            }
            if (nuevaHora >= 24)
            {
                nuevoDia++;
                nuevaHora -= 24;
            }
            return new Fecha(nuevoDia, nuevoMes, nuevoAnio, nuevaHora, nuevoMinutos);
        }

        public Fecha sumarndias(int ndias)
        {
            int nuevoDia = dia + ndias;
            while (nuevoDia > 31)
            {
                int fechA = DateTime.DaysInMonth(anio, mes);
                if (nuevoDia > fechA)
                {
                    nuevoDia -= fechA;
                    if (mes == 12)
                    {
                        mes = 1;
                        anio++;
                    }else
                    {
                        mes++;
                    }
                }
            }
            return new Fecha(nuevoDia, mes, anio, hora, minutos);
        }

        public static void Main()
        {
            Fecha fecha1 = new Fecha(2,3,2023,5,20);
            Fecha fecha2 = new Fecha(3,4,2023,6,30);


            Fecha sumar = Fecha.sumar(fecha1, fecha2);

            
            Console.WriteLine("Fecha 1: " + fecha1.Formatofecha());
            Console.WriteLine("Fecha 1 hora: " + fecha1.Formatohora());
            Console.WriteLine("Fecha 2: " + fecha2.Formatofecha());
            Console.WriteLine("Fecha 2 hora: " + fecha2.Formatohora());
            Console.WriteLine("Suma de fechas: " + sumar.Formatofecha());
            Console.WriteLine("Suma de fechas hora: " + sumar.Formatohora());
            fecha1 = fecha1.sumarndias(10); // Sumar 10 días
            Console.WriteLine("Fecha con mas dias: " + fecha1.Formatofecha());
        }
    }
}
