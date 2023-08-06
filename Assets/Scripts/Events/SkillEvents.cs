using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEvents : MonoBehaviour
{
    public static SkillEvents current;

    private void Awake() {
        current = this;
    }

    public event Action onSkillUsed;
    public void SkillUsed() {
        onSkillUsed?.Invoke();
    }

}
