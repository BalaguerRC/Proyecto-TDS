using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace ProyectoFinal
{
    public partial class FormCorreo : Form
    {
        public FormCorreo()
        {
            InitializeComponent();
        }

        private void enviarEmail(string para, string asunto, string mensaje)
        {
            try
            {

                MailMessage msg = new MailMessage();
                SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
                msg.From = new MailAddress("lectorexample@gmail.com", "Lector Programa");
                msg.To.Add(para);
                msg.Subject =asunto;
                msg.Body = mensaje;  //txtMensaje.TexT
                msg.IsBodyHtml = false;

                //msg.SubjectEncoding = Encoding.UTF8;
                //msg.BodyEncoding = Encoding.UTF8;
                cliente.Credentials = new NetworkCredential("lectorexample@gmail.com", "mmxymtcgptgnxlpt");
                cliente.EnableSsl = true;
                cliente.Send(msg);
                MessageBox.Show("Enviado", "Aviso Email");

            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error", "Aviso Email");
            }
        }

        private void btnEnvio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPara.Text))
            {
                MessageBox.Show("Escriba el destinatario", "Aviso Email");
            }
            else if (string.IsNullOrEmpty(txtAsunto.Text))
            {
                MessageBox.Show("Escriba el asunto", "Aviso Email");
            }
            else if (string.IsNullOrEmpty(txtMensaje.Text))
            {
                MessageBox.Show("Escriba el mensaje", "Aviso Email");
            }
            else
            {
                enviarEmail(txtPara.Text, txtAsunto.Text, txtMensaje.Text);
            }
            //enviarEmail();
        }
    }
}
