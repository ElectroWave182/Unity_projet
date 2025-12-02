using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    public GameObject residenceTab;
    public GameObject factoryTab;
    public GameObject commercialTab;
    public GameObject cultureTab;

    public Button residenceButton;
    public Button factoryButton;
    public Button commercialButton;
    public Button cultureButton;

    public Color activeColor = new Color(0.7f, 0.7f, 0.7f, 1f); 
    public Color normalColor = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenResidenceTab()
    {
        CloseAllTabs();
        if (residenceTab != null) residenceTab.SetActive(true);
        HighlightButton(residenceButton);
    }

    public void OpenFactoryTab()
    {
        CloseAllTabs();
        if (factoryTab != null) factoryTab.SetActive(true);
        HighlightButton(factoryButton);
    }
    public void OpenCommercialTab()
    {
        CloseAllTabs();
        if (commercialTab != null) commercialTab.SetActive(true);
        HighlightButton(commercialButton);
    }

    public void OpenCultureTab()
    {
        CloseAllTabs();
        if (cultureTab != null) cultureTab.SetActive(true);
        HighlightButton(cultureButton);
    }

   private void CloseAllTabs()
    {
        if (residenceTab != null) residenceTab.SetActive(false);
        if (factoryTab != null) factoryTab.SetActive(false);
        if (commercialTab != null) commercialTab.SetActive(false);
        if (cultureTab != null) cultureTab.SetActive(false);

        
    }



    private void HighlightButton(Button button)
    {
        // Réinitialise la couleur de tous les boutons
        ResetAllButtonColors();

        // Applique la couleur active au bouton sélectionné
        if (button != null)
        {
            RawImage buttonRawImage = button.GetComponent<RawImage>();
            if (buttonRawImage != null)
            {
                buttonRawImage.color = activeColor; // Applique la couleur active
            }
        }
    }

    private void ResetAllButtonColors()
    {
        // Réinitialise la couleur de tous les boutons à la couleur normale
        ResetButtonColor(residenceButton);
        ResetButtonColor(factoryButton);
        ResetButtonColor(commercialButton);
        ResetButtonColor(cultureButton);
    }

    private void ResetButtonColor(Button button)
    {
        if (button != null)
        {
            RawImage buttonRawImage = button.GetComponent<RawImage>();
            if (buttonRawImage != null)
            {
                buttonRawImage.color = normalColor;  // Remet la couleur normale
            }
        }
    }


}
