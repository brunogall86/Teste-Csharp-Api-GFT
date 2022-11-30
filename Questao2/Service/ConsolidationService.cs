using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Questao2.Api.Models;
using Questao2.Api.Service;
using Questao2.Dto;
using Questao2.Model;

namespace Questao2.Service
{
    public class ConsolidationService : IConsolidationService
    {
        private readonly IApiService _apiService;
        private ConsolidateData _consolidateData;
        
        public ConsolidationService(IApiService apiService)
        {
            _apiService = apiService;            
        }
        private Task<int> GetGoalsFromTeam(DtoRequest dto, ApiRootModel returnApi)
        {
            var lstTeamOne = returnApi.data.Where(p => p.team1.Equals(dto.Team)).ToList();
            var lstTeamTwo = returnApi.data.Where(p => p.team2.Equals(dto.Team)).ToList();

            var totalGoals = 0;

            foreach (var item in lstTeamOne)
            {
                totalGoals += Convert.ToInt32(item.team1goals);
            }
             foreach (var item in lstTeamTwo)
            {
                totalGoals += Convert.ToInt32(item.team2goals);
            }
            
            return Task.FromResult(totalGoals);
        }

        private async Task GetGoals(DtoRequest dto)
        {
            var listDtoRequest = new List<DtoRequest>();
            var listReturnApi = new List<ApiRootModel>();

            if(_consolidateData is null)  _consolidateData = new ConsolidateData(dto.Team);

            var returnApi = await _apiService.FindTeamByYear(dto);
            listReturnApi.Add(returnApi);

            int pageAtual = returnApi.page;

            while(returnApi.total_pages > pageAtual)
            {
                pageAtual++;
                listDtoRequest.Add(new DtoRequest(){ Team = dto.Team, Page = pageAtual, Year = dto.Year});
            }            

            var task = listDtoRequest.Select(dto=> 
            {
                return Task.Run(async () => 
                {
                    var r = await _apiService.FindTeamByYear(dto);
                    listReturnApi.Add(r);
                });
            }).ToList();

            await Task.WhenAll(task);

            foreach (var item in listReturnApi)
            {
                var r = GetGoalsFromTeam(dto, item).Result;
                _consolidateData.AddGoals(r);
            }
        }

        public async Task<int> GetConsolidateData(DtoRequest dto)
        {
            await GetGoals(dto);
            
            return _consolidateData.TotalGoals();
        }

    }
}