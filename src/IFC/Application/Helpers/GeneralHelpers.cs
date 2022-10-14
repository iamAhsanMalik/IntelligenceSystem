namespace IFC.Application.Helpers;

public interface IGeneralHelpers
{
    decimal GetRoundDigit(string Amount);
    string GetUserStatus(int strStatus);
    string StringFixer(string inputValue);
}

internal sealed class GeneralHelpers : IGeneralHelpers
{
    public string StringFixer(string inputValue)
    {
        if (inputValue.Trim() != "")
        {
            inputValue = inputValue.Replace("'", "''");
        }
        return inputValue;
    }
    public string GetUserStatus(int strStatus)
    {
        if (strStatus == 1)
        {
            return "Active";
        }
        else
        {
            return "Inactive";
        }
    }

    public decimal GetRoundDigit(string Amount)
    {
        decimal LcAmount = Convert.ToDecimal(Amount);
        try
        {
            string[] pSplit = Amount.Split('.');
            string pdec = pSplit[1];
            string firstdigit = pdec.Substring(0, 1);
            string seconddigit = pdec[1].ToString();
            string thirddigit = pdec[2].ToString();
            string fourthdigit = pdec[3].ToString();
            if (Convert.ToInt32(firstdigit) > 0 && firstdigit == seconddigit && firstdigit == thirddigit && firstdigit == fourthdigit)
            {
                int div = Convert.ToInt32(pdec) % Convert.ToInt32(firstdigit);
                if (div == 0 && Convert.ToInt32(firstdigit) < 5)
                {
                    LcAmount = Math.Round(LcAmount, 2);
                    if (LcAmount > 0)
                    {
                        LcAmount += Convert.ToDecimal(0.01);
                    }
                    else
                    {
                        LcAmount -= Convert.ToDecimal(0.01);
                    }
                }
            }
            LcAmount = Math.Round(LcAmount, 2);
        }
        catch (Exception)
        {
            LcAmount = Math.Round(Convert.ToDecimal(Amount), 2);
        }
        return LcAmount;
    }
}
