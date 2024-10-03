### Untersuchung zur Datenauslesung aus Fahrzeugen für die Implementierung von Triptracker

#### 1. Einleitung
Um die Handhabung von Triptracker effizienter zu gestalten, wird nach geeigneten Methoden zur Datenerfassung aus Fahrzeugen gesucht. Diese Analyse soll verschiedene Möglichkeiten aufzeigen, um Fahrzeugdaten für die App zu nutzen, mit dem Ziel, sowohl die Benutzererfahrung als auch die Leistungsfähigkeit der Anwendung zu verbessern. Die Wahl der optimalen Methode ist entscheidend, um den Nutzern präzise und nützliche Informationen bereitzustellen.

#### 2. Optionen zur Datenauslesung

##### 2.1. OBD-II (On-Board Diagnostics)
- **Beschreibung:** OBD-II ist ein standardisiertes System, das seit 1996 in den meisten Fahrzeugen verfügbar ist. Es ermöglicht das Auslesen von Fehlercodes sowie die Überwachung von Daten wie Geschwindigkeit, Motordrehzahl und Sensormessungen.
- **Vorteile:**
  - Weit verbreitete und standardisierte Schnittstelle.
  - Bietet Zugang zu einer Vielzahl relevanter Fahrzeugdaten.
- **Nachteile:**
  - Datenmenge kann je nach Fahrzeugmodell variieren.
  - Ein zusätzlicher OBD-II-Adapter ist notwendig.

##### Nutzung der ELM-327-Schnittstelle und PIDs:
Durch die Verwendung eines ELM-327-Adapters können spezifische Fahrzeugdaten über Parameter IDs (PIDs) wie Motordrehzahl, Geschwindigkeit oder Kilometerstand in Echtzeit abgefragt und an die Triptracker-App übermittelt werden. Dies erlaubt eine präzise Überwachung relevanter Fahrzeugparameter und steigert den Mehrwert der App für die Nutzer.

- Motordrehzahl(010C)
- Fahrzeuggeschwindigkeit(010D) 
- Odometer(01A6)


##### 2.2. Telematiksysteme
- **Beschreibung:** Telematiksysteme verwenden GPS und Sensoren, um umfassende Fahrzeugdaten wie Position, Geschwindigkeit und Zustand in Echtzeit zu erfassen.
- **Vorteile:**
  - Detaillierte Echtzeitinformationen.
  - Potenzial zur Integration zusätzlicher Dienste wie Navigation oder Sicherheitsfunktionen.
- **Nachteile:**
  - Höhere Kosten und Abhängigkeit von Mobilfunknetzen.

##### 2.3. Fahrzeugherstellerspezifische APIs
- **Beschreibung:** Einige Fahrzeughersteller bieten APIs an, die spezifische Daten aus ihren Fahrzeugen liefern.
- **Vorteile:**
  - Zugang zu detaillierten und spezifischen Informationen.
  - Option zur Fernsteuerung bestimmter Fahrzeugfunktionen.
- **Nachteile:**
  - Begrenzter Zugang, da APIs herstellerspezifisch sind.
  - Komplexe Authentifizierungsmethoden erforderlich.

##### 2.4. CAN-Bus (Controller Area Network)
- **Beschreibung:** Der CAN-Bus ermöglicht die Kommunikation zwischen verschiedenen Steuergeräten im Fahrzeug und bietet Zugriff auf umfangreiche Fahrzeugdaten.
- **Vorteile:**
  - Hohe Datenübertragungsrate und Zuverlässigkeit.
  - Zugriff auf diverse Steuergeräte im Fahrzeug.
- **Nachteile:**
  - Benötigt spezialisierte Hardware und Fachwissen.
  - Komplexe Dateninterpretation.

##### 2.5. Optical Character Recognition (OCR)
- **Beschreibung:** OCR-Technologie erlaubt es, Textinformationen aus Fahrzeugdokumenten oder Anzeigen zu extrahieren.
- **Vorteile:**
  - Kann Informationen aus nicht-digitalen Quellen erfassen.
  - Benötigt lediglich eine Kamera (z.B. Smartphone).
- **Nachteile:**
  - Abhängig von Bildqualität und Erkennungsgenauigkeit.
  - Eingeschränkter Nutzen, da nur begrenzte Datenmenge extrahierbar ist.
  - Hoher Implementierungsaufwand durch fehlendes Know-how in der neuronalen Netzwerktechnologie für OCR auf 7-Segment-Anzeigen.

#### 3. Entscheidung
Nach sorgfältiger Analyse verschiedener Ansätze zur Fahrzeugdatenerfassung erwies sich OBD-II als die effektivste Lösung. Obwohl Telematik, GPS und OCR ebenfalls in Betracht gezogen wurden, waren sie entweder kostenintensiv, ungenau oder mit zu hohem Entwicklungsaufwand verbunden. OBD-II bietet eine bewährte und zuverlässige Möglichkeit, Fahrzeugdaten kosteneffizient und präzise zu erfassen, und ist somit die ideale Wahl für die Implementierung von Triptracker.


Quellen: 

https://business.finanz.at/vorlagen/produkt/?id=15&_gl=1*1khbfws*_gcl_au*MjEyNDg0OTYyLjE3Mjc3MjU4ODQ.*_ga*ODkwMjQ0MzU3LjE3Mjc3MjU4NjE.*_ga_4MCWS49RC9*MTcyNzcyNTg2Mi4xLjEuMTcyNzcyNTg4OS4wLjAuMA..*_ga_9EF8VC5TQ2*MTcyNzcyNTg2Mi4xLjEuMTcyNzcyNTg4OS4wLjAuMA..
https://stackoverflow.com/questions/16721940/why-when-use-sys-platform-on-mac-os-it-print-darwin
https://github.com/barracuda-fsh/python-OBD
https://en.wikipedia.org/wiki/OBD-II_PIDs
https://www.csselectronics.com/pages/obd2-pid-table-on-board-diagnostics-j1979
https://www.obd-2.de/sae-j1979-pids-parameter.html
https://github.com/tesseract-ocr/tesseract
https://de.wikipedia.org/wiki/Tesseract_(Software)
https://developers.google.com/machine-learning?hl=de
https://www.elmelectronics.com/DSheets/ELM327DSH.pdf
https://www.webfleet.com/de_at/webfleet/fleet-management/glossary/can-bus/#:~:text=CAN%20ist%20ein%20standardisiertes%20Fahrzeug,den%20Einsatz%20in%20Kraftfahrzeugen%20entwickelt.
https://en.wikipedia.org/wiki/CAN_bus
https://bmw-cardata.bmwgroup.com/thirdparty/public/car-data/technical-configuration/api-documentation
https://www.verizonconnect.com/de/ressourcen/artikel/was-ist-telematik/#:~:text=Ein%20Telematiksystem%20umfasst%20im%20Kern,mit%20einer%20SIM%2DKarte%20verbinden.
https://de.wikipedia.org/wiki/Telematik


