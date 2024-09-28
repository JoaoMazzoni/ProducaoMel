using Microsoft.Data.SqlClient;
using Models;
using ProducaoMel.DALL;

namespace ProducaoMel.Repositories
{
    public class FloresRepository
    {

        private DALProducaoMel _dalProducaoMel;

        public FloresRepository()
        {
            _dalProducaoMel = new DALProducaoMel();
        }

        public void AddFlores(Flores flores)
        {
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Flores(Nome, Tipo, Periodo_floracao, Origem, Atracao_abelhas) VALUES (@Nome, @Tipo, @Periodo_floracao, @Origem, @Atracao_abelhas)";
                    cmd.Parameters.AddWithValue("@Nome", flores.Nome);
                    cmd.Parameters.AddWithValue("@Tipo", flores.Tipo);
                    cmd.Parameters.AddWithValue("@Periodo_floracao", flores.PeriodoFloracao);
                    cmd.Parameters.AddWithValue("@Origem", flores.Origem);
                    cmd.Parameters.AddWithValue("@Atracao_abelhas", flores.AtracaoAbelhas);
                    var linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas == 0)
                    {
                        Console.WriteLine("Erro ao inserir registro!");
                    }
                    else
                    {
                        Console.WriteLine("Registro de Flores inserido com sucesso!");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro SQL ao realizar consulta SQL. Detalhes: " + ex);
                throw;
            }


        }

        public void UpdateFlores(Flores flores)
        {
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "UPDATE Flores SET Nome = @Nome, Tipo = @Tipo, Periodo_floracao = @Periodo_floracao, Origem = @Origem, Atracao_abelhas = @Atracao_abelhas WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", flores.ID);
                    cmd.Parameters.AddWithValue("@Nome", flores.Nome);
                    cmd.Parameters.AddWithValue("@Tipo", flores.Tipo);
                    cmd.Parameters.AddWithValue("@Periodo_floracao", flores.PeriodoFloracao);
                    cmd.Parameters.AddWithValue("@Origem", flores.Origem);
                    cmd.Parameters.AddWithValue("@Atracao_abelhas", flores.AtracaoAbelhas);
                    var linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas == 0)
                    {
                        Console.WriteLine("Erro ao atualizar registro!");
                    }
                    else
                    {
                        Console.WriteLine("Registro de Flores atualizado com sucesso!");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro SQL ao realizar consulta SQL. Detalhes: " + ex);
                throw;
            }
        }

        public void DeleteFlores(int id)
        {
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Flores WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    var linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas == 0)
                    {
                        Console.WriteLine("Erro ao deletar registro! Nenhuma flor foi deletada.");
                        Console.Write("\nPressione qualquer tecla para continuar: ");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Registro de Flores deletado com sucesso!");
                        Console.Write("\nPressione qualquer tecla para continuar: ");
                        Console.ReadLine();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro SQL ao realizar consulta SQL. Detalhes: " + ex);
                throw;
            }
        }

        public List<Flores> GetAllFlores()
        {
            List<Flores> flores = new List<Flores>();
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Flores";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Flores flores1 = new Flores();
                            flores1.ID = Convert.ToInt32(reader["ID"]);
                            flores1.Nome = reader["Nome"].ToString();
                            flores1.Tipo = reader["Tipo"].ToString();
                            flores1.PeriodoFloracao = reader["Periodo_floracao"].ToString();
                            flores1.Origem = reader["Origem"].ToString();
                            flores1.AtracaoAbelhas = Convert.ToBoolean(reader["Atracao_abelhas"]);
                            flores.Add(flores1);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro SQL ao realizar consulta SQL. Detalhes: " + ex);
                throw;
            }

            return flores;
          
        }

        public Flores GetFloresById(int id)
        {
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Flores WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    var dataReader = cmd.ExecuteReader();
                    Flores flores = new Flores();

                    while (dataReader.Read())
                    {
                        flores.ID = Convert.ToInt32(dataReader["ID"]);
                        flores.Nome = dataReader["Nome"].ToString();
                        flores.Tipo = dataReader["Tipo"].ToString();
                        flores.PeriodoFloracao = dataReader["Periodo_floracao"].ToString();
                        flores.Origem = dataReader["Origem"].ToString();
                        flores.AtracaoAbelhas = Convert.ToBoolean(dataReader["Atracao_abelhas"]);
                    }

                    return flores;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro SQL ao realizar consulta SQL. Detalhes: " + ex);
                throw;
            }
        }
        

    }
}
