using Avalonia.Controls;
using Avalonia.Threading;
using DataService;
using Microsoft.CodeAnalysis;
using ModuleA.ViewModels;
using ReactiveUI;
using ScottPlot;
using ScottPlot.Avalonia;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace ModuleA.Views
{
    public partial class ViewA : UserControl
    {
        List<string> isins = new List<string>();

        public ViewA()
        {
            InitializeComponent();

            btnShow.Click += BtnShow_Click;

            isins.Add("INE435A01028");
            isins.Add("INE299U01018");
            isins.Add("INE177H01021");
            isins.Add("INE742B01025");
            isins.Add("INE495S01016");

        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var dc = DataContext as ViewAViewModel;
            if (dc != null)
            {
                dc.ChartPlot = avaPlot1.Plot;                
            }
        }

        ManualResetEventSlim ManualResetEvent = new ManualResetEventSlim(false);

        private void BtnShow_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var dc = DataContext as ViewAViewModel;
            ManualResetEvent.Reset();
            if (dc != null)
            {
                // this.avaPlot1.Reset();
                // this.avaPlot1.IsVisible = true;
                // var plt = this.avaPlot1.Plot;
                // OHLC[] prices = DataGen.RandomStockPrices(null, 30, TimeSpan.FromDays(1));
                // Task.Run(async () => { prices = await GetData(); ManualResetEvent.Set(); });
                //// Dispatcher.UIThread.Invoke(async () => { prices = await GetData(); ManualResetEvent.Set(); });

                // ManualResetEvent.Wait();

                // var candlePlot = plt.AddCandlesticks(prices);
                // candlePlot.YAxisIndex = 1;
                // plt.XAxis.DateTimeFormat(true);

                // plt.YAxis.Ticks(false);
                // plt.YAxis2.Ticks(true);
                // plt.YAxis2.Label("Price (INR)");
                // this.avaPlot1.Refresh();
                dc.ChartPlot = avaPlot1.Plot;
                this.avaPlot1.Reset();
                this.avaPlot1.IsVisible = true;

                Task.Run(async () => { await Show(); ManualResetEvent.Set(); });
               
                ManualResetEvent.Wait();
                
                this.avaPlot1.Refresh();

                //  Dispatcher.UIThread.Invoke(async () => await Show());              
            }
        }

        private static int index = 0;

        public ObservableCollection<OHLC> chartData { get; set; } = new ObservableCollection<OHLC>();

        public ObservableCollection<OHLC> ChartData
        {
            get { return chartData; }
            set { chartData = value; }
        }

        private async Task<OHLC[]> GetData()
        {
            if (index == isins.Count() - 1)
                index = 0;

            IConnectionDetails connectionDetails = new PgConnectionDetails("");
            ChartService dbService = new ChartService(connectionDetails);
            var result = await dbService.GetPriceData(isins[index++]);

            ChartData.Clear();
            result.ForEach(x => ChartData.Add(new OHLC(x.Open, x.High, x.Low, x.Close, x.Date, TimeSpan.FromDays(1))));

            return ChartData.ToArray();            
        }
        public async Task Show()
        {
            
            if (index == isins.Count() - 1)
                index = 0;
          

            var ChartPlot = avaPlot1.Plot;


            IConnectionDetails connectionDetails = new PgConnectionDetails("");
            ChartService dbService = new ChartService(connectionDetails);

            var result = await dbService.GetPriceData(isins[index++]);            
            ChartData.Clear();
            result.ForEach(x => ChartData.Add(new OHLC(x.Open, x.High, x.Low, x.Close, x.Date, TimeSpan.FromDays(1))));
            double nStep = 10.0;
            if (ChartPlot != null)
            {

                var fp = ChartPlot.AddCandlesticks(ChartData.ToArray());

                //double[] tickPositions = result.Where((x, i) => i % nStep == 0).Select(j => j.Close).ToArray();
                //string[] tickLabels = result.Where((x, i) => i % nStep == 0).Select(x => x.Date.ToString("yyyy MMM dd")).ToArray();
                //ChartPlot.XTicks(tickPositions, tickLabels);
               
                fp.YAxisIndex = 1;
                ChartPlot.XAxis.DateTimeFormat(true);
                ChartPlot.YAxis.Ticks(false);
                ChartPlot.YAxis2.Ticks(true);
                ChartPlot.YAxis2.Label("Price (INR)");

                //fp.ColorDown = Color.Red;
                //fp.ColorUp = Color.Green;
                //fp.WickColor = Color.Black;
               // plt.Style(Style.Blue1);
                ChartPlot.Palette = ScottPlot.Palette.PolarNight;
                //fp.ColorDown = ColorTranslator.FromHtml("#00FF00");
                //fp.ColorUp = ColorTranslator.FromHtml("#FF0000");

                //// customize figure styling
                //ChartPlot.Layout(padding: 12);
                //ChartPlot.Style(figureBackground: Color.Black, dataBackground: Color.Black);
                //ChartPlot.Frameless();
                //ChartPlot.XAxis.TickLabelStyle(color: Color.White);
                //ChartPlot.XAxis.TickMarkColor(ColorTranslator.FromHtml("#333333"));
                //ChartPlot.XAxis.MajorGrid(color: ColorTranslator.FromHtml("#333333"));

                //// hide the left axis and show a right axis
                //ChartPlot.YAxis.Ticks(false);
                //ChartPlot.YAxis.Grid(false);
                //ChartPlot.YAxis2.Ticks(true);
                //ChartPlot.YAxis2.Grid(true);
                //ChartPlot.YAxis2.TickLabelStyle(color: ColorTranslator.FromHtml("#00FF00"));
                //ChartPlot.YAxis2.TickMarkColor(ColorTranslator.FromHtml("#333333"));
                //ChartPlot.YAxis2.MajorGrid(color: ColorTranslator.FromHtml("#333333"));

                //// customize the legend style
                //var legend = ChartPlot.Legend();
                //legend.FillColor = Color.Transparent;
                //legend.OutlineColor = Color.Transparent;
                //legend.Font.Color = Color.White;
                //legend.Font.Bold = true;

                ChartPlot.Style(ScottPlot.Style.Blue1);
            }
        }
    }
}
