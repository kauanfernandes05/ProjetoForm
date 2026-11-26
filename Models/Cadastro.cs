using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoForm.Models;

public class Cadastro
{
   public int Id { get; set; }

    public string Nome { get; set; } = "";

    public DateTime DataNascimento { get; set; }

    public decimal Salario { get; set; }

    public string Cargo { get; set; } = "";

    public string Sexo { get; set; } = "";

    public bool ValeTransporte { get; set; }

    public bool ValeAlimentacao { get; set; }

    public bool PlanoSaude { get; set; }

    public string Beneficios
    {
        get
        {
            var beneficios = new List<string>();

            if (ValeTransporte)
                beneficios.Add("Vale-transporte");

            if (ValeAlimentacao)
                beneficios.Add("Vale-alimentação");

            if (PlanoSaude)
                beneficios.Add("Plano de saúde");

            return beneficios.Count > 0
                ? string.Join(", ", beneficios)
                : "Nenhum";
        }
    }
}
