using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yaell {
    public class Container : MonoBehaviour
    {
        [Header("Resources")]
        private Animator containerAnimator;
        public GameObject ingredientInContainer;
        public Pickup script;
        private Transform t;

        [Header("Settings")]
        public string openContainer = "Open Container";


        //Zoek een meer elegante oplossing om die transformhand te pakken.
        public void Start()
        {
            t = script.transformHand;
        }

        public void OnContainerOpened()
        {
            
            GameObject newingriedient = Instantiate(ingredientInContainer, t.position, t.rotation);
            newingriedient.GetComponent<Rigidbody>().useGravity = false;
            newingriedient.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            newingriedient.GetComponent<Pickup>().transformHand = t;
            newingriedient.GetComponent<Pickup>().objectInHands = newingriedient;
            newingriedient.GetComponent<Pickup>().objectInHands.transform.SetParent(t);
        }
    }
}