using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace API_Inmuebles.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [MaxLength(20)]
        public string? Tel { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }

        public int? Capacity { get; set; }

        public byte[]? Photo { get; set; }

        public Point? Location { get; set; }
    }
    [Owned]
    public class Point
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
