using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Defeat : MonoBehaviour
{
    [SerializeField] PMovement PM;
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject[] DFUI;
    [SerializeField] Pause PS;
    
    // Start is called before the first frame update
    void Start()
    {
        DFUI = GameObject.FindGameObjectsWithTag("DFUI");
        PM = FindObjectOfType<PMovement>();
        PS = FindObjectOfType<Pause>();
        Player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < DFUI.Length; i++)
        {
            DFUI[i].SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PM.Defeated == true)
        {
            Camera.transform.parent = null;
            Destroy(Player);
            for (int i = 0; i < DFUI.Length; i++)
            {
                DFUI[i].SetActive(true);
            }
        }
    }

    public void RestartRun()
    {
        PS.gameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        PS.gameIsPaused = false;
        SceneManager.LoadScene("Menu");
    }
}
