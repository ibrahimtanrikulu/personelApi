using Application.Abstract.Services.Departman;
using Application.Models.Departman;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Departman
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class DepartmanController : ControllerBase
    {
        private readonly IDepartmanService _departmanService;

        public DepartmanController(IDepartmanService departmanService)
        {
            _departmanService = departmanService;
        }

        [Route("get")]
        public async Task<IActionResult> Get()
        {
            var result = _departmanService.GetAll();
            var deger = result;
            return Ok(result);
        }

        [Route("post")]
        public async Task<IActionResult> Post(DepartmanModel model)
        {
            var result = await _departmanService.Save(model);
            return Ok(result);
        }

        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _departmanService.Delete(id);
            return Ok(result);
        }

        [Route("put")]
        public async Task<IActionResult> Put([FromBody] DepartmanModel model)
        {
            var result = await _departmanService.Update(model);
            return Ok(result);
        }
    }
}
