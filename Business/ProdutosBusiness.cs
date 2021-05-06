using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProdutosBusiness
    {
        public List<Produtos> GetProduto(int idFornecedor)
        {
            return new Repository.ProdutosRepository().GetProdutos(idFornecedor);
        }
    }
}
