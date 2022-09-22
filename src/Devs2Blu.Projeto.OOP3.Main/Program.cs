using Devs2Blu.Projeto.OOP3.Main.Cadastros;
using Devs2Blu.Projeto.OOP3.Main.Utils;
using Devs2Blu.Projeto.OOP3.Main.Utils.Enums;
using Devs2Blu.Projeto.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.Projeto.OOP3.Main
{
    internal class Program
    {
        public static Mocks Mock { get; set; }
        static void Main(string[] args)
        {
            int opcao;
            Mock = new Mocks();
            do
            {
                Console.WriteLine("| ");
                Console.WriteLine("| --- 1 - Cadastro de Pacientes ---");
                Console.WriteLine("| --- 2 - Cadastro de Medicos ---");
                Console.WriteLine("| --- 3 - Cadastro de Recepcionistas ---");
                Console.WriteLine("| --- 4 - Cadastro de Fornecedores ---");
                Console.WriteLine("| --- 5 - Agenda ---");
                Console.WriteLine("| --- 6 - Prontuário ---");
                Console.WriteLine("| --- 7 - Financeiro ---");
                Console.WriteLine("| ---");
                Console.WriteLine("| --- 0 - Voltar / Sair ---");
                Int32.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case (int)MainMenuEnums.CAD_PACI:
                        CadastroPaciente ModuloCadastroPacientes = new CadastroPaciente();
                        ModuloCadastroPacientes.MenuCadastro();
                        break;
                    case (int)MainMenuEnums.CAD_MED:
                        CadastroMedico ModuloCadastroMedicos = new CadastroMedico();
                        ModuloCadastroMedicos.MenuCadastro();
                        break;
                    default:
                        break;
                }

            } while (!opcao.Equals((int)MainMenuEnums.SAIR));
        }
    }
}
