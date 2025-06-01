using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.AdminAPI.Models
{
    [Table("Cities", Schema = "Common")]
    public class City
    {
        public int CityID { get; set; }
        public string Name { get; set; } = null!;
        public int StateID { get; set; }
        public int CountryId { get; set; }
    }

    [Table("Countries", Schema = "Common")]
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;
    }

    [Table("Gender", Schema = "Common")]
    public class Gender
    {
        public int GenderID { get; set; }
        public string Name { get; set; } = null!;
    }

    [Table("Seasons", Schema = "Common")]
    public class Season
    {
        public int SeasonID { get; set; }
        public string Name { get; set; } = null!;
    }

    [Table("States", Schema = "Common")]
    public class State
    {
        public int StateID { get; set; }
        public string Name { get; set; } = null!;
        public int CountryId { get; set; }
    }
}