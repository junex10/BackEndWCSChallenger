using System;
using System.Collections.Generic;

namespace Hogwarts_users_api
{
    public class NewUser : Hogwarts_request_api.ConnectionDb
    {
        public List<Hogwarts_request_api.SuccessRequest> PushUser(List<UsersTB> data)
        {
            var conn = Hogwarts_request_api.ConnectionDb.connection;
            var cmd = Hogwarts_request_api.ConnectionDb.command;

            conn.Open();

            cmd.Connection = conn;

            cmd.CommandText = $"INSERT INTO usuarios(nombre, apellido, edad, sexo, identificacion, casa_id, estado_id, tipo_usuario_id) VALUES(?nombre, ?apellido, ?edad, ?sexo, ?identificacion, ?casa_id, ?estado_id, ?tipo_usuario_id)";

            cmd.Parameters.Add("?nombre", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = data[0].nombre;
            cmd.Parameters.Add("?apellido", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = data[0].apellido;
            cmd.Parameters.Add("?edad", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = data[0].edad;
            cmd.Parameters.Add("?sexo", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = data[0].sexo;
            cmd.Parameters.Add("?identificacion", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = data[0].identificacion;
            cmd.Parameters.Add("?estado_id", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = data[0].estado_id;
            cmd.Parameters.Add("?tipo_usuario_id", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = data[0].tipo_usuario_id;
            cmd.Parameters.Add("?casa_id", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = data[0].casa_id;

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();

            conn.Close();

            List<Hogwarts_request_api.SuccessRequest> response = new List<Hogwarts_request_api.SuccessRequest>(){
                new Hogwarts_request_api.SuccessRequest {
                    description = "Se ha completado el registro",
                    status = 200
                }
            };

            return response;
        }
    }

    public class UsersTB
    {
        public int tipo_usuario_id { get; set; }
        public int estado_id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int identificacion { get; set; }
        public int edad { get; set; }
        public string sexo { get; set; }
        public int casa_id { get; set; }

    }
}