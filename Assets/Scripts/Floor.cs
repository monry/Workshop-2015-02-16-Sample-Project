using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {

    /// <summary>
    /// Canvas にアタッチしてある管理用コンポーネント
    /// </summary>
    private Root root;

    /// <summary>
    /// Unity lifecycle: Start
    /// </summary>
    public void Start () {
        // ボールが接触したらゲームオーバー扱いにしたいので保持しておく
        // FindObjectOfType はちょっと重いので、あまりオススメしないけどね。
        this.root = GameObject.FindObjectOfType<Root>();
    }

    /// <summary>
    /// Unity lifecycle: Update
    /// </summary>
    public void Update () {
        // Do nothing.
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        // ボールが触れたときにゲームオーバーとする
        if (collision.gameObject.tag == "Ball") {
            this.root.buttonReplay.SetActive(true);
            this.root.canPlay = false;
        }
    }
}
