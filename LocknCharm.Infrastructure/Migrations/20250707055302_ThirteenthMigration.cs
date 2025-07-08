using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LocknCharm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ThirteenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"), new DateTime(2025, 7, 7, 5, 53, 2, 336, DateTimeKind.Utc).AddTicks(4079), "Bộ sưu tập móc khóa Thú Cưng đáng yêu dành cho những người yêu động vật. Từ những chú chó tinh nghịch đến mèo lười dễ thương, mỗi sản phẩm đều được thiết kế tỉ mỉ, mang lại cảm giác gần gũi và cá tính riêng. Phù hợp để treo trên balo, chìa khóa hoặc làm quà tặng đầy ý nghĩa.", "https://res.cloudinary.com/ddewgbug1/image/upload/v1751807280/7_tirqcu.png", "Móc khóa Thú Cưng", null },
                    { new Guid("3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"), new DateTime(2025, 7, 7, 5, 53, 2, 336, DateTimeKind.Utc).AddTicks(4100), "Những chiếc móc khóa Chibi siêu dễ thương với thiết kế nhân vật mini độc đáo, đáng yêu đến từng chi tiết. Phù hợp cho các fan anime, manga hoặc bất kỳ ai yêu thích phong cách dễ thương và nổi bật. Một món phụ kiện nhỏ nhưng đầy cá tính để thể hiện gu thẩm mỹ riêng của bạn.", "https://res.cloudinary.com/ddewgbug1/image/upload/v1751806861/edef84a7723416a1b2f0428f91b3f944_juhuh6.jpg", "Móc khóa Chibi", null },
                    { new Guid("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f90"), new DateTime(2025, 7, 7, 5, 53, 2, 336, DateTimeKind.Utc).AddTicks(4161), "Móc khóa Couple là biểu tượng ngọt ngào dành cho các cặp đôi. Thiết kế đôi độc đáo, có thể ghép lại với nhau như một mảnh ghép hoàn hảo, thể hiện sự gắn kết và tình yêu bền chặt. Phù hợp làm quà tặng trong các dịp kỷ niệm, Valentine hay đơn giản là để luôn mang theo một phần của người thương bên cạnh.", "https://res.cloudinary.com/ddewgbug1/image/upload/v1751807225/11_y71hx0.png", "Móc khóa Couple", null },
                    { new Guid("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f90a1"), new DateTime(2025, 7, 7, 5, 53, 2, 336, DateTimeKind.Utc).AddTicks(4164), "Móc khóa Doanh Nghiệp là lựa chọn quà tặng tinh tế và chuyên nghiệp cho khách hàng, đối tác hoặc sự kiện. Thiết kế tối giản nhưng sang trọng, dễ dàng in logo, slogan hoặc thông tin thương hiệu, giúp tăng độ nhận diện và để lại ấn tượng tốt với người nhận. Phù hợp cho hội nghị, sự kiện quảng bá hoặc tri ân khách hàng.", "https://res.cloudinary.com/ddewgbug1/image/upload/v1751807173/MICA-14_trrgit.jpg", "Móc khóa Doanh Nghiệp", null },
                    { new Guid("6f7a8b9c-0d1e-2f3a-4b5c-6d7e8f90a1b2"), new DateTime(2025, 7, 7, 5, 53, 2, 336, DateTimeKind.Utc).AddTicks(4167), "Móc khóa Lời Nhắn mang đến một cách đặc biệt để gửi gắm thông điệp yêu thương, động viên hoặc lời chúc đến người thân yêu. Mỗi chiếc móc khóa có thể in, khắc hoặc đính kèm lời nhắn ý nghĩa, tạo nên món quà nhỏ nhưng đong đầy cảm xúc. Phù hợp cho bạn bè, người yêu, gia đình – hoặc chính bản thân bạn như một lời nhắc nhở tích cực mỗi ngày.", "https://res.cloudinary.com/ddewgbug1/image/upload/v1751807198/8_kdtfrk.jpg", "Móc khóa Lời Nhắn", null },
                    { new Guid("7a8b9c0d-1e2f-3a4b-5c6d-7e8f90a1b2c3"), new DateTime(2025, 7, 7, 5, 53, 2, 336, DateTimeKind.Utc).AddTicks(4170), "Lấy cảm hứng từ tinh hoa văn hóa Việt Nam, bộ sưu tập Móc khóa Chất Việt tái hiện sống động những biểu tượng quen thuộc như cà phê phin đậm đà, ổ bánh mì giòn rụm hay cuốn gỏi thanh mát. Mỗi chiếc móc khóa là một lát cắt nhỏ của đời sống Việt – bình dị, gần gũi mà đầy tự hào. Phù hợp làm quà tặng độc đáo cho bạn bè quốc tế, người yêu ẩm thực, hoặc đơn giản là để bạn luôn mang theo hương vị quê hương bên mình.", "https://res.cloudinary.com/ddewgbug1/image/upload/v1751806345/17_et0abi.png", "Móc khóa Chất Việt", null }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "5abe826e-3ed4-44c8-a3bb-a3c9b8f61513", new DateTime(2025, 7, 7, 5, 53, 2, 222, DateTimeKind.Utc).AddTicks(7884) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "6a23bf10-08de-4e0b-8b51-1197c039ec03", new DateTime(2025, 7, 7, 5, 53, 2, 222, DateTimeKind.Utc).AddTicks(7887) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedTime",
                value: new DateTime(2025, 7, 7, 5, 53, 2, 336, DateTimeKind.Utc).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedTime",
                value: new DateTime(2025, 7, 7, 5, 53, 2, 336, DateTimeKind.Utc).AddTicks(3971));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aeb7db36-1baa-46b5-b9af-8ac486830ec3", new DateTime(2025, 7, 7, 5, 53, 2, 222, DateTimeKind.Utc).AddTicks(8046), "AQAAAAIAAYagAAAAEKPMOeZqZ20n4twCeYFV58vO+hwoYvcQMs+jMpUbQwJ2BTWbp9tAcRb20PY4z6d0ng==", "1a7f6b74-06ba-44fd-8e17-4f32dc4c4af9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b8fd8d1-8179-4aff-b446-8c0ae8819abb", new DateTime(2025, 7, 7, 5, 53, 2, 279, DateTimeKind.Utc).AddTicks(3491), "AQAAAAIAAYagAAAAEKy7lUPzF9l3JA2lggvoag/ZEq+xy4qHaDLAKu2OeypYeuBJsn4O5Bdx3S4rNMAIVA==", "8502e136-aabb-4577-bbf8-fa97802b44fd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f90"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f90a1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f7a8b9c-0d1e-2f3a-4b5c-6d7e8f90a1b2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7a8b9c0d-1e2f-3a4b-5c6d-7e8f90a1b2c3"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "087a9449-ed35-469c-a713-37dc92b103c3", new DateTime(2025, 7, 5, 3, 24, 56, 726, DateTimeKind.Utc).AddTicks(7026) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "7c03b581-74bb-4ab9-ab05-278f1d300020", new DateTime(2025, 7, 5, 3, 24, 56, 726, DateTimeKind.Utc).AddTicks(7029) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedTime",
                value: new DateTime(2025, 7, 5, 3, 24, 56, 840, DateTimeKind.Utc).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedTime",
                value: new DateTime(2025, 7, 5, 3, 24, 56, 840, DateTimeKind.Utc).AddTicks(1869));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "891396b0-424b-4080-bf50-25abbb86fe37", new DateTime(2025, 7, 5, 3, 24, 56, 726, DateTimeKind.Utc).AddTicks(7210), "AQAAAAIAAYagAAAAEAGGA0zn8K3UC141II+6mo3xC8IYilkg78uEcIHK64uSr3E3F1DXuGzXDNiepFA5eg==", "f553fa64-c374-4224-972a-405109264873" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce34abda-f35b-4f2b-ae06-381eade79546", new DateTime(2025, 7, 5, 3, 24, 56, 783, DateTimeKind.Utc).AddTicks(3487), "AQAAAAIAAYagAAAAEMy0LHZoArYeAVbirn4VQOUsOxfd3cPEClmqVFf8b2mZDKKw2ryHTpZZbw2WlCSnlw==", "cce74a35-ef62-428e-b00f-8327cfbb6781" });
        }
    }
}
