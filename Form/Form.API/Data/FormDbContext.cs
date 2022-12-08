using Form.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Form.API.Data
{
    public class FormDbContext : DbContext
    {
        public FormDbContext(DbContextOptions options) : base(options)
        {
        }
        //DbSet
        public  DbSet<Post> Posts { get; set; }
    }
}
