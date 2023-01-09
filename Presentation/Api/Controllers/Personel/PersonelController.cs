using Application.Abstract.Services.Personel;
using Application.Abstract.Storage;
using Application.Models.Personel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Personel
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class PersonelController : ControllerBase
    {
        readonly IPersonelService _personelService;

        public PersonelController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

        [Route("get")]
        public async Task<IActionResult> GetAll()
        {
            var result = _personelService.GetAll();
            var d = result;
            return Ok(result);
        }

        [Route("getfilter")]
        public async Task<IActionResult> GetFilter()
        {
            var result = _personelService.GetFilterAll();
            return Ok(result);
        }

        [Route("put")]
        public async Task<IActionResult> Put(PersonelModel model)
        {
            var result = await _personelService.Update(model);
            return Ok(result);
        }

        [Route("post")]
        public async Task<IActionResult> Post(PersonelModel model)
        {   
            var result = await _personelService.Save(model);
            return Ok();
        }

        [Route("delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _personelService.Delete(id);
            return Ok(result);
        }   

        [Route("postimage")]
        public async Task<IActionResult> PostImage()
        {
            
            string pachAdres = "wwwroot/resource/personelforograf";
            if (!Directory.Exists(pachAdres))
                Directory.CreateDirectory(pachAdres);

            Random r = new();
            foreach (IFormFile file in Request.Form.Files) {
                string fullPath = Path.Combine(pachAdres, $"{r.Next()}{Path.GetExtension(file.FileName)}");
                using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync(); }
            return Ok();
        }
    }
}

