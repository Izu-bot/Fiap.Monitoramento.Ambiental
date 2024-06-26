﻿using Fiap.Monitoramento.Ambiental.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fiap.Monitoramento.Ambiental.Models
{
    public class MonitoraQualidadeArModel
    {
        public int MonitorarId { get; set; }
        public DateTime DiaMonitoracao { get; set; }
        public QualidadeArEnum Qualidade { get; set; }
    }
}
