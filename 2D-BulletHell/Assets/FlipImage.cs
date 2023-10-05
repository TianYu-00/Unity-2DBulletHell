using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlipImage : MonoBehaviour
{
    public float flipSpeed = 1f;

    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    void Update()
    {
        float deltaTime = Time.unscaledDeltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), deltaTime * flipSpeed);

    }
}
