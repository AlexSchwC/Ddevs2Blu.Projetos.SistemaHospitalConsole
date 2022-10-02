using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devs2Blu.Projeto.OOP3.Main.Cadastros.Interfaces;
using Devs2Blu.Projeto.OOP3.Main.Utils;
using Devs2Blu.Projeto.OOP3.Main.Utils.Enums;
using Devs2Blu.Projeto.OOP3.Models;
using Devs2Blu.Projeto.OOP3.Models.Model;

namespace Devs2Blu.Projeto.OOP3.Main.Cadastros
{
    public class CadastroPaciente : IMenuCadastro
    {
        public Int32 MenuCadastro()
        {
            Int32 opcao;
            Console.Clear();
            Console.WriteLine("| ---    Cadastros de Pacientes     --- |");
            Console.WriteLine("|=======================================|");
            Console.WriteLine("| --- 1 - Lista de Pacientes            |");
            Console.WriteLine("| --- 2 - Cadastrar Paciente            |");
            Console.WriteLine("| --- 3 - Alterar Cadastro Paciente     |");
            Console.WriteLine("| --- 4 - Excluir Paciente Cadastrado   |");
            Console.WriteLine("| ---                                   |");
            Console.WriteLine("| --- 0 - Voltar                        |");
            Int32.TryParse(Console.ReadLine(), out opcao);
            Console.Clear();
            return opcao;
        }

        public void Listar()
        {
            ListarPacientes();
        }

        private void ListarPacientesByCodeAndName()
        {
            Console.Clear();
            foreach (Paciente paciente in Program.Mock.ListaPacientes)
            {
                Console.WriteLine($"| Codigo: {paciente.CodigoPaciente} - Nome: {paciente.Nome}");
            }
        }

        public void Cadastrar()
        {
            Console.Clear();

            String nome, cpf, convenio;
            Int32 codigo = UtilsGerais.GeraRandomNum(10, 99);

            Console.WriteLine("| --- Cadastro de Paciente, siga os passos a seguir:     |");

            do
            {
                nome = ValidacoesInputs.inputNotNullSRT("| Informe o nome completo do Paciente:                   |");
            } while (ValidacoesInputs.validaNome(nome));

            do
            {
                cpf = ValidacoesInputs.inputNotNullSRT("| Informe o CPF do Paciente:                             |");
            } while (ValidacoesInputs.validaCPF(cpf));

            convenio = ValidacoesInputs.inputNotNullSRT("| Qual o convênio do paciente ?                          |");

            Paciente novoPaciente = new Paciente(codigo, nome, cpf, convenio);

            CadastrarPaciente(novoPaciente);
        }

        public void Alterar()
        {
            Paciente paciente;
            int codigoPaciente;

            Console.Clear();

            ListarPacientesByCodeAndName();

            // Esse trecho abaixo se repete ainda na função Excluir() também. Poderia melhorar (talvez).
            codigoPaciente = ExistePessoaByCode();
            paciente = Program.Mock.ListaPacientes.Find(p => p.CodigoPaciente.Equals(codigoPaciente));

            AlterarPaciente(paciente);
        }

        public void Excluir()
        {
            Paciente paciente;
            int codigoPaciente;

            Console.Clear();

            ListarPacientesByCodeAndName();

            codigoPaciente = ExistePessoaByCode();
            paciente = Program.Mock.ListaPacientes.Find(p => p.CodigoPaciente.Equals(codigoPaciente));

            ExcluirPaciente(paciente);
        }

        public int ExistePessoaByCode()
        {
            Paciente paciente;
            int codigo;
            bool primeiraTentativa = true;

            Console.WriteLine("\n---");
            Console.WriteLine($"| Informe o código do paciente que deseja alterar: ");

            do
            {
                if (primeiraTentativa.Equals(false))
                {
                    Console.WriteLine("| Informe um código válido!");
                }
                Int32.TryParse(Console.ReadLine(), out codigo);
                paciente = Program.Mock.ListaPacientes.Find(p => p.CodigoPaciente.Equals(codigo));
                if (primeiraTentativa.Equals(true)) primeiraTentativa = false;
            } while (paciente == null);
            return codigo;
        }

        #region FACADE

        private void ListarPacientes()
        {
            Console.Clear();

            foreach (Paciente paciente in Program.Mock.ListaPacientes)
            {
                Console.WriteLine("==========");
                Console.WriteLine($"| Codigo: {paciente.CodigoPaciente}");
                Console.WriteLine($"| Nome: {paciente.Nome}");
                Console.WriteLine($"| CPF: {paciente.CGCCPF}");
                Console.WriteLine($"| Convenio: {paciente.Convenio}");
                Console.WriteLine("==========\n");
            }
            Console.Write("| Pressione qualquer tecla para voltar...");
            Console.ReadLine();
        }

        private void CadastrarPaciente(Paciente paciente)
        {
            Program.Mock.ListaPacientes.Add(paciente);
        }

        private void AlterarPaciente(Paciente paciente)
        {
            Int32 opcao;
            do
            {
                Console.Clear();

                Console.WriteLine($"| Alteração de cadastro do paciente:");
                Console.WriteLine($"| Nome: {paciente.Nome} | CPF: {paciente.CGCCPF} | Convênio: {paciente.Convenio} |");
                Console.WriteLine("| Selecione o campo que deseja alterar:");
                Console.WriteLine("| 1 - Nome | 2 - CPF | 3 - Convênio |");
                Console.WriteLine("| ---");
                Console.WriteLine("| 0 - Voltar");
                Int32.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("| Alterando Nome...");
                        do
                        {
                            paciente.Nome = ValidacoesInputs.inputNotNullSRT("| Informe o novo nome:");
                        } while (ValidacoesInputs.validaNome(paciente.Nome));
                        break;
                    case 2:
                        Console.WriteLine("| Alterando CPF...");
                        do
                        {
                            paciente.CGCCPF = ValidacoesInputs.inputNotNullSRT("| Informe o novo CPF:");
                        } while (ValidacoesInputs.validaCPF(paciente.CGCCPF));
                        break;
                    case 3:
                        Console.WriteLine("| Alterando Convênio...");
                        paciente.Convenio = ValidacoesInputs.inputNotNullSRT("| Informe o novo convênio:");
                        break;
                    default:
                        if (!opcao.Equals(0)) Console.WriteLine("| Opção não existe, informe uma opção válida:");
                        break;
                }
            } while (!opcao.Equals(0));
            
        }

        private void ExcluirPaciente(Paciente paciente)
        {
            Program.Mock.ListaPacientes.Remove(paciente);
            Console.WriteLine($"| Paciente {paciente.Nome} exluído com sucesso!");
            Console.Write("\n| Pressione qualquer tecla para continuar...");
            Console.ReadLine();
        }

        #endregion

    }
}
