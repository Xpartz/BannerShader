using UnityEngine;
using UnityEditor;

/* [CustomEditor(typeof(WindController))]
public class WindControllerEditorCustom : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        WindController windController = (WindController)target;

        Vector2 inspectorCenter = new Vector2(200, 200);
        Vector2 inspectorSize = new Vector2(200, 200);

        Handles.DrawSolidRectangleWithOutline(new Rect(inspectorCenter - inspectorSize / 2, inspectorSize), Color.gray, Color.black);

        Vector2 xAxisStart = inspectorCenter + new Vector2(-inspectorSize.x / 2, 0);
        Vector2 xAxisEnd = inspectorCenter + new Vector2(inspectorSize.x / 2, 0);
        Handles.color = Color.red;
        Handles.DrawLine(xAxisStart, xAxisEnd);

        Vector2 yAxisStart = inspectorCenter + new Vector2(0, -inspectorSize.y / 2);
        Vector2 yAxisEnd = inspectorCenter + new Vector2(0, inspectorSize.y / 2);
        Handles.color = Color.green;
        Handles.DrawLine(yAxisStart, yAxisEnd);


        Vector2 point1 = new Vector2(0, 0);
        Vector2 point2 = windController.point2.normalized;
        Vector2 inspectorPoint1 = inspectorCenter + point1 * inspectorSize / 2;
        Vector2 inspectorPoint2 = inspectorCenter + new Vector2(point2.x * inspectorSize.x / 2, point2.y * inspectorSize.x / 2 * -1);

        Handles.color = Color.black;
        Handles.DrawLine(inspectorPoint1, inspectorPoint2);

        // Отображение вектора с помощью стрелки
        DrawArrow(inspectorPoint1, inspectorPoint2, Color.black, 20f, 5f);
    }

    private void DrawArrow(Vector2 from, Vector2 to, Color color, float arrowSize, float lineWidth)
{
    Handles.color = color;

    // Рисование нескольких линий для увеличения толщины
    for (float i = 0; i < 1; i += 0.1f)
    {
        Vector2 start = Vector2.Lerp(from, to, i);
        Vector2 end = Vector2.Lerp(from, to, i + 0.1f);
        Handles.DrawAAPolyLine(lineWidth, start, end);
    }

    // Рисование стрелочки
    Vector2 direction = (to - from).normalized;
    Vector2 arrowTip = to - direction * arrowSize;

    // Рисование главной линии стрелки
    Handles.DrawAAPolyLine(lineWidth, to, arrowTip);

    // Рисование боковых линий стрелки
    float angle = 20f;
    Vector2 arrowSide1 = Quaternion.Euler(0, 0, angle) * -direction;
    Vector2 arrowSide2 = Quaternion.Euler(0, 0, -angle) * -direction;

    Handles.DrawAAPolyLine(lineWidth, arrowTip, arrowTip + arrowSide1 * arrowSize * 0.5f);
    Handles.DrawAAPolyLine(lineWidth, arrowTip, arrowTip + arrowSide2 * arrowSize * 0.5f);
}
}*/
