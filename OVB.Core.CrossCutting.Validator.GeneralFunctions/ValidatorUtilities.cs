using Microsoft.VisualBasic;

namespace OVB.Core.CrossCutting.Validator.GeneralFunctions;

public static class ValidatorUtilities
{
    /// <summary>
    /// Verificar se a quantidade de caracteres é maior que a esperada
    /// </summary>
    public static bool VerifyInformationHasMinimumQuantityOfCharacters(string information, int minimumQuantity)
    {
        if (information.Length < minimumQuantity) return false;
        return true;
    }

    /// <summary>
    /// Verificar se a quantidade de caracteres é menor que a esperada
    /// </summary>
    public static bool VerifyInformationHasLessThanMaximumQuantityOfCharacters(string information, int maximumQuantity)
    {
        if (information.Length > maximumQuantity) return false;
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
}
