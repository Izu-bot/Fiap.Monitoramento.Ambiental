﻿using Fiap.Monitoramento.Ambiental.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fiap.Monitoramento.Ambiental.VIewModels
{
    public class IrrigacaoViewModel
    {
        public int IrrigacaoId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(QualidadeArEnum))]
        public QualidadeArEnum QualidadeAr { get; set; }
        public DateTime DataIrrigacao { get; set; }
        public string? Lugar { get; set; }
        public int MonitoraQualidadeArId { get; set; }
    }
}
