namespace PlacementPortal.Domain.Entities
{
    public class College : UserDetail
    {
        public virtual User User { get; set; } = null!;
    }
}
