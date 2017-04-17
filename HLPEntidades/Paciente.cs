using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLPEntidades
{
    class Paciente
    {
        public int? id_paciente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string calle { get; set; }
        public int? nro { get; set; }
        public int id_barrio { get; set; }
        public int id_localidad { get; set; }
        public string telefono { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public bool id_sexo { get; set; }
        public int id_tipo_doc { get; set; }
        public int nro_doc { get; set; }
       
    }
}
