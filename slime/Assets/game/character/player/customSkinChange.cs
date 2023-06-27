using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(playerMovement))]
public class customSkinChange : MonoBehaviour
{
    InputAction action;
    CinemachineFreeLook freeLook;
    [SerializeField] Slider red,green, blue,transparent;
    Material material;
    private void Start()
    {
        material = GetComponentInChildren<MeshRenderer>().material;
        action = GetComponent<playerMovement>().InputSys.UI.changeSkin;
        action.started += changeSkin_Started;
        action.canceled += (e) => { Debug.Log(e.duration); };
    }

    private void changeSkin_Started(InputAction.CallbackContext obj)
    {
        toogleSkinChanger();
    }

    public void toogleSkinChanger()
    {
        freeLook.Priority = (freeLook.Priority == 50 )? 0 : 50 ;
    }
    public void changeSkin()
    {
        Color color = new Color(red.value,green.value,blue.value,1-transparent.value);
        material.SetColor("_Color", color);
    }
}
