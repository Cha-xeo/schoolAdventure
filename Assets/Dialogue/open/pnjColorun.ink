EXTERNAL changeScene(sceneName)

Bonjour 
->main

=== main ===
Envie de courir après les couleurs ?
 + [Oui]
  ->Agreed
   //-C'est parti !
 //~ changeScene("Pyrun")
 + [Non]
 ->by


=== Agreed ===
-Super ! C'est parti !
~ changeScene("MenuColorun")
->END
=== by ===

Peut être plus tard
-> END