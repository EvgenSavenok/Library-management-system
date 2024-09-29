using System;
using System.Collections.Generic;

namespace BorrowingManagementService;

public partial class Borrow
{
    public int RecordId { get; set; }

    public int BookId { get; set; }

    public string? BookTitle { get; set; }

    public string? BorrowedDate { get; set; }

    public string? ReturnDate { get; set; }

    public int? IsOverdue { get; set; }
}
