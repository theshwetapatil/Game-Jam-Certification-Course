using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public bool destroyOnTrigger = true;

    public List<string> tags;

    public UnityEngine.Events.UnityEvent onTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (tags.Count == 0 || tags.Contains(other.tag))
        {
            onTrigger.Invoke();

            if (destroyOnTrigger)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
