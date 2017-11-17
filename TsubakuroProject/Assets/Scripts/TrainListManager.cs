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
    public class TrainListManager : MonoBehaviour
    {
        private string scenenum;
        UserTrainData status;

        /// <summary>
        /// ItemList内コンテンツオブジェクト
        /// </summary>
        [SerializeField]
        private GameObject _trainListContent = null;

        /// <summary>
        /// ItemNoede
        /// </summary>
        [SerializeField]
        private GameObject _trainNode = null;


        /// <summary>
        /// ItemNode内オブジェクト
        /// </summary>
        private UnityEngine.UI.Image _trainImage = null;
        private Text _trainName = null;

        /// <summary>
        /// Contents内オブジェクト
        /// </summary>
        private Text _trainDetail = null;


        /// <summary>
        /// アイテムマスタStruct
        /// </summary>
        public struct TrainListMaster
        {
            public int trainId;     // ItemId
            public string name;    // 名前
            public string detail;  // 詳細

            public TrainListMaster(int num, string Nam, string Det)
            {
                trainId = num;
                name = Nam;
                detail = Det;
            }
        }

        /// <summary>
        /// ユーザー所持アイテムデータ
        /// </summary>
        private struct UserTrainData
        {
            public int trainId; // アイテムId
            public bool isNew; // newフラグ
            public UserTrainData(int num, bool New)
            {
                trainId = num;
                isNew = New;
            }
        }

        /// <summary>
        /// アイテムマスタリスト
        /// </summary>
        private List<TrainListMaster> _trainListMst = new List<TrainListMaster>();



        /// <summary>
        /// ユーザ所持アイテムデータリスト
        /// </summary>
        private List<UserTrainData> _userTrainDataLst = new List<UserTrainData>();






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
            _trainListMst.Clear();

            _trainListMst.Add(new TrainListMaster(1, "飛翔", "必須。"));
            _trainListMst.Add(new TrainListMaster(2, "回避", "これまた必須。"));

            // UserItemDataロード
            _userTrainDataLst.Clear();


            _userTrainDataLst.Add(new UserTrainData(1, true));
            _userTrainDataLst.Add(new UserTrainData(2, true));
        }
        /// <summary>
        /// 初期化処理
        /// </summary>
        void Start()
        {
            // TODO:テストデータのロード
            DebugDataLoad();

            // ItemNode内の各オブジェクトの取得
            _trainImage = _trainNode.transform.Find("TrainImg").GetComponent<UnityEngine.UI.Image>();
            _trainName = _trainNode.transform.Find("TrainName").GetComponent<Text>();

            // ItemList内の各オブジェクト取得
            _trainDetail = transform.Find("TContents/Detail").GetComponent<Text>();

            CreateTrainList();

        }

        /// <summary>
        /// アイテムリスト生成処理
        /// </summary>


        /// <summary>
        /// 詳細設定処理
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cnt"></param>



        private void CreateTrainList()
        {
            bool isFirst = true;

            if (!_isLoad)
            {
                // ユーザが所持しているアイテムの種類の数だけノードを生成
                foreach (UserTrainData userData in _userTrainDataLst)
                {
                    TrainListMaster trainData = _trainListMst.Find(local => local.trainId == userData.trainId);

                    if (trainData.trainId != null)
                    {
                        _trainName.text = trainData.name;

                        if (isFirst)
                        {
                            // 詳細部に１レコード目のデータの情報をセット
                            _trainDetail.text = trainData.detail;
                            isFirst = false;
                        }

                        // 別クラスに定義している子オブジェクトをインスタンス化するための関数
                        Button node = SetChild(_trainListContent, _trainNode).GetComponent<Button>();





                        // 参照渡しだとAddListner時に値がうまくセットされないため値渡しに変換
                        TrainListMaster data = trainData;
                        // ノードクリック時に詳細が表示されるようにイベントを付与
                        node.onClick.AddListener(() => ItemSetting(data, userData.trainId));


                    }
                }
                _isLoad = true;
            }
        }
        private void ItemSetting(TrainListMaster data, int num)
        {
            _trainDetail.text = data.detail;
            scenenum = "train" + num.ToString();
        }
        private Transform SetChild(GameObject trainListContent, GameObject trainNode)
        {
            // プレハブからインスタンスを生成
            GameObject obj = Instantiate(trainNode);

            // 作成したオブジェクトを子として登録
            obj.transform.SetParent(trainListContent.transform);

            obj.transform.localPosition = new Vector3(0f, 0f, 0f);
            obj.transform.localScale = new Vector3(1f, 1f, 1f);

            // 作成したオブジェクトの名前にが(Clone)がつかないようにプレハブの名前を再付与
            obj.name = (name != null) ? name : trainNode.name;

            return obj.transform;
        }
        public void PushButtonGo()
        {
            SceneManager.LoadScene(scenenum);

        }

    }
}

