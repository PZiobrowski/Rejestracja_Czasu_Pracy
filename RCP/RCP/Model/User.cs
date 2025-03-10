using System.ComponentModel.DataAnnotations;

namespace RCP.Model
{
    /// <summary>
    /// Użytkownik systemu
    /// </summary>
    public class User
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string Lastname { get; set; }
    }
}
