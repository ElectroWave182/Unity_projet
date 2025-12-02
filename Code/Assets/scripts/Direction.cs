using System;
using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class Direction
{
	public float tempsMaintien {get; set;}
	public KeyCode touche {get;}
	public Vector3 vecteurUnitaire {get;}
	
	
	public Direction (string codeTouche)
	{
		switch (codeTouche)
		{
			case "z":
				this. touche = KeyCode. Z;
				this. vecteurUnitaire = Vector3. back;
				break;
				
			case "q":
				this. touche = KeyCode. Q;
				this. vecteurUnitaire = Vector3. right;
				break;
				
			case "s":
				this. touche = KeyCode. S;
				this. vecteurUnitaire = Vector3. forward;
				break;
				
			case "d":
				this. touche = KeyCode. D;
				this. vecteurUnitaire = Vector3. left;
				break;
				
			default:
				Debug. LogError ("Touche " + codeTouche + " non reconnue par Direction.cs.");
				break;
		}
		
		this. tempsMaintien = Single. PositiveInfinity;
	}
}
