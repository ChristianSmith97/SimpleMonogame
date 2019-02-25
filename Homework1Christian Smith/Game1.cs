using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Homework1Christian_Smith
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Vector2 winPos;
        String winText;
        #region models
        Model player;//animal_rigged_zebu
        Model enemy1;//bone ribcage
        Model enemy2;//boulder stone
        Model enemy3;//cactus
        Model enemy4;//casket timber lid
        Model enemy5;//casket timber open
        Model power1;//candle
        Model power2;//crystal light
        Model cloud;
        Model treeStump;
        Model tree;
        Model bush1;
        Model bush2;
        Model crate;
        Model barrel;
        #endregion
        #region model positions
        Vector3 playerPos;
        List<Vector3> enemy1Pos;
        List<Vector3> enemy2Pos;
        List<Vector3> enemy3Pos;
        List<Vector3> enemy4Pos;
        List<Vector3> enemy5Pos;
        List<Vector3> power1Pos;
        List<Vector3> power2Pos;
        List<Vector3> cloudPos;
        List<Vector3> treeStumpPos;
        List<Vector3> treePos;
        List<Vector3> bush1Pos;
        List<Vector3> bush2Pos;
        List<Vector3> cratePos;
        List<Vector3> barrelPos;
        #endregion
        Vector3 camOffset;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            winText = "WIN";
            winPos = new Vector2(400,240);
            playerPos = Vector3.Zero;
            #region enemy locations
            enemy1Pos = new List<Vector3>();
            enemy1Pos.Add(new Vector3(100, 0, 0));
            enemy1Pos.Add(new Vector3(200, 0, 0));
            enemy1Pos.Add(new Vector3(300, 0, 0));
            enemy2Pos = new List<Vector3>();
            enemy2Pos.Add(new Vector3(75f, 15, 0));
            enemy2Pos.Add(new Vector3(175f, 15, 0));
            enemy2Pos.Add(new Vector3(275f, 15, 0));
            enemy3Pos = new List<Vector3>();
            enemy3Pos.Add(new Vector3(50, 10, 0));
            enemy3Pos.Add(new Vector3(150, 10, 0));
            enemy3Pos.Add(new Vector3(250, 10, 0));
            enemy4Pos = new List<Vector3>();
            enemy4Pos.Add(new Vector3(350, 0, 0));
            enemy4Pos.Add(new Vector3(400, 0, 0));
            enemy4Pos.Add(new Vector3(550, 0, 0));
            enemy5Pos = new List<Vector3>();
            enemy5Pos.Add(new Vector3(375f, 10, 0));
            enemy5Pos.Add(new Vector3(475f, 10, 0));
            enemy5Pos.Add(new Vector3(575f, 10, 0));
            #endregion
            power1Pos = new List<Vector3>();
            power1Pos.Add(new Vector3(25,5,0));
            power1Pos.Add(new Vector3(50, 5, 0));
            #region prop positions
            cloudPos = new List<Vector3>();
            cloudPos.Add(new Vector3(100, 20, -30));
            cloudPos.Add(new Vector3(250, 20, -30));
            cloudPos.Add(new Vector3(500, 20, -30));
            treePos = new List<Vector3>();
            treePos.Add(new Vector3(0, 0, -10));
            treePos.Add(new Vector3(250, 0, -10));
            treePos.Add(new Vector3(420, 0, -10));
            treeStumpPos = new List<Vector3>();
            treeStumpPos.Add(new Vector3(25, 0, -5));
            treeStumpPos.Add(new Vector3(200, 0, -5));
            treeStumpPos.Add(new Vector3(425, 0, -5));
            bush1Pos = new List<Vector3>();
            bush1Pos.Add(new Vector3(10, 0, -10));
            bush1Pos.Add(new Vector3(360, 0, -10));
            bush1Pos.Add(new Vector3(490, 0, -10));
            bush2Pos = new List<Vector3>();
            bush2Pos.Add(new Vector3(50, 0, -10));
            bush2Pos.Add(new Vector3(150, 0, -10));
            bush2Pos.Add(new Vector3(250, 0, -10));
            cratePos = new List<Vector3>();
            cratePos.Add(new Vector3(75, 0, -10));
            cratePos.Add(new Vector3(175, 0, -10));
            cratePos.Add(new Vector3(275, 0, -10));
            barrelPos = new List<Vector3>();
            barrelPos.Add(new Vector3(95, 0, -10));
            barrelPos.Add(new Vector3(280, 0, -10));
            barrelPos.Add(new Vector3(430, 0, -10));
            #endregion
            camOffset = new Vector3(0, 5, 25);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("font");
            player = Content.Load<Model>("Animal_Rigged_Zebu_01");
            enemy1 = Content.Load<Model>("Bone_Ribcage_02");
            enemy2 = Content.Load<Model>("Boulder_Stone_01");
            enemy3 = Content.Load<Model>("Cactus_01");
            enemy4 = Content.Load<Model>("Casket_Timber_Lid_01");
            enemy5 = Content.Load<Model>("Casket_Timber_Open_01");
            power1 = Content.Load<Model>("Candle_01");
            power2 = Content.Load<Model>("Crystal_Light_Blue_01");
            cloud = Content.Load<Model>("Cloud_02");
            treeStump = Content.Load<Model>("Tree_Stump_01");
            tree = Content.Load<Model>("Tree_Pine_04");
            bush1 = Content.Load<Model>("Bush_Large_01");
            bush2 = Content.Load<Model>("Bush_Small_02");
            crate = Content.Load<Model>("Crate_Sealed_01");
            barrel = Content.Load<Model>("Barrel_Sealed_01");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                playerPos.X += 1.0f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                playerPos.X -= 1.0f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                playerPos.Y += 1.0f;
            }
            else
            {
                playerPos.Y -= 1.0f;
                // if playerPos.Y is ever negative (then 0 is bigger) and the answer to max
                playerPos.Y = Math.Max(playerPos.Y, 0.0f);
            }
            for (int b = 0; b < enemy1Pos.Count; b++)
            {
                //enemy1Pos[b] -= new Vector3(0.1f, 0, 0);
                if (Vector3.Distance(enemy1Pos[b], playerPos) < 10)
                    playerPos -= new Vector3(0.2f, 0, 0);
            }
            for (int b = 0; b < enemy2Pos.Count; b++)
            {
                //enemy2Pos[b] -= new Vector3(0.1f, 0, 0);
                if (Vector3.Distance(enemy2Pos[b], playerPos) < 10)
                    playerPos -= new Vector3(0.2f, 0, 0);
            }
            for (int b = 0; b < enemy3Pos.Count; b++)
            {
                //enemy3Pos[b] -= new Vector3(0.1f, 0, 0);
                if (Vector3.Distance(enemy3Pos[b], playerPos) < 10)
                    playerPos -= new Vector3(0.2f, 0, 0);
            }
            for (int b = 0; b < enemy4Pos.Count; b++)
            {
                //enemy4Pos[b] -= new Vector3(0.1f, 0, 0);
                if (Vector3.Distance(enemy4Pos[b], playerPos) < 10)
                    playerPos -= new Vector3(0.2f, 0, 0);
            }
            for (int b = 0; b < enemy5Pos.Count; b++)
            {
                //enemy5Pos[b] -= new Vector3(0.1f, 0, 0);
                if (Vector3.Distance(enemy5Pos[b], playerPos) < 10)
                    playerPos -= new Vector3(0.2f, 0, 0);
            }
            if (Vector3.Distance(power1Pos[0], playerPos) < 10)
                power1Pos[0] = new Vector3(0, -50, 0);
            if (Vector3.Distance(power1Pos[1], playerPos) < 10)
                power1Pos[1] = new Vector3(0, -50, 0);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (playerPos.X>600)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font,
                    winText,
                    winPos,
                    Color.GreenYellow);
                spriteBatch.End();
            }
            //like the properties of lens on a camera
            Matrix proj = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(60), (float)graphics.PreferredBackBufferWidth / graphics.PreferredBackBufferHeight, 0.001f, 100f);

            //how the camera is positioned in world
            Matrix view = Matrix.CreateLookAt(playerPos+camOffset, new Vector3(playerPos.X, 4 + playerPos.Y, 0), new Vector3(0, 1, 0));

            //how the model is positioned in the world
            Matrix world = Matrix.CreateScale(0.005f) * Matrix.CreateRotationY(MathHelper.ToRadians(90)) * Matrix.CreateTranslation(playerPos);

            player.Draw(world, view, proj);
            power1.Draw(world, view, proj);
            power2.Draw(world, view, proj);

            //drawing objects
            foreach (Vector3 pos in power1Pos)
            { //power1
                world = Matrix.CreateScale(0.1f) * Matrix.CreateTranslation(pos);
                power1.Draw(world, view, proj);
            }
            foreach (Vector3 pos in enemy1Pos)
            { //enemy1
                world = Matrix.CreateScale(0.1f) * Matrix.CreateTranslation(pos);
                enemy1.Draw(world, view, proj);
            }
            foreach (Vector3 pos in enemy2Pos)
            { //enemy2
                world = Matrix.CreateScale(0.1f) * Matrix.CreateTranslation(pos);
                enemy2.Draw(world, view, proj);
            }
            foreach (Vector3 pos in enemy3Pos)
            { //enemy3
                world = Matrix.CreateScale(0.1f) * Matrix.CreateTranslation(pos);
                enemy3.Draw(world, view, proj);
            }
            foreach (Vector3 pos in enemy4Pos)
            { //enemy4
                world = Matrix.CreateScale(0.1f) * Matrix.CreateTranslation(pos);
                enemy4.Draw(world, view, proj);
            }
            foreach (Vector3 pos in enemy5Pos)
            { //enemy5
                world = Matrix.CreateScale(0.1f) * Matrix.CreateTranslation(pos);
                enemy5.Draw(world, view, proj);
            }
            foreach (Vector3 pos in cloudPos)
            { //cloud
                world = Matrix.CreateScale(0.1f) * Matrix.CreateTranslation(pos);
                cloud.Draw(world, view, proj);
            }
            foreach (Vector3 pos in treePos)
            { //tree
                world = Matrix.CreateScale(0.1f) * Matrix.CreateTranslation(pos);
                tree.Draw(world, view, proj);
            }
            foreach (Vector3 pos in treeStumpPos)
            { //tree stump
                world = Matrix.CreateScale(0.1f) * Matrix.CreateTranslation(pos);
                treeStump.Draw(world, view, proj);
            }
            foreach (Vector3 pos in bush1Pos)
            { //bush1
                world = Matrix.CreateScale(0.1f) * Matrix.CreateTranslation(pos);
                bush1.Draw(world, view, proj);
            }
            foreach (Vector3 pos in bush2Pos)
            { //bush2
                world = Matrix.CreateScale(0.1f) * Matrix.CreateTranslation(pos);
                bush2.Draw(world, view, proj);
            }
            foreach (Vector3 pos in cratePos)
            { //crate
                world = Matrix.CreateScale(0.1f) * Matrix.CreateTranslation(pos);
                crate.Draw(world, view, proj);
            }
            foreach (Vector3 pos in barrelPos)
            { //barrel
                world = Matrix.CreateScale(0.1f) * Matrix.CreateTranslation(pos);
                barrel.Draw(world, view, proj);
            }

            base.Draw(gameTime);
        }
    }
}
