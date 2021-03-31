using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Artisan.Core.Exceptions;

namespace ToDoApplicationAPI.Biz
{
    /// <summary>
    /// Response contract representing a set of search results.
    /// </summary>
    public class SearchResponse<T>
    {
        private IEnumerable<object> enumerable;
        private int count;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public SearchResponse(IEnumerable<T> data, long totalCount)
        {
            Verify.That(data, nameof(data)).IsNotNull();
            Verify.That(totalCount, nameof(totalCount)).IsGreaterThanOrEqualTo(0);

            Data = data;
            TotalCount = totalCount;
        }

        public SearchResponse(IEnumerable<object> enumerable, int count)
        {
            this.enumerable = enumerable;
            this.count = count;
        }

        /// <summary>
        /// The page of records that match the given search criteria.
        /// </summary>
        [Required]
        public IEnumerable<T> Data { get; set; }

        /// <summary>
        /// The total number of records that match the given search criteria.
        /// </summary>
        [Required]
        public long TotalCount { get; set; }
    }
}
