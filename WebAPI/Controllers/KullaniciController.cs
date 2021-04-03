using Business.Services.KullaniciService;
using Data.Extends;
using Data.Kullanici;
using Data.TableItem;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Abstract;
using WebAPI.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : BaseController, ICrudController<UserDetailDto, UserListItemDto>
    {
        private readonly IUserService _kullaniciService;

        public KullaniciController(IUserService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserDetailDto dto)
        {
            var response = await _kullaniciService.AddAsync(dto);
            if (!response.Success) return Error(response.Errors);
            return Success(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(UserDetailDto dto)
        {
            var response = await _kullaniciService.DeleteAsync(dto);
            if (!response.Success) return Error(response.Errors);
            return Success();

            var telefon = new Telefon();
            telefon.EkranBoyutu = 7;
            telefon.Marka = "Xiaomi";

            var telefonListesi = new List<Telefon>();

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
            var a = new UserListFilterDto();
            var response = await _kullaniciService.GetListAsync(a);
            if (!response.Success) return Error(response.Errors);
            return Success(response.Data);
        }

        [HttpGet("page={pageNumber}/size={pageSize}")]
        public async Task<IActionResult> GetList(int pageNumber, int pageSize)
        {
            var a = new UserListFilterDto();
            var response = await _kullaniciService.GetPagedListAsync(pageNumber, pageSize, a);

            if (!response.Success) return Error(response.Errors);
            return Success(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDetailDto dto)
        {
            var response = await _kullaniciService.UpdateAsync(dto);
            if (!response.Success) return Error(response.Errors);
            return Success();
        }
    }
}