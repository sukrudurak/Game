using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;


[System.Serializable]
public class item {

//	public string name;
	public Sprite imageTexture;
//	public Button.ButtonClickedEvent thingToDo;



}

public class Game : MonoBehaviour {
	public GameObject prefab;
	public Transform contentPanel;
	public List<item> itemlist;
	// Start ta hangi canvas gelmeli?
	static public int SelectedCanvas = 0;


	public static Game Instance;
	void Awake() {
		Instance = this;
		if (PlayerPrefs.HasKey("Language") == true) {
			SelectedCanvas = 1;
		} else {
			SelectedCanvas = 0;
		}
	/*	for (int z = 0; z < allWordsE.Count (); z++) {
			for (int i = 0; i < allWordsE[z].Count (); i++) {
				allWords.Add(allWordsE[z][i]);
				Debug.Log ("ccc"+WordList);
			}
		}*/
		}
	public void TurkceButton() {
		PlayerPrefs.SetString ("Language", "Turkce");
		SelectedCanvas = 1;

	}
	public void EnglishButton() {
		PlayerPrefs.SetString ("Language", "English");
		SelectedCanvas = 1;

	}
	public RectTransform content;

	public Button leftButton,rightButton,upButton;
	public Button startOverButton,	returnGameButton;
	static public bool DebugMode = true, buttonEnable = false,showAd = false,turnValue=false,turnValueBarrier=false;
	// Veritabanından hangi listeyi çekeceğimizi gösteren değişken
	public int WordList = 0;
	// Grup başına kaç sözcük soracağız
	int totalQuestions = 40;
	// Kaçıncı sözcükte kaldığımızı gösterir
	int lastQuestion = 0;
	public Animator catAnim,textAnim,rightAnim,leftAnim,upAnim;
	//Oyun durdurma
	public bool Paused = true;

