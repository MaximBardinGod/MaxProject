using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PnoneNumber { get; set; }

        public Mentor Mentors { get; set; }

        public Client() { }

        public Client(int id, string name, string phoneNumber, Mentor mentors) 
        {
            Id = id;
            Name = name;
            PnoneNumber = phoneNumber;
            Mentors = mentors;
        }
    }
}
