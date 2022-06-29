using UnityEngine;
using TMPro;

public class BossCoeur : MonoBehaviour
{
    [SerializeField] private LifeView lifeView;
    private BossModel bossModel;

    public GameObject win;

    [SerializeField] private float cooldownSpawnLaser;
    private float currentCoolDown;


    public GameObject Laser1;
    public GameObject Laser2;
    public GameObject Laser3;
    public GameObject Laser4;
    public GameObject Laser5;
    public GameObject Laser6;


    private bool LaserFormation1 = true;
    private bool LaserFormation2 = false;
    
    // Start is called before the first frame update
    void Start()
    {
        bossModel = new BossModel(100, 100);
        bossModel.GetLife().Subscribe(lifeView);
        if (cooldownSpawnLaser == 0)
        {
            cooldownSpawnLaser = 1;

        }
        currentCoolDown = cooldownSpawnLaser;
    }

    // Update is called once per frame
    void Update()
    {
        if (LaserFormation1)
        {
            ActiveLaser1();
            LaserFormation1 = false;
            LaserFormation2 = true;
        }
         if (LaserFormation2)
        {
            ActiveEtDesactiverLaser2();
            LaserFormation2 = false;
            LaserFormation1 = true;
        }
    }

    private void ActiveLaser1()
    {
        currentCoolDown -= Time.deltaTime;
        if (currentCoolDown <= 0)
        {
            Laser1.SetActive(true);
            Laser3.SetActive(true);
            Laser5.SetActive(true);
            currentCoolDown = cooldownSpawnLaser;
            currentCoolDown++;
            
        }
    }
  

    private void ActiveEtDesactiverLaser2()
    {
        currentCoolDown -= Time.deltaTime;
        if (currentCoolDown <= 0)
        {
            Laser2.SetActive(true);
            Laser4.SetActive(true);
            Laser6.SetActive(true);
            currentCoolDown = cooldownSpawnLaser;
            currentCoolDown++;
        }
    }
    public void OnDamage()
    {
        bossModel.AddLife(-1);

    }
    public void Dead()
    {
        if (bossModel.GetLife().GetValue().GetValue() <= 0)
        {
            win.SetActive(true);
            win.transform.Find("Score").Find("Text Score FLOAT").GetComponent<TextMeshProUGUI>().text = GameObject.FindObjectOfType<ScoreController>().GetScoreModel().GetScore().GetValue().ToString();
        }
        
    }

private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "BalleCharacter")
    {
        OnDamage();
    }
}
}
