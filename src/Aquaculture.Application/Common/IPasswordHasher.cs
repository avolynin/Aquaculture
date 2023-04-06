﻿namespace Aquaculture.Application.Common;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string passwordHash, string inputPassword);
}
