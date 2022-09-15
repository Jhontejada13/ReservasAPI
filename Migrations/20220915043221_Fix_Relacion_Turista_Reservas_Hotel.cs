using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservasAPI.Migrations
{
    public partial class Fix_Relacion_Turista_Reservas_Hotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Turistas_TuristaId",
                table: "Hotel");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHotel_Hotel_HotelId",
                table: "ReservaHotel");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHotel_Turistas_TuristaId",
                table: "ReservaHotel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservaHotel",
                table: "ReservaHotel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_TuristaId",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "TuristaId",
                table: "Hotel");

            migrationBuilder.RenameTable(
                name: "ReservaHotel",
                newName: "ReservaHoteles");

            migrationBuilder.RenameTable(
                name: "Hotel",
                newName: "Hoteles");

            migrationBuilder.RenameColumn(
                name: "IdSucursal",
                table: "ReservaHoteles",
                newName: "IdHotel");

            migrationBuilder.RenameIndex(
                name: "IX_ReservaHotel_TuristaId",
                table: "ReservaHoteles",
                newName: "IX_ReservaHoteles_TuristaId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservaHotel_HotelId",
                table: "ReservaHoteles",
                newName: "IX_ReservaHoteles_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservaHoteles",
                table: "ReservaHoteles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hoteles",
                table: "Hoteles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaHoteles_Hoteles_HotelId",
                table: "ReservaHoteles",
                column: "HotelId",
                principalTable: "Hoteles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaHoteles_Turistas_TuristaId",
                table: "ReservaHoteles",
                column: "TuristaId",
                principalTable: "Turistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHoteles_Hoteles_HotelId",
                table: "ReservaHoteles");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHoteles_Turistas_TuristaId",
                table: "ReservaHoteles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservaHoteles",
                table: "ReservaHoteles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hoteles",
                table: "Hoteles");

            migrationBuilder.RenameTable(
                name: "ReservaHoteles",
                newName: "ReservaHotel");

            migrationBuilder.RenameTable(
                name: "Hoteles",
                newName: "Hotel");

            migrationBuilder.RenameColumn(
                name: "IdHotel",
                table: "ReservaHotel",
                newName: "IdSucursal");

            migrationBuilder.RenameIndex(
                name: "IX_ReservaHoteles_TuristaId",
                table: "ReservaHotel",
                newName: "IX_ReservaHotel_TuristaId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservaHoteles_HotelId",
                table: "ReservaHotel",
                newName: "IX_ReservaHotel_HotelId");

            migrationBuilder.AddColumn<int>(
                name: "TuristaId",
                table: "Hotel",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservaHotel",
                table: "ReservaHotel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_TuristaId",
                table: "Hotel",
                column: "TuristaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Turistas_TuristaId",
                table: "Hotel",
                column: "TuristaId",
                principalTable: "Turistas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaHotel_Hotel_HotelId",
                table: "ReservaHotel",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaHotel_Turistas_TuristaId",
                table: "ReservaHotel",
                column: "TuristaId",
                principalTable: "Turistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
