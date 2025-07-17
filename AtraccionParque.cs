using System;
using System.Collections.Generic;

namespace ParqueAtraccion
{

    /// Estoy creando la clase principal que maneja toda la lógica de la atracción.
    
       public class AtraccionParque
    {
        // Estoy declarando las estructuras de datos que voy a necesitar
        private Queue<Persona> colaEspera;           // Cola FIFO para orden de llegada
        private Stack<Persona> historialVisitantes;  // Pila LIFO para historial
        private Asiento[] asientos;                  // Array de 30 asientos
        private const int CAPACIDAD_MAXIMA = 30;     // Capacidad máxima de la atracción
        private int siguienteId;                     // Para asignar IDs únicos

   
        /// Constructor: Estoy inicializando todas las estructuras de datos
        /// y preparando la atracción para recibir visitantes.
      
        public AtraccionParque()
        {
            // Estoy inicializando la cola de espera vacía
            colaEspera = new Queue<Persona>();
            
            // Estoy inicializando la pila de historial vacía
            historialVisitantes = new Stack<Persona>();
            
            // Estoy creando el array de 30 asientos
            asientos = new Asiento[CAPACIDAD_MAXIMA];
            
            // Estoy inicializando el contador de IDs en 1
            siguienteId = 1;

            // Estoy inicializando cada asiento individual
            for (int i = 0; i < CAPACIDAD_MAXIMA; i++)
            {
                // Estoy creando cada asiento con su número correspondiente (1-30)
                asientos[i] = new Asiento(i + 1);
            }
        }

    
        /// Estoy creando este método para agregar una persona a la cola de espera.
        /// Primero verifico si hay espacio disponible.

        public void AgregarPersonaACola(string nombre, int edad)
        {
            // Estoy verificando si todavía hay asientos disponibles
            if (HayAsientosDisponibles())
            {
                // Estoy creando una nueva persona con un ID único
                Persona nuevaPersona = new Persona(siguienteId++, nombre, edad);
                
                // Estoy agregando la persona al final de la cola
                colaEspera.Enqueue(nuevaPersona);
                
                // Estoy informando que la persona se unió exitosamente
                Console.WriteLine($" {nombre} se ha unido a la cola. Posición: {colaEspera.Count}");
            }
            else
            {
                // Estoy informando que no hay espacio disponible
                Console.WriteLine($" Lo sentimos, la atracción está llena. {nombre} no puede unirse.");
            }
        }

        /// Estoy creando este método para procesar la cola y asignar asientos.
        /// Este es el proceso principal donde las personas suben a la atracción.
     
        public void ProcesarCola()
        {
            Console.WriteLine("\n=== PROCESANDO COLA DE ESPERA ===");
            
            // Estoy procesando la cola mientras haya personas y asientos disponibles
            while (colaEspera.Count > 0 && HayAsientosDisponibles())
            {
                // Estoy sacando a la primera persona de la cola (FIFO)
                Persona persona = colaEspera.Dequeue();
                
                // Estoy buscando el primer asiento disponible
                int asientoLibre = EncontrarPrimerAsientoLibre();
                
                // Estoy verificando que encontré un asiento libre
                if (asientoLibre != -1)
                {
                    // Estoy asignando la persona al asiento
                    asientos[asientoLibre].AsignarPersona(persona);
                    
                    // Estoy agregando la persona al historial (LIFO)
                    historialVisitantes.Push(persona);
                    
                    // Estoy confirmando la asignación
                    Console.WriteLine($" {persona.Nombre} ha sido asignado al asiento {asientoLibre + 1}");
                }
            }

            // Estoy informando si quedan personas en la cola
            if (colaEspera.Count > 0)
            {
                Console.WriteLine($"\n Quedan {colaEspera.Count} personas en la cola esperando el próximo ciclo.");
            }
        }

  
        /// Estoy creando este método para simular que la atracción termina
        /// y libero todos los asientos para el próximo ciclo.
  
