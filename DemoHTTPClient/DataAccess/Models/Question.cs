using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DemoHTTPClient.DataAccess.Models;

public class Question
{
    [BsonId]
    public ObjectId Id { get; set; }
    [BsonElement]
    public string Category { get; set; }
    [BsonElement]
    public string Type { get; set; }
    [BsonElement]
    public string Statement { get; set; }
    [BsonElement]
    public string Difficulty { get; set; }
    [BsonElement]
    public string CorrectAnswer { get; set; }
    [BsonElement]
    public ICollection<string> IncorrectAnswers { get; set; }
}