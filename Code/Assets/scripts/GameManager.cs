using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI displayText1;
    public TextMeshProUGUI displayText2;

    public GameObject marketMenu;
    public GameObject buildMenu;
    public GameObject impotsMenu;

  
    // Start is called before the first frame update
    void Start()
    {
        string value1 = PlayerPrefs.GetString("InputField1Value", "Default1");
        string value2 = PlayerPrefs.GetString("InputField2Value", "Default2");

        displayText1.text = value1;
        displayText2.text = value2;

        CloseAllMenus();


    }
    public void OpenMarketMenu()
    {
        CloseAllMenus();
		if (Magasin. estPlace)
			marketMenu.SetActive(true);
    }
    public void OpenBuildMenu()
    {
        CloseAllMenus();
        buildMenu.SetActive(true);
    }

    public void OpenImpotsMenu()
    {
        CloseAllMenus();
        impotsMenu.SetActive(true);
    }
    private void CloseAllMenus()
    {
        // Désactive tous les menus
        if (marketMenu != null) marketMenu.SetActive(false);
        if (buildMenu != null) buildMenu.SetActive(false);
        if (impotsMenu != null) impotsMenu.SetActive(false);
    }

    public void CloseMenu(GameObject menu)
    {
        if (menu != null)
        {
            menu.SetActive(false);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

}
