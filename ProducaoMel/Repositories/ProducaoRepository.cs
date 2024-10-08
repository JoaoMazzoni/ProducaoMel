﻿using Microsoft.Data.SqlClient;
using Models;
using ProducaoMel.DALL;

namespace ProducaoMel.Repositories
{
    public class ProducaoRepository
    {
        private DALProducaoMel _dalProducaoMel;

        public ProducaoRepository()
        {
            _dalProducaoMel = new DALProducaoMel();
        }

        public void AddProducao(Producao producao)
        {
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Producao(Data_colheita, ColmeiaID, MelID, Quantidade_colhida, Qualidade_final) VALUES (@Data_colheita, @ColmeiaID, @MelID, @Quantidade_colhida, @Qualidade_final)";
                    cmd.Parameters.AddWithValue("@Data_colheita", producao.DataColheita);
                    cmd.Parameters.AddWithValue("@ColmeiaID", producao.ColmeiaID);
                    cmd.Parameters.AddWithValue("@MelID", producao.MelID);
                    cmd.Parameters.AddWithValue("@Quantidade_colhida", producao.QuantidadeColhida);
                    cmd.Parameters.AddWithValue("@Qualidade_final", producao.QualidadeFinal);
                 
                    var linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas == 0)
                    {
                        Console.WriteLine("\nErro ao inserir registro!");
                        Console.Write("\nPressione qualquer tecla para continuar: ");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("\nRegistro de Producao inserido com sucesso!");
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

        public void UpdateProducao(Producao producao)
        {
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "UPDATE Producao SET Data_colheita = @Data_colheita, ColmeiaID = @ColmeiaID, MelID = @MelID, Quantidade_colhida = @Quantidade_colhida, Qualidade_final = @Qualidade_final WHERE Lote = @Lote";
                    cmd.Parameters.AddWithValue("@Data_colheita", producao.DataColheita);
                    cmd.Parameters.AddWithValue("@ColmeiaID", producao.ColmeiaID);
                    cmd.Parameters.AddWithValue("@MelID", producao.MelID);
                    cmd.Parameters.AddWithValue("@Quantidade_colhida", producao.QuantidadeColhida);
                    cmd.Parameters.AddWithValue("@Qualidade_final", producao.QualidadeFinal);
                    cmd.Parameters.AddWithValue("@Lote", producao.Lote);
                    var linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas == 0)
                    {
                        Console.WriteLine("\nErro ao atualizar registro!");
                        Console.Write("\nPressione qualquer tecla para continuar: ");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("\nRegistro de Producao atualizado com sucesso!");
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

        public void DeleteProducao(int lote)
        {
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Producao WHERE Lote = @Lote";
                    cmd.Parameters.AddWithValue("@Lote", lote);
                    var linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas == 0)
                    {
                        Console.WriteLine("\nErro ao deletar registro!");
                        Console.Write("\nPressione qualquer tecla para continuar: ");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("\nRegistro de Producao deletado com sucesso!");
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

        public List<Producao> GetAllProducao()
        {
            List<Producao> producoes = new List<Producao>();

            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Producao";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producao producao = new Producao();
                            producao.Lote = reader.GetInt32(0);
                            producao.DataColheita = reader.GetDateTime(1);
                            if (!reader.IsDBNull(2))
                            {
                                producao.ColmeiaID = reader.GetInt32(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                producao.MelID = reader.GetInt32(3);
                            }
                            producao.QuantidadeColhida = reader.GetDouble(4);
                            producao.QualidadeFinal = reader.GetString(5);
                            producoes.Add(producao);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro SQL ao realizar consulta SQL. Detalhes: " + ex);
                throw;
            }

            return producoes;
        }

        public Producao GetProducaoByLote(int lote)
        {
            Producao producao = new Producao();
            try
            {
                using (var cmd = _dalProducaoMel.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Producao WHERE Lote = @Lote";
                    cmd.Parameters.AddWithValue("@Lote", lote);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            producao.Lote = reader.GetInt32(0);
                            producao.DataColheita = reader.GetDateTime(1);
                            if (!reader.IsDBNull(2))
                            {
                                producao.ColmeiaID = reader.GetInt32(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                producao.MelID = reader.GetInt32(3);
                            }
                            producao.QuantidadeColhida = reader.GetDouble(4);
                            producao.QualidadeFinal = reader.GetString(5);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro SQL ao realizar consulta SQL. Detalhes: " + ex);
                throw;
            }

            return producao;
        }
    }
}
