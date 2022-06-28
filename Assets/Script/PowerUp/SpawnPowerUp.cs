using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    Vector2 whereToSpawn;
    [SerializeField] public GameObject _spawnPrefabPowerUp;
    [SerializeField] public GameObject _spawnPointPowerUp;



    // ici je chope le prefab du bouton power up
    public GameObject boutonPowerUp;

    // sound effect 

    //public AudioSource activation;
    //public AudioSource desactivation;
    //public AudioSource apparition;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

               
        
    }

    private void PowerUp()
    {
        whereToSpawn = new Vector2(_spawnPointPowerUp.transform.position.x, _spawnPointPowerUp.transform.position.y);
        GameObject clientSpecial = Instantiate(_spawnPrefabPowerUp, whereToSpawn, Quaternion.identity);
        clientSpecial.transform.SetParent(_spawnPointPowerUp.transform);
    }

    public void DesactivationBouton()
    {
        StartCoroutine(LoadDelayed());
    }

    public void ActivationBouton()
    {
        PowerUp();
    }


    IEnumerator LoadDelayed(float tempsEnSecondes = 1.5f)
    {
        yield return new WaitForSeconds(tempsEnSecondes);
        boutonPowerUp.SetActive(false);
    }
}
