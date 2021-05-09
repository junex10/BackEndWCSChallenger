using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Hogwarts_request_api
{
    public class ConnectionDb {
        public static MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=hogwarts;Uid=root;password=;");
        public static MySqlCommand command = new MySqlCommand();

    }
}