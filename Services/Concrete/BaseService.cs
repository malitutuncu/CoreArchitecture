using AutoMapper;
using Business.Services.KullaniciService.ValidationRules;
using Core.Business;
using Core.CrossCuttings.Validation;
using Core.Data;
using Core.Utilities.Results;
using DataAccess.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BaseService<TEntity, TExtend, TTableItem, TListFilter, TUpsertValidator> :
        IBaseService<TEntity, TExtend, TTableItem, TListFilter>
        where TEntity : class, IEntity
        where TExtend : class
    {
        private readonly IUnitOfWork<TEntity> _uow;
        private readonly IMapper _mapper;

        private static Type UpsertValidatorType;
        private IValidator _validator;

        public BaseService(IUnitOfWork<TEntity> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
            // _validator = TUpsertValidator; //new KullaniciUpsertValidator();

            UpsertValidatorType = typeof(KullaniciUpsertValidator);//GetType().GetGenericArguments()[0];
            //var str = "Product.List"
        }

        public async virtual Task<IDataResult<TExtend>> AddAsync(TExtend extEntity)
        {
            ValidationTool.Validate(_validator, extEntity);

            var entity = _mapper.Map<TEntity>(extEntity);
            var addedEntity = await _uow.Repository.AddAsync(entity);
            await _uow.CommitAsync();
            return Success(_mapper.Map<TExtend>(addedEntity));
        }

        public async virtual Task<IDataResult<TExtend>> UpdateAsync(TExtend extEntity)
        {
            var entity = _mapper.Map<TEntity>(extEntity);
            var updateEntity = await _uow.Repository.UpdateAsync(entity);
            await _uow.CommitAsync();
            return Success(_mapper.Map<TExtend>(updateEntity));
        }

        public async Task<IResult> DeleteAsync(TExtend extEntity)
        {
            var entity = _mapper.Map<TEntity>(extEntity);
            await Task.Run(() => { _uow.Repository.DeleteAsync(entity); });
            return Success();
        }

        public async virtual Task<IDataResult<IEnumerable<TTableItem>>> GetListAsync(TListFilter filter)
        {
            return await BaseGetListAsync();
        }

        public async virtual Task<PagedResult<IEnumerable<TTableItem>>> GetPagedListAsync(int pageNumber, int pageSize, TListFilter filter)
        {
            return await BaseGetPagedListAsync(pageNumber, pageSize);
        }

        public async Task<IDataResult<TExtend>> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _uow.Repository.GetAsync(expression);
            return Success(_mapper.Map<TExtend>(entity));
        }

        public async Task<IDataResult<TExtend>> GetByIdAsync(int id)
        {
            var entity = await _uow.Repository.GetByIdAsync(id);
            return Success(_mapper.Map<TExtend>(entity));
        }

        public async Task<IDataResult<int>> GetCountAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            int count;

            if (expression == null)
                count = await _uow.Repository.GetCountAsync();
            else
                count = await _uow.Repository.GetCountAsync(expression);

            return Success(count);
        }

        protected async Task<IDataResult<IEnumerable<TTableItem>>> BaseGetListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            IEnumerable<TEntity> entityList;
            if (expression == null)
                entityList = await _uow.Repository.GetListAsync();
            else
                entityList = await _uow.Repository.GetListAsync(expression);

            return Success(_mapper.Map<IEnumerable<TTableItem>>(entityList));
        }

        protected async Task<PagedResult<IEnumerable<TTableItem>>> BaseGetPagedListAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> expression = null)
        {
            var response = await _uow.Repository.GetPagedListAsync(pageNumber, pageSize, expression);

            var totalCount = response.Item2;
            var list = _mapper.Map<IEnumerable<TTableItem>>(response.Item1);

            return new PagedResult<IEnumerable<TTableItem>>(list, totalCount, pageNumber, pageSize);
        }

        public IResult Success()
        {
            var result = new Result();
            return result.SuccesResult();
        }

        public IDataResult<T> Success<T>(T data)
        {
            var result = new DataResult<T>();
            return result.SuccesResult(data);
        }

        public IResult Error(string mesaj)
        {
            var result = new Result();
            return result.ErrorResult(mesaj);
        }
    }
}