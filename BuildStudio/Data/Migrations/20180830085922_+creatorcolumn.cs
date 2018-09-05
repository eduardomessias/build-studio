using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BuildStudio.Data.Migrations
{
    public partial class creatorcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Creation",
                table: "Results",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Results",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Update",
                table: "Results",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Creation",
                table: "Requirements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Requirements",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Update",
                table: "Requirements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "FunctionalSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Update",
                table: "FunctionalSpecifications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Creation",
                table: "Functionalities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Functionalities",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Update",
                table: "Functionalities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Creation",
                table: "ExpectedResults",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "ExpectedResults",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Update",
                table: "ExpectedResults",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Creation",
                table: "Conditions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Conditions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Update",
                table: "Conditions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Creation",
                table: "AcceptanceCriterias",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "AcceptanceCriterias",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Update",
                table: "AcceptanceCriterias",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creation",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Update",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Creation",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "Update",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "Creator",
                table: "FunctionalSpecifications");

            migrationBuilder.DropColumn(
                name: "Update",
                table: "FunctionalSpecifications");

            migrationBuilder.DropColumn(
                name: "Creation",
                table: "Functionalities");

            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Functionalities");

            migrationBuilder.DropColumn(
                name: "Update",
                table: "Functionalities");

            migrationBuilder.DropColumn(
                name: "Creation",
                table: "ExpectedResults");

            migrationBuilder.DropColumn(
                name: "Creator",
                table: "ExpectedResults");

            migrationBuilder.DropColumn(
                name: "Update",
                table: "ExpectedResults");

            migrationBuilder.DropColumn(
                name: "Creation",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "Update",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "Creation",
                table: "AcceptanceCriterias");

            migrationBuilder.DropColumn(
                name: "Creator",
                table: "AcceptanceCriterias");

            migrationBuilder.DropColumn(
                name: "Update",
                table: "AcceptanceCriterias");
        }
    }
}
