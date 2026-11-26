using ProjetoForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoForm.Validacoes;

public class CadastroValidator
{
    public bool ValidarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome) || nome.Length > 150)
        {
            return false;
        }

        foreach (char caractere in nome)
        {

            if(!char.IsLetterOrDigit(caractere) &&
                caractere != ' ' &&
                caractere != '-' &&
                caractere == '_' &&
                caractere != '.' &&
                caractere != '/')
            {
                return false;
            }
        }

        int quantidade = 0;

        foreach(char caractere in nome)
        {
            if (char.IsLetter(caractere))
            {
                quantidade++;
            }
        }

        if(quantidade < 2)
        {
            return false;
        }

        bool simbolosExcessivos = Regex.IsMatch(nome, @"[./-]{3,}");

        if (simbolosExcessivos)
        {
            return false;
        }

        if (!char.IsLetterOrDigit(nome[0]))
        {
            return false;
        }

        return true;
    }

    public bool ValidarNascimento(DateTime nascimento, DateTime hoje)
    {
        nascimento = nascimento.Date;
        hoje = hoje.Date;

        // Validação da data de nascimento.
        if (nascimento > hoje)
        {
            return false;
        }

        if (nascimento > hoje.AddYears(-18))
        {
            return false;
        }

        if (nascimento < hoje.AddYears(-120))
        {
            return false;
        }
        return true;
    }

    public bool ValidarSalario(decimal salario)
    {
        if(salario < 800m || salario > 9999999.99m)
        {
            return false;
        }
        return true;
    }

    public bool ValidarCargo(string cargo, IEnumerable<string> cargosDisponiveis)
    {
        return cargosDisponiveis.Any(item => string.Equals(item,cargo,StringComparison.CurrentCultureIgnoreCase));
    }
    
    public bool ExisteDuplicado(Cadastro cadastro, IEnumerable<Cadastro> cadastros, Cadastro? cadastroEmEdicao = null)
    {
        foreach(Cadastro registro in cadastros)
        {
            if(registro == cadastroEmEdicao)
            {
                continue;
            }
            string nomeExixtente = Regex.Replace(registro.Nome.Trim(), " +", " ");
            string nomeInformado = Regex.Replace(cadastro.Nome.Trim(), " +", " ");

            bool mesmoNome = string.Equals(nomeExixtente, nomeInformado, StringComparison.CurrentCultureIgnoreCase);
            bool mesmaData = registro.DataNascimento.Date == cadastro.DataNascimento.Date;

            bool mesmoSalario =  registro.Salario == cadastro.Salario;

            bool mesmoCargo = string.Equals(registro.Cargo, cadastro.Cargo, StringComparison.OrdinalIgnoreCase);
            bool mesmoSexo = string.Equals(registro.Sexo, cadastro.Sexo, StringComparison.OrdinalIgnoreCase);

            bool mesmosBeneficios = 
                registro.ValeTransporte == cadastro.ValeTransporte &&
                registro.ValeAlimentacao == cadastro.ValeAlimentacao &&
                registro.PlanoSaude == cadastro.PlanoSaude;

            if(mesmoNome && mesmoSalario && mesmaData && mesmosBeneficios && mesmoSexo && mesmoCargo)
            {
                return true;
            }
        }

        return false;
    }
}


