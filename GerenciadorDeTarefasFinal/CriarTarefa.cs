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
    public partial class CriarTarefa : Form
    {
        public CriarTarefa()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }//Titulo

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }//Descrição

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }//Data de Criação

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//Data Final

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//Prioridade

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//Situação

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Coletar os DADOS
                string titulo = textBox7.Text;
                string descricao = textBox8.Text;
                DateTime dataCriacao = Convert.ToDateTime(textBox9.Text);
                DateTime dataFinal = Convert.ToDateTime(textBox1.Text);
                string prioridade = textBox4.Text;
                string situacao = textBox2.Text;
                int codigoUsuario = Convert.ToInt32(textBox3.Text);

                //Cadastrar no Banco
                DAOTarefa dao = new DAOTarefa();
                dao.Inserir(titulo, descricao, dataCriacao, dataFinal, prioridade, situacao, codigoUsuario);


                MessageBox.Show("Cadastrado com sucesso!!!");
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox1.Text = "";
                textBox4.Text = "";
                textBox2.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Algo deu Errado!!!\n\n{ex}");

            }
        }//Salvar

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Voltar

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//Codigo Usuario
    }
}
