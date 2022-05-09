using Microsoft.EntityFrameworkCore;
using XProject.Contract.Repository.Models;

namespace XProject.Repository.Infrastructure
{
    public sealed partial class AppDbContext
    {
        public DbSet<TM_DD_MEMBER> TM_DD_MEMBERs { get; set; }
        public DbSet<TD_CUSTOMER_INFO> TD_CUSTOMER_INFOs { get; set; }
        public DbSet<TD_SHARING_INFO> T_SHARING_INFOs { get; set; }
        public DbSet<TD_FILE_INFO> TD_FILE_INFOs { get; set; }
    }
}