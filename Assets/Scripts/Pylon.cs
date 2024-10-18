using Unity.VisualScripting;
using UnityEngine;

public class Pylon : MonoBehaviour
{
    public Material ActivePylon_Mat;
    public Material InactivePylon_Mat;

    Renderer renderer;

    void Start() 
    { 
        renderer = GetComponent<Renderer>();
    }

    void SetActivePylon() 
    {
       renderer.material = ActivePylon_Mat;
    }
    void SetInctivePylon()
    {
        renderer.material = InactivePylon_Mat;
    }
}
