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
    public class ProdutoService :  BaseAncestralService<ProdutoPoco, Produto>
    {
        private ProdutoRepository repositorio;

        public ProdutoService()
        {
            this.mapeador = new Mapper.Ancestral.MapeadorGenerico<ProdutoPoco, Produto>();
            this.repositorio = new ProdutoRepository(new AtacadoContext());
        }

        public ProdutoService(AtacadoContext contexto)
        {
            this.mapeador = new Mapper.Ancestral.MapeadorGenerico<ProdutoPoco, Produto>();
            this.repositorio = new ProdutoRepository(contexto);
        }

        public List<ProdutoPoco> Listar(int pular, int exibir)
        {
            List<Produto> listDOM = this.repositorio.Read(pular, exibir).ToList();
            return this.ProcessarListaDOM(listDOM);
        }

        protected override List<ProdutoPoco> ProcessarListaDOM(List<Produto> listDOM)
        {
            return listDOM.Select(dom => this.mapeador.Mecanismo.Map<ProdutoPoco>(dom)).ToList();
        }

        public List<ProdutoPoco> PesquisarPorSubcategoria(int idsub)
        {
            List<Produto> listDOM = this.repositorio.Browse(sub => sub.IdSubcategoria == idsub).ToList();
            return this.ProcessarListaDOM(listDOM);
        }

        public override ProdutoPoco Selecionar(int id)
        {
            Produto dom = this.repositorio.Read(id);
            ProdutoPoco poco = this.mapeador.Mecanismo.Map<ProdutoPoco>(dom);
            return poco;
        }

        public override ProdutoPoco Atualizar(ProdutoPoco obj)
        {
            Produto dom = this.mapeador.Mecanismo.Map<Produto>(obj);
            Produto alterado = this.repositorio.Edit(dom);
            ProdutoPoco poco = this.mapeador.Mecanismo.Map<ProdutoPoco>(alterado);
            return poco;
        }

        public override ProdutoPoco Criar(ProdutoPoco obj)
        {
            Produto dom = this.mapeador.Mecanismo.Map<Produto>(obj);
            Produto criado = this.repositorio.Add(dom);
            ProdutoPoco poco = this.mapeador.Mecanismo.Map<ProdutoPoco>(criado);
            return poco;
        }

        public override ProdutoPoco Excluir(int id)
        {
            Produto excluido = this.repositorio.DeleteById(id);
            ProdutoPoco poco = this.mapeador.Mecanismo.Map<ProdutoPoco>(excluido);
            return poco;
        }

        public override ProdutoPoco Excluir(ProdutoPoco obj)
        {
            return this.Excluir(obj.IdProduto);
        }
    }
}
