using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StatMenuManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject statsPanel;  
    public TextMeshProUGUI cultureText;
    public TextMeshProUGUI chomageText;
    public TextMeshProUGUI impotsText;
    public TextMeshProUGUI logementsText;
    public TextMeshProUGUI nourritureStatText;

    public Slider satisfactionSlider;  // Référence au slider de satisfaction

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStats();
    }

    public void ShowStatMenu()
    {
        statsPanel.SetActive(true);  // Affiche le panel
    }

    // Cache le menu des statistiques
    public void HideStatMenu()
    {
        statsPanel.SetActive(false);  // Cache le panel
    }

    // Gère l'affichage du menu quand la souris entre dans la zone du slider
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter == satisfactionSlider.gameObject)  // Vérifie si le curseur est sur le slider
        {
            ShowStatMenu();  // Affiche le menu
        }
    }

    // Cache le menu des statistiques quand la souris quitte le slider
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter == satisfactionSlider.gameObject)  // Vérifie si la souris quitte le slider
        {
            HideStatMenu();  // Cache le menu
        }
    }

    // Change la couleur du texte en fonction de la valeur
    private void UpdateTextColor(TextMeshProUGUI textComponent, double value)
    {
        // Convertir la valeur en float pour l'affichage
        float satisfactionValue = (float)value;

        if (satisfactionValue <= 0)  // Si la valeur est inférieure ou égale à 0, on met rouge
        {
            textComponent.color = Color.red;
        }
        else if (satisfactionValue >= 1)  // Si la valeur est supérieure ou égale à 100% (1.0), on met vert
        {
            textComponent.color = Color.green;
        }
        else  // Entre 0 et 100%, on met une couleur neutre (par exemple, blanc)
        {
            textComponent.color = Color.white;
        }
    }

    // Mise à jour des statistiques à chaque frame
    public void UpdateStats()
    {
        // Met à jour les statistiques et les couleurs
        double chomageValue = Economie.satisfactionChomage;
        chomageText.text = (chomageValue * 100).ToString("F2") + "%";
        UpdateTextColor(chomageText, chomageValue);

        double impotsValue = Economie.satisfactionImpots;
        impotsText.text = (impotsValue * 100).ToString("F2") + "%";
        UpdateTextColor(impotsText, impotsValue);

        double logementsValue = Economie.satisfactionLogement;
        logementsText.text = (logementsValue * 100).ToString("F2") + "%";
        UpdateTextColor(logementsText, logementsValue);

        double nourritureValue = Economie.satisfactionNourriture;
        nourritureStatText.text = (nourritureValue * 100).ToString("F2") + "%";
        UpdateTextColor(nourritureStatText, nourritureValue);
    }




}
