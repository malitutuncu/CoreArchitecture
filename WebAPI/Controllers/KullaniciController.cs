using Business.Services.KullaniciService;
using Data.Extends;
using Data.Kullanici;
using Data.TableItem;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Abstract;
using WebAPI.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : BaseController, ICrudController<KullaniciUpsertDto, KullaniciTableItem>
    {
        private readonly IKullaniciService _kullaniciService;

        public KullaniciController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(KullaniciUpsertDto dto)
        {
            var response = await _kullaniciService.AddAsync(dto);
            if (!response.Success) return Error(response.Errors);
            return Success(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(KullaniciUpsertDto dto)
        {
            var response = await _kullaniciService.DeleteAsync(dto);
            if (!response.Success) return Error(response.Errors);
            return Success();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _kullaniciService.GetByIdAsync(id);
            if (!response.Success) return Error(response.Errors);
            return Success();
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var a = new KullaniciTableFilter();
            var response = await _kullaniciService.GetListAsync(a);
            if (!response.Success) return Error(response.Errors);
            return Success(response.Data);
        }

        [HttpGet("page={pageNumber}/size={pageSize}")]
        public async Task<IActionResult> GetList(int pageNumber, int pageSize)
        {
            var a = new KullaniciTableFilter();
            var response = await _kullaniciService.GetPagedListAsync(pageNumber, pageSize, a);

            if (!response.Success) return Error(response.Errors);
            return Success(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(KullaniciUpsertDto dto)
        {
            var response = await _kullaniciService.UpdateAsync(dto);
            if (!response.Success) return Error(response.Errors);
            return Success();
        }
    }
}