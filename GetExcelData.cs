using ExcelDataReader;
using System.Data;
using System.IO;

public class GetExcelData
{
    public static DataTable ReadExcelFile()
    {
        DataTable dataTable = new DataTable();

        var filePath = @"C:\Users\NEUTRONS\source\repos\Driving_Licence_Test\App_Data\STALL_QB_ENGLISH_NEW.xlsx";

        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);


        using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            IExcelDataReader reader;

            if (filePath.ToString().EndsWith(".xls"))
            {
                reader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            else if (filePath.ToString().EndsWith(".xlsx"))
            {
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }
            else
            {
                throw new Exception("Invalid file format. Only .xls and .xlsx files are supported.");
            }

            DataSet dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            });

            if (dataSet.Tables.Count > 0)
            {
                dataTable = dataSet.Tables[0];
            }

            reader.Close();
        }

        return dataTable;

    }
}