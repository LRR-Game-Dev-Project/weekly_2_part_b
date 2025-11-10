using UnityEngine;

public class IndicatorController : MonoBehaviour
{
    public Transform player; // player to track
    public RectTransform minimapPanel; // minimap panel
    public float worldWidth = 20f; // world width
    public float worldHeight = 20f; // world height
    public float movementMultiplier = 1.5f;// how much to scale the circle's movement (default 1.5)

    private RectTransform indicatorRect;// rect transform of the indicator

    void Start()
    {// get the RectTransform component
        indicatorRect = GetComponent<RectTransform>();
    }
    void Update()
    {//function to update the indicator position
        if (player == null || minimapPanel == null) return;

        // Normalize the player's position
        float normalizedX = (player.position.x + worldWidth / 2f) / worldWidth;
        float normalizedY = (player.position.y + worldHeight / 2f) / worldHeight;

        // Convert to minimap position
        float minimapX = (normalizedX * minimapPanel.rect.width - minimapPanel.rect.width / 2f) * movementMultiplier;
        float minimapY = (normalizedY * minimapPanel.rect.height - minimapPanel.rect.height / 2f) * movementMultiplier;

        // Clamp to panel boundaries
        float halfWidth = minimapPanel.rect.width / 2f;// get half width
        float halfHeight = minimapPanel.rect.height / 2f;
        float indicatorHalfW = indicatorRect.rect.width / 2f;
        float indicatorHalfH = indicatorRect.rect.height / 2f;

//limiting the indicator within the minimap panel
        minimapX = Mathf.Clamp(minimapX, -halfWidth + indicatorHalfW, halfWidth - indicatorHalfW);
        minimapY = Mathf.Clamp(minimapY, -halfHeight + indicatorHalfH, halfHeight - indicatorHalfH);

        // Update the final position
        indicatorRect.anchoredPosition = new Vector2(minimapX, minimapY);
    }
}
