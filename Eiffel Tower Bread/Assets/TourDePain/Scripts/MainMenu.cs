using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject levelSelectMenu;
    public GameObject baseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        levelSelectMenu.SetActive(false); 
        baseMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void switchToLevelSelect()
    {
        levelSelectMenu.SetActive(true);
        baseMenu.SetActive(false);
    }
    public void switchToBaseMenu()
    {
        levelSelectMenu.SetActive(false);
        baseMenu.SetActive(true);
    }
}
