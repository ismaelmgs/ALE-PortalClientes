using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalClientes.Interfaces
{
    public interface IViewUsuarios : IBaseView
    {
        Usuario oUsuario { get; }
        string sFiltro { get; }
        int iIdUsuario { set; get; }
        List<int> olst { set; get; }
        int iIdUsuarioDestino { set; get; }


        void CargaUsuarios(List<Usuario> oLstUsers);
        void CargaMatriculas(List<Matriculas> olstMats);
        void CargaModulos(List<ModulosUsuario> olstMods);

        event EventHandler eSearchObjFiltros;
        event EventHandler eSearchMatriculas;
        event EventHandler eSearchModulos;
        event EventHandler eSaveClonaPermisos;
        event EventHandler eSaveMatriculasUsuario;
        event EventHandler eSaveModulos;
    }
}
