using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageBoardApi.Migrations
{
    public partial class AddEmailToSeededUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f9e3a9c-3bdf-420d-a755-0d57dd983ecf", "AQAAAAEAACcQAAAAEAxKNMmMv4unvxlmXXYna+u9pmgZfdUjbM9QLJAii0KFgsCCaStr032Lrx6PBJqnfA==", "e45cc444-6fac-4f5c-84bb-78c0c4538e2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "def",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ed479b2-3596-414c-8850-72dbc9467ca5", "richard@email.com", "AQAAAAEAACcQAAAAEB5lSiYmymKRH9wimPINvrHN3m1CdNpA9pf+NeNx129ClsR1/wdoHlhLjkB51K77lg==", "df6bc540-82d3-4d41-9e7b-0909ddbed8ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ghi",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c36dda33-a100-4068-af22-1695f03b4b26", "onur@email.com", "AQAAAAEAACcQAAAAEEykPYALzLExPaZiqZeyDzb+D6X/liDop/L9fWgL7pmrg58lstcwXnl3qnZjk0qgEA==", "befbbb04-e03b-47c3-89b9-98b829e85167" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "228a6eaa-cf78-4109-990a-82418a0987d9", "AQAAAAEAACcQAAAAEFoA3obnYCjDJZfl4QavHFFSldNdpLVy+dpvoYp4CmL++xLXp+Hd+sCuAyUaP8smGQ==", "e4de6e66-851f-43d9-a133-d7e3963bbb35" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "def",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f6901ab-d662-4192-a039-d60c76886b89", null, "AQAAAAEAACcQAAAAEI4Q6BX0s9SVaC3WDALkT+mkYsxkqA3B5fBW37FKfoSfGg/HxzTZkSWpcd27pF/Wng==", "e8f93da8-b7fc-4e1b-8f6f-08cb4dbcd547" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ghi",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ddd0af1-3a1c-4d00-9a8e-39d1c66ec14d", null, "AQAAAAEAACcQAAAAEOhRrnDFVUTGWk0CIr5DL7rqqa137TgBI9ZRg8O7vR2TT5fC9vEJ3S6kgdBeSbvjBA==", "51841830-69cd-4077-8546-a94a63103c4c" });
        }
    }
}
