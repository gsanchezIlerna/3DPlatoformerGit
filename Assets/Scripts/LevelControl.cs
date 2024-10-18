using UnityEngine;

public class LevelControl : MonoBehaviour
{

    public GameObject[] Pylon;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivatePylon(int pylon_ID) 
    {
        Debug.Log("Pilon activdao!");
    }

    void win() 
    {
        Debug.Log("has ganado!");
    }
}
