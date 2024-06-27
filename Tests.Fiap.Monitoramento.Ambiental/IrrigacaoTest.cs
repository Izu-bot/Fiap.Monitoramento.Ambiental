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
    public class IrrigacaoTest
    {
        [Test]
        public async Task Irrigacao_Return_Status_Code_200()
        {
            // Arrange
            var mockService = new Mock<IIrrigacaoService>();
            mockService.Setup(s => s.Get(5)).Returns(new IrrigacaoModel());
            var mockMapper = new Mock<IMapper>();

            var controller = new IrrigacaoController(mockService.Object, mockMapper.Object);

            // Act
            var resultador = await controller.GetId(5);

            var okResult = resultador.Result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
