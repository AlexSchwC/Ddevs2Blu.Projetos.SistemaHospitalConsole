using Devs2Blu.Projeto.OOP3.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.Projeto.OOP3.Models.Model
{
    public class Medico : Pessoa
    {
        public Int32 CodigoMedico { get; set; }
        public Int32 CRM { get; set; }
        public String Especialidade { get; set; }
        public Medico()
        {
            TipoPessoa = TipoPessoa.PF;
        }
        public Medico(Int32 codigo, String nome, String cpf, Int32 crm, String especialidade)
        {
            TipoPessoa = TipoPessoa.PF;
            Codigo = codigo;
            Nome = nome;
            CGCCPF = cpf;
            CRM = crm;
            Especialidade = especialidade;
            Random rd = new Random();
            CodigoMedico = Int32.Parse($"{Codigo}{rd.Next(100, 999)}");
        }
    }
}
