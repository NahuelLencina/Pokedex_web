using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Elemento
    {
        public int id { get; set; }
        public  string Descripcion { get; set; }

        // Sobreescribimos el Metodo ToString y Retornamos la descripción
        public override string ToString()
        {
            return Descripcion;
        }

    }
}
