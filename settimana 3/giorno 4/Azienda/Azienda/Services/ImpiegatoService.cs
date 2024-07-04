// Services/ImpiegatoService.cs
using Azienda.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Azienda.Services
{
    public class ImpiegatoService : IImpiegatoService
    {
        private readonly string? _connectionString;

        public ImpiegatoService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Appconn");
        }

        public IEnumerable<Impiegato> GetImpiegati()
        {
            List<Impiegato> impiegati = new List<Impiegato>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT IDImpiegato, Cognome, Nome, CodiceFiscale, Eta, RedditoMensile, DetrazioneFiscale FROM IMPIEGATO";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Impiegato impiegato = new Impiegato
                            {
                                IDImpiegato = reader.GetInt32(0),
                                Cognome = reader.GetString(1),
                                Nome = reader.GetString(2),
                                CodiceFiscale = reader.GetString(3),
                                Eta = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                                RedditoMensile = reader.IsDBNull(5) ? (decimal?)null : reader.GetDecimal(5),
                                DetrazioneFiscale = reader.GetBoolean(6)
                            };

                            impiegati.Add(impiegato);
                        }
                    }
                }
            }

            return impiegati;
        }

        public Impiegato GetImpiegatoById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT IDImpiegato, Cognome, Nome, CodiceFiscale, Eta, RedditoMensile, DetrazioneFiscale FROM IMPIEGATO WHERE IDImpiegato = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Impiegato
                            {
                                IDImpiegato = reader.GetInt32(0),
                                Cognome = reader.GetString(1),
                                Nome = reader.GetString(2),
                                CodiceFiscale = reader.GetString(3),
                                Eta = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                                RedditoMensile = reader.IsDBNull(5) ? (decimal?)null : reader.GetDecimal(5),
                                DetrazioneFiscale = reader.GetBoolean(6)
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void InsertImpiegato(Impiegato impiegato)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO IMPIEGATO (Cognome, Nome, CodiceFiscale, Eta, RedditoMensile, DetrazioneFiscale)
                                 VALUES (@Cognome, @Nome, @CodiceFiscale, @Eta, @RedditoMensile, @DetrazioneFiscale)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Cognome", impiegato.Cognome);
                    cmd.Parameters.AddWithValue("@Nome", impiegato.Nome);
                    cmd.Parameters.AddWithValue("@CodiceFiscale", impiegato.CodiceFiscale);
                    cmd.Parameters.AddWithValue("@Eta", impiegato.Eta ?? (object)DBNull.Value); // Gestione di nullable
                    cmd.Parameters.AddWithValue("@RedditoMensile", impiegato.RedditoMensile ?? (object)DBNull.Value); // Gestione di nullable
                    cmd.Parameters.AddWithValue("@DetrazioneFiscale", impiegato.DetrazioneFiscale);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateImpiegato(Impiegato impiegato)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE IMPIEGATO
                                 SET Cognome = @Cognome,
                                     Nome = @Nome,
                                     CodiceFiscale = @CodiceFiscale,
                                     Eta = @Eta,
                                     RedditoMensile = @RedditoMensile,
                                     DetrazioneFiscale = @DetrazioneFiscale
                                 WHERE IDImpiegato = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Cognome", impiegato.Cognome);
                    cmd.Parameters.AddWithValue("@Nome", impiegato.Nome);
                    cmd.Parameters.AddWithValue("@CodiceFiscale", impiegato.CodiceFiscale);
                    cmd.Parameters.AddWithValue("@Eta", impiegato.Eta ?? (object)DBNull.Value); // Gestione di nullable
                    cmd.Parameters.AddWithValue("@RedditoMensile", impiegato.RedditoMensile ?? (object)DBNull.Value); // Gestione di nullable
                    cmd.Parameters.AddWithValue("@DetrazioneFiscale", impiegato.DetrazioneFiscale);
                    cmd.Parameters.AddWithValue("@Id", impiegato.IDImpiegato);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteImpiegato(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM IMPIEGATO WHERE IDImpiegato = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
