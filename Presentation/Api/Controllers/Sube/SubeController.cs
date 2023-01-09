using Application.Abstract.Services;
using Application.Models.Sube;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Sube
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class SubeController : ControllerBase
    {
        private readonly ISubeService _subeService;

        public SubeController(ISubeService subeService)
        {
            _subeService = subeService;
        }

        [Route("get")]
        public async Task<IActionResult> Get()
        {
            var result = _subeService.GetAll();
            var deger = result;
            return Ok(result);
        }

        [Route("post")]
        public async Task<IActionResult> Post(SubeModel model)
        {
            var result = await _subeService.Save(model);
            return Ok(result);
        }

        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _subeService.Delete(id);
            return Ok(result);
        }

        [Route("put")]
        public async Task<IActionResult> Put([FromBody] SubeModel model)
        {
            var result = await _subeService.Update(model);
            return Ok(result);
        }
    }
}
