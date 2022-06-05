using UnityEngine;
using UnityEngine.Events;


public class OnTriggerEvent : MonoBehaviour
{
    [SerializeField] UnityEvent onEnter;
    [SerializeField] UnityEvent<GameObject> onEnterDynamicGO;

    [SerializeField] UnityEvent onExit;
    [SerializeField] UnityEvent<GameObject> onExitDynamicGO;

    [SerializeField] string objectTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(objectTag))
        {
            onEnter?.Invoke();

            onEnterDynamicGO?.Invoke(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(objectTag))
        {
            onExit?.Invoke();

            onExitDynamicGO?.Invoke(other.gameObject);
        }
    }
}
