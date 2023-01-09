using Application.Abstract.Services.Personel;
using Application.Models.Personel;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Personel
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelMaasController : ControllerBase
    {
        readonly IPersonelMaasService _personelMaasService;

        public PersonelMaasController(IPersonelMaasService personelMaasService)
        {
            _personelMaasService = personelMaasService;
        }

        [Route("get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = _personelMaasService.GetAllFilter(id);
            return Ok(result);
        }

        //[Route("putlist")]
        //public async Task<IActionResult> PutList(PersonelMaasHesaplaModel[] model)
        //{
        //    var result = await _personelMaasService.UpdateList(model);
        //    return Ok(result);
        //}

        [Route("post")]
        public async Task<IActionResult> Post(PersonelMaasHesaplaModel model)
        {
            return Ok();
        }

    }
}
