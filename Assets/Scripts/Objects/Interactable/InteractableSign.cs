using System.Collections;
using UnityEngine;

public class InteractableSign : InteractableBase {

    public string Text;

    public override void OnInteract(Character character)
    {
        if (DialogBox.IsVisible())
        {
            character.Movement.SetFrozen(false, true);
            DialogBox.Hide();
        }
        else
        {
            //doesn't reset stop animation properly, https://youtu.be/TUkMjX4tzkk?t=1h37m43s
            character.Movement.SetFrozen(true, true);
            DialogBox.Show(Text);
        }
    }
}
