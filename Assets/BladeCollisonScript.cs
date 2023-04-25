using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeCollisonScript : MonoBehaviour
{
    private const string healthyFoodTag = "Healthy";
    private const string unHealthyFoodTag = "NotHealthy";
    private const string logicScriptTag = "Logic";
    [SerializeField]
    private LogicScript logic;

    private void Start()
    {

        logic = GameObject.FindGameObjectWithTag(logicScriptTag).GetComponent<LogicScript>();


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(healthyFoodTag))
        {
            logic.addScore(1);
            Destroy(other.gameObject);

        }else if (other.CompareTag(unHealthyFoodTag))
        {
            logic.DecreaseScore(1);
            Destroy(other.gameObject);

        }


    }


}
