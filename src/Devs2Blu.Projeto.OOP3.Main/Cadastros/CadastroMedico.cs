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
                Console.Clear();

                switch (opcao)
                {
                    case (int)MenuGeralEnums.LISTAR:
                        ListarMedicos();
                        break;
                    case (int)MenuGeralEnums.CADASTRAR:
                        CadastrarMedico();
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

        public void CadastrarMedico()
        {
            Console.Clear();
            String nome, cpf, especialidade;
            Int32 codigo = UtilsGerais.GeraRandomNum(10, 99);
            Int32 crm;

            Console.WriteLine("| --- Cadastro de Medico, siga os passos a seguir: ---");
            Console.WriteLine("| Informe o nome completo do Médico:");
            nome = Console.ReadLine();
            Console.WriteLine("| Informe o CPF do Médico:");
            cpf = Console.ReadLine();
            Console.WriteLine("| Informe o CRM do Médico:");
            Int32.TryParse(Console.ReadLine(), out crm);
            Console.WriteLine("| Informe a especialidade:");
            especialidade = Console.ReadLine();

            Medico novoMedico = new Medico(codigo, nome, cpf, crm, especialidade);

            Program.Mock.ListaMedicos.Add(novoMedico);
        }

        public void AlterarMedico()
        {

        }

        public void ExcluirMedico()
        {

        }
    }
}
