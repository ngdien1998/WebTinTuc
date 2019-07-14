using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTinTuc.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TinTuc");

            migrationBuilder.CreateTable(
                name: "DanhMuc",
                schema: "TinTuc",
                columns: table => new
                {
                    IdDanhMuc = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    TenDanhMuc = table.Column<string>(unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.IdDanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "QuanTriVien",
                schema: "TinTuc",
                columns: table => new
                {
                    Username = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    MatKhau = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    HoTen = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    GioiTinh = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    HinhDaiDien = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    ChucVu = table.Column<string>(unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanTriVien", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "BaiBao",
                schema: "TinTuc",
                columns: table => new
                {
                    IdBaiBao = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    TieuDe = table.Column<string>(unicode: false, nullable: false),
                    TomTat = table.Column<string>(unicode: false, nullable: false),
                    NoiDung = table.Column<string>(type: "longtext", nullable: false),
                    HinhAnh = table.Column<string>(unicode: false, nullable: false),
                    ThoiGianTao = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    IdDanhMuc = table.Column<long>(type: "bigint(20)", nullable: false),
                    LuotXem = table.Column<int>(type: "int(11)", nullable: true),
                    Tags = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiBao", x => x.IdBaiBao);
                    table.ForeignKey(
                        name: "BaiBao___DanhMuc",
                        column: x => x.IdDanhMuc,
                        principalSchema: "TinTuc",
                        principalTable: "DanhMuc",
                        principalColumn: "IdDanhMuc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "BaiBao___QuanTriVien",
                        column: x => x.Username,
                        principalSchema: "TinTuc",
                        principalTable: "QuanTriVien",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BinhLuan",
                schema: "TinTuc",
                columns: table => new
                {
                    IdBinhLuan = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    NoiDung = table.Column<string>(unicode: false, nullable: true),
                    TenNguoiBL = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ThoiGian = table.Column<DateTime>(nullable: false),
                    IdBLCha = table.Column<long>(type: "bigint(20)", nullable: true),
                    IdBaiBao = table.Column<long>(type: "bigint(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinhLuan", x => x.IdBinhLuan);
                    table.ForeignKey(
                        name: "BinhLuan___BaiBao",
                        column: x => x.IdBaiBao,
                        principalSchema: "TinTuc",
                        principalTable: "BaiBao",
                        principalColumn: "IdBaiBao",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "BinhLuan___BinhLuan",
                        column: x => x.IdBLCha,
                        principalSchema: "TinTuc",
                        principalTable: "BinhLuan",
                        principalColumn: "IdBinhLuan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "BaiBao___DanhMuc",
                schema: "TinTuc",
                table: "BaiBao",
                column: "IdDanhMuc");

            migrationBuilder.CreateIndex(
                name: "BaiBao___QuanTriVien",
                schema: "TinTuc",
                table: "BaiBao",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "BinhLuan___BaiBao",
                schema: "TinTuc",
                table: "BinhLuan",
                column: "IdBaiBao");

            migrationBuilder.CreateIndex(
                name: "BinhLuan___BinhLuan",
                schema: "TinTuc",
                table: "BinhLuan",
                column: "IdBLCha");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BinhLuan",
                schema: "TinTuc");

            migrationBuilder.DropTable(
                name: "BaiBao",
                schema: "TinTuc");

            migrationBuilder.DropTable(
                name: "DanhMuc",
                schema: "TinTuc");

            migrationBuilder.DropTable(
                name: "QuanTriVien",
                schema: "TinTuc");
        }
    }
}
