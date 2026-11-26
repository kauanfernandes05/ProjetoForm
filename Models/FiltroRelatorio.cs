using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoForm.Models;

public class FiltroRelatorio
{
    public int? IdInicial { get; set; }

    public int? IdFinal { get; set; }

    public string Nome { get; set; } = "";

    public DateTime? NascimentoInicial { get; set; }

    public DateTime? NascimentoFinal { get; set; }

    public decimal? SalarioMinimo { get; set; }

    public decimal? SalarioMaximo { get; set; }

    public string? Cargo { get; set; }

    public string? Sexo { get; set; }

    public bool? ValeTransporte { get; set; }

    public bool? ValeAlimentacao { get; set; }

    public bool? PlanoSaude { get; set; }
}
