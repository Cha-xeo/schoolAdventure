EXTERNAL changeScene(sceneName)

He toi !
->main

=== main ===
Je dois nourrir mes animaux, tu veux m'aider ?
 + [Oui]
  ->Agreed
 + [Non]
 ->by


=== Agreed ===
Merci, c'est par là !
~ changeScene("Snake")
->END
=== by ===

Une prochaine fois !
-> END