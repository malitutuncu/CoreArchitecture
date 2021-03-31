using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Concrete;

namespace WebAPI.Abstract
{
   /* todo: Interface kaldırılacak baseController dahil edilecek
            Post, put, delete vs metodları aktif sekilde kullanılması yapılacak
   aaa
    */
    public interface ICrudController<TExtend, TTableItem>
    {
        [HttpGet]
        Task<IActionResult> GetList();

        [HttpGet("page={pageNumber}/size={pageSize}")]
        Task<IActionResult> GetList(int pageNumber, int pageSize);

        [HttpGet("{id}")]
        Task<IActionResult> GetById(int id);

        [HttpPost]
        Task<IActionResult> Add(TExtend dto);

        [HttpPut]
        Task<IActionResult> Update(TExtend dto);

        [HttpDelete("{id}")]
        Task<IActionResult> Delete(TExtend dto);


    }
}
