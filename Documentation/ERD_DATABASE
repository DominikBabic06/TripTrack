User                    Logbook                      Vehicle
-------                 -----------                  -------
ID (PK*)      <---       ID (PK*)                    ID (PK*)
Username    |   |--FK*-> Team_ID (FK*) <--------     Team_ID (FK*)
Email       |   |--FK*-> Driver_ID (FK*)             Lisence_Plate
Name        |            Period                      Brand
            |            Kilometer_Total             Model
            |            Vehicle_Using               Colour
            |                                        Odometer
            |                                        Type
            |                                        Construction_Year
            |                                        Current_Location

Driver_FK <--Trips--> Vehicle_FK
-------               -------
ID (PK*)              ID (PK*)
Date                  Purpose_Of_Trip
Time_Departue         Type_Of_Trip
Time_Arrival          Status
Kilometerstand_A      


PK: Primary Key 
FK: FOREIGN KEY


## User

- **ID**: Eindeutige Identifikation, die jeden Nutzer eindeutig identifiziert.
- **Username (USERNAME)**: Eindeutiger Name des Nutzers, bestehend aus 4 bis 30 Zeichen. Erlaubte Zeichen sind A-Z, a-z, 0-9, ß, ö, ä, ü und das Sonderzeichen "-". (varchar)
- **Email (EMAIL)**: Derzeit wird die E-Mail nur für Login-Zwecke verwendet. Zukünftig könnte sie jedoch auch für weitere Funktionen wie die Zwei-Faktor-Authentifizierung (2FA) genutzt werden. (varchar)
- **Name**: Der reale Name des Benutzers. (varchar)


## Logbook

Das "Logbook" (Fahrtenbuch) ist eine Sammlung aller aufgezeichneten Fahrten (Trips) und dient als Übersicht über die Nutzung der Fahrzeuge innerhalb eines Teams oder durch einen einzelnen Benutzer.

- **ID**: Eindeutige Identifikation für das Fahrtenbuch.
- **Team_ID**: Referenz auf das Team, zu dem das Fahrtenbuch gehört.
- **Fahrer_ID**: Alle Fahrer, deren Fahrten im Fahrtenbuch aufgeführt sind.
- **Period**: Der Zeitraum, den das Fahrtenbuch abdeckt (z. B. Monat, Quartal, Jahr).
- **Kilometer_Total**: Die Gesamtkilometer aller Fahrten innerhalb des Fahrtenbuchs.
- **Vehicle_Using**: Eine Statistik, die zeigt, wie oft und wie lange jedes Fahrzeug genutzt wurde.


## Vehicle

Ein Vehicle (Fahrzeug) ist ein Objekt, das von einem oder mehreren Teams genutzt werden kann.

- **ID**: Eindeutige Identifikation für jedes Fahrzeug.
- **License_Plate**: Das amtliche Kennzeichen des Fahrzeugs.
- **Brand**: Die Marke des Fahrzeugs.
- **Model**: Das Modell des Fahrzeugs (z.B Marke: Volkswagen; Modell: Golf)
- **Colour**: Die Farbe des Fahrzeugs.
- **Odometer**: Der aktuelle Kilometerstand des Fahrzeugs.
- **Type**: Art des Fahrzeugs (z. B. PKW, LKW, Motorrad).
- **Construction_Year**: Das Baujahr des Fahrzeugs.
- **Current_Location**: Der letzte bekannte Standort des Fahrzeugs (optional).


## Trip

Ein Trip repräsentiert eine einzelne Fahrt im Fahrtenbuch.

- **ID**: Eindeutige Identifikation für jeden Trip.
- **Date**: Datum der Abfahrt.
- **Time_Departure**: Abfahrtszeit aus Sicht des Fahrers.
- **Time_Arrival**: Ankunftszeit aus Sicht des Fahrers.
- **Odometer_Start**: Kilometerstand zu Beginn der Fahrt.
- **Odometer_End**: Kilometerstand am Ende der Fahrt.
- **Driver_ID**: Identifikation des Nutzers, der die Fahrt durchgeführt hat.
- **Vehicle_ID**: Identifikation des Fahrzeugs, das für die Fahrt genutzt wurde.
- **Purpose_Of_Drive**: Kurze Beschreibung des Zwecks der Fahrt.
- **Type_Of:Drive**: Angabe, ob die Fahrt privat oder geschäftlich ist.
- **Status**: Status des Trips, welcher folgende Werte annehmen kann:
    - **Active**: Die Fahrt ist aktuell im Gange.
    - **Finished**: Die Fahrt wurde abgeschlossen.
    - **Completed**: Alle Felder des Trips wurden ausgefüllt.
    - **Unkown**: Es konnte keine Verbindung zum Client hergestellt werden.


## Primär- und Fremdschlüssel:

    User (PK: ID)
    Logbook (PK: ID, FK: Team_ID, Fahrer_ID)
    Vehicle (PK: ID)
    Trip (PK: ID, FK: Fahrer_ID, Fahrzeug_ID)
    Team (PK: ID, FK: Besitzer_ID)



## Beziehungen:

    User kann in Teams Mitglied sein. Dies ist eine n Beziehung, da ein User in mehreren Teams sein kann und ein Team mehrere User haben kann.
    Ein User ist Driver für Trips, eine 1 Beziehung (ein User kann mehrere Trips fahren).
    Vehicle wird von Teams verwendet. Dies ist eine 1 Beziehung (ein Vehicle gehört zu einem Team, aber ein Team kann mehrere Vehicle haben).
    Logbook bezieht sich auf ein Team und listet alle Trips dieses Teams, was eine 1 Beziehung ist (ein Logbook gehört zu einem Team, aber ein Team kann mehrere Logbooks haben).
    Trips verknüpft User (Driver) und Vehicles durch Trips. Jeder Trip hat genau einen User als Driver und ein Driver, was eine 1 Beziehung ist.



