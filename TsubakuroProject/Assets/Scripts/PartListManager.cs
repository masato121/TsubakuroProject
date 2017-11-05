using UnityEngine;

using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Novel;
using UnityEngine.SceneManagement;

namespace Scene
{

    /// <summary>
    /// ItemList制御クラス
    /// </summary>
    public class PartListManager : MonoBehaviour
    {
        private string scenenum;
        UserPartData status;

        /// <summary>
        /// ItemList内コンテンツオブジェクト
        /// </summary>
        [SerializeField]
        private GameObject _partListContent = null;

        /// <summary>
        /// ItemNoede
        /// </summary>
        [SerializeField]
        private GameObject _partNode = null;


        /// <summary>
        /// ItemNode内オブジェクト
        /// </summary>
        private UnityEngine.UI.Image _partImage = null;
        private Text _partName = null;

        /// <summary>
        /// Contents内オブジェクト
        /// </summary>
        private Text _partDetail = null;
 

        /// <summary>
        /// アイテムマスタStruct
        /// </summary>
        public struct PartListMaster
        {
            public int partId;     // ItemId
            public string name;    // 名前
            public string detail;  // 詳細

            public PartListMaster(int num, string Nam, string Det)
            {
                partId = num;
                name = Nam;
                detail = Det;
            }
        }

        /// <summary>
        /// ユーザー所持アイテムデータ
        /// </summary>
        private struct UserPartData
        {
            public int partId; // アイテムId
            public bool isNew; // newフラグ
            public UserPartData(int num, bool New)
            {
                partId = num;
                isNew = New;
            }
        }

        /// <summary>
        /// アイテムマスタリスト
        /// </summary>
        private List<PartListMaster> _partListMst = new List<PartListMaster>();



        /// <summary>
        /// ユーザ所持アイテムデータリスト
        /// </summary>
        private List<UserPartData> _userPartDataLst = new List<UserPartData>();






        /// <summary>
        /// リストロードフラグ
        /// </summary>
        private bool _isLoad = false;

        /// <summary>
        /// デバッグデータロード処理
        /// TODO:後で削除
        /// </summary>
        private void DebugDataLoad()
        {
            // ItemMasterデータロード
            _partListMst.Clear();

            _partListMst.Add(new PartListMaster(1, "ラーメン店", "忙しい。"));
            _partListMst.Add(new PartListMaster(2, "鎚起銅器", "難しい。"));

            // UserItemDataロード
            _userPartDataLst.Clear();


            _userPartDataLst.Add(new UserPartData(1, true));
            _userPartDataLst.Add(new UserPartData(2, true));
        }
        /// <summary>
        /// 初期化処理
        /// </summary>
        void Start()
        {
            // TODO:テストデータのロード
            DebugDataLoad();

            // ItemNode内の各オブジェクトの取得
            _partImage = _partNode.transform.Find("PartImg").GetComponent<UnityEngine.UI.Image>();
            _partName = _partNode.transform.Find("PartName").GetComponent<Text>();

            // ItemList内の各オブジェクト取得
            _partDetail = transform.Find("PContents/Detail").GetComponent<Text>();

            CreatePartList();

        }

        /// <summary>
        /// アイテムリスト生成処理
        /// </summary>


        /// <summary>
        /// 詳細設定処理
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cnt"></param>



        private void CreatePartList()
        {
            bool isFirst = true;

            if (!_isLoad)
            {
                // ユーザが所持しているアイテムの種類の数だけノードを生成
                foreach (UserPartData userData in _userPartDataLst)
                {
                    PartListMaster partData = _partListMst.Find(local => local.partId == userData.partId);

                    if (partData.partId != null)
                    {
                        _partName.text = partData.name;

                        if (isFirst)
                        {
                            // 詳細部に１レコード目のデータの情報をセット
                            _partDetail.text = partData.detail;
                            isFirst = false;
                        }

                        // 別クラスに定義している子オブジェクトをインスタンス化するための関数
                        Button node = SetChild(_partListContent, _partNode).GetComponent<Button>();





                        // 参照渡しだとAddListner時に値がうまくセットされないため値渡しに変換
                        PartListMaster data = partData;
                        // ノードクリック時に詳細が表示されるようにイベントを付与
                        node.onClick.AddListener(() => ItemSetting(data,userData.partId));


                    }
                }
                _isLoad = true;
            }
        }
        private void ItemSetting(PartListMaster data,int num)
        {
            _partDetail.text = data.detail;
            scenenum = "part"+num.ToString();
        }
        private Transform SetChild(GameObject partListContent, GameObject partNode)
        {
            // プレハブからインスタンスを生成
            GameObject obj = Instantiate(partNode);

            // 作成したオブジェクトを子として登録
            obj.transform.SetParent(partListContent.transform);

            obj.transform.localPosition = new Vector3(0f, 0f, 0f);
            obj.transform.localScale = new Vector3(1f, 1f, 1f);

            // 作成したオブジェクトの名前にが(Clone)がつかないようにプレハブの名前を再付与
            obj.name = (name != null) ? name : partNode.name;

            return obj.transform;
        }
        public void PushButtonGo()
        {
            SceneManager.LoadScene(scenenum);

        }

    }
}
