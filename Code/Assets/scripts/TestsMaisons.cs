using System;
using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class TestsMaisons: MonoBehaviour
{
	private const int maxMaisons = 0;
	
	
    public void Start ()
    {
		GameObject maison;
		Vector3 taille;
		float rapport;
		string sortie = "Coordonnées des maisons :";
		
        for (int numMaison = 1; numMaison <= TestsMaisons. maxMaisons; numMaison ++)
		{
			maison = GameObject. Find ("" + numMaison);
			taille = maison. GetComponent <Renderer> (). bounds. size;
			rapport = taille. x / taille. z;
			sortie += "\n" + taille + " " + rapport;
		}
		
		Debug. Log (sortie);
    }
	
    void FixedUpdate ()
    {
		if (Time. time == 3)
		{
			Debug. Log ("Taux d'IPS moyen : " + Time. frameCount / 3);
		}
    }
}


/*
Tailles des bâtiments (x, y, z) :

1 x 1   -> (20.00, 0.00, 20.00)  1         -> * 0.5
2 x 2   -> (11.09, 5.80, 8.30)   1.335895  -> * 1.4
3 x 2   -> (15.12, 5.79, 7.74)   1.952234  -> * 1.8
3 x 3   -> (13.00, 16.93, 13.07) 0.9949908 -> * 2.1
3 x 3   -> (13.66, 24.80, 12.30) 1.110869  -> * 2.1
7 x 4   -> (36.81, 10.06, 20.07) 1.833588  -> * 1.9
5 x 4   -> (15.52, 14.97, 12.26) 1.266184  -> * 2.3
3 x 5   -> (16.40, 18.97, 27.50) 0.5963637 -> * 1.8
3 x 5   -> (16.40, 18.97, 27.50) 0.5963637 -> * 1.8
5 x 3   -> (24.77, 11.47, 13.51) 1.833616  -> * 2
4 x 4   -> (17.64, 10.66, 18.07) 0.9763261 -> * 2
2 x 2   -> (7.36, 10.41, 7.41)   0.9933068 -> * 1.8
7 x 5 +
3 x 7   -> (35.44, 16.20, 62.84) 0.5640491 -> * 1.8
3 x 4   -> (9.98, 16.47, 16.33)  0.6112546 -> * 2.4
14 x 18 -> (35.46, 11.73, 44.76) 0.7923062 -> * 3.9
*/
