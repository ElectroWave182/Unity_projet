using System;
using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class Habitation3: MonoBehaviour
{
	public Vector2Int emplacement {get; set;}
	
	private bool enConstruction = true;
	private const int tailleX = 3;
	private const int tailleZ = 3;
	
	
	public void Start ()
	{
		// Coût
		Economie. argent -= 55;
		Economie. acier  -= 20;
		Economie. beton  -= 100;
		Economie. bois   -= 100;
	}
	
	
	// Termine la construction lors d'un clic gauche
	
	public void Update ()
	{
		if (this. enConstruction && Input. GetMouseButtonDown (0))
		{
			this. enConstruction = false;
			Invoke ("placer", 10);
		}
	}
	
	
	public void placer ()
	{
		// Apport
		Economie. capaciteLogement += 100;
	}
	
	
	public List <Vector2Int> casesAdjacentes ()
	{
		var cases = new List <Vector2Int> ();
		
		
		// Cases côté -x et x
		for (int z = 0; z < tailleZ; z ++)
		{
			cases. Add (new Vector2Int (-1, z));
			cases. Add (new Vector2Int (tailleX, z));
		}
		
		// Cases côté -z et z
		for (int x = 0; x < tailleX; x ++)
		{
			cases. Add (new Vector2Int (x, -1));
			cases. Add (new Vector2Int (x, tailleZ));
		}
		
		
		// Décalage par rapport à l'emplacement
		for (int indice = 0; indice < cases. Count; indice ++)
		{
			cases [indice] += this. emplacement;
		}
		
		
		return cases;
	}
}
