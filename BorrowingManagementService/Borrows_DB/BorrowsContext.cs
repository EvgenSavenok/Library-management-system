using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BorrowingManagementService;

public partial class BorrowsContext : DbContext
{
    public BorrowsContext()
    {
    }

    public BorrowsContext(DbContextOptions<BorrowsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Borrow> Borrows { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Borrows.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Borrow>(entity =>
        {
            entity.HasKey(e => e.RecordId);

            entity.HasIndex(e => e.BookId, "IX_Borrows_BookId").IsUnique();

            entity.HasIndex(e => e.RecordId, "IX_Borrows_RecordId").IsUnique();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
