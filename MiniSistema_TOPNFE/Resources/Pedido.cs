using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSistema_TOPNFE.Resources
{
    class Pedido
    {
        private int idItem;
        private string nomeProduto;
        private double quantidade;
        private double valorUnitario;
        private double descontoUnitario;
        private double acrescimoUnitario;


        public int GetIdItem() => idItem;

        public void SetIdItem(int id) => this.idItem = id;
        public string GetNomeProduto() => nomeProduto;

        public void SetNomeProduto(string nome) => this.nomeProduto = nome; 
        public double GetQuantidade() => quantidade;

        public void SetQuantidade(int quantidade) => this.quantidade = quantidade;
        public double GetValorUnitario() => valorUnitario;

        public void SetValorUnitario(double valorUnitario) => this.valorUnitario = valorUnitario;

        public double GetDescontoUnitario() => descontoUnitario;

        public void SetDescontoUnitario(double descontoUnitario) => this.descontoUnitario = descontoUnitario;
        public double AcrescimoUnitario() => acrescimoUnitario;

        public void SetAcrescimoUnitario(double acrescimo) => this.acrescimoUnitario = acrescimo;

    }
}
