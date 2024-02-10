using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Room camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //Follow player
    [SerializeField] private Transform player;

    private void Update()
    {

        if (player != null)
        {
            // Follow player
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}