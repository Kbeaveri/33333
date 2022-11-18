using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace _33333
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            DrawGraph();
        }
        private double f1(double x)
        { 
            return (Math.Pow(x, 2) * Math.Sqrt(Math.Pow(x, 2) - 1)) / (2 * Math.Pow(x, 2) - 1);
        }
        private double f2(double x)
        {
            return ((Math.Pow(x, 5)) - (3 * Math.Pow(x, 3)) + (2 * x)) / (Math.Sqrt((Math.Pow(x, 2)) - 1) * (Math.Pow((2 * Math.Pow(x, 2)) - 1, 2)));
        }

        private void DrawGraph()
        {
            // Получим панель для рисования
            GraphPane pane = zedGraph.GraphPane;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            // Создадим список точек
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            double xmin = -10;
            double xmax = 10;

            double xbreak1 = -1;
            double xbreak2 = 1;

            // Заполняем список точек
            for (double x = xmin; x <= xbreak1; x += 0.01)
            {
                // добавим в список точку
                list1.Add(x, f1(x));
            }
            list1.Add(PointPairBase.Missing, PointPairBase.Missing);
            for (double x = xbreak2; x <= xmax; x += 0.01)
            {
                // добавим в список точку
                list1.Add(x, f1(x));
            }
            for (double x = xmin; x <= xbreak1; x += 0.01)
            {
                // добавим в список точку
                list2.Add(x, f2(x));
            }
            list2.Add(PointPairBase.Missing, PointPairBase.Missing);
            for (double x = xbreak2; x <= xmax; x += 0.01)
            {
                // добавим в список точку
                list2.Add(x, f2(x));
            }
            LineItem f1_curve = pane.AddCurve("Функция", list1, Color.Blue, SymbolType.None);
            LineItem f2_curve = pane.AddCurve("Производная", list2, Color.Red, SymbolType.Plus);
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.XAxis.Cross = 0.0;

            // Ось Y будет пересекаться с осью X на уровне X = 0
            pane.YAxis.Cross = 0.0;

            // Отключим отображение первых и последних меток по осям
            pane.XAxis.Scale.IsSkipFirstLabel = true;
            pane.XAxis.Scale.IsSkipLastLabel = true;

            // Отключим отображение меток в точке пересечения с другой осью
            pane.XAxis.Scale.IsSkipCrossLabel = true;


            // Отключим отображение первых и последних меток по осям
            pane.YAxis.Scale.IsSkipFirstLabel = true;

            // Отключим отображение меток в точке пересечения с другой осью
            pane.YAxis.Scale.IsSkipLastLabel = true;
            pane.YAxis.Scale.IsSkipCrossLabel = true;

            // Спрячем заголовки осей
            pane.XAxis.Title.IsVisible = false;
            pane.YAxis.Title.IsVisible = false;
            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();
        }

        private void zedGraph_MouseClick(object sender, MouseEventArgs e)
        {
                // Сюда будут записаны координаты в системе координат графика
                double x, y;

                // Пересчитываем пиксели в координаты на графике
                // У ZedGraph есть несколько перегруженных методов ReverseTransform.
                zedGraph.GraphPane.ReverseTransform(e.Location, out x, out y);

                // Выводим результат
                string text = string.Format("X: {0};    Y: {1}", x, y);
                label1.Text = text;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
