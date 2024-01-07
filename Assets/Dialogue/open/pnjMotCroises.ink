EXTERNAL changeScene(sceneName)

Coucou toi 
->main

=== main ===
Je fais me mots croisés, envie de m'aidez ?
 + [Oui]
  ->Agreed
   //-C'est parti !
 //~ changeScene("Pyrun")
 + [Non]
 ->by


=== Agreed ===
-Super ! C'est parti !
~ changeScene("WordmapMainMenu")
->END
=== by ===

Peut être plus tard alors
-> END