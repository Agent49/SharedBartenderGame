## README ##

## Members ##
- Kai Jurgeit @Agent49 (Win7, Win8, Win10)
- Tobias Krueger @fre2dyy
- Martin Heise @Khamu


## 1. Warum Git? ##

Git ist der Shit unter den Version Controll Systems (VCS) und wird von den allermeisten Software-Buden genutzt. Mit Git ersparst du dir das Anlegen von "myProject_version01", "myProject_version02" usw. da Git jeden Bearbeitungsschritt den du registrierst im Verlauf dokumentiert und nur die Differenz zum jeweils voherigen abspeichert. Dadurch kann man beliebig viel und wesentlich kontrollierter "Rückgängig machen". Des Weiteren ist es hierdurch erst möglich, dass praktisch unendlich viele Entwickler am gleichen Projekt arbeiten, ohne etwas zu Zerstören. Git kann noch viel mehr, aber dafür konsultiere bitte die Suchmaschine deine (Nicht-)Vertrauens.
Konkret in unserem Fall ergibt sich darüber hinaus der Vorteil, dass ein gewisses Maß an Dokumentation, die ja zu 25% in die Endnote einfließt, durch Git quasi automatisch gegeben ist.


## 2. Das Setup ##

1. Unity 5.5 öffnen (ggf. Version 5.5 vorher installieren)
2. Projekt erstellen (im Folgenden "mySharedProject" genannt, gleichzeitig Ordner)
3. Unity schließen
4. ~\mySharedProject\ProjectSettings löschen
5. git CMD öffnen, folgendes eingeben (nur das was auf "$" folgt):
ACHTUNG: "- $ cd ~\mySharedProject" wechselt in betreffenden Ordner und hängt von Win, Linux, Mac usw. ab

- $ git config --global user.name "John Doe"
- $ git config --global user.email johndoe@example.com
- $ cd ~\mySharedProject
- $ git init
- $ git remote add origin https://github.com/Agent49/SharedBartenderGame.git
- $ git pull origin master
- Eintrag in README.md (in dieser Datei, unter ~\mySharedProject), dein Name unter "Members"
- $ git add *
- $ git commit -m "My inital commit"
- $ git push -u origin master


## 3. Der Workflow ##

Das wichtigste im workflow ist in dieser Reihenfolge:
- $ git add "myFiles/*"
- $ git commit -m "My Message"
- $ git pull
- $ git push
- $ git checkout -b "mybranch"

HINWEIS:
Um Konflikte zwischen Änderungen zu vermeiden, am besten immer regelmäßig einen "pull" vor der Änderung und einen commit nach der Änderung.


## 4. Datei ohne Namen? Gitignore! ##

Mit .gitignore lassen sich Ausnahmen beim tracken von files festlegen. Teilweise generiert Unity temporäre Files u.a. beim Öffnen und Schließen des Editors. Falls du noch auf weitere solcher Fälle stößt, bitte hinzufügen, vor allem, wenn sie sich nur auf deinem PC befinden. 
Eigentlich sollte alles sonst soweit in den folgenden Dateien untergebracht sein:
- .gitignore

## 5. Weiteres in Bezug auf Unity und Git ##
Unity arbeitet viel mit binaries, die in Versionskontrollsystemen (VCS) Schwierigkeiten bereiten können. Deswegen empfielt es sich vor Aufsetzen (!) eines Repositories folgende Anleitung zu befolgen:
http://stackoverflow.com/questions/21573405/how-to-prepare-a-unity-project-for-git