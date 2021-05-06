using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ColaboradoresBusiness
    {
        public List<Colaboradores> GetColaboradores(DateTime dataI, DateTime dataF)
        {
            return new Repository.ColaboradoresRepository().GetColaboradores(dataI, dataF);
        }
    }
}
