namespace IFC.Application.Contracts.Application;

internal interface IGeneralHelpers
{
    decimal GetRoundDigit(string Amount);
    string GetUserStatus(int strStatus);
    string StringFixer(string inputValue);
}