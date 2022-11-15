namespace TP3.Models
{
    public class Mentor: Base
    {
        public string FIO { get; set; }
        public string Post { get; set; }

        public int ClientId { get; set; }

        public virtual Guid client { get; set; }
    }
}
