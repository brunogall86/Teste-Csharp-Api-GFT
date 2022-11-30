using System.Diagnostics;
using System.Linq;
using System.Dynamic;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Questao2.Api.Models;
using Questao2.Dto;
using System.Collections.Generic;

namespace Questao2.Api.Service
{
    public class ApiService : IApiService
    {
        private readonly string baseAddress = "https://jsonmock.hackerrank.com/api/football_matches";

        private async Task<GenericResponse<ApiRootModel>> SendRequest(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = new GenericResponse<ApiRootModel>();

            using (var client = new HttpClient())
            {
                var responseApi = await client.SendAsync(request);
                var content = await responseApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<ApiRootModel>(content);

                if(responseApi.IsSuccessStatusCode)
                {
                    response.StatusCode = responseApi.StatusCode;
                    response.Data = objResponse;
                }else
                {
                    response.StatusCode = responseApi.StatusCode;
                    response.Error = JsonSerializer.Deserialize<ExpandoObject>(content);
                }
            }
            return response;
        }

        public async Task<ApiRootModel> FindTeamByYear(DtoRequest dtoRequest)
        {   
            var resultWhenTeamOne = await FindByYearTeam(GetUrlFromTeamOne(dtoRequest));
            var resultWhenTeamTwo = await FindByYearTeam(GetUrlFromTeamTwo(dtoRequest));

            var result = new ApiRootModel();
            result.page = resultWhenTeamOne.Data.page;
            result.total_pages = resultWhenTeamOne.Data.total_pages;
            
            if (result.data is null)
            {
                result.data = new List<ApiModelData>();
            }
            result.data.AddRange(resultWhenTeamOne.Data.data);
            result.data.AddRange(resultWhenTeamTwo.Data.data);
            
            return result;
        }

        private async Task<GenericResponse<ApiRootModel>> FindByYearTeam(string url)
        {
            return await SendRequest(url);
        }

        private string GetUrlFromTeamOne(DtoRequest dto)
        {
            return String.Format("{0}?year={1}&page={2}&team1={3}", baseAddress,dto.Year, dto.Page, dto.TeamToParameter);            
        }
        private string GetUrlFromTeamTwo(DtoRequest dto)
        {
            return String.Format("{0}?year={1}&page={2}&team2={3}", baseAddress,dto.Year, dto.Page, dto.TeamToParameter);
        }

        
    }
}