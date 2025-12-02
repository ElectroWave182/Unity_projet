using System;
using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class Camescope: MonoBehaviour
{
	public void Update ()
	{
		// Bouger la caméra avec les flèches directionnelles
		float horizontal = Input. GetAxis ("horizontal");
		float vertical   = Input. GetAxis ("vertical");
		transform. Translate (new Vector3 (vertical - horizontal, 0, -vertical - horizontal), Space. World);
		
		// Zoomer avec la molette jusqu'à une limite
		float zoom = Input. GetAxis ("molette");
		if (zoom > 0 && transform. position. y <= 10)
			zoom = 0;
		transform. Translate (new Vector3 (0, 0, zoom));
	}
}
