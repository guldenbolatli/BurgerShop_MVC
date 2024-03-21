using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hamburger_MVC.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Burgerler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    VeganMi = table.Column<bool>(type: "bit", nullable: false),
                    UrunFotografı = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ad = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burgerler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Icecekler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "200, 1"),
                    UrunFotografı = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ad = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icecekler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IcMalzemeler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "300, 1"),
                    VeganMi = table.Column<bool>(type: "bit", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcMalzemeler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Soslar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "400, 1"),
                    VeganMi = table.Column<bool>(type: "bit", nullable: false),
                    UrunFotografı = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ad = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soslar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "YanUrunler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "500, 1"),
                    VeganMi = table.Column<bool>(type: "bit", nullable: false),
                    UrunFotografı = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ad = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YanUrunler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Adresler_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    SiparisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adet = table.Column<int>(type: "integer", nullable: false),
                    ToplamFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    SiparisDurumu = table.Column<string>(type: "nvarchar", nullable: false),
                    OdemeTipi = table.Column<string>(type: "nvarchar", nullable: false),
                    SiparisDetay = table.Column<string>(type: "nvarchar", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.SiparisID);
                    table.ForeignKey(
                        name: "FK_Siparisler_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menuler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToplamKalori = table.Column<int>(type: "integer", nullable: true),
                    SatisAdedi = table.Column<int>(type: "integer", nullable: false),
                    Boyut = table.Column<string>(type: "nvarchar", nullable: false),
                    UrunFotografı = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BurgerID = table.Column<int>(type: "int", nullable: false),
                    IcecekID = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menuler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Menuler_Burgerler_BurgerID",
                        column: x => x.BurgerID,
                        principalTable: "Burgerler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menuler_Icecekler_IcecekID",
                        column: x => x.IcecekID,
                        principalTable: "Icecekler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Burger_IcMalzemeler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BurgerID = table.Column<int>(type: "int", nullable: false),
                    IcMalzemeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burger_IcMalzemeler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Burger_IcMalzemeler_Burgerler_BurgerID",
                        column: x => x.BurgerID,
                        principalTable: "Burgerler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Burger_IcMalzemeler_IcMalzemeler_IcMalzemeID",
                        column: x => x.IcMalzemeID,
                        principalTable: "IcMalzemeler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sepetler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adet = table.Column<int>(type: "integer", nullable: false),
                    ToplamFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepetler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sepetler_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sepetler_Menuler_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menuler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Icecek_Customs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Adet = table.Column<int>(type: "integer", nullable: false),
                    ToplamFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    SepetID = table.Column<int>(type: "int", nullable: true),
                    IcecekID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icecek_Customs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Icecek_Customs_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Icecek_Customs_Icecekler_IcecekID",
                        column: x => x.IcecekID,
                        principalTable: "Icecekler",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Icecek_Customs_Sepetler_SepetID",
                        column: x => x.SepetID,
                        principalTable: "Sepetler",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Menu_IcMalzeme_Customs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    SepetID = table.Column<int>(type: "int", nullable: true),
                    IcMalzemeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_IcMalzeme_Customs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Menu_IcMalzeme_Customs_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menu_IcMalzeme_Customs_IcMalzemeler_IcMalzemeID",
                        column: x => x.IcMalzemeID,
                        principalTable: "IcMalzemeler",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Menu_IcMalzeme_Customs_Menuler_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menuler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menu_IcMalzeme_Customs_Sepetler_SepetID",
                        column: x => x.SepetID,
                        principalTable: "Sepetler",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Sos_Customs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Adet = table.Column<int>(type: "integer", nullable: false),
                    ToplamFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    SepetID = table.Column<int>(type: "int", nullable: true),
                    SosID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sos_Customs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sos_Customs_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sos_Customs_Sepetler_SepetID",
                        column: x => x.SepetID,
                        principalTable: "Sepetler",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Sos_Customs_Soslar_SosID",
                        column: x => x.SosID,
                        principalTable: "Soslar",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "YanUrun_Customs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Adet = table.Column<int>(type: "integer", nullable: false),
                    ToplamFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    SepetID = table.Column<int>(type: "int", nullable: true),
                    YanUrunId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YanUrun_Customs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_YanUrun_Customs_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YanUrun_Customs_Sepetler_SepetID",
                        column: x => x.SepetID,
                        principalTable: "Sepetler",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_YanUrun_Customs_YanUrunler_YanUrunId",
                        column: x => x.YanUrunId,
                        principalTable: "YanUrunler",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "0a3c49fa-3940-422c-b624-2bb6a8da2f68", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2, "a1acd1fd-5dc2-4a8c-ac49-436af9d6f91a", "Uye", "UYE" });

            migrationBuilder.CreateIndex(
                name: "IX_Adresler_UserID",
                table: "Adresler",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Burger_IcMalzemeler_BurgerID",
                table: "Burger_IcMalzemeler",
                column: "BurgerID");

            migrationBuilder.CreateIndex(
                name: "IX_Burger_IcMalzemeler_IcMalzemeID",
                table: "Burger_IcMalzemeler",
                column: "IcMalzemeID");

            migrationBuilder.CreateIndex(
                name: "IX_Icecek_Customs_IcecekID",
                table: "Icecek_Customs",
                column: "IcecekID");

            migrationBuilder.CreateIndex(
                name: "IX_Icecek_Customs_SepetID",
                table: "Icecek_Customs",
                column: "SepetID");

            migrationBuilder.CreateIndex(
                name: "IX_Icecek_Customs_UserID",
                table: "Icecek_Customs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_IcMalzeme_Customs_IcMalzemeID",
                table: "Menu_IcMalzeme_Customs",
                column: "IcMalzemeID");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_IcMalzeme_Customs_MenuID",
                table: "Menu_IcMalzeme_Customs",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_IcMalzeme_Customs_SepetID",
                table: "Menu_IcMalzeme_Customs",
                column: "SepetID");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_IcMalzeme_Customs_UserID",
                table: "Menu_IcMalzeme_Customs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Menuler_BurgerID",
                table: "Menuler",
                column: "BurgerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menuler_IcecekID",
                table: "Menuler",
                column: "IcecekID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepetler_MenuID",
                table: "Sepetler",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepetler_UserID",
                table: "Sepetler",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_UserID",
                table: "Siparisler",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Sos_Customs_SepetID",
                table: "Sos_Customs",
                column: "SepetID");

            migrationBuilder.CreateIndex(
                name: "IX_Sos_Customs_SosID",
                table: "Sos_Customs",
                column: "SosID");

            migrationBuilder.CreateIndex(
                name: "IX_Sos_Customs_UserID",
                table: "Sos_Customs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_YanUrun_Customs_SepetID",
                table: "YanUrun_Customs",
                column: "SepetID");

            migrationBuilder.CreateIndex(
                name: "IX_YanUrun_Customs_UserID",
                table: "YanUrun_Customs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_YanUrun_Customs_YanUrunId",
                table: "YanUrun_Customs",
                column: "YanUrunId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresler");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Burger_IcMalzemeler");

            migrationBuilder.DropTable(
                name: "Icecek_Customs");

            migrationBuilder.DropTable(
                name: "Menu_IcMalzeme_Customs");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Sos_Customs");

            migrationBuilder.DropTable(
                name: "YanUrun_Customs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "IcMalzemeler");

            migrationBuilder.DropTable(
                name: "Soslar");

            migrationBuilder.DropTable(
                name: "Sepetler");

            migrationBuilder.DropTable(
                name: "YanUrunler");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Menuler");

            migrationBuilder.DropTable(
                name: "Burgerler");

            migrationBuilder.DropTable(
                name: "Icecekler");
        }
    }
}
