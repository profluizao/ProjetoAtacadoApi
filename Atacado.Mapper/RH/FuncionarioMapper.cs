using Atacado.Mapper.Ancestral;
using Atacado.EF.Database;
using Atacado.Poco.RH;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Mapper.RH
{
    public class FuncionarioMapper : BaseAncestralMapper
    {
        public FuncionarioMapper() : base()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Funcionario, FuncionarioPoco>();

                cfg.CreateMap<FuncionarioPoco, Funcionario>();
            });
            this.getMapper = configuration.CreateMapper();
        }
    }
}
