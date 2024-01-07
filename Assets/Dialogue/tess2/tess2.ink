// Character variables. We track just two, using a +/- scale
VAR forceful = 0
VAR evasive = 0
VAR Langue = 0
VAR Math = 0
VAR Money = 100

// Inventory Items
VAR teacup = false
VAR gotcomponent = false


// Story states: these can be done using read counts of knots; or functions that collect up more complex logic; or variables
VAR drugged = false
VAR hooper_mentioned = false

VAR losttemper = false
VAR admitblackmail = false

// what kind of clue did we pass to Hooper?
CONST NONE = 0
CONST STRAIGHT = 1
CONST CHESS = 2
CONST CROSSWORD = 3
VAR hooperClueType = NONE

VAR hooperConfessed = false

CONST SHOE = 1
CONST BUCKET = 2
VAR smashingWindowItem = NONE

VAR notraitor = false
VAR revealedhooperasculprit = false
VAR smashedglass = false
VAR muddyshoes = false

VAR framedhooper = false

// What did you do with the component?
VAR putcomponentintent = false
VAR throwncomponentaway = false
VAR piecereturned = false
VAR longgrasshooperframe = false


// DEBUG mode adds a few shortcuts - remember to set to false in release!
VAR DEBUG = false
{DEBUG:
	IN DEBUG MODE!
	*	[Beginning...]	-> start
- else:
	// First diversion: where do we begin?
 -> start
}

 /*--------------------------------------------------------------------------------
	Wrap up character movement using functions, in case we want to develop this logic in future
--------------------------------------------------------------------------------*/


 === function lower(ref x)
 	~ x = x - 1

 === function raise(ref x)
 	~ x = x + 1

/*--------------------------------------------------------------------------------

	Start the story!

--------------------------------------------------------------------------------*/
EXTERNAL LabEnd(money)

=== start === 

//  Intro
	- 	Ici sera ton dernier challenge. 
		*[Ok]
	    Te tenir en face de moi signifie que tu connais d'autres jeux. 
		Réponds correctement et tu seras récompenser.
		Choisi un type de jeu? 

	- (opts)
 		* 	(think) [Qui êtes vous?] 
 			Je suis un arbre d'un noël passer.
 			Mais cela n'a pas d'importance.
 			Choisi.
			-> opts
 		*	[zouzouLangue]
 		    Un linguistique, interessant.
 		    Comment dit-on "l'enfant" en allemand?
 			* * 	[das Kind] 
	 				Bien, reviend plus tard et j'aurais d'autres questions pour toi.
		 			~ raise(Langue)
	 		* * 	[The Kid] 
		 			Si la question avait était en anglais tu auais eu juste.
		 			~ lower(Langue)
	 		* * 	[Kinder] 
		 			Presque, Kinder est "enfant" "das Kind" était l'enfant.
		 			~ lower(Langue)
		*	[Pyrun]
		
		    Combien fait l'additon de 4 et 5
		    * * 	[10] 
	 				Faux.
		 			~ lower(Math)
	 		* * 	[9] 
		 			Presque. 
		 			~ lower(Math)
	 		* * 	[8] 
		 			Bien, reviend plus tard et j'aurais d'autres questions pour toi.
		 			~ raise(Math)
	- 	-> waited

= waited 
        ~ Money += Math+Langue
        ~ LabEnd(Money)
	-	Ton score te donne {Money} d'or.
->END