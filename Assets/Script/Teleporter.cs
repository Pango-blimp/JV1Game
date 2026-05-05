using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform destination;
    private bool playerInZone = false;

    public Transform player;
    private Vector3 originalScale;

    public KeyCode keyToPress = KeyCode.Escape;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }
    void Update()
    {
        if (playerInZone && Input.GetKeyDown(keyToPress))
        {
            {
                player.position = destination.position;
            }
        }
    }

    /*void OnMouseEnter()
    {
        if (PauseMenu.Instance.IsPaused()) return;
        if (MenuManager.Instance.IsMenuOpen()) return;
        if (hoverParticles != null)
            hoverParticles.Show();
    }*/





    /*IEnumerator Bump()
    {
        float elapsed = 0f;
        float halfDuration = bumpDuration / 2f;

        while (elapsed < halfDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / halfDuration;
            transform.localScale = Vector3.Lerp(originalScale, originalScale * bumpScale, t);
            yield return null;
        }

        elapsed = 0f;
        while (elapsed < halfDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / halfDuration;
            transform.localScale = Vector3.Lerp(originalScale * bumpScale, originalScale, t);
            yield return null;
        }

        transform.localScale = originalScale;
    }

    void OnDrawGizmosSelected()
    {
        if (destination != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(destination.position, 0.3f);
            Gizmos.DrawLine(transform.position, destination.position);
        }
    }*/
}