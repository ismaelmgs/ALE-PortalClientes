using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalClientes.Views
{
    public partial class frmCalendario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SchedulerRecurenceInfo.Start = DateTime.Now;

        }

        protected void btnAlerta2_Click(object sender, EventArgs e)
        {
            MostrarMensaje("Mensaje de exito!", "Aviso");
        }

        public void MostrarMensaje(string sMensaje, string sCaption)
        {
            sMensaje = "alertexito('" + sMensaje + "');";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertexito", sMensaje, true);
        }

        public static List<Appointment> getAllAppoinments()
        {
            List<Appointment> ap = new List<Appointment>();

            Appointment a = new Appointment();
            a.ID = 1.ToString();
            a.StartTime = DateTime.Now;
            a.EndTime = DateTime.Now.AddHours(5);
            a.Description = "Ejemplo numero uno de calendario";
            a.Location = "Delicias Chihuahua";
            a.Subject = "Dua";
            a.Status = "1";
            a.AllDay = false;
            a.EventType = "";
            a.Label = "";
            ap.Add(a);

            return ap;
        }
    }
}