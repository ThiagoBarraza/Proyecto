using UnityEngine;

public class ModelRotation : MonoBehaviour
{
    [SerializeField] GameObject Model;
    [SerializeField] GameObject DebugObj3;

    [SerializeField] float RotationSpeed;
    private Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            DebugObj3.transform.localPosition = new Vector3(10, 0, 0);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            DebugObj3.transform.localPosition = new Vector3(5, 0, 5);
        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            DebugObj3.transform.localPosition = new Vector3(-5, 0, 5);
        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            DebugObj3.transform.localPosition = new Vector3(0, 0, 10);
        }

        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W))
        {
            DebugObj3.transform.localPosition = new Vector3(-10, 0, 0);
        }

        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W))
        {
            DebugObj3.transform.localPosition = new Vector3(-5, 0, -5);
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            DebugObj3.transform.localPosition = new Vector3(0, 0, -10);
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            DebugObj3.transform.localPosition = new Vector3(5, 0, -5);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            Anim.SetBool("IsWalkiing", true);
        }
        else
        {
            Anim.SetBool("IsWalkiing", false);
        }
        var targetPos = DebugObj3.transform.position;
        targetPos.y = Model.transform.position.y;
        var targetDir = Quaternion.LookRotation(targetPos - Model.transform.position);
        Model.transform.rotation = Quaternion.Slerp(Model.transform.rotation, targetDir, RotationSpeed * Time.deltaTime);
    }
}
