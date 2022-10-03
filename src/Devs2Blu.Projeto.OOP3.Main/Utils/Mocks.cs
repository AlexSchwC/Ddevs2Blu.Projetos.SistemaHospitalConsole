using Devs2Blu.Projeto.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.Projeto.OOP3.Main.Utils
{
    public class Mocks
    {
        public List<Paciente> ListaPacientes { get; set; }
        public List<Medico> ListaMedicos { get; set; }
        public List<Recepcionista> ListaRecepcionistas { get; set; }
        public List<Fornecedor> ListaFornecedores { get; set; }

        public Mocks()
        {
            ListaPacientes = new List<Paciente>();
            ListaMedicos = new List<Medico>();
            ListaRecepcionistas = new List<Recepcionista>();
            ListaFornecedores = new List<Fornecedor>();

            CargaMock();
        }

        public void CargaMock()
        {
            CargaPacientes();
            CargaMedicos();
            CargaRecepcionistas();
            CargaFornecedores();
        }

        public void CargaPacientes()
        {
            for (int i = 1; i <= 9; i++)
            {
                Paciente paciente = new Paciente(i, $"Paciente {i}", $"{i}23.{i}56.{i}89-1{i}", "Unimed");
                ListaPacientes.Add(paciente);
            }
        }

        public void CargaMedicos()
        {
            string[] especialidades = new string[3] {"Cardiologista", "Anestesista", "Medico Geral"};
            
            for (int i = 1; i <= 5; i++)
            {
                Medico medic = new Medico(i, $"Medico {i}", $"{i}23.{i}56.{i}89-1{i}", UtilsGerais.GeraRandomNum(1000, 9999), especialidades[UtilsGerais.GeraRandomNum(0, 2)]);
                ListaMedicos.Add(medic);
            }
        }

        public void CargaRecepcionistas()
        {
            string[] setores = new string[3] { "Atendimento", "Emergência", "Ala Infantil" };

            for (int i = 1; i <= 5; i++)
            {
                Recepcionista recep = new Recepcionista(i, $"Recepcionista {i}", $"{i}23.{i}56.{i}89-1{i}", setores[UtilsGerais.GeraRandomNum(0, 2)]);
                ListaRecepcionistas.Add(recep);
            }
        }

        public void CargaFornecedores()
        {
            string[] tipos = new string[3] { "Equipamentos Médicos", "Orgãos", "Naridrin" };

            for (int i = 1; i <= 5; i++)
            {
                Fornecedor fornecedor = new Fornecedor(i, $"Recepcionista {i}", $"{i}2.3{i}5.6{i}8/0001-{UtilsGerais.GeraRandomNum(10, 99)}", tipos[UtilsGerais.GeraRandomNum(0, 2)]);
                ListaFornecedores.Add(fornecedor);
            }
        }
    }
}
