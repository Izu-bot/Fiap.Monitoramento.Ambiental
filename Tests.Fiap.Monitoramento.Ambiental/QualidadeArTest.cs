using AutoMapper;
using Fiap.Monitoramento.Ambiental.Controllers;
using Fiap.Monitoramento.Ambiental.Models;
using Fiap.Monitoramento.Ambiental.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Fiap.Monitoramento.Ambiental
{
    [TestFixture]
    public class QualidadeArTest
    {
        [Test]
        public async Task Qualidade_Ar_Return_Status_Code_200()
        {
            // Arrange
            var mockService = new Mock<IMonitoraQualidadeArService>();
            mockService.Setup(s => s.GetId(1)).Returns(new MonitoraQualidadeArModel());
            var mockMapper = new Mock<IMapper>();

            var controller = new MonitoraQualidadeArController(mockService.Object, mockMapper.Object);

            // Act
            var resultador = await controller.Get(1);

            var okResult = resultador.Result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
