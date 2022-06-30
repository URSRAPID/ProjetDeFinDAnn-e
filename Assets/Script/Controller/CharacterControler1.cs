using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class CharacterControler1 : MonoBehaviour
{
    [SerializeField] private LifeView lifeView;
    [SerializeField] private MpView mpView;
    [SerializeField] private PositionView positionView;

    [SerializeField] private Transform cam;

    private CharacterModel characterModel;
    private HealthView _healthLife;


    [SerializeField] private BouclierView bouclierView;


    [SerializeField] private float speed = 5;
    [SerializeField] private float speedCam = 5;

    [SerializeField] private float deltaY;
    [SerializeField] private float deltaX;
    [SerializeField] private float deltaminY;
    [SerializeField] private float deltaminX;

    [SerializeField] private float deltaPositionBouclier;

    // Points de détection de collision inférieurs gauche et droit
    public Transform downLeft;
    public Transform downRight;

    //Points de détection de collision supérieurs gauche et droit 
    public Transform upLeft;
    public Transform upRight;


    //Points de détection de collision gauche Haut et bas
    public Transform leftUp;
    public Transform leftDown;

    //Points de détection de collision droit Haut et bas
    public Transform rightUp;
    public Transform rightDown;

    public LayerMask groundLayerMask;
    private bool isCollisonDown = false;
    private bool isCollisonUp = false;
    private bool isCollisonLeft = false;
    private bool isCollisonRight = false;

    public float rayLength = 0.5f;


    private float minMP = 0f;


    // ANIMATION

    public Animator animator;
    private bool isDead;


    // Game Over Panel

    public GameObject gameOver;
    bool loadedOnce = false;
    public AudioSource stopLevelMusic;
    public AudioSource gameoverMusic;

    public bool _bouclierIsActive;


    public float manaBouclier = 10000;

    void Start()
    {

        characterModel = new CharacterModel(-10, 0, 3, 3, manaBouclier, 20000);
        characterModel.GetLife().Subscribe(lifeView);
        characterModel.GetPosition().Subscribe(positionView);
        characterModel.GetMp().Subscribe(mpView);


    }
    void Update()
    {

        // ANIMATION






        DetectionCollisionMur();
        Vector2 moveCam = new Vector2(speedCam * Time.deltaTime, 0);
        float deltaPositionV = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float deltaPositionH = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (deltaPositionV < 0 && isCollisonDown)
        {
            deltaPositionV = 0;
        }
        if (deltaPositionV > 0 && isCollisonUp)
        {
            deltaPositionV = 0;
        }
        if (deltaPositionH < 0 && isCollisonLeft)
        {
            deltaPositionH = 0;
            
        }
        if (deltaPositionH > 0 && isCollisonRight)
        {
            deltaPositionH = 0;
            speedCam = 0;
        }

        

        Vector2 deltaPosition = new Vector2(deltaPositionH, deltaPositionV);


        BouclierActive();


        //Gestion de délimitation pour le character dans la caméra
        if (characterModel.GetPosition().GetValue().y + deltaPosition.y >= cam.transform.position.y + deltaY)
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



        characterModel.AddPosition(moveCam + deltaPosition);
        

        bouclierView.transform.position = new Vector2(characterModel.GetPosition().GetValue().x + deltaPositionBouclier, characterModel.GetPosition().GetValue().y);


        Dead();
        
    }

    public void OnDamage()
    {
        characterModel.AddLife(-1);
        GameObject.FindObjectOfType<HealthView>().health = GameObject.FindObjectOfType<HealthView>().health - 1;



    }

    // ANIMATION TRIGGER WHEN HIT
    public void Hit()
    {
        if (!isDead)
        {
            animator.SetTrigger("Hit");
        }
    }


    public void Dead()
    {
        if (characterModel.GetLife().GetValue().GetValue() <= 0 && !isDead)
        {
            isDead = true;
            
            animator.SetTrigger("Dead");
            StartCoroutine(LoadDelayed());
            
            

        }
        // ici du coup j'ai fais la fonction qui fait que ca lancera le trigger animation de la mort, manque plus qu'à mettre " Dead(); " à la fin de la condition de mort et c good (comme à la ligne 171 pour Hit();
    }

    IEnumerator LoadDelayed(float tempsEnSecondes = 1.5f)
    {
        yield return new WaitForSeconds(tempsEnSecondes);
        Time.timeScale = 0;
        stopLevelMusic.Stop();
        
        gameOver.SetActive(true);
        gameOver.transform.Find("Score").Find("Text Score FLOAT").GetComponent<TextMeshProUGUI>().text = GameObject.FindObjectOfType<ScoreController>().GetScoreModel().GetScore().GetValue().ToString();
        gameoverMusic.Play();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "BalleEnemy")
        {
            if (characterModel.GetLife().GetValue().GetValue() >= 1)
            {
                OnDamage();
                Hit();
            }
                
        }
        if (collision.gameObject.tag == "PowerUpLifeCharacter")
        {
            if (characterModel.GetLife().GetValue().GetValue() < 3)
            {
                
                characterModel.AddLife(1);
                GameObject.FindObjectOfType<HealthView>().health = GameObject.FindObjectOfType<HealthView>().health + 1;
                Debug.Log(characterModel.GetLife().GetValue().GetValue());
            }
           
        }
        if (collision.gameObject.tag == "PowerUpManaBouclierCharacter")
        {
            if (characterModel.GetMp().GetValue().GetValue() < 10000)
            {
                characterModel.AddMp(1000);
            }
            
        }
        if (collision.gameObject.tag == "Laser")
        {
            OnDamage();
            Hit();
        }
        if (collision.gameObject.tag == "BouclierIsActive")
        {
            _bouclierIsActive = true;
        }

    }

    private void BouclierActive()
    {
        if (_bouclierIsActive == true)
        {
            if (characterModel.GetMp().GetValue().GetValue() > 0)
            {
                if (Input.GetMouseButton(0))
                {
                    bouclierView.gameObject.SetActive(true);
                    characterModel.AddMp(-2);
                }
                else
                {
                    bouclierView.gameObject.SetActive(false);
                }
            }

            if (characterModel.GetMp().GetValue().GetValue() <= minMP)
            {
                bouclierView.gameObject.SetActive(false);
            }
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawLine(downLeft.position, new Vector2(downLeft.position.x, downLeft.position.y - rayLength));
        Gizmos.DrawLine(downRight.position, new Vector2(downRight.position.x, downRight.position.y - rayLength));

        Gizmos.DrawLine(upLeft.position, new Vector2(upLeft.position.x, upLeft.position.y + rayLength));
        Gizmos.DrawLine(upRight.position, new Vector2(upRight.position.x, upRight.position.y + rayLength));

        Gizmos.DrawLine(leftUp.position, new Vector2(leftUp.position.x - rayLength, leftUp.position.y));
        Gizmos.DrawLine(leftDown.position, new Vector2(leftDown.position.x - rayLength, leftDown.position.y));

        Gizmos.DrawLine(rightUp.position, new Vector2(rightUp.position.x + rayLength, rightUp.position.y));
        Gizmos.DrawLine(rightDown.position, new Vector2(rightDown.position.x + rayLength, rightDown.position.y));
    }
    
    void DetectionCollisionMur()
    {
        RaycastHit2D downLeftHit = Physics2D.Raycast(downLeft.position, Vector2.down, rayLength, groundLayerMask);
        RaycastHit2D downRightHit = Physics2D.Raycast(downRight.position, Vector2.down, rayLength, groundLayerMask);
        if (downLeftHit.collider != null || downRightHit.collider != null)
        {
            isCollisonDown = true;

        }
        else
        {
            isCollisonDown = false;
        }

        RaycastHit2D upLeftHit = Physics2D.Raycast(upLeft.position, Vector2.up, rayLength, groundLayerMask);
        RaycastHit2D upRightHit = Physics2D.Raycast(upRight.position, Vector2.up, rayLength, groundLayerMask);
        if (upLeftHit.collider != null || upRightHit.collider != null)
        {
            isCollisonUp = true;
        }
        else
        {
            isCollisonUp = false;
        }

        RaycastHit2D leftUpHit = Physics2D.Raycast(leftUp.position, Vector2.left, rayLength, groundLayerMask);
        RaycastHit2D leftDownHit = Physics2D.Raycast(leftDown.position, Vector2.left, rayLength, groundLayerMask);
        if (leftUpHit.collider != null || leftDownHit.collider != null)
        {
            isCollisonLeft = true;
        }
        else
        {
            isCollisonLeft = false;
        }

        RaycastHit2D rightUpHit = Physics2D.Raycast(rightUp.position, Vector2.right, rayLength, groundLayerMask);
        RaycastHit2D rightDownHit = Physics2D.Raycast(rightDown.position, Vector2.right, rayLength, groundLayerMask);
        if (rightUpHit.collider != null || rightDownHit.collider != null)
        {
            isCollisonRight = true;
            speedCam = 0;
        }
        else
        {
            isCollisonRight = false;
            speedCam = 5.0F ;
        }

    }

    public void AddDamageLaser(LaserTutorial _laserDamage)
    {
        Debug.Log("Oui");
        if (_laserDamage != null && _laserDamage.GetPlayerHit() == true)
        {
            Debug.Log("Oui2");
            OnDamage();
        }
    }
    

}

