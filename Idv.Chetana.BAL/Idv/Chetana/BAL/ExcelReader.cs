namespace Idv.Chetana.BAL
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Text;

    public class ExcelReader
    {
        private Stream objStream;
        private StreamReader objReader;

        public ExcelReader(Stream filestream) : this(filestream, null)
        {
        }

        public ExcelReader(Stream filestream, Encoding enc)
        {
            this.objStream = filestream;
            if (filestream.CanRead)
            {
                this.objReader = (enc != null) ? new StreamReader(filestream, enc) : new StreamReader(filestream);
            }
        }

        public string[] GetCSVLine()
        {
            string data = this.objReader.ReadLine();
            if (data == null)
            {
                return null;
            }
            if (data.Length == 0)
            {
                return new string[0];
            }
            ArrayList result = new ArrayList();
            this.ParseCSVData(result, data);
            return (string[]) result.ToArray(typeof(string));
        }

        private int GetSingleQuote(string data, int SFrom)
        {
            int num = SFrom - 1;
            while (++num < data.Length)
            {
                if (data[num] == '"')
                {
                    if ((num < (data.Length - 1)) && (data[num + 1] == '"'))
                    {
                        num++;
                    }
                    else
                    {
                        return num;
                    }
                }
            }
            return -1;
        }

        private void ParseCSVData(ArrayList result, string data)
        {
            int startSeperatorPos = -1;
            while (startSeperatorPos < data.Length)
            {
                result.Add(this.ParseCSVField(ref data, ref startSeperatorPos));
            }
        }

        private string ParseCSVField(ref string data, ref int StartSeperatorPos)
        {
            if (StartSeperatorPos == (data.Length - 1))
            {
                StartSeperatorPos++;
                return "";
            }
            int startIndex = StartSeperatorPos + 1;
            if (data[startIndex] == '"')
            {
                int singleQuote = this.GetSingleQuote(data, startIndex + 1);
                int num3 = 1;
                while (singleQuote == -1)
                {
                    data = data + "\n" + this.objReader.ReadLine();
                    singleQuote = this.GetSingleQuote(data, startIndex + 1);
                    num3++;
                    if (num3 > 20)
                    {
                        throw new Exception("lines overflow: " + data);
                    }
                }
                StartSeperatorPos = singleQuote + 1;
                return data.Substring(startIndex + 1, (singleQuote - startIndex) - 1).Replace("'", "''").Replace("\"\"", "\"");
            }
            int index = data.IndexOf(',', startIndex);
            if (index == -1)
            {
                StartSeperatorPos = data.Length;
                return data.Substring(startIndex);
            }
            StartSeperatorPos = index;
            return data.Substring(startIndex, index - startIndex);
        }
    }
}