	public TextMesh scoreText,loadingText;
	public GameObject loadingObject1;
	// Sözcük listeleri ve çevirileri
//	public List<string> allWords = new List<string>();
	public static List<string[]> allWords = new List<string[]> {

		/* Renkler       */ new string[] {"white", "silver", "gray", "black", "navy", "beige", "blue", "sky blue", "coral", "mauve", "turquoise", "azure", "cyan", "green", "lime",  "yellow", "gold", "amber", "orange", "brown", "red", "maroon", "rose", "red-violet", "pink", "magenta", "purple", "indigo", "violet",  "ochre",  "moss", "hazel"},
		/* Karışık       */ new string[] {"bus", "december", "doctor", "thursday", "february", "film", "dog", "january", "everyone", "july", "june", "coffee", "captain", "lion", "may", "man", "march", "monday", "morning", "name", "november", "october"},
	/* Vucut Bölümleri */    new string[] {"arm", "blood", "body", "ear", "eye", "face", "finger", "foot", "hair", "hand", "head", "heart", "knee", "leg", "lip", "mouth", "neck", "nose", "shoulder", "side", "skin", "stomach", "toe", "tooth", "brain", "chest", "hip", "thumb", "waist", "nail", "back"},
    /* Kıyafetler */    new string[] {"bag", "belt", "carry", "cloth", "coat", "dress", "hat", "jacket", "ring", "shirt", "shoe", "skirt", "sock", "wear", "boot", "glove ", "handbag", "jean", "scarf", "suit", "sweater", "trousers", "umbrella", "trainer", "watch", "tie", "shorts", "tights", "glasses", "sunglasses", "pyjamas", "get dressed", "get undressed", "put on", "take  off"},
	/*Conv1 */    new string[] {"goodbye", "greeting", "hello", "please", "sorry", "wish", "good morning", "good afternoon", "good evening", "hi", "see you soon", "good night", "sleep well", "bless you", "excuse me", "cheers", "happy birthday", "merry christmas", "happy new year", "good luck", "congratulations", "well done"},
		/*Conv 2  */    new string[] {"anyway", "actually", "let's go", "I don't mind", "It's up to you", "How about", "what about", "oh dear", "absolutely", "disappoint", "d*oesn't matter", "what a pity", "hurry up", "look out", "be careful", "I agree"},
		/* desc */    new string[] {"blue", "brown", "fat", "heavy", "height", "middle-age", "old", "pretty", "short", "tall", "thin", "young", "beautiful", "blonde", "elder", "fair", "long", "medium", "slim", "ugly", "overweight", "dark skin", "beard", "moustache", "good looking", "average looking"},
		/* Family */    new string[] {"cousin", "nephew", "niece", "relation", "relative", "grandparents", "granddaughter", "grandson", "aunt", "brother", "child", "children", "daughter", "family", "father", "grandfather", "grandmother", "husband", "morning", "parent", "uncle", "wife"},
			/* feeling */    new string[] {"angry", "bit", "cold", "happy", "hate", "hope", "horror", "hot", "hungry", "like", "love", "prefer", "sad", "want", "well", "thirsty", "tired", "upset", "surprise"},
			/* health */    new string[] {"asthma", "dentist", "headache", "panic", "relax", "vomit", "aspirin", "toothache", "sneeze", "malaria", "cholera", "cancer", "good for you", "bad", "breathe", "diet", "exercise", "feel", "fever", "fine", "fruit", "health", "healthy", "ill", "illness", "probably", "rest", "sick", "stress", "vegetable"},
			/*life  */    new string[] {"baby", "birth", "born", "call", "die", "marriage", "single", "wedding", "weight", "bride", "death", "divorce", "married", "separate", "widow", "groom", "honeymoon", "die of", "funeral"},};
	public static List<string[]> allTrans = new List<string[]> {

		/* Renkler       */ new string[] {"beyaz", "gümüş", "gri", "siyah", "lacivert", "bej", "mavi", "gök mavisi", "mercan", "eflatun", "turkuaz", "azur mavisi", "cam göbeği", "yeşil", "çim",  "sarı", "altuni", "kehribar", "turuncu", "kahverengi", "kırmızı", "bordo", "gül", "kırmızı mor", "pembe", "galibarda", "mor", "çivit", "menekşe",  "toprak boya", "yosun", "ela"},
		/* Karışık       */ new string[] {"otobüs", "aralık", "doktor", "perşembe", "şubat", "film", "köpek", "ocak", "herkes", "temmuz", "haziran", "kahve", "kaptan", "aslan", "mayıs", "erkek", "mart", "pazartesi", "sabah", "isim", "kasım", "ekim"},
			/* Vucut Bölümleri */    new string[] {"kol", "kan", "vücut", "kulak", "göz", "yüz", "parmak", "ayak", "saç", "el", "kafa", "kalp", "diz", "bacak", "dudak", "ağız", "boyun", "burun", "omuz", "yan", "deri", "karın", "ayak parmağı", "diş", "beyin", "göğüs", "kalça", "başparmak", "bel", "tırnak", "sırt"},
			/* Kıyafetler */    new string[] {"çanta", "kemer", "taşımak", "kumaş", "palto", "elbise", "şapka", "ceket", "yüzük", "gömlek", "ayakkabı", "etek", "çorap", "aşındırmak", "çizme", "eldiven", "el çantası", "kot pantolon", "atkı", "takım elbise", "süveter", "pantolon", "şemsiye", "spor ayakkabı", "saat", "kravat", "şort", "tayt", "gözlük", "güneş gözlüğü", "pijama", "giyinmek", "soyun", "giymek", "elbise çıkarmak"},
			/*Conv1 */    new string[] {"hoşçakal", "selamlama", "merhaba", "lütfen", "üzgün", "dilemek", "günaydın", "tünaydın", "iyi akşamlar", "merhaba", "görüşmek üzere", "iyi geceler", "rahat uyumak", "çok yaşa (hapşırınca)", "affedersiniz", "şerefe", "iyiki dogdun", "mutlu noeller", "mutlu yıllar", "bol şans", "tebrikler", "aferin" },
			/*Conv 2  */    new string[] {"neyse", "etrafında", "başka", "gerçekten", "ifade", "aslında", "hadi gidelim", "itirazım yok", "karar sizin", "ne dersin", "var mısın", "aman yarabbi", "mutlaka", "umudunu kırmak", "önemli değil", "vah vah", "acele etmek", "dışarı bakmak", "dikkat etmek", "bence de"},
			/* desc */    new string[] {"mavi", "kahverengi", "şişman", "ağır", "yükseklik", "orta yaşlı", "eski", "sevimli", "kısa", "uzun", "ince", "genç", "güzel", "sarışın", "yaşlı, büyük", "açık renkli", "uzun", "orta", "zayıf", "çirkin", "kilolu", "koyu ten", "sakal", "bıyık", "güzel", "sıradan görünüşlü"},
			/* Family */    new string[] {"kuzen", "erkek yeğen", "kız yeğen", "ilgi", "akraba", "büyükbaba, büyükanne", "kız torun", "erkek torun", "teyze,hala", "erkek kardeş", "çocuk", "çocuklar", "kız evlat", "aile", "baba", "büyükbaba", "büyükanne", "koca", "sabah", "ebeveyn", "amca-dayı", "eş-hanım" },
			/* feeling */    new string[] {"kızgın", "parça", "soğuk", "mutlu", "nefret etmek", "ummak", "korku", "sıcak", "aç", "hoşlanmak", "sevmek", "tercih etmek", "mutsuz", "istemek", "iyi", "susamış", "yorgun", "üzmek", "şaşırtmak"},
			/* health */    new string[] {"astım", "dişçi", "baş ağrısı", "panik", "rahatlamak", "kusmak", "aspirin", "diş agrısı", "hapşırmak", "sıtma", "kolera", "kanser", "aferin", "kötü", "nefes almak", "rejim", "egzersiz", "hissetmek", "ateş", "iyi", "meyve", "sağlık", "sağlıklı", "hasta", "hastalık", "muhtemelen", "dinlenmek", "hasta", "stres", "sebze"},
		/* life       */ new string[] {"bebek", "doğmak", "doğmuş", "arama", "ölmek", "evlilik", "tek", "düğün", "ağırlık", "gelin", "ölüm", "boşanmak", "evli", "ayırmak", "dul", "kadın", "damat", "balayı", "-den ölmek", "cenaze"},};
		public static List<string[]> allWordsR = new List<string[]> {
	new string[] {"деятельность", "добавить", "бояться", "black", "возраст",  "moss", "hazel"},

	new string[] {"объем", "любое", "бояться", "другой", "возраст",  "что-нибудь", "кто-нибудь"},
	};

