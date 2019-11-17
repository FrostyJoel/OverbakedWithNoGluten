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


        //Zoek een meer elegante oplossing om die transform te pakken. Nu moet je persee de script in de scene zetten.
        public void Start()
        {
            t = script.transformHand;
        }

        //Maak een empty GameObject in de Player aan genaamed "ParentHolder". De gespawnde object gebruikt deze coördinaten. 
        // Moet nog wel dit transleren dat de input ook de spul pakt.

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