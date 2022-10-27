using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public bool gameIsPaused;
    [SerializeField] GameObject[] PSUI;
    public GameObject cubo;

    void Start()
    {
        PSUI = GameObject.FindGameObjectsWithTag("PSUI");

        for (int i = 0; i < PSUI.Length; i++)
        {
            PSUI[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();

            if (gameIsPaused == false)
            {
                for (int i = 0; i < PSUI.Length; i++)
                {
                    PSUI[i].SetActive(false);
                }
            }
        }

        if (gameIsPaused)
        {
            for(int i = 0; i< PSUI.Length; i++)
            {
                PSUI[i].SetActive(true);
            }
        }
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void BackPause()
    {
        for (int i = 0; i < PSUI.Length; i++)
        {
            PSUI[i].SetActive(false);
        }
    }
}
