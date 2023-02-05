using DemoHTTPClient.DataAccess.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DemoHTTPClient.DataAccess;

public class QuestionRepository : IRepository<Question>
{
    private readonly IMongoCollection<Question> _questionCollection;

    public QuestionRepository()
    {
        var host = "localhost";
        var databaseName = "QuizDemo";
        var connectionString = $"mongodb://{host}:27017";
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _questionCollection = database.GetCollection<Question>("Questions", new MongoCollectionSettings(){ AssignIdOnInsert = true});
    }

    public async Task AddAsync(Question item)
    {
        await _questionCollection.InsertOneAsync(item);
    }

    public async Task<Question> GetAsync(object id)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));
        var exists = await _questionCollection.FindAsync(q => q.Id.Equals((ObjectId) id));
        return exists.FirstOrDefault();
    }

    public async Task<IEnumerable<Question>> GetAllAsync()
    {
        var all =  await _questionCollection.FindAsync(_ => true);
        return all.ToEnumerable();
    }

    public async Task<IEnumerable<Question>> GetAllWithDifficultyAsync(string difficulty)
    {
        var allWithDiff = await _questionCollection.FindAsync(q => q.Difficulty.Equals(difficulty));
        return allWithDiff.ToEnumerable();
    }

    public async Task DeleteAsync(object id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(object id, Question item)
    {
        throw new NotImplementedException();
    }
}