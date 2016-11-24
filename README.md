## README ##

Du hast zum Git-Ordner gefunden. Bitte lies dir kurz die Beschreibung zu diesem Ordner durch.


## 1. Hinweise zur Handhabe ###

- Dieser Ordner darf nur indirekt via git bearbeitet werden
- D.h. Keine Dateien einfach hinzuf�gen, l�schen oder bearbeiten
- Den Ordner unter keinen Umst�nden umbenennen
- Der Ordner enth�lt ein Git-Projekt unter
-- "~\Dropbox\Game Development Group 2\Git\project.git"
- Falls du den Ordner unter Windows nicht siehst, geh zu:
-- Systemsteuerung -> "Versteckte Dateien und Ordner ausblenden"


## 2. Warum Git? ##

Git ist der Shit unter den Version Controll Systems (VCS) und wird von den allermeisten Software-Buden genutzt. Mit Git ersparst du dir das Anlegen von "myProject_version01", "myProject_version02" usw. da Git jeden Bearbeitungsschritt den du registrierst im Verlauf dokumentiert und nur die Differenz zum jeweils voherigen abspeichert. Dadurch kann man beliebig viel und wesentlich kontrollierter "R�ckg�ngig machen". Des Weiteren ist es hierdurch erst m�glich, dass praktisch unendlich viele Entwickler am gleichen Projekt arbeiten, ohne etwas zu Zerst�ren. Git kann noch viel mehr, aber daf�r konsultiere bitte die Suchmaschine deine (Nicht-)Vertrauens.

Konkret in unserem Fall ergibt sich dar�ber hinaus der Vorteil, dass ein gewisses Ma� an Dokumentation, die ja zu 25% in die Endnote einflie�t, durch Git quasi automatisch gegeben ist.


## 3. Wie zum Geier benutze ich das? ##

Zun�chst empfielt sich dieses etwa 10 Minuten dauernde interaktive Tutorial: https://try.github.io/levels/1/challenges/1. Git arbeitet mit Kopien von repositories. Das bedeutet, dass sich hier in diesem Ordner das repository "origin" befinden, also wo alles zusammenkommt. Um damit arbeiten zu k�nnen musst du zun�chst Git installieren und eine Kopie des repositories lokal auf deinem PC (au�erhalb des geteilten Dropbox-Ordners) erstellen. Das geht wie folgt:

1. Git installieren: https://git-scm.com/download/win
2. Git CMD �ffnen.
3. Folgendes eingeben:

~\C:\ $ D:
~\D:\ $ cd ~\myProject
~\myProject $ git init
~\myProject $ git add .
~\myProject $ git commit -m "first commit"
~\myProject $ git remote add origin "~\Dropbox\Game Development Group 2\Git\project.git\project.git"
~\myProject $ git push -u origin master

HINWEIS:
- "~\myProject" ist dein lokaler Ordner, den du hierf�r erstellt hast
- "~\Dropbox" ist dein lokaler Dropbox-Ordner, der sich automatisch synchronisiert
- Nur den Befehl eingeben, der nach "$" folgt
- Erste Zeile nur eingeben, wenn das Laufwerk bspw. zu D: gewechselt werden soll
- Bei Leerzeichen im Pfad nicht vergessen alles in Anf�hrungszeichen einzuschlie�en (Ich habe es vergessen :D )

Alles andere kann nachgeschlagen werden, das wichtigste im workflow is jedoch in dieser Reihenfolge:
- $ git add "myFiles/*"
- $ git commit -m "My Message"
- $ git pull
- $ git push
- $ git checkout -b "mybranch"

HINWEIS:
Um Konflikte zwischen �nderungen zu vermeiden, am besten immer regelm��ig einen "pull" vor der �nderung und einen commit nach der �nderung.


## 4. Datei ohne Namen? Gitignore! ##

Mit .gitignore lassen sich Ausnahmen beim tracken von files festlegen. Teilweise generiert Unity tempor�re Files u.a. beim �ffnen und Schlie�en des Editors. Falls du noch auf weitere solcher F�lle st��t, bitte hinzuf�gen, vor allem, wenn sie sich nur auf deinem PC befinden. 
Eigentlich sollte alles sonst soweit in den folgenden Dateien untergebracht sein:
- .gitignore
- unity.gitignore