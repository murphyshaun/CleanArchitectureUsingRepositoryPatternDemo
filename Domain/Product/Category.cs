using Domain.Common;

namespace Domain.Product
{
    public class Category : AuditableWithBaseEntity<long>
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int DisplayOrder { get; set; }
    }
}