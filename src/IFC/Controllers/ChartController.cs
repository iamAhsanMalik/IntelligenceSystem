using ChartJSCore.Helpers;
using ChartJSCore.Models;
using ChartJSCore.Plugins.Zoom;

namespace IFC.Controllers;
public class ChartController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ChartController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var iFCCharts = new IFCChartsModel()
        {
            VerticalBarChart = await GenerateVerticalBarChart(),
            HorizontalBarChart = GenerateHorizontalBarChart(),
            LineChart = GenerateLineChart(),
            RadarChart = GenerateRadarChart(),
            LineScatterChart = GenerateLineScatterChart(),
            NestedDoughnutChart = GenerateNestedDoughnutChart(),
            PieChart = GeneratePieChart(),
            PolarChart = GeneratePolarChart()
        };
        return View(iFCCharts);
    }

    private async Task<Chart> GenerateVerticalBarChart()
    {
        var totalIncidents = await _unitOfWork.IncidentRepo.GetIncidentsAsync();
        var totalThreats = await _unitOfWork.ThreatRepo.GetThreatsAsync();
        var totalTerrorist = await _unitOfWork.TerroristProfileRepo.GetTerroristProfilesAsync();
        var totalOrganizations = await _unitOfWork.OrganizationRepo.GetOrganizationDetailsAsync();
        var totalSuspects = await _unitOfWork.SuspectProfileRepo.GetSuspectProfilesAsync();

        var chart = new Chart();
        chart.Type = Enums.ChartType.Bar;

        var data = new Data();
        data.Labels = new List<string>() { "Incidents", "Threats", "Terrorist", "Suspects", "Organizations" };

        var dataset = new BarDataset()
        {
            Label = "IFC Overview",
            Data = new List<double?>() { totalIncidents.Count(), totalThreats.Count(), totalTerrorist.Count(), totalSuspects.Count(), totalOrganizations.Count() },
            BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromRgba(255, 99, 132, 0.2),
                    ChartColor.FromRgba(54, 162, 235, 0.2),
                    ChartColor.FromRgba(255, 206, 86, 0.2),
                    ChartColor.FromRgba(75, 192, 192, 0.2),
                    ChartColor.FromRgba(153, 102, 255, 0.2),
                },
            BorderColor = new List<ChartColor>
                {
                    ChartColor.FromRgb(255, 99, 132),
                    ChartColor.FromRgb(54, 162, 235),
                    ChartColor.FromRgb(255, 206, 86),
                    ChartColor.FromRgb(75, 192, 192),
                    ChartColor.FromRgb(153, 102, 255),
                },
            BorderWidth = new List<int>() { 1 },
            BarPercentage = 0.5,
            BarThickness = 6,
            MaxBarThickness = 8,
            MinBarLength = 2
        };

        data.Datasets = new List<Dataset>();
        data.Datasets.Add(dataset);
        chart.Data = data;

        chart.Options = new Options
        {
            Scales = new Dictionary<string, Scale>()
                {
                    { "y", new CartesianLinearScale()
                        {
                            BeginAtZero = true
                        }
                    },
                    { "x", new Scale()
                        {
                            Grid = new Grid()
                            {
                                Offset = true
                            }
                        }
                    },
                }
        };

        chart.Options.Layout = new Layout
        {
            Padding = new Padding
            {
                PaddingObject = new PaddingObject
                {
                    Left = 10,
                    Right = 12
                }
            }
        };

        return chart;
    }

    private Chart GenerateHorizontalBarChart()
    {
        var chart = new Chart();
        chart.Type = Enums.ChartType.Bar;

        chart.Data = new Data()
        {
            Datasets = new List<Dataset>()
                {
                    {
                        new VerticalBarDataset()
                        {
                            Label = "Dataset 1",
                            Data = new List<VerticalBarDataPoint?>()
                            {
                                new VerticalBarDataPoint(12, 1)
                            },
                            BackgroundColor = new List<ChartColor>
                            {
                                ChartColor.FromRgba(255, 99, 132, 0.2)
                            },
                            BorderWidth = new List<int>() { 2 },
                            IndexAxis = "y"
                        }
                    },
                    {
                        new VerticalBarDataset()
                        {
                            Label = "Dataset 2",
                            Data = new List<VerticalBarDataPoint?>()
                            {
                                new VerticalBarDataPoint(19, 2)
                            },
                            BackgroundColor = new List<ChartColor>
                            {
                                ChartColor.FromRgba(54, 162, 235, 0.2)
                            },
                            BorderWidth = new List<int>() { 2 },
                            IndexAxis = "y"
                        }
                    },
                    {
                        new VerticalBarDataset()
                        {
                            Label = "Dataset 3",
                            Data = new List<VerticalBarDataPoint?>()
                            {
                                new VerticalBarDataPoint(3, 3)
                            },
                            BackgroundColor = new List<ChartColor>
                            {
                                ChartColor.FromRgba(255, 206, 86, 0.2)
                            },
                            BorderWidth = new List<int>() { 2 },
                            IndexAxis = "y"
                        }
                    },
                    {
                        new VerticalBarDataset()
                        {
                            Label = "Dataset 4",
                            Data = new List<VerticalBarDataPoint?>()
                            {
                                new VerticalBarDataPoint(5, 4)
                            },
                            BackgroundColor = new List<ChartColor>
                            {
                                ChartColor.FromRgba(75, 192, 192, 0.2)
                            },
                            BorderWidth = new List<int>() { 2 },
                            IndexAxis = "y"
                        }
                    },
                    {
                        new VerticalBarDataset()
                        {
                            Label = "Dataset 5",
                            Data = new List<VerticalBarDataPoint?>()
                            {
                                new VerticalBarDataPoint(2, 5)
                            },
                            BackgroundColor = new List<ChartColor>
                            {
                                ChartColor.FromRgba(153, 102, 255, 0.2)
                            },
                            BorderWidth = new List<int>() { 2 },
                            IndexAxis = "y"
                        }
                    },
                    {
                        new VerticalBarDataset()
                        {
                            Label = "Dataset 6",
                            Data = new List<VerticalBarDataPoint?>()
                            {
                                new VerticalBarDataPoint(3, 6)
                            },
                            BackgroundColor = new List<ChartColor>
                            {
                                ChartColor.FromRgba(255, 159, 64, 0.2)
                            },
                            BorderWidth = new List<int>() { 2 },
                            IndexAxis = "y"
                        }
                    }
                }
        };

        chart.Options = new Options()
        {
            Responsive = true,
            Plugins = new Plugins()
            {
                Legend = new Legend()
                {
                    Position = "right"
                },
                Title = new Title()
                {
                    Display = true,
                    Text = new List<string>() { "Chart.js Horizontal Bar Chart" }
                }
            }
        };

        return chart;
    }

    private Chart GenerateLineChart()
    {
        var chart = new Chart();

        chart.Type = Enums.ChartType.Line;
        chart.Options.Scales = new Dictionary<string, Scale>();
        var xAxis = new CartesianScale();
        xAxis.Display = true;
        xAxis.Title = new Title
        {
            Text = new List<string> { "Month" },
            Display = true
        };
        chart.Options.Scales.Add("x", xAxis);


        var data = new Data
        {
            Labels = new List<string> { "January", "February", "March", "April", "May", "June", "July" }
        };

        var dataset = new LineDataset()
        {
            Label = "My First dataset",
            Data = new List<double?> { 65, 59, 80, 81, 56, 55, 40 },
            Fill = "true",
            Tension = .01,
            BackgroundColor = new List<ChartColor> { ChartColor.FromRgba(75, 192, 192, 0.4) },
            BorderColor = new List<ChartColor> { ChartColor.FromRgb(75, 192, 192) },
            BorderCapStyle = "butt",
            BorderDash = new List<int>(),
            BorderDashOffset = 0.0,
            BorderJoinStyle = "miter",
            PointBorderColor = new List<ChartColor> { ChartColor.FromRgb(75, 192, 192) },
            PointBackgroundColor = new List<ChartColor> { ChartColor.FromHexString("#ffffff") },
            PointBorderWidth = new List<int> { 1 },
            PointHoverRadius = new List<int> { 5 },
            PointHoverBackgroundColor = new List<ChartColor> { ChartColor.FromRgb(75, 192, 192) },
            PointHoverBorderColor = new List<ChartColor> { ChartColor.FromRgb(220, 220, 220) },
            PointHoverBorderWidth = new List<int> { 2 },
            PointRadius = new List<int> { 1 },
            PointHitRadius = new List<int> { 10 },
            SpanGaps = false
        };

        data.Datasets = new List<Dataset>
            {
                dataset
            };

        chart.Data = data;

        var zoomOptions = new ZoomOptions
        {
            Zoom = new Zoom
            {
                Wheel = new Wheel
                {
                    Enabled = true
                },
                Pinch = new Pinch
                {
                    Enabled = true
                },
                Drag = new Drag
                {
                    Enabled = true,
                    ModifierKey = Enums.ModifierKey.alt
                }
            },
            Pan = new Pan
            {
                Enabled = true,
                Mode = "xy"
            }
        };

        chart.Options.Plugins = new ChartJSCore.Models.Plugins
        {
            PluginDynamic = new Dictionary<string, object> { { "zoom", zoomOptions } }
        };

        return chart;
    }

    private Chart GenerateLineScatterChart()
    {
        var chart = new Chart();
        chart.Type = Enums.ChartType.Scatter;

        var data = new Data();

        var dataset = new LineScatterDataset()
        {
            Label = "Scatter Dataset",
            Data = new List<LineScatterData>()
        };

        var scatterData1 = new LineScatterData();
        var scatterData2 = new LineScatterData();
        var scatterData3 = new LineScatterData();

        scatterData1.X = "-10";
        scatterData1.Y = "0";
        dataset.Data.Add(scatterData1);

        scatterData2.X = "0";
        scatterData2.Y = "10";
        dataset.Data.Add(scatterData2);

        scatterData3.X = "10";
        scatterData3.Y = "5";
        dataset.Data.Add(scatterData3);
        dataset.Type = Enums.ChartType.Scatter;

        data.Datasets = new List<Dataset>();
        data.Datasets.Add(dataset);

        chart.Data = data;

        var options = new Options()
        {
            Scales = new Dictionary<string, Scale>()
        };

        var xAxis = new CartesianLinearScale()
        {
            Type = "linear",
            Grace = "50%"
        };

        var yAxis = new CartesianLinearScale()
        {
            Type = "linear",
            Grace = "50%"
        };

        /*            {
                        XAxes = new List<Scale>()
                        {
                            new CartesianScale()
                            {
                                Type = "linear",
                                Position = "bottom",
                                Ticks = new CartesianLinearTick()
                                {
                                    BeginAtZero = true
                                }
                            } */

        options.Scales.Add("x", xAxis);
        options.Scales.Add("y", yAxis);

        chart.Options = options;

        return chart;
    }

    private Chart GenerateRadarChart()
    {
        var chart = new Chart();
        chart.Type = Enums.ChartType.Radar;

        var data = new Data();
        data.Labels = new List<string>() { "Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running" };

        var dataset1 = new RadarDataset()
        {
            Label = "My First dataset",
            BackgroundColor = new List<ChartColor> { ChartColor.FromRgba(179, 181, 198, 0.2) },
            BorderColor = new List<ChartColor> { ChartColor.FromRgba(179, 181, 198, 1) },
            PointBackgroundColor = new List<ChartColor>() { ChartColor.FromRgba(179, 181, 198, 1) },
            PointBorderColor = new List<ChartColor>() { ChartColor.FromHexString("#fff") },
            PointHoverBackgroundColor = new List<ChartColor>() { ChartColor.FromHexString("#fff") },
            PointHoverBorderColor = new List<ChartColor>() { ChartColor.FromRgba(179, 181, 198, 1) },
            Data = new List<double?>() { 65, 59, 80, 81, 56, 55, 40 }
        };

        var dataset2 = new RadarDataset()
        {
            Label = "My Second dataset",
            BackgroundColor = new List<ChartColor> { ChartColor.FromRgba(255, 99, 132, 0.2) },
            BorderColor = new List<ChartColor> { ChartColor.FromRgba(255, 99, 132, 1) },
            PointBackgroundColor = new List<ChartColor>() { ChartColor.FromRgba(255, 99, 132, 1) },
            PointBorderColor = new List<ChartColor>() { ChartColor.FromHexString("#fff") },
            PointHoverBackgroundColor = new List<ChartColor>() { ChartColor.FromHexString("#fff") },
            PointHoverBorderColor = new List<ChartColor>() { ChartColor.FromRgba(255, 99, 132, 1) },
            Data = new List<double?>() { 28, 48, 40, 19, 96, 27, 100 }
        };

        data.Datasets = new List<Dataset>();
        data.Datasets.Add(dataset1);
        data.Datasets.Add(dataset2);

        chart.Data = data;

        return chart;
    }

    private Chart GeneratePolarChart()
    {
        var chart = new Chart();
        chart.Type = Enums.ChartType.PolarArea;

        var data = new Data();
        data.Labels = new List<string>() { "Red", "Green", "Yellow", "Grey", "Blue" };

        var dataset = new PolarDataset()
        {
            Label = "My dataset",
            BackgroundColor = new List<ChartColor>() {
                ChartColor.FromHexString("#FF6384"),
                ChartColor.FromHexString("#4BC0C0"),
                ChartColor.FromHexString("#FFCE56"),
                ChartColor.FromHexString("#E7E9ED"),
                ChartColor.FromHexString("#36A2EB")
            },
            Data = new List<double?>() { 11, 16, 7, 3, 14 }
        };

        data.Datasets = new List<Dataset>();
        data.Datasets.Add(dataset);

        chart.Data = data;

        return chart;
    }

    private Chart GeneratePieChart()
    {
        var chart = new Chart();
        chart.Type = Enums.ChartType.Pie;

        var data = new Data();
        data.Labels = new List<string>() { "Red", "Blue", "Yellow" };

        var dataset = new PieDataset()
        {
            Label = "My dataset",
            BackgroundColor = new List<ChartColor>() {
                ChartColor.FromHexString("#FF6384"),
                ChartColor.FromHexString("#36A2EB"),
                ChartColor.FromHexString("#FFCE56")
            },
            HoverBackgroundColor = new List<ChartColor>() {
                ChartColor.FromHexString("#FF6384"),
                ChartColor.FromHexString("#36A2EB"),
                ChartColor.FromHexString("#FFCE56")
            },
            Data = new List<double?>() { 300, 50, 100 }
        };

        data.Datasets = new List<Dataset>();
        data.Datasets.Add(dataset);

        chart.Data = data;

        return chart;
    }

    private Chart GenerateNestedDoughnutChart()
    {
        var chart = new Chart();
        chart.Type = Enums.ChartType.Doughnut;

        var data = new Data();
        data.Labels = new List<string>() {
            "resource-group-1",
            "resource-group-2",
            "Data Services - Basic Database Days",
            "Data Services - Basic Database Days",
            "Azure App Service - Basic Small App Service Hours",
            "resource-group-2 - Other"
        };

        var outerDataset = new PieDataset()
        {
            BackgroundColor = new List<ChartColor>() {
                ChartColor.FromHexString("#3366CC"),
                ChartColor.FromHexString("#DC3912"),
                ChartColor.FromHexString("#FF9900"),
                ChartColor.FromHexString("#109618"),
                ChartColor.FromHexString("#990099"),
                ChartColor.FromHexString("#3B3EAC")
            },
            HoverBackgroundColor = new List<ChartColor>() {
                ChartColor.FromHexString("#3366CC"),
                ChartColor.FromHexString("#DC3912"),
                ChartColor.FromHexString("#FF9900"),
                ChartColor.FromHexString("#109618"),
                ChartColor.FromHexString("#990099"),
                ChartColor.FromHexString("#3B3EAC")
            },
            Data = new List<double?>() { 0.0, 0.0, 8.31, 10.43, 84.69, 0.84 }
        };

        var innerDataset = new PieDataset()
        {
            BackgroundColor = new List<ChartColor>() {
                ChartColor.FromHexString("#3366CC"),
                ChartColor.FromHexString("#DC3912"),
                ChartColor.FromHexString("#FF9900"),
                ChartColor.FromHexString("#109618"),
                ChartColor.FromHexString("#990099"),
                ChartColor.FromHexString("#3B3EAC")
            },
            HoverBackgroundColor = new List<ChartColor>() {
                ChartColor.FromHexString("#3366CC"),
                ChartColor.FromHexString("#DC3912"),
                ChartColor.FromHexString("#FF9900"),
                ChartColor.FromHexString("#109618"),
                ChartColor.FromHexString("#990099"),
                ChartColor.FromHexString("#3B3EAC")
            },
            Data = new List<double?>() { 8.31, 95.96 }
        };

        data.Datasets = new List<Dataset>();
        data.Datasets.Add(outerDataset);
        data.Datasets.Add(innerDataset);

        chart.Data = data;

        return chart;
    }
}