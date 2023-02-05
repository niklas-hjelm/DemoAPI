using System.Text.Encodings.Web;
using System.Text.Json;
using DemoHTTPClient.DataAccess;
using DemoHTTPClient.DataAccess.Models;
using DemoHTTPClient.Services;

var builder = WebApplication.CreateBuilder(args);

#region Steg2

builder.Services.AddScoped<IRepository<Question>, QuestionRepository>();
builder.Services.AddScoped<IQuizService<Result, QuizResponse>, QuizService>();
builder.Services.AddHttpClient();

#endregion

var app = builder.Build();

#region Steg 1
app.MapGet("/", async () =>
{
    var client = new HttpClient();
    var response = await client.GetAsync("https://opentdb.com/api.php?amount=10&difficulty=easy");
    return response.Content.ReadAsStringAsync();
});
#endregion
#region Steg 2
//app.MapGet("/easy", async (HttpClient client, IQuizService<Result, QuizResponse> quizService) =>
//{
//    var response = await client.GetAsync("https://opentdb.com/api.php?amount=10&difficulty=easy");
//    var quiz = await response.Content.ReadFromJsonAsync<QuizResponse>();
//    return await quizService.GetQuestions(quiz, "easy");
//});

//app.MapGet("/medium", async (HttpClient client, IQuizService<Result, QuizResponse> quizService) =>
//{
//    var response = await client.GetAsync("https://opentdb.com/api.php?amount=10&difficulty=medium");
//    var quiz = await response.Content.ReadFromJsonAsync<QuizResponse>();
//    return await quizService.GetQuestions(quiz, "medium");
//});

//app.MapGet("/hard", async (HttpClient client, IQuizService<Result, QuizResponse> quizService) =>
//{
//    var response = await client.GetAsync("https://opentdb.com/api.php?amount=10&difficulty=hard");
//    var quiz = await response.Content.ReadFromJsonAsync<QuizResponse>();
//    return await quizService.GetQuestions(quiz, "hard");
//});
#endregion
#region Steg 3
//app.MapGet("/{difficulty}", async (HttpClient client, IQuizService<Result, QuizResponse> quizService, string difficulty) =>
//{
//    var response = await client.GetAsync($"https://opentdb.com/api.php?amount=10&difficulty={difficulty}");
//    var quiz = await response.Content.ReadFromJsonAsync<QuizResponse>();
//    return await quizService.GetQuestions(quiz, difficulty);
//});
#endregion

app.Run();