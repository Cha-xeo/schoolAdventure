EXTERNAL changeScene(sceneName)

Bonjouur.
->main

=== main ===
Mon oreille n'est plus ce qu'elle était, tu pourrais m'aider ?
 + [Oui]
  ->Agreed
 + [Non]
 ->by


=== Agreed ===
Super, par ici !
~ changeScene("SymphoQuizMenu")
->END
=== by ===

Très bien, une prochaine fois peut être.
-> END