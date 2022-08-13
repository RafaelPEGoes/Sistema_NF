using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace MiniSistema_TOPNFE.Resources
{
    public partial class TesteImpressao : Form 
    {
        private int numeroImpressao = 1;
        public List<ProdutoPedido> lista;

        public void SetListaContent() 
        {
            ConsultaPedidosView cpv = new();

            lista = new List<ProdutoPedido>(cpv.ListaParaImpressao3());
        }
        
        public int GetNumeroImpressao()
        {
            return this.numeroImpressao;
        }

        public void IncrementaNumeroImpressao()
        {
            numeroImpressao++;
        }
        public TesteImpressao()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //MAXIMIZAR A TELA DE PREVIEW AO ABRIR

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument2;
            printPreviewDialog.Width = Screen.PrimaryScreen.Bounds.Width;
            printPreviewDialog.Height = Screen.PrimaryScreen.Bounds.Height;
            printPreviewDialog.Show();

            this.Hide();
        }

        public string[] textoCabecalho(string[] array)
        {

            //funcao para criar o texto de cabeçalho da impressão

            string[] texto = new string[4];

            texto[0] = "RAZÃO SOCIAL";
            texto[1] = "NOME FANTASIA";
            texto[2] = "ENDEREÇO";
            texto[3] = "CNPJ: 00.000.000 / 0000 - 00 IE: 0000000000";

            texto.CopyTo(array, 0);
            return array;
        }

        public Rectangle retanguloCabecalho()
        {
            int[] medidas = new int[4];
            medidas[0] = printDocument2.DefaultPageSettings.Bounds.X;
            medidas[1] = printDocument2.DefaultPageSettings.Bounds.Y;
            medidas[2] = printDocument2.DefaultPageSettings.Bounds.Width;
            medidas[3] = printDocument2.DefaultPageSettings.Bounds.Height;

            //ordem dos parâmetros: eixo X, eixo Y, comprimento, altura

            Rectangle retangulo = new Rectangle(medidas[0] + 50, medidas[1] + 50, medidas[2] - 100, medidas[3]);
            return retangulo;
        }

        public string[] colunasInformacaoPedido(string[] array)
        {
            string[] colunas = new string[6];
            colunas[0] = "#";
            colunas[1] = "ID";
            colunas[2] = "DESCRIÇÃO";
            colunas[3] = "QNT";
            colunas[4] = "VL. UNIT";
            colunas[5] = "VL ITEM";
            colunas.CopyTo(array, 0);
            return array;
        }

        public Rectangle desenhaRetanguloIndiceCodigo(Rectangle retanguloCabecalho)
        {
            int[] medidas = new int[4];

            medidas[0] = retanguloCabecalho.X;
            medidas[1] = retanguloCabecalho.Y;
            medidas[2] = (25 * (printDocument2.DefaultPageSettings.Bounds.Width - 100)) / 100;
            medidas[3] = printDocument2.DefaultPageSettings.Bounds.Height;

            Rectangle retangulo = new Rectangle(medidas[0], medidas[1], medidas[2], medidas[3]);
            return retangulo;
        }

        public Rectangle desenhaRetanguloProduto(Rectangle retanguloIndice)
        {
            int[] medidas = new int[4];

            medidas[0] = retanguloIndice.Width + 50;
            medidas[1] = retanguloIndice.Y;
            medidas[2] = (35 * (printDocument2.DefaultPageSettings.Bounds.Width - 100)) / 100;
            medidas[3] = printDocument2.DefaultPageSettings.Bounds.Height;

            Rectangle retangulo = new Rectangle(medidas[0], medidas[1], medidas[2], medidas[3]);
            return retangulo;
        }

        public void incrementaValorRetanguloNovaLinha(Rectangle ret1, Rectangle ret2, Rectangle ret3)
        {
            ret1.Y += 50;
            ret2.Y += 50;
            ret3.Y += 50;
        }

        public int SetIDParaImpressao(int id)
        {
            return id;
        }

        public Rectangle desenhaRetanguloQntValor(Rectangle retanguloProduto, Rectangle retanguloIndice)
        {
            int[] medidas = new int[4];
            //alterar aqui para ajustar a posicao do retangulo na tela
            //somar a width de retangulo produto + retangulo indicecodigo
            medidas[0] = retanguloProduto.Width + retanguloIndice.Width + 50;
            medidas[1] = retanguloProduto.Y;
            medidas[2] = (40 * (printDocument2.DefaultPageSettings.Bounds.Width - 100)) / 100;
            medidas[3] = printDocument2.DefaultPageSettings.Bounds.Height;

            Rectangle retangulo = new Rectangle(medidas[0], medidas[1], medidas[2], medidas[3]);
            return retangulo;
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            string[] arrayTextoCabecalho = new string[4];
            textoCabecalho(arrayTextoCabecalho);
            string[] itemsColuna = new string[6];
            colunasInformacaoPedido(itemsColuna);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            Brush brushVermelho = new SolidBrush(Color.Red);
            Brush brushAzul = new SolidBrush(Color.DarkCyan);
            Brush brush = new SolidBrush(Color.Black);
            Font fonteCabecalho = new Font("Times New Roman", 15, FontStyle.Bold, GraphicsUnit.Point);
            Font fontInformacoes = new Font("Times New Roman", 12, FontStyle.Regular);
            Rectangle retangulo = retanguloCabecalho();


            foreach (string itemArrayCabecalho in arrayTextoCabecalho)
            {
                e.Graphics.DrawString(itemArrayCabecalho.ToString(), fonteCabecalho, brush, retangulo, sf);
                retangulo.Y += 50;
                retangulo.Height += 50;

            }

            //e.Graphics.DrawRectangle(new Pen(brushAzul), retangulo);

            //e.Graphics.DrawRectangle(new Pen(brush), retanguloIndice);

            //MessageBox.Show(retanguloIndice.Width.ToString());
            //e.Graphics.DrawRectangle(new Pen(brushAzul), retanguloProduto);
            //MessageBox.Show(retanguloProduto.X.ToString());
            //e.Graphics.DrawRectangle(new Pen(brushVermelho), retanguloQntValor);
            e.Graphics.DrawLine(new Pen(brush), 50, retangulo.Y + 10, printDocument2.DefaultPageSettings.Bounds.Width - 50, retangulo.Y + 10);
            retangulo.Y += 50;
            e.Graphics.DrawString($"EXTRATO N: {GetNumeroImpressao()}", fonteCabecalho, brush, retangulo, sf);
            IncrementaNumeroImpressao();
            retangulo.Y += 50;
            e.Graphics.DrawLine(new Pen(brush), 50, retangulo.Y + 10, printDocument2.DefaultPageSettings.Bounds.Width - 50, retangulo.Y + 10);
            retangulo.Y += 50;

            Rectangle retanguloIndice = desenhaRetanguloIndiceCodigo(retangulo);
            Rectangle retanguloProduto = desenhaRetanguloProduto(retanguloIndice);
            Rectangle retanguloQntValor = desenhaRetanguloQntValor(retanguloProduto, retanguloIndice);

            for (int i = 0, countRetValor = 0, countRetIndice = 0; i < itemsColuna.Length; i++)
            {
                if (i != itemsColuna.Length - 1)
                {
                    if (i < 2)
                    {
                        e.Graphics.DrawString(itemsColuna[i].ToString(), fonteCabecalho, brush, retanguloIndice);
                        retanguloIndice.X += (30 * retanguloIndice.Width) / 100;
                        countRetIndice += (30 * retanguloIndice.Width) / 100;
                    }
                    else if (i == 2)
                    {

                        e.Graphics.DrawString(itemsColuna[i].ToString(), fonteCabecalho, brush, retanguloProduto);

                    }
                    else
                    {

                        e.Graphics.DrawString(itemsColuna[i].ToString(), fonteCabecalho, brush, retanguloQntValor);
                        retanguloQntValor.X += 33 * retanguloQntValor.Width / 100;
                        countRetValor += 33 * retanguloQntValor.Width / 100;

                    }
                }
                else
                {
                    e.Graphics.DrawString(itemsColuna[i].ToString(), fonteCabecalho, brush, retanguloQntValor);
                    retanguloIndice.X -= countRetIndice;
                    retanguloQntValor.X -= countRetValor;
                }


            }

            retanguloIndice.Y += 50;
            retanguloProduto.Y += 50;
            retanguloQntValor.Y += 50;

            //passar a lista da classe consultapedidosview como referencia para essa função
            //descobrir como diabos eu vo ufazer isso
            ConsultaPedidosView view = new ConsultaPedidosView();

            //List<ProdutoPedido> lista = new List<ProdutoPedido>();

            foreach(ProdutoPedido item in lista)
            {
                MessageBox.Show(item.ToString());
            }
            int indiceProduto = 1;

            foreach (ProdutoPedido produto in lista)
            {
                //IMPLEMENTAR 

                //ao inves de incrementar um valor específico no eixo X, somar a divisão de printDocument2.DefaultPageSettings.Bounds.X; pelo numero de colunas
                //dando espaçamento igual dentro dos limites da página:
                //printDocument2.DefaultPageSettings.Bounds.X / itemsColuna.Length;
                e.Graphics.DrawString(indiceProduto.ToString(), fontInformacoes, brush, retanguloIndice);
                retanguloIndice.X += 30 * retanguloIndice.Width / 100;
                e.Graphics.DrawString(produto.GetID().ToString(), fontInformacoes, brush, retanguloIndice);

                e.Graphics.DrawString(produto.GetNome(), fontInformacoes, brush, retanguloProduto);

                e.Graphics.DrawString(produto.GetQuantidade().ToString(), fontInformacoes, brush, retanguloQntValor);
                retanguloQntValor.X += 33 * retanguloQntValor.Width / 100;
                e.Graphics.DrawString(produto.GetPreco().ToString("C", CultureInfo.CurrentCulture), fontInformacoes, brush, retanguloQntValor);
                retanguloQntValor.X += 33 * retanguloQntValor.Width / 100;
                e.Graphics.DrawString(produto.GetValorTotal().ToString("C", CultureInfo.CurrentCulture), fontInformacoes, brush, retanguloQntValor);
                retangulo.Y += 50;
                retangulo.Height += 50;

                retanguloIndice.X -= 30 * retanguloIndice.Width / 100;
                retanguloIndice.Y += 50;
                retanguloProduto.Y += 50;
                retanguloQntValor.Y += 50;
                retanguloQntValor.X -= (33 * retanguloQntValor.Width / 100) * 2;
                incrementaValorRetanguloNovaLinha(retanguloIndice, retanguloProduto, retanguloQntValor);
                indiceProduto++;

            }

            //e.Graphics.DrawRectangle(new Pen(brush), retangulo);

        }

        public string GerarQueryParaImpressao(string opcao)
        {
            //implementar essa parte
            //sera passado como parametro para a funcao ListaParaImpressao, como a query a ser pesquisada

            string query = opcao switch
            {
                "porID" => $"SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO WHERE ID_PEDIDO = @ID_PEDIDO",
                "porCliente" => $"SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO WHERE NOME_CLIENTE = @NOME_CLIENTE",
                "porProduto" => $"SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO WHERE NOME_PRODUTO LIKE %@NOME_PRODUTO%",
                "porDataIni" => $"SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO WHERE DATA >= @DATA",
                "porDataFim" => $"SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO WHERE DATA <= @DATA",
                "porPeriodo" => $"SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO WHERE DATA BETWEEN @DATA AND @DATA ",
            };

            return query;
        }

        public List<ProdutoPedido> GerarNovaLista(List<ProdutoPedido> lista)
        {
            List<ProdutoPedido> listaProdutos = new List<ProdutoPedido>(lista);

            return listaProdutos;
        }

        public MySqlCommand GerarNovoComando(string query, MySqlConnection conn)
        {
            //adicionar o parâmetro da query

            MySqlCommand cmd = new MySqlCommand(query, conn);

            return cmd;
        }

        //public string textoInformativoDaQuery(int opcao)
        //{
        //    string texto = opcao switch
        //    {
        //        1 => "PEDIDOS COM ID";
        //        2 => "PEDIDOS POR CLIENTE";
        //        3 => "PEDIDOS POR PRODUTO";
        //        4 => "PEDIDOS A PARTIR DE";
        //        5 => "PEDIDOS ATÉ";
        //        _ => 
        //    };
        //}
        public List<ProdutoPedido> ListaParaImpressao3(List<ProdutoPedido> listaOriginal)
        {
            List < ProdutoPedido > lista = new List<ProdutoPedido>(listaOriginal);
            return lista;
        }


    }
    //public List<ProdutoPedido> ListaParaImpressao2(string str)
    //{
    //    List<ProdutoPedido> lista = new List<ProdutoPedido>();

    //    using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;database=test_minisistema_topnfe;uid=root;pwd=jujuba99;"))
    //    {
    //        string query = str;

    //        using (MySqlCommand cmd = new MySqlCommand(query, conn))
    //        {
    //            conn.Open();

    //            using (MySqlDataReader reader = cmd.ExecuteReader())
    //            {

    //                while (reader.Read())
    //                {

    //                    ProdutoPedido prod = new ProdutoPedido();

    //                    prod.SetID(Int32.Parse(reader.GetString(0)));
    //                    prod.SetNome(reader.GetString(1));
    //                    prod.SetQuantidade(Int32.Parse(reader.GetString(2)));
    //                    prod.SetPreco(Double.Parse(reader.GetString(3)));
    //                    prod.SetValorTotal(double.Parse(reader.GetString(4)));
    //                    lista.Add(prod);

    //                }

    //                conn.Close();

    //            }
    //        }
    //    }

    //    return lista;
    //}

    //public List<ProdutoPedido> ListaParaImpressao(int idPedido)
    //{
    //    List<ProdutoPedido> lista = new List<ProdutoPedido>();

    //    using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;database=test_minisistema_topnfe;uid=root;pwd=jujuba99;"))
    //    {
    //        string query = "SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO WHERE ID_PEDIDO = @ID_PEDIDO";

    //        using (MySqlCommand cmd = new MySqlCommand(query, conn))
    //        {
    //            conn.Open();
    //            cmd.Parameters.AddWithValue("@ID_PEDIDO", idPedido);

    //            using (MySqlDataReader reader = cmd.ExecuteReader())
    //            {

    //                while(reader.Read())
    //                {

    //                    ProdutoPedido prod = new ProdutoPedido();

    //                    prod.SetID(Int32.Parse(reader.GetString(0)));
    //                    prod.SetNome(reader.GetString(1));
    //                    prod.SetQuantidade(Int32.Parse(reader.GetString(2)));
    //                    prod.SetPreco(Double.Parse(reader.GetString(3)));
    //                    prod.SetValorTotal(double.Parse(reader.GetString(4)));
    //                    lista.Add(prod);

    //                }

    //                conn.Close();

    //            }
    //        }
    //    }

    //    return lista;
    //}




}



