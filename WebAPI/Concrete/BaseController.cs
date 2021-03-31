using Business.Concrete;
using Core.Business;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Concrete
{
    [ApiController]

    //todo: generic sekilde tip alınacak 
    //todo: autherization : jwt token cok uzun oldugunda hataya sebebiyet veriyor. bunun icin bi cozum uretılmeli
    //todo: rol-yetki sistemi dınamik olmalı hem metod uzerinde hem metod icerinde kolayca ulasılabilmeli
    //todo: sistem sabitleri yada az kullanılan datalar icin cache mekanizmasında tutulacak bir yapı olmalı(redis,memcache)
    /*todo: multiple dil eklenecek normal translete
    {
        normal translate
        field translate
        urun - urun adı coklu dil kayıt - tablo yaklasımı yada adını dil bazlı json olarak kolonda tutma
    }
    */
    //todo: swagger eklenecek
    //todo: open api eklenecek - istenen alanları yollaması 
    //todo: automapper detaylandırılacak
    //todo: hangfire eklenecek
    //todo: db -> stored procedure, view , trigger sorulacak
    //todo: code first - auto migration vs custom migration
    //caching
    public class BaseController : ControllerBase 
    {
        //private IBaseService<Type,Type,Type> _service;

        //public BaseController(Type serviceType)
        //{
        //    var entityType = serviceType.BaseType.GetGenericArguments()[0];
        //    var extType = serviceType.BaseType.GetGenericArguments()[1];
        //    var tableItemType = serviceType.BaseType.GetGenericArguments()[2];
        //    _service = (IBaseService<entityType,extType, tableItemType>)Activator.CreateInstance(serviceType);

        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var persons = await _service.GetListAsync();
        //    return Ok(persons);
        //}

        [NonAction]
        protected IActionResult Success()
        {
            var result = new Result();
            return Ok(result.SuccesResult());
        }

        [NonAction]
        protected IActionResult Success<T>(T data)
        {
            var result = new DataResult<T>();
          
            //var settings =  new JsonSerializerSettings()
            //{
            //    NullValueHandling = NullValueHandling.Ignore
            //};
           // return Ok(JsonConvert.SerializeObject(result.SuccesResult(data), settings));

            return Ok(result.SuccesResult(data));
        }

        [NonAction]
        protected IActionResult Success<T>(PagedResult<T> pagedResult)
        {
            return Ok(pagedResult);
        }

        

        [NonAction]
        protected IActionResult Error(List<string> errors)
        {
            var result = new Result();
            return Ok(result.ErrorResult(errors));
        }

    }
}
