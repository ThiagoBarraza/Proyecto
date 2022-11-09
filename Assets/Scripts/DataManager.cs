using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    [SerializeField] Stage2data S2D;
    [SerializeField] Stage1data S1D;
    [SerializeField] MenuData MND;
    [SerializeField] Text TS1D;
    [SerializeField] Text TS2D;
    [SerializeField] int S1DUIP;
    [SerializeField] int S2DUIP;


    // Start is called before the first frame update
    void Start()
    {
        TS1D.text = "" + S1D.S1Points;
        TS2D.text = "" + S2D.S2Points;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
