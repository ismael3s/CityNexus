namespace CityNexus.People.Domain.VO;

public enum DocumentType
{
    Cpf = 1,
}

public sealed record Document(string Value, DocumentType Type)
{
    public static Document Create(string value, DocumentType type = DocumentType.Cpf)
    {
        var document = new Document(value, type);
        if (!IsAValidCpf(value))
        {
            throw new Exception($"Invalid Cpf value: {value}"); 
        }
        return document;
    }

    private static bool IsAValidCpf(string cpf)
    {
        int[] multiplier = [10, 9, 8, 7, 6, 5, 4, 3, 2];
        int[] secondMultiplier = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];
        cpf = cpf.Trim()
            .Replace(".", "")
            .Replace("-", "");
        if (cpf.Length != 11)
            return false;
        var tempCpf = cpf[..9];
        var sum = 0;
        for (var i = 0; i < 9; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multiplier[i];
        var rest = sum % 11;
        if (rest < 2) rest = 0;
        else rest = 11 - rest;
        var digit = rest.ToString();
        tempCpf += digit;
        sum = 0;
        for (var i = 0; i < 10; i++)
            sum += int.Parse(tempCpf[i].ToString()) * secondMultiplier[i];
        rest = sum % 11;
        if (rest < 2)
            rest = 0;
        else
            rest = 11 - rest;
        digit += rest;
        return cpf.EndsWith(digit);
    }
};