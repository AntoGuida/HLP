using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLPEntidades
{
   public class Paciente
    {
        public int id_paciente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string domicilio { get; set; }
        public int? telefono{ get; set; }
        public int id_barrio { get; set; }
        public int id_sexo { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int id_tipo_doc { get; set; }
        public int num_doc { get; set; }
       
    }
}
