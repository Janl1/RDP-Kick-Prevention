# RDP-Kick-Prevention
Das RDP-Kick-Prevention Tool ist eine Software, die das Problem lösen soll, welches entsteht, wenn mehrere Personen mit einem Windows RDP Account arbeiten.

## Das Problem im Detail
Wenn mehrere Personen den selber RDP Account eines Windows Servers nutzen sollen, kommt es zwangsläufig zu einem Problem.
Windows lässt maximal eine Verbindung zu einem Benutzeraccount zu, anders als Bepsielsweise bei Linux Distributionen.
Dies stellt ein großes Problem dar, da man nicht nachvollziehen kann, ob bereits eine andere Person zu dem Server verbunden ist.
Zusätzlich wird bei dem Verbindungsaufbau keine Warnung angezeigt, dass sich ein Benutzer auf dem Server befindet.
Die Konsequenz daraus ist, dass der verbundene Benutzer ohne Vorwarnung vom Server getrennt wird.

## Die Lösung
Bei dem Lösungsansatz, das dieses Tool verfolgt, wird eine Warnung eingeblendet, sobald man zu dem Server verbindet, auf dem sich bereits ein Benutzer befindet.

[logo]: https://t.gyazo.com/teams/ugc/0032cfc9020444bfea48d88ff2ec814b.png "Warnung"

Die Warnung kann entweder mit 'OK' ignoriert werden, oder man beednet den Verbindungsaufbau.