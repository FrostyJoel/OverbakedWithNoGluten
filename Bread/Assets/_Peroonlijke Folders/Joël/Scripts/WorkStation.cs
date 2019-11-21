using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkStation : MonoBehaviour
{
    public AllRecipe receptManager;
    public ParticleSystem smoke;
    public GameObject point;
    public GameObject finishedProduct;
    public List<ItemBase> inStation = new List<ItemBase>();
    public RecipeBase availableRecipe;
    public bool cooking;
    public bool finished;
    public float cookingTime;
    public float offset;
    public float force;
    public Text stoveAmount;
    public List<Text> soup = new List<Text>();
    RaycastHit hit;
    [SerializeField]float currentTime;

    public void CheckRecipe()
    {
        bool b = false;
        for (int i = 0; i < inStation.Count; i++)
        {
            if(inStation[i].id == availableRecipe.recipe[i].id)
            {
                b = true;
            }
            else
            {
                Vector3 endPosition = new Vector3(finishedProduct.transform.position.x, finishedProduct.transform.position.y + offset, finishedProduct.transform.position.z);
                GameObject wrongItem = Instantiate(inStation[i].item, endPosition, Quaternion.identity);
                wrongItem.GetComponent<Rigidbody>().velocity += finishedProduct.transform.up * force;
                inStation.Remove(inStation[i]);
                break;
            }
        }
        if (b && inStation.Count == availableRecipe.recipe.Count)
        {
            smoke.Play();
            cooking = true;
            currentTime = cookingTime;
        }
    }

    private void Update()
    {
        if (cooking && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        if(availableRecipe == null)
        {
            point.GetComponent<Collider>().enabled = false;
            point.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            point.GetComponent<Collider>().enabled = true;
            point.GetComponent<Renderer>().enabled = false;
        }
        if(cooking || finished)
        {
            point.GetComponent<Collider>().enabled = false;
            point.GetComponent<Renderer>().enabled = true;
        }
        if (cooking && currentTime <= 0)
        {
            Vector3 endPosition = new Vector3(finishedProduct.transform.position.x, finishedProduct.transform.position.y+ offset, finishedProduct.transform.position.z);
            Instantiate(availableRecipe.finalProduct.item,endPosition,Quaternion.identity);
            inStation.Clear();
            finished = false;
            cooking = false;
            point.GetComponent<Collider>().enabled = true;
            point.GetComponent<Renderer>().enabled = false;
        }
        if(availableRecipe != null)
        {
            stoveAmount.text = inStation.Count.ToString() + "/" + availableRecipe.recipe.Count.ToString();
        }
        else
        {
            stoveAmount.text = "No Recipe Selected";
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        foreach (Text buttonText in soup)
        {
            buttonText.text = buttonText.GetComponentInParent<WorkStationButton>().recept.name;
        }
    }
}
