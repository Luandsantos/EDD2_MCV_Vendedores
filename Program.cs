using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            char continuar = 's';
            int opcao;

            Vendedores vendedores1 = new Vendedores(10); // max de vendedores 10, qtde inicial 0

            while (continuar == 's' || continuar == 'S')
            {
                Console.WriteLine("Escolha uma opção.");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Cadastrar Vendedor (máx. 10)");
                Console.WriteLine("2. Consultar Vendedor");
                Console.WriteLine("3. Excluir Vendedor");
                Console.WriteLine("4. Registrar venda");
                Console.WriteLine("5. Listar vendedores");

                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Finalizando o programa.");
                        continuar = 'n';
                        break;

                    case 1: // Cadastrar vendedor
                        if (vendedores1.Qtde == 10)
                        {
                            Console.WriteLine("Número máximo (10) de vendedores alcançado. Exclua um vendedor se quiser adicionar um novo.");
                        } else
                        {
                            Console.WriteLine("Cadastrando vendedor...\n");

                            Console.WriteLine("Digite o id do vendedor.");
                            int id = int.Parse(Console.ReadLine());

                            Console.WriteLine("Digite o nome do vendedor.");
                            string nome = Console.ReadLine();

                            Console.WriteLine("Digite a porcentagem de comissão do vendedor.");
                            double percComissao = double.Parse(Console.ReadLine());

                            Vendedor vendedor1 = new Vendedor(id, nome, percComissao);

                            if (vendedores1.addVendedor(vendedor1))
                            {
                                Console.WriteLine("Vendedor registrado. \n");
                                Console.WriteLine($"Quantidade de vendedeores atuais: {vendedores1.Qtde}");
                            }
                            else
                            {
                                Console.WriteLine("Falha ao registrar o vendedor \n.");
                                Console.WriteLine($"Quantidade de vendedeores atuais: {vendedores1.Qtde}");
                            }                        
                        }
                        break;

                    case 2: // Consultar vendedor
                        if (vendedores1.Qtde == 0)
                        {
                            Console.WriteLine("Nenhum vendedor está registrado. \n");
                            break;
                        }

                        Console.WriteLine("Qual o ID do vendedor que você quer consultar?");
                        int id_vendedor = int.Parse(Console.ReadLine());

                        Vendedor vendedorConsultado = vendedores1.searchVendedor(id_vendedor);

                        if (vendedorConsultado != null)
                        {
                            Console.WriteLine($"Vendedor de id {vendedorConsultado.Id}");
                            Console.WriteLine($"Nome: {vendedorConsultado.Nome}");
                            Console.WriteLine($"Porcentagem de comissão: {vendedorConsultado.PercComissao}%");

                            if (vendedorConsultado.valorVendas() > 0)
                            {
                                Console.WriteLine($"Valor total das vendas: R${vendedorConsultado.valorVendas()}");
                                Console.WriteLine($"Valor total da comissão: R${vendedorConsultado.valorComissao()}");

                                for (int k = 0; k < vendedorConsultado.AsVendas.Length; k++)
                                {
                                    if (vendedorConsultado.AsVendas[k] != null)
                                    {
                                        Console.WriteLine($"Dia {k + 1}: {vendedorConsultado.AsVendas[k].Qtde} vendas, " +
                                            $"valor médio: R${vendedorConsultado.AsVendas[k].valorMedio()}");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Esse vendedor não possui vendas registradas. \n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Vendedor não encontrado. \n");
                        }
                        break;

                    case 3: // excluir vendedor
                        Console.WriteLine("Excluindo vendedores...");
                        
                        if (vendedores1.Qtde == 0)
                        {
                            Console.WriteLine("Nenhum vendedor está registrado.");
                            break;
                        }

                        Console.WriteLine("Informe o ID do vendedor a ser excluído:");
                        int idExcluir = int.Parse(Console.ReadLine());

                        if (vendedores1.delVendedor(idExcluir))
                        {
                            Console.WriteLine("Vendedor excluído. \n");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível excluir o vendedor. \n");
                        }
                        break;

                    case 4: // registrar vendas
                        if (vendedores1.Qtde == 0)
                        {
                            Console.WriteLine("Nenhum vendedor está registrado.");
                            break;
                        }

                        Console.WriteLine("Registrando vendas...");

                        Console.WriteLine("Informe o ID do vendedor para registrar as vendas:");
                        int idVendedor = int.Parse(Console.ReadLine());
                        Vendedor vendedorSelecionado = null;

                        for (int i = 0; i < vendedores1.Qtde; i++)
                        {
                            if (vendedores1.OsVendedores[i].Id == idVendedor)
                            {
                                vendedorSelecionado = vendedores1.OsVendedores[i];
                                break;
                            }
                        }

                        if (vendedorSelecionado == null)
                        {
                            Console.WriteLine("Vendedor não encontrado.");
                            break;
                        }

                        Console.WriteLine("Informe o dia da venda (1 a 31):");
                        int diaVenda = int.Parse(Console.ReadLine());

                        Console.WriteLine("Informe a quantidade de vendas:");
                        int qtdeVendas = int.Parse(Console.ReadLine());

                        Console.WriteLine("Informe o valor da venda:");
                        double valorVenda = double.Parse(Console.ReadLine());

                        Venda novaVenda = new Venda(qtdeVendas, valorVenda);
                        vendedorSelecionado.registrarVenda(diaVenda, novaVenda);

                        Console.WriteLine("Venda registrada com sucesso \n.");
                        break;

                    case 5: // listar vendedores
                        Console.WriteLine("Listando vendededores... \n");
                        
                        for (int i = 0; i < vendedores1.Qtde; i++)
                        {
                                Console.WriteLine($"Quantidade de vendedeores atuais: {vendedores1.Qtde}");
                                Console.WriteLine($"Vendedor de id {vendedores1.OsVendedores[i].Id}");
                                Console.WriteLine($"Nome: {vendedores1.OsVendedores[i].Nome}");
                                Console.WriteLine($"Porcentagem de comissão: {vendedores1.OsVendedores[i].PercComissao}%");

                                if (vendedores1.OsVendedores[i].valorVendas() > 0)
                                {
                                    Console.WriteLine($"Valor total das vendas: R${vendedores1.OsVendedores[i].valorVendas()}");
                                    Console.WriteLine($"Valor total da comissão: R${vendedores1.OsVendedores[i].valorComissao()}");
                                }
                                else
                                {
                                    Console.WriteLine("Esse vendedor não possui vendas registradas. \n");
                                }
                            }

                            break;
                }
            }
        }
    }
}
