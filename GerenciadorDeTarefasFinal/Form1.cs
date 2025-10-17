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
    
    public partial class Form1 : Form
    {
        MenuUsuariocs menuUsuariocs;
        public string dadoNome;
        public string dadoEmail;

        public Form1(string teste)
        {
            string novo = teste;
        }
        public Form1()
        {
            InitializeComponent();
            menuUsuariocs = new MenuUsuariocs();
            dadoNome = "";
            dadoEmail = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Coletar os DADOS
                string nome = textBox1.Text;
                string senha = textBox4.Text;

                //Cadastrar no Banco
                DAOUsuario dao = new DAOUsuario();
                if (dao.ConsultarNome(nome) == "Correto" && dao.ConsultarSenha(senha) == "Correto")
                {
                    MessageBox.Show("Dados Corretos");
                    
                    dadoNome = dao.MostrarNome(dao.InformarPosicao());
                    dadoEmail = dao.MostrarEmail(dao.InformarPosicao());
                    MessageBox.Show(dadoNome + "\n" + dadoEmail + "");

                    menuUsuariocs.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Informe um usuário ou senha já cadastrados!!!");
                    textBox1.Text = "";
                    textBox4.Text = "";
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Algo deu Errado!!!\n\n{ex}");

            }

        }//Entrar

        public string RetornarNome()
        {
            return dadoNome;
        }

        public string RetornarEmail()
        {
            return dadoEmail;
        }
        private void label4_Click(object sender, EventArgs e)
        {
            CadastroUsuario cadastroUsuario = new CadastroUsuario();
            cadastroUsuario.ShowDialog();

        }//Criar Conta

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//caixa texto nome

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//Caixa texto senha
    }
}
