Feature: Location

Background: 
Given the clients are
	| FirstName   | LastName | BirthDate  | LicenceDate | LicenceNumber | Login     | Password |
	| Francois    | Roullaud | 16/10/1999 | 04/09/2019  | 20AF45091     | froullaud | YXplcnR5 |
	| Johan       | Campion  | 13/07/1997 | 02/11/2017  | 19BF25467     | jcampion  | YXplcnR5 |
	| Jean-Michel | Osef     | 14/02/1954 | 02/09/1972  | 21CF16547     | jmosef    | YXplcnR5 |
	And the vehicles are
	| Immatriculation | Model     | Brand   | Color | ReservationPrice | PricePerKilometer | HorsePower |
	| 24 EFR 14       | Clio 2    | Renault | Blue  | 25               | 0.5               | 2          |
	| 01 BML 98       | Batmobile | Ford    | Black | 150              | 2                 | 9          |
	| 98 PZL 21       | SS 180    | Vesoa   | Red   | 500              | 15                | 14         |
	And froullaud is logged in	
	

Scenario: Get available vehicles
	Given the reservations are
	| Immatriculation | Login    | StartDate  | EndDate    | EstimatedKilometers |
	| 24 EFR 14       | jcampion | 11/03/2022 | 12/06/2022 | 25                  |
	| 01 BML 98       | jcampion | 11/03/2021 | 12/03/2021 | 100                 |
	Then the available vehicles should be
	| Immatriculation | Model     | Brand   | Color | ReservationPrice | PricePerKilometer | HorsePower |
	| 01 BML 98       | Batmobile | Ford    | Black | 150              | 2                 | 9          |

Scenario: Make reservation
	When loan vehicle
	| Immatriculation | Login     | StartDate  | EndDate    | EstimatedKilometers |
	| 01 BML 98       | froullaud | 13/03/2022 | 15/03/2022 | 100                 | 
	Then the reservations should be
	| Immatriculation | Login     | StartDate  | EndDate    | EstimatedKilometers | FinalKilometers | EstimatedPrice | FinalPrice |
	| 01 BML 98       | froullaud | 13/03/2022 | 15/03/2022 | 100                 | 0               | 350            | 0          |

Scenario: Close reservation
Given the reservations are
	| Immatriculation | Login     | StartDate  | EndDate    | EstimatedKilometers |
	| 01 BML 98       | froullaud | 13/03/2022 | 15/03/2022 | 100                 |
	When close reservation
	| Immatriculation | Login     | FinalKilometers |
	| 01 BML 98       | froullaud | 150             |
	Then the reservations should be
	| Immatriculation | Login     | StartDate  | EndDate    | EstimatedKilometers | FinalKilometers | EstimatedPrice | FinalPrice |
	| 01 BML 98       | froullaud | 13/03/2022 | 15/03/2022 | 100                 | 150             | 350            | 450        |

