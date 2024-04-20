using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftUserControls : MonoBehaviour
{
        // these max angles are only used on mobile, due to the way pitch and roll input are handled
        public float maxRollAngle = 80;
        public float maxPitchAngle = 80;

        // reference to the aeroplane that we're controlling
        private AircraftControl m_Aeroplane;


        private void Awake()
        {
            // Set up the reference to the aeroplane controller.
            m_Aeroplane = GetComponent<AircraftControl>();
        }


        private void FixedUpdate()
        {
            // Read input for the pitch, yaw, roll and throttle of the aeroplane.
            float roll = Input.GetAxis("Horizontal");
            float pitch = Input.GetAxis("Vertical");
            bool airBrakes = Input.GetButton("Fire1");

            // auto throttle up, or down if braking.
            float throttle = airBrakes ? -1 : 1;

            // Pass the input to the aeroplane
            m_Aeroplane.Move(roll, pitch, 0, throttle, airBrakes);
        }

}

