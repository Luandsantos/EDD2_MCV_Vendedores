using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Venda
    {
        private int qtde;
        private double valor;

        public int Qtde
        {
            get => qtde;
            set => qtde = value;
        }
        public double Valor
        {
            get => valor;
            set => valor = value;
        }

        public Venda()
        {
            this.qtde = 0;
            this.valor = 0;
        }

        public Venda(int qtde, double valor)
        {
            this.qtde = qtde;
            this.valor = valor;
        }

        public double valorMedio()
        {
            if (qtde == 0)
            {
                return 0;
            } else
            {
                return valor / qtde;
            }
        }
    }
}
