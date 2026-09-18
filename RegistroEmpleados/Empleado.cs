using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroEmpleados
{
    internal class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal SueldoBase { get; set; }
        public int HorasExtrasTrabajadas { get; set; }

        public decimal calcularSueldoTotal()
        {
           return SueldoBase + (HorasExtrasTrabajadas * 50);
        }
        public override string ToString()
        {
            return $"{Id} Nombre: {Nombre}| Sueldo : Q{SueldoBase}| Horas Extras: {HorasExtrasTrabajadas} = Q{calcularSueldoTotal()}";
        }
    }
}

