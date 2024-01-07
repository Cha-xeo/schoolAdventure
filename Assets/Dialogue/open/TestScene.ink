EXTERNAL newQuest(iter)

Bonjour !
->main

=== main ===
Voulez vous une explication sur ce monde ?
 + [Oui]
    ~ newQuest(1)
    ~ newQuest(2)
 -> explication
 + [Non]
 ->by


=== explication ===
-Très bien
-Ici vous pouvez trouver certaines personnes qui seront ravies d'échanger avec vous.
-Si vous êtes perdus, utilisez les panneaux autour de nous.
-Pour communiquer, utilisez 'i' comme vous l'avez fait avec moi.

->END
=== by ===

-Je vois, très bien.
-Bonne continuation !
-> END
