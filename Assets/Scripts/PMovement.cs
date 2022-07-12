using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    public float ZSpeed;
    public float XSpeed;
    public float RSpeed;
    public int maxJumps;
    public float JumpForce;
    //public CollisionTest ColT;
    public int hasJump;
    public bool Salto = false;
    public int vidas;
    public int NroVidas;
    Rigidbody rb;
    int Amongquantity = 0;

    //Resources

    public GameObject Amogus1;
    public GameObject Amogus2;
    public GameObject Amogus3;

    // Start is called before the first frame update
    void Start()
    {
        hasJump = maxJumps;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, ZSpeed * .2f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -ZSpeed * .1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(XSpeed * .1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-XSpeed * .1f, 0, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, RSpeed, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -RSpeed, 0);
        }

        if (Input.GetKey(KeyCode.Space) && hasJump > 0)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            hasJump--;
        }

        
    }
    void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.tag == "Ground")
        {
            hasJump = maxJumps;
        }

        if (col.gameObject.name == "DeathWall")
        {
            vidas--;
        }
    }

    void OnCollisionExit()
    {

        Salto = false;
    }

    void OnCollisionStay(Collision col)
    {
        Salto = true;

        if (col.gameObject.name == "Among_Cube-1")
        {
            Destroy(Amogus1);
            Amongquantity++;
            Debug.Log("Amongcube Achieved");
        }

        if (col.gameObject.name == "Among_Cube-2")
        {
            Destroy(Amogus2);
            Amongquantity++;
            Debug.Log("Amongcube Achieved");
        }

        if (col.gameObject.name == "Among_Cube-3")
        {
            Destroy(Amogus3);
            Amongquantity++;
            Debug.Log("Amongcube Achieved");
        }
    }
}
