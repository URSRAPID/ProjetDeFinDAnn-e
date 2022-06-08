using UnityEngine;


public class CharacterControler1 : MonoBehaviour
{
    [SerializeField] private LifeView lifeView;

     private CharacterModel characterModel;


    private float speed = 5;
    void Start()
    {
        characterModel = new CharacterModel(-10,0, 3, 3);
        characterModel.GetLife().Subscribe(lifeView);
    }
    void Update()
    {
        transform.Translate(
        Input.GetAxis("Horizontal") * speed * Time.deltaTime,
        Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);
    }

    public void OnDamage()
    {
        characterModel.AddLife(-1);
    }

}

