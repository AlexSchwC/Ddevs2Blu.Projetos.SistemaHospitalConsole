using Devs2Blu.Projeto.OOP3.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.Projeto.OOP3.Models.Model
{
    public class Paciente : Pessoa
    {
        public Int32 CodigoPaciente { get; set; }
        public String Convenio { get; set; }

        public Paciente()
        {
            TipoPessoa = TipoPessoa.PF;
        }
        public Paciente(Int32 codigo, String nome, String cpf, String convenio)
        {
            TipoPessoa = TipoPessoa.PF;
            Codigo = codigo;
            Nome = nome;
            CGCCPF = cpf;
            Convenio = convenio;
            Random rd = new Random();
            CodigoPaciente = Int32.Parse($"{Codigo}{rd.Next(100, 999)}");
        }
    }
}
