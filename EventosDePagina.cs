using iTextSharp.text;
using iTextSharp.text.pdf;
using System;

namespace GeradorDeRelatoriosEmPDF
{
    class EventosDePagina : PdfPageEventHelper
    {
        private PdfContentByte wdc;

        private BaseFont fonteBaseRodape { get; set; }
        private iTextSharp.text.Font fonteRodape { get; set; }
        public int totalPaginas { get; set; }
        public EventosDePagina(int totalPaginas)
        {
            fonteBaseRodape = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            fonteRodape = new iTextSharp.text.Font(fonteBaseRodape, 8f, iTextSharp.text.Font.NORMAL, BaseColor.Black);
            this.totalPaginas = totalPaginas;
        }

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);
            this.wdc = writer.DirectContent;
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            AdicionarMomentoGeracaoRelatorio(writer, document);
            AdicionarNumerosDasPaginas(writer, document);
        }

        private void AdicionarMomentoGeracaoRelatorio(PdfWriter writer, Document document)
        {
            var textoMomentoGeracao = $"Gerado em {DateTime.Now.ToShortDateString()} às " + $"{DateTime.Now.ToShortDateString()}";

            wdc.BeginText(); // aqui eu inicio um texto
            wdc.SetFontAndSize(fonteRodape.BaseFont, fonteRodape.Size); // aqui determino a familia da fonte e o tamanho a ser usado
            wdc.SetTextMatrix(document.LeftMargin, document.BottomMargin * 0.75f); // aqui eu defino a posição em que ocorrera a escrita
            wdc.ShowText(textoMomentoGeracao); // mando mostrar o texto criado
            wdc.EndText(); // e finalizo o conteudo.
        }

        private void AdicionarNumerosDasPaginas(PdfWriter writer, Document document)
        {
            int paginaAtual = writer.PageNumber;
            var textoPaginacao = $"Página {paginaAtual} de {totalPaginas}";

            float larguraTextoPaginacao = fonteBaseRodape.GetWidthPoint(textoPaginacao, fonteRodape.Size);

            var tamanhoPagina = document.PageSize;

            wdc.BeginText(); // aqui eu inicio um texto
            wdc.SetFontAndSize(fonteRodape.BaseFont, fonteRodape.Size); // aqui determino a familia da fonte e o tamanho a ser usado
            wdc.SetTextMatrix(tamanhoPagina.Width - document.RightMargin - larguraTextoPaginacao, document.BottomMargin * 0.75f); // aqui eu defino a posição em que ocorrera a escrita
            wdc.ShowText(textoPaginacao); // mando mostrar o texto criado
            wdc.EndText(); // e finalizo o conteudo.
        }
    }
}
