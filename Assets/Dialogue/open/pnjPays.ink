EXTERNAL changeScene(sceneName)

Bonjour
->main

=== main ===
Interessé par un jeu sur les pays ?
 + [Oui]
  ->Agreed
   //-C'est parti !
 //~ changeScene("Pyrun")
 + [Non]
 ->by


=== Agreed ===
-C'est parti !
~ changeScene("Menu")
->END
=== by ===

Une prochaine fois !
-> END