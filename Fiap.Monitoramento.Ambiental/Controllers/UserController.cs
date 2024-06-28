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
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [MapToApiVersion(1)]
        [HttpGet]
        [Authorize(Roles = "Admin,Gerente")]
        public ActionResult<IEnumerable<UserViewModel>> Get()
        {
            var user = _service.GetAll();
            var viewModelList = _mapper.Map<IEnumerable<UserViewModel>>(user);

            return Ok(viewModelList);
        }

        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Gerente")]
        public ActionResult<UserViewModel> Get(int id)
        {
            var user = _service.GetById(id);
            if (user == null)
                return NotFound();

            var viewModel = _mapper.Map<UserViewModel>(user);
            return Ok(viewModel);
        }

        [MapToApiVersion(1)]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] UserCreateViewModel user)
        {
            var usuario = _mapper.Map<UserModel>(user);
            _service.Add(usuario);

            return CreatedAtAction(nameof(Get), new { id = usuario.UserId }, usuario);
        }


        [MapToApiVersion(1)]
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Gerente")]
        public ActionResult Put(int id, [FromBody] UserViewModel user)
        {
            var usuario = _service.GetById(id);
            if (usuario == null)
                return NoContent();

            _mapper.Map(user, usuario);
            _service.Update(usuario);

            return NoContent();
        }

        [MapToApiVersion(1)]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Gerente")]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
