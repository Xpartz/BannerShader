using UnityEngine;

public class WindController : MonoBehaviour
{
    [Curve] // Используем пользовательский атрибут

    [ExecuteInEditMode]
    [SerializeField] // Помечаем поле для отображения в инспекторе
    public Vector2 point2 = new Vector2(1, 1);
    public float zValue = 0.0f;

    public float positionX;
    public float positionY;


    private void OnValidate()
    {
        // Ограничиваем значения компонента x в диапазоне от -1 до 1
        point2.x = Mathf.Clamp(point2.x, -1f, 1f);

        // Ограничиваем значения компонента y в диапазоне от -1 до 1
        point2.y = Mathf.Clamp(point2.y, -1f, 1f);
        zValue = Mathf.Clamp(zValue, -1f, 1f);
       
    }
    private void Update()
    {
       
    }
}
