using UnityEngine;

public interface IPlayableCharacter : ICharacter
{
    public AudioClip OnShopSelected { get; }
    public AudioClip OnHire { get; }
}
