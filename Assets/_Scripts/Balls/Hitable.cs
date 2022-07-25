using UnityEngine;

public class Hitable : MonoBehaviour, IRaycastable
{
    public bool isBomb;

    private void PlayEffects()
    {
        Debug.Log("PlayEffects");
    }
    
    public void HitOn()
    {
        PlayEffects();
    }

    public void HitOff()
    {
        
    }
}
