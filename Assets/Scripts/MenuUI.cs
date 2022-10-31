using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] GameObject[] UIElements;
    [SerializeField] GameObject[] LSUI; //Level Selector UI
    [SerializeField] GameObject[] OMUI; //Options Menu UI
    [SerializeField] GameObject[] CSUI; //Credits UI
    //[SerializeField] GameObject[] SettingsUI;
    
    
    // Start is called before the first frame update
    void Start()
    {
        UIElements = GameObject.FindGameObjectsWithTag("MenuUI");
        LSUI = GameObject.FindGameObjectsWithTag("LSUI");
        OMUI = GameObject.FindGameObjectsWithTag("OMUI");
        CSUI = GameObject.FindGameObjectsWithTag("CSUI");
        for(int i = 0; i < LSUI.Length; i++)
        {
            LSUI[i].SetActive(false);
        }

        for (int i = 0; i < OMUI.Length; i++)
        {
            OMUI[i].SetActive(false);
        }
        for (int i = 0; i < CSUI.Length; i++)
        {
            CSUI[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    public void OpenLevelSelector(bool state)
    {
        for(int i = 0; i < UIElements.Length; i++)
        {
            UIElements[i].SetActive(state);
        }
        for(int i = 0; i < LSUI.Length; i++)
        {
            LSUI[i].SetActive(!state);
        }
        for (int i = 0; i < CSUI.Length; i++)
        {
            CSUI[i].SetActive(false);
        }
    }

    public void OpenOptionsMenu(bool state)
    {
        for (int i = 0; i < UIElements.Length; i++)
        {
            UIElements[i].SetActive(state);
        }
        for (int i = 0; i < OMUI.Length; i++)
        {
            OMUI[i].SetActive(!state);
        }
        for (int i = 0; i < CSUI.Length; i++)
        {
            CSUI[i].SetActive(false);
        }
    }

    public void OpenCredits(bool state)
    {
        for (int i = 0; i < CSUI.Length; i++)
        {
            CSUI[i].SetActive(!state);
        }
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
