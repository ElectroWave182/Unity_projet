using System;
using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class Route: MonoBehaviour
{
	public GameObject routeInerte;
	public string etat {get; set;}
	
	private Direction
		z = new Direction ("z"),
		q = new Direction ("q"),
		s = new Direction ("s"),
		d = new Direction ("d")
	;
	
	
	// Début de la construction
	
	public void Start ()
	{
		etat = "deplacee";
	}
	
	
	public void Update ()
	{
		switch (this. etat)
		{
			// Le bloc de route est déplacé
			
			case "deplacee":
			
				// Le bloc de route passe en extension
				if (Input. GetMouseButtonDown (0))
				{
					this. etat = "etendue";
				}
				
				this. deplacer (this. z);
				this. deplacer (this. q);
				this. deplacer (this. s);
				this. deplacer (this. d);
				
				break;
				
				
			// Le bloc de route est étendu
			
			case "etendue":
			
				// Le bloc de route passe en fixe
				if (Input. GetMouseButtonDown (0))
				{
					this. etat = "placee";
				}
				
				this. deplacer (this. z);
				this. deplacer (this. q);
				this. deplacer (this. s);
				this. deplacer (this. d);
				
				break;
		}
	}
	
	
	// Touches de déplacement selon une direction
	
	private void deplacer (Direction direction)
	{
		// Le joueur commence à maintenir la touche
		if (Input. GetKeyDown (direction. touche))
		{
			this. bouger (direction. vecteurUnitaire);
			direction. tempsMaintien = Time. time;
		}
		
		// Le joueur arrête de maintenir la touche
		if (Input. GetKeyUp (direction. touche))
		{
			direction. tempsMaintien = Single. PositiveInfinity;
		}
		
		// Répétition du mouvement si le joueur maintient la touche depuis suffisemment longtemps
		if (Time. time - direction. tempsMaintien > Constantes. delaiAvantMaintien)
		{
			direction. tempsMaintien += Constantes. periodeMaintien;
			this. bouger (direction. vecteurUnitaire);
		}
	}
	
	
	// Effectue un mouvement d'une case selon la direction indiquée
	
	public void bouger (Vector3 direction)
	{
		// Extension de la route
		if (this. etat == "etendue")
		{
			Transform extension = Instantiate (this. routeInerte). transform;
			extension. SetParent (transform. root. Find ("construction/routes"));
			extension. position = transform. position;
		}
		
		// La tuile principale bouge
		transform. Translate (direction * Constantes. tailleCase);
	}
}
