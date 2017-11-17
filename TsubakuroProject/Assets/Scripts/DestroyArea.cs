using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    Manager manager;
    void OnTriggerExit2D(Collider2D c)
    {
        Destroy(c.gameObject);
    }
    private void Update()
    {
        manager = FindObjectOfType<Manager>();
        if (manager.IsPlaying() == false)
        {
            transform.position = new Vector3(800, 0, 0);
        }
        else
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}