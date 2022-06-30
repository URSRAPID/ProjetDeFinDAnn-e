using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTutorial : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    [SerializeField] public LineRenderer m_lineRenderer;
    [SerializeField] public Transform laserFirePoint;
    [SerializeField] public int PlayerLayer;
    [SerializeField] public int ShieldLayer;
    [SerializeField] public int IgnoreLaserLayer;
    Transform m_transform;

    private bool playerHit;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }


    private void Update()
    {
        IgnoreLaserLayer = 1 << 10;
        IgnoreLaserLayer = ~IgnoreLaserLayer;
        ShootLaser();
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(m_transform.position, transform.right, Mathf.Infinity, IgnoreLaserLayer))
        {

            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
     
            if (_hit.transform.gameObject.layer == PlayerLayer)
            {
                Draw2DRay(laserFirePoint.position, _hit.point);
              
                playerHit = true;
                FindObjectOfType<CharacterControler1>().AddDamageLaser(this);
            }
            else if (_hit.transform.gameObject.layer == ShieldLayer)
            {
                Draw2DRay(laserFirePoint.position, _hit.point);
                
            }
            else
            {
                Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
            }
        }

        void Draw2DRay(Vector2 startPos, Vector2 endPos)
        {
            m_lineRenderer.SetPosition(0, startPos);
            m_lineRenderer.SetPosition(1, endPos);
        }

        
    }
    public bool GetPlayerHit()
    {
        return playerHit;
    }
}
