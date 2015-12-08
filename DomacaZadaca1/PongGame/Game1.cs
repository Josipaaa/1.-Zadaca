using DomacaZadaca1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PongGame {


    public class Game1 : Game {

        public Paddle PaddleBottom { get; private set; }

        public Paddle PaddleTop { get; private set; }

        public Ball Ball { get; private set; }

        public Background Background { get; private set; }

        public SoundEffect HitSound { get; private set; }

        public Song Music { get; private set; }

        private IGenericList<Sprite> SpritesForDrawList = new GenericList<Sprite>();

        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        public Game1() {
            graphics = new GraphicsDeviceManager(this) {

                PreferredBackBufferHeight = 900,
                PreferredBackBufferWidth = 500

            };

            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent() {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            var screenBounds = GraphicsDevice.Viewport.Bounds;

            Texture2D paddleTexture = Content.Load<Texture2D>("paddle");

            PaddleBottom = new Paddle(paddleTexture);
            PaddleTop = new Paddle(paddleTexture);

            PaddleBottom.Position = new Vector2(screenBounds.X + 150, screenBounds.Y + 880);
            PaddleTop.Position = new Vector2(screenBounds.X + 150, screenBounds.Y);

            Texture2D ballTexture = Content.Load<Texture2D>("ball");

            Ball = new Ball(ballTexture);
            Ball.Position = screenBounds.Center.ToVector2();

            Texture2D backgroundTexture = Content.Load<Texture2D>("background");

            Background = new Background(backgroundTexture, screenBounds.Width, screenBounds.Height);

            HitSound = Content.Load<SoundEffect>("hit");
            Music = Content.Load<Song>("music");

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(Music);

            SpritesForDrawList.Add(Background);
            SpritesForDrawList.Add(PaddleBottom);
            SpritesForDrawList.Add(PaddleTop);
            SpritesForDrawList.Add(Ball);

        }

        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime) {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Ball.Position += Ball.Direction * (float)(gameTime.ElapsedGameTime.TotalMilliseconds * Ball.Speed);

            var bounds = GraphicsDevice.Viewport.Bounds;
            if (Ball.Position.X < bounds.Left || Ball.Position.X > bounds.Right - Ball.Size.Width) {
                Ball.Direction.X = -Ball.Direction.X;
                Ball.Speed = Ball.Speed * Ball.BumpSpeedIncreaseFactor;
                HitSound.Play();
            }
            if (Ball.Position.Y > bounds.Bottom || Ball.Position.Y < bounds.Top) {
                Ball.Position = bounds.Center.ToVector2();
                Ball.Speed = Ball.InitialSpeed;
            }
            if (CollisionDetector.Overlaps(Ball, PaddleTop) && Ball.Direction.Y < 0 || (CollisionDetector.Overlaps(Ball, PaddleBottom) && Ball.Direction.Y > 0)) {
                Ball.Direction.Y = -Ball.Direction.Y;
                Ball.Speed *= Ball.BumpSpeedIncreaseFactor;
            }

            var touchState = Keyboard.GetState();
            if (touchState.IsKeyDown(Keys.Left)) {
                PaddleBottom.Position.X -= (float)(PaddleBottom.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
                PaddleBottom.Position.X = MathHelper.Clamp(PaddleBottom.Position.X, graphics.GraphicsDevice.Viewport.Bounds.Left, graphics.GraphicsDevice.Viewport.Bounds.Right - PaddleBottom.Size.Width);
            }
            if (touchState.IsKeyDown(Keys.Right)) {
                PaddleBottom.Position.X += (float)(PaddleBottom.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
                PaddleBottom.Position.X = MathHelper.Clamp(PaddleBottom.Position.X, graphics.GraphicsDevice.Viewport.Bounds.Left, graphics.GraphicsDevice.Viewport.Bounds.Right - PaddleBottom.Size.Width);
            }
            if (touchState.IsKeyDown(Keys.A)) {
                PaddleTop.Position.X -= (float)(PaddleTop.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
                PaddleTop.Position.X = MathHelper.Clamp(PaddleTop.Position.X, graphics.GraphicsDevice.Viewport.Bounds.Left, graphics.GraphicsDevice.Viewport.Bounds.Right - PaddleBottom.Size.Width);
            }
            if (touchState.IsKeyDown(Keys.D)) {
                PaddleTop.Position.X += (float)(PaddleTop.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
                PaddleTop.Position.X = MathHelper.Clamp(PaddleTop.Position.X, graphics.GraphicsDevice.Viewport.Bounds.Left, graphics.GraphicsDevice.Viewport.Bounds.Right - PaddleBottom.Size.Width);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            for (int i = 0; i < SpritesForDrawList.Count; i++) {

                SpritesForDrawList.GetElement(i).Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
