﻿using System;
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
        Finished,
        InProgress,
        Unread,
        Partial
    }

    public enum BookCondition
    {
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
}
