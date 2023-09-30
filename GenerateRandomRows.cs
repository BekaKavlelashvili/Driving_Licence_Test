using System.Data;

public class GenerateRandomRows
{
    public static List<DataRow> Generate()
    {
        Random random = new Random();
        int numberOfRandomRows = 15;

        var excelDataTable = GetExcelData.ReadExcelFile();

        if (numberOfRandomRows > excelDataTable.Rows.Count)
        {
            numberOfRandomRows = excelDataTable.Rows.Count;
        }

        List<DataRow> randomRows = new List<DataRow>();

        for (int i = 0; i < numberOfRandomRows; i++)
        {
            int randomRowIndex = random.Next(0, excelDataTable.Rows.Count);
            DataRow randomRow = excelDataTable.Rows[randomRowIndex];
            randomRows.Add(randomRow);
        }

        return randomRows;
    }
}