EXTERNAL changeScene(sceneName)

Ahoy  !
->main

=== main ===
Vous me semblez bien capable, vous voulez m'aider à recupérer mes trésors ?
 + [Oui]
  ->Agreed
   //-C'est parti !
 //~ changeScene("Pyrun")
 + [Non]
 ->by


=== Agreed ===
-Super ! C'est parti !
~ changeScene("Pyrun")
->END
=== by ===

Raah très bien, pas de soucis
-> END