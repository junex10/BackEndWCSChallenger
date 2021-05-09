using System;
using System.Collections.Generic;
using System.Net;

namespace Hogwarts_request_api
{
    public class UpdateRequestAPI : ConnectionDb
    {
        public List<SuccessRequest> UpdateRequest(List<RequestTB> data, int id)
        {
            var conn = ConnectionDb.connection;
            var cmd = ConnectionDb.command;

            conn.Open();

            cmd.Connection = conn;

            cmd.CommandText = $"UPDATE solicitudes_inscripcion SET usuario_solicitando_id = ?usuario_id, casa_solicitada_id = ?casa_id, estado_solicitud_id = ?estado_id WHERE id_inscripcion = ?id_inscripcion";

            cmd.Parameters.Add("?usuario_id", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = data[0].usuario_solicitando_id;
            cmd.Parameters.Add("?casa_id", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = data[0].casa_solicitada_id;
            cmd.Parameters.Add("?estado_id", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = data[0].estado_solicitud_id;
            cmd.Parameters.Add("?id_inscripcion", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = id;

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();

            conn.Close();

            List<SuccessRequest> response = new List<SuccessRequest>(){
                new SuccessRequest {
                    description = "Se ha actualizado el registro",
                    status = 200
                }
            };

            return response;
        }
    }

}