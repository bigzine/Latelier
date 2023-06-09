﻿using AtelierTennis.API.Models;

namespace AtelierTennis.API.Data;

public interface IPlayerDataProvider
{
    Task<List<Player>?> Get();
}