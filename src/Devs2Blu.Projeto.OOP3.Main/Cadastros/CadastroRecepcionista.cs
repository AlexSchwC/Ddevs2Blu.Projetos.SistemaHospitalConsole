using Devs2Blu.Projeto.OOP3.Main.Utils.Enums;
using Devs2Blu.Projeto.OOP3.Main.Utils;
using Devs2Blu.Projeto.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.Projeto.OOP3.Main.Cadastros
{
    public class CadastroRecepcionista
    {
        public CadastroRecepcionista()
        {

        }
        public void MenuCadastro()
        {
            int opcao;

            do
            {
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
                    default:
                        break;
                }

            } while (!opcao.Equals((int)MenuGeralEnums.SAIR));
        }

        public void ListarRecepcionistas()
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

        public void CadastrarRecepcionista(Mocks mock)
        {

        }

        public void AlterarRecepcionista(Mocks mock)
        {

        }

        public void ExcluirRecepcionista(Mocks mock)
        {

        }
    }
}
