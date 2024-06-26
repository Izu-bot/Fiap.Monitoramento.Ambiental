using Fiap.Monitoramento.Ambiental.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fiap.Monitoramento.Ambiental.VIewModels
{
    public class MonitoraQualidadeArCreateViewModel
    {
        public DateTime DiaMonitoracao { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(QualidadeArEnum))]
        public QualidadeArEnum Qualidade { get; set; }
    }
}
