using Elite.Budget.Mobile.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Elite.Budget.Mobile.Import
{
    public interface IImporter
    {
        Task<IEnumerable<ImportRow>> Import(Stream stream);
    }
}