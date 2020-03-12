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
    public ColliderEvent EnterCallback;
    public ColliderEvent StayCallback;
    public ColliderEvent ExitCallback;

    private void OnTriggerEnter(Collider other)
    {
        EnterCallback.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        StayCallback.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        ExitCallback.Invoke(other);
    }
}
