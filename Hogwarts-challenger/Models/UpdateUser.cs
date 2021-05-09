using System;
using System.Collections.Generic;
using System.Net;

namespace Hogwarts_users_api
{
    public class UpdateUser : Hogwarts_request_api.ConnectionDb
    {
        public List<Hogwarts_request_api.SuccessRequest> UpdUser(List<UsersTB> data, int id)
        {
            var conn = Hogwarts_request_api.ConnectionDb.connection;
            var cmd = Hogwarts_request_api.ConnectionDb.command;

            conn.Open();

            cmd.Connection = conn;

            cmd.CommandText = $"UPDATE usuarios SET tipo_usuario_id = ?tipo_usuario_id, estado_id = ?estado_id, nombre = ?nombre, apellido = ?apellido, identificacion = ?identificacion, edad = ?edad, sexo = ?sexo, casa_id = ?casa_id WHERE id_usuario = ?id_usuario";

            cmd.Parameters.Add("?tipo_usuario_id", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = data[0].tipo_usuario_id;
            cmd.Parameters.Add("?estado_id", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = data[0].estado_id;
            cmd.Parameters.Add("?nombre", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = data[0].nombre;
            cmd.Parameters.Add("?apellido", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = data[0].apellido;
            cmd.Parameters.Add("?identificacion", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = data[0].identificacion;
            cmd.Parameters.Add("?edad", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = data[0].edad;
            cmd.Parameters.Add("?sexo", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = data[0].sexo;
            cmd.Parameters.Add("?casa_id", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = data[0].casa_id;
            cmd.Parameters.Add("?id_usuario", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = id;

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();

            conn.Close();

            List<Hogwarts_request_api.SuccessRequest> response = new List<Hogwarts_request_api.SuccessRequest>(){
                new Hogwarts_request_api.SuccessRequest {
                    description = "Se ha actualizado el usuario",
                    status = 200
                }
            };

            return response;
        }
    }

}