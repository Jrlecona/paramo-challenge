namespace Sat.Recruitment.Domain.Entities;

public class AppSettings
{
    public AppSettings()
    {
    }

    public AppSettings(string nameError, string emailError, string addressError, string phoneError, string userCreated,
        string userDuplicated, string fileRoute, string emailFormatError)
    {
        NameError = nameError;
        EmailError = emailError;
        AddressError = addressError;
        PhoneError = phoneError;
        UserCreated = userCreated;
        UserDuplicated = userDuplicated;
        FileRoute = fileRoute;
        EmailFormatError = emailFormatError;
    }

    public string NameError { get; }
    public string EmailError { get; }
    public string AddressError { get; }
    public string PhoneError { get; }
    public string UserCreated { get; }
    public string UserDuplicated { get; }
    public string FileRoute { get; }
    public string EmailFormatError { get; }
}