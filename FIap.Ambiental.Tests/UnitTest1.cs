using AutoMapper;
using Fiap.Monitoramento.Ambiental.Controllers;
using Fiap.Monitoramento.Ambiental.Models;
using Fiap.Monitoramento.Ambiental.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FIap.Ambiental.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
                // Arrange - configura��o dos objetos necess�rios para o teste
                // Configurando o mock de servi�o
                var mockService = new Mock<IDesastresNaturaisService>();
                mockService.Setup(service => service.GetId(1)).Returns(new DesastresNaturaisModel());

                var mockMapper = new Mock<IMapper>(); // Configurando o mock para o IMapper

                // Instanciando a classe controller com os objetos mock
                var controller = new DesastresNaturaisController(mockService.Object, mockMapper.Object);

                // Act - execu��o do metodo a ser testado
                var resultado = controller.Get(1); // Chamada do metodo Get passando o Id de um usu�rio

                // Assert - verifica��o dos resultados esperados
                Assert.NotNull(resultado.Result);// Verifica se n�o � nulo

                Assert.IsType<OkObjectResult>(resultado.Result); // Verifica se o resultado.Result e do tipo OkObjectResut
                
                var okObjectResult = resultado.Result as OkObjectResult; // Atribui a referencia a okObjectResult

                Assert.Equal(200, okObjectResult.StatusCode); // Verifica se o StatusCode � igual a 200 (OK)
        }
    }
}