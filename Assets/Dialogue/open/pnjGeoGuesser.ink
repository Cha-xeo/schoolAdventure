EXTERNAL changeScene(sceneName)

Bonjour !
->main

=== main ===
Tu m'as l'air malin, tu veux bien jeter un coup d'oeil à cette carte ?
 + [Oui]
  ->Agreed
 + [Non]
 ->by


=== Agreed ===
Merci !
~ changeScene("GeoGuesserMenu")
->END
=== by ===

Pas de soucis, je ne bouge pas.
-> END