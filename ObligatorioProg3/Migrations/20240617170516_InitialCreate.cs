using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObligatorioProg3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clima",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Temperatura = table.Column<short>(type: "smallint", nullable: false),
                    DescripciónClima = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clima__3214EC27DE0A7907", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Restaura__3214EC278ED62150", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__3214EC277562E1B3", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestauranteID = table.Column<int>(type: "int", nullable: false),
                    NombrePlato = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Menu__3214EC277A9EBA02", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Menu__Restaurant__4BAC3F29",
                        column: x => x.RestauranteID,
                        principalTable: "Restaurantes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroMesa = table.Column<int>(type: "int", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RestauranteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mesas__3214EC27E8E94DAE", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Mesas__Restauran__4316F928",
                        column: x => x.RestauranteID,
                        principalTable: "Restaurantes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolID = table.Column<int>(type: "int", nullable: false),
                    TipoPermisos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Permisos__3214EC2737D74335", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Permisos__RolID__619B8048",
                        column: x => x.RolID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__3214EC273E215491", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Usuarios__RolID__398D8EEE",
                        column: x => x.RolID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoCliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clientes__3214EC27A8AADB0A", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Clientes__Usuari__3D5E1FD2",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Resenas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    RestauranteID = table.Column<int>(type: "int", nullable: false),
                    Puntaje = table.Column<byte>(type: "tinyint", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaReseña = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reseñas__3214EC27242CF2E5", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Reseñas__Cliente__5DCAEF64",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Reseñas__Restaur__5EBF139D",
                        column: x => x.RestauranteID,
                        principalTable: "Restaurantes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    MesaID = table.Column<int>(type: "int", nullable: false),
                    RestauranteID = table.Column<int>(type: "int", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "datetime", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservas__3214EC2722C5E044", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Reservas__Client__46E78A0C",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Reservas__MesaID__47DBAE45",
                        column: x => x.MesaID,
                        principalTable: "Mesas",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Reservas__Restau__48CFD27E",
                        column: x => x.RestauranteID,
                        principalTable: "Restaurantes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservaID = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ordenes__3214EC276BDF29A0", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Ordenes__Reserva__4E88ABD4",
                        column: x => x.ReservaID,
                        principalTable: "Reservas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservaID = table.Column<int>(type: "int", nullable: false),
                    ClimaID = table.Column<int>(type: "int", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime", nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    TasaCambio = table.Column<double>(type: "float", nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pagos__3214EC27BB1C6511", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Pagos__ClienteID__5AEE82B9",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Pagos__ClimaID__59FA5E80",
                        column: x => x.ClimaID,
                        principalTable: "Clima",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Pagos__ReservaID__59063A47",
                        column: x => x.ReservaID,
                        principalTable: "Reservas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OrdenDetalles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenID = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrdenDet__3214EC27C97BA4AB", x => x.ID);
                    table.ForeignKey(
                        name: "FK__OrdenDeta__MenuI__52593CB8",
                        column: x => x.MenuID,
                        principalTable: "Menu",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__OrdenDeta__Orden__5165187F",
                        column: x => x.OrdenID,
                        principalTable: "Ordenes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UsuarioID",
                table: "Clientes",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_RestauranteID",
                table: "Menu",
                column: "RestauranteID");

            migrationBuilder.CreateIndex(
                name: "IX_Mesas_RestauranteID",
                table: "Mesas",
                column: "RestauranteID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDetalles_MenuID",
                table: "OrdenDetalles",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDetalles_OrdenID",
                table: "OrdenDetalles",
                column: "OrdenID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_ReservaID",
                table: "Ordenes",
                column: "ReservaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ClienteID",
                table: "Pagos",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ClimaID",
                table: "Pagos",
                column: "ClimaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ReservaID",
                table: "Pagos",
                column: "ReservaID");

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_RolID",
                table: "Permisos",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_Resenas_ClienteID",
                table: "Resenas",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Resenas_RestauranteID",
                table: "Resenas",
                column: "RestauranteID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ClienteID",
                table: "Reservas",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_MesaID",
                table: "Reservas",
                column: "MesaID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_RestauranteID",
                table: "Reservas",
                column: "RestauranteID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolID",
                table: "Usuarios",
                column: "RolID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenDetalles");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Resenas");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Clima");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Restaurantes");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
