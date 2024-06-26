using Fiap.Monitoramento.Ambiental.Models.Enum;

namespace Fiap.Monitoramento.Ambiental.Models
{
    public class IrrigacaoModel
    {
        public int IrrigacaoId { get; set; }
        public QualidadeArEnum QualidadeAr { get; set; }
        public DateTime DataIrrigacao { get; set; }
        public string? Lugar { get; set; }

        // Referencia para classe MonitoraQualidadeArModel
        public int MonitoraQualidadeArId { get; set; }
        public MonitoraQualidadeArModel? MonitoraQualidadeArModel { get; set; }
    }
}