        public void TerminarCicloAtraccion()
        {
            Console.WriteLine("\n=== LA ATRACCIÓN HA TERMINADO ===");
            Console.WriteLine("Liberando asientos...");
            
            // Estoy recorriendo todos los asientos para liberarlos
            for (int i = 0; i < CAPACIDAD_MAXIMA; i++)
            {
                // Estoy verificando si el asiento está ocupado
                if (asientos[i].EstaOcupado)
                {
                    // Estoy informando que la persona terminó su viaje
                    Console.WriteLine($" {asientos[i].Ocupante.Nombre} ha terminado su viaje");
                    
                    // Estoy liberando el asiento
                    asientos[i].LiberarAsiento();
                }
            }
            
            Console.WriteLine("Todos los asientos han sido liberados para el próximo ciclo.\n");
        }

        /// <summary>
        /// Estoy creando este método para mostrar el estado actual de la atracción.
        /// Esto me permite ver qué está pasando en tiempo real.
        /// </summary>
        public void MostrarEstadoAtraccion()
        {
            Console.WriteLine("\n=== ESTADO DE LA ATRACCIÓN ===");
            
            // Estoy mostrando estadísticas generales
            Console.WriteLine($"Asientos ocupados: {ContarAsientosOcupados()}/{CAPACIDAD_MAXIMA}");
            Console.WriteLine($"Personas en cola: {colaEspera.Count}");
            Console.WriteLine($"Total de visitantes atendidos: {historialVisitantes.Count}");
            
            // Estoy mostrando los asientos ocupados
            Console.WriteLine("\nAsientos:");
            for (int i = 0; i < CAPACIDAD_MAXIMA; i++)
            {
                if (asientos[i].EstaOcupado)
                {
                    Console.WriteLine($"  {asientos[i]}");
                }
            }
            
            // Estoy mostrando las personas en cola si las hay
            if (colaEspera.Count > 0)
            {
                Console.WriteLine("\nPersonas en cola:");
                int posicion = 1;
                
                // Estoy recorriendo la cola para mostrar cada persona
                foreach (Persona persona in colaEspera)
                {
                    Console.WriteLine($"  {posicion}. {persona}");
                    posicion++;
                }
            }
        }


        /// Estoy creando este método para mostrar el historial de visitantes.
        /// Uso una pila temporal para no modificar el historial original.
  
        public void MostrarHistorialVisitantes()
        {
            Console.WriteLine("\n=== HISTORIAL DE VISITANTES (último en entrar primero) ===");
            
            // Estoy verificando si hay visitantes en el historial
            if (historialVisitantes.Count == 0)
            {
                Console.WriteLine("No hay visitantes en el historial.");
                return;
            }

            // Estoy creando una pila temporal para no modificar la original
            Stack<Persona> tempStack = new Stack<Persona>();
            
            // Estoy mostrando el historial sin modificar la pila original
            while (historialVisitantes.Count > 0)
            {
                Persona persona = historialVisitantes.Pop();
                Console.WriteLine($"  {persona}");
                tempStack.Push(persona);
            }
            
            // Estoy restaurando la pila original
            while (tempStack.Count > 0)
            {
                historialVisitantes.Push(tempStack.Pop());
            }
        }

        // === MÉTODOS AUXILIARES PRIVADOS ===
        
        /// <summary>
        /// Estoy creando este método privado para verificar si hay asientos disponibles.
        /// </summary>
        private bool HayAsientosDisponibles()
        {
            return ContarAsientosOcupados() < CAPACIDAD_MAXIMA;
        }

        /// <summary>
        /// Estoy creando este método privado para contar cuántos asientos están ocupados.
        /// </summary>
        private int ContarAsientosOcupados()
        {
            int ocupados = 0;
            
            // Estoy recorriendo todos los asientos para contarlos
            for (int i = 0; i < CAPACIDAD_MAXIMA; i++)
            {
                if (asientos[i].EstaOcupado)
                    ocupados++;
            }
            
            return ocupados;
        }

        /// <summary>
        /// Estoy creando este método privado para encontrar el primer asiento libre.
        /// </summary>
        private int EncontrarPrimerAsientoLibre()
        {
            // Estoy buscando el primer asiento disponible
            for (int i = 0; i < CAPACIDAD_MAXIMA; i++)
            {
                if (!asientos[i].EstaOcupado)
                    return i;
            }
            
            // Estoy retornando -1 si no hay asientos libres
            return -1;
        }
    }
}