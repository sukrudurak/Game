using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
//using frame8.Logic.Misc.Visual.UI.ScrolRectItemsAdapter;
public class Menu : MonoBehaviour {
/*	public Texture2D[] availableIcons;
	public RectTransform prefab;
	public Text countText;
	public ScrollRect scrollView;
	public RectTransform content;

	List<ExampleItemView> views = new List<ExampleItemView>();
	public string[] selectedGroupArray2 =  {"Life", "Health", "Feeling", "Aile", "desc", "Conv2", "Conv1", "Kıyafetler", "Vucut", "Renkler", "Karışık"};

	void Start () {
	
	}
	
	public void UpdateItems()
	{
		int newCount;
		int.TryParse (countText.text, out newCount);
		StartCoroutine (FetchItemModelsFromServer (newCount, results => OnReceivedNewMedls (results)));
		}

	void OnReceivedNewMedls(ExampleItemModel[] models)
	{
		foreach (Transform child in content) 
			Destroy (child.gameObject);
			views.Clear ();
			int i = 0;
			foreach (var model in models) {
				var instance = GameObject.Instantiate (prefab.gameObject) as GameObject;
				instance.transform.SetParent (content , false);
			   
			var view = InitializeItemView (instance, model);
				views.Add (view);
				++i;
			}
		}

	ExampleItemView InitializeItemView(GameObject viewGameObject, ExampleItemModel model)
	{
		ExampleItemView view = new ExampleItemView (viewGameObject.transform);
	

		return view;
	}
		
		IEnumerator FetchItemModelsFromServer(int count, Action<ExampleItemModel[]> onDone)
		{
			yield return new WaitForSeconds(2f);

		var results = new ExampleItemModel[selectedGroupArray2.Length];
		for (int i = 0; i < selectedGroupArray2.Length; ++i) {


				results[i] = new ExampleItemModel();
				results[i].title = "Item "+i;
				results[i].icon1Index= UnityEngine.Random.Range(0, availableIcons.Length);
				results[i].icon2Index= UnityEngine.Random.Range(0, availableIcons.Length);
				results[i].icon3Index= UnityEngine.Random.Range(0, availableIcons.Length);

			}

			onDone(results);
		}


		public class ExampleItemView
		{
			public Text titleText;
		public RawImage icon1Image, icon2Image, icon3Image;

			public ExampleItemView (Transform rootView)
			{
			Debug.Log("");
			/*	titleText = rootView.Find("TitlePanel/TitleText").GetComponent<Text>();
			icon1Image = rootView.Find("Icon1Image").GetComponent<RawImage>();
			icon2Image = rootView.Find("Icon2Image").GetComponent<RawImage>();
			icon3Image = rootView.Find("TitlePanel/Icon3Image").GetComponent<RawImage>();

			}
		}

		public class ExampleItemModel
		{
			public string title;
			public int icon1Index, icon2Index, icon3Index;


		}

	*/
}
