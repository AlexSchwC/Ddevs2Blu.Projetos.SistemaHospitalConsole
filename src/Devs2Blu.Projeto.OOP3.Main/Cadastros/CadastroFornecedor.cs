using Devs2Blu.Projeto.OOP3.Main.Cadastros.Interfaces;
using Devs2Blu.Projeto.OOP3.Main.Utils;
using Devs2Blu.Projeto.OOP3.Main.Utils.Enums;
using Devs2Blu.Projeto.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.Projeto.OOP3.Main.Cadastros
{
    public class CadastroFornecedor : IMenuCadastro
    {
        public Int32 MenuCadastro()
        {
            Int32 opcao;
            Console.Clear();
            Console.WriteLine("| ---     Cadastro de Fornecedor     --- |");
            Console.WriteLine("|========================================|");
            Console.WriteLine("| --- 1 - Lista de Fornecedores          |");
            Console.WriteLine("| --- 2 - Cadastrar Fornecedor           |");
            Console.WriteLine("| --- 3 - Alterar Cadastro Fornecedor    |");
            Console.WriteLine("| --- 4 - Excluir Fornecedor Cadastrado  |");
            Console.WriteLine("| ---                                    |");
            Console.WriteLine("| --- 0 - Voltar / Sair                  |");
            Int32.TryParse(Console.ReadLine(), out opcao);
            Console.Clear();
            return opcao;
        }

        public void Listar()
        {
            ListarFornecedores();
        }

        private void ListarFornecedoresByCodeAndName()
        {
            Console.Clear();
            foreach (Fornecedor fornecedor in Program.Mock.ListaFornecedores)
            {
                Console.WriteLine($"| Codigo: {fornecedor.CodigoFornecedor} - Nome: {fornecedor.Nome}");
            }
        }

        public void Cadastrar()
        {
            Console.Clear();

            String nome, cnpj, tipo;
            Int32 codigo = UtilsGerais.GeraRandomNum(10, 99);

            Console.WriteLine("| --- Cadastro de Fornecedor, siga os passos a seguir:");

            do
            {
                nome = ValidacoesInputs.inputNotNullSRT("| Informe o nome / razão social do Fornecedor:");
            } while (ValidacoesInputs.validaNome(nome));

            do
            {
                cnpj = ValidacoesInputs.inputNotNullSRT("| Informe o CNPJ do Fornecedor:");
            } while (!ValidacoesInputs.validaCNPJ(cnpj));

            tipo = ValidacoesInputs.inputNotNullSRT("| Qual o tipo do Fornecedor?");

            Fornecedor novoFornecedor = new Fornecedor(codigo, nome, cnpj, tipo);

            CadastrarFornecedor(novoFornecedor);

            Console.WriteLine($"\n| Fornecedor {novoFornecedor.Nome} cadastrado(a) com sucesso!");
            Console.WriteLine("| Pressione qualquer tecla para continuar...");
            Console.ReadLine();
        }

        public void Alterar()
        {
            Fornecedor fornecedor;
            int codigoFornecedor;

            Console.Clear();

            ListarFornecedoresByCodeAndName();

            codigoFornecedor = ExistePessoaByCode();
            if (codigoFornecedor != (int)MenuGeralEnums.SAIR)
            {
                fornecedor = Program.Mock.ListaFornecedores.Find(p => p.CodigoFornecedor.Equals(codigoFornecedor));
                AlterarFornecedor(fornecedor);
            }
        }

        public void Excluir()
        {
            Fornecedor fornecedor;
            int codigoFornecedor;

            Console.Clear();

            ListarFornecedoresByCodeAndName();

            codigoFornecedor = ExistePessoaByCode();
            if (codigoFornecedor != (int)MenuGeralEnums.SAIR)
            {
                fornecedor = Program.Mock.ListaFornecedores.Find(p => p.CodigoFornecedor.Equals(codigoFornecedor));
                ExcluirFornecedor(fornecedor);
            }
        }

        public int ExistePessoaByCode()
        {
            Fornecedor fornecedor;
            int codigo;
            bool primeiraTentativa = true;

            Console.WriteLine("\n---");
            Console.WriteLine($"| Informe o código do fornecedor que deseja alterar: ");

            do
            {
                if (primeiraTentativa.Equals(false)) { Console.WriteLine("| Informe um código válido!"); }
                    
                Int32.TryParse(Console.ReadLine(), out codigo);
                fornecedor = Program.Mock.ListaFornecedores.Find(p => p.CodigoFornecedor.Equals(codigo));

                if (primeiraTentativa.Equals(true)) { primeiraTentativa = false; }
            } while (fornecedor == null && codigo != 0);
            return codigo;
        }

        #region FACADE

        private void ListarFornecedores()
        {
            Console.Clear();

            foreach (Fornecedor fornecedor in Program.Mock.ListaFornecedores)
            {
                Console.WriteLine("==========");
                Console.WriteLine($"Codigo: {fornecedor.CodigoFornecedor}");
                Console.WriteLine($"Nome: {fornecedor.Nome}");
                Console.WriteLine($"CNPJ: {fornecedor.CGCCPF}");
                Console.WriteLine($"Tipo: {fornecedor.TipoFornecedor}");
                Console.WriteLine("==========");
            }
            Console.Write("| Pressione qualquer tecla para voltar...");
            Console.ReadLine();
        }

        private void CadastrarFornecedor(Fornecedor fornecedor)
        {
            Program.Mock.ListaFornecedores.Add(fornecedor);
        }

        private void AlterarFornecedor(Fornecedor fornecedor)
        {
            Int32 opcao;
            do
            {
                Console.Clear();
                Console.WriteLine($"| Alteração de cadastro de recepcionista:");
                Console.WriteLine($"| Nome: {fornecedor.Nome} | CNPJ: {fornecedor.CGCCPF} | Tipo: {fornecedor.TipoFornecedor} |");
                Console.WriteLine("| Selecione o campo que deseja alterar:");
                Console.WriteLine("| 1 - Nome | 2 - CNPJ | 3 - Tipo |");
                Console.WriteLine("| ---");
                Console.WriteLine("| 0 - Voltar");
                Int32.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("| Alterando Nome...");
                        do
                        {
                            fornecedor.Nome = ValidacoesInputs.inputNotNullSRT("| Informe o novo nome:");
                        } while (ValidacoesInputs.validaNome(fornecedor.Nome));
                        break;
                    case 2:
                        Console.WriteLine("| Alterando CPF...");
                        do
                        {
                            fornecedor.CGCCPF = ValidacoesInputs.inputNotNullSRT("| Informe o novo CNPJ:");
                        } while (!ValidacoesInputs.validaCPF(fornecedor.CGCCPF));
                        break;
                    case 3:
                        Console.WriteLine("| Alterando Tipo...");
                        fornecedor.TipoFornecedor = ValidacoesInputs.inputNotNullSRT("| Informe o novo setor:");
                        break;
                    default:
                        if (!opcao.Equals(0)) Console.WriteLine("| Opção não existe, informe uma opção válida:");
                        break;
                }
            } while (!opcao.Equals(0));
        }

        private void ExcluirFornecedor(Fornecedor fornecedor)
        {
            Program.Mock.ListaFornecedores.Remove(fornecedor);
            Console.WriteLine($"| Fornecedor {fornecedor.Nome} exluído com sucesso!");
            Console.Write("\n| Pressione qualquer tecla para continuar...");
            Console.ReadLine();
        }

        #endregion
    }
}
