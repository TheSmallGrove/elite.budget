using System;
using System.Collections.Generic;
using System.Globalization;

namespace Elite.Budget.Mobile.Entities
{
    public class ImportRow
    {
        public ImportRow(Dictionary<string, string> map, string dateFormat)
        {
            var income = string.IsNullOrWhiteSpace(map["Income"]) ? 0.0M : decimal.Parse(map["Income"], CultureInfo.InvariantCulture);
            var outgoing = string.IsNullOrWhiteSpace(map["Outgoing"]) ? 0.0M : decimal.Parse(map["Outgoing"], CultureInfo.InvariantCulture);

            this.Date = DateTime.ParseExact(map["Date"], dateFormat, CultureInfo.InvariantCulture);
            this.Reason = (map["Reason"] ?? "").Trim();
            this.Description = (map["Description"] ?? "").Trim();
            this.Amount = income - outgoing;
            this.Hash = CryptoUtils.Hash(this.ToString());
        }

        public Guid Id { get; set; }
        public string Hash { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public override string ToString()
        {
            return $"[{this.Date}]-[{this.Reason}]-[{this.Description}]-[{this.Amount}]";
        }
    }
}
