using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaProdutos lista = new ListaProdutos(2);

            int a = 1;

            while (a > 0) 
            {
                a = SelecionaOpcao(lista);
            }
        }

        private static int SelecionaOpcao(ListaProdutos lista)
        {
            Console.WriteLine("Menu:\na) Cadastrar produto\nb) Atualizar o preço de um produto" +
                "\nc) Imprimir o preço médio dos produtos\nd) Imprimir listagem de produtos");

            Console.WriteLine("Digite a letra do menu referente a funcionalidade desejada ou entre com 's' para sair:");

            char letra = Convert.ToChar(Console.ReadLine());

            switch (letra)
            {
                case 'a': 
                    CadastroProduto(lista); 
                    return 1;

                case 'b':
                    Console.Write("Entre com o código do produto a ser modificado: ");
                    var cod = Convert.ToInt32(Console.ReadLine());
                    lista.AtualizaPreco(cod);
                    return 1;

                case 'c':
                    lista.PrecoMedio();
                    return 1;

                case 'd':
                    lista.ImprimeLista();
                    return 1;

                case 's':
                    return 0;

                default:
                    Console.WriteLine("Ops... Opção inválida!");
                    return 1;
            }
        }

        public static void CadastroProduto(ListaProdutos lista)
        {
            Console.Write("Codigo do Produto: ");
            var codigo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Descricao: ");
            var descricao = Console.ReadLine();

            Console.Write("Preço: ");
            var preco = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Custo: ");
            var custo = Convert.ToDecimal(Console.ReadLine());

            Produto produto = new Produto(codigo, descricao, preco, custo);

            lista.AdicionaProduto(produto);
        }
    }
}
