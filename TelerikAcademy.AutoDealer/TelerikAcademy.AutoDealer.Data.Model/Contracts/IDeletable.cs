﻿using System;

namespace TelerikAcademy.AutoDealer.Data.Model.Contracts
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}