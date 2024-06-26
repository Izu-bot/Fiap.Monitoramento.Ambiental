﻿using Asp.Versioning;
using AutoMapper;
using Fiap.Monitoramento.Ambiental.Models;
using Fiap.Monitoramento.Ambiental.Services;
using Fiap.Monitoramento.Ambiental.VIewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Monitoramento.Ambiental.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class MonitoraQualidadeArController : ControllerBase
    {
        private readonly IMonitoraQualidadeArService _service;
        private readonly IMapper _mapper;

        public MonitoraQualidadeArController(IMonitoraQualidadeArService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [MapToApiVersion(1)]
        [HttpGet]
        public ActionResult<IEnumerable<MonitoraQualidadeArPaginacaoViewModel>> Get([FromQuery]int page = 1, [FromQuery] int pageSize = 10)
        {
            var monitorar = _service.GetAll(page, pageSize);
            var viewModelList = _mapper.Map<IEnumerable<MonitoraQualidadeArViewModel>>(monitorar);

            var viewModel = new MonitoraQualidadeArPaginacaoViewModel
            {
                Monitora = viewModelList,
                CurrentPage = page,
                PageSize = pageSize
            };

            return Ok(viewModel);
        }

        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        public ActionResult<MonitoraQualidadeArViewModel> Get(int id)
        {
            var monitoramento = _service.GetId(id);
            if (monitoramento == null)
                NotFound();

            var viewModel = _mapper.Map<MonitoraQualidadeArModel>(monitoramento);

            return Ok(viewModel);
        }

        [MapToApiVersion(1)]
        [HttpPost]
        public ActionResult Post([FromBody] MonitoraQualidadeArCreateViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var monitoramento = _mapper.Map<MonitoraQualidadeArModel>(viewModel);
            _service.Add(monitoramento);

            return CreatedAtAction(nameof(Get), new { id = monitoramento.MonitorarId }, monitoramento);
        }

        [MapToApiVersion(1)]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MonitoraQualidadeArViewModel model)
        {
            var monitorar = _service.GetId(id);
            if(monitorar == null)
                return NotFound();

            _mapper.Map(model, monitorar);
            _service.Update(monitorar);

            return NoContent();
        }

        [MapToApiVersion(1)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var monitorar = _service.GetId(id);
            if (monitorar == null)
                NotFound();

            _service.Delete(monitorar.MonitorarId);
            return NoContent();
        }
    }
}