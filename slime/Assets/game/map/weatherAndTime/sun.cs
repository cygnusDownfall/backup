using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class sun : MonoBehaviour
{
    public float numTimeInDay;
    public float valueTime;
    public Transform playerTrf;
   // DirectionalLight light;
    public void updateTime()
    {
        valueTime += Time.deltaTime;
        transform.RotateAround(playerTrf.position, new Vector3(1, 0, 1), valueTime *Time.deltaTime / numTimeInDay);
        transform.LookAt(playerTrf.position);
    }
    private void Update()
    {
        updateTime();
    }
}
