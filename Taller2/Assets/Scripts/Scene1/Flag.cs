using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameControllerScene1 controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            controller.TocarBandera();
        }
    }
}