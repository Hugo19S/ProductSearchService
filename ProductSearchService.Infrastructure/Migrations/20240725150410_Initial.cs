using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductSearchService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Barcode = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supermarket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supermarket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupermarketProduct",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    SupermarketId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ProductQuantity = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupermarketProduct", x => new { x.ProductId, x.SupermarketId });
                    table.ForeignKey(
                        name: "FK_SupermarketProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupermarketProduct_Supermarket_SupermarketId",
                        column: x => x.SupermarketId,
                        principalTable: "Supermarket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("11d951a4-d47d-4493-a65e-37edabf8f488"), "3C63D3DL8CG122197", null, "Gel Fixador" },
                    { new Guid("2c82cde0-f5c8-408b-8959-9b2ddd61618d"), "WP0CB2A81FK737485", null, "Tônico Capilar" },
                    { new Guid("3657192b-8bf1-41cc-aa7e-27fb13b0542c"), "WAUSH78E87A574664", null, "Shampoo Hidratante" },
                    { new Guid("42f7d306-4435-4d84-abce-ace14095800b"), "2C3CDXJG5CH817619", null, "Leave-in Condicionante" },
                    { new Guid("56aae860-62f1-420e-8449-2d62df55a6e4"), "JM3KE2BE6F0509041", null, "Óleo Reparador" },
                    { new Guid("8cea0461-31a2-4146-a936-cc881f97eeab"), "4A31K5DFXAE659389", null, "Creme para Pentear" },
                    { new Guid("97ecdc35-621e-46fd-a280-f34e00ce3340"), "SCBDR33WX9C881684", null, "Máscara Capilar" },
                    { new Guid("a6528c65-5d6d-4560-ad59-70703ed98e45"), "1G6AS5S32F0858696", null, "Condicionador Nutritivo" },
                    { new Guid("eabc1500-7d32-488b-9051-c062c9b23ad0"), "WAUBFAFL7CN345965", null, "Serum Anti-Frizz" },
                    { new Guid("f846a46b-64a3-4fb9-b88b-9e1da3b25fa7"), "1N6AF0LYXFN674122", null, "Mousse Modelador" }
                });

            migrationBuilder.InsertData(
                table: "Supermarket",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0149b95c-2857-445f-a0dd-16d591278e46"), "Lidl" },
                    { new Guid("1aaa883e-2b3d-4b0b-bad2-f696431067e2"), "Auchan" },
                    { new Guid("34d678a1-ade5-4f3c-8b4c-bf92a78a1234"), "Continente" },
                    { new Guid("34e60c09-7b61-4cb4-97e3-0bd03f02f80b"), "Pingo Doce" },
                    { new Guid("90c8513a-181c-4abd-a855-9864ecc044d8"), "Aldi" },
                    { new Guid("a670b084-ae63-48c9-b248-7b997beaf486"), "Minipreço" },
                    { new Guid("da98f9aa-afd6-444f-a3dd-92b7ab32cf5d"), "Mercadona" },
                    { new Guid("e4a32804-3206-48dc-8dcd-a455480bac2c"), "Intermarché" }
                });

            migrationBuilder.InsertData(
                table: "SupermarketProduct",
                columns: new[] { "ProductId", "SupermarketId", "CreatedOn", "Description", "Price", "ProductQuantity", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("11d951a4-d47d-4493-a65e-37edabf8f488"), new Guid("1aaa883e-2b3d-4b0b-bad2-f696431067e2"), new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9344), "Gel Fixador - Auchan", 6.49m, 80, null },
                    { new Guid("2c82cde0-f5c8-408b-8959-9b2ddd61618d"), new Guid("34d678a1-ade5-4f3c-8b4c-bf92a78a1234"), new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9351), "Tônico Capilar - E.Leclerc", 6.99m, 130, null },
                    { new Guid("3657192b-8bf1-41cc-aa7e-27fb13b0542c"), new Guid("34d678a1-ade5-4f3c-8b4c-bf92a78a1234"), new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9338), "Shampoo Hidratante - Continente", 4.99m, 100, null },
                    { new Guid("42f7d306-4435-4d84-abce-ace14095800b"), new Guid("34e60c09-7b61-4cb4-97e3-0bd03f02f80b"), new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9352), "Leave-in Condicionante - Mercadona", 11.99m, 140, null },
                    { new Guid("56aae860-62f1-420e-8449-2d62df55a6e4"), new Guid("a670b084-ae63-48c9-b248-7b997beaf486"), new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9347), "Óleo Reparador - Minipreço", 9.99m, 60, null },
                    { new Guid("8cea0461-31a2-4146-a936-cc881f97eeab"), new Guid("0149b95c-2857-445f-a0dd-16d591278e46"), new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9343), "Creme para Pentear - Lidl", 3.99m, 200, null },
                    { new Guid("97ecdc35-621e-46fd-a280-f34e00ce3340"), new Guid("da98f9aa-afd6-444f-a3dd-92b7ab32cf5d"), new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9350), "Máscara Capilar - El Corte Inglés", 14.99m, 110, null },
                    { new Guid("a6528c65-5d6d-4560-ad59-70703ed98e45"), new Guid("34e60c09-7b61-4cb4-97e3-0bd03f02f80b"), new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9342), "Condicionador Nutritivo - Pingo Doce", 5.99m, 150, null },
                    { new Guid("eabc1500-7d32-488b-9051-c062c9b23ad0"), new Guid("90c8513a-181c-4abd-a855-9864ecc044d8"), new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9348), "Serum Anti-Frizz - Aldi", 12.99m, 90, null },
                    { new Guid("f846a46b-64a3-4fb9-b88b-9e1da3b25fa7"), new Guid("e4a32804-3206-48dc-8dcd-a455480bac2c"), new DateTime(2024, 7, 25, 15, 4, 10, 26, DateTimeKind.Utc).AddTicks(9346), "Mousse Modelador - Intermarché", 7.99m, 120, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupermarketProduct_SupermarketId",
                table: "SupermarketProduct",
                column: "SupermarketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupermarketProduct");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Supermarket");
        }
    }
}
