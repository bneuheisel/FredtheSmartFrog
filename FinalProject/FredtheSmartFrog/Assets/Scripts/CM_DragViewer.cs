using Cinemachine;
using UnityEngine;

public class CM_DragViewer : MonoBehaviour
{
    private CinemachineVirtualCamera _vcam;
    private FixedTouchField _touchfield;

    // Use this for initialization
    void Start()
    {
        _vcam = GetComponent<CinemachineVirtualCamera>();
        _touchfield = FindObjectOfType<FixedTouchField>();
    }

    // Update is called once per frame
    void Update()
    {
        CinemachineTransposer ct = _vcam.GetCinemachineComponent<CinemachineTransposer>();
        ct.m_FollowOffset = Quaternion.AngleAxis(_touchfield.TouchDist.x, Vector3.up) * ct.m_FollowOffset;
        ct.m_FollowOffset = Quaternion.AngleAxis(_touchfield.TouchDist.y, Vector3.right) * ct.m_FollowOffset;
    }
}
