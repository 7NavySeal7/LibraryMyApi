using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Core.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Library");

            migrationBuilder.EnsureSchema(
                name: "Master");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "Library",
                columns: table => new
                {
                    IdAuthor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.IdAuthor);
                });

            migrationBuilder.CreateTable(
                name: "Editorial",
                schema: "Library",
                columns: table => new
                {
                    IdEditorial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Editorial = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorial", x => x.IdEditorial);
                });

            migrationBuilder.CreateTable(
                name: "TypeBook",
                schema: "Library",
                columns: table => new
                {
                    IdTypeBook = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeBook = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeBook", x => x.IdTypeBook);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "Master",
                columns: table => new
                {
                    IdState = table.Column<int>(nullable: false),
                    State = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.IdState);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "Security",
                columns: table => new
                {
                    IdRol = table.Column<int>(nullable: false),
                    Rol = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "TypePermission",
                schema: "Security",
                columns: table => new
                {
                    IdTypePermission = table.Column<int>(nullable: false),
                    TypePermission = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePermission", x => x.IdTypePermission);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Security",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Password = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "Library",
                columns: table => new
                {
                    IdBook = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    DateRelease = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    IdEditorial = table.Column<int>(nullable: false),
                    IdTypeBook = table.Column<int>(nullable: false),
                    IdState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.IdBook);
                    table.ForeignKey(
                        name: "FK_Book_Editorial_IdEditorial",
                        column: x => x.IdEditorial,
                        principalSchema: "Library",
                        principalTable: "Editorial",
                        principalColumn: "IdEditorial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_State_IdState",
                        column: x => x.IdState,
                        principalSchema: "Master",
                        principalTable: "State",
                        principalColumn: "IdState",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_TypeBook_IdTypeBook",
                        column: x => x.IdTypeBook,
                        principalSchema: "Library",
                        principalTable: "TypeBook",
                        principalColumn: "IdTypeBook",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "Security",
                columns: table => new
                {
                    IdPermission = table.Column<int>(nullable: false),
                    Permission = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    IdTypePermission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.IdPermission);
                    table.ForeignKey(
                        name: "FK_Permission_TypePermission_IdTypePermission",
                        column: x => x.IdTypePermission,
                        principalSchema: "Security",
                        principalTable: "TypePermission",
                        principalColumn: "IdTypePermission",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolUser",
                schema: "Security",
                columns: table => new
                {
                    IdRolUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(nullable: false),
                    idUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUser", x => x.IdRolUser);
                    table.ForeignKey(
                        name: "FK_RolUser_Rol_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "Security",
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUser_User_idUser",
                        column: x => x.idUser,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                schema: "Library",
                columns: table => new
                {
                    IdAuthorBook = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAuthor = table.Column<int>(nullable: false),
                    IdBook = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => x.IdAuthorBook);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Author_IdAuthor",
                        column: x => x.IdAuthor,
                        principalSchema: "Library",
                        principalTable: "Author",
                        principalColumn: "IdAuthor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Book_IdBook",
                        column: x => x.IdBook,
                        principalSchema: "Library",
                        principalTable: "Book",
                        principalColumn: "IdBook",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolPermissions",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(nullable: false),
                    IdPermission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolPermissions_Permission_IdPermission",
                        column: x => x.IdPermission,
                        principalSchema: "Security",
                        principalTable: "Permission",
                        principalColumn: "IdPermission",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolPermissions_Rol_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "Security",
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_IdAuthor",
                schema: "Library",
                table: "AuthorBook",
                column: "IdAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_IdBook",
                schema: "Library",
                table: "AuthorBook",
                column: "IdBook");

            migrationBuilder.CreateIndex(
                name: "IX_Book_IdEditorial",
                schema: "Library",
                table: "Book",
                column: "IdEditorial");

            migrationBuilder.CreateIndex(
                name: "IX_Book_IdState",
                schema: "Library",
                table: "Book",
                column: "IdState");

            migrationBuilder.CreateIndex(
                name: "IX_Book_IdTypeBook",
                schema: "Library",
                table: "Book",
                column: "IdTypeBook");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_IdTypePermission",
                schema: "Security",
                table: "Permission",
                column: "IdTypePermission");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermissions_IdPermission",
                schema: "Security",
                table: "RolPermissions",
                column: "IdPermission");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermissions_IdRol",
                schema: "Security",
                table: "RolPermissions",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_RolUser_IdRol",
                schema: "Security",
                table: "RolUser",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_RolUser_idUser",
                schema: "Security",
                table: "RolUser",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "Security",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "RolPermissions",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "RolUser",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "Book",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Editorial",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "State",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "TypeBook",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "TypePermission",
                schema: "Security");
        }
    }
}
