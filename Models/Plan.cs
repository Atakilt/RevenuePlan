namespace WebApplication2.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public decimal InBirr { get; set; }
        public int RevenuTypeId { get; set; }
        public RevenuType RevenuType { get; set; }
    }
}
