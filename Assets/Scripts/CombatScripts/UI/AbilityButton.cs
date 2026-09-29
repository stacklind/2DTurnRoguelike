using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AbilityButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI abilityName;
    private Button button;

    private Ability ability;
    private Combatant combatant;

    public Button Button {  get { return button; } }

    private void Awake()
    {
        abilityName = GetComponentInChildren<TextMeshProUGUI>();
        button = GetComponent<Button>();
    }
    public void Activate(Ability ability, Combatant combatant)
    {
        this.ability = ability;
        this.combatant = combatant;
        abilityName.text = ability.Name;
        gameObject.SetActive(true);
    }

    public void Decativate()
    {
        gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        CombatHandler.Events.Publish(new CombatUIEvent.ShowAbilityTooltipEvent(ability, combatant));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CombatHandler.Events.Publish(new CombatUIEvent.ClearTooltipEvent());
    }

    
} 