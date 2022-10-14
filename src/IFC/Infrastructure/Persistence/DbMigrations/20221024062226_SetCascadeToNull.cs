using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFC.Infrastructure.Persistence.DbMigrations
{
    public partial class SetCascadeToNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_District",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_CoreHeadQuarter_SectorHeadQuarter",
                table: "CoreHeadQuarter");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Location",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Organizations",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_SuspectProfiles",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Wing",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationFunders_Funders",
                table: "OrganizationFunders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationFunders_Organizations",
                table: "OrganizationFunders");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Affiliates",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Involvements",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_OperationalBases",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_SocialMediaProfiles",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_SuspectFamilyDetails_RelationTypes",
                table: "SuspectFamilyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SuspectProfiles_Address",
                table: "SuspectProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_SuspectProfiles_Organizations",
                table: "SuspectProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_SuspectProfiles_SuspectFamilyDetails",
                table: "SuspectProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristFacilitatorsDetails_Address",
                table: "TerroristFacilitatorsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristFacilitatorsDetails_RelationTypes",
                table: "TerroristFacilitatorsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristFamilyDetails_Address",
                table: "TerroristFamilyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristFamilyDetails_RelationTypes",
                table: "TerroristFamilyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristProfiles_Address",
                table: "TerroristProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristProfiles_Organizations",
                table: "TerroristProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristProfiles_TerroristFacilitatorsDetails",
                table: "TerroristProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristProfiles_TerroristFamilyDetails",
                table: "TerroristProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristProfiles_TerroristInvolvements",
                table: "TerroristProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Threats_Incidents",
                table: "Threats");

            migrationBuilder.DropForeignKey(
                name: "FK_Threats_Location",
                table: "Threats");

            migrationBuilder.DropForeignKey(
                name: "FK_Threats_Organizations",
                table: "Threats");

            migrationBuilder.DropForeignKey(
                name: "FK_Threats_SuspectProfiles",
                table: "Threats");

            migrationBuilder.DropForeignKey(
                name: "FK_Threats_Wing",
                table: "Threats");

            migrationBuilder.DropForeignKey(
                name: "FK_Wing_CoreHeadQuarter",
                table: "Wing");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City",
                table: "Address",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_District",
                table: "Address",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_CoreHeadQuarter_SectorHeadQuarter",
                table: "CoreHeadQuarter",
                column: "SectorHeadQuarterId",
                principalTable: "SectorHeadQuarter",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Location",
                table: "Incidents",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Organizations",
                table: "Incidents",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_SuspectProfiles",
                table: "Incidents",
                column: "SuspectsProfileId",
                principalTable: "SuspectProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Wing",
                table: "Incidents",
                column: "WingId",
                principalTable: "Wing",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationFunders_Funders",
                table: "OrganizationFunders",
                column: "FunderId",
                principalTable: "Funders",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationFunders_Organizations",
                table: "OrganizationFunders",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Affiliates",
                table: "Organizations",
                column: "AffiliateId",
                principalTable: "Affiliates",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Involvements",
                table: "Organizations",
                column: "InvolvementId",
                principalTable: "Involvements",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_OperationalBases",
                table: "Organizations",
                column: "OperationalBaseId",
                principalTable: "OperationalBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_SocialMediaProfiles",
                table: "Organizations",
                column: "SocialMediaProfileId",
                principalTable: "SocialMediaProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SuspectFamilyDetails_RelationTypes",
                table: "SuspectFamilyDetails",
                column: "RelationTypeId",
                principalTable: "RelationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SuspectProfiles_Address",
                table: "SuspectProfiles",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SuspectProfiles_Organizations",
                table: "SuspectProfiles",
                column: "OrgnizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SuspectProfiles_SuspectFamilyDetails",
                table: "SuspectProfiles",
                column: "SuspectFamilyDetailsId",
                principalTable: "SuspectFamilyDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristFacilitatorsDetails_Address",
                table: "TerroristFacilitatorsDetails",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristFacilitatorsDetails_RelationTypes",
                table: "TerroristFacilitatorsDetails",
                column: "RelationTypeId",
                principalTable: "RelationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristFamilyDetails_Address",
                table: "TerroristFamilyDetails",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristFamilyDetails_RelationTypes",
                table: "TerroristFamilyDetails",
                column: "RelationTypeId",
                principalTable: "RelationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristProfiles_Address",
                table: "TerroristProfiles",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristProfiles_Organizations",
                table: "TerroristProfiles",
                column: "OrgnizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristProfiles_TerroristFacilitatorsDetails",
                table: "TerroristProfiles",
                column: "TerroristFacilitatorsDetailsId",
                principalTable: "TerroristFacilitatorsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristProfiles_TerroristFamilyDetails",
                table: "TerroristProfiles",
                column: "TerroristFamilyDetailsId",
                principalTable: "TerroristFamilyDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristProfiles_TerroristInvolvements",
                table: "TerroristProfiles",
                column: "TerroristInvolvementId",
                principalTable: "TerroristInvolvements",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_Incidents",
                table: "Threats",
                column: "IncidentId",
                principalTable: "Incidents",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_Location",
                table: "Threats",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_Organizations",
                table: "Threats",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_SuspectProfiles",
                table: "Threats",
                column: "SuspectsProfileId",
                principalTable: "SuspectProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_Wing",
                table: "Threats",
                column: "WingId",
                principalTable: "Wing",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Wing_CoreHeadQuarter",
                table: "Wing",
                column: "CoreHeadQuarterId",
                principalTable: "CoreHeadQuarter",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_District",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_CoreHeadQuarter_SectorHeadQuarter",
                table: "CoreHeadQuarter");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Location",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Organizations",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_SuspectProfiles",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Wing",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationFunders_Funders",
                table: "OrganizationFunders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationFunders_Organizations",
                table: "OrganizationFunders");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Affiliates",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Involvements",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_OperationalBases",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_SocialMediaProfiles",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_SuspectFamilyDetails_RelationTypes",
                table: "SuspectFamilyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SuspectProfiles_Address",
                table: "SuspectProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_SuspectProfiles_Organizations",
                table: "SuspectProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_SuspectProfiles_SuspectFamilyDetails",
                table: "SuspectProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristFacilitatorsDetails_Address",
                table: "TerroristFacilitatorsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristFacilitatorsDetails_RelationTypes",
                table: "TerroristFacilitatorsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristFamilyDetails_Address",
                table: "TerroristFamilyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristFamilyDetails_RelationTypes",
                table: "TerroristFamilyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristProfiles_Address",
                table: "TerroristProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristProfiles_Organizations",
                table: "TerroristProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristProfiles_TerroristFacilitatorsDetails",
                table: "TerroristProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristProfiles_TerroristFamilyDetails",
                table: "TerroristProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristProfiles_TerroristInvolvements",
                table: "TerroristProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Threats_Incidents",
                table: "Threats");

            migrationBuilder.DropForeignKey(
                name: "FK_Threats_Location",
                table: "Threats");

            migrationBuilder.DropForeignKey(
                name: "FK_Threats_Organizations",
                table: "Threats");

            migrationBuilder.DropForeignKey(
                name: "FK_Threats_SuspectProfiles",
                table: "Threats");

            migrationBuilder.DropForeignKey(
                name: "FK_Threats_Wing",
                table: "Threats");

            migrationBuilder.DropForeignKey(
                name: "FK_Wing_CoreHeadQuarter",
                table: "Wing");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City",
                table: "Address",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_District",
                table: "Address",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoreHeadQuarter_SectorHeadQuarter",
                table: "CoreHeadQuarter",
                column: "SectorHeadQuarterId",
                principalTable: "SectorHeadQuarter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Location",
                table: "Incidents",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Organizations",
                table: "Incidents",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_SuspectProfiles",
                table: "Incidents",
                column: "SuspectsProfileId",
                principalTable: "SuspectProfiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Wing",
                table: "Incidents",
                column: "WingId",
                principalTable: "Wing",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationFunders_Funders",
                table: "OrganizationFunders",
                column: "FunderId",
                principalTable: "Funders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationFunders_Organizations",
                table: "OrganizationFunders",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Affiliates",
                table: "Organizations",
                column: "AffiliateId",
                principalTable: "Affiliates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Involvements",
                table: "Organizations",
                column: "InvolvementId",
                principalTable: "Involvements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_OperationalBases",
                table: "Organizations",
                column: "OperationalBaseId",
                principalTable: "OperationalBases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_SocialMediaProfiles",
                table: "Organizations",
                column: "SocialMediaProfileId",
                principalTable: "SocialMediaProfiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SuspectFamilyDetails_RelationTypes",
                table: "SuspectFamilyDetails",
                column: "RelationTypeId",
                principalTable: "RelationTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SuspectProfiles_Address",
                table: "SuspectProfiles",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SuspectProfiles_Organizations",
                table: "SuspectProfiles",
                column: "OrgnizationId",
                principalTable: "Organizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SuspectProfiles_SuspectFamilyDetails",
                table: "SuspectProfiles",
                column: "SuspectFamilyDetailsId",
                principalTable: "SuspectFamilyDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristFacilitatorsDetails_Address",
                table: "TerroristFacilitatorsDetails",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristFacilitatorsDetails_RelationTypes",
                table: "TerroristFacilitatorsDetails",
                column: "RelationTypeId",
                principalTable: "RelationTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristFamilyDetails_Address",
                table: "TerroristFamilyDetails",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristFamilyDetails_RelationTypes",
                table: "TerroristFamilyDetails",
                column: "RelationTypeId",
                principalTable: "RelationTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristProfiles_Address",
                table: "TerroristProfiles",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristProfiles_Organizations",
                table: "TerroristProfiles",
                column: "OrgnizationId",
                principalTable: "Organizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristProfiles_TerroristFacilitatorsDetails",
                table: "TerroristProfiles",
                column: "TerroristFacilitatorsDetailsId",
                principalTable: "TerroristFacilitatorsDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristProfiles_TerroristFamilyDetails",
                table: "TerroristProfiles",
                column: "TerroristFamilyDetailsId",
                principalTable: "TerroristFamilyDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TerroristProfiles_TerroristInvolvements",
                table: "TerroristProfiles",
                column: "TerroristInvolvementId",
                principalTable: "TerroristInvolvements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_Incidents",
                table: "Threats",
                column: "IncidentId",
                principalTable: "Incidents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_Location",
                table: "Threats",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_Organizations",
                table: "Threats",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_SuspectProfiles",
                table: "Threats",
                column: "SuspectsProfileId",
                principalTable: "SuspectProfiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_Wing",
                table: "Threats",
                column: "WingId",
                principalTable: "Wing",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wing_CoreHeadQuarter",
                table: "Wing",
                column: "CoreHeadQuarterId",
                principalTable: "CoreHeadQuarter",
                principalColumn: "Id");
        }
    }
}
