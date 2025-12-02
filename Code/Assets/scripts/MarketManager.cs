using System;
using UnityEngine;
using TMPro;

public class MarketManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_InputField quantityInputField;  // Champ de saisie pour la quantité
    public TextMeshProUGUI costTextBuy;        // Texte affichant le coût d'achat
    public TextMeshProUGUI costTextSell;       // Texte affichant le coût de vente

    private int quantity; // Quantité saisie par l'utilisateur

    
    /// Initialise les textes au démarrage.
   
    void Start()
    {
        UpdateCostText("acier"); // Affiche les coûts pour l'acier par défaut
    }

   
    /// Met à jour les textes des coûts d'achat et de vente pour une ressource donnée.
  
    /// <param name="ressource">Nom de la ressource (acier, béton, bois, nourriture).</param>
    public void UpdateCostText(string ressource)
    {
        if (string.IsNullOrWhiteSpace(quantityInputField.text) || !int.TryParse(quantityInputField.text, out quantity) || quantity <= 0)
        {
            costTextBuy.text = "Entrez une quantité valide";
            costTextSell.text = "Entrez une quantité valide";
            return;
        }

        decimal taux = GetTaux(ressource);
        if (taux < 0)
        {
            Debug.LogError($"Ressource '{ressource}' inconnue.");
            return;
        }

        decimal costBuy = quantity * taux;
        decimal costSell = quantity * (taux * 0.9m); // Taux de vente = 90% du taux d'achat

        costTextBuy.text = $" {costBuy:F2}";
        costTextSell.text = $" {costSell:F2}";
    }

    
    /// Achète une ressource donnée.
   
    /// <param name="ressource">Nom de la ressource.</param>
    public void Buy(string ressource)
    {
        if (TryParseQuantity(out quantity))
        {
            Marche.Transaction(ressource, quantity);
            UpdateCostText(ressource);
        }
    }

  
    /// Vend une ressource donnée.
   
    /// <param name="ressource">Nom de la ressource.</param>
    public void Sell(string ressource)
    {
        if (TryParseQuantity(out quantity))
        {
            Marche.Transaction(ressource, -quantity);
            UpdateCostText(ressource);
        }
    }

   
    /// Obtient le taux d'une ressource donnée.
   
    /// <param name="ressource">Nom de la ressource.</param>
    
    private decimal GetTaux(string ressource)
    {
        return ressource.ToLower() switch
        {
            "acier" => (decimal)Marche.TauxAcier,
            "beton" => (decimal)Marche.TauxBeton,
            "bois" => (decimal)Marche.TauxBois,
            "nourriture" => (decimal)Marche.TauxNourriture,
            _ => -1
        };
    }

    
    /// Valide et parse la quantité entrée par l'utilisateur.
   
    /// <param name="quantity">Quantité extraite.</param>
    
    private bool TryParseQuantity(out int quantity)
    {
        if (!int.TryParse(quantityInputField.text, out quantity) || quantity <= 0)
        {
            Debug.LogWarning("Quantité invalide ou vide.");
            return false;
        }
        return true;
    }
}
