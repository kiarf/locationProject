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
            _firstName = firstName;
            _lastName = lastName;
            BirthDate = birthDate;
            _licenceDate = licenceDate;
            _licenceNumber = licenceNumber;
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
            _firstName = firstName;
            _lastName = lastName;
            BirthDate = birthDate;
            _licenceDate = licenceDate;
            _licenceNumber = licenceNumber;
            Login = login;
            Password = password;
        }

        public string Login { get; }
        public string Password { get; }
        private string _firstName;
        private string _lastName;
        public DateTime BirthDate { get; }
        private DateTime _licenceDate;
        private string _licenceNumber;
    }
}