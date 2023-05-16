using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PalEats.Models;

namespace PalEats.Services
{
    public class SignUpServices
    {
        private readonly string _connectionString = "Server=tcp:paleatserver.database.windows.net,1433;Initial Catalog=PalEatsDB;Persist Security Info=False;User ID=sama;Password=S11a7m2!a000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public async Task<int> InsertNewUsersAsync(SignUpModel signUpModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM [Users] WHERE Email = @Email", connection);
                    checkCommand.Parameters.AddWithValue("@Email", signUpModel.Email);

                    int count = (int)await checkCommand.ExecuteScalarAsync();

                    if (count > 0)
                    {
                        return 0;
                    }

                    SqlCommand insertCommand = new SqlCommand("INSERT INTO [Users] (Email, Password) OUTPUT INSERTED.UserId VALUES (@Email, @Password)", connection);
                    insertCommand.Parameters.AddWithValue("@Email", signUpModel.Email);
                    insertCommand.Parameters.AddWithValue("@Password", signUpModel.Password);

                    int newUserId = (int)await insertCommand.ExecuteScalarAsync();

                    return newUserId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in InsertNewUsersAsync: {ex.Message}");
                throw ex;
            }
        }
    }
}
