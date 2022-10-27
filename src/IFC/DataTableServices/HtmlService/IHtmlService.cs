namespace IFC.DataTableServices.HtmlService;

public interface IHtmlService
{
    byte[] Write<T>(IList<T> data);
}
