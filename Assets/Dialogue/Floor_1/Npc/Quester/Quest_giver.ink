VAR exit = false

Bienvenue dans la grotte aux pyrates.
Pour avancer au niveau suivant répond à mes questions.
*[Ok] -> Ok
*[mmmh, non] -> Mmmhnon

==Ok==
-> Question_1

==Mmmhnon==
Sans moi tu ne pourras pas avancer.
-> Question_1


== Question_1 ==
As-tu déjà joué à Pyrun ?
*[Oui] -> Good
*[C'est quoi?] -> Bad
*[Non] -> Non
*[Pas besoin] -> question2



== Good ==
Tu connais donc les mathématiques.
-> question2

== Bad ==
Pyrun est un jeu pour améliorer t'es connaissance en mathématiques.
Tu devrais essayer.
Ce sera donc une quastion facile.
-> Question_easy

== Non ==
C'est dommage tu devrais essayer.
Ce sera donc une quastion facile.
-> Question_easy

==question2==
Combien font 2 foix 2
*[4] -> BonneReponse
*[2] -> Question_easy
*[8] -> Question_easy

== Question_easy ==
Combien font 2 plus 2
*[4] -> BonneReponse
*[2] -> Question_easy
*[5] -> Question_easy

== BonneReponse ==
Bien
~ exit = true
-> END