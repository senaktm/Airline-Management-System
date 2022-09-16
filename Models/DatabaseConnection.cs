
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineManagementSystem.Models
{
    public class DatabaseConnection
    {
        public static string connection = "server=localhost;port=5432;Database=database;" +
                " User Id=postgres;" + "Password=1234";

        public string Statu_Check()
        {
            using (var connect = new NpgsqlConnection(connection))
            {
                try
                {
                    connect.Open();
                    NpgsqlDataReader reader;
                    NpgsqlCommand cmd = new NpgsqlCommand(
                           "SELECT statu_name " +
                           "FROM statu_table " +
                           "WHERE statu_id " +
                           " IN(Select statu_id " +
                           "from usertable  " +
                           "WHERE user_id ='" + UserModel.user_id + "' )", connect);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        UserModel.statu_name = reader.GetString(0);
                    }
                    return UserModel.statu_name;
                }
                catch
                {

                }
            }
            return UserModel.statu_name;
        }


        public bool LoginCheck()
        {
            using (var connect = new NpgsqlConnection(connection))
            {
                try
                {
                    connect.Open();
                    NpgsqlDataReader reader, reader2;
                    NpgsqlCommand cmd = new NpgsqlCommand(
                        "SELECT user_id" +
                        " FROM usertable" +
                        " WHERE username ='" + UserModel.username + "'" +
                        " AND passwords ='" + UserModel.password + "'", connect);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        UserModel.user_id = reader.GetInt32(0);
                        Statu_Check();
                        connect.Close();
                        return true;
                    }
                    else
                    {
                        connect.Close();

                        return false;
                    }

                }
                catch (Exception ex)
                {



                    return false;
                    throw;
                }
            }
        }

    }
}