using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    [SerializeField] GameObject[] CoreBuildings;
    [SerializeField] GameObject[] VUI;
    [SerializeField] PMovement PM;
    [SerializeField] Text Ptxt;

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
            }
        }
    }
}
