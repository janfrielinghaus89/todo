using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestApp.Models
{
    public class ToDoPost
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string TagsString { get; set; } // Spalte für die komma-separierten Tags

        // Property für die Tags als Liste von Strings
        [NotMapped]
        public List<string> Tags
        {
            get => TagsString?.Split(',').Select(tag => tag.Trim()).ToList() ?? new List<string>();
            set => TagsString = string.Join(",", value);
        }
    }
}