using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DevBook.Models.Entities
{
    public partial class DevBookContext : DbContext
    {
        public DevBookContext(DbContextOptions<DevBookContext> options) : base(options)
        {
        }
    }
}
