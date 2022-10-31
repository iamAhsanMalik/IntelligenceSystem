namespace IFC.Application.Helpers;

internal sealed class ValidatorHelpers : IValidatorHelpers
{
    public bool EmailValidator(string email)
    {
        //regular expression pattern for valid email
        //addresses, allows for the following domains:
        //com,edu,info,gov,int,mil,net,org,biz,name,museum,coop,aero,pro,tv
        const string pattern = @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$";
        //Regular expression object
        Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
        //boolean variable to return to calling method

        //make sure an email address was provided
        if (string.IsNullOrEmpty(email))
        {
            return false;
        }
        else
        {
            //use IsMatch to validate the address
            return check.IsMatch(email);
        }
        //return the value to the calling method
    }

}
