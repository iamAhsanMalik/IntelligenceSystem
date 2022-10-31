using ChartJSCore.Models;

namespace IFC.Application.Models;

public class IFCChartsModel
{
    public Chart? VerticalBarChart { get; set; }
    public Chart? HorizontalBarChart { get; set; }
    public Chart? LineChart { get; set; }
    public Chart? LineScatterChart { get; set; }
    public Chart? RadarChart { get; set; }
    public Chart? PolarChart { get; set; }
    public Chart? PieChart { get; set; }
    public Chart? NestedDoughnutChart { get; set; }
}
