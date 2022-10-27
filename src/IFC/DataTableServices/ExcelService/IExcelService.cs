namespace IFC.DataTableServices.ExcelService;

public interface IExcelService
{
    Task<byte[]> Write<T>(IList<T> registers);
}
