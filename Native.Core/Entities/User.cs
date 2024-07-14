using System;
using System.Collections.Generic;

namespace Native.Core.Entities;
public class User(string email, string password) : BaseEntity
{
    public string Email { get; private set; } = email;
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public bool Active { get; set; } = true;
    public string Password { get; private set; } = password;
    public List<Sneaker> OwnedSneakers { get; private set; } = [];
}