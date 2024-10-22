using AdvertisementApp.Business.Extensions;
using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos.Interfaces;
using AdvertisementApp.Entities;
using AutoMapper;
using Azure;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Services
{
    public class GenericService<CreateDto, UpdateDto, ListDto, T> : IGenericService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {

        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _updateDtoValidator;
        private readonly IUOW _uow;

        public GenericService(IMapper mapper, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator, IUOW uow)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
        }

        public async Task<IResponseData<CreateDto>> CreateAsync(CreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(dto);
                await _uow.GetRepository<T>().CreateAsync(createdEntity);
                await _uow.SaveChangesAsync();
                return new ResponseData<CreateDto>(ResponseType.Success, dto);
            }
            return new ResponseData<CreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public Task<IResponseData<List<ListDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResponseData<IDto>> GetByIdAsync<IDto>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseData<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
