using GuiDeveloper.Domain.Entities;
using GuiDeveloper.Domain.Enums;
using System;

namespace GuiDeveloper.Domain.Models
{
    public class Paciente : EntityBase
    {
        public Paciente()
        {
            DataInternacao =DateTime.Now;
            Ativo=true;
        }

        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInternacao { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public string Cpf { get; set; }
        public TipoPaciente TipPaciente { get; set; }
        public Sexo Sexo { get; set; }
        public string Rg { get; set; }
        public string RgOrgao { get; set; }
        public DateTime RgDataEmissao { get; set; }

        public override string ToString()
        {
            return Id + " - " + Nome;
        }
    }
}
