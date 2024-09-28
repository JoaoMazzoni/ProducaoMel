using Microsoft.Data.SqlClient;
using Models;
using ProducaoMel.DALL;


namespace ProducaoMel.Repositories
{
    public class ColmeiaRepository
    {
        private DALProducaoMel _dalProducaoMel;

        public ColmeiaRepository()
        {
            _dalProducaoMel = new DALProducaoMel();
        }

        public void AddColmeia(Colmeia colmeia)
        {
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Colmeia(Localizacao, Data_instalacao, Numero_abelhas, Estado_saude, Especie_abelhas) VALUES (@Localizacao, @Data_instalacao, @Numero_abelhas, @Estado_saude, @Especie_abelhas)";
                    cmd.Parameters.AddWithValue("@Localizacao", colmeia.Localizacao);
                    cmd.Parameters.AddWithValue("@Data_instalacao", colmeia.DataInstalacao);
                    cmd.Parameters.AddWithValue("@Numero_abelhas", colmeia.NumeroAbelhas);
                    cmd.Parameters.AddWithValue("@Estado_saude", colmeia.EstadoSaude);
                    cmd.Parameters.AddWithValue("@Especie_abelhas", colmeia.EspecieAbelhas);
                    var linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas == 0)
                    {
                        Console.WriteLine("Erro ao inserir registro!");
                    }
                    else
                    {
                        Console.WriteLine("Registro de Colmeia inserido com sucesso!");
                    }


                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro SQL ao realizar consulta SQL. Detalhes: " + ex);
                throw;
            }
            
            
        }

        public void UpdateColmeia(Colmeia colmeia)
        {
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "UPDATE Colmeia SET Localizacao = @Localizacao, Data_instalacao = @Data_instalacao, Numero_abelhas = @Numero_abelhas, Estado_saude = @Estado_saude, Especie_abelhas = @Especie_abelhas WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@Localizacao", colmeia.Localizacao);
                    cmd.Parameters.AddWithValue("@Data_instalacao", colmeia.DataInstalacao);
                    cmd.Parameters.AddWithValue("@Numero_abelhas", colmeia.NumeroAbelhas);
                    cmd.Parameters.AddWithValue("@Estado_saude", colmeia.EstadoSaude);
                    cmd.Parameters.AddWithValue("@Especie_abelhas", colmeia.EspecieAbelhas);
                    cmd.Parameters.AddWithValue("@ID", colmeia.ID);
                    var linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas == 0)
                    {
                        Console.WriteLine("Erro ao atualizar registro!");
                    }
                    else
                    {
                        Console.WriteLine("Registro de Colmeia atualizado com sucesso!");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro SQL ao realizar consulta SQL. Detalhes: " + ex);
                throw;
            }

        }

        public void DeleteColmeia(int id)
        {
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Colmeia WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    var linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas == 0)
                    {
                        Console.WriteLine("\nErro ao deletar registro. Nenhuma colmeia foi delatada.");
                        Console.Write("\nPressione qualquer tecla para continuar: ");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("\nRegistro de Colmeia deletado com sucesso!");
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

        public List<Colmeia> GetAllColmeias()
        {
            List<Colmeia> colmeias = new List<Colmeia>();
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Colmeia";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            colmeias.Add(new Colmeia
                            {
                                ID = reader.GetInt32(0),
                                Localizacao = reader.GetString(1),
                                DataInstalacao = reader.GetDateTime(2),
                                NumeroAbelhas = reader.GetInt32(3),
                                EstadoSaude = reader.GetString(4),
                                EspecieAbelhas = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro SQL ao realizar consulta SQL. Detalhes: " + ex);
                throw;
            }

            return colmeias;
        }

        public Colmeia GetColmeiaById(int id)
        {
            Colmeia colmeia = new Colmeia();
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Colmeia WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            colmeia.ID = reader.GetInt32(0);
                            colmeia.Localizacao = reader.GetString(1);
                            colmeia.DataInstalacao = reader.GetDateTime(2);
                            colmeia.NumeroAbelhas = reader.GetInt32(3);
                            colmeia.EstadoSaude = reader.GetString(4);
                            colmeia.EspecieAbelhas = reader.GetString(5);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro SQL ao realizar consulta SQL. Detalhes: " + ex);
                throw;
            }

            return colmeia;
        }


    }
}