		public static List<string[]> allTransR = new List<string[]> {
		new string[] {"деятельность", "добавить", "бояться", "black", "возраст",  "moss", "hazel"},

		new string[] {"объем", "любое", "бояться", "другой", "возраст",  "что-нибудь", "кто-нибудь"},
	};
	public List<string> tempWords, tempTrans = new List<string>();
	public TextMesh TextScore, TextWord, Text1, Text2, Text3, Text4, Text5, Text6, Text7, Text8, Text9, Text10, Text11, Text12,TextHeart,textAnswer;
	public GameObject barrier1, barrier2, barrier3, barrier4, barrier5, barrier6, barrier7, barrier8, barrier9, barrier10, barrier11, barrier12, barrier13, barrier14, barrier15, barrier16, barrier17, barrier18, barrier19, barrier20, barrier21, barrier22, barrier23, barrier24,barrier25, barrier26, barrier27, barrier28, barrier29,barrier30,barrier31,barrier32,barrier33,barrier34,barrier35,barrier36;
	public List<TextMesh> Texts = new List<TextMesh>();
	public List<GameObject> Barriers = new List<GameObject>();
	public List<string> saveAnswerFalse = new List<string>();
	public List<string> saveAnswerTrue = new List<string>();
	public GameObject heartObject;
	// Silindir üzerinde 4 sıra sözcük, her sırada ise 3 adet sözcük yan yana
	// Toplam 12 sözcük var. Her bir sırayı "1 turn" kabul edersek "4 turn" içinde silindir 1 tur atıyor
	public int turn = 1, score, randomOption,heart = 3,turnBarrier=1;
	public Canvas CanvasMenu, CanvasGame, CanvasMainMenu, CanvasGameSelect, CanvasSetting,CanvasSettingMenu, CanvasWordMenu;
	private GameObject gameSelectedButton,answerFalseButton;
	//public GameObject barrierInstantiate;
	// CanvasGameSelect te oluşturulan buton prefab nesnesi
	public GameObject buttons,buttonFalseWord;
	/*public GameObject randomBarrier1;
	public GameObject randomBarrier2;
	public GameObject randomBarrier3;*/
	public GameObject scroolView,Panel,PanelWrongWord;
	//CanvasGameSelect te gelecek olan konu listeleri
	public string[] selectedGroupArray2 =  {"Life-Yasam", "Health-Saglik", "Feeling-Hisler", "Family-Aile", "desc", "Conv2", "Conv1", "Kıyafetler", "Vucut","Others-Karışık", "Colours-Renkler" };

