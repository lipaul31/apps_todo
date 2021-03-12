using System.Text.Json.Serialization;

namespace TodoApp.Web.Controllers.v1
{
    public class TodoItemPutRequest
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("state")]
        public bool State { get; set; }
    }
}