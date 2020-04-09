using Projeto_BRQ.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_BRQ.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }


        public bool CadastrarContato(Contato contato)
        {
            try
            {
                var obj = new Contato
                {
                    Nome = contato.Nome,
                    Email = contato.Email,
                    Telefone = (!string.IsNullOrEmpty(contato.Telefone) ? RetirarMascaraTelefone(contato.Telefone) : string.Empty)
                };

                if (new ContatoDAO().CadastrarContato(obj))
                    return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditarContato(Contato contato)
        {
            try
            {
                var obj = new Contato
                {
                    Id = contato.Id,
                    Nome = contato.Nome,
                    Email = contato.Email,
                    Telefone = (!string.IsNullOrEmpty(contato.Telefone) ? RetirarMascaraTelefone(contato.Telefone) : string.Empty)
                };

                if (new ContatoDAO().EditarContato(obj))
                    return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        

        public bool ExcluirContato(Contato contato)
        {
            try
            {
                if (new ContatoDAO().ExcluirContato(contato))
                    return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        

        private string RetirarMascaraTelefone(string numero)
        {
            return numero = numero.Replace("(", "").Replace(")", "").Replace("-", "");
        }

        private string IncluirMascaraTelefone(string numero)
        {
            var lote1 = numero.Substring(0, 2);
            var lote2 = numero.Substring(2, 5);
            var lote3 = numero.Substring(5,11);
            return numero = "(" + lote1 + ")" + lote2 + "-" + lote3;
        }

        public List<Contato> ConsultarContato(Contato contato)
        {
            try
            {
                return new ContatoDAO().ConsultarContato(contato);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Contato ConsultarContatoByID(Contato contato)
        {
            try
            {
                return new ContatoDAO().ConsultarContatoByID(contato);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}