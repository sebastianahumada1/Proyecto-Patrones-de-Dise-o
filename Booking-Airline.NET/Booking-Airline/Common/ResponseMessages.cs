namespace Booking_Airline.Common;

public class ResponseMessages
{
    public const string CreateResource = "El recurso se creó con éxito.";
    public const string UpdateResource = "El recurso se actualizó con éxito.";
    public const string DeleteResource = "El recurso se eliminó con éxito.";
    public const string GetResource = "Recurso obtenido con éxito.";
    public const string ResourceNotFound = "Recurso no encontrado.";
    public const string ResourceNotCreated = "El recurso no pudo ser creado, hubo un error";
    public const string ResourceFromAnotherUser = "El recurso es de otro usuario.";
    public const string ResourceNotUpdated = "El recurso no se actualizó";
    public const string ResourceNotDeleted = "El recurso no se eliminó.";

    public const string Success = "Éxito";
    public const string Error = "Error";
    public const string NotFound = "Registro no encontrado";
    public const string MatchNoFound = "No se ha encontrado ninguna coincidencia.";

    public const string ValidationError = "Se encontró un error de validación";
    public const string ValidationErrors = "Se encontraron errores de validación";
    public const string UnexpectedError = "Hubo un error inesperado, por favor intente de nuevo";
    public const string UnexpectedErrors = "Se encontraron errores inesperados, por favor intente de nuevo";
    public const string PropertyFailedValidation = "Property '{0}' failed validation. Error was: {1}.";
    public const string UniqueConstraintViolated = "Se detectó una violación a una restricción única (UNIQUE INDEX). " +
                                                                            "Por favor, no envíe una entrada duplicada.";

    public const string EmailNotExists = "El correo no existe";
    public const string EmailExists = "El correo ya existe";


    public const string UserNotExists = "El usuario no existe";
    public const string PersonNotExists = "La persona no existe";
    public const string UserExists = "El usuario ya existe";
    public const string UserInactive = "El usuario se encuentra inactivo o desactivado";
    public const string RoleNotExists = "El rol no existe";
    public const string RoleInactive = "El rol se encuentra inactivo o desactivado";

    public const string InvalidCredentials = "El usuario y/o la contraseña son incorrectos";
    public const string InvalidPassword = "La contraseña es incorrecta";
    public const string UnknownPasswordChangeError = "Hubo un error desconocido y no se pudo cambiar la contraseña, mira lo detalles";

    public const string FlightNotExists = "El vuelo no existe";
    public const string PassengerNotExists = "El pasajero no existe";
    public const string PassengerExists = "El pasajero ya existe en el vuelo";
}