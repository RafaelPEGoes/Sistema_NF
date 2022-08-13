using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSistema_TOPNFE.Resources
{
    public class Produto
    {
        private int id;
        private long codDeBarras;
        private string referencia;
        private string nomeProduto;
        private double preco;

        public Produto()
        {

        }
        public Produto(int id, long codDeBarras, string referencia, string nomeProduto)
        {
            this.id = id;
            this.codDeBarras = codDeBarras;
            this.referencia = referencia;
            this.nomeProduto = nomeProduto;
        }


        public int GetID() => id;
        public long GetCOD() => codDeBarras;
        public string GetReferencia() => referencia;
        public string GetNomeProduto() => nomeProduto;

        public double GetPreco() => preco;
        public void SetID(int id) => this.id = id;

        public void SetCodDeBarras(long codDeBarras) => this.codDeBarras = codDeBarras;

        public void SetReferencia(string referencia) => this.referencia = referencia;

        public void SetNomeProduto(string nomeProduto) => this.nomeProduto = nomeProduto;

        public void SetPrecoProduto(double preco) => this.preco = preco;
    }


}
