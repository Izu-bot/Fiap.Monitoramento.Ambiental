namespace Fiap.Monitoramento.Ambiental.Models
{
    public class MonitoraQualidadeAr
    {
        public int MonitorarId { get; set; }
        public DateTime DiaMonitoracao { get; set; }
        public string? Qualidade { get; set; }
    }
}
