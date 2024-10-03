# Vorwort

Um bei der Umsetzung von Triptrack möglichst reibungsfrei zu arbeiten, wurden die eingesetzten Technologien und Konzepte sorgfältig durchdacht. Dabei lag der Fokus  auf folgenden Aspekten:

1. **Skalierbarkeit**: Die verwendeten Technologien müssen in der Lage sein, bei steigender Nutzerzahl und Datenmenge zu skalieren.
    
2. **Performance**: Eine schnelle und effiziente Verarbeitung von Anfragen, um die Benutzererfahrung flüssig zu gestalten.
    
3. **Sicherheit**: Schutz von Nutzerdaten und sicheren Zugriff auf die API durch Authentifizierung und Autorisierung.
    
4. **Wartbarkeit**: Der Code und die Architektur sollen klar strukturiert sein, um zukünftige Wartungen und Erweiterungen zu erleichtern.
    
5. **Modularität**: Die Anwendung sollte in logische, wiederverwendbare Module unterteilt sein, um Flexibilität und Anpassbarkeit zu ermöglichen.
    
6. **Zukunftssicherheit**: Einsatz moderner, bewährter Technologien, die auch in den kommenden Jahren unterstützt werden.
    
7. **Echtzeitfähigkeit**: Einsatz von Technologien wie Server-Sent Events (SSE) für Echtzeit-Updates ohne hohe Serverlast.

Dieses Dokument konzentriert sich hauptsächlich auf die technische Umsetzung des Backends, also auf den Service, der die Daten für den Client bereitstellt.



