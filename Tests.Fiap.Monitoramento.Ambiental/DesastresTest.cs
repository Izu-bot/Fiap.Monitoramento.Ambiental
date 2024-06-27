using AutoMapper;
using Fiap.Monitoramento.Ambiental.Controllers;
using Fiap.Monitoramento.Ambiental.Data.Repository;
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
    public class DesastresTest
    {
        [Test]
        public async Task Desastres_Return_Status_Code_200()
        {
            // Arrange - Configuração dos objetos necessários para o teste
            var mockService = new Mock<IDesastresNaturaisService>();
            mockService.Setup(s => s.GetId(1)).Returns(new DesastresNaturaisModel());
            var mockMapper = new Mock<IMapper>();

            var controller = new DesastresNaturaisController(mockService.Object, mockMapper.Object); // Instanciação do controlador, passando o mock como serviço

            // Act - Execução do método a ser testado
            var resultador = await controller.Get(1); // Chamada do método Get do controlador e obtenção do resultado

            var okResult = resultador.Result as OkObjectResult; // Verifica se o resultado é um OkObjectResult

            // Assert - Verificação dos resultados esperados
            Assert.NotNull(okResult); // Verifica se não é nulo
            Assert.AreEqual(200, okResult.StatusCode); // Verifica se o status code é 200 (OK)
        }
    }
}