﻿using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.GradeBooks;

namespace GradeBook.GradeBooks
{
    class StandardGradeBook : BaseGradeBook
    {
        StandardGradeBook(string name) : base(name)
        {
            base.Type = Enums.GradeBookType.Standard;
        }
    }
}