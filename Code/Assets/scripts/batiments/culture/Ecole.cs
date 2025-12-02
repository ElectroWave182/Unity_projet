using System;
using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class Ecole: MonoBehaviour
{
	public Vector2Int emplacement {get; set;}
	
	private bool enConstruction = true;
	private const int tailleX = 7;
	private const int tailleZ = 12;
	
	
	public void Start ()
	{
		// Coût
		Economie. argent -= 150;
		Economie. acier  -= 60;
		Economie. beton  -= 200;
		Economie. bois   -= 400;
	}
	
	
	// Termine la construction lors d'un clic gauche
	
	public void Update ()
	{
		if (this. enConstruction && Input. GetMouseButtonDown (0))
		{
			this. enConstruction = false;
			Invoke ("placer", 50);
		}
	}
	
	
	public void placer ()
	{
		// Apport
		Economie. capaciteCulture += 500;
	}
	
	
	public List <Vector2Int> casesAdjacentes ()
	{
		var cases = new List <Vector2Int> ();
		
		
		// Cases côté -x
		for (int z = 0; z < tailleZ; z ++)
		{
			cases. Add (new Vector2Int (-1, z));
		}
		
		// Cases côté x
		for (int z = 0; z < 5; z ++)
		{
			cases. Add (new Vector2Int (tailleX, z));
		}
		
		// Cases côté -z
		for (int x = 0; x < 3; x ++)
		{
			cases. Add (new Vector2Int (x, -1));
		}
		
		// Cases côté z
		for (int x = 0; x < tailleX; x ++)
		{
			cases. Add (new Vector2Int (x, tailleZ));
		}
		
		// Cases du creux côté x
		for (int z = 0; z < 7; z ++)
		{
			cases. Add (new Vector2Int (3, z));
		}
		
		// Cases du creux côté -z
		for (int x = 3; x < tailleX; x ++)
		{
			cases. Add (new Vector2Int (x, 6));
		}
		
		
		// Décalage par rapport à l'emplacement
		for (int indice = 0; indice < cases. Count; indice ++)
		{
			cases [indice] += this. emplacement;
		}
		
		
		return cases;
	}
}
