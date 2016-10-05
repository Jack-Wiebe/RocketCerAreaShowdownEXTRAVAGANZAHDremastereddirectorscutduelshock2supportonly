using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


    public class CarUserControl : MonoBehaviour
    {
        private Car_Controller m_Car; // the car controller we want to use 
		private bool m_shooting = false;
		private Car_Shooting_System m_CarWeapon;
		
        private void Awake()
        {
            // get the car controller
			m_CarWeapon = GetComponent<Car_Shooting_System>();
            m_Car = GetComponent<Car_Controller>();
        }


        private void Update()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
			float fire = CrossPlatformInputManager.GetAxis("Shoot");
			//Debug.Log (fire);
			if (fire > 0 && !m_shooting) {
				m_CarWeapon.ShootOn ();
				m_shooting = true;
			}
			else if (fire == 0) {
				m_CarWeapon.ShootOff ();
				m_shooting = false;
			}
#if !MOBILE_INPUT
           // float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v);
#else
            m_Car.Move(h, v, v, 0f);
#endif

        }
    }

