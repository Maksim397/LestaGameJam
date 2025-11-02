public enum CollisionLayer
{
    PickableIngredient = 6,
    MouseCanGo = 7
}

public static class CollisionExtensions
{
    public static int AsMask(this CollisionLayer layer) =>
      1 << (int)layer;
}
