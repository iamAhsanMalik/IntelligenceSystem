namespace IFC.Application.DTOs.Affiliate;

public class AffiliateDTO
{
    public long Id { get; set; }
    public string? LocalAffiliate { get; set; }
    public string? ForiegnAffiliate { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

}
