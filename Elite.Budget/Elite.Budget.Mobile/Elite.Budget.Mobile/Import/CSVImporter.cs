using CsvHelper;
using CsvHelper.Configuration;
using Elite.Budget.Mobile.Entities;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite.Budget.Mobile.Import
{
    partial class CSVImporter : IImporter
    {
        private CSVImportMap Map = new CSVImportMap
        {
            Map = new[] { (1, "Date"), (2, "Reason"), (3, "Description"), (4, "Outgoing"), (5, "Income") }
        };

        public CSVImporter()
        { }

        public async Task<IEnumerable<ImportRow>> Import(Stream stream)
        {
            var read = await this.ReadFileAsync(stream);
            return this.ConvertToRows(read).ToArray();
        }

        private IEnumerable<ImportRow> ConvertToRows(IEnumerable<dynamic> read)
        {
            foreach (ExpandoObject item in read)
            {
                var dictionary = item as IDictionary<string, object>;

                var map = (from i in this.Map.Map
                           select (i.Destination, dictionary.ElementAt(i.SourceIndex).Value))
                           .ToDictionary(_ => _.Destination, _ => (string)_.Value);

                yield return new ImportRow(map, this.Map.DateFormat);
            }
        }

        private Task<IEnumerable<dynamic>> ReadFileAsync(Stream stream)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = this.Map.Delimiter,
                Mode = CsvMode.NoEscape
            };

            using (var reader = new StreamReader(stream))
            {
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<dynamic>();
                    return Task.FromResult<IEnumerable<dynamic>>(records.ToArray());
                }
            }
        }

        class CSVImportMap
        {
            public string DateFormat { get; set; } = "d/MM/yyyy";
            public string Delimiter { get; set; } = ";";
            public IEnumerable<(int SourceIndex, string Destination)> Map { get; set; }
        }
    }
}
