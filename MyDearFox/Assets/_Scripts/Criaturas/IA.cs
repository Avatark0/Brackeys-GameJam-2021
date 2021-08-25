using UnityEngine;

public class IA : MonoBehaviour
{
    [SerializeField] private Criatura essaCriatura;

    private void Awake()
    {
        essaCriatura=transform.parent.gameObject.GetComponent<Criatura>();
    }
}
