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
    }
}
