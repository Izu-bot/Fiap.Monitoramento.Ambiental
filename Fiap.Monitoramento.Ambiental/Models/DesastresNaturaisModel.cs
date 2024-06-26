namespace Fiap.Monitoramento.Ambiental.Models
{
    public class DesastresNaturaisModel
    {
        public int DesastreId { get; set; }
        public string? TipoDesastre { get; set; }
        public string? Lugar {  get; set; }
        public DateTime? Data {  get; set; }
        public bool Resolvido { get; set; }
    }
}
