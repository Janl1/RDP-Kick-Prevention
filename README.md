# RDP-Kick-Prevention
Das RDP-Kick-Prevention Tool ist eine Software, die das Problem lösen soll, welches entsteht, wenn mehrere Personen mit einem Windows RDP Account arbeiten.

## Das Problem im Detail
Wenn mehrere Personen den selber RDP Account eines Windows Servers nutzen sollen, kommt es zwangsläufig zu einem Problem.<br>
Windows lässt maximal eine Verbindung zu einem Benutzeraccount zu, anders als Bepsielsweise bei Linux Distributionen.<br>
Dies stellt ein großes Problem dar, da man nicht nachvollziehen kann, ob bereits eine andere Person zu dem Server verbunden ist.<br>
Zusätzlich wird bei dem Verbindungsaufbau keine Warnung angezeigt, dass sich ein Benutzer auf dem Server befindet.<br>
Die Konsequenz daraus ist, dass der verbundene Benutzer ohne Vorwarnung vom Server getrennt wird.

## Die Lösung
Bei dem Lösungsansatz, das dieses Tool verfolgt, wird eine Warnung eingeblendet, sobald man zu dem Server verbindet, auf dem sich bereits ein Benutzer befindet.

![Warnung](https://t.gyazo.com/teams/ugc/0032cfc9020444bfea48d88ff2ec814b.png)

Die Warnung kann entweder mit 'OK' ignoriert werden, oder man beednet den Verbindungsaufbau.

## Konfiguration
Das Tool beinhaltet eine ini-Konfigurationsdatei, mit der die Warnung an die Wünsche des Nutzers angepasst werden kann.
```
[Settings]
MessagesCaption = "WARNING!"
MessageText = "There is currently a user connected to this rdp session! If you countinue, he will get kicked out!"
```

## Installation
Um das Tool zu installieren, muss es an die Windows Aufgabenplanung angekoppelt werden.<br>
Dies ist notwendig, damit bei An/Abmeldungen das Tool die Warnung ein und ausschalten kann.<br><br>
Für die Eintragung in die Aufgabenplanung gibt es zwei xml-Dateien, die die Konfiguration durchführen.<br>
Bevor die Dateien importiert werden können, muss der Pfad zum Tool ausgewählt werden.<br>
Dazu die Dateien
```
Hilfsdateien\RDP-Kick-Prevention_Off.xml
Hilfsdateien\RDP-Kick-Prevention_On.xml
```
aus dem Download in einem Editor öffnen und unter `Command (Zeile: 44)` den Pfad zum Tool angeben.
