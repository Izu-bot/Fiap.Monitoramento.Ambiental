using Asp.Versioning;
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
    public class IrrigacaoController : ControllerBase
    {
        private readonly IIrrigacaoService _service;
        private readonly IMapper _mapper;

        public IrrigacaoController(IIrrigacaoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [MapToApiVersion(1)]
        [HttpGet]
        public ActionResult<IEnumerable<IrrigacaoPaginacaoViewModel>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var irrigacao = _service.GetAll(page, pageSize);
            var viewModelList = _mapper.Map<IEnumerable<IrrigacaoViewModel>>(irrigacao);

            var viewModel = new IrrigacaoPaginacaoViewModel
            {
                Irrigacao = viewModelList,
                CurrentPage = page,
                PageSize = pageSize
            };

            return Ok(viewModel);
        }

        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        public ActionResult<IrrigacaoViewModel> GetId(int id)
        {
            var irrigacao = _service.Get(id);
            if(irrigacao == null)
                NoContent();

            var viewModel = _mapper.Map<IrrigacaoViewModel>(irrigacao);
            return Ok(viewModel);
        }

        [MapToApiVersion(1)]
        [HttpPost]
        public ActionResult Post([FromBody] IrrigacaoCreateViewModel model)
        {
            var irrigacao = _mapper.Map<IrrigacaoModel>(model);
            _service.Add(irrigacao);

            return CreatedAtAction(nameof(Get), new { id = irrigacao.IrrigacaoId}, irrigacao);
        }

        [MapToApiVersion(1)]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] IrrigacaoViewModel model)
        {
            var irrigacao = _service.Get(id);
            if(irrigacao == null)
                return NoContent();

            _mapper.Map(model, irrigacao);
            _service.Update(irrigacao);

            return NoContent();
        }

        [MapToApiVersion(1)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
