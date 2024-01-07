EXTERNAL changeTarget(targetName)

Ce panneau indique le sud, que cherchez vous ?
->main

=== main ===
 + [Logique]
  ->Logique
 + [Science]
 ->Science
 + [Rien]
 ->by


=== Logique ===
Une envie ?
+ [Un monde remplis de mystère]
    ~ changeTarget("NPC Lab")
  ->by
 + [Un labyrinthe]
 ~ changeTarget("NPC Maze")
  ->by
 + [Un donjon]
 ~ changeTarget("NPC Donjon")
  ->by
 + [J'ai changé d'avis]
 ->by

=== Science ===
Une envie ?
+ [Nourrir les animaux]
  ~ changeTarget("NPC ZouzouSnake")
  ->by
 + [J'ai changé d'avis]
 ->by

=== by ===
Validé
-> END