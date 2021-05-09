using System;
using System.Collections.Generic;
using System.Net;

namespace Hogwarts_request_api
{
    public class RemoveRequest : ConnectionDb
    {
        public List<SuccessRequest> DisableRequest(int id)
        {
            var conn = ConnectionDb.connection;
            var cmd = ConnectionDb.command;

            conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = $"UPDATE solicitudes_inscripcion SET estado_solicitud_id = 4 WHERE id_inscripcion = ?id";

            cmd.Parameters.Add("?id", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = id;

            cmd.ExecuteNonQuery();

            conn.Close();

            List<SuccessRequest> response = new List<SuccessRequest>(){
                new SuccessRequest {
                    description = "Se ha inhabilitado el registro",
                    status = 200
                }
            };

            return response;
        }
    }

    public class DisableRequestAPI
    {
        public int estado_id { get; set; }
    }
}