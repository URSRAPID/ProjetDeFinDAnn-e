using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private LifeView lifeView;

    private BossModel bossModel;

    [SerializeField] private GameObject bossPrefab;

    // Start is called before the first frame update
    void Start()
    {
        bossModel = new BossModel( 3, 3);
        bossModel.GetLife().Subscribe(lifeView);
    }

    // Update is called once per frame
    void Update()
    {
        if ( bossModel.GetLife().GetValue().GetValue() <= 0 )
        {
            
            bossPrefab.transform.eulerAngles = new Vector3(bossPrefab.transform.eulerAngles.x, bossPrefab.transform.eulerAngles.y, bossPrefab.transform.eulerAngles.z + 90);
            Destroy(gameObject);
            Debug.Log(bossPrefab.transform.eulerAngles.z);
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
