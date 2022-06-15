using UnityEngine;


public class CharacterControler1 : MonoBehaviour
{
    [SerializeField] private LifeView lifeView;
    [SerializeField] private MpView mpView;
    [SerializeField] private PositionView positionView;

    [SerializeField] private Transform cam;

    private CharacterModel characterModel;

    
    [SerializeField] private BouclierView bouclierView;
    

    [SerializeField] private float speed = 5;
    [SerializeField] private float speedCam = 5;

    [SerializeField] private float deltaY;
    [SerializeField] private float deltaX;
    [SerializeField] private float deltaminY;
    [SerializeField] private float deltaminX;

    [SerializeField] private float deltaPositionBouclier;
    void Start()
    {
        
        characterModel = new CharacterModel(-10,0, 3, 3 , 10000,10000);
        characterModel.GetLife().Subscribe(lifeView);
        characterModel.GetPosition().Subscribe(positionView);
        characterModel.GetMp().Subscribe(mpView);
    }
    void Update()
    {
        float deltaPositionV = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float deltaPositionH = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 deltaPosition = new Vector2(deltaPositionH, deltaPositionV);

        Debug.Log("Vertical:" + Input.GetAxis("Vertical"));
        Debug.Log("Horizontal:" + Input.GetAxis("Horizontal"));

        

        BouclierActive();

        if (characterModel.GetPosition().GetValue().y + deltaPosition.y >= cam.transform.position.y + deltaY )
        {
            deltaPosition.y = 0F;
            
        }
        if (characterModel.GetPosition().GetValue().x + deltaPosition.x >= cam.transform.position.x + deltaX)
        {
            deltaPosition.x = 0F;
           
        }
        if (characterModel.GetPosition().GetValue().y + deltaPosition.y <= cam.transform.position.y + deltaminY)
        {
            deltaPosition.y = 0F;   
        }
        if (characterModel.GetPosition().GetValue().x + deltaPosition.x <= cam.transform.position.x + deltaminX)
        {
            deltaPosition.x = 0F; 
        }
        characterModel.AddPosition(new Vector2(speedCam * Time.deltaTime, 0) + deltaPosition);

        bouclierView.transform.position = new Vector2(characterModel.GetPosition().GetValue().x + deltaPositionBouclier, characterModel.GetPosition().GetValue().y);
    }

    public void OnDamage()
    {
        characterModel.AddLife(-1);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "BalleEnemy")
        {
            OnDamage();
            
        }
    }

    private void BouclierActive()
    {
        if (characterModel.GetMp().GetValue().GetValue() > 0)
        {
            if (Input.GetMouseButton(1))
            {
                bouclierView.gameObject.SetActive(true);
                characterModel.AddMp(-10);
            }
        }
        
        if (Input.GetMouseButtonUp(1))
        {
            bouclierView.gameObject.SetActive(false);
        }
    }
}

