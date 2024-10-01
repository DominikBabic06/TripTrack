Zur Kommunikation zwischen Client und Server kommen zwei Paradigmen zum Einsatz:

1. **REST API**
2. **Server-Sent Events (SSE)**

### REST API:

Die REST API ermöglicht einen strukturierten und effizienten Zugriff auf die Daten des Servers und der Datenbank. Sie dient in erster Linie dazu, Daten abzurufen, zu speichern oder zu aktualisieren. Beispielsweise kann der Kilometerstand des Fahrzeugs einfach auf den Hauptserver geladen werden. Dabei nutzt der Client HTTP-Anfragen wie GET und POST, um die gewünschten Daten vom Server zu empfangen oder neue Informationen hinzuzufügen.

Durch den Einsatz der REST API ist eine klare Trennung der einzelnen Aufgaben gewährleistet: Der Client fragt spezifische Daten ab, während der Server diese Anfragen bearbeitet und die entsprechenden Antworten liefert. Dies gewährleistet eine saubere und skalierbare Datenstruktur.

### Server-Sent Events (SSE):

Zusätzlich zur REST API wird SSE eingesetzt, um eine kontinuierliche, unidirektionale Kommunikation vom Server zum Client zu ermöglichen. Server-Sent Events sorgen dafür, dass der Client automatisch benachrichtigt wird, wenn sich bestimmte Daten auf dem Server ändern, ohne dass er ständig neue Anfragen senden muss. Dies ist besonders nützlich, um den Status des Fahrzeugs in Echtzeit zu überwachen und sicherzustellen, dass alle relevanten Informationen, wie welche fahzeuge grade im Betrieb sind, auf allen verbundenen Geräten synchron zu bereitben.

SSE stellt eine permanente Verbindung her, über die der Server sofortige Updates senden kann, sobald sich Daten ändern, ohne dass der Client aktiv nachfragen muss. So wird die Benutzererfahrung dynamischer und der Aufwand für den Datentransfer reduziert.

SSE ist also hauptsächlich dafür verantwortlich Daten auf allen Geräten synchron zu halten. 


### **Was Passiert wenn ein Client während einer fahrt die verbindung verliert?**

Es ist zunächst wichtig zu betonen, dass für den Betrieb des Programms keine konstante Verbindung zum Server erforderlich ist. Beim Autofahren können Faktoren wie Tunnel, schlechtes Signal oder widrige Witterungsverhältnisse den Empfang stark beeinträchtigen. Unser Programm ist jedoch nicht für die Überwachung von Firmenfahrzeugen gedacht, sondern soll lediglich das Führen eines Fahrtenprotokolls erleichtern.

Das bedeutet, es ist zwar vorteilhaft, wenn der aktuelle Kilometerstand immer auf dem Server abrufbar ist, aber es stellt kein Problem dar, falls Clients während der Fahrt die Verbindung verlieren und erst am Ende der Fahrt wiederherstellen. In einem solchen Fall können sie die Daten lokal speichern und sie übermitteln, sobald die Verbindung zum Hauptserver wieder besteht.

Sollte es zu einem schwerwiegenden Fehler kommen und eine Fahrt nicht aufgezeichnet werden, besteht natürlich die Möglichkeit, Fahrten manuell nachzutragen. Server-Sent Events (SSE) bieten hier zusätzlich den Vorteil, dass sie eine automatische Wiederverbindung ermöglichen, was die Zuverlässigkeit weiter verbessert. 

# Was für stadien der Trips gibt es

Aufgrund von verschieden faktoren 

# Wie funktioniert der Login über Rest und SSE

Ein Login über REST und SSE funktioniert so, dass REST für die Authentifizierung und Autorisierung zuständig ist, während SSE für das Empfangen von Echtzeit-Updates genutzt wird, sobald der Benutzer eingeloggt ist. 

1. **Login mit REST:**
   - **Anfrage an den Server:** Der Benutzer sendet seine Anmeldeinformationen (z.B. Benutzername und Passwort) über eine REST-API-Anfrage (z.B. ein `POST`-Request an `/login`).
   - **Verifizierung der Daten:** Der Server prüft die Anmeldeinformationen, und wenn sie korrekt sind, erstellt er einen Token (z.B. einen JWT, JSON Web Token).
   - **Antwort vom Server:** Der Token wird in der Antwort an den Client zurückgeschickt. Der Client speichert diesen Token in einem sicheren Ort, wie z.B. im LocalStorage oder einem Cookie.
   - **Sicherheit:** Bei zukünftigen Anfragen sendet der Client diesen Token in den HTTP-Headern (z.B. im `Authorization`-Header), um zu beweisen, dass er authentifiziert ist.

2. **Echtzeit-Updates mit SSE:**
   - **SSE-Verbindung aufbauen:** Nach einem erfolgreichen Login kann der Client eine SSE-Verbindung zum Server aufbauen (z.B. ein `GET`-Request an `/events`), um Echtzeit-Updates zu erhalten.
   - **Authentifizierung für SSE:** Der Token, der im Login-Prozess empfangen wurde, wird in den Header der SSE-Anfrage aufgenommen, damit der Server die Berechtigung des Clients überprüfen kann.
   - **Server sendet Updates:** Der Server kann nun regelmäßig oder bei bestimmten Ereignissen Updates an den Client senden, solange die SSE-Verbindung aktiv ist.



Mit dieser Methode kombinierst du REST für die Authentifizierung und SSE für Echtzeit-Updates, wobei beide Kommunikationskanäle getrennt und spezifisch für ihre Aufgabe sind.








