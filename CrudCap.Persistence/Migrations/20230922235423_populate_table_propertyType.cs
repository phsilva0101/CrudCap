using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudCap.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class populate_table_propertyType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into PropertyType values (newId(), 'Casa', GETDATE(), GETDATE(), null),\r\n (newId(), 'Apartamento', GETDATE(), GETDATE(), null),\r\n (newId(), 'Galpão', GETDATE(), GETDATE(), null),\r\n(newId(), 'Fazenda', GETDATE(), GETDATE(), null),\r\n(newId(), 'Loteamento', GETDATE(), GETDATE(), null)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
