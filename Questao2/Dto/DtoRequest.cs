namespace Questao2.Dto
{
    public class DtoRequest
    {
        public int Year { get; set; }
        public string Team { get; set; }
        public string TeamToParameter{get { return Team.Replace(" ", "+"); }}
        public int Page { get; set; } = 1;
    }
    
}