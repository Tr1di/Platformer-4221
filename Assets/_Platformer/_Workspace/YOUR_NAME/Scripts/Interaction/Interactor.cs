using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Interactor : MonoBehaviour
{
    private List<IInteractive> _interactives;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var interactive = other.GetComponent<IInteractive>();
        if (interactive != null) _interactives.Add(interactive);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var interactive = other.GetComponent<IInteractive>();
        if (interactive != null) _interactives.Remove(interactive);
    }
    
    private void Sort()
    {
        if (!HasInteractions()) return;
        _interactives = _interactives.OrderBy(x => x.Priority).ToList();
    }
    
    public void Interact()
    {
        Sort();
        var interactive = _interactives.LastOrDefault();
        interactive?.Interact(this);
    }

    public bool HasInteractions()
    {
        return _interactives.Count > 0;
    }
}
