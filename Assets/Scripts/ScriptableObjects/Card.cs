using UnityEngine;

public enum CardType
{
    Simple,
    Multiplier,
    Utility,
    Special
}


[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public CardType type;
    public int value;
    public string description;
    public Sprite cardSprite;
    
    public CardEffect effect;
}
