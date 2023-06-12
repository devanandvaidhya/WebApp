using System.Data.SqlClient;

namespace WebApp.Models.Services
{
    public class ProductService
    {
        private static string db_Source = "dvdbserver.database.windows.net";
        private static string db_username = "Dvadmin";
        private static string db_password = "Admin@123";
        private static string db_database = "dvdb";


        private SqlConnection GetConnection()
        {
           var _builder = new  SqlConnectionStringBuilder();
            _builder.DataSource = db_Source;
            _builder.UserID = db_username;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);

        }

        public IEnumerable<Product> GetProdcut()
        {
            List<Product> _lst = new List<Product>();
            string _statement = "SELECT ProductId,ProductName,Quantity from Product";
            SqlConnection _connection = GetConnection();
            // Let's open the connection
            _connection.Open();
            // We then construct the statement of getting the data from the Course table
            SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);
            // Using the SqlDataReader class , we will read all the data from the Course table
            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Product _course = new Product()
                    {
                        ProductId = _reader.GetInt32(0),
                        ProductName = _reader.GetString(1),
                        Quantity = _reader.GetInt32(2)
                    };

                    _lst.Add(_course);
                }
            }
            _connection.Close();
            return _lst;
        }
    }
}
