using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Table;
using ShrAgropecuaria.Classes;
using ShrAgropecuaria.Repositorios.Interfaces;
using ShrAgropecuaria.Views.Pesquisas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShrAgropecuaria.Views
{
    public partial class view_PedidoNutrição : Form
    {
        public List<ProdutoPedidoNutricao> prodPedNutriList = new List<ProdutoPedidoNutricao>();

        public IClienteRepository ClienteRepository { get; }
        public IFazendaRepository FazendaRepository { get; }
        public IProdutoNutricao ProdutoNutricao { get; }
        public IPedidoNutricaoRepository PedidoNutricaoRepository { get; }
        public view_PedidoNutrição(IClienteRepository clienteRepository, IFazendaRepository fazendaRepository, IPedidoNutricaoRepository pedidoNutricaoRepository,
            IProdutoNutricao produtoNutricao)
        {
            InitializeComponent();
            PedidoNutricaoRepository = pedidoNutricaoRepository;
            ClienteRepository = clienteRepository;
            FazendaRepository = fazendaRepository;
            ProdutoNutricao = produtoNutricao;


            cbb_FormaPgto.Items.Add(15);
            cbb_FormaPgto.Items.Add(30);
            cbb_FormaPgto.Items.Add(60);
            cbb_FormaPgto.Items.Add(90);
            cbb_FormaPgto.SelectedIndex = 0;
            dataE.MinDate = DateTime.Now;
            txt_valorTotal.Text = "0";
            mask_porcentagem.Text = "5";
        }

        private void btn_pesqPedido_Click(object sender, EventArgs e)
        {
            var a = new PesquisaPedidoNutrição(PedidoNutricaoRepository);
            if (a.ShowDialog() == DialogResult.OK)
            {
                txt_codPedido.Text = a.pedNutri.Pn_cod.ToString();

                txt_idCli.Text = a.pedNutri.Cliente.Cli_cod.ToString();
                txt_nomeCliente.Text = a.pedNutri.ClienteNome;
                CarregaFazendas();
                cbb_Fazenda.SelectedItem = a.pedNutri.Fazenda.Faz_nome;

                txt_obs.Text = a.pedNutri.Pn_obs;
                txt_valorTotal.Text = a.pedNutri.Pn_valortotal.ToString();
                mask_telefone.Text = a.pedNutri.Pn_contato;
                mask_porcentagem.Text = a.pedNutri.Pn_porcentagem.ToString();
                cbb_FormaPgto.SelectedItem = a.pedNutri.Pn_formapgto;

                prodPedNutriList = PedidoNutricaoRepository.GetByProduto(txt_codPedido.Text).ToList();
                dataGridView1.DataSource = prodPedNutriList;
                ArrumaGrid();
            }
        }

        public void ArrumaGrid()
        {
            dataGridView1.Columns.Remove("PedidoNutricao");
            dataGridView1.Columns.Remove("ProdutoNutricao");
            dataGridView1.Columns.Remove("idPedNutri");
            dataGridView1.Columns.Remove("idProdNutri");
            dataGridView1.Columns["Ppn_quantidade"].HeaderText = "Quantidade";
            dataGridView1.Columns["Ppn_peso"].HeaderText = "Peso";
            dataGridView1.Columns["Ppn_valorvenda"].HeaderText = "Valor";
            dataGridView1.Columns["NomeProd"].HeaderText = "Nome do Produto";
        }

        public void CarregaFazendas()
        {
            List<Fazenda> fazendas = new List<Fazenda>();
            fazendas = FazendaRepository.GetByCliente(txt_idCli.Text).ToList();
            cbb_Fazenda.Items.Clear();
            foreach (var item in fazendas)
            {
                cbb_Fazenda.Items.Add(item.Faz_nome);
            }
            if (cbb_Fazenda.Items.Count > 0)
                cbb_Fazenda.SelectedIndex = 0;
        }

        private void btn_pesqCliente_Click(object sender, EventArgs e)
        {
            var a = new PesquisaCliente(ClienteRepository);
            if (a.ShowDialog() == DialogResult.OK)
            {
                txt_idCli.Text = a.cli.Cli_cod.ToString();
                txt_nomeCliente.Text = a.cli.Cli_nome;
                CarregaFazendas();
            }
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            var a = new PesquisaProdutoNutricao(ProdutoNutricao);
            if (a.ShowDialog() == DialogResult.OK)
            {
                ProdutoPedidoNutricao prodPedNutri = new ProdutoPedidoNutricao();
                prodPedNutri.ProdutoNutricao = a.Produto;
                prodPedNutri.PedidoNutricao = null;



                var b = new view_Quantidade();
                if (b.ShowDialog() == DialogResult.OK)
                {
                    bool achou = false;
                    foreach (var item in prodPedNutriList)
                    {
                        if (item.ProdutoNutricao.Prodn_cod == prodPedNutri.ProdutoNutricao.Prodn_cod)
                        {
                            item.Ppn_quantidade += b.quant;
                            item.Ppn_peso += b.quant * 20;
                            item.Ppn_valorvenda += b.quant * a.Produto.Prod_valorunitario;
                            //txt_valorTotal.Text = (Convert.ToDecimal(txt_valorTotal.Text) + item.Ppn_valorvenda).ToString();
                            achou = true;
                            break;
                        }
                    }

                    if (!achou)
                    {
                        prodPedNutri.Ppn_quantidade = b.quant;
                        prodPedNutri.Ppn_peso = b.quant * 20;
                        prodPedNutri.Ppn_valorvenda = b.quant * a.Produto.Prod_valorunitario;
                        //txt_valorTotal.Text = (Convert.ToDecimal(txt_valorTotal.Text) + prodPedNutri.Ppn_valorvenda).ToString();
                        prodPedNutriList.Add(prodPedNutri);
                    }

                    decimal val = 0;
                    foreach (var item in prodPedNutriList)
                    {
                        val += item.Ppn_valorvenda;
                    }
                    txt_valorTotal.Text = val.ToString();

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = prodPedNutriList;
                    ArrumaGrid();
                }
            }
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            LimparTudo();
        }

        public void LimparTudo()
        {
            txt_codPedido.Text = "";
            txt_idCli.Text = "";
            txt_nomeCliente.Text = "";
            txt_obs.Text = "";
            txt_valorTotal.Text = "0";
            mask_porcentagem.Text = "5";
            dataE.Value = DateTime.Now;
            mask_telefone.Text = "";
            cbb_FormaPgto.SelectedIndex = 0;
            cbb_Fazenda.Items.Clear();
            cbb_Fazenda.Text = "";
            dataGridView1.DataSource = null;
            prodPedNutriList = new List<ProdutoPedidoNutricao>();
            
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            PedidoNutricao pedNutri = new PedidoNutricao();
            if (txt_idCli.Text != "")
            {
                pedNutri.Cliente = ClienteRepository.Get(Convert.ToInt32(txt_idCli.Text));
                if (cbb_Fazenda.Items.Count > 0)
                {
                    pedNutri.Fazenda = FazendaRepository.GetByNome(cbb_Fazenda.SelectedItem.ToString()).First();
                    pedNutri.Pn_data = DateTime.Now;
                    pedNutri.Pn_obs = txt_obs.Text;
                    pedNutri.Pn_valortotal = Convert.ToDecimal(txt_valorTotal.Text);
                    pedNutri.Pn_previsaoentrega = dataE.Value.Date;
                    if (mask_telefone.Text.Length == 15)
                    {
                        pedNutri.Pn_contato = mask_telefone.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                        if (mask_porcentagem.Text != null)
                        {
                            pedNutri.Pn_porcentagem = Convert.ToInt32(mask_porcentagem.Text);
                            pedNutri.Pn_formapgto = Convert.ToInt32(cbb_FormaPgto.SelectedItem.ToString());

                            if (txt_codPedido.Text != "")
                            {
                                PedidoNutricaoRepository.DeletaProdutosPedido(Convert.ToInt32(txt_codPedido.Text));
                                pedNutri.Pn_cod = Convert.ToInt32(txt_codPedido.Text);
                            }

                            PedidoNutricaoRepository.GravarPedido(pedNutri);
                            txt_codPedido.Text = pedNutri.Pn_cod.ToString();
                            

                            foreach (var item in prodPedNutriList)
                            {
                                item.PedidoNutricao = pedNutri;
                                PedidoNutricaoRepository.GravarProdutoPedido(item);
                            }
                            MessageBox.Show("Gravado com Sucesso!");
                            GerarExcel(pedNutri);
                            LimparTudo();
                        }
                    }
                }
            }
        }

        private void mask_telefone_Click(object sender, EventArgs e)
        {
            string telefone = mask_telefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            if (telefone.Length > 0 && telefone.Length < 2)
                mask_telefone.Select(telefone.Length + 1, 0);
            else
                if (telefone.Length >= 2 && telefone.Length < 7)
                mask_telefone.Select(telefone.Length + 3, 0);
            else
                if (telefone.Length >= 7)
                mask_telefone.Select(telefone.Length + 4, 0);
            else
                mask_telefone.Select(1, 0);
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (txt_codPedido.Text != null)
            {
                if (DialogResult.Yes == MessageBox.Show("Deseja Excluir o Pedido?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    PedidoNutricaoRepository.Excluir(Convert.ToInt32(txt_codPedido.Text));
                    MessageBox.Show("Excluido com Sucesso!");
                    LimparTudo();
                }
            }
        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                prodPedNutriList.Remove(prodPedNutriList[dataGridView1.CurrentRow.Index]);

                decimal val = 0;
                foreach (var item in prodPedNutriList)
                {
                    val += item.Ppn_valorvenda;
                }
                txt_valorTotal.Text = val.ToString();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = prodPedNutriList;
                ArrumaGrid();
            }
        }

        private void mask_porcentagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void mask_porcentagem_KeyUp(object sender, KeyEventArgs e)
        {
            if (mask_porcentagem.Text == "0" || (mask_porcentagem.Text != "" && Convert.ToInt32(mask_porcentagem.Text) > 10))
            {
                mask_porcentagem.Text = "";
            }
        }

        private void mask_porcentagem_Click(object sender, EventArgs e)
        {
            string porcentagem = mask_porcentagem.Text.Replace(" ", "").Replace("_", "");
            if (porcentagem.Length > 0)
                mask_porcentagem.Select(porcentagem.Length, 0);
            else
                mask_porcentagem.Select(0, 0);
        }

        private void btn_GerarExcel_Click(object sender, EventArgs e)
        {
            
        }

        public void GerarExcel(PedidoNutricao pedNutri)
        {
            var package = new ExcelPackage();
            var workbook = package.Workbook;
            var sheet = workbook.Worksheets.Add("Pedido");

            {
                sheet.Cells.Style.Font.Name = "Times New Roman";
                sheet.Cells.Style.Font.Size = 12;
                sheet.Cells["I3"].Style.WrapText = true;
                sheet.Cells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                
            }

            {
                sheet.Cells["A1"].Value = "Informações do Pedido";
                sheet.Cells["A1"].Style.Font.Bold = true;
                sheet.Cells["A1"].Style.Font.Size = 26;
                sheet.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["A1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["A1:J1"].Merge = true;
                
                sheet.Cells["A2:J2"].Style.Font.Bold = true;

                sheet.Cells[2, 1].Value = "Código";
                sheet.Cells[2, 2].Value = "Nome do Cliente";
                sheet.Cells[2, 3].Value = "Fazenda do Cliente";
                sheet.Cells[2, 4].Value = "Data do Pedido";
                sheet.Cells[2, 5].Value = "Previsão de Entrega";
                sheet.Cells[2, 6].Value = "Contato";
                sheet.Cells[2, 7].Value = "Valor Total";
                sheet.Cells[2, 8].Value = "Porcentagem ";
                sheet.Cells[2, 9].Value = "Observação";
                sheet.Cells[2, 10].Value = "Forma de Pagamento";
                
                sheet.Cells[3, 1].Value = pedNutri.Pn_cod;
                sheet.Cells[3, 2].Value = pedNutri.ClienteNome;
                sheet.Cells[3, 3].Value = pedNutri.FazendaNome;
                sheet.Cells[3, 4].Value = pedNutri.Pn_data;
                sheet.Cells[3, 5].Value = pedNutri.Pn_previsaoentrega.Date.ToShortDateString();
                sheet.Cells[3, 6].Value = Convert.ToInt64(pedNutri.Pn_contato);
                sheet.Cells[3, 7].Value = pedNutri.Pn_valortotal;
                sheet.Cells[3, 8].Value = pedNutri.Pn_porcentagem / 100;
                sheet.Cells[3, 9].Value = pedNutri.Pn_obs;
                sheet.Cells[3, 10].Value = pedNutri.Pn_formapgto + " Dias";

                using (ExcelRange Rng = sheet.Cells["A2:J3"])
                {
                    ExcelTable table = sheet.Tables.Add(Rng, "infoPedido");
                    table.TableStyle = TableStyles.Dark2;
                    table.ShowHeader = true;
                    table.ShowFilter = false;
                }
            }

            {
                sheet.Cells["A5"].Value = "Informações Produto do Pedido";
                sheet.Cells["A5"].Style.Font.Bold = true;
                sheet.Cells["A5"].Style.Font.Size = 24;
                sheet.Cells["A5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["A5"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["A5:D5"].Merge = true;

                sheet.Cells[6, 1].Value = "Produto";
                sheet.Cells[6, 2].Value = "Quantidade";
                sheet.Cells[6, 3].Value = "Peso";
                sheet.Cells[6, 4].Value = "Valor Final do Produto";

                for (int i = 0, l = 7; i < prodPedNutriList.Count; i++, l++)
                {
                    sheet.Cells[l, 1].Value = prodPedNutriList[i].NomeProd;
                    sheet.Cells[l, 2].Value = prodPedNutriList[i].Ppn_quantidade + " Sacos";
                    sheet.Cells[l, 3].Value = prodPedNutriList[i].Ppn_peso + "Kg";
                    sheet.Cells[l, 4].Value = prodPedNutriList[i].Ppn_valorvenda;
                }

                string p = "A6:D" + (prodPedNutriList.Count + 6);
                using (ExcelRange Rng = sheet.Cells[p])
                {
                    ExcelTable table2 = sheet.Tables.Add(Rng, "infoProduto");
                    table2.TableStyle = TableStyles.Dark2;
                    table2.ShowHeader = true;
                    table2.ShowFilter = false;
                }
            }

            {
                //Image img = Image.FromFile(@".\logomarca.png");
                sheet.Cells["F3"].Style.Numberformat.Format = "0";
                sheet.Cells["H3"].Style.Numberformat.Format = "0%";
                sheet.Cells["D3"].Style.Numberformat.Format = "dd/MM/yyyy HH:mm";
                sheet.Cells["D7:D9"].Style.Numberformat.Format = "R$ #,##0.00";
                sheet.Cells["G3"].Style.Numberformat.Format = "R$ #,##0.00";

                sheet.Cells[sheet.Dimension.Address].AutoFitColumns();
                sheet.Column(9).Width = 32;

                {
                    string c = AppDomain.CurrentDomain.BaseDirectory;
                    c = c.Remove(c.Length - 10) + "Imagens\\";
                    Image img = Image.FromFile(c + "logomarca.png");
                    ExcelPicture pic = sheet.Drawings.AddPicture("Picture_Name", img);
                    pic.SetPosition(5, 0, 5, 0);
                }

                string caminho = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\FuncionaPoha.xlsx";
                package.SaveAs(new FileInfo(caminho));
            }
        }
    }
}
