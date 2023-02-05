using DemoHTTPClient.DataAccess;
using DemoHTTPClient.DataAccess.Models;

namespace DemoHTTPClient.Services;

public class QuizService : IQuizService<Result, QuizResponse>
{
    private readonly IRepository<Question> _questionsRepository;

    public QuizService(IRepository<Question> questionsRepository)
    {
        _questionsRepository = questionsRepository;
    }

    public async Task<IEnumerable<Question>> GetQuestions(QuizResponse response, string difficulty)
    {
        foreach (var responseResult in response.Results)
        {
            await Add(responseResult);
        }

        return await _questionsRepository.GetAllWithDifficultyAsync(difficulty);
    }

    public async Task<bool> CheckExists(Result item)
    {
        var all = await _questionsRepository.GetAllAsync();

        return all.Any(q => q.Statement.Equals(item.Question));
    }

    public async Task Add(Result item)
    {
        if (await CheckExists(item))
        {
            return;
        }

        await _questionsRepository.AddAsync(ConvertResultToQuestion(item));
    }

    private Question ConvertResultToQuestion(Result result)
    {
        return new Question()
        {
            Statement = result.Question,
            Category = result.Category,
            CorrectAnswer = result.CorrectAnswer,
            Difficulty = result.Difficulty,
            IncorrectAnswers = new List<string>(result.IncorrectAnswers),
            Type = result.Type
        };
    }
}