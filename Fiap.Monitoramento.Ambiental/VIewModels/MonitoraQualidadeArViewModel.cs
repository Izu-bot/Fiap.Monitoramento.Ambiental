using Fiap.Monitoramento.Ambiental.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fiap.Monitoramento.Ambiental.VIewModels
{
    public class MonitoraQualidadeArViewModel
    {
        public int MonitorarId { get; set; }
        public DateTime DiaMonitoracao { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(QualidadeArEnum))]
        public QualidadeArEnum Qualidade { get; set; }
    }
}
