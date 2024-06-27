using Asp.Versioning;
using AutoMapper;
using Fiap.Monitoramento.Ambiental.Models;
using Fiap.Monitoramento.Ambiental.Services;
using Fiap.Monitoramento.Ambiental.VIewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Monitoramento.Ambiental.Controllers
{
    [Authorize]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class DesastresNaturaisController : ControllerBase
    {
        private readonly IDesastresNaturaisService _service;
        private readonly IMapper _mapper;

        public DesastresNaturaisController(IDesastresNaturaisService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [MapToApiVersion(1)]
        [HttpGet]
        public ActionResult<IEnumerable<DesastresPaginacaoViewModel>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var desastros = _service.GetAllPaginable(page, pageSize);
            var viewModelList = _mapper.Map<IEnumerable<DesastresNaturaisViewModel>>(desastros);

            var viewModel = new DesastresPaginacaoViewModel
            {
                Desastros = viewModelList,
                CurrentPage = page,
                PageSize = pageSize
            };

            return Ok(viewModel);
        }

        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        public ActionResult<DesastresNaturaisViewModel> Get(int id)
        {
            var desastre = _service.GetId(id);
            if(desastre == null)
                return NotFound();

            var viewModel = _mapper.Map<DesastresNaturaisViewModel>(desastre);
            return Ok(viewModel);
            
        }

        [MapToApiVersion(1)]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]  DesastresNaturaisViewModel model)
        {
            var desastreExistente = _service.GetId(id);
            if (desastreExistente == null)
                return NotFound();

            _mapper.Map(model, desastreExistente);
            _service.Update(desastreExistente);

            return NoContent();
        }

        [MapToApiVersion(1)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [MapToApiVersion(1)]
        [HttpPost]
        public ActionResult Post([FromBody]  DesastresNaturaisCreateViewModel viewModel)
        {
            var desastre = _mapper.Map<DesastresNaturaisModel>(viewModel);
            _service.Add(desastre);

            return CreatedAtAction(nameof(Get), new {id = desastre.DesastreId}, desastre);
        }
    }
}
