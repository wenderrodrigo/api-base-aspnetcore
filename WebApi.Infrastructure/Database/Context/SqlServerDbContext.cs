using Microsoft.EntityFrameworkCore;

namespace WebApiServicos.Context;

public class SqlServerDbContext : DbContext
{
    public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options) { }
}
