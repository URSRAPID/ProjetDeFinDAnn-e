using UnityEngine;
using Random = UnityEngine.Random;

public class CanonsActive : MonoBehaviour
{
    [SerializeField] private GameObject Canons;
    [SerializeField] private GameObject Canons2;
    [SerializeField] private GameObject Canons3;
    [SerializeField] private GameObject Canons4;
    [SerializeField] private GameObject bossPrefab;

    Vector2 whereToSpawn;
    [SerializeField] private GameObject Spawn;
    [SerializeField] private GameObject Spawn2;
    [SerializeField] private GameObject Spawn3;
    [SerializeField] private GameObject Spawn4;
    [SerializeField] private GameObject Spawn5;
    [SerializeField] private GameObject Spawn6;
    [SerializeField] private GameObject Spawn7;
    [SerializeField] private GameObject Spawn8;

    [SerializeField] private GameObject SplineBoss1;
    [SerializeField] private GameObject SplineBoss2;
    [SerializeField] private GameObject SplineBoss3;
    [SerializeField] private GameObject SplineBoss4;
    int spawnNb;


    [SerializeField] private float cooldownSpawn;
    private float currentCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        if (cooldownSpawn == 0)
        {
            cooldownSpawn = 1;

        }
        currentCoolDown = cooldownSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossPrefab.transform.eulerAngles.z == 0)
        {
            Canons4.gameObject.SetActive(true);
            currentCoolDown -= Time.deltaTime;
            if (currentCoolDown <= 0)
            {
                SpawnMur();
                currentCoolDown = cooldownSpawn;
                currentCoolDown++;
            }
        }
        if (bossPrefab.transform.eulerAngles.z == 90)
        {
            Canons.gameObject.SetActive(true);
            currentCoolDown -= Time.deltaTime;
            if (currentCoolDown <= 0)
            {
                if (Canons.gameObject.active == true)
                {

                    SpawnMur2();
                    currentCoolDown = cooldownSpawn;
                    currentCoolDown++;
                }
            }
        }
        if (bossPrefab.transform.eulerAngles.z == 180)
        {
            Canons2.gameObject.SetActive(true);
            currentCoolDown -= Time.deltaTime;
            if (currentCoolDown <= 0)
            {
                if (Canons2.gameObject.active == true)
                {
                    SpawnMur3();
                    currentCoolDown = cooldownSpawn;
                    currentCoolDown++;
                }
            }
        }
        if (bossPrefab.transform.eulerAngles.z == 270)
        {
            Canons3.gameObject.SetActive(true);
            currentCoolDown -= Time.deltaTime;
            if (currentCoolDown <= 0)
            {
                if (Canons3.gameObject.active == true)
                {
                    SpawnMur4();
                    currentCoolDown = cooldownSpawn;
                    currentCoolDown++;
                }
            }
        }
    }

    private void SpawnMur()
    {
        Debug.Log("AlDoilea");
        SpawnSpline1();
        SpawnSpline2();
    }

    private void SpawnSpline1()
    {
        spawnNb = Random.Range(0, 3);
        Debug.Log("Altreilea");
        Debug.Log(spawnNb);

        if (spawnNb == 0)
        {
            whereToSpawn = new Vector2(Spawn7.transform.position.x, Spawn7.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss1, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn7.transform);
        }
        else if (spawnNb == 1)
        {
            whereToSpawn = new Vector2(Spawn7.transform.position.x, Spawn7.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss2, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn7.transform);
        }
        else if (spawnNb == 2)
        {
            whereToSpawn = new Vector2(Spawn7.transform.position.x, Spawn7.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss3, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn7.transform);
        }
        else if (spawnNb == 3)
        {
            whereToSpawn = new Vector2(Spawn7.transform.position.x, Spawn7.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss4, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn7.transform);
        }
    }

    private void SpawnSpline2()
    {
        spawnNb = Random.Range(0, 3);

        if (spawnNb == 0)
        {
            whereToSpawn = new Vector2(Spawn8.transform.position.x, Spawn8.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss1, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn8.transform);
        }
        else if (spawnNb == 1)
        {
            whereToSpawn = new Vector2(Spawn8.transform.position.x, Spawn8.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss2, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn8.transform);
        }
        else if (spawnNb == 2)
        {
            whereToSpawn = new Vector2(Spawn8.transform.position.x, Spawn8.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss3, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn8.transform);
        }
        else if (spawnNb == 3)
        {
            whereToSpawn = new Vector2(Spawn8.transform.position.x, Spawn8.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss4, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn8.transform);
        }
    }

    private void SpawnMur2()
    {
        Debug.Log("AlDoilea");
        SpawnSpline7();
        SpawnSpline8();
    }

    private void SpawnSpline7()
    {
        spawnNb = Random.Range(0, 3);
        Debug.Log("Altreilea");
        Debug.Log(spawnNb);

        if (spawnNb == 0)
        {
            whereToSpawn = new Vector2(Spawn.transform.position.x, Spawn.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss1, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn.transform);
        }
        else if (spawnNb == 1)
        {
            whereToSpawn = new Vector2(Spawn.transform.position.x, Spawn.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss2, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn.transform);
        }
        else if (spawnNb == 2)
        {
            whereToSpawn = new Vector2(Spawn.transform.position.x, Spawn.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss3, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn.transform);
        }
        else if (spawnNb == 3)
        {
            whereToSpawn = new Vector2(Spawn.transform.position.x, Spawn.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss4, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn.transform);
        }
    }

    private void SpawnSpline8()
    {
        spawnNb = Random.Range(0, 3);

        if (spawnNb == 0)
        {
            whereToSpawn = new Vector2(Spawn2.transform.position.x, Spawn2.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss1, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn2.transform);
        }
        else if (spawnNb == 1)
        {
            whereToSpawn = new Vector2(Spawn2.transform.position.x, Spawn2.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss2, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn2.transform);
        }
        else if (spawnNb == 2)
        {
            whereToSpawn = new Vector2(Spawn2.transform.position.x, Spawn2.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss3, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn2.transform);
        }
        else if (spawnNb == 3)
        {
            whereToSpawn = new Vector2(Spawn2.transform.position.x, Spawn2.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss4, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn2.transform);
        }
    }
    private void SpawnMur3()
    {
        SpawnSpline3();
        SpawnSpline4();
    }

    private void SpawnSpline3()
    {
        spawnNb = Random.Range(0, 3);

        if (spawnNb == 0)
        {
            whereToSpawn = new Vector2(Spawn3.transform.position.x, Spawn3.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss1, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn3.transform);
        }
        else if (spawnNb == 1)
        {
            whereToSpawn = new Vector2(Spawn3.transform.position.x, Spawn3.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss2, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn3.transform);
        }
        else if (spawnNb == 2)
        {
            whereToSpawn = new Vector2(Spawn3.transform.position.x, Spawn3.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss3, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn3.transform);
        }
        else if (spawnNb == 3)
        {
            whereToSpawn = new Vector2(Spawn3.transform.position.x, Spawn3.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss4, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn3.transform);
        }
    }

    private void SpawnSpline4()
    {
        spawnNb = Random.Range(0, 3);

        if (spawnNb == 0)
        {
            whereToSpawn = new Vector2(Spawn4.transform.position.x, Spawn4.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss1, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn4.transform);
        }
        else if (spawnNb == 1)
        {
            whereToSpawn = new Vector2(Spawn4.transform.position.x, Spawn4.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss2, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn4.transform);
        }
        else if (spawnNb == 2)
        {
            whereToSpawn = new Vector2(Spawn4.transform.position.x, Spawn4.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss3, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn4.transform);
        }
        else if (spawnNb == 3)
        {
            whereToSpawn = new Vector2(Spawn4.transform.position.x, Spawn4.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss4, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn4.transform);
        }
    }

    private void SpawnMur4()
    {
        SpawnSpline5();
        SpawnSpline6();
    }


    private void SpawnSpline5()
    {
        spawnNb = Random.Range(0, 3);

        if (spawnNb == 0)
        {
            whereToSpawn = new Vector2(Spawn5.transform.position.x, Spawn5.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss1, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn5.transform);
        }
        else if (spawnNb == 1)
        {
            whereToSpawn = new Vector2(Spawn5.transform.position.x, Spawn5.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss2, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn5.transform);
        }
        else if (spawnNb == 2)
        {
            whereToSpawn = new Vector2(Spawn5.transform.position.x, Spawn5.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss3, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn5.transform);
        }
        else if (spawnNb == 3)
        {
            whereToSpawn = new Vector2(Spawn5.transform.position.x, Spawn5.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss4, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn5.transform);
        }
    }

    private void SpawnSpline6()
    {
        spawnNb = Random.Range(0, 3);

        if (spawnNb == 0)
        {
            whereToSpawn = new Vector2(Spawn6.transform.position.x, Spawn6.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss1, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn6.transform);
        }
        else if (spawnNb == 1)
        {
            whereToSpawn = new Vector2(Spawn6.transform.position.x, Spawn6.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss2, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn6.transform);
        }
        else if (spawnNb == 2)
        {
            whereToSpawn = new Vector2(Spawn6.transform.position.x, Spawn6.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss3, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn6.transform);
        }
        else if (spawnNb == 3)
        {
            whereToSpawn = new Vector2(Spawn6.transform.position.x, Spawn6.transform.position.y);
            GameObject clientSpecial = Instantiate(SplineBoss4, whereToSpawn, Quaternion.identity);
            clientSpecial.transform.SetParent(Spawn6.transform);
        }
    }
}
