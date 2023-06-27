using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : movement
{
    public InputSys InputSys;
    Transform modelTrs=null;

    
    private void Awake()
    {
        InputSys = new InputSys();
        InputSys.Enable();
        InputSys.player.Enable();
        InputSys.player.move.performed += Move_performed;
        InputSys.player.move.started += Move_started;
        InputSys.player.move.canceled += Move_canceled;
        modelTrs = transform;
    }

    private void Move_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        dir=Vector3.zero;
        Debug.Log("cancelMove");
    }

    private void Move_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("moving");
    }

    private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        var movedir=obj.ReadValue<Vector2>();
        //Debug.Log(movedir);
        dir=(Camera.main.transform.rotation*(new Vector3(movedir.x,0,movedir.y))).ProjectOntoPlane(Vector3.up).normalized;
    }

    void Rolling()
    {
        if (modelTrs == null) { return; }

    }
    private void OnDestroy()
    {
        InputSys.Disable();
        InputSys.player.Disable();
    }

}
