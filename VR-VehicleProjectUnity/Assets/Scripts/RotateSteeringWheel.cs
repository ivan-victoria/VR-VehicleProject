using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSteeringWheel : MonoBehaviour
{
    LogitechGSDK.LogiControllerPropertiesData properties;

    private string actualState;
    public float xAxis, xPedal, yPedal, zPedal, GasInput;
    public float xAxisDegree;

    public int damperForce = 40;
    public int constantForcee, bumpyRoadEffect, dirtRoadEffect, frontalCollisionForce, sideCollisionForce, slipperyRoadEffect;
    public bool carAirborne;

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
        if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
        {
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(0);

            xAxis = rec.lX;
            xAxisDegree = (xAxis / 364)*(-1);
            // 90* -32768

            //  90*  + 32767
            //364 = 1*
          
            //transform.rotation = Quaternion.Euler(0, 0, xAxisDegree);
            transform.localEulerAngles = new Vector3(0, 0, xAxisDegree);
            properties.forceEnable = true;
            
            LogitechGSDK.LogiPlayDamperForce(0, damperForce);
            /*
            LogitechGSDK.LogiPlayConstantForce(0, constantForcee);
            LogitechGSDK.LogiPlayBumpyRoadEffect(0, bumpyRoadEffect);
            if (carAirborne) { LogitechGSDK.LogiPlayCarAirborne(0); }
            LogitechGSDK.LogiPlayDirtRoadEffect(0, dirtRoadEffect);
            LogitechGSDK.LogiPlayFrontalCollisionForce(0, frontalCollisionForce);
            LogitechGSDK.LogiPlaySideCollisionForce(0, sideCollisionForce);
            LogitechGSDK.LogiPlaySlipperyRoadEffect(0, slipperyRoadEffect);
            */
}

        
    }
}
