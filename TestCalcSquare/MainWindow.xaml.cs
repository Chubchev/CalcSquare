using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CalcSquare;

namespace TestCalcSquare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum FUGURE { CIRCLE, TRIANGLE }
        private FUGURE FigureType;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnType_Checked(object sender, RoutedEventArgs e)
        {
            int figureType = 0;
            int.TryParse((string)((RadioButton)sender).Tag, out figureType);
            FigureType = (FUGURE)figureType;
            if (textBlock_Result1 != null)
            {
                textBlock_Result1.Text = "";
                textBlock_Result2.Text = "";
            }
        }

        private void CalcButton_Click(object sender, RoutedEventArgs e)
        {
            string FigureName = "";
            CalcSquare.Figure? figure = null;
            switch (FigureType)
            {   
                case  FUGURE.CIRCLE:
                    double Radius = 0;
                    FigureName = "круга: ";
                    double.TryParse(textBox_Radius.Text, out Radius);
                    if(Radius==0)
                    {
                        textBlock_Result2.Text = "Введите ненулевой радиус";
                        return;
                    }
                    figure = new CalcSquare.Circle(Radius);
                    break;
                case FUGURE.TRIANGLE:
                    double A = 0, B = 0, С = 0;
                    FigureName = "треугольника: ";
                    double.TryParse(textBox_A.Text, out A);
                    double.TryParse(textBox_B.Text, out B);
                    double.TryParse(textBox_C.Text, out С);
                    if (A == 0 || B == 0 || С == 0)
                    {
                        textBlock_Result2.Text = "Введите ненулевую длину сторон";
                        return;
                    }
                    figure = new CalcSquare.Triangle(A, B, С);
                    break;
                default:
                    textBlock_Result2.Text = "Расчёт полощади заданной фигуры не реализован";
                    return;

            }
            if (figure != null)
            {
                textBlock_Result1.Text = "Площадь "+ FigureName + figure.Square.ToString();
                textBlock_Result2.Text = FigureType == FUGURE.TRIANGLE ? figure.Message : "";
            }
        }
    }

    /// <summary>конвертер bool в видимость контрола</summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : IValueConverter
    {
        //OneWay
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }
        //OneWayToSource
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}