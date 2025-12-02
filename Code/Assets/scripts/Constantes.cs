using System;
using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class Constantes
{
	// Tailles des petits carrés sur le terrain (en coordonnée Unity)
	public const float tailleCase = 10;
	
	// Temps en secondes à maintenir appuyé avant de simuler une pression
	public const float delaiAvantMaintien = 0.5f;
	
	// Maintenir appuyé simule une pression toutes les periodeMaintien secondes
	public const float periodeMaintien = 0.03f;
}
