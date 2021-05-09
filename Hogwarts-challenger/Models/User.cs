using System;
using System.Collections.Generic;
using System.Net;

namespace Hogwarts_users_api
{
    public class User : Hogwarts_request_api.ConnectionDb
    {
        public List<UserAPI> GetAll()
        {
            var conn = Hogwarts_request_api.ConnectionDb.connection;
            var cmd = Hogwarts_request_api.ConnectionDb.command;

            conn.Open();

            cmd.Connection = conn;

            cmd.CommandText = $"SELECT nombre, apellido, edad, sexo, identificacion, id_usuario, tipo_usuario, tipo_usuario_id, usuarios.fecha_registro, estado FROM usuarios INNER JOIN tipo_usuarios ON(usuarios.tipo_usuario_id = tipo_usuarios.id_tipo_usuario) INNER JOIN estados ON(usuarios.estado_id = estados.id_estado)";
            List<UserAPI> data = new List<UserAPI>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    data.Add(
                        new UserAPI
                        {
                            id_usuario = Convert.ToInt32(reader["id_usuario"]),
                            nombre = reader["nombre"].ToString(),
                            apellido = reader["apellido"].ToString(),
                            edad = Convert.ToInt32(reader["edad"]),
                            sexo = reader["sexo"].ToString(),
                            estado = reader["estado"].ToString(),
                            tipo_usuario = reader["tipo_usuario"].ToString(),
                            identificacion = Convert.ToInt32(reader["identificacion"]),
                            fecha_registro = reader["fecha_registro"].ToString(),
                        }
                    );
                }
            }

            cmd.Parameters.Clear();

            conn.Close();

            return data;
        }

        public List<UserAPI> GetById(int id)
        {
            var conn = Hogwarts_request_api.ConnectionDb.connection;
            var cmd = Hogwarts_request_api.ConnectionDb.command;

            conn.Open();

            cmd.Connection = conn;

            cmd.CommandText = $"SELECT nombre, apellido, edad, sexo, identificacion, id_usuario, tipo_usuario, tipo_usuario_id, usuarios.fecha_registro, estado FROM usuarios INNER JOIN tipo_usuarios ON(usuarios.tipo_usuario_id = tipo_usuarios.id_tipo_usuario) INNER JOIN estados ON(usuarios.estado_id = estados.id_estado) WHERE id_usuario = ?id";
            
            cmd.Parameters.Add("?id", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = id;
            
            List<UserAPI> data = new List<UserAPI>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    data.Add(
                        new UserAPI
                        {
                            id_usuario = Convert.ToInt32(reader["id_usuario"]),
                            nombre = reader["nombre"].ToString(),
                            apellido = reader["apellido"].ToString(),
                            edad = Convert.ToInt32(reader["edad"]),
                            sexo = reader["sexo"].ToString(),
                            estado = reader["estado"].ToString(),
                            tipo_usuario = reader["tipo_usuario"].ToString(),
                            identificacion = Convert.ToInt32(reader["identificacion"]),
                            fecha_registro = reader["fecha_registro"].ToString(),
                        }
                    );
                }
            }

            cmd.Parameters.Clear();

            conn.Close();

            return data;
        } 
    }

    public class UserAPI
    {
        public string nombre {get; set;}
        public string apellido {get; set;}
        public string sexo {get; set;}
        public int edad {get; set;}
        public int identificacion {get; set;}
        public string fecha_registro {get; set;}
        public string estado {get; set;}
        public string tipo_usuario {get; set;}
        public int id_usuario {get; set;}
    }
}