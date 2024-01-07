EXTERNAL changeScene(sceneName)

Salut toi
->main

=== main ===
-Je m'entraine à communiquer
-Tu veux essayer ?
 + [Oui]
  ->Agreed
   //-C'est parti !
 //~ changeScene("Pyrun")
 + [Non]
 ->by


=== Agreed ===
-Ok lets go !
~ changeScene("MenuLang")
->END
=== by ===

Pas grave, une prochaine fois
-> END