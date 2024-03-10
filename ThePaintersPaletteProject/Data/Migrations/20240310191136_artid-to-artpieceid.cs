using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThePaintersPaletteProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class artidtoartpieceid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetail_ArtPiece_ArtPieceArtId",
                table: "CartDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_ArtPiece_ArtPiecesArtId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ArtId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ArtId",
                table: "CartDetail");

            migrationBuilder.RenameColumn(
                name: "ArtPiecesArtId",
                table: "OrderDetail",
                newName: "ArtPieceId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ArtPiecesArtId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ArtPieceId");

            migrationBuilder.RenameColumn(
                name: "ArtPieceArtId",
                table: "CartDetail",
                newName: "ArtPieceId");

            migrationBuilder.RenameIndex(
                name: "IX_CartDetail_ArtPieceArtId",
                table: "CartDetail",
                newName: "IX_CartDetail_ArtPieceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetail_ArtPiece_ArtPieceId",
                table: "CartDetail",
                column: "ArtPieceId",
                principalTable: "ArtPiece",
                principalColumn: "ArtId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_ArtPiece_ArtPieceId",
                table: "OrderDetail",
                column: "ArtPieceId",
                principalTable: "ArtPiece",
                principalColumn: "ArtId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetail_ArtPiece_ArtPieceId",
                table: "CartDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_ArtPiece_ArtPieceId",
                table: "OrderDetail");

            migrationBuilder.RenameColumn(
                name: "ArtPieceId",
                table: "OrderDetail",
                newName: "ArtPiecesArtId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ArtPieceId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ArtPiecesArtId");

            migrationBuilder.RenameColumn(
                name: "ArtPieceId",
                table: "CartDetail",
                newName: "ArtPieceArtId");

            migrationBuilder.RenameIndex(
                name: "IX_CartDetail_ArtPieceId",
                table: "CartDetail",
                newName: "IX_CartDetail_ArtPieceArtId");

            migrationBuilder.AddColumn<int>(
                name: "ArtId",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArtId",
                table: "CartDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetail_ArtPiece_ArtPieceArtId",
                table: "CartDetail",
                column: "ArtPieceArtId",
                principalTable: "ArtPiece",
                principalColumn: "ArtId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_ArtPiece_ArtPiecesArtId",
                table: "OrderDetail",
                column: "ArtPiecesArtId",
                principalTable: "ArtPiece",
                principalColumn: "ArtId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
