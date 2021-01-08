using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaConsoleApp
{
    public class ListaProdutos
    {
        private Produto[] _lista;
        private int _proximaPosicao;
        
        //construtor da classe
        public ListaProdutos(int capacidade = 100)
        {
            _lista = new Produto[capacidade];
            _proximaPosicao = 0;
        }
        public void AdicionaProduto(Produto produto)
        {
            var verificacao = VerificaCapacidade(_proximaPosicao + 1);

            if (verificacao)
            {
                _lista[_proximaPosicao] = produto;
                //Console.WriteLine($"Produto[{_proximaPosicao}] => " + _lista[_proximaPosicao]);

                _proximaPosicao++;
                //Console.WriteLine($"Proxima posicao: [{_proximaPosicao}]");
            }
            else
                Console.WriteLine("Não foi possível cadastrar o produto. Vetor cheio.");
        }

        private bool VerificaCapacidade(int indice)
        {
            return indice <= _lista.Length;
        }

        public void ImprimeLista()
        {
            foreach (var produto in _lista)
            {
                Console.WriteLine(produto);
            }
        }

        public Produto GetItemNoIndice(int indice)
        {
            return _lista[indice];
        }

        public void AtualizaPreco(int codigo)
        {
            foreach (var produto in _lista)
            {
                if(codigo == produto.Codigo)
                {
                    var preco = (double)produto.Preco;
                    var novoPreco = VariacaoPreco(preco);
                    produto.Preco = (decimal)novoPreco;
                    break;
                }
                else
                {
                    Console.WriteLine("Código do produto inexistente.");
                }
            }
        }

        private double VariacaoPreco(double preco)
        {
            //d para desconto a para acrescimo
            char letra;
            int variacao;
            Console.WriteLine("Desconto(d) ou Acrescimo(a)?");
            letra = Convert.ToChar(Console.ReadLine());
            if(letra == 'a' || letra == 'A')
            {
                Console.Write("Valor do Acrescimo (em porcentagem): ");
                variacao = Convert.ToInt32(Console.ReadLine());
                
                double setPreco = preco + preco*(variacao/100);
                
                return setPreco;
            }
            else
            {
                if (letra == 'd' || letra == 'D')
                {
                    Console.Write("Valor do Desconto (em porcentagem): ");
                    variacao = Convert.ToInt32(Console.ReadLine());
                    var setPreco = preco - preco * (variacao / 100);
                    return setPreco;
                }
                else
                {
                    return preco;
                }
            }
        }

        public void PrecoMedio()
        {
            decimal media;
            decimal acumulador = 0;
            int contador = 0;
            for (int i = 0; i < _lista.Length; i++)
            {
                acumulador += _lista[i].Preco;
                contador++;
            }
            media = acumulador / contador;

            Console.WriteLine($"Média de preços: {media:C2}");
        }
    }
}
