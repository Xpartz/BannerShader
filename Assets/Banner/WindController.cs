using UnityEngine;

public class WindController : MonoBehaviour
{
    [Curve] // ���������� ���������������� �������

    [ExecuteInEditMode]
    [SerializeField] // �������� ���� ��� ����������� � ����������
    public Vector2 point2 = new Vector2(1, 1);
    public float zValue = 0.0f;

    public float positionX;
    public float positionY;


    private void OnValidate()
    {
        // ������������ �������� ���������� x � ��������� �� -1 �� 1
        point2.x = Mathf.Clamp(point2.x, -1f, 1f);

        // ������������ �������� ���������� y � ��������� �� -1 �� 1
        point2.y = Mathf.Clamp(point2.y, -1f, 1f);
        zValue = Mathf.Clamp(zValue, -1f, 1f);
       
    }
    private void Update()
    {
       
    }
}
