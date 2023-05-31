using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NucleoBase.Core;
using RestSharp;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Data;
using System.ComponentModel;
using System.IO;

namespace PortalClientes.Clases
{
    public static class Utils
    {
        public static string Idioma
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["Idioma"] == null)
                    System.Web.HttpContext.Current.Session["Idioma"] = "es-MX";

                //if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
                //{
                //    UserIdentity oUsuario = new UserIdentity();
                //    oUsuario.sIdioma = System.Web.HttpContext.Current.Session["Idioma"].S();
                //    System.Web.HttpContext.Current.Session["UserIdentity"] = oUsuario;
                //}
                //else
                //{
                //    UserIdentity oUsuario = (UserIdentity)System.Web.HttpContext.Current.Session["UserIdentity"];
                //    oUsuario.sIdioma = System.Web.HttpContext.Current.Session["Idioma"].S();
                //    System.Web.HttpContext.Current.Session["UserIdentity"] = oUsuario;
                //}

                return System.Web.HttpContext.Current.Session["Idioma"].S();
            }
            set
            {
                //if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
                //{
                //    UserIdentity oUsuario = new UserIdentity();
                //    oUsuario.sIdioma = "es-MX";
                //    System.Web.HttpContext.Current.Session["UserIdentity"] = oUsuario;
                //}

                System.Web.HttpContext.Current.Session["Idioma"] = value;
            }
        }

        public static string ResxPlaceholder
        {
            get
            {
                return Properties.Resources.Us_ApeMat;
            }
        }

        public static int GetIdEmpUsuario
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
                {
                    UserIdentity oUsuario = new UserIdentity();
                    oUsuario.iIdUsuario = 1;
                    System.Web.HttpContext.Current.Session["UserIdentity"] = oUsuario;
                }

                return ((UserIdentity)System.Web.HttpContext.Current.Session["UserIdentity"]).iIdUsuario;
            }
        }

        public static TokenWS ObtieneToken
        {
            get

            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                CredencialesWS oCred = new CredencialesWS();
                oCred.username = Globales.GetConfigApp<string>("UsrWs");
                oCred.password = Globales.GetConfigApp<string>("PassWs");

                var client = new RestClient(Helper.UrlToken);
                var request = new RestRequest(Method.POST);

                request.AddJsonBody(oCred);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                TokenWS oToken = ser.Deserialize<TokenWS>(resp);

                return oToken;
            }
        }

        public static string NombreUsuario
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
                {
                    UserIdentity oUsuario = new UserIdentity();
                    oUsuario.sNombre = "Ismael Morato";
                    System.Web.HttpContext.Current.Session["UserIdentity"] = oUsuario;
                }

                return ((UserIdentity)System.Web.HttpContext.Current.Session["UserIdentity"]).sNombre;
            }

        }

        public static string MatriculaActual
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
                {
                    UserIdentity oUsuario = new UserIdentity();
                    oUsuario.sMatricula = "";
                    System.Web.HttpContext.Current.Session["UserIdentity"] = oUsuario;
                }

                return ((UserIdentity)System.Web.HttpContext.Current.Session["UserIdentity"]).sMatricula;
            }
            set
            {
                UserIdentity oUser = (UserIdentity)System.Web.HttpContext.Current.Session["UserIdentity"];
                oUser.sMatricula = value;
                System.Web.HttpContext.Current.Session["UserIdentity"] = oUser;
            }
        }

        public static string ClaveContrato
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
                {
                    UserIdentity oClientes = new UserIdentity();
                    oClientes.Clientes = "";
                    System.Web.HttpContext.Current.Session["UserIdentity"] = oClientes;
                }

                return ((UserIdentity)System.Web.HttpContext.Current.Session["UserIdentity"]).Clientes;
            }
            set
            {
                UserIdentity oClientes = (UserIdentity)System.Web.HttpContext.Current.Session["UserIdentity"];
                oClientes.Clientes = value;
                System.Web.HttpContext.Current.Session["UserIdentity"] = oClientes;
            }
        }

        public static string NombreCliente
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
                {
                    UserIdentity oNombreCliente = new UserIdentity();
                    oNombreCliente.NombreCliente = "";
                    System.Web.HttpContext.Current.Session["UserIdentity"] = oNombreCliente;
                }

                return ((UserIdentity)System.Web.HttpContext.Current.Session["UserIdentity"]).NombreCliente;
            }
            set
            {
                UserIdentity oNombreCliente = (UserIdentity)System.Web.HttpContext.Current.Session["UserIdentity"];
                oNombreCliente.NombreCliente = value;
                System.Web.HttpContext.Current.Session["UserIdentity"] = oNombreCliente;
            }
        }

        public static List<string> Matriculas
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
                {
                    UserIdentity oUser= new UserIdentity();
                    oUser.lsMatriculas = null;
                    System.Web.HttpContext.Current.Session["UserIdentity"] = oUser;
                }

                return ((UserIdentity)System.Web.HttpContext.Current.Session["UserIdentity"]).lsMatriculas;
            }
            set
            {
                UserIdentity oUser = (UserIdentity)System.Web.HttpContext.Current.Session["UserIdentity"];
                oUser.lsMatriculas = value;
                System.Web.HttpContext.Current.Session["UserIdentity"] = oUser;
            }
        }


        public static DataTable ConvertListToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static void GuardarBitacora(string sMensaje)
        {
            try
            {
                string lsCarpeta = @"c:/Bitacoras/"; //Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\BitacorasApp\\";
                string lsArchivo = "Bitacora_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";

                //valida si ya existe la carpeta o no
                if (!Directory.Exists(lsCarpeta))
                    Directory.CreateDirectory(lsCarpeta);

                lsArchivo = lsCarpeta + lsArchivo;

                //valida si existe el archivo
                if (!File.Exists(lsArchivo))
                    File.CreateText(lsArchivo).Close();

                StreamWriter loSW = File.AppendText(lsArchivo);

                loSW.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " - " + sMensaje);

                loSW.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static Token ObtieneTokenPortalClientes
        {
            get

            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                Credenciales oCred = new Credenciales();
                oCred.UserName = Globales.GetConfigApp<string>("UsrWs");
                oCred.Password = Globales.GetConfigApp<string>("PassWs");

                var client = new RestClient(Helper.D_TokenPortal);
                var request = new RestRequest(Method.POST);

                request.AddJsonBody(oCred);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                Token oToken = ser.Deserialize<Token>(resp);

                return oToken;
            }
        }

    }
}