	private void CanvasSelect(int selected) {
		SelectedCanvas = selected;
	}
	void Start() {

		scoreText.gameObject.GetComponent<Renderer>().enabled = false;
		TextHeart.gameObject.GetComponent<Renderer>().enabled = false;
		heartObject.gameObject.GetComponent<Renderer>().enabled = false;
		loadingText.gameObject.GetComponent<Renderer>().enabled = false;
		loadingObject1.gameObject.GetComponent<Renderer>().enabled = false;
		//loadingObject2.gameObject.GetComponent<Renderer>().enabled = false;
		//Oyun sadece yatayda açılsın.
		Screen.orientation = ScreenOrientation.LandscapeLeft ;
	//	PlayerPrefs.GetInt ("heart");
	if (SelectedCanvas==0) {

			ShowCanvasMainMenu ();

			// Menü canvas'ını gizle
			HideCanvasMenu();
			HideCanvasSetting ();
			// GameSelect canvas'ını gizle
			HideCanvasGameSelect ();
			HideCanvasSettingMenu ();
			HideCanvasWordMenu ();
			// Reklam göster

	}

		if (SelectedCanvas==1) {
			ShowCanvasGameSelect ();
			//GameSelected ();
			HideCanvasMainMenu ();
			HideCanvasSetting ();
			HideCanvasSettingMenu ();
			HideCanvasMenu ();
			HideCanvasWordMenu ();

		}/* else {
			HideCanvasMainMenu ();
			HideCanvasMenu ();
			StartGame ();
			HideCanvasSetting ();
			HideCanvasSettingMenu ();
			HideCanvasWordMenu ();

		}*/
		AddBarriers ();
		DisableCollidersBarriers ();


		HideBarriers ();
		AddImage ();

	}
	// ************************************************** //
	// Textleri listeye ekleyelim
	void AddTexts() {
		Texts.Add(Text1); Texts.Add(Text2); Texts.Add(Text3);
		Texts.Add(Text4); Texts.Add(Text5); Texts.Add(Text6);
		Texts.Add(Text7); Texts.Add(Text8); Texts.Add(Text9);
		Texts.Add(Text10); Texts.Add(Text11); Texts.Add(Text12);
	/*	if (DebugMode)
			Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name + " OK");*/
	}
	void AddBarriers() {
		Barriers.Add(barrier1);Barriers.Add(barrier2);Barriers.Add(barrier3);Barriers.Add(barrier4);Barriers.Add(barrier5);
		Barriers.Add(barrier6);Barriers.Add(barrier7);Barriers.Add(barrier8);Barriers.Add(barrier9);Barriers.Add(barrier10);
		Barriers.Add(barrier11);Barriers.Add(barrier12);Barriers.Add(barrier13);Barriers.Add(barrier14);Barriers.Add(barrier15);
		Barriers.Add(barrier16);Barriers.Add(barrier17);Barriers.Add(barrier18);Barriers.Add(barrier19);Barriers.Add(barrier20);
		Barriers.Add(barrier21);Barriers.Add(barrier22);Barriers.Add(barrier23);Barriers.Add(barrier24);Barriers.Add(barrier25);
		Barriers.Add(barrier26);Barriers.Add(barrier27);Barriers.Add(barrier28);Barriers.Add(barrier29);Barriers.Add(barrier30);
		Barriers.Add(barrier31);Barriers.Add (barrier32);Barriers.Add(barrier33);Barriers.Add (barrier34);Barriers.Add(barrier35);Barriers.Add(barrier36);
	}
	private List<Sprite> availableIcons = new List<Sprite>();
	public Sprite image1, image2, image3, image4, image5, image6, image7, image8, image9, image10, image11, image12, image13;
	public Sprite resim;
	void AddImage() {
		availableIcons.Add (image1);		availableIcons.Add (image2);		availableIcons.Add (image3);		availableIcons.Add (image4);
		availableIcons.Add (image5);		availableIcons.Add (image6);		availableIcons.Add (image7);		availableIcons.Add (image8);
		availableIcons.Add (image9);		availableIcons.Add (image10);		availableIcons.Add (image11);	availableIcons.Add (image12); availableIcons.Add (image13);

	}
	public int randomNumberBarrier;
	public void Barrier() {
		 randomNumberBarrier = Utils.RandZ (36);
			// Collider'ları aç
		Barriers[randomNumberBarrier].GetComponent<Collider> ().enabled = true;
		Barriers[randomNumberBarrier].GetComponent<Renderer> ().enabled = true;
	}


	void CreateRandomWordList() {


		/*if (PlayerPrefs.GetString("Language")=="Turkce") {
			for (int i = 0; i < allWordsE[WordList].Count(); i++) {
				allWords.Add (allWordsE[WordList][i]);
			}

		}
		else if (PlayerPrefs.GetString("Language")=="English") {

		}
	*/

		// Havuzdan sözcük seçtikçe bir öncekinden farklı olmalı
		int lastIndex = 0;
		// Rastgele seçilmiş sözcük listesi hazırlayalım
		for (int i = 1; i <= totalQuestions; i++) {
			// Çek bir sayı
			int newIndex = Utils.RandZ(allWords[WordList].Count() - 1);
			// Çektiğimiz sayı son sayıyla aynıysa tekrar çek
			while (newIndex == lastIndex) {
				newIndex = Utils.RandZ(allWords[WordList].Count() - 1);

			}
			lastIndex = newIndex;
			tempWords.Add(allWords[WordList][lastIndex]); // For Debug: tempWords.ForEach(i => Debug.Log(i));
			tempTrans.Add(allTrans[WordList][lastIndex]);
		}

	}

