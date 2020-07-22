using System;
using System.Collections.Generic;
using System.Text;

namespace BookCollector.Models
{
    public enum LendingStatus
    {
        Loaned,
        NotLoaned
    }

    public enum ReadStatus
    {
        Unlisted,
        Finished,
        InProgress,
        Unread,
        Partial
    }

    public enum BookCondition
    {
        Unlisted,
        New,
        LikeNew,
        Good,
        Fair,
        Poor
    }

    public enum Currency
    {
        GBP,
        USD
    }

    public enum SortType
    {
        TitleAsc,
        TitleDesc,
        AuthorAsc,
        AuthorDesc
    }
}
