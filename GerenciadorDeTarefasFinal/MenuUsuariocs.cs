using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorDeTarefasFinal
{
    public partial class MenuUsuariocs : Form
    {
        Form1 form1;
        DAOUsuario dao;
        public MenuUsuariocs()
        {
            InitializeComponent();
          
            form1 = new Form1(textBox1.Text);            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }//Caixa de Consulta

        private void button2_Click(object sender, EventArgs e)
        {

        }//Nova Tarefa

        private void button1_Click_1(object sender, EventArgs e)
        {

        }//Excluir Tarefa

        private void button3_Click(object sender, EventArgs e)
        {

        }//Voltar

        public void PreencherCampos()
        {
            
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }//Nome do Usuario

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }//Email do Usuario

        private void button5_Click(object sender, EventArgs e)
        {

        }//Atualizar Informação do Usuario

        private void button4_Click(object sender, EventArgs e)
        {

        }//Atualizar Tarefa

        private void MenuUsuariocs_Load(object sender, EventArgs e)
        {
            dao = new DAOUsuario();
            textBox1.Text = form1.RetornarNome();
            textBox2.Text = form1.RetornarEmail();
        } 
    }
}
