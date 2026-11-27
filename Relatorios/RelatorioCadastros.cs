using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;
using ProjetoForm.Models;

namespace ProjetoForm.Relatorios;

public class RelatorioCadastros
{
    public void AbrirPreviaRelatorio(IWin32Window janelaDona, List<Cadastro> registros, FiltroRelatorio filtro, List<string> cargosSelecionados)
    {
        using var documento = new PrintDocument();
        using var previa = new PrintPreviewDialog();

        using var fonteTitulo = new Font("Arial", 14, FontStyle.Bold);
        using var fonteRodape = new Font("Arial", 9);

        var cultura = CultureInfo.GetCultureInfo("pt-BR");

        int indiceRegistro = 0;
        int numeroPagina = 0;

        DateTime emissao = DateTime.Now;

        documento.DocumentName = "Relatório de cadastros";

        // Margens em centésimos de polegada.
        documento.DefaultPageSettings.Margins = new Margins(60, 60, 60, 60);

        documento.DefaultPageSettings.Landscape = true;

        // Reinicia a contagem ao gerar a prévia ou imprimir.
        documento.BeginPrint += (sender, e) =>
        {
            indiceRegistro = 0;
            numeroPagina = 0;
        };

        string resumoFiltros =MontarResumoFiltros(filtro, cargosSelecionados);

        documento.PrintPage += (sender, e) =>
        {
            Graphics? desenho = e.Graphics;

            if (desenho == null)
                return;

            numeroPagina++;

            Rectangle area = e.MarginBounds;

            float esquerda = area.Left;
            float largura = area.Width;
            float posicaoY = area.Top;
            float limiteInferior = area.Bottom - 30;

            const float margemCelula = 4;

            string[] titulos =
            {
                "ID",
                "Nome",
                "Nascimento",
                "Salário",
                "Cargo",
                "Sexo",
                "Benefícios"
            };

            // Proporção da largura destinada a cada coluna.
            float[] proporcoes =
            {
                0.06f,
                0.22f,
                0.10f,
                0.12f,
                0.18f,
                0.09f,
                0.23f
            };

            float[] larguras = new float[proporcoes.Length];

            for (int i = 0; i < proporcoes.Length; i++)
            {
                larguras[i] = largura * proporcoes[i];
            }

            using var fonteCabecalho =
                new Font("Arial", 9, FontStyle.Bold);

            using var fonteCelula =
                new Font("Arial", 9);

            using var formatoTexto = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near,
                Trimming = StringTrimming.None
            };

            using var formatoCentro = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Near,
                Trimming = StringTrimming.None
            };

