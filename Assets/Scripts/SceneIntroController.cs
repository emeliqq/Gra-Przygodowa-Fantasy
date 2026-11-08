
using System.Collections;
using UnityEngine;

public class SceneIntroController : MonoBehaviour
{
    [Header("Character")]
    public Animator characterAnimator;

    [Header("Backpack")]
    public Backpack backpack;

    [Header("Narrator")]
    public GameObject narratorPanel;

    [Header("Settings")]
    public float narratorDuration = 10f;

    private IEnumerator Start()
    {
        // Show narrator
        narratorPanel.SetActive(true);

        // Wait for narrator
        yield return new WaitForSeconds(narratorDuration);

        // Hide narrator
        narratorPanel.SetActive(false);

        // Play idle animation once
        characterAnimator.Play("Idle_NoBackpack", 0, 0f);

        // Wait until Animator updates
        yield return null;

        // Get animation duration
        float animationDuration =
            characterAnimator.GetCurrentAnimatorStateInfo(0).length;

        // Wait until animation finishes
        yield return new WaitForSeconds(animationDuration);

        // Enable backpack interaction
        backpack.EnableInteraction();

        Debug.Log("Idle finished. Backpack interaction enabled.");
    }
}
