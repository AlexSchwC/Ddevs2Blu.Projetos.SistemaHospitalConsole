using Devs2Blu.Projeto.OOP3.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.Projeto.OOP3.Models.Model
{
    public class Fornecedor : Pessoa
    {
        public Int32 CodigoFornecedor { get; set; }
        public String TipoFornecedor { get; set; }
        public Fornecedor()
        {
            TipoPessoa = TipoPessoa.PJ;
        }
        public Fornecedor(Int32 codigo, String nome, String cpf, String tipoFornecedor)
        {
            TipoPessoa = TipoPessoa.PJ;
            Codigo = codigo;
            Nome = nome;
            CGCCPF = cpf;
            TipoFornecedor = tipoFornecedor;
            Random rd = new Random();
            CodigoFornecedor = Int32.Parse($"{Codigo}{rd.Next(1000, 1100)}");
        }
    }
}
