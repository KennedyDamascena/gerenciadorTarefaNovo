using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
    
namespace GerenciadorDeTarefasFinal
{
    internal class DAOUsuario
    {
        public MySqlConnection conexao;//Criando uma chave para a classe MYSQLCONNECTION
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] nome;
        public string[] email;
        public string[] senha;
        public int quantidadeUsuarios;
        public int i;
        public int contador;
        public string msq;//variavel acumuladora unir os dados da consulta
        public int posicao;
        public DAOUsuario()
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
        public void Inserir(string nome, string email,string senha)
        {
            try
            {
                dados = $"('','{nome}','{email}','{senha}')";
                comando = $"Insert into usuario (codigo, nome, email, senha) values{dados}";
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
            string query = "select * from usuario";//comando para acessar o dado
            //instanciar os vetores
            codigo = new int[100];
            nome = new string[100];
            email = new string[100];
            senha = new string[100];


            //reafirmar que eu quero preencher com 0 e "" os vetores
            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                nome[i] = "";
                email[i] = "";
                senha[i] = "";


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
                nome[i] = leitura["nome"] + "";
                email[i] = leitura["email"] + "";
                senha[i] = leitura["senha"] + "";

                i++;//ande o vetor
                contador++;//Contar exatamente quantos dados foram inseridos
            }//fim do while
            quantidadeUsuarios = contador;
             //Fechar a leitura dos dados com banco de dados
            leitura.Close();
        }//preencher
            public int BuscarCodigoPorEmail(string emailBusca)
        {
            for (int i = 0; i < quantidadeUsuarios; i++)
            {
                if (email[i] == emailBusca)
                    return codigo[i];
            }
            return -1; 
        }


        public string ConsultarTudo()
        {
            //Preecher Vetor
            preencherVetor();
            msq = "";//Instanciar Variavel
            for (i = 0; i < contador; i++)
            {
                msq += $"\nCódigo:{codigo[i]} \nnome: {nome[i]} \nemail: {email[i]} \nsenha: {senha[i]} \n";
            }//Fim do for
            return msq;
            //Mostrar bd
        }//Fim

        public string ConsultarNome(string nome)
        {
            preencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.nome[i] == nome)
                {
                    this.posicao = i;
                    return "Correto";
                }//fim do if                
            }//fim do metodo
            return "Nome não existe!";
        }//fim do metodo

        public int MostrarCodigo(string nome)
        {
            preencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.nome[i] == nome)
                {
                    return codigo[i];
                }//fim do if                
            }//fim do metodo
            return -1;
        }//fim do metodo



        public string ConsultarSenha(string senha)
        {
            preencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.senha[i] == senha)
                {
                    this.posicao = i;
                    return "Correto";
                }//fim do if                
            }//fim do metodo
            return "senha não existe!";
        }//fim do metodo

        public int InformarPosicao()
        {
            return this.codigo[this.posicao];
        }

        public string MostrarNome(int codigo)
        {
            preencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    
                    return nome[i];
                }//fim do if
            }//fim do for
            return "\n\nCódigo informado não foi encontrado!";
        }//fim do metodo

        public string MostrarEmail(int codigo)
        {
            preencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {

                    return email[i];
                }//fim do if
            }//fim do for
            return "\n\nCódigo informado não foi encontrado!";
        }//fim do metodo
        public string ConsultarPorCodigo(int codigo)
        {
            preencherVetor();
            msq = "";
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    msq = $"\nCódigo:{this.codigo[i]} \nnome: {nome[i]} \nemail: {email[i]} \nsenha: {senha[i]} \n";
                    return msq;
                }//fim do if
            }//fim do for
            return "\n\nCódigo informado não foi encontrado!";
        }//fim do metodo

        public int ConsultarPorCodigo(string nome)
        {
            preencherVetor();
            msq = "";
            for (i = 0; i < contador; i++)
            {
                if (this.nome[i] == nome)
                {
                    return codigo[i];
                }//fim do if
            }//fim do for
            return -1;
        }//fim do metodo

        public string Atualizar(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = $"update usuario set {campo} = '{novoDado}' where codigo = '{codigo}'";
                //executar o comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "dado altualizado com sucesso!";

            }
            catch (Exception erro)
            {
                return $"\nAlgo Deu errado!\n\n{erro}";
            }
        }//Fim do Metodo

        public string Atualizar(int codigo, string campo, int novoDado)
        {
            try
            {
                string query = $"update usuario set {campo} = '{novoDado}' where codigo = '{codigo}'";
                //executar o comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "dado altualizado com sucesso!";

            }
            catch (Exception erro)
            {
                return $"\nAlgo Deu errado!\n\n{erro}";
            }
        }//Fim do Metodo

        public string deletar(int codigo)
        {
            try
            {
                string query = $"delete from usuario where codigo = '{codigo}' ";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado excluido";
            }
            catch (Exception erro)
            {
                return $"algo deu errado\n\n {erro}";
            }
        }
    }//Fim da Classe
}//Fim do Projeto
