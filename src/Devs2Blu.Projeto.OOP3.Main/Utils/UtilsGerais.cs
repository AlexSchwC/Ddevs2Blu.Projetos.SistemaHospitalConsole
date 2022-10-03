using Devs2Blu.Projeto.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Devs2Blu.Projeto.OOP3.Main.Utils
{
    public static class UtilsGerais
    {
        static Random rd = new Random();
        
        public static int GeraRandomNum(int min, int max)
        {
            return rd.Next(min, max);
        }

        public static string PadronizaCPF(String cpf)
        {
            //recebe umas string de 11 numeros
            //retorna o cpf com separação por . e -
            //000.000.000-00
            if (cpf.Count().Equals(15)) return cpf;
            cpf = cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            return cpf;
        }

        public static string PadronizaCNPJ(String cnpj)
        {
            //00.000.000/0001-00
            if (cnpj.Count().Equals(18)) return cnpj;
            cnpj = cnpj.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
            return cnpj;
        }
    }
}
