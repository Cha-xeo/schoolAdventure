VAR choice = false


-> main

=== main ===
Veut-tu explorer le labyrinthe?
    + [Oui]
        ~ choice = true
        -> chosen("de rentrer dans le labyrinthe")
    + [Non]
        ~ choice = false
        -> chosen("de rentrer chez toi")
        
=== chosen(path) ===
Tu as choisie {path}!
{choice:
    Trouve la clé du labyrinth pour ouvrir ces portes.
  - else:
    Es-tu sur de ne pas vouloir explorer le labyrinthe?
    Si tu change d'avis vas chercher la clé du labyrinth.
}
-> END