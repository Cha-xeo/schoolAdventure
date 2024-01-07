EXTERNAL changeScene(sceneName)

Oh mon petit !
->main

=== main ===
Ma mémoire me jout des tours, tu veux bien m'aider ?
 + [Oui]
  ->Agreed
   //-C'est parti !
 //~ changeScene("Pyrun")
 + [Non]
 ->by


=== Agreed ===
Merci, c'est par ici.
~ changeScene("TrouMathsMenu")
->END
=== by ===

Hum, une prochaine fois peut être.
-> END