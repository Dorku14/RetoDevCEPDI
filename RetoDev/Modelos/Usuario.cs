using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetoDev.Modelos
{
     class Usuario
    {
        public int      idusuario { set; get; }
        public string   nombre { set; get; }
        public DateTime fechacreacion { set; get; }
        public string   usuario { set; get; }
        public string   password { set; get; }
        public string   idperfil { set; get; }
        public int      estatus { set; get; }
    }
}
