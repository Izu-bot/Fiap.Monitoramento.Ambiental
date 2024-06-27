using AutoMapper;
using Fiap.Monitoramento.Ambiental.Controllers;
using Fiap.Monitoramento.Ambiental.Models;
using Fiap.Monitoramento.Ambiental.Services;
using Fiap.Monitoramento.Ambiental.VIewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Monitoramento.Ambiental.Test
{
    [TestFixture]
    public class ReturnStatusCode200
    {
        [Test]
        public async Task Desastres_Naturais_Return_Status_Code_200()
        {
            // Arrange - configuração dos objetos necessários para o teste
            // Configurando o mock de serviço
            var mockService = new Mock<IDesastresNaturaisService>();
            mockService.Setup(service => service.GetId(1)).Returns(new DesastresNaturaisModel());

            var mockMapper = new Mock<IMapper>(); // Configurando o mock para o IMapper

            // Instanciando a classe controller com os objetos mock
            var controller = new DesastresNaturaisController(mockService.Object, mockMapper.Object);

            // Act - execução do metodo a ser testado
            var resultado = await controller.Get(1); // Chamada do metodo Get passando o Id de um usuário

            // Assert - verificação dos resultados esperados
            var okResult = resultado.Result as OkObjectResult; // Verifica se o resultado é um OkObjectResult

            Assert.NotNull(okResult);// Verifica se não é nulo
            Assert.AreEqual(200, okResult.StatusCode); // Verifica se o StatusCode é igual a 200 (OK)
        }
    }
}