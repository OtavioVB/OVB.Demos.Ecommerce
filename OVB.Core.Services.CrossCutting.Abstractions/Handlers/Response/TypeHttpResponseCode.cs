namespace OVB.Core.Services.CrossCutting.Abstractions.Handlers.Response;

public enum TypeHttpResponseCode
{
    Ok = 200,
    Created = 201,
    BadRequest = 400,
    Forbidden = 403,
    NotFound = 404,
    TooManyRequests = 429,
    RequestHeaderFieldsToLarge = 431,
    InternalServerError = 500,
    ServiceUnavailable = 503
}
