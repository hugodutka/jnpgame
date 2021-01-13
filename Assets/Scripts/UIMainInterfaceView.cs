using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UIMainInterfaceView : UIBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_CoinText;

    [SerializeField]
    private TextMeshProUGUI m_TimeText;

    [SerializeField]
    private Button m_PauseButton;

    public void Initialize(UnityAction onPause)
    {
        m_PauseButton.onClick.AddListener(onPause);
    }

    public void Configure(ulong coinNumber, float time)
    {
        m_CoinText.text = coinNumber.ToString();
        m_TimeText.text = $"{time.ToString("f1")} s";
    }
}
