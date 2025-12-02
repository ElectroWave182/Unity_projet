using System;
using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class Batiment: MonoBehaviour
{
	private bool deplace = true;
	private int
		tailleX,
		tailleZ
	;
	private Direction
		z = new Direction ("z"),
		q = new Direction ("q"),
		s = new Direction ("s"),
		d = new Direction ("d")
	;
	private Vector3 tailleReelle;
	
	
	public void Start ()
	{
		this. tailleReelle = GetComponent <Renderer> (). bounds. size;
		this. tailleX = formaterTaille (this. tailleReelle. x);
		this. tailleZ = formaterTaille (this. tailleReelle. z);
	}
	
	
	// Retourne la taille d'un bâtiment en nombre de cases
	
	private int formaterTaille (float coordonneeReelle)
	{
		return (int) (Math. Ceiling (coordonneeReelle / Constantes. tailleCase) * Constantes. tailleCase);
	}
	
	
	public void Update ()
	{
		// Le bâtiment est déplacé
		
		if (this. deplace)
		{
			if (Input. GetMouseButtonDown (0))
			{
				this. deplace = false;
			}
			
			this. deplacer (this. z);
			this. deplacer (this. q);
			this. deplacer (this. s);
			this. deplacer (this. d);
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
		transform. Translate (direction * Constantes. tailleCase);
	}
}
