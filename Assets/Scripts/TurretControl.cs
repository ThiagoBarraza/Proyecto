using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    public GameObject Turret;
    public GameObject Player;
    public Transform BulletSpawn1 = null;
    public Transform BulletSpawn2 = null;
    public GameObject Bullet;
    public float RTime;
    float CRTime;
    public float Innacuracy;
    bool CanShoot = true;
    //GameObject Foundation;
    bool OnRange = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //Foundation = Turret.transform.Find("Foundation").gameObject;
        CRTime = RTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (OnRange == true)
        {
            Vector3 lookPos = Player.transform.position - transform.position;
            Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
            float eulerY = lookRot.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, eulerY, 0);
            Turret.transform.rotation = rotation;

            if (CRTime > 0)
            {
                CRTime -= Time.deltaTime;
            }
            if (CRTime <= 0)
            {
                var b = Instantiate(Bullet, BulletSpawn1.position, BulletSpawn1.rotation);
                var c = Instantiate(Bullet, BulletSpawn2.position, BulletSpawn2.rotation);
                b.transform.eulerAngles += new Vector3(Random.Range(-Innacuracy, Innacuracy), Random.Range(-Innacuracy, Innacuracy), Random.Range(-Innacuracy, Innacuracy));
                c.transform.eulerAngles += new Vector3(Random.Range(-Innacuracy, Innacuracy), Random.Range(-Innacuracy, Innacuracy), Random.Range(-Innacuracy, Innacuracy));
                CRTime = RTime;
                CRTime = RTime;
                Debug.Log("Shot");
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            OnRange = true;
            Debug.Log("Player is on range");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            OnRange = false;
        }
    }
}
