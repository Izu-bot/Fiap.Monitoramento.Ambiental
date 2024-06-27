namespace Fiap.Monitoramento.Ambiental.VIewModels
{
    public class IrrigacaoPaginacaoViewModel
    {
        public IEnumerable<IrrigacaoViewModel>? Irrigacao { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Irrigacao.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Irrigacao?pagina={CurrentPage - 1}&tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/Irrigacao?pagina={CurrentPage + 1}&tamanho={PageSize}" : "";
    }
}
