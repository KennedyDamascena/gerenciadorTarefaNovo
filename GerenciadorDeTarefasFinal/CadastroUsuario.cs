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
    public partial class CadastroUsuario : Form
    {
        public CadastroUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Coletar os DADOS
                string nome = textBox1.Text;
                string email = textBox4.Text;
                string senha = textBox2.Text;

                //Cadastrar no Banco
                DAOUsuario dao = new DAOUsuario();
                dao.Inserir(nome, email, senha);
                    

                MessageBox.Show("Cadastrado com sucesso!!!");
                textBox1.Text = "";
                textBox4.Text = "";
                textBox2.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Algo deu Errado!!!\n\n{ex}");

            }

        }//Botao Salvar

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//Nome

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//E-mail

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//Senha

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }//Voltar

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
