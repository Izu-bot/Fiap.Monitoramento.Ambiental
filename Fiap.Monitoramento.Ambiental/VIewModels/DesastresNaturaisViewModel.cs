namespace Fiap.Monitoramento.Ambiental.VIewModels
{
    public class DesastresNaturaisViewModel
    {
        public int DesastreId { get; set; }
        public string? TipoDesastre { get; set; }
        public string? Lugar { get; set; }
        public DateTime? Data { get; set; }
        public bool Resolvido { get; set; }
    }
}
