using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BuildStudio.Data.Migrations
{
    public partial class CU01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Creator",
                table: "Results",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Creator",
                table: "Requirements",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Creator",
                table: "FunctionalSpecifications",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Creator",
                table: "Functionalities",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Creator",
                table: "ExpectedResults",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Creator",
                table: "Conditions",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Creator",
                table: "AcceptanceCriterias",
                newName: "ModifiedBy");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Results",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Results",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Requirements",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Requirements",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "FunctionalSpecifications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FunctionalSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Functionalities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Functionalities",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "ExpectedResults",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ExpectedResults",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Conditions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Conditions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "AcceptanceCriterias",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AcceptanceCriterias",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "FunctionalSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FunctionalSpecifications");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Functionalities");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Functionalities");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "ExpectedResults");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ExpectedResults");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "AcceptanceCriterias");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AcceptanceCriterias");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Results",
                newName: "Creator");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Requirements",
                newName: "Creator");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "FunctionalSpecifications",
                newName: "Creator");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Functionalities",
                newName: "Creator");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ExpectedResults",
                newName: "Creator");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Conditions",
                newName: "Creator");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "AcceptanceCriterias",
                newName: "Creator");
        }
    }
}
