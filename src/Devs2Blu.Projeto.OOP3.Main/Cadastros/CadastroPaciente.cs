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
            Console.WriteLine("| --- Cadastro de Pacientes ---");
            Console.WriteLine("| --- 1 - Lista de Pacientes ---");
            Console.WriteLine("| --- 2 - Cadastrar Paciente ---");
            Console.WriteLine("| --- 3 - Alterar Cadastro Paciente ---");
            Console.WriteLine("| --- 4 - Excluir Paciente Cadastrado ---");
            Console.WriteLine("| ---");
            Console.WriteLine("| --- 0 - Voltar / Sair ---");
            Int32.TryParse(Console.ReadLine(), out opcao);
            Console.Clear();
            return opcao;
        }

        public void Listar()
        {
            ListarPacientes();
        }

        public void Cadastrar()
        {
            Paciente paciente = new Paciente();
            CadastrarPaciente(paciente);
        }

        public void Alterar()
        {
            Paciente paciente;
            int codigoPaciente;

            Console.Clear();

            ListarPacientesByCodeAndName();
            Console.WriteLine("\n---");

            Console.WriteLine($"| Informe o código do paciente que deseja alterar: ");
            Int32.TryParse(Console.ReadLine(), out codigoPaciente);
            paciente = Program.Mock.ListaPacientes.Find(p => p.CodigoPaciente.Equals(codigoPaciente));

            AlterarPaciente(paciente);
        }

        public void Excluir()
        {
            Paciente paciente;
            int codigoPaciente;

            Console.Clear();

            ListarPacientesByCodeAndName();
            Console.WriteLine("\n---");
            Console.WriteLine($"| Informe o código do paciente que deseja excluir: ");
            Int32.TryParse(Console.ReadLine(), out codigoPaciente);
            paciente = Program.Mock.ListaPacientes.Find(p => p.CodigoPaciente.Equals(codigoPaciente));

            ExcluirPaciente(paciente);
        }

        #region FACADE

        private void ListarPacientes()
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
            Console.ReadLine();
        }

        private void ListarPacientesByCodeAndName()
        {
            Console.Clear();

            foreach (Paciente paciente in Program.Mock.ListaPacientes)
            {
                Console.WriteLine($"| Codigo: {paciente.CodigoPaciente} - Nome: {paciente.Nome}");
            }
        }

        private void CadastrarPaciente(Paciente paciente)
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

        private void AlterarPaciente(Paciente paciente)
        {
            
        }

        private void ExcluirPaciente(Paciente paciente)
        {
            Program.Mock.ListaPacientes.Remove(paciente);
            Console.WriteLine($"| Paciente {paciente.Nome} exluído com sucesso!");
            Console.ReadLine();
        }

        #endregion

    }
}
