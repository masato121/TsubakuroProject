using UnityEngine;

using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace Scene
{

    /// <summary>
    /// ItemList制御クラス
    /// </summary>
    public class ItemListManager : MonoBehaviour
    {
        private int use_money;
        private int up_fat;
        private int up_kno;
        UserItemData status;

        /// <summary>
        /// ItemList内コンテンツオブジェクト
        /// </summary>
        [SerializeField]
        private GameObject _itemListContent = null;

        /// <summary>
        /// ItemNoede
        /// </summary>
        [SerializeField]
        private GameObject _itemNode = null;

  
        /// <summary>
        /// ItemNode内オブジェクト
        /// </summary>
        private Image _itemImage = null;
        private Text _itemName = null;

        /// <summary>
        /// Contents内オブジェクト
        /// </summary>
        private Text _itemDetail = null;

        /// <summary>
        /// アイテムマスタStruct
        /// </summary>
        public struct ItemListMaster
        {
            public int itemId;     // ItemId
            public string name;    // 名前
            public string detail;  // 詳細
            public int buy;        // 買値
            public int hungry;  // スキルタイプ
            public int kno;

            public ItemListMaster(int num, string Nam, string Det, int Buy, int Hun,int Kno)
            {
                itemId = num;
                name = Nam;
                detail = Det;
                buy = Buy;
                hungry = Hun;
                kno = Kno;
            }
        }

        /// <summary>
        /// ユーザー所持アイテムデータ
        /// </summary>
        private struct UserItemData
        {
            public int itemId; // アイテムId
            public bool isNew; // newフラグ
            public UserItemData(int num, bool New)
            {
                itemId = num;
                isNew = New;
            }
        }

        /// <summary>
        /// アイテムマスタリスト
        /// </summary>
        private List<ItemListMaster> _itemListMst = new List<ItemListMaster>();



        /// <summary>
        /// ユーザ所持アイテムデータリスト
        /// </summary>
        private List<UserItemData> _userItemDataLst = new List<UserItemData>();






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
            _itemListMst.Clear();

            _itemListMst.Add(new ItemListMaster(1, "背油ラーメン", "おいしい。", 300, 30,20));
            _itemListMst.Add(new ItemListMaster(2, "菊の花", "珍しい。", 100, 10,10));

            // UserItemDataロード
            _userItemDataLst.Clear();


            _userItemDataLst.Add(new UserItemData(1, true));
            _userItemDataLst.Add(new UserItemData(2, true));
        }
        /// <summary>
        /// 初期化処理
        /// </summary>
        void Start()
        {
            // TODO:テストデータのロード
            DebugDataLoad();

            // ItemNode内の各オブジェクトの取得
            _itemImage = _itemNode.transform.Find("ItemImg").GetComponent<Image>();
            _itemName = _itemNode.transform.Find("ItemName").GetComponent<Text>();

            // ItemList内の各オブジェクト取得
            _itemDetail = transform.Find("Contents/Detail").GetComponent<Text>();


            CreateItemList();

        }

        /// <summary>
        /// アイテムリスト生成処理
        /// </summary>


        /// <summary>
        /// 詳細設定処理
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cnt"></param>



        private void CreateItemList()
        {
            bool isFirst = true;

            if (!_isLoad)
            {
                // ユーザが所持しているアイテムの種類の数だけノードを生成
                foreach (UserItemData userData in _userItemDataLst)
                {
                    ItemListMaster itemData = _itemListMst.Find(local => local.itemId == userData.itemId);

                    if (itemData.itemId != null)
                    {
                        _itemName.text = itemData.name;

                        if (isFirst)
                        {
                            // 詳細部に１レコード目のデータの情報をセット
                            _itemDetail.text = itemData.detail;
                            isFirst = false;
                        }

                        // 別クラスに定義している子オブジェクトをインスタンス化するための関数
                        Button node = SetChild(_itemListContent, _itemNode).GetComponent<Button>();





                        // 参照渡しだとAddListner時に値がうまくセットされないため値渡しに変換
                        ItemListMaster data = itemData;
                        int buy = itemData.buy;
                        int ski = itemData.hungry;
                        int kno = itemData.kno;
                       // ノードクリック時に詳細が表示されるようにイベントを付与
                        node.onClick.AddListener(() => ItemSetting(data,buy,ski,kno));
                       
                       
                    }
                }
                _isLoad = true;
            }
        }
        private void ItemSetting(ItemListMaster data,int buy,int ski,int kno)
        {
            _itemDetail.text = data.detail;
            use_money = buy;
            up_fat = ski;
            up_kno = kno;
        }
        private Transform SetChild(GameObject itemListContent, GameObject itemNode)
        {
            // プレハブからインスタンスを生成
            GameObject obj = Instantiate(itemNode);

            // 作成したオブジェクトを子として登録
            obj.transform.SetParent(itemListContent.transform);

            obj.transform.localPosition = new Vector3(0f, 0f, 0f);
            obj.transform.localScale = new Vector3(1f, 1f, 1f);

            // 作成したオブジェクトの名前にが(Clone)がつかないようにプレハブの名前を再付与
            obj.name = (name != null) ? name : itemNode.name;

            return obj.transform;
        }
        public void PushButtonUse()
        {
            Para_text para = FindObjectOfType<Para_text>();
            if (para.money >= use_money)
            {

                para.money = para.money - use_money;
                para.Food = para.Food + up_fat;
                para.know = para.know + up_kno;
            }
        }

    }
}




