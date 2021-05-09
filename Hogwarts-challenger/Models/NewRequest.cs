using System;
using System.Collections.Generic;

namespace Hogwarts_request_api
{
    public class NewRequest : ConnectionDb
    {
        public List<SuccessRequest> PushRequest(List<RequestTB> data)
        {
            var conn = ConnectionDb.connection;
            var cmd = ConnectionDb.command;

            conn.Open();

            cmd.Connection = conn;

            cmd.CommandText = $"INSERT INTO solicitudes_inscripcion(usuario_solicitando_id, casa_solicitada_id, estado_solicitud_id) VALUES(?usuario_id, ?casa_id, ?estado_id)";

            cmd.Parameters.Add("?usuario_id", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = data[0].usuario_solicitando_id;
            cmd.Parameters.Add("?casa_id", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = data[0].casa_solicitada_id;
            cmd.Parameters.Add("?estado_id", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = data[0].estado_solicitud_id;

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();

            conn.Close();

            List<SuccessRequest> response = new List<SuccessRequest>(){
                new SuccessRequest {
                    description = "Se ha completado el registro",
                    status = 200
                }
            };

            return response;
        }
    }

    public class RequestTB
    {
        public int usuario_solicitando_id { get; set; }
        public int casa_solicitada_id { get; set; }
        public int estado_solicitud_id { get; set; }
    }
}