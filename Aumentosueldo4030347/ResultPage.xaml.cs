namespace Aumentosueldo4030347;

public partial class ResultPage : ContentPage
{
    public ResultPage(decimal nuevoSueldo)
    {
        InitializeComponent();
        ResultLabel.Text = $"Nuevo sueldo: {nuevoSueldo:C}";
    }
}