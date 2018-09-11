using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Cliente
    {
        [Display(Name = "Código")]
        public int idCliente { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string NomeCliente { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Display(Name = "Estado")]
        public int Estado { get; set; }

        public Cliente()
        {

        }

        public Cliente(int idCliente)
        {
            this.idCliente = idCliente;
        }

        public Cliente(int idCliente, string NomeCliente, string Endereco, string Cpf, string Email, string Senha)
        {
            try
            {
                this.idCliente = idCliente;
                this.NomeCliente = NomeCliente;
                this.Endereco = Endereco;
                this.Cpf = Cpf;
                this.Email = Email;
                this.Senha = Senha;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
