using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboTextsContainer : MonoBehaviour
{
    // List of texts to update the gui
    [SerializeField]
    private List<Text> comboSetNames1Texts;
    public List<Text> ComboSetNames1Texts { get { return this.comboSetNames1Texts; } }
}
