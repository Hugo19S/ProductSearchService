using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductSearchService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PendingNotificationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PendingNotification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingNotification", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("11d951a4-d47d-4493-a65e-37edabf8f488"), new Guid("1aaa883e-2b3d-4b0b-bad2-f696431067e2") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 30, 15, 21, 21, 372, DateTimeKind.Utc).AddTicks(1399));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("2c82cde0-f5c8-408b-8959-9b2ddd61618d"), new Guid("34d678a1-ade5-4f3c-8b4c-bf92a78a1234") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 30, 15, 21, 21, 372, DateTimeKind.Utc).AddTicks(1406));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("3657192b-8bf1-41cc-aa7e-27fb13b0542c"), new Guid("34d678a1-ade5-4f3c-8b4c-bf92a78a1234") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 30, 15, 21, 21, 372, DateTimeKind.Utc).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("42f7d306-4435-4d84-abce-ace14095800b"), new Guid("34e60c09-7b61-4cb4-97e3-0bd03f02f80b") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 30, 15, 21, 21, 372, DateTimeKind.Utc).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("56aae860-62f1-420e-8449-2d62df55a6e4"), new Guid("a670b084-ae63-48c9-b248-7b997beaf486") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 30, 15, 21, 21, 372, DateTimeKind.Utc).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("8cea0461-31a2-4146-a936-cc881f97eeab"), new Guid("0149b95c-2857-445f-a0dd-16d591278e46") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 30, 15, 21, 21, 372, DateTimeKind.Utc).AddTicks(1398));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("97ecdc35-621e-46fd-a280-f34e00ce3340"), new Guid("da98f9aa-afd6-444f-a3dd-92b7ab32cf5d") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 30, 15, 21, 21, 372, DateTimeKind.Utc).AddTicks(1405));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("a6528c65-5d6d-4560-ad59-70703ed98e45"), new Guid("34e60c09-7b61-4cb4-97e3-0bd03f02f80b") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 30, 15, 21, 21, 372, DateTimeKind.Utc).AddTicks(1396));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("eabc1500-7d32-488b-9051-c062c9b23ad0"), new Guid("90c8513a-181c-4abd-a855-9864ecc044d8") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 30, 15, 21, 21, 372, DateTimeKind.Utc).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("f846a46b-64a3-4fb9-b88b-9e1da3b25fa7"), new Guid("e4a32804-3206-48dc-8dcd-a455480bac2c") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 30, 15, 21, 21, 372, DateTimeKind.Utc).AddTicks(1401));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PendingNotification");

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("11d951a4-d47d-4493-a65e-37edabf8f488"), new Guid("1aaa883e-2b3d-4b0b-bad2-f696431067e2") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("2c82cde0-f5c8-408b-8959-9b2ddd61618d"), new Guid("34d678a1-ade5-4f3c-8b4c-bf92a78a1234") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("3657192b-8bf1-41cc-aa7e-27fb13b0542c"), new Guid("34d678a1-ade5-4f3c-8b4c-bf92a78a1234") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("42f7d306-4435-4d84-abce-ace14095800b"), new Guid("34e60c09-7b61-4cb4-97e3-0bd03f02f80b") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9352));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("56aae860-62f1-420e-8449-2d62df55a6e4"), new Guid("a670b084-ae63-48c9-b248-7b997beaf486") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9347));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("8cea0461-31a2-4146-a936-cc881f97eeab"), new Guid("0149b95c-2857-445f-a0dd-16d591278e46") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9343));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("97ecdc35-621e-46fd-a280-f34e00ce3340"), new Guid("da98f9aa-afd6-444f-a3dd-92b7ab32cf5d") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("a6528c65-5d6d-4560-ad59-70703ed98e45"), new Guid("34e60c09-7b61-4cb4-97e3-0bd03f02f80b") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("eabc1500-7d32-488b-9051-c062c9b23ad0"), new Guid("90c8513a-181c-4abd-a855-9864ecc044d8") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "SupermarketProduct",
                keyColumns: new[] { "ProductId", "SupermarketId" },
                keyValues: new object[] { new Guid("f846a46b-64a3-4fb9-b88b-9e1da3b25fa7"), new Guid("e4a32804-3206-48dc-8dcd-a455480bac2c") },
                column: "CreatedOn",
                value: new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9346));
        }
    }
}
