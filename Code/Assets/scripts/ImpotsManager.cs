using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImpotsManager : MonoBehaviour
{

    public TextMeshProUGUI tauxImpotsText; // Affichage du taux d'impôts
    public Button plusButton;         // Bouton pour augmenter
    public Button minusButton;         // Bouton pour diminuer

    private double tauxMin = 0.0;         // Taux minimum d'impôts
    private double tauxMax = 0.5;         // Taux maximum d'impôts
    private double increment = 0.01;      // Pas d'incrément/décrément


    // Start is called before the first frame update
    void Start()
    {
        // Initialiser l'affichage et connecter les boutons
        UpdateTauxImpotsUI();
        plusButton.onClick.AddListener(PlusTauxImpots);
        minusButton.onClick.AddListener(MinusTauxImpots);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlusTauxImpots()
    {
        if (Economie.tauxImpots + increment <= tauxMax)
        {
            Economie.tauxImpots += increment;
            UpdateTauxImpotsUI();
        }
    }

    private void MinusTauxImpots()
    {
        if (Economie.tauxImpots - increment >= tauxMin)
        {
            Economie.tauxImpots -= increment;
            UpdateTauxImpotsUI();
        }
    }

    private void UpdateTauxImpotsUI()
    {
        if (tauxImpotsText != null)
        {
            tauxImpotsText.text = $"{(Economie.tauxImpots * 100):F1}%";
        }
    }
}
