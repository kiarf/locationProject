using System;

namespace Location
{
    public class Vehicle
    {
        public Vehicle(string immatriculation, string brand, string model, string color, decimal reservationPrice, decimal pricePerKilometer, int horsePower)
        {
            Immatriculation = immatriculation;
            Brand = brand;
            Model = model;
            Color = color;
            ReservationPrice = reservationPrice;
            PricePerKilometer = pricePerKilometer;
            HorsePower = horsePower;
        }

        public string Immatriculation { get; set; }
        private string Brand { get; set; }
        private string Model { get; set; }
        private string Color { get; set; }
        public decimal ReservationPrice{ get; set; }
        public decimal PricePerKilometer { get; set; }
        public int HorsePower { get; set; }
    }
}
