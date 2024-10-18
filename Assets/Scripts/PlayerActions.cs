using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    public PullPush PulleableObject;
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public GameObject aimAssist;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(PulleableObject != null)
                PulleableObject.Push();
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PulleableObject != null)
                PulleableObject.Pull();
        }
        
        if (Input.GetMouseButtonDown(0))
            Disparo();
        if (Input.GetMouseButton(1))
            aimAssist.SetActive(true);
        else aimAssist.SetActive(false);
    }

    void Disparo() 
    {
       GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void SetPulleableObject( GameObject newPuleable) 
    {
        PulleableObject = newPuleable.GetComponent<PullPush>();
    }
}
