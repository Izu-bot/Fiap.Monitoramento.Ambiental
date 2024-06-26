using Fiap.Monitoramento.Ambiental.Models.Enum;

namespace Fiap.Monitoramento.Ambiental.Models
{
    public class MonitoraQualidadeArModel
    {
        public int MonitorarId { get; set; }
        public DateTime DiaMonitoracao { get; set; }
        public QualidadeArEnum Qualidade { get; set; }
    }
}
