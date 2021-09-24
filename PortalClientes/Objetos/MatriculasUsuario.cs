using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class MatriculasUsuario
    {
        public int IdAeronave { set; get; }
        public string Serie { set; get; }
        public string Matricula { set; get; }
        public string GrupoModelo { set; get; }

        private int _sts = 0;
        public int sts { set { _sts = value; } get { return _sts; } }
    }
}