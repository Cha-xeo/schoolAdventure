EXTERNAL changeScene(sceneName)

Hey toi !
->main

=== main ===
Je connais l'emplacement d'un labyrinthe, intéréssé ? 
 + [Oui]
  ->Agreed
   //-C'est parti !
 //~ changeScene("Pyrun")
 + [Non]
 ->by


=== Agreed ===
-C'est parti !
~ changeScene("MazeMenu")
->END
=== by ===

Une prochaine fois
-> END