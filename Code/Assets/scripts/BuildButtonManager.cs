using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButtonManager : MonoBehaviour
{
    public GameObject buildingPrefab;
    public GameObject buildMenu; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBuildButtonClicked()
    {
        if (buildingPrefab != null)
        {
			// Construction de l'instance du bâtiment
            Debug.Log("Bâtiment sélectionné : " + buildingPrefab.name);
			GameObject construction = Instantiate (buildingPrefab);
			construction. transform. SetParent (transform. root. Find ("construction"));
			
			// On cache l'interface du menu
			if (buildMenu != null)
			{
				buildMenu.SetActive(false);
			}

        } else
        {
            Debug.LogWarning("Aucun prefab de bâtiment n'est assigné !");
        }
        
    }
}
