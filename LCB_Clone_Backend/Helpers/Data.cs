namespace LCB_Clone_Backend.Helpers
{

    public static class DataHelper
    {
        // Helper function for Create Function
        public static string GetStringValue(List<string> arr)
        {
            string result = String.Empty;
            for (int i = 0; i < arr.Count; i++)
            {
                if (i > 0)
                {
                    result += $", {arr[i]}";
                }
                else
                {
                    result += $"{arr[i]}";
                }
            }
            return result;
        }

        // Heper function to get string insert data
        public static string GetInsertValues(List<string> columns, List<string> values)
        {
            string result = "";
            if (columns.Count != values.Count)
            {
                throw new InvalidDataException("Columns array count != values array count");
            }

            int i = 0;
            for (; i < columns.Count - 1; i++)
            {
                result += $"{columns[i]} = {values[i]}, ";
            }
            result += $"{columns[i]} = {values[i]}";

            return result;
        }
    }
}
