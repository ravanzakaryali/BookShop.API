﻿namespace BookShop.Application.Asbtarcts.Services.Storage;

public interface IStorageService : IStorage
{
    public string StorageName { get; }
}
