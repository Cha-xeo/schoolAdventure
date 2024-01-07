VAR exit = false
-> main

=== main ===
Insérer une clé dans la serrure ?
    + [Oui]
        ~ exit = true
        Des runes apparaisses.
        -> DONE
    + [Non]
        Rien ne ce passe.
        ~ exit = false
        -> DONE
-> END