using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaveenBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class bookrecoms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookRecoms",
                columns: table => new
                {
                    BookRecomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookRecomTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookRecomAuthor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookRecomDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookRecomImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRecoms", x => x.BookRecomId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRecoms");
        }
    }
}
