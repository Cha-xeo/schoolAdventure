EXTERNAL changeScene(sceneName)

Coucou
->main

=== main ===
Je chasse des formes, tu veux m'aider ? 
 + [Oui]
  ->Agreed
   //-C'est parti !
 //~ changeScene("Pyrun")
 + [Non]
 ->by


=== Agreed ===
-C'est parti !
~ changeScene("MenuGeometry")
->END
=== by ===

Dommage, reviens quand tu veux
-> END