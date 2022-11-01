using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    public GameObject Turret;
    public Transform Target;
    public Transform BulletSpawn1 = null;
    public Transform BulletSpawn2 = null;
    public GameObject Bullet;
    public float RTime;
    float CRTime;
    public float Innacuracy;
    //bool CanShoot = true;
    //GameObject Foundation;
    bool OnRange = false;
    public float RotationSpeed;
    AudioSource Sound;
    
    // Start is called before the first frame update
    void Start()
    {
        //Foundation = Turret.transform.Find("Foundation").gameObject;
        CRTime = RTime;
        Sound = GetComponent<AudioSource>();
        GameObject player = GameObject.FindWithTag("Player");
        Target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (OnRange == true)
        {

            var targetPos = Target.position;
            targetPos.y = Turret.transform.position.y; 
            var targetDir = Quaternion.LookRotation(targetPos - Turret.transform.position);
            Turret.transform.rotation = Quaternion.Slerp(Turret.transform.rotation, targetDir, RotationSpeed * Time.deltaTime);

            if (CRTime > 0)
            {
                CRTime -= Time.deltaTime;
            }
            if (CRTime <= 0)
            {
                if (Sound)
                {
                    Sound.Play();
                }
                var b = Instantiate(Bullet, BulletSpawn1.position, BulletSpawn1.rotation);
                if (BulletSpawn2)
                {
                    var c = Instantiate(Bullet, BulletSpawn2.position, BulletSpawn2.rotation);
                    c.transform.eulerAngles += new Vector3(Random.Range(-Innacuracy, Innacuracy), Random.Range(-Innacuracy, Innacuracy), Random.Range(-Innacuracy, Innacuracy));
                }
                b.transform.eulerAngles += new Vector3(Random.Range(-Innacuracy, Innacuracy), Random.Range(-Innacuracy, Innacuracy), Random.Range(-Innacuracy, Innacuracy));
                

                CRTime = RTime;
                Debug.Log("Shot");
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            OnRange = true;
            Debug.Log("Player is on range");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            OnRange = false;
        }
    }
}
