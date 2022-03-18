using System.ComponentModel.DataAnnotations;

namespace MvcMate.Models
{
    public class Mate
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        public string? Title { get; set; }
        public string? ImgURL { get; set; }
        public string? Body { get; set; }
        public string? GrURL { get; set; }
        public string? ShowOn { get; set; }
    }
}