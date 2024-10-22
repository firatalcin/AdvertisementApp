using AdvertisementApp.Common;
using AdvertisementApp.Dtos.Interfaces;
using AdvertisementApp.Entities;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IGenericService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        Task<IResponseData<CreateDto>> CreateAsync(CreateDto dto);
        Task<IResponseData<UpdateDto>> UpdateAsync(UpdateDto dto);

        Task<IResponseData<IDto>> GetByIdAsync<IDto>(int id);

        Task<IResponse> RemoveAsync(int id);

        Task<IResponseData<List<ListDto>>> GetAllAsync();
    }
}
