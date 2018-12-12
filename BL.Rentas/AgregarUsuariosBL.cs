using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    class AgregarUsuariosBL
    {
        contexto _contexto;
        public BindingList<AgregarUsuariosBL> ListaUsuarios { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
    }
}
