using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Background;

    [SerializeField]
    private float m_ScrollSpeedRatio = 0.1f;

    private GameObject m_BackgroundRightClone;

    private GameObject m_BackgroundLeftClone;

    private float m_BackgroundWidth;

    private Vector3 m_PreviousCameraPosition;

    void Start()
    {
        m_BackgroundWidth = m_Background.transform.GetComponent<SpriteRenderer>().bounds.size.x;
        m_PreviousCameraPosition = transform.position;
        m_BackgroundRightClone = CreateBackgroundClone(m_Background, new Vector3(m_BackgroundWidth, 0, 0));
        m_BackgroundLeftClone = CreateBackgroundClone(m_Background, new Vector3(-m_BackgroundWidth, 0, 0));
    }

    void Update()
    {
        float x_offset = m_Background.transform.position.x - transform.position.x;
        if (Mathf.Abs(x_offset) > m_BackgroundWidth)
        {
            Vector3 delta = new Vector3(x_offset, 0, 0);
            m_Background.transform.position -= delta;
            m_BackgroundRightClone.transform.position -= delta;
            m_BackgroundLeftClone.transform.position -= delta;
        }

        Vector3 cameraVelocity = transform.position - m_PreviousCameraPosition;
        m_PreviousCameraPosition = transform.position;

        m_Background.transform.position -= cameraVelocity * m_ScrollSpeedRatio;
        m_BackgroundRightClone.transform.position -= cameraVelocity * m_ScrollSpeedRatio;
        m_BackgroundLeftClone.transform.position -= cameraVelocity * m_ScrollSpeedRatio;
    }

    private GameObject CreateBackgroundClone(GameObject background, Vector3 positionOffset)
    {
        GameObject backgroundClone = GameObject.Instantiate(background);
        Destroy(backgroundClone.GetComponent<BackgroundScroller>());
        backgroundClone.transform.SetParent(transform);
        backgroundClone.transform.localPosition = m_Background.transform.localPosition + positionOffset;

        return backgroundClone;
    }
}
