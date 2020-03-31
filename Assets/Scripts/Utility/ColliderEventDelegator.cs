using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ColliderEvent : UnityEvent<Collider>
{
}

public class ColliderEventDelegator : MonoBehaviour
{
    public ColliderEvent TriggerStayCallback;
    public ColliderEvent TriggerExitCallback;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other);
        TriggerStayCallback.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other);
        TriggerExitCallback.Invoke(other);
    }
}
