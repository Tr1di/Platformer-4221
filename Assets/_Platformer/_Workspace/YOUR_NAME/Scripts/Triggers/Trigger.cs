using System;
using System.Linq;
using UnityEngine;

[Serializable]
public enum TriggerType
{
    Enter,
    Exit
}

[RequireComponent(typeof(Collider2D))]
public abstract class Trigger : MonoBehaviour
{
    [Header("Trigger")]
    [SerializeField] private TriggerType type;
    [SerializeField] private string[] tags = { "Player" };
    [SerializeField] private bool once;
    
    private bool _done;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!tags.Contains(other.tag)) return;
        if (type != TriggerType.Enter || _done) return;
        _done = once;
        Activate(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (type != TriggerType.Exit || _done) return;
        _done = once;
        Activate(other);
    }
    
    public abstract void Activate(Collider2D other);
}