	public void DisableColliders() {
		foreach (TextMesh text in Texts)
			text.gameObject.GetComponent<Collider>().enabled = false;
	}
	public void DisableCollidersBarriers() {
		foreach (GameObject barrier in Barriers)
			barrier.gameObject.GetComponent<Collider>().enabled = false;

	}
	public void HideBarriers ()
	{
		foreach (GameObject barrier in Barriers)
			barrier.gameObject.GetComponent<Renderer>().enabled = false;
	}
	public void DisableParticles() {
		foreach (TextMesh text in Texts)
			text.gameObject.GetComponent<ParticleSystem>().Stop();
	}

	public void SetTurn() {
		// Sınıra ulaştıysak başa dönelim, yoksa üçer üçer artıralım
		if (turn == 10) {
			turn = 1;
			turnValue = true;
		} else {
			turn += 3;
			turnValue = false;
		}
	}





	public void SetWords() {

		// totalQuestions kadar sözcük gösterdiysek oyun biter
		if (lastQuestion > totalQuestions) {

			Application.Quit();
		}



		// Havuzdan sözcük seçtikçe bir öncekinden farklı olmalı
		HashSet<string> tempTurnWords = new HashSet<string>();
		HashSet<string> tempTurnTrans = new HashSet<string>();

		// Üç birbirinden ve doğru cevaptan farklı seçenek eklemeliyiz
		for (int i = 1; i <= 3; i++) {
			int rand = Utils.RandZ(allWords[WordList].Count() - 1);
			string word = allWords[WordList][rand];
			// while (tempTurnWords.Contains(word) || tempTurnWords.Contains(tempWords[lastQuestion])) {
			while (tempTurnWords.Contains(word) ) {
				rand = (int)Utils.RandZ(allWords[WordList].Count() - 1);
				word =allWords[WordList][rand];

			}

			tempTurnWords.Add(word);
			//Eğer gelen sözcük iki veya daha fazla kelimeden oluşuyorsa newline işlemi yapılır.
			string theText = allTrans[WordList][rand];
			theText = theText.Replace (" ",System.Environment.NewLine);
			tempTurnTrans.Add (theText);
		}

		for (int i = -1; i <= 1; i++) {
			// Collider'ları aç
			Texts[turn + i].GetComponent<Collider>().enabled = true;
			// Etiketleri temizleyelim
			Texts[turn + i].tag = "FalseAnswer";
			if (turn==4) {
				Texts[turn + i-3].tag = "FalseAnswer";
			}
			else if (turn==7) {
				Texts[turn + i-3].tag = "FalseAnswer";
			}
			else if (turn==10) {
				Texts[turn + i-3].tag = "FalseAnswer";
			}
			else if (turnValue=true) {
				Texts[turn + i+9].tag = "FalseAnswer";
			}
			// Cevapları yerleştir
			Texts[turn + i].text = tempTurnTrans.ToArray()[1 + i];

		}

		// Sıradaki sözcüğü ekrana yaz.
		TextWord.text = tempWords[lastQuestion]; // Debug.Log("TextWord: " + tempWords[lastQuestion]);
		// Hangisi doğru cevap olacak? Üzerine yaz
		randomOption = Utils.RandZ(3);
		Texts[turn - 1 + randomOption].text = tempTrans[lastQuestion];
		Texts[turn - 1 + randomOption].tag = "TrueAnswer";
		Texts[turn - 1 + randomOption].text=Texts[turn - 1 + randomOption].text.Replace (" ",System.Environment.NewLine);
		int y=0;
		for (int i = -1; i <= 1; i++) {
			if (Texts[turn - 1 + randomOption].text==Texts[turn + i].text) {
				y++;
				if (y>=1 && Texts[turn + i].tag =="FalseAnswer") {

					Texts [turn + i].text = "merhaba";

				}}
			}



		// Bir sözcüğü daha bitirdik
		lastQuestion++;
		for (int i = -1; i <= 1; i++) {
			string textLenght = Texts [turn + i].text;
			if (textLenght.Length==5) {
				Texts [turn + i].characterSize = 0.35f;

			}
			else if(textLenght.Length>=6  && textLenght.Length<=8 ) {
				Texts [turn + i].characterSize = 0.24f;

			}
			else if(textLenght.Length>=8  && textLenght.Length<=10 ) {
				Texts [turn + i].characterSize = 0.2f;


			}
			else if(textLenght.Length>=10  && textLenght.Length<=12 ) {
				Texts [turn + i].characterSize = 0.15f;

			}
			else if(textLenght.Length>=12 && textLenght.Length<=25) {
				Texts [turn + i].characterSize = 0.13f;

			}
			else if(textLenght.Length>=25) {
				Texts [turn + i].characterSize = 0.1f;

			}

		}
	}

	public void AnswerTrue(Collider col) {
		Barrier ();
		barrierScore++;
		StartCoroutine(BarrierBegin());
		Texts[turn].text = "";
		Texts[turn + 1].text = "";
		Texts[turn - 1].text = "";
		score++;
		TextScore.text = "Puan: " + score;
		ParticleSystem ps = col.gameObject.GetComponent<ParticleSystem>();
		ps.startColor = new Color(0, 1, 0, 1);
		ps.Play();

	}

