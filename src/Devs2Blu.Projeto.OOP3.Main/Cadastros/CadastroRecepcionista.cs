using Devs2Blu.Projeto.OOP3.Main.Utils.Enums;
using Devs2Blu.Projeto.OOP3.Main.Utils;
using Devs2Blu.Projeto.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devs2Blu.Projeto.OOP3.Main.Cadastros.Interfaces;

namespace Devs2Blu.Projeto.OOP3.Main.Cadastros
{
    public class CadastroRecepcionista : IMenuCadastro
    {
        public Int32 MenuCadastro()
        {
            int opcao;
            Console.Clear();
            Console.WriteLine("| ---     Cadastros de Recepcionistas      --- |");
            Console.WriteLine("|==============================================|");
            Console.WriteLine("| --- 1 - Lista de Recepcionistas              |");
            Console.WriteLine("| --- 2 - Cadastrar Recepcionistas             |");
            Console.WriteLine("| --- 3 - Alterar Cadastro Recepcionista       |");
            Console.WriteLine("| --- 4 - Excluir Recepcionista Cadastrada     |");
            Console.WriteLine("| ---                                          |");
            Console.WriteLine("| --- 0 - Voltar / Sair                        |");
            Int32.TryParse(Console.ReadLine(), out opcao);
            Console.Clear();
            return opcao;
        }

        public void Listar()
        {
            ListarRecepcionistas();
        }

        private void ListarRecepcionistasByCodeAndName()
        {
            Console.Clear();
            foreach (Recepcionista recepcionista in Program.Mock.ListaRecepcionistas)
            { 
                Console.WriteLine($"| Codigo: {recepcionista.CodigoRecepcionista} - Nome: {recepcionista.Nome}");
            }
        }

        public void Cadastrar()
        {
            Console.Clear();

            String nome, cpf, setor;
            Int32 codigo = UtilsGerais.GeraRandomNum(10, 99);

            Console.WriteLine("| --- Cadastro de Recepcionista, siga os passos a seguir:");

            do
            {
                nome = ValidacoesInputs.inputNotNullSRT("| Informe o nome completo do(a) Recepcionista:");
            } while (ValidacoesInputs.validaNome(nome));

            do
            {
                cpf = ValidacoesInputs.inputNotNullSRT("| Informe o CPF do(a) Recepcionista:");
            } while (!ValidacoesInputs.validaCPF(cpf));
            cpf = UtilsGerais.PadronizaCPF(cpf);

            setor = ValidacoesInputs.inputNotNullSRT("| Qual o setor do(a) Recepcionista?");

            Recepcionista novoRecepcionista = new Recepcionista(codigo, nome, cpf, setor);

            CadastrarRecepcionista(novoRecepcionista);

            Console.WriteLine($"\n| Recepcionista {novoRecepcionista.Nome} cadastrado(a) com sucesso!");
            Console.WriteLine("| Pressione qualquer tecla para continuar...");
            Console.ReadLine();
        }

        public void Alterar()
        {
            Recepcionista recepcionista;
            int codigoRecepcionista;

            Console.Clear();

            ListarRecepcionistasByCodeAndName();

            codigoRecepcionista = ExistePessoaByCode();
            if (codigoRecepcionista != (int)MenuGeralEnums.SAIR)
            {
                recepcionista = Program.Mock.ListaRecepcionistas.Find(p => p.CodigoRecepcionista.Equals(codigoRecepcionista));
                AlterarRecepcionista(recepcionista);
            }
        }

        public void Excluir()
        {
            Recepcionista recepcionista;
            int codigoRecepcionista;

            Console.Clear();

            ListarRecepcionistasByCodeAndName();

            codigoRecepcionista = ExistePessoaByCode();
            if (codigoRecepcionista != (int)MenuGeralEnums.SAIR)
            {
                recepcionista = Program.Mock.ListaRecepcionistas.Find(p => p.CodigoRecepcionista.Equals(codigoRecepcionista));
                ExcluirRecepcionista(recepcionista);
            }
        }

        public int ExistePessoaByCode()
        {
            Recepcionista recepcionista;
            int codigo;
            bool primeiraTentativa = true;

            Console.WriteLine("\n---");
            Console.WriteLine($"| Informe o código do(a) recepcionista que deseja alterar: ");

            do
            {
                if (primeiraTentativa.Equals(false)) { Console.WriteLine("| Informe um código válido!"); }
                    
                Int32.TryParse(Console.ReadLine(), out codigo);
                recepcionista = Program.Mock.ListaRecepcionistas.Find(p => p.CodigoRecepcionista.Equals(codigo));

                if (primeiraTentativa.Equals(true)) { primeiraTentativa = false; }
            } while (recepcionista == null && codigo != 0);
            return codigo;
        }

        #region FACADE 

        static void ListarRecepcionistas()
        {
            Console.Clear();
            foreach (Recepcionista recepcionista in Program.Mock.ListaRecepcionistas)
            {
                Console.WriteLine("==========");
                Console.WriteLine($"Codigo: {recepcionista.CodigoRecepcionista}");
                Console.WriteLine($"Nome: {recepcionista.Nome}");
                Console.WriteLine($"CPF: {recepcionista.CGCCPF}");
                Console.WriteLine($"Setor: {recepcionista.Setor}");
                Console.WriteLine("==========");
            }
            Console.Write("| Pressione qualquer tecla para voltar...");
            Console.ReadLine();
        }

        static void CadastrarRecepcionista(Recepcionista recepcionista)
        {
            Program.Mock.ListaRecepcionistas.Add(recepcionista);
        }

        static void AlterarRecepcionista(Recepcionista recepcionista)
        {
            Int32 opcao;
            do
            {
                Console.Clear();

                Console.WriteLine($"| Alteração de cadastro de recepcionista:");
                Console.WriteLine($"| Nome: {recepcionista.Nome} | CPF: {recepcionista.CGCCPF} | Setor: {recepcionista.Setor} |");
                Console.WriteLine("| Selecione o campo que deseja alterar:");
                Console.WriteLine("| 1 - Nome | 2 - CPF | 3 - Setor |");
                Console.WriteLine("| ---");
                Console.WriteLine("| 0 - Voltar");
                Int32.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("| Alterando Nome...");
                        do
                        {
                            recepcionista.Nome = ValidacoesInputs.inputNotNullSRT("| Informe o novo nome:");
                        } while (ValidacoesInputs.validaNome(recepcionista.Nome));
                        break;
                    case 2:
                        Console.WriteLine("| Alterando CPF...");
                        do
                        {
                            recepcionista.CGCCPF = ValidacoesInputs.inputNotNullSRT("| Informe o novo CPF:");
                        } while (!ValidacoesInputs.validaCPF(recepcionista.CGCCPF));
                        recepcionista.CGCCPF = UtilsGerais.PadronizaCPF(recepcionista.CGCCPF);
                        break;
                    case 3:
                        Console.WriteLine("| Alterando Setor...");
                        recepcionista.Setor = ValidacoesInputs.inputNotNullSRT("| Informe o novo setor:");
                        break;
                    default:
                        if (!opcao.Equals(0)) Console.WriteLine("| Opção não existe, informe uma opção válida:");
                        break;
                }
            } while (!opcao.Equals(0));
        }

        static void ExcluirRecepcionista(Recepcionista recepcionista)
        {
            Program.Mock.ListaRecepcionistas.Remove(recepcionista);
            Console.WriteLine($"| Paciente {recepcionista.Nome} exluído com sucesso!");
            Console.Write("\n| Pressione qualquer tecla para continuar...");
            Console.ReadLine();
        }

        #endregion
    }
}
