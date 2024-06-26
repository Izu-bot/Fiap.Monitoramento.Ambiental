namespace Fiap.Monitoramento.Ambiental.VIewModels
{
    public class MonitoraQualidadeArPaginacaoViewModel
    {
        public IEnumerable<MonitoraQualidadeArViewModel>? Monitora { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Monitora.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Monitora_Qualidade_Ar?pagina={CurrentPage - 1}&tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/Monitora_Qualidade_Ar?pagina={CurrentPage + 1}&tamanho={PageSize}" : "";
    }
}
