using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.API.Models
{
    [Table("Cities", Schema = "Common")]
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public string Name { get; set; } = null!;
        public int StateID { get; set; }
        public int CountryId { get; set; }
    }

    [Table("Countries", Schema = "Common")]
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;
    }

    [Table("Gender", Schema = "Common")]
    public class Gender
    {
        [Key]
        public int GenderID { get; set; }
        public string Name { get; set; } = null!;
    }

    [Table("Seasons", Schema = "Common")]
    public class Season
    {
        [Key]
        public int SeasonID { get; set; }
        public string Name { get; set; } = null!;
    }

    [Table("States", Schema = "Common")]
    public class State
    {
        [Key]
        public int StateID { get; set; }
        public string Name { get; set; } = null!;
        public int CountryId { get; set; }
    }
}