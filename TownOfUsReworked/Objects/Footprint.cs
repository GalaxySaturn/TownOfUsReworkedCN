namespace TownOfUsReworked.Objects
{
    public class Footprint
    {
        public readonly PlayerControl Player;
        public byte PlayerId => Player.PlayerId;
        private GameObject GObject;
        private SpriteRenderer Sprite;
        private readonly float Time2;
        private readonly Vector2 Velocity;
        public Color Color;
        public Vector3 Position;
        private static bool Grey => CustomGameOptions.AnonymousFootPrint || DoUndo.IsCamoed;
        public readonly static Dictionary<PlayerControl, int> OddEven = new();
        private readonly static List<Footprint> AllPrints = new();

        public Footprint(PlayerControl player)
        {
            Position = player.transform.position;
            Velocity = player.gameObject.GetComponent<Rigidbody2D>().velocity;
            Player = player;
            Time2 = (int)Time.time;
            Color = Color.black;
            Start();
            AllPrints.Add(this);

            if (!OddEven.ContainsKey(Player))
                OddEven.Add(Player, 0);
            else
                OddEven[Player]++;
        }

        private void Start()
        {
            GObject = new("Footprint") { layer = 11 };
            GObject.AddSubmergedComponent(ModCompatibility.ElevatorMover);
            GObject.transform.position = Position;
            GObject.transform.localScale *= Player.GetModifiedSize();
            GObject.transform.Rotate(Vector3.forward * Vector2.SignedAngle(Vector2.up, Velocity));
            GObject.transform.SetParent(Player.transform.parent);
            GObject.SetActive(true);

            Sprite = GObject.AddComponent<SpriteRenderer>();
            Sprite.sprite = OddEven[Player] % 2 == 0 ? AssetManager.GetSprite("FootprintLeft") : AssetManager.GetSprite("FootprintRight");
            Sprite.color = Color;
        }

        public void Destroy(bool remove = true)
        {
            GObject.Destroy();

            if (remove)
                AllPrints.Remove(this);
        }

        public bool Update()
        {
            var currentTime = Time.time;
            var alpha = Mathf.Max(1f - ((currentTime - Time2) / CustomGameOptions.FootprintDuration), 0f);

            if (alpha is < 0 or > 1)
                alpha = 0;

            Color = Player.GetPlayerColor(false, Grey);
            Color = new(Color.r, Color.g, Color.b, alpha);
            Sprite.color = Color;

            if (Time2 + CustomGameOptions.FootprintDuration < currentTime)
            {
                Destroy();
                Role.AllRoles.ForEach(x => x.AllPrints.Remove(this));
                return true;
            }
            else
                return false;
        }
    }
}