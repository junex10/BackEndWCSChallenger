using System;
using System.Collections.Generic;
using System.Net;

namespace Hogwarts_request_api
{

    public class Requests : ConnectionDb
    {

        public List<RequestAPI> GetAllRequests()
        {
            var conn = ConnectionDb.connection;
            var cmd = ConnectionDb.command;

            conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = $"SELECT nombre, apellido, edad, sexo, identificacion, id_inscripcion, id_usuario, id_casa, casa, solicitudes_inscripcion.fecha_solicitando AS fecha_solicitando FROM solicitudes_inscripcion INNER JOIN usuarios ON(solicitudes_inscripcion.usuario_solicitando_id = usuarios.id_usuario) INNER JOIN casas on(solicitudes_inscripcion.casa_solicitada_id = casas.id_casa) INNER JOIN estados ON(solicitudes_inscripcion.estado_solicitud_id = estados.id_estado)";

            List<RequestAPI> data = new List<RequestAPI>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    data.Add(
                        new RequestAPI
                        {
                            id_inscripcion = Convert.ToInt32(reader["id_inscripcion"]),
                            nombre = reader["nombre"].ToString(),
                            apellido = reader["apellido"].ToString(),
                            edad = Convert.ToInt32(reader["edad"]),
                            sexo = reader["sexo"].ToString(),
                            identificacion = Convert.ToInt32(reader["identificacion"]),
                            id_usuario = Convert.ToInt32(reader["id_usuario"]),
                            id_casa = Convert.ToInt32(reader["id_casa"]),
                            casa = reader["casa"].ToString(),
                            fecha_solicitando = reader["fecha_solicitando"].ToString(),
                        }
                    );
                }
            }

            conn.Close();
            return data;
        }

        public List<RequestAPI> GetRequest(int id)
        {
            var conn = ConnectionDb.connection;
            var cmd = ConnectionDb.command;

            conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = $"SELECT nombre, apellido, edad, sexo, identificacion, id_inscripcion, id_usuario, id_casa, casa, solicitudes_inscripcion.fecha_solicitando AS fecha_solicitando FROM solicitudes_inscripcion INNER JOIN usuarios ON(solicitudes_inscripcion.usuario_solicitando_id = usuarios.id_usuario) INNER JOIN casas on(solicitudes_inscripcion.casa_solicitada_id = casas.id_casa) INNER JOIN estados ON(solicitudes_inscripcion.estado_solicitud_id = estados.id_estado) WHERE id_inscripcion = ?id";

            cmd.Parameters.Add("?id", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = id;

            List<RequestAPI> data = new List<RequestAPI>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    data.Add(
                        new RequestAPI
                        {
                            id_inscripcion = Convert.ToInt32(reader["id_inscripcion"]),
                            nombre = reader["nombre"].ToString(),
                            apellido = reader["apellido"].ToString(),
                            edad = Convert.ToInt32(reader["edad"]),
                            sexo = reader["sexo"].ToString(),
                            identificacion = Convert.ToInt32(reader["identificacion"]),
                            id_usuario = Convert.ToInt32(reader["id_usuario"]),
                            id_casa = Convert.ToInt32(reader["id_casa"]),
                            casa = reader["casa"].ToString(),
                            fecha_solicitando = reader["fecha_solicitando"].ToString(),
                        }
                    );
                }
            }
            cmd.Parameters.Clear();

            conn.Close();

            return data;
        }
    }

    public class RequestAPI
    {
        public int id_inscripcion { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public string sexo { get; set; }
        public int identificacion { get; set; }
        public int id_usuario { get; set; }
        public int id_casa { get; set; }
        public string casa { get; set; }
        public string fecha_solicitando { get; set; }

    }
}