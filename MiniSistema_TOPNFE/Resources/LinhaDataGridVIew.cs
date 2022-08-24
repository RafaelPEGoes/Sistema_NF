using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSistema_TOPNFE.Resources
{
    public class LinhaDataGridVIew
    {
        private int idPedido;
        private string data;
        private int idCliente;
        private string nomeCliente;
        private int idProduto;
        private string nomeProduto;
        private double quantidade;
        private double preco;
        private double valorTotal;
        public LinhaDataGridVIew()
        {

        }

        public int GetIDPedido()
        {
            return this.idPedido;
        }
        
        public void SetIDPedido(int id)
        {
            this.idPedido = id;
        }
        public string GetData()
        {
            return this.data;
        }

        public void SetData(string data)
        {
            this.data = data;
        }

        public int GetIdCliente()
        {
            return this.idCliente;
        }

        public void SetIdCliente(int id)
        {
            this.idCliente = id;
        }
        public string GetNomeCliente()
        {
            return this.nomeCliente;
        }

        public void SetNomeCliente(string nome)
        {
            this.nomeCliente = nome;
        }

        public int GetIDProduto()
        {
            return this.idProduto;
        }

        public void SetIDProduto(int id)
        {
            this.idProduto = id;
        }

        public string GetNomeProduto()
        {
            return this.nomeProduto;
        }

        public void SetNomeProduto(string nome)
        {
            this.nomeProduto = nome;
        }

        public double GetQuantidade()
        {
            return this.quantidade;
        }

        public void SetQuantidade(double quantidade)
        {
            this.quantidade = quantidade;
        }

        public double GetPreco()
        {
            return this.preco;
        }

        public void SetPreco(double preco)
        {
            this.preco = preco;
        }

        public double GetValorTotal()
        {
            return this.quantidade * this.preco;
        }

        public void SetValorTotal(double valorTotal)
        {
            this.valorTotal = valorTotal;
        }
    }
}
