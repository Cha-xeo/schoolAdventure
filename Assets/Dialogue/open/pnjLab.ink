EXTERNAL changeScene(sceneName)

Hoo vous ! 
->main

=== main ===
-J'ai trouvé le chemin vers un île étrange
-Envie de l'explorer ?
 + [Oui]
  ->Agreed
   //-C'est parti !
 //~ changeScene("Pyrun")
 + [Non]
 ->by


=== Agreed ===
-Ok ! Par ici !
~ changeScene("Floor_0")
->END
=== by ===

Très bien, au revoir !
-> END