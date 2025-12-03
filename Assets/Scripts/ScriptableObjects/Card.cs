using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public string type;
    public int value;
    public string description;

    public Sprite cardSprite;
    
    public CardEffect effect;
}
