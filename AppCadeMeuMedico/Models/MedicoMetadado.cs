using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppCadeMeuMedico.Models
{
    [MetadataType(typeof(MedicoMetadado))]
    public partial class Medico
    {
    }
    public class MedicoMetadado
    {
        [Required(ErrorMessage = "Obrigatório informar o CRM")]
        [StringLength(30, ErrorMessage = "O CRM deve possuirno máximo 30 caracteres")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Nome")]

        [StringLength(80, ErrorMessage = "O Nome deve possuir nomáximo 80 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o Endereço")]

        [StringLength(100, ErrorMessage = "O Endereço deve possuirno máximo 100 caracteres")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o Bairro")]

        [StringLength(60, ErrorMessage = "O Bairro deve possuir no máximo 60 caracteres")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o E-mail")]

        [StringLength(100, ErrorMessage = "O E-mail deve possuirno máximo 100 caracteres")]

        [EmailAddress(ErrorMessage = "E-mail incorreto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar se Atende por Convênio")]
        public bool AtendePorConvenio { get; set; }

        [Required(ErrorMessage = "Obrigatório informar se Tem Clínica")]
        public bool TemClinica { get; set; }

        [StringLength(80, ErrorMessage = "O Website deve possuir no máximo 80 caracteres")]
        //[Url(ErrorMessage = "Website inválido")]
        public string WebsiteBlog { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Cidade")]
       
        public int IDCidade { get; set; }

        [Required(ErrorMessage = "Obrigatório informara Especialidade")]
        public int IDEspecialidade { get; set; }
    }
}
