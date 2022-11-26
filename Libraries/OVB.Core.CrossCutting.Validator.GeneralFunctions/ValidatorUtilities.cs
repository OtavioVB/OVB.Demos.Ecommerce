using Microsoft.VisualBasic;

namespace OVB.Core.CrossCutting.Validator.GeneralFunctions;

public static class ValidatorUtilities
{
    /// <summary>
    /// Verificar se a quantidade de caracteres é maior que a esperada
    /// </summary>
    public static bool VerifyInformationHasHigherOrEqualOfMinimumQuantityOfCharacters(string information, int minimumQuantity)
    {
        if (information.Length < minimumQuantity) return false;
        return true;
    }

    /// <summary>
    /// Verificar se a quantidade de caracteres é menor que a esperada
    /// </summary>
    public static bool VerifyInformationHasLessOrEqualThanMaximumQuantityOfCharacters(string information, int maximumQuantity)
    {
        if (information.Length >= maximumQuantity) return false;
        return true;
    }

    /// <summary>
    /// Verificar se uma string contém um tipo de caractere
    /// </summary>
    public static bool VerifyInformationHasACharacter(string information, char character)
    {
        foreach (var charact in information)
        {
            if (charact == character)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Verificar se informação é nula
    /// </summary>
    public static bool VerifyInformationIsNull(string information)
    {
        return (information == string.Empty);
    }

    /// <summary>
    /// Verificar se informação não é nula
    /// </summary>
    public static bool VerifyInformationIsNotNull(string information)
    {
        return (information != string.Empty);
    }

    /// <summary>
    /// Verificar se uma string contém uma outra string
    /// </summary>
    public static bool VerifyInformationContainsPartInString(string information, string searchIn)
    {
        return information.Contains(searchIn);
    }

    /// <summary>
    /// Verificar se string contém letras com acentos/pontuações
    /// </summary>
    public static bool VerifyInformationContainsLettersWithPontuactions(string information)
    {
        if (VerifyInformationContainsPartInString(information, "á") ||
            VerifyInformationContainsPartInString(information, "à") ||
            VerifyInformationContainsPartInString(information, "é") ||
            VerifyInformationContainsPartInString(information, "è") ||
            VerifyInformationContainsPartInString(information, "â") ||
            VerifyInformationContainsPartInString(information, "ã") ||
            VerifyInformationContainsPartInString(information, "õ") ||
            VerifyInformationContainsPartInString(information, "ó") ||
            VerifyInformationContainsPartInString(information, "ò") ||
            VerifyInformationContainsPartInString(information, "í") ||
            VerifyInformationContainsPartInString(information, "ì") ||
            VerifyInformationContainsPartInString(information, "î") ||
            VerifyInformationContainsPartInString(information, "ô") ||
            VerifyInformationContainsPartInString(information, "ê") ||
            VerifyInformationContainsPartInString(information, "û") ||
            VerifyInformationContainsPartInString(information, "ú") ||
            VerifyInformationContainsPartInString(information, "ù"))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Verificar se string contém apenas letras
    /// </summary>
    public static bool VerifyInformationContainsOnlyLetters(string information)
    {
        foreach (char character in information)
        {
            if (char.IsLetter(character) == false)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Verificar se string contém espaços em branco regulares
    /// </summary>
    public static bool VerifyWhitespaceIsRegular(string information)
    {
        if (information.Contains("  "))
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Verificar se string contém letras
    /// </summary>
    public static bool VerifyInformationHasLetter(string information)
    {
        foreach (char character in information)
        {
            if (char.IsLetter(character))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Verificar se string contém letras maiúsculas
    /// </summary>
    public static bool VerifyInformationHasUppercase(string information)
    {
        foreach (char character in information)
        {
            if (char.IsUpper(character))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Verificar se string contém letras minúsculas
    /// </summary>
    public static bool VerifyInformationHasLowercase(string information)
    {
        foreach (char character in information)
        {
            if (char.IsLower(character))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Verificar se string contém números
    /// </summary>
    public static bool VerifyInformationHasNumbers(string information)
    {
        foreach (char character in information)
        {
            if (char.IsNumber(character))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Verificar se o email é válido
    /// </summary>
    public static bool VerifyEmailIsValid(string email)
    {
        return false;
    }
}
