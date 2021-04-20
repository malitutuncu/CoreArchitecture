using AutoMapper;
using Business.Services.UserService.ValidationRules;
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
    public class CrudService<TEntity, TExtendDto, TListItemDto, TListFilterDto> :
        ICrudService<TEntity, TExtendDto, TListItemDto, TListFilterDto>
        where TEntity : class, IEntity
        where TExtendDto : class
    {
        private readonly IUnitOfWork<TEntity> _uow;
        private readonly IMapper _mapper;

        private static Type UpsertValidatorType;
        private IValidator _validator;

        public CrudService(IUnitOfWork<TEntity> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
            // _validator = TUpsertValidator; //new UserAddOrEditValidator();

            UpsertValidatorType = typeof(UserAddOrEditValidator);//GetType().GetGenericArguments()[0];
            //var str = "Product.List"
        }

        public async virtual Task<IDataResult<TExtendDto>> AddAsync(TExtendDto extEntity)
        {
            ValidationTool.Validate(_validator, extEntity);

            var entity = _mapper.Map<TEntity>(extEntity);
            var addedEntity = await _uow.Repository.AddAsync(entity);
            await _uow.CommitAsync();
            return Success(_mapper.Map<TExtendDto>(addedEntity));
        }

        public async virtual Task<IDataResult<TExtendDto>> UpdateAsync(TExtendDto extEntity)
        {
            var entity = _mapper.Map<TEntity>(extEntity);
            var updateEntity = await _uow.Repository.UpdateAsync(entity);
            await _uow.CommitAsync();
            return Success(_mapper.Map<TExtendDto>(updateEntity));
        }

        public async Task<IResult> DeleteAsync(TExtendDto extEntity)
        {
            var entity = _mapper.Map<TEntity>(extEntity);
            await Task.Run(() => { _uow.Repository.DeleteAsync(entity); });
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
            var entity = await _uow.Repository.GetAsync(expression);
            return Success(_mapper.Map<TExtendDto>(entity));
        }

        public async Task<IDataResult<TExtendDto>> GetByIdAsync(int id)
        {
            var entity = await _uow.Repository.GetByIdAsync(id);
            return Success(_mapper.Map<TExtendDto>(entity));
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

        protected async Task<IDataResult<IEnumerable<TListItemDto>>> BaseGetListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            IEnumerable<TEntity> entityList;
            if (expression == null)
                entityList = await _uow.Repository.GetListAsync();
            else
                entityList = await _uow.Repository.GetListAsync(expression);

            return Success(_mapper.Map<IEnumerable<TListItemDto>>(entityList));
        }

        protected async Task<PagedResult<IEnumerable<TListItemDto>>> BaseGetPagedListAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> expression = null)
        {
            var response = await _uow.Repository.GetPagedListAsync(pageNumber, pageSize, expression);

            var totalCount = response.Item2;
            var list = _mapper.Map<IEnumerable<TListItemDto>>(response.Item1);

            return new PagedResult<IEnumerable<TListItemDto>>(list, totalCount, pageNumber, pageSize);
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