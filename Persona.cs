using System;

namespace ParqueAtraccion
{

    /// Estoy creando la clase Persona para representar a cada visitante del parque.
    /// Esta clase va a contener toda la información básica de una persona en la cola.
   
    public class Persona
    {
        // Estoy definiendo las propiedades públicas para que se puedan acceder desde otras clases
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime HoraLlegada { get; set; }
        public int Edad { get; set; }

 
        /// Constructor: Aquí estoy inicializando una nueva persona.
        /// Automáticamente le asigno la hora actual como hora de llegada.
   
        public Persona(int id, string nombre, int edad)
        {
            // Estoy asignando los valores que recibo como parámetros
            Id = id;
            Nombre = nombre;
            Edad = edad;
            
            // Estoy guardando el momento exacto en que la persona llega a la cola
            HoraLlegada = DateTime.Now;
        }

      
        /// Estoy sobrescribiendo el método ToString para mostrar la información 
        /// de manera legible cuando necesite imprimir los datos de la persona.
  
        public override string ToString()
        {
            // Estoy formateando la información de manera clara y organizada
            return $"ID: {Id}, Nombre: {Nombre}, Edad: {Edad}, Llegada: {HoraLlegada:HH:mm:ss}";
        }
    }
}