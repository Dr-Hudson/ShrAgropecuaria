using ShrAgropecuaria.Repositorios.Interfaces;
using ShrAgropecuaria.Repositorios.MySqlRepository;
using ShrAgropecuaria.Views;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ShrAgropecuaria.Views.Pesquisas;

namespace ShrAgropecuaria.Classes
{
    class Dependencia
    {
        public static SimpleInjector.Container Container { get; set; } = new SimpleInjector.Container();

        static Dependencia()
        {
            Dependencia.Container.Options.DefaultLifestyle = Lifestyle.Transient;
            Dependencia.Container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
        }

        public static void Configurar()
        {
            Container.Register<IDbConnection>(Connection.GetConnection, Lifestyle.Scoped);
            Container.Register<ICidadeRepository, MySqlCidadeRepository>(Lifestyle.Scoped);
            Container.Register<IFornecedorRepository, MySqlFornecedorRepository>(Lifestyle.Scoped);
            Container.Register<IClienteRepository, MySqlClienteRepository>(Lifestyle.Scoped);
            Container.Register<IUsuarioRepository, MySqlUsuarioRepository>(Lifestyle.Scoped);
            Container.Register<ICategoriaProdutoPET, MySqlCategoriaProdutoPET>(Lifestyle.Scoped);
            Container.Register<IProdutoPET, MySqlProdutoPET>(Lifestyle.Scoped);
            Container.Register<IProdutoNutricao, MySqlProdutoNutricaoRepository>(Lifestyle.Scoped);
            Container.Register<IParametrizacaoRepository, MySqlParametrizacaoRepository>(Lifestyle.Scoped);
            Container.Register<IFiadoRepository, MySqlFiadoRepository>(Lifestyle.Scoped);

            Container.Register<IFazendaRepository, MySqlFazendaRepository>(Lifestyle.Scoped);

            Container.Register<PesquisaCategoria>();
            Container.Register<PesquisaProdutoPET>();
            Container.Register<view_Fornecedor>();
            Container.Register<view_ProdutoPET>();
            Container.Register<Views.View_Cliente>();
            Container.Register<PesquisaCidade>();
            Container.Register<PesquisaFornecedor>();
            Container.Register<view_Login>();
            Container.Register<Views.view_Usuario>();
            Container.Register<view_ProdutoNutrição>();
            Container.Register<view_Parametrização>();
            Container.Register<view_Fiado>();
            Container.Register<view_ControlarEntregaPedidoNutrição>();
        }
    }
}
