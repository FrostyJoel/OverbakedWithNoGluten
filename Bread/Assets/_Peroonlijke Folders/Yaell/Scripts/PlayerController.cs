using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yaell
{
    public class PlayerController : MonoBehaviour
    {

        [Header("Resources")]
        public float horizontal;
        public float vertical;
        public float moveSpeed;
        public float runSpeed = 8f;
        public float walkSpeed = 5f;

        public Vector3 position;
        public Vector3 jumpPower;
        public Vector3 rotateX;
        public Vector3 rotateY;

        public Camera firstPersonCam;
        public float sensitivityHorizontal = 10f;
        public float sensitivityVertical = 10f;
        public float maxAngle = 90f;
        public float minAngle = -40f;

        public RaycastHit hit;
        public float range;

        public void Start()
        {
            moveSpeed = walkSpeed;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Update()
        {
            Movement();
            Interaction();
        }

        public void Movement()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            rotateX.x += Input.GetAxis("Mouse Y");
            rotateY.y += Input.GetAxis("Mouse X");

            //  rotateY.y = Mathf.Clamp(rotateY.y, -60f, 60f);
            rotateX.x = Mathf.Clamp(rotateX.x, -50f, 50f);

            position.x = horizontal;
            position.z = vertical;

            firstPersonCam.transform.localRotation = Quaternion.Euler(-rotateX.x, 0f, 0f);
            transform.localRotation = Quaternion.Euler(0f, rotateY.y, 0f);

            transform.Translate(position * moveSpeed * Time.deltaTime);

            if (Input.GetButton("Sprint"))
            {
                moveSpeed = runSpeed;
            }

            else
            {
                moveSpeed = walkSpeed;
            }

        }

        public void Interaction()
        {
            if (Input.GetButtonDown("Interact"))
            {
                if (Physics.Raycast(firstPersonCam.transform.position, firstPersonCam.transform.forward, out hit, range))
                {
                    Debug.DrawRay(firstPersonCam.transform.position, firstPersonCam.transform.forward, Color.red, range);
                    Debug.Log(hit.transform.name);
                }
            }
        }
    }
}
