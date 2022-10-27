namespace IFC.DataTableServices.ExportService;

public interface IExportService
{
    Task<byte[]> ExportToExcel<T>(List<T> data);

    byte[] ExportToCsv<T>(List<T> data);

    byte[] ExportToHtml<T>(List<T> data);
}
