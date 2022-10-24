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
    
    // Start is called before the first frame update
    void Start()
    {
        DFUI = GameObject.FindGameObjectsWithTag("DFUI");
        PM = FindObjectOfType<PMovement>();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
