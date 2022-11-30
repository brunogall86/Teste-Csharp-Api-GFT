using System.Runtime.Serialization;
namespace Questao5.Domain.Enumerators
{
    public static class EnumeradoresExtensions
    {
        public static bool ExisteNoEnumTipoMovimento(char value)
        {
            var items = Enum.GetValues<TipoMovimento>();
            var c = new List<char>();
            foreach (var item in items)
            {
                c.Add((char)item);
            }
            return c.Contains(value);
        }
    }
}