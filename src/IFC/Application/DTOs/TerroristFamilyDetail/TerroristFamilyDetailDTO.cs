﻿namespace IFC.Application.DTOs.TerroristFamilyDetail;

public class TerroristFamilyDetailDTO
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get => $"{FirstName} {LastName}"; }
    public DateTime? DateOfBirth { get; set; }
    public string? TribeOrCast { get; set; }
    public string? Sect { get; set; }
    public string? CNIC { get; set; }
    public string? Passport { get; set; }
    public bool? MaritalStatus { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }



    public virtual string? Address { get; set; }
    public virtual string? RelationType { get; set; }
}