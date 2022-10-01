using Devs2Blu.Projeto.OOP3.Main.Cadastros;
using Devs2Blu.Projeto.OOP3.Main.Cadastros.Interfaces;
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
            Int32 opcao = 0, opcaoMenuCadastros = 0;
            IMenuCadastro menuCadastros;
            Mock = new Mocks();

            do
            {

                if (opcaoMenuCadastros.Equals((int)MainMenuEnums.SAIR))
                {
                    Console.Clear();
                    Console.WriteLine("|  - Sistema de Gerenciamento de Clinicas -  |");
                    Console.WriteLine("|============================================|");
                    Console.WriteLine("| --- 1 - Cadastro de Pacientes              |");
                    Console.WriteLine("| --- 2 - Cadastro de Medicos                |");
                    Console.WriteLine("| --- 3 - Cadastro de Recepcionistas         |");
                    Console.WriteLine("| --- 4 - Cadastro de Fornecedores           |");
                    Console.WriteLine("| --- 5 - Agenda                             |");
                    Console.WriteLine("| --- 6 - Prontuário                         |");
                    Console.WriteLine("| --- 7 - Financeiro                         |");
                    Console.WriteLine("| ---                                        |");
                    Console.WriteLine("| --- 0 - Sair                               |");
                    Int32.TryParse(Console.ReadLine(), out opcao);
                    Console.Clear();
                }

                switch (opcao)
                {
                    case (int)MainMenuEnums.CAD_PACI:
                        menuCadastros = new CadastroPaciente();
                        opcaoMenuCadastros = menuCadastros.MenuCadastro();
                        break;
                    case (int)MainMenuEnums.CAD_MED:
                        menuCadastros = new CadastroMedico();
                        opcaoMenuCadastros = menuCadastros.MenuCadastro();
                        break;
                    case (int)MainMenuEnums.CAD_RECEP:
                        menuCadastros = new CadastroRecepcionista();
                        opcaoMenuCadastros = menuCadastros.MenuCadastro();
                        break;
                    case (int)MainMenuEnums.CAD_FORN:
                        menuCadastros = new CadastroFornecedor();
                        opcaoMenuCadastros = menuCadastros.MenuCadastro();
                        break;
                    default:
                        menuCadastros = new CadastroPadrao();
                        opcaoMenuCadastros = (int)MainMenuEnums.SAIR;
                        break;
                }

                switch (opcaoMenuCadastros)
                {
                    case (int)MenuGeralEnums.LISTAR:
                        menuCadastros.Listar();
                        break;
                    case (int)MenuGeralEnums.CADASTRAR:
                        menuCadastros.Cadastrar();
                        break;
                    case (int)MenuGeralEnums.ALTERAR:
                        menuCadastros.Alterar();
                        break;
                    case (int)MenuGeralEnums.EXCLUIR:
                        menuCadastros.Excluir();
                        break;
                    default:
                        opcaoMenuCadastros = (int)MenuGeralEnums.SAIR;
                        break;
                }


            } while (!opcao.Equals((int)MainMenuEnums.SAIR));
        }
    }
}
