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
                Console.Clear();
                Console.WriteLine("| --- - Sistema de Gerenciamento de Clinicas - ---");
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
                Console.Clear();

                switch (opcao)
                {
                    case (int)MainMenuEnums.CAD_PACI:
                        CadastroPaciente moduloCadastroPacientes = new CadastroPaciente();
                        moduloCadastroPacientes.MenuCadastro();
                        break;
                    case (int)MainMenuEnums.CAD_MED:
                        CadastroMedico moduloCadastroMedicos = new CadastroMedico();
                        moduloCadastroMedicos.MenuCadastro();
                        break;
                    case (int)MainMenuEnums.CAD_RECEP:
                        CadastroRecepcionista moduloCadastroRecepcionista = new CadastroRecepcionista();
                        moduloCadastroRecepcionista.MenuCadastro();
                        break;
                    default:
                        break;
                }

            } while (!opcao.Equals((int)MainMenuEnums.SAIR));
        }
    }
}
