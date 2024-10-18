using System.Collections;
using UnityEngine;

public class ProjectileBehabiour : MonoBehaviour
{
    public GameObject player;
    Rigidbody rb;

    Vector3 direccionDisparo;
    float fuerzaDisparo = 1;
    float projectileLifeTime = 3;

    PlayerActions playerActions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();

        direccionDisparo = transform.position - player.transform.position;
        direccionDisparo.Normalize();

        direccionDisparo = direccionDisparo * fuerzaDisparo;
        
        StartCoroutine(BulletLife());
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(direccionDisparo, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Movable"))
        {
            PlayerActions playerActions = player.GetComponent<PlayerActions>();
            playerActions.SetPulleableObject(collision.gameObject);
        }
    }

    IEnumerator BulletLife()
    {
        yield return new WaitForSeconds(projectileLifeTime);
        Destroy(gameObject);
    }
}
