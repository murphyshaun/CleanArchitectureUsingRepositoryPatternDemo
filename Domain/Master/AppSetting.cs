global using Domain.Common;

namespace Domain.Master
{
    public class AppSetting : BaseEntity<int>
    {
        /// <summary>
        /// Gets or sets the reference key.
        /// </summary>
        /// <value>
        /// The reference key.
        /// </value>
        public string ReferenceKey { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; } = string.Empty;
    }
}