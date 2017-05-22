using System.Threading.Tasks;

namespace AI.Learning.API.Interfaces
{
    public interface IDictionaryService<T>
    {
        Task<T> Define(string word);
    }
}