using DemoHTTPClient.DataAccess.Models;

namespace DemoHTTPClient.Services;

public interface IQuizService<in T, TU> where T : class
                                        where TU : class
{
    Task<IEnumerable<Question>> GetQuestions(TU response, string difficulty);
    Task<bool> CheckExists(T item);
    Task Add(T item);
}