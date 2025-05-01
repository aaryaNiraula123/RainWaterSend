using UnityEngine;

public class ToggleCanvasWithKey : MonoBehaviour
{
    public GameObject tankInfoPanel;     // UI panel for tank
    public GameObject filterInfoPanel;   // UI panel for filter
    public Transform playerArmature;     // Drag the PlayerArmature here
    public Transform tankObject;         // Drag the Tank object here
    public Transform filterObject;       // Drag the Filter object here
    public float triggerDistance = 5f;   // Distance required to trigger

    void Update()
    {
        // Toggle Tank Info Panel with 'I'
        if (Input.GetKeyDown(KeyCode.I))
        {
            float distance = Vector3.Distance(playerArmature.position, tankObject.position);
            Debug.Log("Distance to tank: " + distance);

            if (distance <= triggerDistance)
            {
                tankInfoPanel.SetActive(!tankInfoPanel.activeSelf);
            }
            else
            {
                Debug.Log("Too far to show tank info panel.");
            }
        }

        // Toggle Filter Info Panel with 'F'
        if (Input.GetKeyDown(KeyCode.F))
        {
            float distance = Vector3.Distance(playerArmature.position, filterObject.position);
            Debug.Log("Distance to filter: " + distance);

            if (distance <= triggerDistance)
            {
                filterInfoPanel.SetActive(!filterInfoPanel.activeSelf);
            }
            else
            {
                Debug.Log("Too far to show filter info panel.");
            }
        }
    }
}
