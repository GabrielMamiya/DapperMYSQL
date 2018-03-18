using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using Dapper;


namespace MYSQL_DAPPER2
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            {
                //Aqui você substitui pelos seus dados
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "Data Source=localhost; Initial Catalog = gabriel;User ID = root; Password = gabriel00";

                conn.Open();
                //command.CommandText = "INSERT INTO TABELA1 (CAMPO1) VALUES ('VALOR1')";
                Console.WriteLine("Abri a conexao!");
                //command.ExecuteNonQuery();
                //Pessoas newCLient = new Pessoas("Luna", "Mota");

                //INSERT SEM DAPPER
                //string firstName = newCLient.Nome;
                //string lastName = newCLient.SobreNome;

                //string query = @"insert into pessoas (nome, sobrenome) values ('" + firstName + "', '" + lastName + "')";

                //MySqlCommand cmd = new MySqlCommand(query, conn);

                //cmd.ExecuteNonQuery();

                Pessoas newPessoa = new Pessoas();

                newPessoa.Nome = "Mitsuaki";
                newPessoa.SobreNome = "Mamiya";

                conn.Execute("insert into pessoas (nome, sobrenome) values (@nome, @sobrenome)", newPessoa);
                List<Pessoas> listaDePessoas = conn.Query<Pessoas>("select * from pessoas").ToList();


                foreach (var item in listaDePessoas)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Nome);
                    Console.WriteLine(item.SobreNome);
                }

                Console.ReadKey();

            }
        }
    }
}
