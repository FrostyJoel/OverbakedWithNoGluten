using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yaell
{
    public class Pickup : MonoBehaviour
    {
        [Header("Resources")]
        public Transform transformHand;
        public GameObject objectInHands;
        public RecipeBase baseRecipe;
        public ItemBase dish;

        [Header("Settings")]
        public bool isPickedUp;
        public float objectVelocity = 5f;
        public float timer = 10f;

            private void Update()
            {
                if (timer == 0)
                {
                    return;
                }

                else
                {
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        gameObject.tag = "Unusable";
                    }
                }
            }
        public void OnPickup()
        {
            objectInHands = gameObject;
            objectInHands.transform.SetParent(transformHand);
            objectInHands.GetComponent<Rigidbody>().useGravity = false;
            objectInHands.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            objectInHands.transform.localRotation = transform.rotation;
            objectInHands.transform.position = transform.position;

            isPickedUp = true;
        }

        public void OnDrop()
        {
            objectInHands.GetComponent<Rigidbody>().useGravity = true;
            objectInHands.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            transformHand.GetChild(0).parent = null;
            objectInHands = null;
            isPickedUp = false;
        }

        public void OnThrow()
        {
            objectInHands.GetComponent<Rigidbody>().useGravity = true;
            objectInHands.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            transformHand.GetChild(0).GetComponent<Rigidbody>().velocity = transform.forward * objectVelocity;

            transformHand.GetChild(0).parent = null;
            objectInHands = null;
            isPickedUp = false;
        }
    }
}