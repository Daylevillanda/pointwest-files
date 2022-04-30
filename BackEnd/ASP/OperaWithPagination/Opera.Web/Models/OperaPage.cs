using Operas.Data.Models;
using System.Collections.Generic;

namespace Operas.Web.Models
{
    public class OperaPage
    {
        ///<summary>
        /// Gets or sets Opera.
        ///</summary>
        public List<OperaEntity> OperaList { get; set; }

        ///<summary>
        /// Gets or sets CurrentPageIndex.
        ///</summary>
        public int CurrentPageIndex { get; set; }

        ///<summary>
        /// Gets or sets PageCount.
        ///</summary>
        public int PageCount { get; set; }
    }
}
