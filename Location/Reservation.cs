using System;

namespace Location
{
    public class Reservation
    {
        public readonly decimal EstimatedKilometers;
        public readonly Vehicle Vehicle;
        public DateTime EndDate;
        public decimal EstimatedPrice;
        public decimal FinalKilometers;
        public decimal FinalPrice;
        public string Login;
        public DateTime StartDate;

        public Reservation(Vehicle vehicle,
                           string login,
                           DateTime startDate,
                           DateTime endDate,
                           decimal estimatedKilometers)
        {
            Vehicle = vehicle;
            Login = login;
            StartDate = startDate;
            EndDate = endDate;
            EstimatedKilometers = estimatedKilometers;
            EstimatePrice();
        }

        public Reservation(Vehicle vehicle,
                           string login,
                           DateTime startDate,
                           DateTime endDate,
                           decimal estimatedKilometers,
                           decimal finalKilometers,
                           decimal estimatedPrice,
                           decimal finalPrice)
        {
            Vehicle = vehicle;
            Login = login;
            StartDate = startDate;
            EndDate = endDate;
            EstimatedKilometers = estimatedKilometers;
            FinalKilometers = finalKilometers;
            EstimatedPrice = estimatedPrice;
            FinalPrice = finalPrice;
        }

        public void EndReservation(decimal finalKilometers)
        {
            FinalKilometers = finalKilometers;
            CalculatePrice();
        }

        private void EstimatePrice()
        {
            EstimatedPrice = Vehicle.ReservationPrice + Vehicle.PricePerKilometer * EstimatedKilometers;
        }

        private void CalculatePrice()
        {
            FinalPrice = Vehicle.ReservationPrice + Vehicle.PricePerKilometer * FinalKilometers;
        }
    }
}