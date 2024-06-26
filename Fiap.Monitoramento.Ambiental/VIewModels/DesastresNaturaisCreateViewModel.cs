namespace Fiap.Monitoramento.Ambiental.VIewModels
{
    public class DesastresNaturaisCreateViewModel
    {
        public string? TipoDesastre { get; set; }
        public string? Lugar { get; set; }
        public DateTime? Data { get; set; }
        public bool Resolvido { get; set; }
    }
}
