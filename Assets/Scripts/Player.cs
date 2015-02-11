using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    /// <summary>
    /// 左の壁に接触しているかどうか
    /// </summary>
    public bool hasTouchedWallLeft = false;

    /// <summary>
    /// 右の壁に接触しているかどうか
    /// </summary>
    public bool hasTouchedWallRight = false;

    /// <summary>
    /// 天井に接触しているかどうか
    /// </summary>
    public bool hasTouchedCeil = false;

    /// <summary>
    /// 床に接触しているかどうか
    /// </summary>
    public bool hasTouchedFloor = false;

    /// <summary>
    /// Canvas にアタッチしてある管理用コンポーネント
    /// </summary>
    private Root root;

    /// <summary>
    /// Unity lifecycle: Start
    /// </summary>
    public void Start () {
        this.root = this.gameObject.GetComponentInParent<Root>();
    }

    /// <summary>
    /// Unity lifecycle: Update
    /// </summary>
    public void Update () {
        // ゲームオーバー時にはキー操作を受け付けない
        if (!this.root.canPlay) {
            return;
        }

        // 移動距離を決定
        Vector3 moveDistance = Vector3.zero;
        if (Input.GetKey(KeyCode.A) && !this.hasTouchedWallLeft) {
            moveDistance.x = -5.0f;
        }
        if (Input.GetKey(KeyCode.D) && !this.hasTouchedWallRight) {
            moveDistance.x =  5.0f;
        }
        if (Input.GetKey(KeyCode.W) && !this.hasTouchedCeil) {
            moveDistance.y =  5.0f;
        }
        if (Input.GetKey(KeyCode.S) && !this.hasTouchedFloor) {
            moveDistance.y = -5.0f;
        }

        // 自身の "ローカル座標" を変更する
        this.transform.localPosition += moveDistance;
    }

    /// <summary>
    /// isTrigger: true なオブジェクトに於ける接触開始判定
    /// </summary>
    /// <param name="collider">当たったコライダ</param>
    public void OnTriggerEnter2D(Collider2D collider) {
        // 接触したオブジェクトが持つタグをチェック
        switch (collider.gameObject.tag) {
            case "WallLeft":
                this.hasTouchedWallLeft = true;
                break;
            case "WallRight":
                this.hasTouchedWallRight = true;
                break;
            case "Ceil":
                this.hasTouchedCeil = true;
                break;
            case "Floor":
                this.hasTouchedFloor = true;
                break;
        }
    }

    /// <summary>
    /// isTrigger: true なオブジェクトに於ける接触終了判定
    /// </summary>
    /// <param name="collider">離れたコライダ</param>
    public void OnTriggerExit2D(Collider2D collider) {
        // 離れたオブジェクトが持つタグをチェック
        switch (collider.gameObject.tag) {
            case "WallLeft":
                this.hasTouchedWallLeft = false;
                break;
            case "WallRight":
                this.hasTouchedWallRight = false;
                break;
            case "Ceil":
                this.hasTouchedCeil = false;
                break;
            case "Floor":
                this.hasTouchedFloor = false;
                break;
        }
    }

}
