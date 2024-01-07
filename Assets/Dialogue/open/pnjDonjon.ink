EXTERNAL changeScene(sceneName)

Psst toi !
->main

=== main ===
Je connais l'entrée d'un donjon secret, intéréssé ?
 + [Oui]
  ->Agreed
 + [Non]
 ->by


=== Agreed ===
Allez, par ici !
~ changeScene("BasementMain")
->END
=== by ===

Repasses me voir si tu changes d'avis !
-> END