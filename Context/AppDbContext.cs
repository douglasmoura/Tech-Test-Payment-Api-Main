using Tech_Test_Payment_Api_Main.Models;
using Microsoft.EntityFrameworkCore;

namespace Tech_Test_Payment_Api_Main.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        //     Role roleMentor = new Role();
        //     roleMentor.Id = 1;
        //     roleMentor.Name = "MENTOR";

        //     Role roleMentorando = new Role();
        //     roleMentorando.Id = 2;
        //     roleMentorando.Name = "MENTORANDO";

        //     Role roleAdmin = new Role();
        //     roleAdmin.Id = 3;
        //     roleAdmin.Name = "ADMIN";
        //     base.OnModelCreating(modelBuilder);


        //     modelBuilder.Entity<Role>().HasData(roleMentor);
        //     modelBuilder.Entity<Role>().HasData(roleMentorando);
        //     modelBuilder.Entity<Role>().HasData(roleAdmin);

        //     modelBuilder.Entity<User>().HasData
        //     (new User
        //     {
        //         Id = 1,
        //         Name = "Francielio",
        //         Email = "francielio@gft.com",
        //         Password = "123456",
        //         Description = "user info",
        //         PhotoUrl = "photo_url",
        //         IsActived = true,
        //         AverageRating = 5,
        //         RoleId = 1
        //     });

        //     modelBuilder.Entity<User>().HasData
        //     (new User
        //     {
        //         Id = 2,
        //         Name = "Douglas",
        //         Email = "douglas@gft.com",
        //         Password = "123456",
        //         Description = "user info",
        //         PhotoUrl = "photo_url",
        //         IsActived = true,
        //         AverageRating = 5,
        //         RoleId = 2
        //     });

        //     modelBuilder.Entity<User>().HasData
        //     (new User
        //     {
        //         Id = 3,
        //         Name = "Guilherme",
        //         Email = "guilherme@gft.com",
        //         Password = "123456",
        //         Description = "user info",
        //         PhotoUrl = "photo_url",
        //         IsActived = true,
        //         AverageRating = 5,
        //         RoleId = 3
        //     });
         }
    }
}