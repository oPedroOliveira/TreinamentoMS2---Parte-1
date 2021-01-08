using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaConsoleApp
{
    public class Produto
    {
        private int _codigo;
        public int Codigo { get { return _codigo; } set { _codigo = value; } }
        
        private string _descricao;
        public string Descricao { get { return _descricao; } set { _descricao = value; } }
        
        private decimal _preco;
        public decimal Preco { get { return _preco; } set { _preco = value;}}

        private decimal _custo;
        public decimal Custo { get { return _custo;} set { _custo = value;} }
        
        public decimal Lucro { get { return _preco - _custo; } }

        public Produto(int codigo, string descricao, decimal preco, decimal custo)
        {
            Codigo = codigo;
            Descricao = descricao;
            Preco = preco;
            Custo = custo;
        }
        public Produto()
        {

        }

        public override string ToString()
        {
            return $"Código: {Codigo} - Descrição: {Descricao} - Preco: {Preco:C2} - Custo: {Custo:C2} - Lucro: {Lucro:C2}";
        }
    }
}
