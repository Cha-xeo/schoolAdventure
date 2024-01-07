EXTERNAL changeTarget(targetName)

Ce panneau indique l'ouest, que cherchez vous ?
->main

=== main ===
 + [Mathématique]
  ->Math
 + [Géographie]
 ->Geographie
 + [Rien]
 ->by


=== Math ===
Une envie ?
+ [Une course pirate]
    ~ changeTarget("NPC Pirate")
  ->by
 + [Une course en trois dimensions]
 ~ changeTarget("NPC mathRun")
  ->by
 + [Un puzzle]
 ~ changeTarget("NPC TrouMaths")
  ->by
 + [Un jeu de tir géographique]
 ~ changeTarget("NPC TrouMaths")
  ->by
 + [J'ai changé d'avis]
 ->by

=== Geographie ===
Une envie ?
+ [Un jeu de cartes]
  ~ changeTarget("NPC ZouzouPays")
  ->by
 + [Un jeu sur la carte du monde]
 ~ changeTarget("NPC ZouzouPays")
  ->by
 + [J'ai changé d'avis]
 ->by

=== by ===
Validé
-> END