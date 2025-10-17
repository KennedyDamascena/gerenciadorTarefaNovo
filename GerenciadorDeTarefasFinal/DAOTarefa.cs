using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefasFinal
{
    internal class DAOTarefa
    {
        public MySqlConnection conexao;//Criando uma chave para a classe MYSQLCONNECTION
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] titulo;
        public string[] descricao;
        public DateTime[] dataCriacao;
        public DateTime[] dataFinal;
        public string[] prioridade;
        public string[] situacao;
        public int[] codigoUsuario;
        public int i;
        public int contador;
        public string msq;//variavel acumuladora unir os dados da consulta
        public int posicao;
        public DAOTarefa()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=gerenciador;Uid=root;Password=;Convert Zero DateTime=True");
            try
            {
                conexao.Open();//Tenta abrir a conexao com o Banco de Dados
                Console.WriteLine("Conectado Sucesso!");
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Algo deu errado!\n\n {erro}");
                conexao.Close();//Fechar a conexao
            }//fim do try_catch
        }//fim do construtor
        public void Inserir(string titulo,string descricao,DateTime dataCriacao,DateTime dataFinal,string prioridade, string situacao,int codigoUsuario)
        {
            try 
            {
                dados = $"('','{titulo}','{descricao}','{dataCriacao}','{dataFinal}','{prioridade}','{situacao}','{codigoUsuario})";
                comando = $"Insert into tarefa (codigo, titulo, descricao, dataCriacao, dataFinal, prioridade, situacao, codigoUsuario) values{dados}";
                //Lançar os dados no banco
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();// Comando de inserção/Ações
                Console.WriteLine($"Inserido com sucesso! {resultado}");//Visualização do resultado
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Algo deu Errado!\n\n {erro}");
            }//fim do catch
        }//fim do inserir
        //Metodo  para preeecher
        public void preencherVetor()
        {
            string query = "select * from tarefa";//comando para acessar o dado
            //instanciar os vetores
            codigo = new int[100];
            titulo = new string[100];
            descricao = new string[100];
            dataCriacao = new DateTime[100];
            dataFinal = new DateTime[100];
            prioridade = new string[100];
            situacao = new string[100];
            codigoUsuario= new int[100];


            //reafirmar que eu quero preencher com 0 e "" os vetores
            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                titulo[i] = "";
                descricao[i] = "";
                dataCriacao[i] = new DateTime();
                dataFinal[i] = new DateTime();
                prioridade[i] = "";
                situacao[i] = "";
                codigoUsuario[i] = 0;

            }//fim for

            //executar o comando no Banco de Dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Leitura dos Dados do banco por linha
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;
            //Buscar os Dados 
            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                titulo[i] = leitura["titulo"] + ""; ;
                descricao[i] = leitura["descricao"] + ""; ;
                dataCriacao[i] = Convert.ToDateTime(leitura ["dataCriacao"]);
                dataFinal[i] = Convert.ToDateTime(leitura["dataFinal"]);
                prioridade[i] = leitura["prioridade"] + ""; ;
                situacao[i] = leitura["situacao"] + ""; ;
                codigoUsuario[i] = Convert.ToInt32(leitura["codigoUsuario"]);

                i++;//ande o vetor
                contador++;//Contar exatamente quantos dados foram inseridos
            }//fim do while
             //Fechar a leitura dos dados com banco de dados
            leitura.Close();
        }//preencher

        public string ConsultarTudo()
        {
            //Preecher Vetor
            preencherVetor();
            msq = "";//Instanciar Variavel
            for (i = 0; i < contador; i++)
            {
                msq += $"\nCódigo:{codigo[i]} \ntitulo: {titulo[i]} \ndescricao: {descricao[i]} \ndataCriacao: {dataCriacao[i]} \ndataFinal {dataFinal[i]} \nprioridade {prioridade[i]} \nsituacao {situacao[i]} \ncodigoUsuario {codigoUsuario[i]}\n";
            }//Fim do for
            return msq;
            //Mostrar bd
        }//Fim

        public string ConsultarPorCodigo(int codigo)
        {
            preencherVetor();
            msq = "";
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    msq = $"\nCódigo:{this.codigo[i]} \ntitulo: {titulo[i]} \ndescricao: {descricao[i]} \ndataCriacao: {dataCriacao[i]} \ndataFinal {dataFinal[i]} \nprioridade {prioridade[i]} \nsituacao {situacao[i]} \ncodigoUsuario {codigoUsuario[i]}\n";
                    return msq;
                }//fim do if
            }//fim do for
            return "\n\nCódigo informado não foi encontrado!";
        }//fim do metodo

    }
}
