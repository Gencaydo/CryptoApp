using System.Collections.Generic;
using System.Data;
using System;
using CryptoWeb.Models;
using Microsoft.Data.SqlClient;

namespace CryptoWeb.Repository
{
    public class CryptoRepository
    {
        string connectionString;

        public CryptoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Crypto> GetCryptoValues()
        {
            List<Crypto> cryptodata = new List<Crypto>();
            Crypto crypto;

            var data = GetCryptoDataFromDb();

            foreach (DataRow row in data.Rows)
            {
                crypto = new Crypto
                {
                    Name = row["Name"].ToString(),
                    Icon = row["Icon"].ToString(),
                    PriceandParity = row["PriceandParity"].ToString(),
                    CreateDate = Convert.ToDateTime(row["CreateDate"]),
                };
                cryptodata.Add(crypto);
            }

            return cryptodata;
        }

        private DataTable GetCryptoDataFromDb()
        {
            var query = "SELECT Id, Name, Icon, PriceandParity, CreateDate FROM Crypto";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }

                    return dataTable;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
