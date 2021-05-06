using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProdutosRepository : Conn
    {
        public List<Produtos> GetProdutos(int idFornecedor)
        {
            List<Produtos> list = new List<Produtos>();

            using (var conn = new SqlConnection(ConnString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand( "SELECT Sup.SupplierID, Sup.CompanyName, Pro.ProductID, Pro.ProductName, Pro.UnitPrice FROM Suppliers Sup INNER JOIN[Products] Pro on Pro.SupplierID = Sup.SupplierID WHERE Sup.SupplierID = " + idFornecedor, conn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Produtos products = new Produtos();

                    products.SupplierID = Convert.ToInt32(dr[0]);
                    products.CompanyName = dr[1].ToString();
                    products.ProductID = Convert.ToInt32(dr[2]);
                    products.ProductName = dr[3].ToString();
                    products.UnitPrice = Convert.ToDecimal(dr[4]);

                    list.Add(products);
                }
            }

            return list;
        }
    }
}
