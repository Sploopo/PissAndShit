﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.IO;

namespace PissAndShit.NPCs.Bosses.OddityBoss
{
    class OddityBoss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oddity");
            Main.npcFrameCount[npc.type] = 4;
        }

		public override void SetDefaults()
		{
			npc.width = 48;
			npc.height = 48;
			npc.damage = 500;
			npc.defense = 90;
			npc.lifeMax = 420000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 6000000f;
			npc.knockBackResist = 0f;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noTileCollide = true;
			npc.noGravity = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/LastDance");
			musicPriority = MusicPriority.BossHigh;
			npc.dontTakeDamage = true;
			npc.scale = 1f;
			for (int i = 1; i < 1000; i++)
			{
				npc.ai[0] = 0;
			}
		}
        public override void AI()
        {
			Player player = Main.player[Main.myPlayer];
			npc.direction = npc.spriteDirection = npc.Center.X < player.Center.X ? 1 : -1;
			Vector2 targetPos;
			float speedModifier;
			switch ((int)npc.ai[0])
            {
				case 0:
					targetPos = player.Center;
					targetPos.X += 500 * (npc.Center.X < targetPos.X ? -1 : 1);
					npc.ai[1]++;
					/*DeathAttkCounter3++;
					if (DeathAttkCounter3 > 120)
					{
						npc.velocity.X = 0;
						npc.velocity.Y = 0;
					}*/
					
					
						if (npc.Distance(targetPos) > 50)
						{
							speedModifier = npc.localAI[3] > 0 ? 0.5f : 2f;
							if (npc.Center.X < targetPos.X)
							{
								npc.velocity.X += speedModifier;
								if (npc.velocity.X < 0)
									npc.velocity.X += speedModifier * 2;
							}
							else
							{
								npc.velocity.X -= speedModifier;
								if (npc.velocity.X > 0)
									npc.velocity.X -= speedModifier * 2;
							}
							if (npc.Center.Y < targetPos.Y)
							{
								npc.velocity.Y += speedModifier;
								if (npc.velocity.Y < 0)
									npc.velocity.Y += speedModifier * 2;
							}
							else
							{
								npc.velocity.Y -= speedModifier;
								if (npc.velocity.Y > 0)
									npc.velocity.Y -= speedModifier * 2;
							}
							if (npc.localAI[3] > 0)
							{
								if (Math.Abs(npc.velocity.X) > 24)
									npc.velocity.X = 24 * Math.Sign(npc.velocity.X);
								if (Math.Abs(npc.velocity.Y) > 24)
									npc.velocity.Y = 24 * Math.Sign(npc.velocity.Y);
							}
						}
						npc.ai[1] = 0;
					

					if (npc.ai[1] == 30)
					{
						/*DeathRocketShootOffset = -10;
						for (DeathRocketShootOffset = -10; DeathRocketShootOffset < 10; DeathRocketShootOffset++)
						{
							Projectile.NewProjectile(npc.position, new Vector2(14, -DeathRocketShootOffset), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
						}
						DeathAttkCounter1 = DeathAttkCounter1 + 1;*/
					}
					if (npc.ai[1] == 60)
					{
						/*DeathRocketShootOffset = -10;
						for (DeathRocketShootOffset = -10; DeathRocketShootOffset < 10; DeathRocketShootOffset++)
						{
							Projectile.NewProjectile(new Vector2(npc.position.X, npc.position.Y + 12), new Vector2(-14, DeathRocketShootOffset), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
						}
						DeathAttkCounter1 = DeathAttkCounter1 + 1;*/

						npc.ai[1] = 0;
					}
					/*if (DeathAttkCounter1 == 4)
					{
						DeathRocketsShot = 0;
						DeathRocketShootOffset = 0;
						DeathAttkCounter3 = 0;
						npc.ai[1] = 0;
						npc.ai[0] = 1;
					}*/
					break;

			}
		}


		public override void FindFrame(int frameHeight)
		{
			if (++npc.frameCounter > 4)
			{
				npc.frameCounter = 0;
				npc.frame.Y += frameHeight;
				if (npc.frame.Y >= 4 * frameHeight)
					npc.frame.Y = 0;
			}
		}





	}
}