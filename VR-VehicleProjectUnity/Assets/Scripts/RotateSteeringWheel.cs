using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSteeringWheel : MonoBehaviour
{
    LogitechGSDK.LogiControllerPropertiesData properties;

    private string actualState;
    public float xAxis, xPedal, yPedal, zPedal, GasInput;
    public float xAxisDegree;

    void Start()
    {
        Debug.Log("SteeringInit:" + LogitechGSDK.LogiSteeringInitialize(false));
    }

    void OnApplicationQuit()
    {
        Debug.Log("SteeringShutdown:" + LogitechGSDK.LogiSteeringShutdown());
    }

    void Update()
    {
        if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(1))
        {
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(1);

            xAxis = rec.lX;
            xAxisDegree = (xAxis / 364)*(-1);
            // 90* -32768

            //  90*  + 32767
            //364 = 1*
          
            //transform.rotation = Quaternion.Euler(0, 0, xAxisDegree);
            transform.localEulerAngles = new Vector3(0, 0, xAxisDegree);
            properties.forceEnable = true;
            //LogitechGSDK.LogiPlayConstantForce(0, 0);
            LogitechGSDK.LogiPlayDamperForce(0, 40);

        }

        
    }
}
