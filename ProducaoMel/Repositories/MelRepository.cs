using Microsoft.Data.SqlClient;
using Models;
using ProducaoMel.DALL;

namespace ProducaoMel.Repositories
{
    public class MelRepository
    {
        private DALProducaoMel _dalProducaoMel;

        public MelRepository()
        {
            _dalProducaoMel = new DALProducaoMel();
        }

        public void AddMel(Mel mel)
        {
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Mel(Nome, Cor, Consistencia, Sabor, Aroma, Composicao, FlorID) VALUES (@Nome, @Cor, @Consistencia, @Sabor, @Aroma, @Composicao, @FlorID)";
                    cmd.Parameters.AddWithValue("@Nome", mel.Nome);
                    cmd.Parameters.AddWithValue("@Cor", mel.Cor);
                    cmd.Parameters.AddWithValue("@Consistencia", mel.Consistencia);
                    cmd.Parameters.AddWithValue("@Sabor", mel.Sabor);
                    cmd.Parameters.AddWithValue("@Aroma", mel.Aroma);
                    cmd.Parameters.AddWithValue("@Composicao", mel.Composicao);
                    cmd.Parameters.AddWithValue("@FlorID", mel.FlorID);
                    var linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas == 0)
                    {
                        Console.WriteLine("\nErro ao inserir registro!");
                        Console.Write("\nPressione qualquer tecla para continuar: ");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("\nRegistro de Mel inserido com sucesso!");
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

        public void UpdateMel(Mel mel)
        {
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "UPDATE Mel SET Nome = @Nome, Cor = @Cor, Consistencia = @Consistencia, Sabor = @Sabor, Aroma = @Aroma, Composicao = @Composicao, FlorID = @FlorID WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", mel.ID);
                    cmd.Parameters.AddWithValue("@Nome", mel.Nome);
                    cmd.Parameters.AddWithValue("@Cor", mel.Cor);
                    cmd.Parameters.AddWithValue("@Consistencia", mel.Consistencia);
                    cmd.Parameters.AddWithValue("@Sabor", mel.Sabor);
                    cmd.Parameters.AddWithValue("@Aroma", mel.Aroma);
                    cmd.Parameters.AddWithValue("@Composicao", mel.Composicao);
                    cmd.Parameters.AddWithValue("@FlorID", mel.FlorID);
                    var linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas == 0)
                    {
                        Console.WriteLine("\nErro ao atualizar registro!");
                        Console.Write("\nPressione qualquer tecla para continuar: ");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("\nRegistro de Mel atualizado com sucesso!");
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

        public void DeleteMel(int id)
        {
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Mel WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    var linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas == 0)
                    {
                        Console.WriteLine("\nErro ao deletar registro! Nenhum mel foi deletado.");
                        Console.Write("\nPressione qualquer tecla para continuar: ");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("\nRegistro de Mel deletado com sucesso!");
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

        public List<Mel> GetAllMel()
        {
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Mel";
                    var mel = new List<Mel>();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mel.Add(new Mel
                            {
                                ID = reader.GetInt32(0), 
                                Nome = reader.GetString(1), 
                                Cor = reader.GetString(2), 
                                Consistencia = reader.GetString(3), 
                                Sabor = reader.GetString(4), 
                                Aroma = reader.GetString(5), 
                                Composicao = reader.GetString(6), 
                                FlorID = reader.IsDBNull(7) ? (int?)null : reader.GetInt32(7) 
                            });
                        }
                    }

                    return mel;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro SQL ao realizar consulta SQL. Detalhes: " + ex);
                throw;
            }
        }

        public Mel GetMelByID(int id)
        {
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Mel WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    var mel = new Mel();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mel = new Mel
                            {
                                ID = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Cor = reader.GetString(2),
                                Consistencia = reader.GetString(3),
                                Sabor = reader.GetString(4),
                                Aroma = reader.GetString(5),
                                Composicao = reader.GetString(6),
                                FlorID = reader.IsDBNull(7) ? (int?)null : reader.GetInt32(7)
                            };
                        }
                    }

                    return mel;
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