	public void AnswerFalse(Collider col) {

		if (col.gameObject.tag == "Barrier") {
			heart--;
			TextHeart.text = heart.ToString ();
			if (heart == 0) {
				ShowCanvasMenu ();
				startOverButton.GetComponentInChildren<Text> ().text = "YENİDEN OYNA";
				returnGameButton.gameObject.SetActive (false);
				textAnim.enabled = false;
				scoreText.gameObject.GetComponent<Renderer> ().enabled = false;

			}
		} else if (col.gameObject.tag == "FalseAnswer")  {
			heart--;
			TextHeart.text = heart.ToString();
			textAnswer.text = GameObject.FindWithTag ("TrueAnswer").GetComponent<TextMesh> ().text;
			string answerTrue = GameObject.FindWithTag ("TrueAnswer").GetComponent<TextMesh> ().text;
			string answer =	GameObject.FindWithTag ("TextWord").GetComponent<TextMesh> ().text;
			saveAnswerFalse.Add (answer);
			saveAnswerTrue.Add (answerTrue);

			Texts [turn].text = "";
			Texts [turn + 1].text = "";
			Texts [turn - 1].text = "";



			ParticleSystem ps = col.gameObject.GetComponent<ParticleSystem> ();
			ps.startColor = new Color (1, 0, 0, 1);
			ps.Play ();


			if (heart > 0) {
				StartCoroutine (AnswerFalseBegin ());
			}
		}
	  if (heart==0) {
				ShowAd();

			ShowCanvasMenu() ;
			startOverButton.GetComponentInChildren<Text>().text = "RE-START";
			returnGameButton.gameObject.SetActive (false);
			textAnim.enabled = false;
		}
  if (score==40) {


			ShowCanvasMenu() ;
			returnGameButton.gameObject.SetActive (false);
			textAnim.enabled = false;
			//Debug.Log ("hello");
		}


}
	// Silindir kedi ve text animasyonlarını durduralım.
	public void GamePause() {
		Paused = true;
		catAnim.SetTrigger("Idle");
		textAnim.enabled = false;
	}
	// Silindir kedi ve text animasyonlarını açalım.
	public void GameResume() {
		Paused = false;
		catAnim.SetTrigger("Run");
		textAnim.enabled = true;
	}
	public void CatRun() {

		catAnim.SetTrigger("Run");

	}
	//Oyunu devam ettirelim
	public void ReturnGame() {
		buttonEnable = true;
		GameResume();
		HideCanvasMenu ();
		ShowCanvasGame ();
	}
	//Oyunu yeniden oynayalım
	public void StartOver() {

		SceneManager.LoadScene (0);
	}
	public void SelectedWordGroup(int j)
	{
		WordList = 10-j;
		StartCoroutine (SelectedWordGroupBegin ());

	}

	IEnumerator SelectedWordGroupBegin()
	{
		var btn=UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
		btn.GetComponent<Image> ().color = Color.gray;
		yield return WaitForRealSeconds(1);
		StartGame ();
	}

	public void StartGame() {

		HideCanvasGameSelect ();
		StartCoroutine(ButtonBegin ());
		StartCoroutine(Begin());

	}

	public void GameSelect() {
		HideCanvasMainMenu();
		ShowCanvasGameSelect ();
	}

	public void AnotherGame() {
		SceneManager.LoadScene (0);
	}

