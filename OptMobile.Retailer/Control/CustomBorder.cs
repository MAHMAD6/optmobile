using Microsoft.Maui.Controls.Shapes;

namespace OptMobile.Retailer.Control;

public class CustomBorder : Border
{
    public CustomBorder()
    {
        AddConrnerRadius();
    }

    private List<int> CornerValues = new List<int>() { 10, 40, 70, 80 };

    private void AddConrnerRadius()
    {
        var index = new Random().Next(4);

        StrokeShape = new RoundRectangle
        {
            CornerRadius = new CornerRadius(CornerValues[index])
        };
    }
}
