using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GerenciadorDeTarefasFinal
{
    public partial class ExcluirTarefa : Form
    {
        DAOTarefa dao;
        public ExcluirTarefa()
        {
            InitializeComponent();
            dao = new DAOTarefa();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }//voltar

        private void button2_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBox3.Text);
            MessageBox.Show(dao.Deletar(codigo));

        }//Salvar

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//Codigo
    }
}
