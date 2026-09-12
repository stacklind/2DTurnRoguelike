using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private TextMeshProUGUI moveName;
    [SerializeField]
    private Button button;
    private Move move;

    public Button Button {  get { return button; } }

    public void Activate(Move move)
    {
        this.move = move;
        moveName.text = move.Name;
        gameObject.SetActive(true);
    }

    public void Decativate()
    {
        gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        CombatHandler.Events.Publish(new CombatUIEvent.ShowMoveToolTipEvent(move));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CombatHandler.Events.Publish(new CombatUIEvent.ClearToolTipEvent());
    }

    
} 