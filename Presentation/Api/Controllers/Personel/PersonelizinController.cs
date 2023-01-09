using Application.Abstract.Services.Personel;
using Application.Models.Personel;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Personel
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelizinController : ControllerBase
    {
        readonly IPersonelizinService _personelizinService;

        public PersonelizinController(IPersonelizinService personelizinService)
        {
            _personelizinService = personelizinService;
        }

        [Route("get")]
        public async Task<IActionResult> Get()
        {
            var result = _personelizinService.GetAllfilter();
            return Ok(result);
        }

        [Route("post")]
        public async Task<IActionResult> Post([FromBody] PersonelIzinModel value)
        {
            var result = await _personelizinService.Save(value);
            return Ok(result);
        }

        [Route("postlist")]
        public async Task<IActionResult> PostList([FromBody] PersonelIzinModel[] value)
        {
            var result = await _personelizinService.SaveList(value);
            return Ok(result);
        }

        [Route("put")]
        public async Task<IActionResult> Put([FromBody] PersonelIzinModel value)
        {
            var result = await _personelizinService.Update(value);
            return Ok(result);
        }
        
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _personelizinService.Delete(id);
            return Ok(result);
        }
    }
}
