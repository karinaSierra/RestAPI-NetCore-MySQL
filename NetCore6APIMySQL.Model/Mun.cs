
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore6APIMySQL.Model
{
    public class Municipio
    {
        public int IdMunicipio { get; set; }
        public string Nombre { get; set; }
        public int Departamento_Id { get; set; }

    }
}
