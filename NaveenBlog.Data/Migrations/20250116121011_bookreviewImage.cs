﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaveenBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class bookreviewImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "BookReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "BookReviews");
        }
    }
}
