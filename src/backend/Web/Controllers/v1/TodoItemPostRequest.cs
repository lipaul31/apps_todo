using System.Text.Json.Serialization;

namespace TodoApp.Web.Controllers.v1
{
    public class TodoItemCreateRequest
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}