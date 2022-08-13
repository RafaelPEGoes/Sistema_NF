using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSistema_TOPNFE.Resources
{
    public class ProdutoPedido
    {
        private int id { get; set; }
        private string nome { get; set; }
        private int quantidade { get; set; }
        private double preco { get; set; }
        private double valorTotal { get; set; }

        public int GetID()
        {
            return this.id;
        }
        public void SetID(int id)
        {
            this.id = id;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public string GetNome()
        {
            return this.nome;
        }

        public void SetQuantidade(int quantidade)
        {
            this.quantidade = quantidade;
        }

        public int GetQuantidade()
        {
            return this.quantidade;
        }
        public void SetPreco(double preco)
        {
            this.preco = preco;
        }
        
        public double GetPreco()
        {
            return this.preco;
        }
        public void SetValorTotal(double valorTotal)
        {
            this.valorTotal = valorTotal;
        }

        public double GetValorTotal()
        {
            return this.quantidade * this.preco;
        }



    }
}
