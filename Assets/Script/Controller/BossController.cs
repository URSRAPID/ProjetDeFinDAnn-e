using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private LifeView lifeView;

    private BossModel bossModel;

    [SerializeField] private GameObject bossPrefab;

    private float anglesMin = 0;
    public  float speedAngles = 10;
    public float anglesMax;
    private bool isDead = false;

    

    // Start is called before the first frame update
    void Start()
    {
        bossModel = new BossModel(300, 300);
        bossModel.GetLife().Subscribe(lifeView);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (bossModel.GetLife().GetValue().GetValue() <= 0)
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            foreach (Transform go in transform)
            {
                go.gameObject.SetActive(false);
            }
            isDead = true;
            Debug.Log(isDead);
            if (isDead == true)
            {
                Debug.Log("Oui");
                if (bossPrefab.transform.eulerAngles.z < anglesMax)
                {
                    Debug.Log(anglesMin);
                    anglesMin = speedAngles * Time.deltaTime;
                    bossPrefab.transform.eulerAngles = new Vector3(bossPrefab.transform.eulerAngles.x, bossPrefab.transform.eulerAngles.y, bossPrefab.transform.eulerAngles.z + anglesMin);
                }
                else
                {
                    bossPrefab.transform.eulerAngles = new Vector3(bossPrefab.transform.eulerAngles.x, bossPrefab.transform.eulerAngles.y, anglesMax);
                    isDead = false;
                    Destroy(gameObject);
                }
            }
        }
    }


    public void OnDamage()
    {
        bossModel.AddLife(-1);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BalleCharacter")
        {
            OnDamage();
        }
    }
}
