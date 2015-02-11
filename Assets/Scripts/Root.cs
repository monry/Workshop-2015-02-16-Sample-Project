using UnityEngine;
using System.Collections;

public class Root : MonoBehaviour {

    public bool canPlay = true;

    public GameObject buttonReplay;

    /// <summary>
    /// Unity lifecycle: Start
    /// </summary>
    public void Start () {
        // Do nothing.
    }

    /// <summary>
    /// Unity lifecycle: Update
    /// </summary>
    public void Update () {
        // Do nothing.
    }

    /// <summary>
    /// リプレイボタン押下時のコールバック
    /// </summary>
    public void OnButtonReplayPressed() {
        // リプレイボタンを消す
        this.buttonReplay.SetActive(false);
        GameObject.FindWithTag("Ball").GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 100.0f);
        this.canPlay = true;
    }
}
