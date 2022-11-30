using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Questao2.Dto;

namespace Questao2.Service
{
    public interface IConsolidationService
    {
         Task<int> GetConsolidateData(DtoRequest dto);
    }
}