using System;
using System.ComponentModel.DataAnnotations;
using Artisan.Core.Exceptions;
using Artisan.Service.Core.Web;

namespace ToDoApplicationAPI.Controllers.Contracts
{
    [FieldNamespace("todoitem")]
    public class TodoItemResponse
    {
        /// <summary>
        /// Standard constructor.
        /// </summary>
        public TodoItemResponse(long id, string name, bool isComplete)
        {
            Verify.That(id, nameof(id)).IsGreaterThanOrEqualTo(0);
            Verify.That(name, nameof(name)).IsNotNullOrEmpty();
 
            Id = Id;
            Name = name;
            IsComplete = isComplete;
        }

        /// <summary>
        /// Foreign key to the client this user belongs to.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The username on the account.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Weather or not the user is active.
        /// </summary>
        public bool IsComplete { get; set; }
    }
}