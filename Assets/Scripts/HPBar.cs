using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Image Display;

    public PMovement PM;
    public MissileHability MH;

    // Start is called before the first frame update
    void Start()
    {
        Display = GetComponent<Image>();
        GameObject player = GameObject.FindWithTag("Player");
        if (PM)
        {
            PM = GameObject.FindObjectOfType<PMovement>();
        }
        else
        {
            MH = GameObject.FindObjectOfType<MissileHability>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PM)
        {
            Display.fillAmount = PM.ActualHP / PM.MaxHP;
        }
        else
        {
            Display.fillAmount = MH.ActualCooldown / MH.Cooldown;
        }
    }
}
