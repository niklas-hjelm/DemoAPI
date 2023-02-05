using System.Text.Json.Serialization;

public class QuizResponse
{
    [JsonPropertyName("response_code")]
    public int ResponseCode { get; set; }

    public ICollection<Result> Results { get; set; }
}