using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using RCP.Model;

namespace RCP.Database
{
    public partial class RcpDbContext : DbContext
    {
        private DbSet<User> Users { get; set; }

        /// <summary>
        /// Metoda służąca pobraniu pierwszego użytkownika z bazy danych. 
        /// W docelowej wersji aplikacji należałoby pobrać użytkownika na podstawie kontekstu, a ta metoda byłaby zbędna.
        /// </summary>
        public User GetUser()
        {
            return Users.FirstOrDefault();
        }

    }
}
