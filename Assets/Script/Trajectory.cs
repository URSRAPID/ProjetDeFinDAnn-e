using BezierSolution;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private int nbEnnemi;
    [SerializeField] private float cooldownSpawnEnnemy;
    [SerializeField] private GameObject prefabEnnemi;
    [SerializeField] private BezierSpline spline;
    private int currentSpawnedEnnemy;
    private float currentCooldown;
    // Start is called before the first frame update
    void Start()
    {
        if (cooldownSpawnEnnemy == 0)
        {
            cooldownSpawnEnnemy = 1;
            Debug.Log("Be Careful, cooldownSpawnEnnemy was 0 !");
        }
        currentCooldown = cooldownSpawnEnnemy;
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0 && currentSpawnedEnnemy < nbEnnemi)
        {
            GameObject ennemi = Instantiate(prefabEnnemi, new Vector3(0f, 99f, 0f), Quaternion.identity);
            ennemi.GetComponent<BezierWalkerWithSpeed>().spline = spline;
            currentCooldown = cooldownSpawnEnnemy;
            currentSpawnedEnnemy++;
        }
    }
}
