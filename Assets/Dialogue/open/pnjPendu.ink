EXTERNAL changeScene(sceneName)

Hey toi !
->main

=== main ===
Une partie de pendu ça te tente ?
 + [Oui]
  ->Agreed
   //-C'est parti !
 //~ changeScene("Pyrun")
 + [Non]
 ->by


=== Agreed ===
-C'est parti !
~ changeScene("MenuFr")
->END
=== by ===

Une prochaine fois
-> END