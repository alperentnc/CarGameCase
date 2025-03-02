using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new(0, 20, -32);
    private float FollowSpeed = 5;
    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z) + offset;
        //transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, FollowSpeed * Time.deltaTime);
    }
}
