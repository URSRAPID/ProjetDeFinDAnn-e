using UnityEngine;


public class CharacterControler1 : MonoBehaviour
{
    [SerializeField] private LifeView lifeView;
    [SerializeField] private PositionView positionView;
    private CharacterModel characterModel;


    [SerializeField] private float speed = 5;
    [SerializeField] private float speedCam = 5;

    void Start()
    {
        characterModel = new CharacterModel(-10,0, 3, 3);
        characterModel.GetLife().Subscribe(lifeView);
        characterModel.GetPosition().Subscribe(positionView);
    }
    void Update()
    {
        characterModel.AddPosition(new Vector2(speedCam * Time.deltaTime, 0));
        characterModel.AddPosition(new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime,
        Input.GetAxis("Vertical") * speed * Time.deltaTime));

    }

    public void OnDamage()
    {
        Debug.Log("-1");
        characterModel.AddLife(-1);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "BalleEnemy")
        {
            OnDamage();
            
        }
    }
}

