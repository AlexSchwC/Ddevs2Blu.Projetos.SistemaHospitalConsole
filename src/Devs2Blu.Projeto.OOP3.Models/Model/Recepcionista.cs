using Devs2Blu.Projeto.OOP3.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.Projeto.OOP3.Models.Model
{
    public class Recepcionista : Pessoa
    {
        public Int32 CodigoRecepcionista { get; set; }
        public String Setor { get; set; }
        public Recepcionista()
        {
            TipoPessoa = TipoPessoa.PF;
        }
        public Recepcionista(Int32 codigo, String nome, String cpf, String setor)
        {
            TipoPessoa = TipoPessoa.PF;
            Codigo = codigo;
            Nome = nome;
            CGCCPF = cpf;
            Setor = setor;
            Random rd = new Random();
            CodigoRecepcionista = Int32.Parse($"{Codigo}{rd.Next(100, 999)}");
        }
    }
}
