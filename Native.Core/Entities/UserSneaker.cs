namespace Native.Core.Entities;
public class UserSneaker(int idUser, int idSneaker) : BaseEntity
{
    public int IdUser { get; private set; } = idUser;
    public int IdSneaker { get; private set; } = idSneaker;
    public Sneaker Sneaker { get; private set; }
}
