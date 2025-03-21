using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class VillaNumberService : BaseService, IVillaNumberService
    {
        public readonly IHttpClientFactory _httpClient;
        public string villaNumberUrl;

        public VillaNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _httpClient = clientFactory;
            villaNumberUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public async Task<T> CreateAsync<T>(VillaNumberCreateDto dto)
        {
            return await SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.POST,
                Url = villaNumberUrl + "/api/VillaNumberAPI",
                Data = dto

            });
        }

        public async Task<T> DeleteAsync<T>(int id)
        {
            return await SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.DELETE,
                Url = villaNumberUrl + "/api/VillaNumberAPI/" + id
            });
        }

        public async Task<T> GetAllAsync<T>()
        {
            return await SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = villaNumberUrl + "/api/VillaNumberAPI"
            });
        }

        public async Task<T> GetAsync<T>(int id)
        {
            return await SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = villaNumberUrl + "/api/VillaNumberAPI/" + id
            });
        }

        public async Task<T> UpdateAsync<T>(VillaNumberUpdateDto dto)
        {
            return await SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.PUT,
                Url = villaNumberUrl + "/api/VillaNumberAPI",
                Data = dto
            });
        }
    }
}