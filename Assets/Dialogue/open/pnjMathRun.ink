EXTERNAL changeScene(sceneName)

Et coucou toi !
->main

=== main ===
Je prépare une course, tu veux t'entrainer ?
 + [Oui]
  ->Agreed
 + [Non]
 ->by


=== Agreed ===
Allez, c'est parti !
~ changeScene("MathRunMenuScene")
->END
=== by ===

Eh bien n'hésites pas à repasser.
-> END