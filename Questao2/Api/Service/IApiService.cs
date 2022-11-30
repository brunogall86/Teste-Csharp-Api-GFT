using System.Collections.Generic;
using System.Threading.Tasks;
using Questao2.Api.Models;
using Questao2.Dto;

namespace Questao2.Api.Service
{
    public interface IApiService
    {
            Task<ApiRootModel> FindTeamByYear(DtoRequest dtoRequest);
    }
}