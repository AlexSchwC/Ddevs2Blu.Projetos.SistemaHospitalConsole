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

            Console.Clear();

            do
            {
                Console.WriteLine("| --- Cadastro de Pacientes ---");
                Console.WriteLine("| --- 1 - Lista de Pacientes ---");
                Console.WriteLine("| --- 2 - Cadastrar Paciente ---");
                Console.WriteLine("| --- 3 - Alterar Cadastro Paciente ---");
                Console.WriteLine("| --- 4 - Excluir Paciente Cadastrado ---");
                Console.WriteLine("| ---");
                Console.WriteLine("| --- 0 - Voltar / Sair ---");
                Int32.TryParse(Console.ReadLine(), out opcao);
                Console.Clear();

                switch (opcao)
                {
                    case (int)MenuGeralEnums.LISTAR:
                        ListarPacientes();
                        break;
                    case (int)MenuGeralEnums.CADASTRAR:
                        CadastrarPaciente();
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

        public void CadastrarPaciente()
        {
            Console.Clear();
            String nome, cpf, convenio;
            Int32 codigo = UtilsGerais.GeraRandomNum(10, 99);
            
            Console.WriteLine("| --- Cadastro de Paciente, siga os passos a seguir: ---");
            Console.WriteLine("| Informe o nome completo do Paciente:");
            nome = Console.ReadLine();
            Console.WriteLine("| Informe o CPF do Paciente:");
            cpf = Console.ReadLine();
            Console.WriteLine("| Qual o convênio do paciente?");
            convenio = Console.ReadLine();

            Paciente novoPaciente = new Paciente(codigo, nome, cpf, convenio);

            Program.Mock.ListaPacientes.Add(novoPaciente);
        }

        public void AlterarPaciente()
        {

        }

        public void ExcluirPaciente()
        {

        }
    }
}
