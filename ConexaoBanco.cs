using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ProjetoForm;

internal class ConexaoBanco
{
    private static readonly string stringConexao =
     @"Server=SEU_SERVIDOR;Database=SEU_BANCO;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

    public static SqlConnection CriarConexao()
    {
        return new SqlConnection(stringConexao);
    }
}
