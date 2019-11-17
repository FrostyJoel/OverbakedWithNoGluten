using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yaell;

    public class EindStation : MonoBehaviour
    {
        [Header("Resources")]
        private Collision c;
        private OrderManager orderManagerScript;

        [Header("Settings")]
        public RecipeBase endBaseRecipe;
    public float timeStamp;


        public void OnCollisionEnter(Collision col)
        {
            if (col.transform.tag == "Carryable")
            {
                Invoke("Checker", 0.5f);
            c = col;
            
            }

            else if(col.transform.tag == "Unusable")
            {
                //Display een popup ofzo iets.
            }
        }

        //Wanneer tijd nul of lager is, kan je het niet meer gebruiken behalve weggooien.

        public void Checker()
        {
            if (c.transform.GetComponent<Pickup>().baseRecipe == endBaseRecipe && timer > 0)
            {
                Destroy(c.gameObject);
                //Addscore
            }

            else
            {
                // Display iets of doe iets.
            }
        }
    }

