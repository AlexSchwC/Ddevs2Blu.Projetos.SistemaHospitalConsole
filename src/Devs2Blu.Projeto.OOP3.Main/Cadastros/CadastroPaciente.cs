using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devs2Blu.Projeto.OOP3.Main.Utils;
using Devs2Blu.Projeto.OOP3.Main.Utils.Enums;
using Devs2Blu.Projeto.OOP3.Models.Model;

namespace Devs2Blu.Projeto.OOP3.Main.Cadastros
{
    public class CadastroPaciente
    {
        public CadastroPaciente()
        {

        }
        public void MenuCadastro()
        {
            int opcao;

            do
            {
                Console.WriteLine("| --- Cadastro de Pacientes ---");
                Console.WriteLine("| --- 1 - Lista de Pacientes ---");
                Console.WriteLine("| --- 2 - Cadastrar Pacientes ---");
                Console.WriteLine("| --- 3 - Alterar Cadastro Paciente ---");
                Console.WriteLine("| --- 4 - Excluir Paciente Cadastrado ---");
                Console.WriteLine("| ---");
                Console.WriteLine("| --- 0 - Voltar / Sair ---");
                Int32.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case (int)MenuGeralEnums.LISTAR:
                        ListarPacientes();
                        break;
                    default:
                        break;
                }

            } while (!opcao.Equals((int)MenuGeralEnums.SAIR));
        }

        public void ListarPacientes()
        {
            Console.Clear();

            foreach (Paciente paciente in Program.Mock.ListaPacientes)
            {
                Console.WriteLine("-----");
                Console.WriteLine($"Codigo: {paciente.CodigoPaciente}");
                Console.WriteLine($"Nome: {paciente.Nome}");
                Console.WriteLine($"CPF: {paciente.CGCCPF}");
                Console.WriteLine($"Convenio: {paciente.Convenio}");
                Console.WriteLine("-----\n");
            }
        }

        public void CadastrarPaciente(Mocks mock)
        {

        }

        public void AlterarPaciente(Mocks mock)
        {

        }

        public void ExcluirPaciente(Mocks mock)
        {

        }
    }
}
