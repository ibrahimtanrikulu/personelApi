using Application.Abstract.Services.Departman;
using Application.Models.Departman;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Departman
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmanrolController : ControllerBase
    {
        private readonly IDepartmanRolService _departmanRolService;

        public DepartmanrolController(IDepartmanRolService departmanRolService)
        {
            _departmanRolService = departmanRolService;
        }

        [Route("get")]
        public async Task<IActionResult> Get()
        {
            var result = _departmanRolService.GetAll();
            return Ok(result);
        }

        [Route("post")]
        public async Task<IActionResult> Post(DepartmanRolModel model)
        {
            var result = await _departmanRolService.Save(model);
            return Ok(result);
        }

        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _departmanRolService.Delete(id);
            return Ok(result);
        }

        [Route("put")]
        public async Task<IActionResult> Put([FromBody] DepartmanRolModel model)
        {
            var result = await _departmanRolService.Update(model);
            return Ok(result);
        }
    }
}
