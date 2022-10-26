namespace IFC.Application.Contracts.Application;

internal interface IGeneratorHelpers
{
    string GenerateRandomCode(int codeCount = 5);
    string GenerateRandomDigit(int codeCount = 5);
    string GenerateRandomString(int length = 5);
}