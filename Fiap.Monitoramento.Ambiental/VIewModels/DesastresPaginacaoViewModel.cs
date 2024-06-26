    namespace Fiap.Monitoramento.Ambiental.VIewModels
{
    public class DesastresPaginacaoViewModel
    {
        public IEnumerable<DesastresNaturaisViewModel>? Desastros { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Desastros.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/DesastresNaturais?pagina={CurrentPage - 1}&tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/DesastresNaturais?pagina={CurrentPage + 1}&tamanho={PageSize}" : "";
    }
}
