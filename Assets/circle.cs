using UnityEngine;

public class MiniMapIcon : MonoBehaviour
{
    //some fields to set in inspector
    [Header("any player")]
    public Transform player;//player to follow on minimap

    [Header("map scale")]
    public Vector2 mapScale = new Vector2(0.1f, 0.1f); // scale down factor for minimap

    [Header("map height")]
    public float zOffset = 0f;// always above the background

    void Start()
    {   
        //transform.position = new Vector3(2f, 3f, transform.position.z);
        // Make sure there's a SpriteRenderer and it's set to a high Sorting Layer
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if(sr != null)
        {
            sr.sortingLayerName = "MiniMapPlayer";  // the name of the layer you created
            sr.sortingOrder = 10;// above the background
        }
    }

    void LateUpdate()
    {
        if(player == null) return;

        // Convert the player's world position to a position on the map
        Vector3 newPos = new Vector3(player.position.x * mapScale.x,player.position.y * mapScale.y,zOffset);

        transform.localPosition = newPos;// Update the icon's position on the minimap
    }
}
