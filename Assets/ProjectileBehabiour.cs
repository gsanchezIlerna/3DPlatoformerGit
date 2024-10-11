using UnityEngine;

public class ProjectileBehabiour : MonoBehaviour
{
    public GameObject playerPositon;
    Rigidbody rb;

    Vector3 direccionDisparo;
    float fuerzaDisparo = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPositon = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    void Awake() 
    {     
        direccionDisparo = transform.position - playerPositon.transform.position;
        direccionDisparo.Normalize();
        direccionDisparo = direccionDisparo * fuerzaDisparo;
    }

    // Update is called once per frame
    void Update()
    {   
        rb.AddForce(direccionDisparo, ForceMode.Impulse);
    }
}
