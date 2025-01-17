using UnityEngine;

public class cameraFollowBehaviour : MonoBehaviour
{
    [SerializeField] float cameraYAxisAddition = 3f;
    public Transform mainCamerafollow;
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.position = new Vector3(0f, (mainCamerafollow.position.y + cameraYAxisAddition), mainCamerafollow.position.z - 1f);
    }
}
