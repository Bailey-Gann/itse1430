using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Nile.Stores
{
    public class Sql : ProductDatabase
    {
        public Sql ( string connectionString )
        {
            _connectionString = connectionString;
        }
        private readonly string _connectionString;
        protected override Product AddCore ( Product product )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("AddProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                object result = cmd.ExecuteScalar();

                product.Id = Convert.ToInt32(result);
            }
            return product;
        }


       
        protected override IEnumerable<Product> GetAllCore ()
        {
            DataSet ds = new DataSet();

            using (var conn = OpenConnection())
            {
                var command = new SqlCommand("GetAllProducts", conn);

                var da = new SqlDataAdapter(command);

                da.Fill(ds);
            }

            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
                return table.Rows.OfType<DataRow>().Select(LoadProduct);

            return Enumerable.Empty<Product>();
        }

        //Load Product helper methods
        private Product LoadProduct (DataRow row )
        {
            return new Product() {
                Id = Convert.ToInt32(row[0]),
                Name = row["Name"].ToString(),
                Price = row.Field<decimal>("Price"),
                Description = row.Field<string>("Description")
            };
        }
        private static Product LoadProduct ( SqlDataReader reader ) => new Product() {
            Id = Convert.ToInt32(reader[0]),
            Name = reader["Name"]?.ToString(),
            Description = reader.IsDBNull(2) ? "" : reader.GetFieldValue<string>(2),
            Price = reader.GetInt32("Price")
        };

        protected override Product GetCore ( int id )
        {
            using ( var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return LoadProduct(reader);
                    };
                };
            }
            return null;
        }
        protected override void RemoveCore ( int id )
        {
            using(var conn = OpenConnection())
            {
                var cmd = new SqlCommand("DeleteMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Add parameters
                cmd.Parameters.AddWithValue("@id", id);

                //Execute - no results
                cmd.ExecuteNonQuery();
            }
        }
        protected override Product UpdateCore ( Product existing, Product newItem )
        {
            using( var conn = OpenConnection())
            {
                var cmd = new SqlCommand("UpdateProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", existing.Id);
                cmd.Parameters.AddWithValue("@name", existing.Name);
                cmd.Parameters.AddWithValue("@price", existing.Price);
                cmd.Parameters.AddWithValue("@description", existing.Description);
                cmd.Parameters.AddWithValue("@isDiscontinued", existing.IsDiscontinued);

                object result = cmd.ExecuteNonQuery();
            }
            return newItem;
        }

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }

        protected override object FindByName ( string name ) => throw new NotImplementedException();
    }
}
