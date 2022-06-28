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
    Transform m_transform;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(m_transform.position, transform.right, Mathf.Infinity))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);

            if(_hit.transform.gameObject.layer == PlayerLayer)
            {
                Draw2DRay(laserFirePoint.position, _hit.point);
                Debug.Log("Je touche le Player");
            }           
            else if (_hit.transform.gameObject.layer == ShieldLayer)
            {
                Draw2DRay(laserFirePoint.position, _hit.point);
                Debug.Log("Je touche le Shield");
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
}
