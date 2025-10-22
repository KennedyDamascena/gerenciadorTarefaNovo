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
    public partial class AtualizarTarefa : Form
    {
        DAOTarefa dao;
        MenuUsuariocs menuUsuariocs;

        public AtualizarTarefa()
        {
            InitializeComponent();
            dao = new DAOTarefa();
            menuUsuariocs = new MenuUsuariocs();
        }

        private void AtualizarTarefa_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBox1.Text);
            textBox7.Text = dao.ConsultarTitulo(codigo);
            textBox8.Text = dao.ConsultarDescricao(codigo);
            textBox9.Text = dao.ConsultarDataCriacao(codigo);
            textBox5.Text = dao.ConsultarDataFinal(codigo);
            textBox4.Text = dao.ConsultarPrioridade(codigo);
            textBox2.Text = dao.ConsultarSituacao(codigo);
            textBox3.Text = dao.ConsultarCodigoUsuario(codigo);

        }//Botão Buscar

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//codigo

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }//titulo

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }//Descricao

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }//Data de Criacao

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }//Data final

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//Prioridade

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//situacao

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//codigo Usuario

        private void button3_Click(object sender, EventArgs e)
        {
            //Pegar os dados
            string titulo = textBox7.Text;
            string descricao = textBox8.Text;
            DateTime dataCriacao = Convert.ToDateTime(textBox9.Text);
            DateTime dataFinal = Convert.ToDateTime(textBox5.Text);
            string prioridade = textBox4.Text;
            string situacao = textBox2.Text;
            int codigoUsuario = Convert.ToInt32(textBox3.Text);
            //Atualizar
            int codigo = Convert.ToInt32(textBox1.Text);
            dao.Atualizar(codigo, "titulo", titulo);
            dao.Atualizar(codigo, "descricao", descricao);
            dao.Atualizar(codigo, "dataCriacao", dataCriacao);
            dao.Atualizar(codigo, "dataFinal", dataFinal);
            dao.Atualizar(codigo, "prioridade", prioridade);
            dao.Atualizar(codigo, "situacao", situacao);
            dao.Atualizar(codigo, "codigoUsuario", codigoUsuario);

            //Mensagem:
            MessageBox.Show("Atualizado com sucesso!");
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            menuUsuariocs.ShowDialog();

        }//Botao Salvar

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Botao Voltar

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
