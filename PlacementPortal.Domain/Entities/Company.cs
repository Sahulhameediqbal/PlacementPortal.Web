namespace PlacementPortal.Domain.Entities
{
    public class Company : UserDetail
    {
        public virtual User User { get; set; } = null!;
    }
}
