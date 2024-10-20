﻿using AdvertisementApp.Common.Enums;

namespace AdvertisementApp.Common
{
    public interface IResponse
    {
        string Message { get; set; }
        ResponseType ResponseType { get; set; }
    }
}
