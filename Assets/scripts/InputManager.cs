using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;
using UnityEngine.InputSystem.DualShock;

public class InputManager : MonoBehaviour
{
    public List<GameObject> instancePos = new List<GameObject>();
    public Dictionary<InputDevice,GameObject> ControllerInstances = new Dictionary<InputDevice, GameObject>();
    public GameObject ControllerPrefab;
    public PlayerInputManager inputMan;

    // Start is called before the first frame update
    public void Awake()
    {
        InputSystem.onDeviceChange +=
        (device, change) => OnDeviceChange(device, change);

        Debug.Log(InputSystem.devices);

        //for (int i = 0; i < Gamepad.all.Count;i++)
        //{
        //    OnControllerAdd(Gamepad.all[i].device);
        //}
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            //case InputDeviceChange.Enabled:
            case InputDeviceChange.Added:
                if(!ControllerInstances.ContainsKey(device))
                {
                    OnControllerAdd(device);
                }
                break;
            case InputDeviceChange.Disconnected:
                // Device got unplugged.
                break;
            case InputDeviceChange.Reconnected:
                // Plugged back in.
                break;
            case InputDeviceChange.Removed:
                // Remove from Input System entirely; by default, Devices stay in the system once discovered.
                break;
            default:
                // See InputDeviceChange reference for other event types.
                break;
        }
    }

    public void OnControllerAdd(InputDevice ctx)
    {
        Debug.Log(ctx.device.name);

        GameObject bufferObj = Instantiate(ControllerPrefab,this.transform);
        ControllerInstances.Add(ctx,bufferObj);
        int index = ControllerInstances.Count-1;
        bufferObj.transform.SetPositionAndRotation(new Vector3(instancePos[index].transform.position.x, instancePos[index].transform.position.y, instancePos[index].transform.position.z), Quaternion.identity);
        bufferObj.transform.localScale.Set(1, 1, 1);
    }


    public void OnControllerRemove()
    {

    }
}
