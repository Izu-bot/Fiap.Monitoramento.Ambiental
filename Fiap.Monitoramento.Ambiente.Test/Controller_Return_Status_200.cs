using Fiap.Monitoramento.Ambiental.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Monitoramento.Ambiente.Test
{
    public class Controller_Return_Status_200
    {
        [Fact]
        public async Task Desastres_Naturais_Return_Status_Code_200()
        {
            // Arrange
            var mockService = new Mock<IDesastresNaturaisService>(); // Criação para o mock da interface de serviço
            mockService.Setup(service => service.GetAllPaginable()).ReturnsAsync
        }
    }
}


