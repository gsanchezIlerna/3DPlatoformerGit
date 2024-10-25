using System;
using UnityEngine;

public class ShrinkGrow : MonoBehaviour
{

    float scaleSpeed = 0.3f;
    float minScale = 0.5f;
    float maxScale = 2.0f;

    Vector3 originalScale;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            Shrink();
        if (Input.GetKey(KeyCode.E))
            Grow();
        
    }

    private void Grow()
    {
        Vector3 newScale = transform.localScale + Vector3.one * scaleSpeed * Time.deltaTime;
        newScale = Vector3.Max(newScale, Vector3.one * maxScale);
        transform.localScale = newScale;
    }

    private void Shrink()
    {
        Vector3 newScale = transform.localScale + Vector3.one * scaleSpeed * Time.deltaTime;
        newScale = Vector3.Min(newScale, Vector3.one * minScale);
        transform.localScale = newScale;
    }
}
