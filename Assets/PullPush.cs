using UnityEngine;

public class PullPush : MonoBehaviour
{
    public Transform playerPosition;
    Rigidbody rb;
    public float fuerzaEmpuje;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Pull()
    {
        Vector3 directionEmpuje = transform.position-playerPosition.position;
        directionEmpuje.Normalize();
        directionEmpuje = directionEmpuje * fuerzaEmpuje;
        rb.AddForce(directionEmpuje , ForceMode.Impulse);
    }
    public void Push()
    {
        Vector3 directionEmpuje = transform.position - playerPosition.position;
        directionEmpuje.Normalize();
        directionEmpuje = directionEmpuje * fuerzaEmpuje;
        rb.AddForce(-directionEmpuje, ForceMode.Impulse);
    }
}
