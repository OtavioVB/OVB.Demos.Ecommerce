using OVB.Core.CrossCutting.Validator.Abstractions;
using OVB.Core.CrossCutting.Validator.GeneralFunctions;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Common.Models.Properties;
using System.Xml.Linq;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.Validators.Account;

public class AccountValidator : EcommerceOwnValidatorBase<IAccountGettersProperties, ValidationErrorItemStandard>
{
    protected override ValidationErrorItemStandard InvalidNullInput()
    {
        return new ValidationErrorItemStandard("Os dados inseridos são inválidos!");
    }

    public override void ValidationWorkflow(IAccountGettersProperties property)
    {
        base.ValidationWorkflow(property);

        ValidateUsername(property.Username);
        ValidateName(property.Name);
        ValidatePassword(property.Password);
        ValidateEmail(property.Email);
        ValidateSurname(property.Surname);
        ValidateOffice(property.Office);
        ValidateCPF(property.CPF);
    }

    protected virtual int MinimumLengthUsername { get; set; } = 5;
    protected virtual int MaximumLengthUsername { get; set; } = 30;
    protected virtual int MinimumLengthName { get; set; } = 3;
    protected virtual int MaximumLengthName { get; set; } = 30;
    protected virtual int MinimumLengthSurname { get; set; } = 3;
    protected virtual int MaximumLengthSurname { get; set; } = 50;
    protected virtual int MinimumLengthPassword { get; set; } = 8;
    protected virtual int MaximumLengthPassword { get; set; } = 64;
    protected virtual int MinimumLengthEmail { get; set; } = 5;
    protected virtual int MaximumLengthEmail { get; set; } = 256;

    #region Validação de Username
    protected virtual void ValidateUsername(string username)
    {
        if(ValidatorUtilities.VerifyInformationIsNotNull(username) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard("O nome de usuário não pode ser nulo."));
        }

        if (ValidatorUtilities.VerifyInformationHasHigherOrEqualOfMinimumQuantityOfCharacters(username, MinimumLengthUsername) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"O nome de usuário deve conter pelo menos {MinimumLengthUsername} caracteres."));
        }

        if (ValidatorUtilities.VerifyInformationHasLessOrEqualThanMaximumQuantityOfCharacters(username, MaximumLengthUsername) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"O nome de usuário deve conter até {MaximumLengthUsername} caracteres."));
        }

        if (ValidatorUtilities.VerifyInformationContainsPartInString(username, " ") == true)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard("O nome de usuário não deve conter espaços em branco."));
        }

        if (ValidatorUtilities.VerifyInformationContainsOnlyLetters(username) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard("O nome de usuário deve conter apenas letras."));
        }

        if (ValidatorUtilities.VerifyInformationContainsLettersWithPontuactions(username) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard("O nome de usuário não deve conter letras com pontuações."));
        }
    }
    #endregion

    #region Validação de Nome
    protected virtual void ValidateName(string name)
    {
        if (ValidatorUtilities.VerifyInformationIsNotNull(name) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard("O nome não pode ser nulo."));
        }

        if (ValidatorUtilities.VerifyInformationHasHigherOrEqualOfMinimumQuantityOfCharacters(name, MinimumLengthName) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"O nome deve conter pelo menos {MinimumLengthName} caracteres."));
        }

        if (ValidatorUtilities.VerifyInformationHasLessOrEqualThanMaximumQuantityOfCharacters(name, MaximumLengthName) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"O nome deve conter até {MaximumLengthName} caracteres."));
        }

        if (ValidatorUtilities.VerifyWhitespaceIsRegular(name) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"O nome não pode conter espaços em branco duplos."));
        }
    }
    #endregion

    #region Validação de Senha
    protected virtual void ValidatePassword(string password)
    {
        if (ValidatorUtilities.VerifyInformationIsNotNull(password) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard("A senha não pode ser nula."));
        }

        if (ValidatorUtilities.VerifyInformationHasHigherOrEqualOfMinimumQuantityOfCharacters(password, MinimumLengthPassword) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"A senha deve conter pelo menos {MinimumLengthPassword} caracteres."));
        }

        if (ValidatorUtilities.VerifyInformationHasLessOrEqualThanMaximumQuantityOfCharacters(password, MaximumLengthPassword) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"A senha deve conter até {MaximumLengthPassword} caracteres."));
        }

        if (ValidatorUtilities.VerifyInformationContainsPartInString(password, "@") == false &&
            ValidatorUtilities.VerifyInformationContainsPartInString(password, "%") == false &&
            ValidatorUtilities.VerifyInformationContainsPartInString(password, "$") == false &&
            ValidatorUtilities.VerifyInformationContainsPartInString(password, "&") == false &&
            ValidatorUtilities.VerifyInformationContainsPartInString(password, "*") == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"A senha deve conter símbolos @, %, $, & ou *"));
        }

        if (ValidatorUtilities.VerifyInformationHasLetter(password) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"A senha deve conter pelo menos uma letra."));
        }

        if (ValidatorUtilities.VerifyInformationHasNumbers(password) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"A senha deve conter pelo menos um número."));
        }

        if (ValidatorUtilities.VerifyInformationHasLowercase(password) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"A senha deve conter pelo menos uma letra em minúscula."));
        }

        if (ValidatorUtilities.VerifyInformationHasUppercase(password) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"A senha deve conter pelo menos uma letra em maiúscula."));
        }
    }
    #endregion

    #region Validação de Email
    protected virtual void ValidateEmail(string email)
    {
        if (ValidatorUtilities.VerifyInformationIsNotNull(email) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard("O email não pode ser nulo."));
        }

        if (ValidatorUtilities.VerifyInformationHasHigherOrEqualOfMinimumQuantityOfCharacters(email, MinimumLengthEmail) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"O email deve conter pelo menos {MinimumLengthEmail} caracteres."));
        }

        if (ValidatorUtilities.VerifyInformationHasLessOrEqualThanMaximumQuantityOfCharacters(email, MaximumLengthEmail) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"O email deve conter até {MaximumLengthEmail} caracteres."));
        }
    }
    #endregion

    #region Validação de Sobrenome
    protected virtual void ValidateSurname(string surname)
    {
        if (ValidatorUtilities.VerifyInformationIsNotNull(surname) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard("O sobrenome não pode ser nulo."));
        }

        if (ValidatorUtilities.VerifyInformationHasHigherOrEqualOfMinimumQuantityOfCharacters(surname, MinimumLengthSurname) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"O sobrenome deve conter pelo menos {MinimumLengthSurname} caracteres."));
        }

        if (ValidatorUtilities.VerifyInformationHasLessOrEqualThanMaximumQuantityOfCharacters(surname, MaximumLengthSurname) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"O sobrenome deve conter até {MaximumLengthSurname} caracteres."));
        }

        if (ValidatorUtilities.VerifyWhitespaceIsRegular(surname) == false)
        {
            AddValidationErrorItemMessage(new ValidationErrorItemStandard($"O sobrenome não pode conter espaços em branco duplos."));
        }
    }
    #endregion

    #region Validação de Cargo
    protected virtual void ValidateOffice(string office)
    {

    }
    #endregion

    #region Validação de CPF
    protected virtual void ValidateCPF(string cpf)
    {

    }
    #endregion
}
