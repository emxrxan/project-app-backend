using System.ComponentModel.DataAnnotations;

namespace PortfolioPorjekt.Resources
{
    public enum EinnahmeType
    {
        EINNAHME = 0,
        AUSGABE = 1
    }
    public class HaushaltRechnerResource
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }

        public DateOnly Date { get; set; }

        public float Betrag { get; set; }

        public EinnahmeType EinnahmeType { get; set; }
    }
}
