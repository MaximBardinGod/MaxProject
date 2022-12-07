using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Mentor
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Post { get; set; }

        public Mentor() { }

        public Mentor(int id, string name, string post)
        {
            Id = id;
            Name = name;
            Post = post;
        }
    }
}
