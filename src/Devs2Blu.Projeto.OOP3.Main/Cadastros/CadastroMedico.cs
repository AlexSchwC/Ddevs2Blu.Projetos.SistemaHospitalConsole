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
    public class CadastroMedico
    {
        public void MenuCadastro()
        {
            int opcao;

            do
            {
                Console.WriteLine("| --- Cadastro de Medicos ---");
                Console.WriteLine("| --- 1 - Lista de Medicos ---");
                Console.WriteLine("| --- 2 - Cadastrar Medico ---");
                Console.WriteLine("| --- 3 - Alterar Cadastro Medico ---");
                Console.WriteLine("| --- 4 - Excluir Medico Cadastrado ---");
                Console.WriteLine("| ---");
                Console.WriteLine("| --- 0 - Voltar / Sair ---");
                Int32.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case (int)MenuGeralEnums.LISTAR:
                        ListarMedicos();
                        break;
                    default:
                        break;
                }

            } while (!opcao.Equals((int)MenuGeralEnums.SAIR));
        }

        public void ListarMedicos()
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

        public void CadastrarMedico(Mocks mock)
        {

        }

        public void AlterarMedico(Mocks mock)
        {

        }

        public void ExcluirMedico(Mocks mock)
        {

        }
    }
}
