using IFC.DataTableServices.CsvService;
using IFC.DataTableServices.ExcelService;
using IFC.DataTableServices.HtmlService;

namespace IFC.DataTableServices.ExportService;

public class ExportService : IExportService
{
    private readonly IExcelService _excelService;
    private readonly ICsvService _csvService;
    private readonly IHtmlService _htmlService;

    public ExportService(IExcelService excelService, ICsvService csvService, IHtmlService htmlService)
    {
        _excelService = excelService;
        _csvService = csvService;
        _htmlService = htmlService;
    }

    public async Task<byte[]> ExportToExcel<T>(List<T> data)
    {
        return await _excelService.Write(data);
    }

    public byte[] ExportToCsv<T>(List<T> data)
    {
        return _csvService.Write(data);
    }

    public byte[] ExportToHtml<T>(List<T> data)
    {
        return _htmlService.Write(data);
    }
}
