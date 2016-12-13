## README ##

## 1. Warum Git? ##

Git ist der Shit unter den Version Controll Systems (VCS) und wird von den allermeisten Software-Buden genutzt. Mit Git ersparst du dir das Anlegen von "myProject_version01", "myProject_version02" usw. da Git jeden Bearbeitungsschritt den du registrierst im Verlauf dokumentiert und nur die Differenz zum jeweils voherigen abspeichert. Dadurch kann man beliebig viel und wesentlich kontrollierter "R�ckg�ngig machen". Des Weiteren ist es hierdurch erst m�glich, dass praktisch unendlich viele Entwickler am gleichen Projekt arbeiten, ohne etwas zu Zerst�ren. Git kann noch viel mehr, aber daf�r konsultiere bitte die Suchmaschine deine (Nicht-)Vertrauens.

Konkret in unserem Fall ergibt sich dar�ber hinaus der Vorteil, dass ein gewisses Ma� an Dokumentation, die ja zu 25% in die Endnote einflie�t, durch Git quasi automatisch gegeben ist.


## 2. Wie zum Geier benutze ich das? ##

Alles andere kann nachgeschlagen werden, das wichtigste im workflow is jedoch in dieser Reihenfolge:
- $ git add "myFiles/*"
- $ git commit -m "My Message"
- $ git pull
- $ git push
- $ git checkout -b "mybranch"

HINWEIS:
Um Konflikte zwischen �nderungen zu vermeiden, am besten immer regelm��ig einen "pull" vor der �nderung und einen commit nach der �nderung.


## 3. Datei ohne Namen? Gitignore! ##

Mit .gitignore lassen sich Ausnahmen beim tracken von files festlegen. Teilweise generiert Unity tempor�re Files u.a. beim �ffnen und Schlie�en des Editors. Falls du noch auf weitere solcher F�lle st��t, bitte hinzuf�gen, vor allem, wenn sie sich nur auf deinem PC befinden. 
Eigentlich sollte alles sonst soweit in den folgenden Dateien untergebracht sein:
- .gitignore
- unity.gitignore