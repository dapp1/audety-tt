using System.Collections;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Main UI objects")]
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private GameObject _menuUI;

    [Header("Buttons and other")]
    [SerializeField] private Button _confirm;
    [SerializeField] private Button _start;
    [SerializeField] private Button _exit;
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private TextMeshProUGUI _nickname;

    [Header("Animations and Cameras")]
    [SerializeField] private Animator _animation;
    [SerializeField] private CinemachineVirtualCamera _vcam1;
    [SerializeField] private CinemachineVirtualCamera _vcam2;
    [SerializeField] private ParallaxCamera _background;

    private void Awake()
    {
        _vcam1.gameObject.SetActive(false);
        _vcam2.gameObject.SetActive(true);
        _animation.enabled = false;
        _background.enabled = false;
    }

    private void Start()
    {
        _confirm.onClick.AddListener(() => { string nickname = _input.text; _nickname.text = nickname; });
        _exit.onClick.AddListener(() => Application.Quit());

        _start.onClick.AddListener(() => StartCoroutine(Delay()));
    }

    private IEnumerator Delay()
    {
        _menuUI.SetActive(false);
        _vcam1.gameObject.SetActive(true);
        _vcam2.gameObject.SetActive(false);
        _menuUI.SetActive(false);
        _animation.enabled = true;
        yield return new WaitForSeconds(2f);
        _gameUI.SetActive(true);
        _background.enabled = true;
    }
}
