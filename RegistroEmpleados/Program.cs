namespace RegistroEmpleados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcion;
            List<Empleado> empleados = new List<Empleado>();
            int idEmpleado = 1;

            do
            {
                opcion = MostrarMenu();

                switch (opcion)
                {
                    case "1":
                        AgregarEmpleado(empleados, ref idEmpleado);
                        break;
                    case "2":
                        MostrarEmpleados(empleados);
                        break;
                    case "3":
                        BuscarEmpleado(empleados);
                        break;
                    case "4":
                        calcularFactorial();
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
            while (opcion != "5");

        }

        public static string MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== Registro de Empleados ===");
            Console.WriteLine("1. Agregar Empleado");
            Console.WriteLine("2. Listar Empleados");
            Console.WriteLine("3. Buscar Empleado");
            Console.WriteLine("4. Calcular Factorial");
            Console.WriteLine("5. Salir");
            Console.Write("Ingrese una opción: ");
            return Console.ReadLine();
        }

        private static void AgregarEmpleado(List<Empleado> empl, ref int id)
        {
            Console.WriteLine();
            Console.Write("Ingrese un nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Sueldo base: ");
            bool sueldoBaseOk = decimal.TryParse(Console.ReadLine(), out decimal sueldoBase);
            Console.Write("Horas extras trabajadas: ");
            bool horasExtrasOk = int.TryParse(Console.ReadLine(), out int horasExtras);

            if (!sueldoBaseOk || sueldoBase <= 0 || !horasExtrasOk || horasExtras <0 || string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("Datos inválidos, intente nuevamente.");
                return;
            }
            else
            {
                Empleado nuevoEmpleado = new Empleado
                {
                    Id = id,
                    Nombre = nombre,
                    SueldoBase = sueldoBase,
                    HorasExtrasTrabajadas = horasExtras
                };
                empl.Add(nuevoEmpleado);

                Console.WriteLine($"Pago total = Q{nuevoEmpleado.calcularSueldoTotal()}");
                id++;
                Console.WriteLine("Empleado agregado exitosamente.");
            }
        }

        private static void MostrarEmpleados(List<Empleado> empl)
        {
            
            if (empl.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No hay empleados registrados.");
                return;
            }
            decimal totalSueldos = 0;
            foreach (Empleado empleado in empl)
            {
                Console.WriteLine(empleado);
                totalSueldos += empleado.calcularSueldoTotal();
            }
                Console.WriteLine($"Total Nomina: Q{totalSueldos}");
        }
        private static void BuscarEmpleado(List<Empleado> empl)
        { 
                Console.WriteLine("Empleado que desea buscar: ");
                string BuscarEmpleado = Console.ReadLine().Trim().ToUpper();
                bool encontrado = false;
                foreach (Empleado empleado in empl)
                { 
                  if (empleado.Nombre.ToUpper().Contains(BuscarEmpleado))
                  {
                    Console.WriteLine($"- {empleado}");
                    encontrado = true;
                  }
                }
            if (!encontrado) 
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        private static void calcularFactorial()
        {
            Console.WriteLine();
            Console.WriteLine("Ingrese un número para calcular su factorial: ");
            bool numeroOk = int.TryParse(Console.ReadLine(), out int numero);
            if (!numeroOk || numero <= 0)
            {
                Console.WriteLine("Número inválido.");
                return;
            }

            int resultado = 1;
            for (int i = numero;i >= 1; i--)
              { 
                resultado *= i;

            }
            Console.WriteLine($"El factorial de {numero} es: {resultado}");
        }
    }
}