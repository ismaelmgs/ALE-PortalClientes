using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NucleoBase.Core;

namespace PortalClientes.Presenter
{
    public class Usuarios_Presenter :BasePresenter<IViewUsuarios>
    {
        private readonly DBUsuarios oIGesCat;

        public Usuarios_Presenter(IViewUsuarios oView, DBUsuarios oGC) : base(oView)
        {
            oIGesCat = oGC;

            oIView.eSearchObjFiltros += eSearchObjFiltros_Presenter;
            oIView.eSearchMatriculas += eSearchMatriculas_Presenter;
            oIView.eSaveMatriculasUsuario += eSaveMatriculasUsuario_Presenter;

            oIView.eSearchModulos += eSearchModulos_Presenter;
            oIView.eSaveModulos += eSaveModulos_Presenter;
            oIView.eSaveClonaPermisos += eSaveClonaPermisos_Presenter;
        }

        protected override void SearchObj_Presenter(object sender, EventArgs e)
        {
           oIView.CargaUsuarios(oIGesCat.ObtieneUsuariosFiltros(string.Empty));
        }

        protected override void SaveObj_Presenter(object sender, EventArgs e)
        {
            oIGesCat.InsertaActualizaUsuarios(oIView.oUsuario);
            oIView.CargaUsuarios(oIGesCat.ObtieneUsuariosFiltros(oIView.sFiltro));
        }

        protected void eSearchObjFiltros_Presenter(object sender, EventArgs e)
        {
            oIView.CargaUsuarios(oIGesCat.ObtieneUsuariosFiltros(oIView.sFiltro));
        }

        // MATRICULAS
        protected void eSearchMatriculas_Presenter(object sender, EventArgs e)
        {
            List<MatriculasUsuario> olstMats = new List<MatriculasUsuario>();
            List<Matriculas> olstMU = oIGesCat.DBGetObtieneMatricuasPorUsuario(oIView.iIdUsuario);
            List<Matriculas> olst = oIGesCat.ObtieneMatriculas();

            foreach (Matriculas item in olst)
            {
                MatriculasUsuario oMatU = new MatriculasUsuario();
                oMatU.IdAeronave = item.IdAeronave;
                oMatU.Serie = item.Serie;
                oMatU.Matricula = item.Matricula;
                oMatU.GrupoModelo = item.GrupoModelo;

                foreach (Matriculas itemU in olstMU)
                {
                    if (item.IdAeronave == itemU.IdAeronave)
                        oMatU.sts = 1;
                }

                olstMats.Add(oMatU);
            }

            oIView.CargaMatriculas(olstMats);
        }
        
        protected void eSaveMatriculasUsuario_Presenter(object sender, EventArgs e)
        {
            responseCodigoMensaje respuesta = oIGesCat.DesvinculaUsuariosMatriculas(oIView.iIdUsuario);
            if (respuesta.codigo == "0000")
            {
                requestIdUsuario ReqUsuario = oIGesCat.RelacionaUsuarioMatriculas(oIView.iIdUsuario, oIView.olst);
            }
        }

        // MODULOS
        protected void eSearchModulos_Presenter(object sender, EventArgs e)
        {
            oIView.CargaModulos(oIGesCat.ObtieneModulosPorUsuario(oIView.iIdUsuario));
        }

        protected void eSaveModulos_Presenter(object sender, EventArgs e)
        {
            List<int> olst = oIView.olst;
            string sModulos = string.Empty;
            foreach (int idMod in olst)
            {
                if (sModulos == string.Empty)
                    sModulos = idMod.S();
                else
                    sModulos += "," + idMod.S();
            }

            oIGesCat.RelacionaModulosUsuario(oIView.iIdUsuario, sModulos);
        }

        protected void eSaveClonaPermisos_Presenter(object sender, EventArgs e)
        {
            List<ModulosUsuario> olstModUser = oIGesCat.ClonaPermisosDeUsuarioUsuario(oIView.iIdUsuarioOrigen, oIView.iIdUsuario);
        }

        protected override void ObjSelected_Presenter(object sender, EventArgs e)
        {
            oIView.CargaModulosUsuario(oIGesCat.ObtieneModulosPorUsuario(oIView.iIdUsuarioOrigen));
        }
    }
}