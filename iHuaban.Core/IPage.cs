﻿using iHuaban.Core.Models;

namespace iHuaban.Core
{
    public interface IPage<T> where T: ObservableObject
    {
        T ViewModel { get; }
    }
}
