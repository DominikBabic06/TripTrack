# Vorwort

Dieses Dokument dient der Vereinfachung der Planung von Triptrack, indem die benötigten Objekte und deren Eigenschaften beschrieben werden.

## Benutzer

- **ID**: Eindeutige Identifikation, die jeden Nutzer eindeutig identifiziert.
- **Benutzername (USERNAME)**: Eindeutiger Name des Nutzers, bestehend aus 4 bis 30 Zeichen. Erlaubte Zeichen sind A-Z, a-z, 0-9, ß, ö, ä, ü und das Sonderzeichen "-".
- **E-Mail (EMAIL)**: Derzeit wird die E-Mail nur für Login-Zwecke verwendet. Zukünftig könnte sie jedoch auch für weitere Funktionen wie die Zwei-Faktor-Authentifizierung (2FA) genutzt werden.
- **Name**: Der reale Name des Benutzers 

## Fahrtenbuch

Das Fahrtenbuch ist eine Sammlung aller aufgezeichneten Fahrten (Trips) und dient als Übersicht über die Nutzung der Fahrzeuge innerhalb eines Teams oder durch einen einzelnen Benutzer. Trips werden aber dem Team zugewiesen das Fahrtenbuch wird erst bei abrufung erstellt. 

- **ID**: Eindeutige Identifikation für das Fahrtenbuch.
- **Team**: Referenz auf das Team, zu dem das Fahrtenbuch gehört.
- **Fahrer**: Alle Fahrer, deren Fahrten im Fahrtenbuch aufgeführt sind.
- **Zeitraum**: Der Zeitraum, den das Fahrtenbuch abdeckt (z. B. Monat, Quartal, Jahr).
- **Trips**: Eine Liste aller Fahrten, die im angegebenen Zeitraum aufgezeichnet wurden.
- **Kilometer Gesamt**: Die Gesamtkilometer aller Fahrten innerhalb des Fahrtenbuchs.
- **Fahrzeug-Nutzung**: Eine Statistik, die zeigt, wie oft und wie lange jedes Fahrzeug genutzt wurde.
- **Export-Funktion**: Möglichkeit, das Fahrtenbuch als PDF oder Excel-Datei zu exportieren.

## Fahrzeug

Ein Fahrzeug ist ein Objekt, das von einem oder mehreren Teams genutzt werden kann.

- **ID**: Eindeutige Identifikation für jedes Fahrzeug.
- **Kennzeichen**: Das amtliche Kennzeichen des Fahrzeugs.
- **Marke**: Die Marke des Fahrzeugs.
- **Modell**: Das Modell des Fahrzeugs (z.B Marke: Volkswagen; Modell: Golf)
- **Farbe**: Die Farbe des Fahrzeugs.
- **Kilometerstand**: Der aktuelle Kilometerstand des Fahrzeugs.
- **Baujahr**: Das Baujahr des Fahrzeugs.
- **Aktueller Standort**: Der letzte bekannte Standort des Fahrzeugs (optional). -- theoretisch in zukunft

## Trip

Ein Trip repräsentiert eine einzelne Fahrt im Fahrtenbuch.

- **ID**: Eindeutige Identifikation für jeden Trip.
- **Datum**: Datum der Abfahrt.
- **Uhrzeit Abfahrt**: Abfahrtszeit aus Sicht des Fahrers.
- **Uhrzeit Ankunft**: Ankunftszeit aus Sicht des Fahrers.
- **Kilometerstand Anfang**: Kilometerstand zu Beginn der Fahrt.
- **Kilometerstand Ende**: Kilometerstand am Ende der Fahrt.
- **Fahrer**: Identifikation des Nutzers, der die Fahrt durchgeführt hat.
- **Fahrzeug**: Identifikation des Fahrzeugs, das für die Fahrt genutzt wurde.
- **Zweck der Fahrt**: Kurze Beschreibung des Zwecks der Fahrt.
- **Art der Fahrt**: Angabe, ob die Fahrt privat oder geschäftlich ist.
- **Status**: Status des Trips, welcher folgende Werte annehmen kann:
    - **Aktiv**: Die Fahrt ist aktuell im Gange.
    - **Beendet**: Die Fahrt wurde abgeschlossen.
    - **Abgeschlossen**: Alle Felder des Trips wurden ausgefüllt.
    - **Unbekannt**: Es konnte keine Verbindung zum Client hergestellt werden.
  
-**Team**: Identifikation des Teams welchem der Trip zugewiesen wird.


Hinweis: Alle Felder eines Trips können nach Abschluss der Fahrt sowohl vom Fahrer als auch vom Teamleiter bearbeitet werden, mit Ausnahme des Statusfeldes.

## Team

Ein Team ist eine Gruppe von Personen, die sich Fahrzeuge teilen. Es kann beispielsweise eine Firma oder ein Haushalt sein. Ein Fahrzeug ist an ein Team gebunden und nicht an einen einzelnen Nutzer. Fahrzeuge können gleichzeitig in mehreren Teams sein.

- **Besitzer**: Identifikation des Nutzers, der das Team erstellt hat.
- **Fahrzeuge**: Eine Liste von Fahrzeugen, die zum Team gehören.
- **Mitglieder**: Eine Liste von Nutzern, die berechtigt sind, die Fahrzeuge des Teams zu nutzen.
- **Trips**: Alle Fahrten, die mit den Fahrzeugen des Teams unternommen wurden.


