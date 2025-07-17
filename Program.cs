using System;

namespace ParqueAtraccion
{
    
    /// Estoy creando la clase Program que contiene el punto de entrada principal.
    /// Aquí voy a demostrar cómo funciona todo el sistema de cola de la atracción.
   
    class Program
    {
   
        /// Método Main: Aquí estoy orquestando toda la demostración del sistema.
        /// Voy a simular un día completo en la atracción del parque.
  
        static void Main(string[] args)
        {
            // Estoy mostrando el título y la información inicial
            Console.WriteLine("SISTEMA DE COLA PARA ATRACCIÓN DE PARQUE DE DIVERSIONES ");
            Console.WriteLine("Capacidad máxima: 30 asientos\n");

            // Estoy creando una nueva instancia de la atracción
            AtraccionParque atraccion = new AtraccionParque();

            // === SIMULACIÓN DE LLEGADA DE VISITANTES ===
            Console.WriteLine("=== LLEGADA DE VISITANTES ===");
            
            // Estoy agregando los primeros visitantes uno por uno
            Console.WriteLine("Estoy agregando los primeros visitantes...");
            atraccion.AgregarPersonaACola("Ana García", 25);
            atraccion.AgregarPersonaACola("Luis Martínez", 30);
            atraccion.AgregarPersonaACola("María López", 28);
            atraccion.AgregarPersonaACola("Carlos Rodríguez", 35);
            atraccion.AgregarPersonaACola("Elena Sánchez", 22);
            atraccion.AgregarPersonaACola("Pedro Fernández", 40);
            atraccion.AgregarPersonaACola("Sofía Jiménez", 27);
            atraccion.AgregarPersonaACola("Miguel Torres", 33);
            atraccion.AgregarPersonaACola("Carmen Ruiz", 29);
            atraccion.AgregarPersonaACola("Antonio Morales", 45);

            // Estoy agregando más visitantes para llenar completamente la atracción
            Console.WriteLine("\nEstoy agregando más visitantes para llenar la atracción...");
            for (int i = 11; i <= 35; i++)
            {
                // Estoy creando visitantes con nombres genéricos y edades variadas
                atraccion.AgregarPersonaACola($"Visitante{i}", 20 + (i % 30));
            }

            // === PROCESAMIENTO DE LA COLA ===
            Console.WriteLine("\nEstoy procesando la cola de espera...");
            atraccion.ProcesarCola();

            // Estoy mostrando el estado actual después del procesamiento
            Console.WriteLine("\nEstoy mostrando el estado actual de la atracción...");
            atraccion.MostrarEstadoAtraccion();

            // === SIMULACIÓN DE FINALIZACIÓN DEL CICLO ===
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("Estoy simulando que la atracción ha terminado su ciclo...");
            atraccion.TerminarCicloAtraccion();

            // === PROCESAMIENTO DEL SEGUNDO CICLO ===
            Console.WriteLine("Estoy procesando las personas que quedaron en cola para el segundo ciclo...");
            atraccion.ProcesarCola();

            // Estoy mostrando el estado final después del segundo ciclo
            Console.WriteLine("\nEstoy mostrando el estado final de la atracción...");
            atraccion.MostrarEstadoAtraccion();

            // === MOSTRAR HISTORIAL ===
            Console.WriteLine("\nEstoy mostrando el historial completo de visitantes...");
            atraccion.MostrarHistorialVisitantes();

            // === FINALIZACIÓN ===
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("¡Gracias por usar el sistema de cola de la atracción!");
            Console.WriteLine("Presiona cualquier tecla para salir...");
            
            // Estoy esperando que el usuario presione una tecla antes de cerrar
            Console.ReadKey();
        }
    }
}