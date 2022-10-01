using Devs2Blu.Projeto.OOP3.Main.Cadastros.Interfaces;
using Devs2Blu.Projeto.OOP3.Main.Utils;
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
            Console.WriteLine("| --- Cadastro de Fornecedor ---");
            Console.WriteLine("| --- 1 - Lista de Fornecedores ---");
            Console.WriteLine("| --- 2 - Cadastrar Fornecedor ---");
            Console.WriteLine("| --- 3 - Alterar Cadastro Fornecedor ---");
            Console.WriteLine("| --- 4 - Excluir Fornecedor Cadastrado ---");
            Console.WriteLine("| ---");
            Console.WriteLine("| --- 0 - Voltar / Sair ---");
            Int32.TryParse(Console.ReadLine(), out opcao);
            Console.Clear();
            return opcao;
        }
        public void Listar()
        {
            ListarFornecedores();
        }
        public void Cadastrar()
        {
            Fornecedor fornecedor = new Fornecedor();
            CadastrarFornecedor(fornecedor);
        }

        public void Alterar()
        {
            throw new NotImplementedException();
        }

        public void Excluir()
        {
            throw new NotImplementedException();
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
                if (primeiraTentativa.Equals(false))
                {
                    Console.WriteLine("| Informe um código válido!");
                }
                Int32.TryParse(Console.ReadLine(), out codigo);
                fornecedor = Program.Mock.ListaFornecedores.Find(p => p.CodigoFornecedor.Equals(codigo));
                if (primeiraTentativa.Equals(true)) primeiraTentativa = false;
            } while (fornecedor == null);
            return codigo;
        }

        #region FACADE

        private void ListarFornecedores()
        {
            Console.Clear();

            foreach (Fornecedor fornecedor in Program.Mock.ListaFornecedores)
            {
                Console.WriteLine("-----");
                Console.WriteLine($"Codigo: {fornecedor.CodigoFornecedor}");
                Console.WriteLine($"Nome: {fornecedor.Nome}");
                Console.WriteLine($"CPF: {fornecedor.CGCCPF}");
                Console.WriteLine($"Tipo: {fornecedor.TipoFornecedor}");
                Console.WriteLine("-----\n");
            }
        }

        private void CadastrarFornecedor(Fornecedor fornecedor)
        {
            Console.Clear();
            String nome, cpf, tipo;
            Int32 codigo = UtilsGerais.GeraRandomNum(10, 99);

            Console.WriteLine("| --- Cadastro de Fornecedor, siga os passos a seguir: ---");
            Console.WriteLine("| Informe o nome do Fornecedor:");
            nome = Console.ReadLine();
            Console.WriteLine("| Informe o CNPJ do Fornecedor:");
            cpf = Console.ReadLine();
            Console.WriteLine("| Qual o tipo do fornecedor?");
            tipo = Console.ReadLine();

            Paciente novoPaciente = new Paciente(codigo, nome, cpf, tipo);

            Program.Mock.ListaPacientes.Add(novoPaciente);
        }

        private void AlterarFornecedor(Fornecedor fornecedor)
        {

        }

        private void ExcluirFornecedor(Fornecedor fornecedor)
        {

        }

        #endregion
    }
}
