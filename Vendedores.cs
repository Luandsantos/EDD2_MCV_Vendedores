using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Vendedores
    {
        private Vendedor[] osVendedores;
        private int max;
        private int qtde;

        public Vendedores(int max)
        {
            this.max = max;
            qtde = 0;
            osVendedores = new Vendedor[max];
        }

        internal Vendedor[] OsVendedores { get => osVendedores; set => osVendedores = value; }
        public int Max { get => max; }
        public int Qtde { get => qtde; }

        public bool addVendedor(Vendedor v)
        {
            if (Qtde < Max)
            {
                osVendedores[Qtde] = v;
                qtde++;
                return true;
            }
            else
            {
                Console.WriteLine("Número máximo de vendedores atingido.");
                return false;
            }
        }

        public bool delVendedor(int id)
        {
            for (int i = 0; i < qtde; i++)
            {
                if (osVendedores[i].Id == id)
                {
                    if (osVendedores[i].valorVendas() == 0)
                    {
                        for (int j = i; j < qtde - 1; j++)
                        {
                            osVendedores[j] = osVendedores[j + 1];
                        }
                        osVendedores[qtde - 1] = null;
                        qtde--;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("O vendedor possui vendas registradas e não pode ser excluído.");
                        return false;
                    }
                }
            }
            Console.WriteLine("Vendedor não encontrado.");
            return false;
        }

        public Vendedor searchVendedor(int id)
        {
            for (int i = 0; i < qtde; i++)
            {
                if (osVendedores[i].Id == id)
                {
                    return osVendedores[i];
                }
            }
            return null; 
        }

        public double valorVendas()
        {
            double total = 0;
            for (int i = 0; i < qtde; i++)
            {
                total += osVendedores[i].valorVendas();
            }
            return total;
        }

        public double valorComissao()
        {
            double totalComissao = 0;
            for (int i = 0; i < qtde; i++)
            {
                totalComissao += osVendedores[i].valorComissao();
            }
            return totalComissao;
        }
    }
}
