using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_Target;

    [SerializeField]
    private float m_SmoothTime = 1.0f;

    [SerializeField]
    private Vector3 m_Offset;

    private Vector3 m_Velocity;

    public void SetTarget(Transform target)
    {
        m_Target = target;
    }

    void Update()
    {
        if (m_Target == null)
        {
            return;
        }

        Vector3 targetPostion = m_Target.position + m_Offset;

        if (MathUtils.AreApproximatelyEqual(transform.position, targetPostion))
        {
            return;
        }

        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPostion, ref m_Velocity, m_SmoothTime);
        transform.position = smoothPosition;
    }
}
