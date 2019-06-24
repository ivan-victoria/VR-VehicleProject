using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
   
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public float gas;
        public float breakk;
        public Boolean keyboard;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("SteeringWheel");
            float v = CrossPlatformInputManager.GetAxis("GasPedal");
            float f = CrossPlatformInputManager.GetAxis("Footbreak");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Break");

            //if (-(f + 1) < 0) { m_Car.Move(h, v, 0, 0); }

            if (keyboard == false)
            {
                m_Car.Move(h, v, -(f + 1), 0);
            }
            else {
                m_Car.Move(h, v, v, 0);
            }
           
            //   Debug.Log("PedalG:" + v);
            Debug.Log("Pedal:" + f);
            breakk = f;
            gas = v;
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
