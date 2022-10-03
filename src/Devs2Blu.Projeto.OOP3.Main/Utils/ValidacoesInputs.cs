using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Devs2Blu.Projeto.OOP3.Main.Utils
{
    public static class ValidacoesInputs
    {
        public static Regex rxOnlyLettersAndSpace = new Regex("[^ a-zA-Z]");
        public static Regex rxOnlyLetters = new Regex("[^a-zA-Z]");
        public static Regex rxValidaCPF = new Regex("([0-9]{3}[\\.]?[0-9]{3}[\\.]?[0-9]{3}[-]?[0-9]{2})");
        public static Regex rxValidaCNPJ = new Regex("([0-9]{2}[\\.]?[0-9]{3}[\\.]?[0-9]{3}[\\/]?[0-9]{4}[-]?[0-9]{2})");
        public static Regex rxValidaCRM = new Regex("([0-9]{6})");

        public static string inputNotNullSRT(string mensagem)
        {
            string inputUser;
            do
            {
                Console.WriteLine($"{mensagem}");
                inputUser = Console.ReadLine();

                if (inputUser.Equals(""))
                {
                    Console.WriteLine("| O input não pode ser nulo, tente novamente...");
                }

            } while (inputUser.Equals("") || inputUser.Equals(null));

            return inputUser;
        }

        public static bool validaCPF(string cpf) 
        {
            if (!rxValidaCPF.IsMatch(cpf)) {
                Console.WriteLine("| O CPF esta em formato inválido, insira novamente...");
                return false;
            }
            return true;
        }

        public static bool validaCNPJ(string cnpj)
        {
            if (!rxValidaCNPJ.IsMatch(cnpj))
            {
                Console.WriteLine("| O CNPJ esta em formato inválido, insira novamente...");
                return false;
            }
            return true;
        }

        public static bool validaNome(string nome)
        {
            if (rxOnlyLettersAndSpace.IsMatch(nome))
            {
                Console.WriteLine("| O nome pode conter SOMENTE letras e espaços, insira novamente...");
                return true;
            }
            return false;
        }

        public static bool validaCRM(int crm)
        {
            string crmSTR = crm.ToString();
            if (rxValidaCRM.IsMatch(crmSTR)) { return false; }

            Console.WriteLine("| CRM em formato inválido!");
            return true;
        }
    }
}
