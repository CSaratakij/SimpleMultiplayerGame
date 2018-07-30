using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : NetworkBehaviour
    /* public class ThirdPersonUserControl : MonoBehaviour */
    {
        ThirdPersonCharacter m_Character;
        Transform m_Cam;

        Vector3 m_CamForward;
        Vector3 m_Move;

        bool m_Jump;


        void Start()
        {
            if (Camera.main != null) {
                m_Cam = Camera.main.transform;
            }
            else {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            }

            m_Character = GetComponent<ThirdPersonCharacter>();
        }


        private void Update()
        {
            if (!isLocalPlayer) { return; }
            if (!m_Jump) {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            if (!isLocalPlayer) { return; }
            bool crouch = Input.GetKey(KeyCode.C);

            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");

            if (m_Cam != null) {
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v*m_CamForward + h*m_Cam.right;
            }
            else {
                m_Move = v * Vector3.forward + h * Vector3.right;
            }
#if !MOBILE_INPUT
	        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
