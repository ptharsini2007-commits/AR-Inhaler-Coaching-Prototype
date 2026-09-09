using UnityEngine;
using TMPro;

public class CoachingInstruction : MonoBehaviour
{
    public TextMeshProUGUI instructionText;

    private string[] steps =
    {
        "Step 1: Position the inhaler correctly.",
        "Step 2: Prepare for inhalation.",
        "Step 3: Follow the guided breathing instruction.",
        "Step 4: Complete the inhaler action."
    };

    private int currentStep = 0;

    void Start()
    {
        ShowInstruction();
    }

    public void NextStep()
    {
        if (currentStep < steps.Length - 1)
        {
            currentStep++;
            ShowInstruction();
        }
        else
        {
            instructionText.text =
                "Coaching completed successfully!";
        }
    }

    void ShowInstruction()
    {
        instructionText.text = steps[currentStep];
    }
}