using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PedidosBusiness
    {
        public List<Pedidos> GetPedido(string idCliente)
        {
            return new Repository.PedidosRepository().GetPedidos(idCliente);
        }
    }
}
