using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShakeScript : MonoBehaviour
{
    private CinemachineVirtualCamera CVM;
    //private float shakeIntensity = 1f;
    //private float shakeTime = 0.2f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin cinemachineBMCP;

    private void Awake()
    {
        CVM = GetComponent<CinemachineVirtualCamera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StopShake();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                StopShake();
            }
        }
    }

    public void StartShake(float shakeIntensity, float shakeTime)
    {
        if (timer <= 0)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBMCP = CVM.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachineBMCP.m_AmplitudeGain = shakeIntensity;
            timer = shakeTime;
        }
        
    }

    public void StopShake()
    {
        CinemachineBasicMultiChannelPerlin cinemachineBMCP = CVM.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBMCP.m_AmplitudeGain = 0f;
        timer = 0;
    }
}
