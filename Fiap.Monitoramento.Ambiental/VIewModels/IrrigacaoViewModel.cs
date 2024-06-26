using Fiap.Monitoramento.Ambiental.Models.Enum;

namespace Fiap.Monitoramento.Ambiental.VIewModels
{
    public class IrrigacaoViewModel
    {
        public int IrrigacaoId { get; set; }
        public QualidadeArEnum QualidadeAr { get; set; }
        public DateTime DataIrrigacao { get; set; }
        public string? Lugar { get; set; }
        public int MonitoraQualidadeArId { get; set; }
    }
}
