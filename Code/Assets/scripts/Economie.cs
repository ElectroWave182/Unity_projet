/*
Economie. tauxImpots += 0.01;
Economie. tauxImpots -= 0.01;
*/

using System;
using System. Collections;
using System. Collections. Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Economie: MonoBehaviour
{
	public TextMeshProUGUI argentText;
	public TextMeshProUGUI nourritureText;
	public TextMeshProUGUI boisText;
	public TextMeshProUGUI betonText;
	public TextMeshProUGUI acierText;
	public TextMeshProUGUI habitantsText;
	public Slider satisfactionSlider;

	// Fait des affichages toutes les secondes
	public bool bavard = false;
	
	public static double
		satisfaction,
		satisfactionChomage,
		satisfactionCulture,
		satisfactionImpots,
		satisfactionLimite,
		satisfactionLogement,
		satisfactionNourriture,
		tauxImpots
	;
	public static int
		acier,
		argent,
		beton,
		bois,
		capaciteCulture,
		capaciteLogement,
		habitantsAcier,
		habitantsBeton,
		habitantsBois,
		habitantsChomage,
		habitantsConstruction,
		habitantsCultives,
		habitantsDedans,
		habitantsNourriture,
		nourriture,
		nourritureConsommation,
		nourritureProduction
	;
	
	
	// Création de l'économie de la ville

    public void Start ()
    {
		// Initialisation des habitants
		habitantsAcier        = 0;
		habitantsBeton        = 0;
		habitantsBois         = 0;
		habitantsChomage      = 10;
		habitantsConstruction = 0;
		habitantsCultives     = 0;
		habitantsDedans       = 0;
		habitantsNourriture   = 0;
		
		// Initialisation des habitacles
		capaciteCulture  = 0;
		capaciteLogement = 0;
		
		// Initialisation des ressources
		acier      = 0;
		argent     = 1000;
		beton      = 4000;
		bois       = 10 * 1000;
		nourriture = 10 * 1000;
		
		// Initialisation des curseurs
		satisfaction       = 1;
		satisfactionLimite = 1;
		tauxImpots         = 0.1;
    }
	
	
	// 1 unité de temps s'écoule dans la ville
	
    public void FixedUpdate ()
    {
		// Immobilier
		habitantsDedans = capaciteLogement;
		
		// Production de ressources
		acier += habitantsAcier;
		beton += habitantsBeton * 4;
		bois  += habitantsBois * 10;
		nourritureProduction = habitantsNourriture * 10;
		nourriture += nourritureProduction;
		
		// Consommation de ressources
		nourritureConsommation = habitants ();
		nourriture -= nourritureConsommation;
		
		// Collecte des impôts
        argent += (int) (tauxImpots * habitants ());
		
		// Intérêts
		argent += (int) (argent * 0.001);
		
		// Naissances
		habitantsChomage += (int) (habitants () * 0.001);
		
		// Immigration
		if (satisfaction > 1)
		{
			habitantsChomage += (int) (satisfaction * 100 - 100);
		}
		
		// Culture
		habitantsCultives = Math. Min (capaciteCulture, habitants ());
		
		
		// Activités
		
		satisfaction = (3 * satisfaction + satisfactionLimite) / 4;
		
		satisfactionChomage = -0.4 * habitantsChomage / habitants ();
		
		satisfactionCulture = habitantsCultives / habitants ();
		
		if (tauxImpots == 0.5)
		{
			satisfactionImpots = -0.35;
		}
		else
		{
			double a = 0.5 - tauxImpots;
			double b = Math. Abs (a);
			satisfactionImpots = 0.5 * a / Math. Sqrt (b) - 0.35;
		}
		
		satisfactionLogement = 0.5 * Math. Pow (habitantsDedans / habitants (), 2) - 0.5;
		
		if (nourriture > 0)
		{
			satisfactionNourriture = 0;
		}
		else
		{
			double tauxFamine = 1 - nourritureProduction / nourritureConsommation;
			satisfactionNourriture = Math. Pow (1 - 2 * tauxFamine, 3) - 1;
		}
		
		satisfactionLimite = 1
			+ satisfactionChomage
			+ satisfactionCulture
			+ satisfactionImpots
			+ satisfactionLogement
			+ satisfactionNourriture
		;
		
		
		// Retour console
		this. affichage ();

		// Mise à jour des textes pour les ressources
		changerTexte (argentText, argent);
		changerTexte (nourritureText, nourriture);
		changerTexte (boisText, bois);
		changerTexte (betonText, beton);
		changerTexte (acierText, acier);
		changerTexte (habitantsText, habitants ());
		if (satisfactionSlider != null)
			satisfactionSlider. value = (float) satisfaction / 2;


		if (satisfaction < 0)
			Application.Quit();
	}
	
	
	// Recalcule et renvoie le nombre d'habitants
	
	public static int habitants ()
	{
		return
			habitantsAcier
			+ habitantsBeton
			+ habitantsBois
			+ habitantsChomage
			+ habitantsConstruction
			+ habitantsNourriture
		;
	}
	
	
	// Recalcule et renvoie le nombre d'habitants qui sont sans abri
	
	private static int habitantsDehors ()
	{
		return
			habitants ()
			- habitantsDedans
		;
	}
	
	
	// Vérifie si un taux donné est compris entre 0 et 1
	
	private static void verifier (double taux)
	{
		if (taux < 0 || 1 < taux)
		{
			Debug. LogError ("Taux = " + taux);
			Application. Quit ();
		}
	}
	
	
	// Affiche les informations intéressantes dans la console
	
	private void affichage ()
	{
		if (bavard)
		{
			Debug. Log
			(
				"- Économie -"
				+ "\nHabitants : " + habitants ()
				+ "\nHabitants sans abri : " + habitantsDehors ()
				+ "\nHabitants chômeurs : " + habitantsChomage
				+ "\nArgent : " + argent
				+ "\nNourriture : " + nourriture
				+ "\nBois : " + bois
				+ "\nBéton : " + beton
				+ "\nAcier : " + acier
				+ "\nSatisfaction : " + satisfaction
				+ "\nSatisfaction cible: " + satisfactionLimite
			);
		}
	}
	
	
	// Met à jour les valeurs dans l'interface
	
	private static void changerTexte (TextMeshProUGUI zoneTexte, int valeur)
	{
		if (zoneTexte != null)
			zoneTexte. text = valeur. ToString ();
	}


}
