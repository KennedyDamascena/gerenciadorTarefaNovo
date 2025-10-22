using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GerenciadorDeTarefasFinal
{
    public partial class AtualizarUsuario : Form
    {
        DAOUsuario dao;
        public AtualizarUsuario(string nome, string email, string senha)
        {
            InitializeComponent();
            dao = new DAOUsuario();
            textBox1.Text = nome;
            textBox4.Text = email;
            textBox2.Text = senha;
        }

       
            
        private void button2_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            string email = textBox4.Text;
            string senha = textBox2.Text;
            
            //Atualizar
            dao.Atualizar(email, "nome", nome);
            dao.Atualizar(email, "email", email);
            dao.Atualizar(email, "senha", senha);
            
            //Mensagem:
            MessageBox.Show("Atualizado com sucesso!");
            textBox1.Text = "";
            textBox4.Text = "";
            textBox2.Text = "";
           

        }//Salvar

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Voltar

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//Nome

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//Email

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//Senha
    }
}