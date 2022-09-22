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
        }

        public void CargaPacientes()
        {
            for (int i = 1; i <= 10; i++)
            {
                Paciente xoxinho = new Paciente(i, $"Paciente {i}", $"{i}23{i}56{i}891{i}", "Unimed");
                ListaPacientes.Add(xoxinho);
            }
        }

        public void CargaMedicos()
        {
            string[] especialidades = new string[3] {"Cardiologista", "Anestesista", "Medico Geral"};
            
            for (int i = 1; i <= 5; i++)
            {
                Medico medic = new Medico(i, $"Medico {i}", $"{i}23{i}56{i}891{i}", UtilsGerais.GeraRandomNum(1000, 9999), especialidades[UtilsGerais.GeraRandomNum(0, 2)]);
                ListaMedicos.Add(medic);
            }
        }
    }
}
