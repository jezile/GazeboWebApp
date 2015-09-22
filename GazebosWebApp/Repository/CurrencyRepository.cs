using GazebosWebApp.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GazebosWebApp.Repository
{
    public class CurrencyRepository : IGenericRepository<CurrencyModel>
    {
        #region # constructor #

        private readonly string _connectionString;

        public CurrencyRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MVC"].ToString();
        }

        #endregion

        #region # CRUD methods #

        public IEnumerable<CurrencyModel> SelectAll()
        {
            List<CurrencyModel> list = new List<CurrencyModel>();
            CurrencyModel u = null;

            using (var conn = new SqlConnection(_connectionString))
            {

                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT * FROM dbo.tblUser";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            u = new CurrencyModel();
                            //u.UserID = reader.GetInt32(reader.GetOrdinal("UserId"));
                            //u.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                            //u.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                            //u.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                            //u.Email = reader.GetString(reader.GetOrdinal("Email"));
                            //u.Address1 = reader.GetString(reader.GetOrdinal("Address1"));
                            //u.Address2 = reader.GetString(reader.GetOrdinal("Address2"));
                            //u.Town = reader.GetString(reader.GetOrdinal("Town"));
                            //u.PostCode = reader.GetString(reader.GetOrdinal("PostCode"));
                            //u.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                            //u.CreationDateTime = reader.GetDateTime(reader.GetOrdinal("CreationDateTime"));
                            list.Add(u);
                        };
                    }
                }
            }
            return list;
        }


        public CurrencyModel SelectByID(object id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT * FROM dbo.tblUser WHERE UserID = @UserID";
                    cmd.Parameters.AddWithValue("@UserID", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }
                        return new CurrencyModel
                        {
                            //UserID = reader.GetInt32(reader.GetOrdinal("UserId")),
                            //UserName = reader.GetString(reader.GetOrdinal("UserName")),
                            //FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            //LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            //Email = reader.GetString(reader.GetOrdinal("Email")),
                            //Address1 = reader.GetString(reader.GetOrdinal("Address1")),
                            //Address2 = reader.GetString(reader.GetOrdinal("Address2")),
                            //Town = reader.GetString(reader.GetOrdinal("Town")),
                            //PostCode = reader.GetString(reader.GetOrdinal("PostCode")),
                            //PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                            //CreationDateTime = reader.GetDateTime(reader.GetOrdinal("CreationDateTime")),
                        };
                    }
                }
            }
        }


        public void Insert(CurrencyModel user)
        {
            // ToDo
        }
        public void Update(CurrencyModel user)
        {
            // ToDo
        }

        public void Delete(object id)
        {
            // ToDo
        }
    }
    #endregion

}