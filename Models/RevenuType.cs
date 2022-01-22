using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class RevenuType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
    }
}
