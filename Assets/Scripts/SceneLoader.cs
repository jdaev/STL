using Base;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject levelSelectorPanel;
    [SerializeField] private Transform levelSelectorContentParent;
    [SerializeField] private GameObject levelButton;
    private const string GameScene = "GameScene";

    private void LoadGameScene(string level)
    {
        GameContext.SelectedLevel = level;
        SceneManager.LoadScene(GameScene);
    }

    public void Start()
    {
        menuPanel.SetActive(true);
        levelSelectorPanel.SetActive(false);
    }

    public void OnClickStart()
    {
        menuPanel.SetActive(false);
        LoadLevelList();
        levelSelectorPanel.SetActive(true);
    }


    private void LoadLevelList()
    {
        BetterStreamingAssets.Initialize();
        string json = BetterStreamingAssets.ReadAllText("levels.json");
        LevelNames levelNames = JsonUtility.FromJson<LevelNames>(json);
        for (int i = 0; i < levelNames.levels.Length; i++)
        {
            string level = levelNames.levels[i];
            float xPos = i * 5;
            GameObject buttonObj = GameObject.Instantiate(levelButton, levelSelectorContentParent, false);

            RectTransform buttonTransform = buttonObj.GetComponent<RectTransform>();

            Button button = buttonObj.GetComponent<Button>();
            TextMeshProUGUI buttonText = button.transform.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = level;
            button.onClick.AddListener(delegate { LoadGameScene(level); });
            buttonTransform.localPosition = new Vector3(xPos, 0, -0.1f);
        }
    }
}