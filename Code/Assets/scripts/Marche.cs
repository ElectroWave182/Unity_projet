using System;
using UnityEngine;

public class Marche : MonoBehaviour
{
    // Champs privés pour stocker les taux
    private static double tauxAcier = 1;
    private static double tauxBeton = 4;
    private static double tauxBois = 10;
    private static double tauxNourriture = 10;

    // Propriétés publiques pour accéder aux taux
    public static double TauxAcier => tauxAcier;
    public static double TauxBeton => tauxBeton;
    public static double TauxBois => tauxBois;
    public static double TauxNourriture => tauxNourriture;

    // Fonctions d'achat/vente (inchangées)
    public static void Transaction(string ressource, int quantite)
    {
        switch (ressource.ToLower())
        {
            case "acier":
                Economie.argent -= quantite;
                Economie.acier += (int)(quantite * tauxAcier);
                tauxAcier -= quantite * tauxAcier / Math.Pow(10, 5);
                break;

            case "beton":
                Economie.argent -= quantite;
                Economie.beton += (int)(quantite * tauxBeton);
                tauxBeton -= quantite * tauxBeton / Math.Pow(10, 5);
                break;

            case "bois":
                Economie.argent -= quantite;
                Economie.bois += (int)(quantite * tauxBois);
                tauxBois -= quantite * tauxBois / Math.Pow(10, 5);
                break;

            case "nourriture":
                Economie.argent -= quantite;
                Economie.nourriture += (int)(quantite * tauxNourriture);
                tauxNourriture -= quantite * tauxNourriture / Math.Pow(10, 5);
                break;

            default:
                Debug.LogError($"Ressource '{ressource}' inconnue.");
                break;
        }
    }
}
