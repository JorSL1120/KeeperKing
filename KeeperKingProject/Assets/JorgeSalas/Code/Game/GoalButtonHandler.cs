using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoalButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private const float hoverDurationThreshold = 2f;
    private Coroutine hoverTimer;
    public bool isInelegibleForRandom { get; private set; } = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverTimer != null) StopCoroutine(hoverTimer);
        hoverTimer = StartCoroutine(StartHoverTimer());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverTimer != null) StopCoroutine(hoverTimer);
        isInelegibleForRandom = false;
    }

    private IEnumerator StartHoverTimer()
    {
        yield return new WaitForSeconds(hoverDurationThreshold);
        isInelegibleForRandom = true;
    }
}
