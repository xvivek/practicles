using DataService;
using Prism.Commands;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel
    {
        private Plot chartPlot;
		
		public Plot ChartPlot
        {
			get { return chartPlot; }
			set { chartPlot = value; }
		}

        public ObservableCollection<OHLC> chartData { get; set; } = new ObservableCollection<OHLC>();

        public ObservableCollection<OHLC> ChartData
        {
            get { return chartData; }
            set { chartData = value; }
        }

        List<string> isins = new List<string>();
        public ViewAViewModel()
        {
            isins.Add("INE435A01028");
            isins.Add("INE299U01018");
            isins.Add("INE177H01021");
            isins.Add("INE742B01025");
            isins.Add("INE495S01016");
        }

        public DelegateCommand ShowCommand => new(async () => await Show());

        private static int index = 0;

        public async Task Show()
        {
            if (index == isins.Count() - 1)
                index = 0;

            IConnectionDetails connectionDetails = new PgConnectionDetails("");
            ChartService dbService = new ChartService(connectionDetails);

            var result = await dbService.GetPriceData(isins[index++]);
            var startDate = result.Min(i => i.Date);
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

                fp.ColorDown = Color.Black;
                fp.ColorUp = Color.White;
                fp.WickColor = Color.Transparent;
            }
        }
    }


}
