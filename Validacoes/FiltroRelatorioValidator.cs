using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoForm.Validacoes;

public class FiltroRelatorioValidator
{
    public bool ValidarIntervaloIds(int? idInicial, int? idFinal)
    {
        if(idInicial.HasValue && idFinal.HasValue && idInicial.Value > idFinal.Value)
        {
            return false;
        }
        return true;
    }

    public bool ValidarIntervaloSalarios(decimal? salarioMinimo, decimal? salarioMaximo)
    {
        if(salarioMinimo.HasValue && salarioMaximo.HasValue && salarioMinimo> salarioMaximo)
        {
            return false;
        }
        return true;
    }

    public bool ValidarIntervaloData(DateTime? nascimentoInicial, DateTime? nascimentoFinal)
    {
        if(nascimentoInicial.HasValue && nascimentoFinal.HasValue && nascimentoInicial > nascimentoFinal)
        {
            return false;
        }
        return true;
    }

    public bool ValidarNome(string nome)
    {
        if(nome.Length > 150)
        {
            return false;
        }

        foreach(char caractere in nome)
        {
            if (!char.IsAsciiLetterOrDigit(caractere) && caractere != ' ' && caractere != '.' && caractere != '-' && caractere != '/')
            {
                return false;
            }
        }

        return true;
    }
}