# Folgende Themen werden in diesem Dokument behandelt:

 [[#1. Konzept der Client Server Kommunikation]]

Dieser Abschnitt erläutert die Architektur der Kommunikation zwischen Client und Server, beschreibt die verwendeten Protokolle und stellt sicher, dass eine zuverlässige, effiziente und sichere Datenübertragung ermöglicht wird.

[[#2 Auswahl des Backend Frameworks]]

Hier wird das für das Backend gewählte Framework vorgestellt. Es werden die Entscheidungskriterien sowie die Vorteile dieses Frameworks erläutert.

[[#3 Sicherheitskonzept]]

Dieser Teil widmet sich den Maßnahmen zur Absicherung des Backends, insbesondere der Implementierung von Authentifizierungs- und Autorisierungsmechanismen.


[[#4 Code Konventionen]]

Hier werden die festgelegten Code-Richtlinien beschrieben, um die Lesbarkeit und Wartbarkeit des Codes zu gewährleisten. Dazu zählen Namenskonventionen, Strukturierung des Codes sowie Best Practices für sauberen und effizienten Code.


[[#5. Klassendiagramm]]

Dieser Abschnitt enthält eine visuelle Darstellung der zentralen Backend-Komponenten und ihrer Beziehungen zueinander, um die Architektur und Logik der Implementierung zu verdeutlichen.


# 1. Konzept der Client Server Kommunikation

Die Client-Server-Kommunikation bildet das Herzstück unserer  Webanwendung. In diesem Kapitel wird das Kommunikationsmodell beschrieben, das sicherstellt, dass der Client effizient und zuverlässig mit dem Backend kommunizieren kann. Ziel ist es, eine klare Trennung zwischen der Frontend- und Backend-Logik zu ermöglichen, während gleichzeitig die Daten konsistent und sicher übermittelt werden.

Für die Kommunikation zwischen Client und Server wird das HTTP-Protokoll verwendet, welches über eine REST(Representational State Transfer)-API realisiert wird. Die wichtigsten Anfragen wie **GET**, **POST**, **PUT**, und **DELETE** ermöglichen dem Client, Daten vom Server abzurufen, zu aktualisieren oder zu löschen. Darüber hinaus wird durch den Einsatz von **Server-Sent Events (SSE)** eine Möglichkeit geschaffen, dem Client in Echtzeit Daten zu senden, ohne dass dieser kontinuierlich Anfragen stellen muss.

Im weiteren Verlauf dieses Kapitels wird detailliert beschrieben, wie die verschiedenen Arten von Anfragen verarbeitet werden, welche Technologien dabei eingesetzt werden und welche Mechanismen zur Optimierung der Performance und Sicherheit angewendet werden.

In Triptrack arbeiten zwei Hauptprinzipien für die Kommunikation zwischen Client und Server zusammen:

1. **REST API**
2. **Server-Sent Events (SSE)**

Diese beiden Ansätze sorgen dafür, dass Daten zuverlässig ausgetauscht und Echtzeit-Updates effizient übermittelt werden.

#### REST API:
Die **REST API** ist die zentrale Schnittstelle, über die der Client mit dem Server kommuniziert. Sie erlaubt es, über gängige HTTP-Methoden (wie **GET**, **POST**, **PUT** und **DELETE**) Daten abzufragen, zu aktualisieren oder zu speichern. Zum Beispiel kann der Client den Kilometerstand eines Fahrzeugs über eine **POST**-Anfrage an den Server senden oder Informationen wie den Fahrzeugstatus über eine **GET** -Anfrage abrufen.

Die REST API sorgt für eine klare Trennung zwischen den Aufgaben des Clients und des Servers. Der Client stellt Anfragen und der Server bearbeitet sie, liefert die notwendigen Daten und führt Updates durch. Diese Struktur ist einfach, flexibel und Skalierbar, was bedeutet, dass sie gut mit wachsendem Datenvolumen und neuen Funktionen umgehen kann. Mit der Verwendung von Access Tokens wird auch die Nutzerverwaltung vereinfacht 

#### Server-Sent Events (SSE):
Zusätzlich zur REST API nutzen wir **Server-Sent Events (SSE)**, um eine Echtzeit-Kommunikation vom Server zum Client zu ermöglichen. Während die REST API für gezielte Anfragen zuständig ist, sorgt SSE dafür, dass der Client automatisch informiert wird, sobald sich Daten auf dem Server ändern. Dies ist besonders praktisch, um etwa den Status eines Fahrzeugs in Echtzeit auf mehreren Geräten synchron anzuzeigen.

SSE baut eine dauerhafte Verbindung zum Server auf, sodass der Client kontinuierlich Updates erhält, ohne immer wieder neue Anfragen stellen zu müssen. Das reduziert die Last auf dem Server und verbessert die Aktualität für den Benutzer. Außerdem wird die Entwicklung des Clients vereinfacht da der sich nicht um die Besorgung der Aktuellen Daten kümmern muss. 

Ein konkretes Beispiel wäre: Sobald ein Fahrzeug den Betrieb aufnimmt oder beendet, erhält der Client in Echtzeit eine Benachrichtigung und zeigt die neuen Informationen sofort an.

Im Kapitel Sicherheitskonzept werden SSEs auch dafür verwendet um den Accestoken zu beantragen 

### Was passiert, wenn der Client während der Fahrt die Verbindung verliert?

Es kann vorkommen, dass der Client während der Fahrt die Verbindung zum Server verliert, zum Beispiel durch schlechtes Netz in Tunneln oder ländlichen Gegenden. Triptrack ist jedoch so entwickelt, dass es auch ohne ständige Verbindung zuverlässig funktioniert. Falls die Verbindung unterbrochen wird, speichert der Client die Daten lokal und sendet sie, sobald die Verbindung wiederhergestellt ist. So bleibt der Kilometerstand oder die Fahrtenhistorie stets auf dem neuesten Stand.

Ein weiteres Plus ist, dass SSE sich automatisch wieder verbindet, sobald die Verbindung wieder verfügbar ist. Sollte es also zu einer Unterbrechung kommen, ist der Client schnell wieder auf dem neuesten Stand, ohne dass der Benutzer eingreifen muss. Sollte dennoch einmal eine Fahrt nicht aufgezeichnet werden, besteht die Möglichkeit, diese manuell nachzutragen.

### Login und Authentifizierung über REST und SSE

Die Authentifizierung in Triptrack erfolgt über die REST API, während SSE die Echtzeit-Updates übernimmt. So bleiben die Prozesse klar und getrennt.

1. **Login über REST:**
   - Der Benutzer gibt seine Anmeldedaten (Benutzername und Passwort) ein und sendet sie über eine **POST**-Anfrage an die API.
   - Der Server überprüft die Daten und stellt, falls diese korrekt sind, einen **Token** (meist ein JSON Web Token, JWT) aus.
   - Dieser Token wird im Client gespeichert und bei jeder weiteren Anfrage in den **Authorization**-Header eingefügt, um sicherzustellen, dass nur autorisierte Nutzer Zugriff auf geschützte Daten haben.

2. **Echtzeit-Updates über SSE:**
   - Nach erfolgreichem Login baut der Client eine **SSE-Verbindung** zum Server auf, um Echtzeit-Updates zu erhalten.
   - Der Token wird auch hier genutzt, um sicherzustellen, dass nur autorisierte Nutzer die Echtzeit-Daten empfangen.
   - Der Server kann dann fortlaufend Statusänderungen und Updates in Echtzeit senden, solange die Verbindung aktiv ist.
   - Außerdem wird kurz vor dem auslaufen des Access Tokens über SSE der Client beauftragt sich einen neuen Token vom Server zu holen sollte der Client dieser Aufforderung nicht nachgehen wird er beim auslaufen des Tokens abgemeldet.

Diese Kombination aus REST für die Authentifizierung und SSE für Echtzeit-Updates sorgt dafür, dass der Benutzer nicht nur sicher eingeloggt ist, sondern auch ohne Verzögerung über alle wichtigen Änderungen informiert wird.

### Zusammenfassung:
Durch die Kombination von **REST API** und **SSE** funktioniert Triptrack zuverlässig und effizient. REST ermöglicht den sicheren Austausch von Daten, während SSE für Echtzeit-Updates sorgt, ohne den Server zu überlasten. Auch bei Verbindungsabbrüchen bleibt die App stabil, indem sie Daten lokal speichert und nach einer Wiederverbindung synchronisiert. Diese Architektur stellt sicher, dass der Benutzer eine reibungslose und verlässliche Erfahrung macht, selbst unter schwierigen Bedingungen.


![[Trip Track Kommunikation.svg]]


# 2 Auswahl des Backend Frameworks

Die Wahl des richtigen Backend-Frameworks ist eine zentrale Entscheidung für den Erfolg und die Effizienz eines Projekts wie Triptrack. Dabei wurden verschiedene Kriterien berücksichtigt, um sicherzustellen, dass das Framework sowohl die technischen Anforderungen erfüllt als auch eine langfristige Wartbarkeit und Erweiterbarkeit ermöglicht.

Besonders wichtig waren dabei Aspekte wie **Performance**, **Sicherheit**, **Skalierbarkeit** und **Entwicklerfreundlichkeit**. Nach sorgfältiger Analyse und Abwägung verschiedener Optionen fiel die Entscheidung auf **ASP.NET Core**, ein modernes, leistungsfähiges und plattformunabhängiges Framework, das ideal zu den Anforderungen von Triptrack passt.

Im Folgenden werden die Schlüsselkriterien erläutert, die zur Auswahl von ASP.NET Core geführt haben, und warum es die beste Wahl für dieses Projekt darstellt.

- **Performance**:
    
    - **ASP.NET Core**: Bekannt für seine hohe Geschwindigkeit und Effizienz bei der Verarbeitung von Anfragen, insbesondere durch die Verwendung von Kestrel, einem leistungsstarken Webserver.
    - **Vergleich**: Im Vergleich zu Frameworks wie **Node.js** oder **Django** zeigt ASP.NET Core oft bessere Leistung bei gleichzeitigen Anfragen, insbesondere in Enterprise-Anwendungen.
    - **Quelle**: https://github.com/AleksandarMitrevski/backend-perf-comp

- **Plattformunabhängigkeit:

	- **ASP.NET Core**: Entwickelt, um plattformunabhängig zu sein und auf Windows, Linux und macOS zu laufen, was es ideal für unsere Umgebung mit Linux-Servern macht und für testung da das Entwickler team auf unterschiedlichen Plattformen Arbeitet .
	

- **Sicherheit**:

	- **ASP.NET Core**: Bietet integrierte Sicherheitsfunktionen wie Authentifizierung, Autorisierung und Schutz vor häufigen Angriffen. Die Verwendung von Identity und JWT-Token macht die Sicherheitsimplementierung robust.
	- **Vergleich**: Während andere Frameworks wie **Laravel** oder **Spring Security** ebenfalls gute Sicherheitsfunktionen bieten, ist ASP.NET Core für die einfache Implementierung von Sicherheitsstandards bekannt.
	- **Quelle**: https://learn.microsoft.com/de-de/troubleshoot/developer/webapps/aspnet/development/security-overview
	
- **Wartbarkeit und Erweiterbarkeit**:

	- **ASP.NET Core**: Der modulare Aufbau ermöglicht eine einfache Wartung und Erweiterung der Anwendung. Das Verwenden von Middleware und Abhängigkeitseinfügungen verbessert die Modularität.
	- **Vergleich**: Während Frameworks wie **Angular** oder **Vue.js** auch Modularität bieten, ist die Wartbarkeit in Backend-Frameworks wie ASP.NET Core oft einfacher aufgrund der klaren Struktur.

- **Community und Support**:
    
    - **ASP.NET Core**: Verfügt über eine große und aktive Community sowie umfangreiche Dokumentation, Tutorials und Support-Ressourcen.
    - **Vergleich**: Auch andere Frameworks wie **Django** oder **Ruby on Rails** haben starke Communities, jedoch bietet ASP.NET Core durch die Unterstützung von Microsoft ein zusätzliches Maß an Professionalität und Stabilität.

- **Entwicklerfreundlichkeit**:
    
    - **ASP.NET Core**: Die Verwendung von C# ermöglicht es uns, unser bestehendes Wissen zu nutzen, was die Entwicklung beschleunigt. Das Framework unterstützt eine klare Struktur und gibt Entwicklern viele nützliche Werkzeuge an die Hand.
    - **Vergleich**: Während JavaScript-Frameworks wie **Node.js** in ihrer Syntax einfacher sein können, bringt C# durch seine starke Typisierung und umfassenden IDE-Features in Visual Studio oder Visual Studio Code eine hohe Entwicklerfreundlichkeit.
      
- **Dokumentation und Swagger**:
    
    - **ASP.NET Core**: Die eingebaute Unterstützung für **Swagger** erleichtert die Dokumentation und das Testen der API. Swagger generiert automatisch eine benutzerfreundliche API-Dokumentation, die Entwicklern und Nutzern hilft, die Funktionen der API besser zu verstehen.

### Fazit

Die Entscheidung für **ASP.NET Core** basiert auf einer sorgfältigen Abwägung dieser Schlüsselkriterien, die es zu einer optimalen Wahl für Triptrack machen. Die Kombination aus Performance, Sicherheit, plattformunabhängiger Nutzung und der Vertrautheit mit der Programmiersprache C# schafft eine solide Grundlage für die Entwicklung einer modernen, leistungsfähigen und wartbaren Backend-Lösung.

# 3 Sicherheitskonzept 

Ein effektives Sicherheitskonzept ist entscheidend, um die Integrität, Vertraulichkeit und Verfügbarkeit der Daten in der Anwendung Triptrack zu gewährleisten. Da die Anwendung sensible Informationen, wie Fahrtenprotokolle und Benutzerdaten, verarbeitet, haben wir einen mehrschichtigen Ansatz zur Sicherung des Systems entwickelt.

In diesem Abschnitt werden die grundlegenden Sicherheitsstrategien und -maßnahmen erläutert, die implementiert wurden, um potenzielle Bedrohungen zu minimieren und die Anwendung vor unbefugtem Zugriff zu schützen. Dazu gehören unter anderem:

- **Authentifizierung und Autorisierung**: Die Implementierung robuster Authentifizierungs- und Autorisierungsmechanismen ist von zentraler Bedeutung. Wir verwenden **JSON Web Tokens (JWT)** für die Authentifizierung, um sicherzustellen, dass nur berechtigte Benutzer auf bestimmte Ressourcen zugreifen können. Diese Tokens werden nach erfolgreichem Login generiert und müssen bei jeder Anfrage im Header der API übermittelt werden. Um die Benutzererfahrung zu verbessern, implementieren wir auch einen **Token-Refresh-Mechanismus**. Dieser ermöglicht es Benutzern, ihre Sitzung aufrechtzuerhalten, ohne sich wiederholt anmelden zu müssen. Tokens haben eine begrenzte Lebensdauer; durch den Refresh-Token kann ein neues Zugriffstoken angefordert werden, solange der Benutzer authentifiziert bleibt. Dies reduziert die Notwendigkeit, die Anmeldedaten häufig einzugeben und erhöht gleichzeitig die Sicherheit. Hierbei wird die Aufforderung zum neubeantragen des Tokens über SSE vermittelt. 

- **Schutz vor häufigen Angriffen**: Um die Anwendung gegen gängige Angriffe abzusichern, implementieren wir Maßnahmen wie:
  - **Cross-Site Request Forgery (CSRF)**: Wir verwenden Anti-CSRF-Tokens, um sicherzustellen, dass alle Anfragen von autorisierten Quellen stammen. Diese Tokens werden zusammen mit Formularen oder API-Anfragen gesendet und vom Server validiert.
  - **SQL-Injection**: Um SQL-Injection-Angriffe zu verhindern, verwenden wir **parameterisierte Abfragen** und ORM-Frameworks (Object-Relational Mapping). Parameterisierte Abfragen stellen sicher, dass Benutzereingaben niemals direkt in SQL-Abfragen eingebettet werden. Dadurch wird die Möglichkeit, schädlichen SQL-Code auszuführen, stark eingeschränkt. Darüber hinaus validieren wir alle Benutzereingaben gründlich und beschränken die Art der Daten, die in unsere Datenbank eingegeben werden dürfen.

- **Sichere API-Entwicklung**:
  
  - **Input Validation**: Alle Eingaben werden validiert, um sicherzustellen, dass sie dem erwarteten Format entsprechen und keine schädlichen Inhalte enthalten. Dies hilft, verschiedene Arten von Angriffen, einschließlich SQL-Injection und XSS, zu verhindern.
  - **Logging und Monitoring**: Wir implementieren umfassende Logging- und Monitoring-Mechanismen, um ungewöhnliche Aktivitäten und potenzielle Sicherheitsvorfälle frühzeitig zu erkennen. Alle Zugriffsversuche und API-Anfragen werden protokolliert, um im Falle eines Vorfalls eine detaillierte Analyse zu ermöglichen. Die Überwachung in Echtzeit ermöglicht es uns, verdächtige Aktivitäten sofort zu identifizieren und darauf zu reagieren.

### Fazit

Durch die Implementierung dieser Maßnahmen schaffen wir eine robuste Sicherheitsarchitektur für Triptrack. Die Kombination aus starker Authentifizierung, Schutz vor häufigen Angriffen und sicherer API-Entwicklung gewährleistet, dass die Daten der Benutzer geschützt sind und die Anwendung gegen verschiedene Bedrohungen gewappnet ist. In einer zunehmend digitalisierten Welt ist Sicherheit kein einmaliges Thema, sondern ein fortlaufender Prozess, den wir kontinuierlich überwachen und anpassen werden, um den neuesten Bedrohungen und Herausforderungen zu begegnen.

# 4 Code Konventionen 

Hier ist eine erweiterte Version des Kapitels über Codekonventionen, die spezifische Richtlinien und Beispiele einbezieht:

---

Ein einheitlicher und klar strukturierter Code ist entscheidend für die Wartbarkeit und Verständlichkeit einer Anwendung. Im Kapitel über Codekonventionen werden die Richtlinien und Standards vorgestellt, die im Projekt Triptrack beachtet werden, um eine konsistente und qualitativ hochwertige Codebasis zu gewährleisten.

Die Einhaltung von Codekonventionen erleichtert nicht nur die Zusammenarbeit im Team, sondern sorgt auch dafür, dass der Code für neue Entwickler schnell verständlich ist. Durch klare Namensgebungen, konsistente Formatierungen und die Anwendung bewährter Praktiken in der Programmierung minimieren wir Fehlerquellen und erhöhen die Effizienz bei der Entwicklung und Wartung des Codes.

In diesem Abschnitt werden die wichtigsten Aspekte unserer Codekonventionen behandelt:

#### 1. Namensgebung

Die Namensgebung ist ein grundlegender Aspekt der Lesbarkeit und Verständlichkeit des Codes. Wir folgen den folgenden Richtlinien:

- **Variablen und Funktionen**: Verwende aussagekräftige und beschreibende Namen, die den Zweck der Variablen oder Funktionen klar machen. Zum Beispiel: `calculateTotalDistance()` anstelle von `calcDist()`.
- **Klassen**: Verwende PascalCase für Klassennamen. Zum Beispiel: `VehicleTracker`.
- **Konstanten**: Konstanten sollten in Großbuchstaben mit Unterstrichen geschrieben werden, um ihre Unveränderlichkeit zu kennzeichnen. Zum Beispiel: `MAX_SPEED`.

#### 2. Formatierung

Eine konsistente Formatierung des Codes verbessert die Lesbarkeit. Folgende Formatierungsrichtlinien gelten:

- **Zeilenlänge**: Halte die Zeilenlänge auf maximal 80 Zeichen. Längere Zeilen sollten sinnvoll umgebrochen werden.
- **Leerzeilen**: Verwende Leerzeilen, um logische Abschnitte im Code zu trennen. Beispielsweise sollten zwischen Methoden Leerzeilen eingefügt werden.

#### 3. Dokumentation

Dokumentation ist entscheidend für die Wartbarkeit des Codes. Unsere Empfehlungen sind:

- **Kommentare**: Verwende Kommentare, um den Zweck und die Funktionsweise von komplexen Codeabschnitten zu erläutern. Achte darauf, dass die Kommentare aktuell sind und den Code nicht unnötig überladen.
- **Docstrings**: Verwende Docstrings für Klassen und Funktionen, um deren Funktionalität zu beschreiben. Zum Beispiel:

  ```csharp
  /// <summary>
  /// Berechnet die Gesamtstrecke für eine Liste von Fahrten.
  /// </summary>
  /// <param name="trips">Eine Liste von Fahrten.</param>
  /// <returns>Die Gesamtstrecke.</returns>
  public double CalculateTotalDistance(List<Trip> trips) {
      // Logik zur Berechnung der Strecke
  }
  ```

#### 4. Fehlerbehandlung

Eine effektive Fehlerbehandlung ist entscheidend für die Stabilität der Anwendung. Wir folgen diesen Richtlinien:

- **Ausnahmebehandlung**: Verwende `try-catch`-Blöcke, um Ausnahmen zu behandeln und spezifische Fehlermeldungen bereitzustellen. Stelle sicher, dass kritische Fehler protokolliert werden.
- **Eingabeverifizierung**: Überprüfe alle Benutzereingaben gründlich, um sicherzustellen, dass sie den erwarteten Kriterien entsprechen. Dies reduziert das Risiko von unerwartetem Verhalten.

#### 5. Tests

Tests sind ein wesentlicher Bestandteil der Softwareentwicklung. Wir legen Wert auf:

- **Unit-Tests**: Schreibe Unit-Tests für alle Funktionen und Methoden, um sicherzustellen, dass sie wie erwartet funktionieren. Verwende Frameworks wie xUnit oder NUnit für die Durchführung von Tests.
- **Integrationstests**: Implementiere Integrationstests, um die Interaktion zwischen verschiedenen Komponenten der Anwendung zu überprüfen.
- **Automatisierung**: Setze Testautomatisierung ein, um die Effizienz der Testdurchführung zu steigern und sicherzustellen, dass alle Tests regelmäßig ausgeführt werden.


### Fazit

Durch die Berücksichtigung dieser Codekonventionen schaffen wir eine solide Basis, auf der das Projekt aufbauen kann, und fördern gleichzeitig ein positives Arbeitsumfeld für alle Beteiligten. Die Einhaltung dieser Richtlinien trägt dazu bei, die Wartbarkeit und Lesbarkeit des Codes zu verbessern und stellt sicher, dass die Entwickler effizient zusammenarbeiten können.

# 5 Klassendiagramm

![[Main.svg]]
