using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;// player to follow

    void LateUpdate()// called after all Update functions have been called
    {
        if (player != null)// check if player is assigned
        {
            Vector3 newPos = player.position;// get player's position
            newPos.z = transform.position.z; // Keep the camera's height
            transform.position = newPos;// update minimap position
        }
    }
    
}
