EXTERNAL changeScene(sceneName)

Hey toi 
->main

=== main ===
Je travaille mon anglais, tu veux essayer ?
 + [Oui]
  ->Agreed
   //-C'est parti !
 //~ changeScene("Pyrun")
 + [Non]
 ->by


=== Agreed ===
-Ok ! Lets go !
~ changeScene("FindGameMenu")
->END
=== by ===

Ok later
-> END