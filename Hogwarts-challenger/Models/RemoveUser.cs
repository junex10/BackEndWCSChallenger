using System;
using System.Collections.Generic;
using System.Net;

namespace Hogwarts_users_api
{
    public class RemoveUser : Hogwarts_request_api.ConnectionDb
    {
        public List<Hogwarts_request_api.SuccessRequest> DisableUser(int id)
        {
            var conn = Hogwarts_request_api.ConnectionDb.connection;
            var cmd = Hogwarts_request_api.ConnectionDb.command;

            conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = $"UPDATE usuarios SET estado_id = 4 WHERE id_usuario = ?id";

            cmd.Parameters.Add("?id", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = id;

            cmd.ExecuteNonQuery();

            conn.Close();

            List<Hogwarts_request_api.SuccessRequest> response = new List<Hogwarts_request_api.SuccessRequest>(){
                new Hogwarts_request_api.SuccessRequest {
                    description = "Se ha inhabilitado el usuario",
                    status = 200
                }
            };

            return response;
        }
    }

}