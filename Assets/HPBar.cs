using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Image Display;

    public PMovement PM;

    // Start is called before the first frame update
    void Start()
    {
        Display = GetComponent<Image>();
        GameObject player = GameObject.FindWithTag("Player");
        PM = GameObject.FindObjectOfType<PMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Display.fillAmount = PM.ActualHP / PM.MaxHP;
    }
}
