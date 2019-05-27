using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogitechSteering : MonoBehaviour
{
    LogitechGSDK.LogiControllerPropertiesData properties;

    public float xAxis, GasInput, BreakInput, ClutchInput;
    public int CurrentGear;

    // Start is called before the first frame update
    void Start()
    {
        print(LogitechGSDK.LogiSteeringInitialize(false));

    }

    // Update is called once per frame
    void Update()
    {
        if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
        {
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(0);

            xAxis = rec.lX;
        }
        else
        {
            print("No steering wheel connected");
        }
    }
}
