Feature: Login


Background: 
Given the clients are
	| FirstName   | LastName | BirthDate  | LicenceDate | LicenceNumber | Login     | Password |
	| Francois    | Roullaud | 16/10/1999 | 04/09/2019  | 20AF45091     | froullaud | YXplcnR5 |
	| Johan       | Campion  | 13/07/1997 | 02/11/2017  | 19BF25467     | jcampion  | YXplcnR5 |
	| Jean-Michel | Osef     | 14/02/1954 | 02/09/1972  | 21CF16547     | jmosef    | YXplcnR5 |

Scenario: Login froullaud
	When login 
	| Login | Password |
	|froullaud | azerty| 
	Then the user froullaud should be connected

Scenario: Create new Client 
	When create new client 
	| FirstName | LastName | BirthDate  | LicenceDate | LicenceNumber | Login   | Password |
	| Philippe  | Random   | 06/09/1999 | 01/08/2018  | 80AF41651     | prandom | azerty   |
	Then the clients should be 
	| FirstName   | LastName | BirthDate  | LicenceDate | LicenceNumber | Login     | Password |
	| Francois    | Roullaud | 16/10/1999 | 04/09/2019  | 20AF45091     | froullaud | YXplcnR5 |
	| Jean-Michel | Osef     | 14/02/1954 | 02/09/1972  | 21CF16547     | jmosef    | YXplcnR5 |
	| Johan       | Campion  | 13/07/1997 | 02/11/2017  | 19BF25467     | jcampion  | YXplcnR5 |
	| Philippe    | Random   | 06/09/1999 | 01/08/2018  | 80AF41651     | prandom   | YXplcnR5 |
