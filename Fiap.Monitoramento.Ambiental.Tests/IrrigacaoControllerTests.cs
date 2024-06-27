//using AutoMapper;
//using Fiap.Monitoramento.Ambiental.Controllers;
//using Fiap.Monitoramento.Ambiental.Models;
//using Fiap.Monitoramento.Ambiental.Services;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Fiap.Monitoramento.Ambiental.Tests
//{
//    public class IrrigacaoControllerTests
//    {
//        [Fact]
//        public async Task Irrigacao_Get_Return_Status_Code_200()
//        {
//            var mockService = new Mock<IIrrigacaoService>();
//            mockService.Setup(service => service.Get(1)).Returns(new IrrigacaoModel());
//            var mockMapper = new Mock<IMapper>();

//            var controller = new IrrigacaoController(mockService.Object, mockMapper.Object);

//            var resultado = await controller.GetId(1);

//            var okResult = resultado.Result as OkObjectResult;

//            Assert.NotNull(okResult);
//            Assert.Equal(200, okResult.StatusCode);
//        }
//    }
//}
