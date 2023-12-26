using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Infra
{
    public class TodoItemTableMap : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure( EntityTypeBuilder<TodoItem> builder )
        {
            builder.ToTable( "Todo" );
            builder.HasKey( x => x.Id );
            builder.Property( x => x.Id );
            builder.Property( x => x.User )
                .IsRequired()
                .HasMaxLength( 30 )
                .HasColumnType( "varchar(50)" );
            builder.Property( x => x.Title )
                .HasMaxLength( 50 )
                .HasColumnType( "varchar(50)" );
            builder.Property( x => x.Done );
            builder.Property( x => x.Date ).HasColumnType( "datetime" );
            builder.Property( x => x.Description )
                .HasMaxLength( 200 )
                .HasColumnType( "varchar(200)" );
        }   
    }
}
