using System.Threading.Tasks;
using System;
using Questao2.Api.Service;
using Questao2.Service;

public class Program
{
    public static async Task Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014

    }

    public static async Task<int> getTotalScoredGoals(string team, int year)
    {
        var r = await new ConsolidationService(new ApiService()).GetConsolidateData(new Questao2.Dto.DtoRequest() { Team =  team, Year = year }); 
        return r;
    }

}