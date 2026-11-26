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
    using var fonteTexto = new Font("Arial", 10);
    using var fonteRodape = new Font("Arial", 9);

    var cultura = CultureInfo.GetCultureInfo("pt-BR");

    int indiceRegistro = 0;
    int numeroPagina = 0;

    DateTime emissao = DateTime.Now;

    documento.DocumentName = "Relatório de cadastros";

    // Margens em centésimos de polegada.
    documento.DefaultPageSettings.Margins =
        new Margins(60, 60, 60, 60);

    // Reinicia a contagem ao gerar a prévia ou imprimir.
    documento.BeginPrint += (sender, e) =>
    {
        indiceRegistro = 0;
        numeroPagina = 0;
    };

    string resumoFiltros =
        MontarResumoFiltros(filtro, cargosSelecionados);

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

        // Cabeçalho repetido em cada página.
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

        // Reserva espaço para o rodapé.
        float limiteInferior = area.Bottom - 30;

        while (indiceRegistro < registros.Count)
        {
            Cadastro cadastro = registros[indiceRegistro];

            string texto =
                $"ID: {cadastro.Id}\n" +
                $"Nome: {cadastro.Nome}\n" +
                $"Nascimento: {cadastro.DataNascimento:dd/MM/yyyy}\n" +
                $"Salário: {cadastro.Salario.ToString("C2", cultura)}\n" +
                $"Cargo: {cadastro.Cargo}\n" +
                $"Sexo: {cadastro.Sexo}\n" +
                $"Benefícios: {cadastro.Beneficios}";

            SizeF tamanho = desenho.MeasureString(
                texto,
                fonteTexto,
                new SizeF(largura, 10000)
            );

            float alturaRegistro = tamanho.Height + 20;

            // Deixa o cadastro inteiro para a próxima página.
            if (posicaoY + alturaRegistro > limiteInferior)
            {
                e.HasMorePages = true;
                break;
            }

            desenho.DrawString(
                texto,
                fonteTexto,
                Brushes.Black,
                new RectangleF(
                    esquerda,
                    posicaoY,
                    largura,
                    tamanho.Height + 2
                )
            );

            posicaoY += tamanho.Height + 8;

            desenho.DrawLine(
                Pens.LightGray,
                esquerda,
                posicaoY,
                area.Right,
                posicaoY
            );

            posicaoY += 12;
            indiceRegistro++;
        }

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
