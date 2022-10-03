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

            Console.WriteLine("| --- Cadastro de Médico, siga os passos a seguir:");

            do
            {
                nome = ValidacoesInputs.inputNotNullSRT("| Informe o nome completo do médico:");
            } while (ValidacoesInputs.validaNome(nome));

            do
            {
                cpf = ValidacoesInputs.inputNotNullSRT("| Informe o CPF do médico:");
            } while (!ValidacoesInputs.validaCPF(cpf));

            //Implementar uma validação de CRM depois...
            Int32.TryParse(ValidacoesInputs.inputNotNullSRT("| Informe o CRM (6 Dígitos):"), out crm);

            especialidade = ValidacoesInputs.inputNotNullSRT("| Qual a especialidade do médico ?");

            Medico novoMedico = new Medico(codigo, nome, cpf, crm, especialidade);

            CadastrarMedico(novoMedico);

            Console.WriteLine($"\n| Médico(a) {novoMedico.Nome} cadastrado(a) com sucesso!");
            Console.WriteLine("| Pressione qualquer tecla para continuar...");
            Console.ReadLine();
        }

        public void Alterar()
        {
            Medico medico;
            int codigoMedico;

            Console.Clear();

            ListarMedicosByCodeAndName();

            codigoMedico = ExistePessoaByCode();
            if (codigoMedico != (int)MenuGeralEnums.SAIR)
            {
            medico = Program.Mock.ListaMedicos.Find(p => p.CodigoMedico.Equals(codigoMedico));
            AlterarMedico(medico);
            };
        }

        public void Excluir()
        {
            Medico medico;
            int codigoMedico;

            Console.Clear();

            ListarMedicosByCodeAndName();

            codigoMedico = ExistePessoaByCode();
            if (codigoMedico != (int)MenuGeralEnums.SAIR)
            {
                medico = Program.Mock.ListaMedicos.Find(p => p.CodigoMedico.Equals(codigoMedico));
                ExcluirMedico(medico);
            }
        }

        public int ExistePessoaByCode()
        {
            Medico medico;
            int codigo;
            bool primeiraTentativa = true;

            Console.WriteLine("\n---");
            Console.WriteLine($"| Informe o código do médico que deseja alterar: ");
            Console.WriteLine("| Ou informe 0 para SAIR");

            do
            {
                if (primeiraTentativa.Equals(false)) { Console.WriteLine("| Informe um código válido!"); }

                Int32.TryParse(Console.ReadLine(), out codigo);
                medico = Program.Mock.ListaMedicos.Find(p => p.CodigoMedico.Equals(codigo));

                if (primeiraTentativa.Equals(true)) { primeiraTentativa = false; }
            } while (medico == null && codigo != 0);
            
            return codigo;
        }

        #region FACADE

        private void ListarMedicos()
        {
            Console.Clear();

            foreach (Medico medico in Program.Mock.ListaMedicos)
            {
                Console.WriteLine("==========\n");
                Console.WriteLine($"Codigo: {medico.CodigoMedico}");
                Console.WriteLine($"Nome: {medico.Nome}");
                Console.WriteLine($"CPF: {medico.CGCCPF}");
                Console.WriteLine($"CRM: {medico.CRM}");
                Console.WriteLine($"Especialidade: {medico.Especialidade}");
                Console.WriteLine("==========\n");
            }
            Console.WriteLine("| Pressione qualquer tecla para sair...");
            Console.ReadLine();
        }

        private void CadastrarMedico(Medico medico)
        {
            Program.Mock.ListaMedicos.Add(medico);
        }

        private void AlterarMedico(Medico medico)
        {
            Int32 opcao;
            do
            {
                Console.Clear();

                Console.WriteLine($"| Alteração de cadastro do médico:");
                Console.WriteLine($"| Nome: {medico.Nome} | CPF: {medico.CGCCPF} | Especialidade: {medico.Especialidade}");
                Console.WriteLine("| Selecione o campo que deseja alterar:");
                Console.WriteLine("| 1 - Nome | 2 - CPF | 3 - Especialidade");
                Console.WriteLine("| ---");
                Console.WriteLine("| 0 - Voltar");
                Int32.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("| Alterando Nome...");
                        do
                        {
                            medico.Nome = ValidacoesInputs.inputNotNullSRT("| Informe o novo nome:");
                        } while (ValidacoesInputs.validaNome(medico.Nome));
                        break;
                    case 2:
                        Console.WriteLine("| Alterando CPF...");
                        do
                        {
                            medico.CGCCPF = ValidacoesInputs.inputNotNullSRT("| Informe o novo CPF:");
                        } while (!ValidacoesInputs.validaCPF(medico.CGCCPF));
                        break;
                    case 3:
                        Console.WriteLine("| Alterando Especialidade...");
                        medico.Especialidade = ValidacoesInputs.inputNotNullSRT("| Informe a nova especialidade(s):");
                        break;
                    default:
                        if (!opcao.Equals(0)) Console.WriteLine("| Opção não existe, informe uma opção válida:");
                        break;
                }
            } while (!opcao.Equals(0));
        }

        private void ExcluirMedico(Medico medico)
        {
            Program.Mock.ListaMedicos.Remove(medico);
            Console.WriteLine($"| Médico {medico.Nome} exluído com sucesso!");
            Console.Write("\n| Pressione qualquer tecla para continuar...");
            Console.ReadLine();
        }

        #endregion

    }
}
