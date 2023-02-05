using System.Text.Json.Serialization;

public class Result
{
    public string Category { get; set; }

    public string Type { get; set; }

    public string Question { get; set; }

    public string Difficulty { get; set; }

    [JsonPropertyName("correct_answer")]
    public string CorrectAnswer { get; set; }

    [JsonPropertyName("incorrect_answers")]
    public ICollection<string> IncorrectAnswers { get; set; }
}