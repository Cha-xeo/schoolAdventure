EXTERNAL changeScene(sceneName)

Bonjour, citoyen.
->main

=== main ===
On a besoin d'un regard neuf sur un dossier, tu pourrais nous aider ?
 + [Oui]
  ->Agreed
 + [Non]
 ->by


=== Agreed ===
Super, par ici !
~ changeScene("IntruderMenu")
->END
=== by ===

Très bien, une prochaine fois peut être.
-> END