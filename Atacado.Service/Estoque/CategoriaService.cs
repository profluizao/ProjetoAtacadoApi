﻿using Atacado.EF.Database;
using Atacado.Mapper.Estoque;
using Atacado.Poco.Estoque;
using Atacado.Repository.Estoque;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Estoque
{
    public class CategoriaService : BaseAncestralService<CategoriaPoco, Categoria>
    {
        private CategoriaMapper mapConfig;
        private CategoriaRepository repositorio;

        public CategoriaService()
        {
            this.mapConfig = new CategoriaMapper();
            this.repositorio = new CategoriaRepository(new AtacadoContext());
        }

        public CategoriaService(AtacadoContext contexto)
        {
            this.mapConfig = new CategoriaMapper();
            this.repositorio = new CategoriaRepository(contexto);
        }

        public override List<CategoriaPoco> Listar()
        {
            List<Categoria> listDOM = this.repositorio.Read().ToList();
            return this.ProcessarListaDOM(listDOM);
        }

        protected override List<CategoriaPoco> ProcessarListaDOM(List<Categoria> listDOM)
        {
            return listDOM.Select(dom => this.mapConfig.Mapper.Map<CategoriaPoco>(dom)).ToList();
        }

        public override CategoriaPoco Selecionar(int id)
        {
            Categoria dom = this.repositorio.Read(id);
            CategoriaPoco poco = this.mapConfig.Mapper.Map<CategoriaPoco>(dom);
            return poco;
        }

        public override CategoriaPoco Criar(CategoriaPoco obj)
        {
            Categoria dom = this.mapConfig.Mapper.Map<Categoria>(obj);
            Categoria criado = this.repositorio.Add(dom);
            CategoriaPoco poco = this.mapConfig.Mapper.Map<CategoriaPoco>(criado);
            return poco;
        }

        public override CategoriaPoco Atualizar(CategoriaPoco obj)
        {
            Categoria dom = this.mapConfig.Mapper.Map<Categoria>(obj);
            Categoria atualizado = this.repositorio.Edit(dom);
            CategoriaPoco poco = this.mapConfig.Mapper.Map<CategoriaPoco>(atualizado);
            return poco;
        }

        public override CategoriaPoco Excluir(CategoriaPoco obj)
        {
            return this.Excluir(obj.Codigo);
        }

        public override CategoriaPoco Excluir(int id)
        {
            Categoria excluido = this.repositorio.DeleteById(id);
            CategoriaPoco poco = this.mapConfig.Mapper.Map<CategoriaPoco>(excluido);
            return poco;
        }
    }
}