            using var formatoNumero = new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Near,
                Trimming = StringTrimming.None
            };

            // Cabeçalho do relatório.
            desenho.DrawString(
                "Relatório de cadastros",
                fonteTitulo,
                Brushes.Black,
                esquerda,
                posicaoY
            );

            posicaoY += 30;

            desenho.DrawString(
                $"Emissão: {emissao:dd/MM/yyyy HH:mm}    " +
                $"Total de cadastros: {registros.Count}",
                fonteRodape,
                Brushes.Black,
                esquerda,
                posicaoY
            );

            posicaoY += 25;

            SizeF tamanhoResumo = desenho.MeasureString(
                resumoFiltros,
                fonteRodape,
                new SizeF(largura, 10000)
            );

            desenho.DrawString(
                resumoFiltros,
                fonteRodape,
                Brushes.Black,
                new RectangleF(
                    esquerda,
                    posicaoY,
                    largura,
                    tamanhoResumo.Height + 2
                )
            );

            posicaoY += tamanhoResumo.Height + 12;

            // Calcula a altura dos títulos, permitindo quebra de linha.
            float alturaCabecalho = 26;

            for (int i = 0; i < titulos.Length; i++)
            {
                SizeF tamanho = desenho.MeasureString(
                    titulos[i],
                    fonteCabecalho,
                    new SizeF(
                        larguras[i] - margemCelula * 2,
                        10000
                    ),
                    formatoCentro
                );

                alturaCabecalho = Math.Max(
                    alturaCabecalho,
                    tamanho.Height + margemCelula * 2
                );
            }

            // Desenha os títulos em todas as páginas.
            float posicaoX = esquerda;

            for (int i = 0; i < titulos.Length; i++)
            {
                RectangleF celula = new RectangleF(
                    posicaoX,
                    posicaoY,
                    larguras[i],
                    alturaCabecalho
                );

                desenho.FillRectangle(Brushes.LightGray, celula);

                desenho.DrawRectangle(
                    Pens.Black,
                    celula.X,
                    celula.Y,
                    celula.Width,
                    celula.Height
                );

                desenho.DrawString(
                    titulos[i],
                    fonteCabecalho,
                    Brushes.Black,
                    new RectangleF(
                        celula.X + margemCelula,
                        celula.Y + margemCelula,
                        celula.Width - margemCelula * 2,
                        celula.Height - margemCelula * 2
                    ),
                    formatoCentro
                );

                posicaoX += larguras[i];
            }

            posicaoY += alturaCabecalho;

            float inicioDasLinhas = posicaoY;

            // Cada cadastro ocupa uma linha da tabela.
            while (indiceRegistro < registros.Count)
            {
                Cadastro cadastro = registros[indiceRegistro];

                string[] valores =
                {
                    cadastro.Id.ToString(),
                    cadastro.Nome,
                    cadastro.DataNascimento.ToString("dd/MM/yyyy"),
                    cadastro.Salario.ToString("C2", cultura),
                    cadastro.Cargo,
                    cadastro.Sexo,
                    cadastro.Beneficios
                };

                float alturaLinha = 26;

                // Usa a altura do maior conteúdo da linha.
                for (int i = 0; i < valores.Length; i++)
                {
                    StringFormat formato = i switch
                    {
                        0 or 2 => formatoCentro,
                        3 => formatoNumero,
                        _ => formatoTexto
                    };

                    SizeF tamanho = desenho.MeasureString(
                        valores[i],
                        fonteCelula,
                        new SizeF(
                            larguras[i] - margemCelula * 2,
                            10000
                        ),
                        formato
                    );

                    alturaLinha = Math.Max(
                        alturaLinha,
                        tamanho.Height + margemCelula * 2
                    );
                }

                // Evita criar páginas infinitas se uma linha não couber
                // nem mesmo em uma página nova.
                if (alturaLinha > limiteInferior - inicioDasLinhas)
                {
                    throw new InvalidOperationException(
                        "Uma linha do relatório ultrapassa a área disponível. " +
                        "Reduza os filtros exibidos, a fonte ou as margens."
                    );
                }

                if (posicaoY + alturaLinha > limiteInferior)
                    break;

                posicaoX = esquerda;

                for (int i = 0; i < valores.Length; i++)
                {
                    RectangleF celula = new RectangleF(
                        posicaoX,
                        posicaoY,
                        larguras[i],
                        alturaLinha
                    );

                    desenho.DrawRectangle(
                        Pens.Gray,
                        celula.X,
                        celula.Y,
                        celula.Width,
                        celula.Height
                    );

                    StringFormat formato = i switch
                    {
                        0 or 2 => formatoCentro,
                        3 => formatoNumero,
                        _ => formatoTexto
                    };

                    desenho.DrawString(
                        valores[i],
                        fonteCelula,
                        Brushes.Black,
                        new RectangleF(
                            celula.X + margemCelula,
                            celula.Y + margemCelula,
                            celula.Width - margemCelula * 2,
                            celula.Height - margemCelula * 2
                        ),
                        formato
                    );

                    posicaoX += larguras[i];
                }

                posicaoY += alturaLinha;
                indiceRegistro++;
            }

            // Rodapé.
            desenho.DrawString(
                $"Página {numeroPagina}",
                fonteRodape,
                Brushes.Black,
                esquerda,
                area.Bottom - 18
            );

            e.HasMorePages = indiceRegistro < registros.Count;
        };

        previa.Document = documento;
        previa.Text = "Prévia do relatório de cadastros";
        previa.StartPosition = FormStartPosition.CenterParent;
        previa.Width = 1000;
        previa.Height = 750;
        previa.UseAntiAlias = true;

        previa.ShowDialog(janelaDona);
    }

    private string MontarResumoFiltros(FiltroRelatorio filtro, List<string> cargosSelecionados)
    {
        List<string> partes = new List<string>();

        var cultura = CultureInfo.GetCultureInfo("pt-BR");

        if (filtro.IdInicial.HasValue)
            partes.Add($"ID de: {filtro.IdInicial.Value}");

        if (filtro.IdFinal.HasValue)
            partes.Add($"ID até: {filtro.IdFinal.Value}");

        if (!string.IsNullOrWhiteSpace(filtro.Nome))
            partes.Add($"Nome contém: {filtro.Nome}");

        if (filtro.NascimentoInicial.HasValue)
        {
            partes.Add(
                $"Nascimento de: {filtro.NascimentoInicial.Value:dd/MM/yyyy}"
            );
        }

        if (filtro.NascimentoFinal.HasValue)
        {
            partes.Add(
                $"Nascimento até: {filtro.NascimentoFinal.Value:dd/MM/yyyy}"
            );
        }

        if (filtro.SalarioMinimo.HasValue)
        {
            partes.Add(
                "Salário mínimo: " +
                filtro.SalarioMinimo.Value.ToString("C2", cultura)
            );
        }

        if (filtro.SalarioMaximo.HasValue)
        {
            partes.Add(
                "Salário máximo: " +
                filtro.SalarioMaximo.Value.ToString("C2", cultura)
            );
        }

        if (cargosSelecionados.Count > 0)
            partes.Add("Cargos: " + string.Join(", ", cargosSelecionados));

        if (filtro.Sexo != null)
            partes.Add($"Sexo: {filtro.Sexo}");

        if (filtro.ValeTransporte.HasValue)
        {
            partes.Add(
                "Vale-transporte: " +
                (filtro.ValeTransporte.Value ? "Possui" : "Não possui")
            );
        }

        if (filtro.ValeAlimentacao.HasValue)
        {
            partes.Add(
                "Vale-alimentação: " +
                (filtro.ValeAlimentacao.Value ? "Possui" : "Não possui")
            );
        }

        if (filtro.PlanoSaude.HasValue)
        {
            partes.Add(
                "Plano de saúde: " +
                (filtro.PlanoSaude.Value ? "Possui" : "Não possui")
            );
        }

        return partes.Count == 0
            ? "Filtros: nenhum — todos os cadastros."
            : "Filtros: " + string.Join(" | ", partes);
    }
}
