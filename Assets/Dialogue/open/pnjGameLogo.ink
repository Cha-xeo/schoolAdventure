EXTERNAL changeScene(sceneName)

Salut !
->main

=== main ===
Ma vue baisse, j'ai du mal à reconnaitre mes animaux, tu peux m'aider ?
 + [Oui]
  ->Agreed
 + [Non]
 ->by


=== Agreed ===
Merci, c'est par ici !
~ changeScene("GameLogo")
->END
=== by ===

Pas de soucis, n'hésites pas à repasser.
-> END