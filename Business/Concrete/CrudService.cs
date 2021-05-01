using AutoMapper;
using Business.Services.UserService.ValidationRules;
using Core.Business;
using Core.CrossCuttings.Validation;
using Core.Data;
using Core.DataAccess;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using DataAccess.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Concrete
{
    public class CrudService<TEntity, TExtendDto, TListItemDto, TListFilterDto> : BaseService ,
        ICrudService<TEntity, TExtendDto, TListItemDto, TListFilterDto>
        where TEntity : class, IEntity
        where TExtendDto : class 
    {

        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private IValidator _validator;

        public CrudService()
        {
            _mapper =ServiceTool.ServiceProvider.GetService<IMapper>();
            _uow = ServiceTool.ServiceProvider.GetService< IUnitOfWork>();
            _repository = _uow.GetRepository<TEntity>();
        }

        public async virtual Task<IDataResult<TExtendDto>> AddAsync(TExtendDto extEntity)
        {
            ValidationTool.Validate(_validator, extEntity);

            var entity = _mapper.Map<TEntity>(extEntity);
            var addedEntity = await _repository.AddAsync(entity);
            await _uow.CommitAsync();
            return Success(_mapper.Map<TExtendDto>(addedEntity));
        }

        public async virtual Task<IDataResult<TExtendDto>> UpdateAsync(TExtendDto extEntity)
        {
            var entity = _mapper.Map<TEntity>(extEntity);
            var updateEntity = await _repository.UpdateAsync(entity);
            await _uow.CommitAsync();
            return Success(_mapper.Map<TExtendDto>(updateEntity));
        }

        public async Task<IResult> DeleteAsync(TExtendDto extEntity)
        {
            var entity = _mapper.Map<TEntity>(extEntity);
            await Task.Run(() => { _repository.DeleteAsync(entity); });
            return Success();
        }

        public async virtual Task<IDataResult<IEnumerable<TListItemDto>>> GetListAsync(TListFilterDto filter)
        {
            return await BaseGetListAsync();
        }

        public async virtual Task<PagedResult<IEnumerable<TListItemDto>>> GetPagedListAsync(int pageNumber, int pageSize, TListFilterDto filter)
        {
            return await BaseGetPagedListAsync(pageNumber, pageSize);
        }

        public async Task<IDataResult<TExtendDto>> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _repository.GetAsync(expression);
            return Success(_mapper.Map<TExtendDto>(entity));
        }

        public async Task<IDataResult<TExtendDto>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return Success(_mapper.Map<TExtendDto>(entity));
        }

        public async Task<IDataResult<int>> GetCountAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            int count;

            if (expression == null)
                count = await _repository.GetCountAsync();
            else
                count = await _repository.GetCountAsync(expression);

            return Success(count);
        }

        protected async Task<IDataResult<IEnumerable<TListItemDto>>> BaseGetListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            IEnumerable<TEntity> entityList;
            if (expression == null)
                entityList = await _repository.GetListAsync();
            else
                entityList = await _repository.GetListAsync(expression);

            return Success(_mapper.Map<IEnumerable<TListItemDto>>(entityList));
        }

        protected async Task<PagedResult<IEnumerable<TListItemDto>>> BaseGetPagedListAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> expression = null)
        {
            var response = await _repository.GetPagedListAsync(pageNumber, pageSize, expression);

            var totalCount = response.Item2;
            var list = _mapper.Map<IEnumerable<TListItemDto>>(response.Item1);

            return new PagedResult<IEnumerable<TListItemDto>>(list, totalCount, pageNumber, pageSize);
        }

      
    }
}