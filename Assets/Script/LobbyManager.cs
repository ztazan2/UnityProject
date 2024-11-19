using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public GameObject lobbyPanel; // �κ� �г� (�ν����Ϳ��� ����)
    private PanelManager panelManager; // PanelManager ����
    public static bool isRestarting = false; // �� ����� ���θ� ��Ÿ���� ����

    void Start()
    {
        panelManager = PanelManager.Instance;

        // ���� ���� �� ó���� �κ� �г��� Ȱ��ȭ
        if (!isRestarting)
        {
            ShowLobby();
        }
        else
        {
            isRestarting = false; // ����� �Ŀ��� �κ� �г��� �ٽ� ������ �ʵ��� ����
        }
    }

    public void ShowLobby()
    {
        if (lobbyPanel != null && panelManager != null)
        {
            if (panelManager.OpenPanel(lobbyPanel))
            {
                Debug.Log("�κ� �г��� ���Ƚ��ϴ�.");
            }
        }
    }

    public void HideLobby()
    {
        if (lobbyPanel != null && panelManager != null)
        {
            PanelManager.Instance.ClosePanel();
            Debug.Log("�κ� �г��� �������ϴ�.");
        }
    }

    public void StartGame()
    {
        HideLobby();
        Debug.Log("������ ���۵˴ϴ�.");
    }

    public void RestartGame()
    {
        // �κ� �ݰ� ����� ���¸� �����Ͽ� �κ� �ٽ� ������ �ʵ��� ����
        HideLobby();
        Debug.Log("���� �����");
        isRestarting = true; // ����� ���·� ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // ���� ���� �ٽ� �ε�
    }
}
