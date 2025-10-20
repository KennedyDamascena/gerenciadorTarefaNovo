using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GerenciadorDeTarefasFinal
{
    public partial class MenuUsuariocs : Form
    {
        Form1 form1;
        DAOTarefa daoTarefa;
        DAOUsuario daoUsuario;

        // Variável para guardar o código do usuário logado
        public int codigoUsuarioLogado;
        public MenuUsuariocs(string nome, string email, int codigo)
        {
            InitializeComponent();
            textBox1.Text = nome;
            textBox2.Text = email;
            form1 = new Form1(textBox1.Text);
            daoTarefa = new DAOTarefa();
            daoUsuario = new DAOUsuario();
            codigoUsuarioLogado = codigo;

            


            //Chamar TODOS OS MÉTODOS NA ORDEM
            ConfigurarGrid();//Estruturando o Grid
            NomeDados();//Nomear as colunas
            daoTarefa.preencherVetor();//Preencher os vetores e consultar o banco
            AdicionarDados();//Inserir os dados na tela, linha por linha
        }//fim do construtor

        public void AdicionarDados()
        {
            for (int i = 0; i < daoTarefa.QuantidadeDeDados(); i++)
            {

                if (daoTarefa.codigoUsuario[i] == codigoUsuarioLogado)
                {
                    dataGridView1.Rows.Add(
                    daoTarefa.codigo[i],
                    daoTarefa.titulo[i],
                    daoTarefa.descricao[i],
                    daoTarefa.dataCriacao[i],
                    daoTarefa.dataFinal[i],
                    daoTarefa.prioridade[i],
                    daoTarefa.situacao[i],
                    daoTarefa.codigoUsuario[i]);
                }
                
            }//fim do for
        }//fim do método

        public void ConfigurarGrid()
        {
            dataGridView1.AllowUserToAddRows = false;//Adicionar linhas
            dataGridView1.AllowUserToDeleteRows = false;//Apagar Linhas
            dataGridView1.AllowUserToResizeColumns = false;//Modificar Colunas
            dataGridView1.AllowUserToResizeRows = false;//Modificar Linhas
            dataGridView1.ColumnCount = 8;
        }//fim do configurarGrid

        public void NomeDados()
        {
            dataGridView1.Columns[0].Name = "Codigo";
            dataGridView1.Columns[1].Name = "titulo";
            dataGridView1.Columns[2].Name = "descricao";
            dataGridView1.Columns[3].Name = "dataCriacao";
            dataGridView1.Columns[4].Name = "dataFinal";
            dataGridView1.Columns[5].Name = "prioridade";
            dataGridView1.Columns[6].Name = "situacao";
            dataGridView1.Columns[7].Name = "codigoUsuario";
        }//fim do método



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
            CriarTarefa criarTarefa = new CriarTarefa();
            criarTarefa.ShowDialog();

        }//Nova Tarefa

        private void button1_Click_1(object sender, EventArgs e)
        {

        }//Excluir Tarefa

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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
            AtualizarTarefa atualizarTarefa = new AtualizarTarefa();
            atualizarTarefa.ShowDialog();

        }//Atualizar Tarefa

        private void MenuUsuariocs_Load(object sender, EventArgs e)
        {
            daoUsuario = new DAOUsuario();
            daoTarefa= new DAOTarefa();
            
        } 
    }
}
