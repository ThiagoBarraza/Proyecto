using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] GameObject[] UIElements;
    [SerializeField] GameObject[] LSUI;
    [SerializeField] GameObject[] OMUI;
    //[SerializeField] GameObject[] SettingsUI;
    
    
    // Start is called before the first frame update
    void Start()
    {
        UIElements = GameObject.FindGameObjectsWithTag("MenuUI");
        LSUI = GameObject.FindGameObjectsWithTag("LSUI");
        OMUI = GameObject.FindGameObjectsWithTag("OMUI");
        for(int i = 0; i < LSUI.Length; i++)
        {
            LSUI[i].SetActive(false);
        }

        for (int i = 0; i < OMUI.Length; i++)
        {
            OMUI[i].SetActive(false);
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
    }
}
