using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    public PullPush pull;
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            pull.Push();
        if (Input.GetKeyDown(KeyCode.E))
            pull.Pull();
        if(Input.GetKeyDown(KeyCode.Space))
            Disparo();
    }

    void Disparo() 
    {
       GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
