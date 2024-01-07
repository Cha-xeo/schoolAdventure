EXTERNAL changeTarget(targetName)

Ce panneau indique l'est, que cherchez vous ?
->main

=== main ===
 + [Français]
  ->Francais
 + [Langues]
 ->Langues
 + [Musiques]
 ->Musiques
 + [Rien]
 ->by


=== Francais ===
Une envie ?
+ [Un quizz à logo]
    ~ changeTarget("NPC LogoQuizz")
  ->by
 + [Une detection d'intrus]
 ~ changeTarget("NPC Intruder")
  ->by
 + [Un pendu]
 ~ changeTarget("NPC Pendu")
  ->by
 + [Des mots croisés]
 ~ changeTarget("NPC MotCroise")
  ->by
 + [J'ai changé d'avis]
 ->by

=== Langues ===
Une envie ?
+ [Un jeu de couleurs anglais]
  ~ changeTarget("NPC Colorun")
  ->by
 + [Un jeu de detection anglais]
 ~ changeTarget("NPC FindingGame")
  ->by
  + [Un quizz de langues]
 ~ changeTarget("NPC ZouzouLangue")
  ->by
 + [J'ai changé d'avis]
 ->by
 
 === Musiques ===
Une envie ?
+ [Un jeu de solfège]
  ~ changeTarget("NPC Musique")
  ->by
 + [J'ai changé d'avis]
 ->by

=== by ===
Validé
-> END