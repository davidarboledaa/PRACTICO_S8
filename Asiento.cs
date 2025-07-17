namespace ParqueAtraccion
{
    
    /// Estoy creando la clase Asiento para representar cada uno de los 30 asientos
    /// de la atracción. Esta clase me ayudará a controlar qué asientos están ocupados
    /// y quién los está ocupando.

    public class Asiento
    {
        // Estoy definiendo las propiedades que necesito para controlar cada asiento
        public int Numero { get; set; }           // El número del asiento (1-30)
        public bool EstaOcupado { get; set; }     // Si está ocupado o no
        public Persona Ocupante { get; set; }     // Quién lo está ocupando

        /// Constructor: Estoy inicializando un nuevo asiento.
        /// Por defecto, todos los asientos empiezan vacíos.
     
        public Asiento(int numero)
        {
            // Estoy asignando el número del asiento
            Numero = numero;
            
            // Estoy inicializando el asiento como disponible
            EstaOcupado = false;
            
            // Estoy dejando el ocupante como null porque no hay nadie
            Ocupante = null;
        }

        
        /// Estoy creando este método para asignar una persona a este asiento.
        /// Solo permito la asignación si el asiento está disponible.
       
        public void AsignarPersona(Persona persona)
        {
            // Estoy verificando que el asiento esté disponible antes de asignar
            if (!EstaOcupado)
            {
                // Estoy asignando la persona al asiento
                Ocupante = persona;
                
                // Estoy marcando el asiento como ocupado
                EstaOcupado = true;
            }
        }

       
        /// Estoy creando este método para liberar el asiento cuando la atracción termine.
        /// Esto me permite reutilizar el asiento para el próximo ciclo.
   
        public void LiberarAsiento()
        {
            // Estoy quitando la referencia a la persona
            Ocupante = null;
            
            // Estoy marcando el asiento como disponible nuevamente
            EstaOcupado = false;
        }

        /// Estoy sobrescribiendo ToString para mostrar el estado del asiento
        /// de manera clara cuando necesite imprimir información.

        public override string ToString()
        {
            // Estoy verificando si el asiento está ocupado para mostrar información apropiada
            if (EstaOcupado)
            {
                // Estoy mostrando quién ocupa el asiento
                return $"Asiento {Numero}: {Ocupante.Nombre}";
            }
            else
            {
                // Estoy mostrando que el asiento está disponible
                return $"Asiento {Numero}: Disponible";
            }
        }
    }
}