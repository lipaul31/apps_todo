using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Repository.Models
{
    [Table("todoitem")]
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool State { get; set; } = false;
    }
}