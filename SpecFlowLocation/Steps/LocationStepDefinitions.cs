using System;
using System.Linq;
using System.Text;
using FluentAssertions;
using Location;
using TechTalk.SpecFlow;

namespace SpecFlowLocation.Steps
{
    [Binding]
    public sealed class LocationStepDefinitions
    {
        private readonly Agency _agency = new Agency();

        [Given("the vehicles are")]
        public void GivenTheVehiclesAre(Table dataTable)
        {
            foreach (var row in dataTable.Rows)
            {
                _agency.AddVehicle(new Vehicle(row[0], row[1], row[2], row[3], decimal.Parse(row[4]), decimal.Parse(row[5]), int.Parse(row[6])));
            }
        }

        [Given("the clients are")]
        public void GivenTheClientsAre(Table dataTable)
        {
            foreach (var row in dataTable.Rows)
            {
                _agency.AddClient(new Client(row[0], row[1], DateTime.ParseExact(row[2], "dd/MM/yyyy", null), DateTime.ParseExact(row[3], "dd/MM/yyyy", null), row[4], row[5], row[6]));
            }
        }

        [Given(@"the reservations are")]
        public void GivenTheReservationsAre(Table dataTable)
        {
            foreach (var row in dataTable.Rows)
            {
                var vehicle = _agency.GetAllVehicles().FirstOrDefault(v => v.Immatriculation == row[0]);
                _agency.AddReservation(new Reservation(vehicle, row[1], DateTime.ParseExact(row[2], "dd/MM/yyyy", null), DateTime.ParseExact(row[3], "dd/MM/yyyy", null), decimal.Parse(row[4])));
            }
        }

        [Given(@"(.*) is logged in")]
        public void GivenIsLoggedIn(string login)
        {
            _agency.LoggedClient = _agency.GetClients().FirstOrDefault(c => c.Login == login);
        }

        [When("login")]
        public void WhenLogin(Table dataTable)
        {
            _agency.LogClient(dataTable.Rows[0][0], dataTable.Rows[0][1]);
        }

        [When("create new client")]
        public void WhenCreateNewClient(Table dataTable)
        {
            _agency.AddClient(new Client(dataTable.Rows[0][0], dataTable.Rows[0][1], DateTime.ParseExact(dataTable.Rows[0][2], "dd/MM/yyyy", null), DateTime.ParseExact(dataTable.Rows[0][3], "dd/MM/yyyy", null), dataTable.Rows[0][4], dataTable.Rows[0][5],
                                         Convert.ToBase64String(Encoding.UTF8.GetBytes(dataTable.Rows[0][6]))));
        }

        [When("loan vehicle")]
        public void WhenNewReservation(Table dataTable)
        {
            var vehicle = _agency.GetAllVehicles().FirstOrDefault(v => v.Immatriculation == dataTable.Rows[0][0]);
            _agency.AddReservation(new Reservation(vehicle,
                                                   dataTable.Rows[0][1],
                                                   DateTime.ParseExact(dataTable.Rows[0][2], "dd/MM/yyyy", null),
                                                   DateTime.ParseExact(dataTable.Rows[0][3], "dd/MM/yyyy", null),
                                                   decimal.Parse(dataTable.Rows[0][4])));
        }

        [When("close reservation")]
        public void WhenCloseReservation(Table dataTable)
        {
            var reservation = _agency.Reservations.FirstOrDefault(r => r.Vehicle.Immatriculation == dataTable.Rows[0][0] && r.Login == dataTable.Rows[0][1] && r.FinalPrice == 0);
            reservation?.EndReservation(decimal.Parse(dataTable.Rows[0][2]));
        }

        [Then(@"the user (.*) should be connected")]
        public void ThenTheUserShouldBeConnected(string login)
        {
            _agency.LoggedClient.Login.Should().Be(login);
        }

        [Then("the clients should be")]
        public void ThenTheResultOfTheBallotShouldBe(Table dataTable)
        {
            var clients = dataTable.Rows.Select(row => new Client(row[0], row[1], DateTime.ParseExact(row[2], "dd/MM/yyyy", null), DateTime.ParseExact(row[3], "dd/MM/yyyy", null), row[4], row[5], row[6])).ToList();
            _agency.GetClients().Should().BeEquivalentTo(clients);
        }

        [Then("the available vehicles should be")]
        public void ThenTheAvailableVehiclesShouldBe(Table dataTable)
        {
            var vehicles = dataTable.Rows.Select(row => new Vehicle(row[0], row[1], row[2], row[3], decimal.Parse(row[4]), decimal.Parse(row[5]), int.Parse(row[6]))).ToList();
            _agency.GetAvailableVehicles(_agency.LoggedClient.BirthDate).Should().BeEquivalentTo(vehicles);
        }

        [Then("the reservations should be")]
        public void ThenTheReservationShouldBe(Table dataTable)
        {
            var vehicles = _agency.GetAllVehicles();
            var reservations = dataTable.Rows.Select(row => new Reservation(vehicles.FirstOrDefault(v => v.Immatriculation == row[0]), row[1], DateTime.ParseExact(row[2], "dd/MM/yyyy", null), DateTime.ParseExact(row[3], "dd/MM/yyyy", null), decimal.Parse(row[4]),
                                                                            decimal.Parse(row[5]), decimal.Parse(row[6]), decimal.Parse(row[7])))
                                        .ToList();
            _agency.GetReservations().Should().BeEquivalentTo(reservations);
        }
    }
}