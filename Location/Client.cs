using System;

namespace Location
{
    public class Client
    {
        public Client(string firstName,
                      string lastName,
                      DateTime birthDate,
                      DateTime licenceDate,
                      string licenceNumber,
                      string login)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            LicenceDate = licenceDate;
            LicenceNumber = licenceNumber;
            Login = login;
        }

        public Client(string firstName,
                      string lastName,
                      DateTime birthDate,
                      DateTime licenceDate,
                      string licenceNumber,
                      string login,
                      string password)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            LicenceDate = licenceDate;
            LicenceNumber = licenceNumber;
            Login = login;
            Password = password;
        }

        public string Login { get; }
        public string Password { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDate { get; }
        public DateTime LicenceDate { get; }
        public string LicenceNumber { get; }
    }
}