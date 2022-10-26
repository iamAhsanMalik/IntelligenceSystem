namespace IFC.Application.Contracts.Application;

internal interface ISecurityHelpers
{
    string Decrypt(string inputText);
    string DecryptQueryString(string inputText);
    string Encrypt(string inputText);
    string EncryptQueryString(string inputText);
}