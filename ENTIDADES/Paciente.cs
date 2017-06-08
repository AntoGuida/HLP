using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Paciente
    {
       

        public int id_paciente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string domicilio { get; set; }
       
        public int id_barrio { get; set; }
        
        public int telefono { get; set; }
      
        public DateTime fecha_nacimiento { get; set; }
        public int id_sexo { get; set; }
   
        public int id_tipo_doc { get; set; }
        public int num_documento { get; set; }
        public string email { get; set; }

        public string nro_obra_social { get; set; }

        public int id_obra_social { get; set; }

        public string nombre_obra_social { get; set; }


        public int? id_provincia { get; set; }

        public int? id_localidad { get; set; }




    }
}
