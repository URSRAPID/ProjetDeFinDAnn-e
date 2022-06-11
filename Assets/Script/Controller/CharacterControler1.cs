using UnityEngine;


public class CharacterControler1 : MonoBehaviour
{
    [SerializeField] private LifeView lifeView;
    [SerializeField] private PositionView positionView;
    private CharacterModel characterModel;

    //[SerializeField] private float maxPos;
    //[SerializeField] private float minPos;

    [SerializeField] private float speed = 5;
    [SerializeField] private float speedCam = 5;

    Transform myTransform;
    void Start()
    {
        myTransform = GetComponent<Transform>();
        characterModel = new CharacterModel(-10, 0, 3, 3);
        characterModel.GetLife().Subscribe(lifeView);
        characterModel.GetPosition().Subscribe(positionView);
    }
    void Update()
    {

        float posX = Input.GetAxis("Horizontal");
        float posY = Input.GetAxis("Vertical");
        Vector2 newPos = new Vector2(posX * speed * Time.deltaTime,
        posY * speed * Time.deltaTime);
        characterModel.AddPosition(new Vector2(speedCam * Time.deltaTime, 0));
        characterModel.AddPosition(newPos);
        //myTransform.Translate(newPos);
        //characterModel.AddPosition(new Vector2(Mathf.Clamp(characterModel.GetPosition().GetValue().x, minPos, maxPos ), characterModel.GetPosition().GetValue().y));
        //myTransform.position = new Vector2(Mathf.Clamp(myTransform.position.x, minPos, maxPos), myTransform.position.y);
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

