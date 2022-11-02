namespace IFC.Application.Modules;

public static class IFCModules
{
    public static List<string> AppModulesList
    {
        get => new List<string>()
        { "Address","Affiliate","Approval",       "ApprovalRequestType","City","District","Funder","Incident","Involments","Location","OperationalBase","Organization","OrganizationFunder","RelationType","SectorHeadQuarter","SocialMediaProfile","SuspectFamilyDetail","TerrioristFamilyDetail","TerroristInvolvement","TerroristProfile","Threat","Wing"};
    }
}