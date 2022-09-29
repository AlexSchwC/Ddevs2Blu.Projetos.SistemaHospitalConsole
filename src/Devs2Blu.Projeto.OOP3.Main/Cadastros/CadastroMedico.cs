using Devs2Blu.Projeto.OOP3.Main.Utils.Enums;
using Devs2Blu.Projeto.OOP3.Main.Utils;
using Devs2Blu.Projeto.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devs2Blu.Projeto.OOP3.Main.Cadastros.Interfaces;
using Devs2Blu.Projeto.OOP3.Models;

namespace Devs2Blu.Projeto.OOP3.Main.Cadastros
{
    public class CadastroMedico : IMenuCadastro
    {
        public Int32 MenuCadastro()
        {
            Int32 opcao;
            Console.Clear();
            Console.WriteLine("| --- Cadastro de Medicos ---");
            Console.WriteLine("| --- 1 - Lista de Medicos ---");
            Console.WriteLine("| --- 2 - Cadastrar Medico ---");
            Console.WriteLine("| --- 3 - Alterar Cadastro Medico ---");
            Console.WriteLine("| --- 4 - Excluir Medico Cadastrado ---");
            Console.WriteLine("| ---");
            Console.WriteLine("| --- 0 - Voltar / Sair ---");
            Int32.TryParse(Console.ReadLine(), out opcao);
            Console.Clear();
            return opcao;
        }

        public void Listar()
        {
            ListarMedicos();
        }

        public void Cadastrar()
        {
            Medico medico = new Medico();
            CadastrarMedico(medico);
        }

        public void Alterar()
        {
            Medico medico = new Medico();
            AlterarMedico(medico);
        }

        public void Excluir()
        {
            Medico medico = new Medico();
            ExcluirMedico(medico);
        }
        
        #region FACADE

        private void ListarMedicos()
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

        private void CadastrarMedico(Pessoa pessoa)
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

        private void AlterarMedico(Pessoa pessoa)
        {

        }

        private void ExcluirMedico(Pessoa pessoa)
        {

        }

        #endregion

    }
}
