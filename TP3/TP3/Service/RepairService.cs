using System.Reflection.Metadata;
using TP3.Repositories;
using TP3.Models;

namespace TP3.Service
{
    public class RepairService: IRepairService
    {
        private IBaseRepository<Client> Clients { get; set; }
        private IBaseRepository<Mentor> Mentors { get; set; }

        public void Work()
        {
            var rand = new Random();
            var clientId = Guid.NewGuid();
            var mentorId = Guid.NewGuid();

            Clients.Create(new Client
            {
                Id = clientId,
                FIO = String.Format($"Client{rand.Next()}"),
                PhoneNumber = String.Format($"{rand.Next()}")
            });

            Mentors.Create(new Mentor
            {
                Id = mentorId,
                FIO = String.Format($"Worker{rand.Next()}"),
                Post = String.Format($"Position{rand.Next()}"),
            });

            var client = Clients.Get(clientId);
            var worker = Mentors.Get(mentorId);
        }
    }
}
