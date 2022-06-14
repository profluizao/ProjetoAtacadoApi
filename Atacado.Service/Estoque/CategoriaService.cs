using Atacado.Poco.Estoque;
using Atacado.EF.Database;
using Atacado.Mapper.Estoque;
using Atacado.Service.Ancestral;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atacado.Dal.Estoque;

namespace Atacado.Service.Estoque
{
    public class CategoriaService : BaseAncestralService<CategoriaPoco>
    {
        private CategoriaMapper map;

        public CategoriaService()
        {
            this.map = new CategoriaMapper();
        }

        public override List<CategoriaPoco> Listar()
        {
            CategoriaDao dao = new CategoriaDao();
            List<Categoria> listDOM = dao.ReadAll();
            List<CategoriaPoco> listPOCO = new List<CategoriaPoco>();
            foreach (Categoria item in listDOM)
            {
                CategoriaPoco poco = this.map.Mapper.Map<CategoriaPoco>(item);
                listPOCO.Add(poco);
            }
            return listPOCO;
        }

    }
}
