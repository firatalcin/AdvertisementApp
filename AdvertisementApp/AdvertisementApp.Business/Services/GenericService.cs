﻿using AdvertisementApp.Business.Extensions;
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

        public async Task<IResponseData<List<ListDto>>> GetAllAsync()
        {
            var data = await _uow.GetRepository<T>().GetAllAsync();
            var dto = _mapper.Map<List<ListDto>>(data);
            return new ResponseData<List<ListDto>>(ResponseType.Success, dto);  
        }

        public async Task<IResponseData<IDto>> GetByIdAsync<IDto>(int id)
        {
            var data = await _uow.GetRepository<T>().GetByFilterAsync(x => x.Id == id);
            if (data == null)
                return new ResponseData<IDto>(ResponseType.NotFound, $"{id} idsine sahip data bulunamadı");
            var dto = _mapper.Map<IDto>(data);
            return new ResponseData<IDto>(ResponseType.Success, dto);
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _uow.GetRepository<T>().FindAsync(id);
            if (data == null)
                return new AdvertisementApp.Common.Response(ResponseType.NotFound, $"{id} idsine sahip data bulunamadı");
            _uow.GetRepository<T>().Remove(data);
            await _uow.SaveChangesAsync();
            return new AdvertisementApp.Common.Response(ResponseType.Success);
        }

        public async Task<IResponseData<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var unchangedData = await _uow.GetRepository<T>().FindAsync(dto.Id);
                if (unchangedData == null)
                    return new ResponseData<UpdateDto>(ResponseType.NotFound, $"{dto.Id} idsine sahip data bulunamadı");
                var entity = _mapper.Map<T>(dto);
                _uow.GetRepository<T>().Update(entity, unchangedData);
                await _uow.SaveChangesAsync();
                return new ResponseData<UpdateDto>(ResponseType.Success, dto);
            }
            return new ResponseData<UpdateDto>(dto, result.ConvertToCustomValidationError());
        }
    }
}
