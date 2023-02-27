using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;

namespace CryptoClient
{
    public class DBAction
    {
        public static string InsertDataToTable(string JsonData)
        {
            SqlConnection sqlConnection = new SqlConnection("Server=localhost;Initial Catalog=CRYPTODB;User ID=sa;Password=Password123;TrustServerCertificate=True;");

            if (!string.IsNullOrEmpty(JsonData))
            {
                try
                {
                    Root cryptoData = JsonConvert.DeserializeObject<Root>(JsonData);

                    string query = "INSERT INTO Crypto (Name, Icon, PriceandParity, CreateDate)";
                    query += " VALUES (@Name, @Icon, @PriceandParity, @CreateDate)";
                    sqlConnection.Open();
                    SqlCommand myCommand = new SqlCommand(query, sqlConnection);
                    myCommand.Parameters.AddWithValue("@Name", cryptoData.USD.ToString());
                    myCommand.Parameters.AddWithValue("@Icon","$");
                    myCommand.Parameters.AddWithValue("@PriceandParity", cryptoData.USD.alis.ToString() + "/" + cryptoData.USD.degisim.ToString());
                    myCommand.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                    myCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    return null;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else return null;
        }
    }
}
