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
        static Regex rxOnlyLetters = new Regex("/(^(?=.{4,16}$)(?=.+[a-zA-Z])[a-zA-Z]+$)/gm");
        
        public static int GeraRandomNum(int min, int max)
        {
            return rd.Next(min, max);
        }
    }
}
