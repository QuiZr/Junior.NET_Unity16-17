using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Changes the Text compoment on game object to sting: "Score: + current score"
/// </summary>
public class ScoreDisplayer : MonoBehaviour
{
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        // A more elegant solution to displaying score would be
        // to add and event in ScoreManager, subscribe to it,
        // and call it every time the score has changed
        // but since events and delegates were not covered we
        // won't use them. Instead we're just refreshing the text
        // component every frame.
        text.text = "Score: " + ScoreManager.Instance.Score;
    }
}
