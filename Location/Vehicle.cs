namespace Location
{
    public class Vehicle
    {
        public Vehicle(string immatriculation, string brand, string model, string color, decimal reservationPrice, decimal pricePerKilometer, int horsePower)
        {
            Immatriculation = immatriculation;
            _brand = brand;
            _model = model;
            _color = color;
            ReservationPrice = reservationPrice;
            PricePerKilometer = pricePerKilometer;
            HorsePower = horsePower;
        }

        public string Immatriculation { get; }
        private readonly string _brand;
        private readonly string _model;
        private readonly string _color;
        public decimal ReservationPrice { get; }
        public decimal PricePerKilometer { get; }
        public int HorsePower { get; }
    }
}