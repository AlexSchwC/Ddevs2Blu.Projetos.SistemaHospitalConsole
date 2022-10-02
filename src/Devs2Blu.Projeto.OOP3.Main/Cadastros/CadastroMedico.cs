using Devs2Blu.Projeto.OOP3.Main.Utils.Enums;
using Devs2Blu.Projeto.OOP3.Main.Utils;
using Devs2Blu.Projeto.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devs2Blu.Projeto.OOP3.Main.Cadastros.Interfaces;
using Devs2Blu.Projeto.OOP3.Models;

namespace Devs2Blu.Projeto.OOP3.Main.Cadastros
{
    public class CadastroMedico : IMenuCadastro
    {
        public Int32 MenuCadastro()
        {
            Int32 opcao;
            Console.Clear();
            Console.WriteLine("| ---     Cadastros de Médicos      --- |");
            Console.WriteLine("|=======================================|");
            Console.WriteLine("| --- 1 - Lista de Médicos              |");
            Console.WriteLine("| --- 2 - Cadastrar Médico              |");
            Console.WriteLine("| --- 3 - Alterar Cadastro Médico       |");
            Console.WriteLine("| --- 4 - Excluir Médico Cadastrado     |");
            Console.WriteLine("| ---                                   |");
            Console.WriteLine("| --- 0 - Voltar                        |");
            Int32.TryParse(Console.ReadLine(), out opcao);
            Console.Clear();
            return opcao;
        }

        public void Listar()
        {
            ListarMedicos();
        }

        private void ListarMedicosByCodeAndName()
        {
            Console.Clear();
            foreach (Medico medico in Program.Mock.ListaMedicos)
            {
                Console.WriteLine($"| Codigo: {medico.CodigoMedico} - Nome: {medico.Nome} - CRM: {medico.CRM} ");
            }
        }

        public void Cadastrar()
        {
            Console.Clear();

            String nome, cpf, especialidade;
            Int32 crm;
            Int32 codigo = UtilsGerais.GeraRandomNum(10, 99);

            Console.WriteLine("| --- Cadastro de Médico, siga os passos a seguir:     |");

            do
            {
                nome = ValidacoesInputs.inputNotNullSRT("| Informe o nome completo do médico:                   |");
            } while (ValidacoesInputs.validaNome(nome));

            do
            {
                cpf = ValidacoesInputs.inputNotNullSRT("| Informe o CPF do médico:                             |");
            } while (ValidacoesInputs.validaCPF(cpf));

            Int32.TryParse(ValidacoesInputs.inputNotNullSRT("| Informe o CRM:"), out crm);

            especialidade = ValidacoesInputs.inputNotNullSRT("| Qual a especialidade do médico ?                          |");

            Medico novoMedico = new Medico(codigo, nome, cpf, crm, especialidade);

            CadastrarMedico(novoMedico);
        }

        public void Alterar()
        {
            Medico medico = new Medico();
            AlterarMedico(medico);
        }

        public void Excluir()
        {
            Medico medico = new Medico();
            ExcluirMedico(medico);
        }

        public int ExistePessoaByCode()
        {
            Medico medico;
            int codigo;
            bool primeiraTentativa = true;

            Console.WriteLine("\n---");
            Console.WriteLine($"| Informe o código do médico que deseja alterar: ");

            do
            {
                if (primeiraTentativa.Equals(false))
                {
                    Console.WriteLine("| Informe um código válido!");
                }
                Int32.TryParse(Console.ReadLine(), out codigo);
                medico = Program.Mock.ListaMedicos.Find(p => p.CodigoMedico.Equals(codigo));
                if (primeiraTentativa.Equals(true)) primeiraTentativa = false;
            } while (medico == null);
            return codigo;
        }

        #region FACADE

        private void ListarMedicos()
            {
                Console.Clear();

                foreach (Medico medico in Program.Mock.ListaMedicos)
                {
                    Console.WriteLine("-----");
                    Console.WriteLine($"Codigo: {medico.CodigoMedico}");
                    Console.WriteLine($"Nome: {medico.Nome}");
                    Console.WriteLine($"CPF: {medico.CGCCPF}");
                    Console.WriteLine($"CRM: {medico.CRM}");
                    Console.WriteLine($"Especialidade: {medico.Especialidade}");
                    Console.WriteLine("-----\n");
                }
            }

        private void CadastrarMedico(Pessoa pessoa)
        {
            Console.Clear();
            String nome, cpf, especialidade;
            Int32 codigo = UtilsGerais.GeraRandomNum(10, 99);
            Int32 crm;

            Console.WriteLine("| --- Cadastro de Medico, siga os passos a seguir: ---");
            Console.WriteLine("| Informe o nome completo do Médico:");
            nome = Console.ReadLine();
            Console.WriteLine("| Informe o CPF do Médico:");
            cpf = Console.ReadLine();
            Console.WriteLine("| Informe o CRM do Médico:");
            Int32.TryParse(Console.ReadLine(), out crm);
            Console.WriteLine("| Informe a especialidade:");
            especialidade = Console.ReadLine();

            Medico novoMedico = new Medico(codigo, nome, cpf, crm, especialidade);

            Program.Mock.ListaMedicos.Add(novoMedico);
        }

        private void AlterarMedico(Pessoa pessoa)
        {

        }

        private void ExcluirMedico(Pessoa pessoa)
        {

        }

        #endregion

    }
}
