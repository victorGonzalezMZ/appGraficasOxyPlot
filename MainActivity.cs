using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Android;

namespace appGraficasOxyPlot
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            SupportActionBar.Hide();
            PlotView view1 = FindViewById<PlotView>(Resource.Id.grafica1);
            PlotView view2 = FindViewById<PlotView>(Resource.Id.grafica2);

            view1.Model = CreatePiePlotModel();
            view2.Model = CreateBarPlotModel();
        }

        private PlotModel CreatePiePlotModel()
        {
            var plotModel = new PlotModel { Title = "Gráfica de Pastel" };
            var seriesP = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8
            };
            seriesP.Slices.Add(new PieSlice("Morena", 197) { Fill = OxyColors.DarkRed });
            seriesP.Slices.Add(new PieSlice("PAN", 111) { Fill = OxyColors.Blue });
            seriesP.Slices.Add(new PieSlice("PRI", 69) { Fill = OxyColors.Red });
            seriesP.Slices.Add(new PieSlice("PWEM", 44) { Fill = OxyColors.Green });
            seriesP.Slices.Add(new PieSlice("PT", 38) { Fill = OxyColors.IndianRed });
            seriesP.Slices.Add(new PieSlice("MC", 24) { Fill = OxyColors.Orange });
            seriesP.Slices.Add(new PieSlice("PRD", 17) { Fill = OxyColors.Yellow });
            plotModel.Series.Add(seriesP);
            return plotModel;
        }

        private PlotModel CreateBarPlotModel()
        {
            var plotModel = new PlotModel 
            { 
                Title = "Gráfica de Barras",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Vertical
            };

            var seriesP = new BarSeries
            {
                Title = "Cámara de Diputados",
                StrokeColor = OxyColors.Black,
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0}",
                TextColor = OxyColor.FromRgb(255,255,255)
            };

            seriesP.Items.Add(new BarItem { Color = OxyColor.FromRgb(89, 35, 33), Value = 197 });
            seriesP.Items.Add(new BarItem { Color = OxyColor.FromRgb(30, 144, 255), Value = 111 });
            seriesP.Items.Add(new BarItem { Color = OxyColor.FromRgb(255, 35, 01), Value = 69 });
            seriesP.Items.Add(new BarItem { Color = OxyColor.FromRgb(87, 166, 57), Value = 44 });
            seriesP.Items.Add(new BarItem { Color = OxyColor.FromRgb(117, 21, 30), Value = 38 });
            seriesP.Items.Add(new BarItem { Color = OxyColor.FromRgb(217, 80, 48), Value = 24 });
            seriesP.Items.Add(new BarItem { Color = OxyColor.FromRgb(243, 208, 51), Value = 17 });
            seriesP.FillColor = OxyColor.FromRgb(255, 0, 0);

            var categoriaAxis = new CategoryAxis { Position = AxisPosition.Left };
            categoriaAxis.Labels.Add("Morena");
            categoriaAxis.Labels.Add("PAN");
            categoriaAxis.Labels.Add("PRI");
            categoriaAxis.Labels.Add("PVEM");
            categoriaAxis.Labels.Add("PT");
            categoriaAxis.Labels.Add("MC");
            categoriaAxis.Labels.Add("PRD");

            plotModel.Series.Add(seriesP);
            plotModel.Axes.Add(categoriaAxis);

            return plotModel;
        }
    }
}