using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Location
{
    public class Agency
    {
        public Agency()
        {
            Vehicles = new List<Vehicle>();
            Clients = new List<Client>();
            Reservations = new List<Reservation>();
        }

        public List<Vehicle> Vehicles { get; }
        public List<Client> Clients { get; }
        public Client LoggedClient { get; set; }
        public List<Reservation> Reservations { get; }
        public string Output { get; set; }

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public List<Client> GetClients()
        {
            return Clients;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
        }

        public void LogClient(string login, string password)
        {
            var client = Clients.FirstOrDefault(l => l.Login == login);
            if (client != null)
            {
                if (Encoding.UTF8.GetString(Convert.FromBase64String(client.Password)) == password)
                {
                    LoggedClient = client;
                }
                else
                {
                    Output = "Wrong password";
                }
            }

            Output = "Unknown Login. Create acccount ?";
        }

        public List<Vehicle> GetAllVehicles()
        {
            return Vehicles;
        }

        public IEnumerable<Vehicle> GetAvailableVehicles(DateTime birthDate)
        {
            var availableVehicles = Vehicles.Where(vehicle => !Reservations.Any(reservation => reservation.StartDate < DateTime.Now && reservation.EndDate > DateTime.Now && reservation.Vehicle.Immatriculation == vehicle.Immatriculation))
                                            .ToList();

            //Au dessus de 25 ans : tout les véhicules
            if (birthDate.AddYears(25) <= DateTime.Now)
            {
                return availableVehicles;
            }

            availableVehicles.RemoveAll(v => v.HorsePower >= 13);

            //Entre 25 et 21 ans : tout les véhicules en dessous de 13 Cheveaux Fiscaux

            if (birthDate.AddYears(21) <= DateTime.Now)
            {
                return availableVehicles;
            }

            availableVehicles.RemoveAll(v => v.HorsePower >= 8);

            //Entre 25 et 18 ans : seulement les véhicules en dessous de 8 Cheveaux Fiscaux
            if (birthDate.AddYears(18) <= DateTime.Now)
            {
                return availableVehicles;
            }

            //En dessous de 18 ans : Location impossible
            Output = "Client must be 18 to loan a vehicle";
            return new List<Vehicle>();
        }

        public void AddReservation(Reservation reservation)
        {
            if (CheckReservation(reservation))
            {
                Reservations.Add(reservation);
            }
        }

        public List<Reservation> GetReservations()
        {
            return Reservations;
        }

        private bool CheckReservation(Reservation reservation)
        {
            var currentReservations = Reservations.Where(r => r.StartDate > reservation.StartDate && r.EndDate < reservation.EndDate).ToList();

            if (currentReservations.Any(r => r.Login == reservation.Login))
            {
                Output = "Only one reservation at a time for a client";
                return false;
            }

            if (currentReservations.Any(r => r.Vehicle.Immatriculation == reservation.Vehicle.Immatriculation))
            {
                Output = "The vehicle is not available during this period";
                return false;
            }

            return true;
        }
    }
}