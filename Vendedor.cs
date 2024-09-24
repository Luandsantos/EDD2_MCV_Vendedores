using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Vendedor
    {
        private int id;
        private string nome;
        private double percComissao;
        private Venda[] asVendas = new Venda[31];

        public Vendedor(int id, string nome, double percComissao)
        {
            Id = id;
            Nome = nome;
            PercComissao = percComissao;
        }

        public Vendedor(int id, string nome, double percComissao, Venda[] asVendas)
        {
            Id = id;
            Nome = nome;
            PercComissao = percComissao;
            AsVendas = asVendas;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public double PercComissao { get => percComissao; set => percComissao = value; }
        internal Venda[] AsVendas { get => asVendas; set => asVendas = value; }

        public void registrarVenda(int dia, Venda venda)
        {
            if (dia >= 1 && dia <= 31) {
                asVendas[dia - 1] = venda; 
            }
        }

        public double valorVendas()
        {
            double total = 0;
            foreach (Venda venda in asVendas)
            {
                if (venda != null)
                {
                    total += venda.Valor;
                }
            }
            return total;
        }

        public double valorComissao()
        {
            return valorVendas() * (percComissao / 100);
        }

    }
}
