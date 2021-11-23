using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksChallenge.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[] { new Guid("3f9a0026-e78e-4307-a4df-c28470b7867d"), "Jack", "London" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[] { new Guid("7c8075c1-26fa-4a8b-9292-d22515a16ad7"), "Jules", "Verne" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Isbn", "Name" },
                values: new object[,]
                {
                    { new Guid("b5fd448f-5b2d-4058-9bfd-cbb8b8b522fd"), new Guid("3f9a0026-e78e-4307-a4df-c28470b7867d"), "2-253-03986-1", "L'Appel de la forêt" },
                    { new Guid("d9f2bf68-50d4-457a-b053-52a5b10ca361"), new Guid("3f9a0026-e78e-4307-a4df-c28470b7867d"), "9782070332731", "Le Loup des mers" },
                    { new Guid("11de9d1c-8d2e-47f2-bce7-d020aa4c9f60"), new Guid("7c8075c1-26fa-4a8b-9292-d22515a16ad7"), "9782253006329", "Vingt Mille Lieues sous les mers" },
                    { new Guid("c146aff2-ec00-47dc-9afa-d331800b5e3f"), new Guid("7c8075c1-26fa-4a8b-9292-d22515a16ad7"), "9781520982076", "Les Aventures du capitaine Hatteras" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("11de9d1c-8d2e-47f2-bce7-d020aa4c9f60"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("b5fd448f-5b2d-4058-9bfd-cbb8b8b522fd"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("c146aff2-ec00-47dc-9afa-d331800b5e3f"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("d9f2bf68-50d4-457a-b053-52a5b10ca361"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("3f9a0026-e78e-4307-a4df-c28470b7867d"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("7c8075c1-26fa-4a8b-9292-d22515a16ad7"));
        }
    }
}
