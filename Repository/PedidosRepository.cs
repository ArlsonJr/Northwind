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
    public class PedidosRepository : Conn
    {
        public List<Pedidos> GetPedidos(string idCliente)
        {
            List<Pedidos> list = new List<Pedidos>();

            using (var conn = new SqlConnection(ConnString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand( 
                    @"SELECT Cus.CustomerID, Cus.CompanyName, Ord.OrderID, Ord.OrderDate, Ord.RequiredDate, SUM( OD.UnitPrice ) UnitPrice
                      FROM Orders Ord 
                      INNER JOIN[Order Details] OD ON OD.OrderID = Ord.OrderID 
                      INNER JOIN[Customers] Cus ON Cus.CustomerID = Ord.CustomerID 
                      WHERE Cus.CustomerID = '" + idCliente + "' " +
                      "GROUP BY Cus.CustomerID, Cus.CompanyName, Ord.OrderID, Ord.OrderDate, Ord.RequiredDate", conn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Pedidos pedidos = new Pedidos();

                    pedidos.CustomerID = dr[0].ToString();
                    pedidos.CompanyName = dr[1].ToString();
                    pedidos.OrderID = Convert.ToInt32(dr[2]);
                    pedidos.OrderDate = Convert.ToDateTime(dr[3]);
                    pedidos.RequiredDate = Convert.ToDateTime(dr[4]);
                    pedidos.UnitPrice = Convert.ToDecimal(dr[5]);

                    list.Add(pedidos);
                }
            }

            return list;
        }
    }
}
