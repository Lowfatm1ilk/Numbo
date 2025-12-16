using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private IClickable currentHover;

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        IClickable newHover = null;

        if (hit.collider != null)
        {
            newHover = hit.collider.GetComponent<IClickable>();
        }

        if (newHover != null && newHover != currentHover)
        {
            currentHover?.OnHoverExit();
            currentHover = newHover;
            currentHover.OnHover();
        }

        if (newHover == null && currentHover != null)
        {
            currentHover.OnHoverExit();
            currentHover = null;
        }

        if (Input.GetMouseButtonDown(0) && newHover != null)
        {
            newHover.OnClicked();
        }
    }
}

