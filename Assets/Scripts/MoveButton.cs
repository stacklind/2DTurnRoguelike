using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moveName;
    [SerializeField]
    private TextMeshProUGUI moveCost;

    public string MoveName 
    { 
        set
        {
            moveName.text = value;
        } 
    }
    public string MoveCost
    {
        set
        {
            moveCost.text = value;
        }
    }
}
