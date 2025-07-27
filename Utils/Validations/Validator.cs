
namespace SimpleInventorySystem.Utils.Validation;

public static class Validator
{
    public static ValidationResult<string> ReadNonEmptyString(string prompt)
    {
        Console.Write($"{prompt}: ");
        var input = Console.ReadLine()?.Trim();
        return string.IsNullOrWhiteSpace(input)
            ? ValidationResult<string>.Failure("Input cannot be empty.")
            : ValidationResult<string>.Success(input);
    }

    public static ValidationResult<decimal> ReadDecimal(string prompt)
    {
        Console.Write($"{prompt}: ");
        var input = Console.ReadLine()?.Trim();
        return decimal.TryParse(input, out var result)
            ? ValidationResult<decimal>.Success(result)
            : ValidationResult<decimal>.Failure("Invalid decimal input.");
    }

    public static ValidationResult<int> ReadInt(string prompt)
    {
        Console.Write($"{prompt}: ");
        var input = Console.ReadLine()?.Trim();
        return int.TryParse(input, out var result)
            ? ValidationResult<int>.Success(result)
            : ValidationResult<int>.Failure("Invalid integer input.");
    }

    public static ValidationResult<uint> ReadUInt(string prompt)
    {
        Console.Write($"{prompt}: ");
        var input = Console.ReadLine()?.Trim();
        return uint.TryParse(input, out var result)
            ? ValidationResult<uint>.Success(result)
            : ValidationResult<uint>.Failure("Invalid unsigned integer input.");
    }

    public static ValidationResult<int?> ReadOptionalInt(string prompt)
    {
        Console.Write($"{prompt}: ");
        var input = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(input))
            return ValidationResult<int?>.Success(null);

        if (int.TryParse(input, out var value))
            return ValidationResult<int?>.Success(value);

        return ValidationResult<int?>.Failure("Invalid integer input.");
    }

    public static ValidationResult<decimal?> ReadOptionalDecimal(string prompt)
    {
        Console.Write($"{prompt}: ");
        var input = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(input))
            return ValidationResult<decimal?>.Success(null);

        if (decimal.TryParse(input, out var value))
            return ValidationResult<decimal?>.Success(value);

        return ValidationResult<decimal?>.Failure("Invalid decimal input.");
    }
    public static ValidationResult<string?> ReadOptionalString(string prompt)
    {
        Console.Write($"{prompt}: ");
        var input = Console.ReadLine()?.Trim();
        return string.IsNullOrWhiteSpace(input)
               ? ValidationResult<string?>.Success(null)
               : ValidationResult<string?>.Success(input);

    }


}

