using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ControllerManager : MonoBehaviour
{
    public GameObject Label;

    public GameObject rightJoy;
    public GameObject leftJoy;

    public GameObject aBut;
    public GameObject bBut;
    public GameObject xBut;
    public GameObject yBut;

    public GameObject upD;
    public GameObject downD;
    public GameObject leftD;
    public GameObject rightD;

    public GameObject calibration;


    void Start()
    {
        Label.GetComponent<TMPro.TextMeshProUGUI>().text = this.GetComponent<PlayerInput>().GetDevice<InputDevice>().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //public void SetJoystickRight(InputAction.CallbackContext ctx)
    //{
    //    Debug.Log(ctx);
    //    GameObject target = null;
    //    switch(ctx.action.name)
    //    {
    //        default:
    //            break;
    //        case "leftJoystick":
    //            target = leftJoy;
    //            break;
    //        case "rightJoystick":
    //            target = rightJoy;
    //            break;
    //        case "Dpad":
    //            Vector2 pad = ctx.ReadValue<Vector2>();
    //            if (pad.x > 0)
    //            {
    //                rightD.GetComponent<TMPro.TextMeshProUGUI>().color = Color.red;
    //            }
    //            else
    //            {
    //                rightD.GetComponent<TMPro.TextMeshProUGUI>().color = Color.black;
    //            }
    //            if (pad.x < 0)
    //            {
    //                leftD.GetComponent<TMPro.TextMeshProUGUI>().color = Color.red;
    //            }
    //            else
    //            {
    //                leftD.GetComponent<TMPro.TextMeshProUGUI>().color = Color.black;
    //            }
    //            if (pad.y > 0)
    //            {
    //                upD.GetComponent<TMPro.TextMeshProUGUI>().color = Color.red;
    //            }
    //            else
    //            {
    //                upD.GetComponent<TMPro.TextMeshProUGUI>().color = Color.black;
    //            }
    //            if (pad.y < 0)
    //            {
    //                downD.GetComponent<TMPro.TextMeshProUGUI>().color = Color.red;
    //            }
    //            else
    //            {
    //                downD.GetComponent<TMPro.TextMeshProUGUI>().color = Color.black;
    //            }
    //            //all the above is just for Emerret's indicator

    //            return;
    //            break;
    //    }
    //    if (target == null)
    //    {
    //        return;
    //    }

    //    Vector2 val = ctx.ReadValue<Vector2>();
    //    Vector3 newPos = new Vector3(val.x * 50, val.y * 50, 0);
    //    target.transform.localPosition = newPos;
    //}


    //make individual functions for these
    public void PushAButton(InputAction.CallbackContext ctx)
    {
        GameObject target = null;
        Debug.Log(ctx); switch (ctx.action.name)
        {
            //dont need any of this when i make new function
            //delete all swtich cases
            default:
                break;
            case "A button":
                target = aBut;
                break;
            case "B button":
                target = bBut;
                break;
            case "X button":
                target = xBut;
                break;
            case "Y button":
                target = yBut;
                break;
        }

        switch(ctx.phase)
        {
            case InputActionPhase.Started:
                //target.GetComponent<TMPro.TextMeshProUGUI>().color = Color.yellow;
                break;
            case InputActionPhase.Performed:
                //target.GetComponent<TMPro.TextMeshProUGUI>().color = Color.red;
                break;
            case InputActionPhase.Canceled:
                //target.GetComponent<TMPro.TextMeshProUGUI>().color = Color.black;
                break;
        }

       
    }

    public void SetJoystickLeft(InputAction.CallbackContext ctx)
    {
        Vector2 val = ctx.ReadValue<Vector2>();
    }

    public void SendToConsole(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx);
    }

    public void NewFunctionTest()
    {
        Debug.Log("fuck");
    }

    //this will be how to switch action map for calibration
    public void ActionMapSwitcher()
    {
        PlayerInput thisInputScript = this.GetComponent<PlayerInput>();
        thisInputScript.SwitchCurrentActionMap("StandardInputs1");
    }

    public void Calibrate(InputAction.CallbackContext ctx)
    {
        //once calibrationmanager script is made. on runtime. have a function: each time it's called maps a different action map. don't use update, use start.
        //calibration.GetComponent<CalibrationManager>();

        //return function
        //PlayerInput thisInputScript = this.GetComponent<PlayerInput>(); //gets this script's PlayerInput
        //string targetMap = calibration.GetComponent<CalibrationManager>().callCalibrate();  //calls CalibrationManager's calibrate script, returns string of the action map to change to
        //thisInputScript.SwitchCurrentActionMap(targetMap);    // sets current action map to target
    }
}
