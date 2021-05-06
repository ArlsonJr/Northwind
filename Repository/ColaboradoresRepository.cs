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
    public class ColaboradoresRepository : Conn
    {
        public List<Colaboradores> GetColaboradores(DateTime dataI, DateTime dataF)
        {
            List<Colaboradores> list = new List<Colaboradores>();

            using (var conn = new SqlConnection(ConnString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand( 
                    @"SELECT Emp.EmployeeID, Emp.LastName, Emp.FirstName, COUNT( Ord.OrderId ) QuantPedidos
                      FROM Employees Emp
                      INNER JOIN[Orders] Ord ON Ord.EmployeeID = Emp.EmployeeID
                      WHERE Ord.OrderDate BETWEEN @DataI AND @DataF
                      GROUP BY Emp.EmployeeID, Emp.LastName, Emp.FirstName", conn);

                cmd.Parameters.Add("@DataI", SqlDbType.DateTime);
                cmd.Parameters["@DataI"].Value = dataI;
                cmd.Parameters.Add("@DataF", SqlDbType.DateTime);
                cmd.Parameters["@DataF"].Value = dataF;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Colaboradores colaboradores = new Colaboradores();

                    colaboradores.EmployeeID = Convert.ToInt32(dr[0]);
                    colaboradores.LastName = dr[1].ToString();
                    colaboradores.FirstName = dr[2].ToString();
                    colaboradores.QuantPedidos = Convert.ToInt32(dr[3]);

                    list.Add(colaboradores);
                }
            }

            return list;
        }
    }
}
