using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    [SerializeField] GameObject[] CoreBuildings;
    [SerializeField] GameObject[] VUI;
    [SerializeField] PMovement PM;
    [SerializeField] Text Ptxt;
    string sceneName;
    Scene m_Scene;
    [SerializeField] Stage2data S2D;
    [SerializeField] Stage1data S1D;
    AudioSource Sound;

    // Start is called before the first frame update
    void Start()
    {
        CoreBuildings = GameObject.FindGameObjectsWithTag("CoreBuilding");
        VUI = GameObject.FindGameObjectsWithTag("VUI");
        for (int i = 0; i < VUI.Length; i++)
        {
            VUI[i].SetActive(false);
        }
        PM = FindObjectOfType<PMovement>();
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(!CoreBuildings[0].activeInHierarchy && !CoreBuildings[1].activeInHierarchy && !CoreBuildings[2].activeInHierarchy)
        {
            for (int i = 0; i < VUI.Length; i++)
            {
                VUI[i].SetActive(true);
                Ptxt.text = PM.PointText.text;
                if (!Sound.isPlaying)
                {
                    Sound.Play();
                }
                
            }
        }

        if(sceneName == "Stage2_Ground")
        {
            S2D.S2Points = Ptxt.text;
        }
        if(sceneName == "Stage1_Space")
        {
            S1D.S1Points = Ptxt.text;
        }
    }
}
