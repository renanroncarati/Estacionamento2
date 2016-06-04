using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estacionamento.Apresentacao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string placa = textBox1.Text;
            var client = new ServiceReference.EstacionamentoServiceClient();

            try
            {

                client.Checkin(placa);
                client.Close();

                MessageBox.Show(String.Format("Placa '{0}' adicionada.", placa));
                textBox1.Text = string.Empty;

            }
            catch (Exception ex)
            {
                client.Abort();
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string placa = textBox1.Text;
            var client = new ServiceReference.EstacionamentoServiceClient();

            try
            {
               double valor = client.CheckOut(placa);
                client.Close();

                MessageBox.Show(String.Format("Placa '{0}' valor de R${1}.", placa, valor));
                textBox1.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var client = new ServiceReference.EstacionamentoServiceClient();
            try
            {
                int vagasR = client.VagasRestantes();
                MessageBox.Show(String.Format("Existem {0} vagas.",vagasR));
                textBox1.Text = string.Empty;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}