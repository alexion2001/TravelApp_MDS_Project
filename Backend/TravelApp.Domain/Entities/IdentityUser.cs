using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Domain.Entities
{
    public partial class IdentityUser
    {
        public IdentityUser()
        {
      
            IdentityRoles = new HashSet<IdentityRole>();
            IdentityUserTokenConfirmations = new HashSet<IdentityUserTokenConfirmation>();
            IdentityUserTokens = new HashSet<IdentityUserToken>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public string PhoneNumberCountryPrefix { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public int NumberOfFailLoginAttempts { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<IstoricZborUser> IstoricZborUsers { get; set; }
        public virtual ICollection<IstoricCazariUser> IstoricCazariUsers { get; set; }
        public virtual ICollection<IstoricVacanteUser> IstoricVacanteUsers { get; set; }
        public virtual ICollection<RecenziiUsers> RecenziiUsers { get; set; }
        public virtual ICollection<IdentityRole> IdentityRoles { get; set; }
        public virtual ICollection<IdentityUserTokenConfirmation> IdentityUserTokenConfirmations { get; set; }
        public virtual ICollection<IdentityUserToken> IdentityUserTokens { get; set; }
        public virtual ICollection<IdentityUserIdentityRole> IdentityUserRoles { get; set; }
        
        //public ICollection<WOType> WOTypes { get; set; } //modif
    }
}
