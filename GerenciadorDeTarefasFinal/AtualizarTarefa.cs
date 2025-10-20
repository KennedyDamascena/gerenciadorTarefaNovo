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
        public AtualizarTarefa()
        {
            InitializeComponent();
            dao = new DAOTarefa();
        }

        private void AtualizarTarefa_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBox1.Text);
            textBox7.Text = dao.ConsultarTitulo(codigo);
            textBox8.Text = dao.ConsultarDescricao(codigo);
            textBox9.Text = dao.ConsultarDatacriacao(codigo);
            textBox5.Text = dao.ConsultarDataFinal(codigo);
            textBox4.Text = dao.ConsultarPrioridade(codigo);
            textBox2.Text = dao.ConsultarSituacao(codigo);
            textBox3.Text = dao.consultarCodigousuario(codigo);

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

        }//Botao Salvar

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Botao Voltar
    }
}
