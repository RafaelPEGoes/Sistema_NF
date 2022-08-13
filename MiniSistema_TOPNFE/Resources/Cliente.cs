using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSistema_TOPNFE.Resources
{
    public class Cliente 
    {
        private int id;
        private int cpf;
        private int cnpj;
        private string nomeCliente { get; set; }
        private string razaoSocial { get; set; }
        private string nomeFantasia { get; set; }
        private string endereco { get; set; }

        public Cliente()
        {
            
        }

        public Cliente(int id, int cpf, int cnpj, string nomeCliente, string razaoSocial, string nomeFantasia, string endereco)
        {
            this.id = id;
            this.cpf = cpf;
            this.cnpj = cnpj;
            this.nomeCliente = nomeCliente;
            this.razaoSocial = razaoSocial;
            this.nomeFantasia = nomeFantasia;
            this.endereco = endereco;
        }

        
    }
}
