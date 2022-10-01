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
            Console.WriteLine("| --- Cadastro de Recepcionistas ---");
            Console.WriteLine("| --- 1 - Lista de Recepcionistas ---");
            Console.WriteLine("| --- 2 - Cadastrar Recepcionistas ---");
            Console.WriteLine("| --- 3 - Alterar Cadastro Recepcionista ---");
            Console.WriteLine("| --- 4 - Excluir Recepcionista Cadastrada ---");
            Console.WriteLine("| ---");
            Console.WriteLine("| --- 0 - Voltar / Sair ---");
            Int32.TryParse(Console.ReadLine(), out opcao);
            Console.Clear();

            switch (opcao)
            {
                case (int)MenuGeralEnums.LISTAR:
                    ListarRecepcionistas();
                    break;
                case (int)MenuGeralEnums.CADASTRAR:
                    CadastrarRecepcionista();
                    break;
                default:
                    break;
            }
            return opcao;
        }
        public void Listar()
        {
            throw new NotImplementedException();
        }

        public void Cadastrar()
        {
            throw new NotImplementedException();
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
            Recepcionista recepcionista;
            int codigo;
            bool primeiraTentativa = true;

            Console.WriteLine("\n---");
            Console.WriteLine($"| Informe o código do(a) recepcionista que deseja alterar: ");

            do
            {
                if (primeiraTentativa.Equals(false))
                {
                    Console.WriteLine("| Informe um código válido!");
                }
                Int32.TryParse(Console.ReadLine(), out codigo);
                recepcionista = Program.Mock.ListaRecepcionistas.Find(p => p.CodigoRecepcionista.Equals(codigo));
                if (primeiraTentativa.Equals(true)) primeiraTentativa = false;
            } while (recepcionista == null);
            return codigo;
        }

        #region FACADE 

        static void ListarRecepcionistas()
        {
            Console.Clear();
            foreach (Recepcionista recepcionista in Program.Mock.ListaRecepcionistas)
            {
                Console.WriteLine("-----");
                Console.WriteLine($"Codigo: {recepcionista.CodigoRecepcionista}");
                Console.WriteLine($"Nome: {recepcionista.Nome}");
                Console.WriteLine($"CPF: {recepcionista.CGCCPF}");
                Console.WriteLine($"CPF: {recepcionista.Setor}");
                Console.WriteLine("-----\n");
            }
        }

        static void CadastrarRecepcionista()
        {
            Console.Clear();
            String nome, cpf, setor;
            Int32 codigo = UtilsGerais.GeraRandomNum(10, 99);

            Console.WriteLine("| --- Cadastro de Recepcionista, siga os passos a seguir: ---");
            Console.WriteLine("| Informe o nome completo da Recepcionista:");
            nome = Console.ReadLine();
            Console.WriteLine("| Informe o CPF da Recepcionista:");
            cpf = Console.ReadLine();
            Console.WriteLine("| Informe o setor:");
            setor = Console.ReadLine();

            Recepcionista novaRecepcionista = new Recepcionista(codigo, nome, cpf, setor);

            Program.Mock.ListaRecepcionistas.Add(novaRecepcionista);
        }

        static void AlterarRecepcionista()
        {

        }

        static void ExcluirRecepcionista()
        {

        }

        #endregion
    }
}
