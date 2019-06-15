using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Threading.Tasks;

namespace ASPNETIdentifySample
{
    class Program
    {
        static void Main(string[] args)
        {
            var username = "sivagopi123@gmail.com";
            var password = "password-1";

            var userStore = new CustomUserStore(new CustomUserDbContext());
            var userManager = new UserManager<CustomUser, int>(userStore);

            var creationResult = userManager
                                .Create(
                                        new CustomUser()
                                        {
                                            UserName = username
                                        }, 
                                        password);
            Console.WriteLine($"Creation: {creationResult.Succeeded}");

            //var userStore = new UserStore<IdentityUser>();
            //var userManager = new UserManager<IdentityUser>(userStore);
            //var creationResult = userManager.Create(new IdentityUser("sivagopi123@gmail.com"), "password-1");
            //Console.WriteLine($"User Created: {creationResult.Succeeded}");
            var user = userManager.FindByName("sivagopi123@gmail.com");
            //var claimResult = userManager.AddClaim(user.Id, new Claim("given_name", "Scott"));
            //Console.WriteLine($"Claim Created: {claimResult.Succeeded}");

            var isMatch = userManager.CheckPassword(user, password);
            Console.WriteLine($"Password Match: {isMatch}");
        }
    }
    
    public class CustomUser : IUser<int>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }

    public class CustomUserDbContext : DbContext
    {
        public CustomUserDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<CustomUser> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<CustomUser>();
            user.ToTable("Users");
            user.HasKey(x => x.Id);
            user.Property(x => x.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            user.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation
                                                (new IndexAttribute("UserNameIndex")
                                                    {
                                                        IsUnique = true
                                                    }
                                                )
                                    );

            base.OnModelCreating(modelBuilder);
            
        }
    }
    public class CustomUserStore : IUserPasswordStore<CustomUser, int>
    {
        private readonly CustomUserDbContext context;

        public CustomUserStore(CustomUserDbContext context)
        {
            this.context = context;
        }
        public Task CreateAsync(CustomUser user)
        {
            context.Users.Add(user);
            return context.SaveChangesAsync();
        }

        public Task DeleteAsync(CustomUser user)
        {
            context.Users.Remove(user);
            return context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Task<CustomUser> FindByIdAsync(int userId)
        {
            return context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public Task<CustomUser> FindByNameAsync(string userName)
        {
            return context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public Task<string> GetPasswordHashAsync(CustomUser user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(CustomUser user)
        {
            return Task.FromResult(user.PasswordHash != null);
        }

        public Task SetPasswordHashAsync(CustomUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(CustomUser user)
        {
            context.Users.Attach(user);
            return context.SaveChangesAsync();
        }
    }
}
