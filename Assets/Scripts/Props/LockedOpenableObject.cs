using UnityEngine;
using System.Collections;

public class LockedOpenableObject : OpenableObject
{
    public int RequiredNumberOfKeys;

    protected override bool Unlocked(Character interacter)
    {
        int keyCount = interacter.GetKeyCount;
        if (keyCount >= RequiredNumberOfKeys) // TODO should later change this to check for key type (chest, door, elemental, whatever)
        {
            return true;
        }

        return false;
    }
}
