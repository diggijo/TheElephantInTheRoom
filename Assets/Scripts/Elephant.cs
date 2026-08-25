using System;
using UnityEngine;

public class Elephant : MonoBehaviour
{
    public static Elephant Instance { get; private set; }
    public event EventHandler OnElephantFound;

    private void Awake()
    {
        Instance = this;
    }

    public void Found()
    {
        DestroySelf();
        Debug.Log("Elephant found!");
        OnElephantFound?.Invoke(this, EventArgs.Empty);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
