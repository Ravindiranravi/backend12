namespace Institute.Models
{
    public class Batch
    {
        public int Id { get; set; } // Unique identifier for the batch (Primary Key)
        public string BatchName { get; set; } // Name of the batch
        public DateTime StartDate { get; set; } // Starting date of the batch
        public DateTime EndDate { get; set; } // Ending date of the batch
    }
}
