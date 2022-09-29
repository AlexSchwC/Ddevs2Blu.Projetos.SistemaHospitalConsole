using Devs2Blu.Projeto.OOP3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.Projeto.OOP3.Main.Cadastros.Interfaces
{
    public interface IMenuCadastro
    {
        Int32 MenuCadastro();
        void Listar();
        void Cadastrar();
        void Alterar();
        void Excluir();
    }
}
