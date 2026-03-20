using UnityEngine;

public class SpikedEnemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInvisibility invis = collision.gameObject.GetComponent<PlayerInvisibility>();

            if (invis != null && !invis.IsInvisible)
            {
                collision.gameObject.GetComponent<PlayerLife>().SendMessage("Die");
            }
        }
    }

}
