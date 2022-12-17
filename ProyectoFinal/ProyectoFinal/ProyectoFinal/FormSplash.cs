using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class FormSplash : Form
    {
        public FormSplash()
        {
            InitializeComponent();
        }

        private void FormSplash_Load(object sender, EventArgs e)
        {
            Thread threadSplashCharge = new Thread(loadThreadProgress);
            threadSplashCharge.Start();
        }
        public void loadThreadProgress()
        {
            Thread.Sleep(1000);

            this.Invoke((MethodInvoker)delegate
            {
                this.Close();
            });
        }
    }
}
