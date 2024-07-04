using AvaliacaoBailarinaPreparada.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoBailarinaPreparada.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; } = default!;
    public DbSet<Evaluation> Evaluations { get; set; } = default!;
}
