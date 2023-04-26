using netCore.RateLimiting.Models.Common;

namespace netCore.RateLimiting.Models.Entities
{
    public sealed class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
