﻿namespace IFC.Domain.Entities;

public class TerroristFamilyDetail
{
    public TerroristFamilyDetail()
    {
        TerroristProfiles = new HashSet<TerroristProfile>();
    }

    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? TribeOrCast { get; set; }
    public string? Sect { get; set; }
    public string? CNIC { get; set; }
    public string? Passport { get; set; }
    public bool? MaritalStatus { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public long? AddressId { get; set; }
    public long? RelationTypeId { get; set; }

    public virtual Address? Address { get; set; }
    public virtual RelationType? RelationType { get; set; }
    public virtual ICollection<TerroristProfile> TerroristProfiles { get; set; }
}
