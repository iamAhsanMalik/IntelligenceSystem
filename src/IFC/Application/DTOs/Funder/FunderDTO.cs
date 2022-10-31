namespace IFC.Application.DTOs.Funder;

public class FunderDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? FundingSource { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }
}