	public void ShowCanvasMenu() {

		// Önce oyunu duraklatalım
		GamePause();
		buttonEnable = false;
		// Oyun canvas'ını gizleyelim
		HideCanvasGame();
		// Menüyü gösterelim
		CanvasMenu.GetComponent<CanvasGroup>().alpha = 1;
		CanvasMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void HideCanvasMenu() {
		CanvasMenu.GetComponent<CanvasGroup>().alpha = 0;
		CanvasMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void ShowCanvasGame() {
		CanvasGame.GetComponent<CanvasGroup>().alpha = 1;
		CanvasGame.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void ShowCanvasMainMenu() {
		CanvasMainMenu.GetComponent<CanvasGroup>().alpha = 1;
		CanvasMainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void HideCanvasMainMenu() {
		CanvasMainMenu.GetComponent<CanvasGroup>().alpha = 0;
		CanvasMainMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void ShowCanvasGameSelect() {

		CanvasGameSelect.GetComponent<CanvasGroup>().alpha = 1;
		CanvasGameSelect.GetComponent<CanvasGroup>().blocksRaycasts = true;
		GameSelected ();
	}

	public void HideCanvasGameSelect() {
		CanvasGameSelect.GetComponent<CanvasGroup>().alpha = 0;
		CanvasGameSelect.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void HideCanvasGame() {
		CanvasGame.GetComponent<CanvasGroup>().alpha = 0;
		CanvasGame.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	public void ShowCanvasSetting() {
		//GameSelected ();
		CanvasSetting.GetComponent<CanvasGroup>().alpha = 1;
		CanvasSetting.GetComponent<CanvasGroup>().blocksRaycasts = true;

	}

	public void HideCanvasSetting() {
		CanvasSetting.GetComponent<CanvasGroup>().alpha = 0;
		CanvasSetting.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	public void ShowCanvasSettingMenu() {
		//GameSelected ();
		CanvasSettingMenu.GetComponent<CanvasGroup>().alpha = 1;
		CanvasSettingMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void HideCanvasSettingMenu() {
		CanvasSettingMenu.GetComponent<CanvasGroup>().alpha = 0;
		CanvasSettingMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	public void ShowCanvasWordMenu() {
		GamePause();
		CanvasWordMenu.GetComponent<CanvasGroup>().alpha = 1;
		CanvasWordMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void HideCanvasWordMenu() {
		CanvasWordMenu.GetComponent<CanvasGroup>().alpha = 0;
		CanvasWordMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	void OnMouseDown(string TName) {
		//GameSelect canvasında hangi butonu seçtiysek o dizi içindeki kelimeler oyuna gelsin
		for (int i = 0; i <= 9; i++) {


		if (TName==selectedGroupArray2[i]) {
			WordList = 10-i;
		}
		}
		StartGame ();
	}

	public void AnswerFalseAllWord() {
		for (int i = 0; i < saveAnswerFalse.Count; i++) {
			answerFalseButton = Instantiate(buttonFalseWord, new Vector3(950, -110 * (i-8) , 500), Quaternion.identity) as GameObject;
			answerFalseButton.GetComponentInChildren<Text> ().fontSize = 52;
			answerFalseButton.transform.SetParent(PanelWrongWord.transform, true);
			answerFalseButton.GetComponentInChildren<Text>().text =saveAnswerFalse[i]+"="+saveAnswerTrue[i];
			answerFalseButton.name=saveAnswerFalse[i];
			Button b = answerFalseButton.GetComponent<Button>();

			string tName = answerFalseButton.name;
			b.onClick.AddListener(() => OnMouseDown(tName));
		}
	}

	Texture2D texture;
	public void GameSelected() {
		// Gameselect kısmı dinamik çalışacaksa  burayı aç!
		int y=0;
		int x = 0;
		for (int i = 0; i < selectedGroupArray2.Length; i++) {
			//texture = (Texture2D) Resources.Load ("clouds1024");
			//gameSelectedButton.GetComponentInChildren<Renderer>().material.mainTexture = texture;
			//Debug.Log ("NESİM"+availableIcons[i+1].texture);
			/*if (i % 3 == 0) {
				y = y +50;
				x = 700;
				gameSelectedButton = Instantiate (buttons, new Vector3 (x, y, 100), Quaternion.identity) as GameObject;
			} else if (i % 3 != 0) {

				x = x + 200;


				gameSelectedButton = Instantiate (buttons, new Vector3 (x, y, 100), Quaternion.identity) as GameObject;
			}
*/        gameSelectedButton = Instantiate (buttons, new Vector3 (x, y, 20), Quaternion.identity) as GameObject;
			gameSelectedButton.GetComponentInChildren<Text> ().fontSize = 45;

		//	gameSelectedButton.AddComponent<SpriteRenderer> ().sprite = availableIcons [5];
			gameSelectedButton.GetComponentInChildren<RawImage>().texture =  resim.texture;
		//	 resim.texture.width= 5;
		//	gameSelectedButton.GetComponentInChildren<Image>().mainTexture= GameObject.FindWithTag ("Icon").GetComponent<Image> ().mainTexture;
			gameSelectedButton.transform.localScale = new Vector3 (1,1,1);
			gameSelectedButton.GetComponentInChildren<Text> ().transform.localScale = new Vector3 (1f,1f,1f);
			gameSelectedButton.transform.SetParent(content.transform, true);
			gameSelectedButton.GetComponentInChildren<Text>().text = selectedGroupArray2[i];
		//	gameSelectedButton.GetComponentInChildren<RawImage> ().texture = availableIcons [i];
			gameSelectedButton.name=selectedGroupArray2[i];
			Button b = gameSelectedButton.GetComponent<Button>();


			string tName = gameSelectedButton.name;
			b.onClick.AddListener(() => OnMouseDown(tName));
		}
}
	//GameSelected canvasındaki geri tuşuna bastıgımızda canvastaki instantiate edilen butonları kaldıralım
	public void BackSpace() {
	/*	foreach (Transform child in Panel.transform) {
			GameObject.Destroy(child.gameObject);
		}*/
		HideCanvasGameSelect();

	//	ShowCanvasMainMenu ();
	}
		//  Oyundan çıkalım
	public void ExitGame() {
		Application.Quit();
	}

	public void ShowAd() {
		//if (Advertisement.IsReady())
		{
		//	Advertisement.Show();

			if (SelectedCanvas == 0) {
			//	heart = heart + 6;

			} else {
			//	heart = heart + 3;
			}
			TextHeart.text = heart.ToString ();
		//	PlayerPrefs.SetInt("heart", heart);
		}
	}
	public int barrierScore=0;
	IEnumerator BarrierBegin()
	{
		if (barrierScore>=6) {
		yield return WaitForRealSeconds(20);
		foreach (GameObject barrier in Barriers) {
				DisableCollidersBarriers ();
				HideBarriers ();
				barrierScore = 0;
			}
		}
		}



	int timeRemaining = 3;
	public Button buttonMenu;

	IEnumerator AnswerFalseBegin()
	{
		buttonMenu.gameObject.SetActive (false);
		// Kediyi hareketlendir; Idle_B hareketini yapacak
		catAnim.enabled = true;

		// 3...
		yield return WaitForRealSeconds(1);
		timeRemaining--;
		// 2...
		yield return WaitForRealSeconds(1);
		timeRemaining--;
		// 1...
		yield return WaitForRealSeconds(1);
		// Başla...
		textAnswer.text = "";
		yield return WaitForRealSeconds(1);
		// Sayacı başa saralım
		timeRemaining = 3;
		// Oyun canvas'ını göster.
		ShowCanvasGame();
		// Textleri listeye ekleyelim.
		AddTexts();
		// Oyuncunun seçtiği sözcük grubundan yeni ve rastgele bir liste oluşturalım.
		CreateRandomWordList();
		// Tüm collider'ları kapatalım.
		DisableColliders();
		// İlk sözcükleri alalım.
		SetWords();
		// Koş kedi koş...
		catAnim.SetTrigger("Run");
		// Oyunu başlatabiliriz.
		GameResume();
		buttonEnable = true;
		buttonMenu.gameObject.SetActive (true);
	}

	IEnumerator ButtonBegin()
	{

		rightAnim.enabled = true;
		yield return WaitForRealSeconds(1);

		leftAnim.enabled = true;
		yield return WaitForRealSeconds(1);

		upAnim.enabled=true;
		yield return WaitForRealSeconds(1);


	}
	IEnumerator Begin()
	{

		loadingText.gameObject.GetComponent<Renderer>().enabled = true;
		loadingObject1.gameObject.GetComponent<Renderer>().enabled = true;
	//	loadingObject2.gameObject.GetComponent<Renderer>().enabled = true;


		// Kediyi hareketlendir; Idle_B hareketini yapacak
		catAnim.enabled = true;
		// 3...
		//TextWord.text = ((int)timeRemaining).ToString();
	//	yield return WaitForRealSeconds(1);		timeRemaining--;
		// 2...
		//TextWord.text = ((int)timeRemaining).ToString();
	//	yield return WaitForRealSeconds(1);
	//	timeRemaining--;
		// 1...
		//TextWord.text = ((int)timeRemaining).ToString();
		yield return WaitForRealSeconds(1);
		// Başla...
		loadingText.gameObject.GetComponent<Renderer>().enabled = false;
		loadingObject1.gameObject.GetComponent<Renderer>().enabled = false;
	//	loadingObject2.gameObject.GetComponent<Renderer>().enabled = false;
		TextWord.text ="START";

		textAnswer.text = "";

		yield return WaitForRealSeconds(1);
		// Sayacı başa saralım
		timeRemaining = 3;
		// Oyun canvas'ını göster
		ShowCanvasGame();
		// Textleri listeye ekleyelim
		AddTexts();
		// Oyuncunun seçtiği sözcük grubundan yeni ve rastgele bir liste oluşturalım
		CreateRandomWordList();
		// Tüm collider'ları kapatalım
		DisableColliders();
		// İlk sözcükleri alalım
		SetWords();
		// Koş kedi koş...
		catAnim.SetTrigger("Run");
		// Oyunu başlatabiliriz
		GameResume();
		buttonEnable = true;
		scoreText.gameObject.GetComponent<Renderer>().enabled = true;
		TextHeart.gameObject.GetComponent<Renderer>().enabled = true;
		heartObject.gameObject.GetComponent<Renderer>().enabled = true;


		if (heart>=10) {
			TextHeart.fontSize = 170;
		}



	}

	public static IEnumerator WaitForRealSeconds(float time)
	{
		float start = Time.realtimeSinceStartup;
		while (Time.realtimeSinceStartup < start + time)
		{
			yield return null;
		}
	}
}
