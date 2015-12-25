﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bitmap = SharpDX.Direct2D1.Bitmap;
using Color = SharpDX.Color;

namespace IceBlink2
{
    public class ScreenMainMap
    {
        public Module mod;
        public GameView gv;

        
        private IbbButton btnParty = null;
        private IbbButton btnJournal = null;
        private IbbButton btnSettings = null;
        private IbbButton btnSave = null;
        private IbbButton btnCastOnMainMap = null;
        private IbbButton btnWait = null;
        public IbbToggleButton tglFullParty = null;
        public IbbToggleButton tglMiniMap = null;
        public IbbToggleButton tglGrid = null;
        public IbbToggleButton tglInteractionState = null;
        public IbbToggleButton tglAvoidConversation = null;
        public IbbToggleButton tglClock = null;
        public List<FloatyText> floatyTextPool = new List<FloatyText>();
        public List<FloatyTextByPixel> floatyTextByPixelPool = new List<FloatyTextByPixel>();
        public int mapStartLocXinPixels;
        public int movementDelayInMiliseconds = 100;
        private long timeStamp = 0;
        private bool finishedMove = true;
        public Bitmap minimap = null;
        public Bitmap fullScreenEffect1 = null;
        public Bitmap fullScreenEffect2 = null;
        public Bitmap fullScreenEffect3 = null;
        public Bitmap fullScreenEffect4 = null;
        public Bitmap fullScreenEffect5 = null;
        public Bitmap fullScreenEffect6 = null;
        public Bitmap fullScreenEffect7 = null;
        public Bitmap fullScreenEffect8 = null;
        public Bitmap fullScreenEffect9 = null;
        public Bitmap fullScreenEffect10 = null;

        public ScreenMainMap(Module m, GameView g)
        {
            mod = m;
            gv = g;
            mapStartLocXinPixels = 6 * gv.squareSize;
            setControlsStart();
            setToggleButtonsStart();
        }

        
        public void setControlsStart()
        {
            int pW = (int)((float)gv.screenWidth / 100.0f);
            int pH = (int)((float)gv.screenHeight / 100.0f);
            int padW = gv.squareSize / 6;
            int hotkeyShift = 0;
            if (gv.useLargeLayout)
            {
                hotkeyShift = 1;
            }


            if (btnWait == null)
            {
                btnWait = new IbbButton(gv, 0.8f);
                btnWait.Text = "WAIT";
                btnWait.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(getResources(), R.drawable.btn_small);
                btnWait.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(getResources(), R.drawable.btn_small_glow);
                //btnWait.X = 17 * gv.squareSize - 3*gv.oXshift;
                //btnWait.Y = 8 * gv.squareSize + pH * 2;
                btnWait.X = gv.cc.pnlArrows.LocX + 1 * gv.squareSize + gv.squareSize / 2;
                btnWait.Y = gv.cc.pnlArrows.LocY + 1 * gv.squareSize + gv.pS;
                btnWait.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnWait.Width = (int)(gv.ibbwidthR * gv.screenDensity);
            }
            if (btnParty == null)
            {
                btnParty = new IbbButton(gv, 0.8f);
                btnParty.HotKey = "P";
                btnParty.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(getResources(), R.drawable.btn_small);
                btnParty.Img2 = gv.cc.LoadBitmap("btnparty"); // BitmapFactory.decodeResource(getResources(), R.drawable.btnparty);
                btnParty.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(getResources(), R.drawable.btn_small_glow);
                //btnParty.X = 7 * gv.squareSize + padW * 0 + gv.oXshift;
                //btnParty.Y = 9 * gv.squareSize + +(int)(1.75 * pH);
                btnParty.X = gv.cc.pnlHotkeys.LocX + (hotkeyShift + 0) * gv.squareSize;
                btnParty.Y = gv.cc.pnlHotkeys.LocY + 0 * gv.squareSize + gv.pS;
                btnParty.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnParty.Width = (int)(gv.ibbwidthR * gv.screenDensity);
            }
            if (btnJournal == null)
            {
                btnJournal = new IbbButton(gv, 0.8f);
                btnJournal.HotKey = "J";
                btnJournal.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(getResources(), R.drawable.btn_small);
                btnJournal.Img2 = gv.cc.LoadBitmap("btnjournal"); // BitmapFactory.decodeResource(getResources(), R.drawable.btnjournal);
                btnJournal.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(getResources(), R.drawable.btn_small_glow);
                //btnJournal.X = 9 * gv.squareSize + padW * 0 + gv.oXshift;
                //btnJournal.Y = 9 * gv.squareSize + +(int)(1.75 * pH);
                btnJournal.X = gv.cc.pnlHotkeys.LocX + (hotkeyShift + 2) * gv.squareSize;
                btnJournal.Y = gv.cc.pnlHotkeys.LocY + 0 * gv.squareSize + gv.pS;
                btnJournal.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnJournal.Width = (int)(gv.ibbwidthR * gv.screenDensity);
            }
            if (btnSettings == null)
            {
                btnSettings = new IbbButton(gv, 1.0f);
                btnSettings.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(getResources(), R.drawable.btn_small);
                btnSettings.Img2 = gv.cc.LoadBitmap("btnsettings"); // BitmapFactory.decodeResource(getResources(), R.drawable.btnsettings);
                btnSettings.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(getResources(), R.drawable.btn_small_glow);
                //btnSettings.X = 10 * gv.squareSize + padW * 0 + gv.oXshift;
                //btnSettings.Y = 9 * gv.squareSize + +(int)(1.75 * pH);
                btnSettings.X = gv.cc.pnlHotkeys.LocX + (hotkeyShift + 3) * gv.squareSize;
                btnSettings.Y = gv.cc.pnlHotkeys.LocY + 0 * gv.squareSize + gv.pS;
                btnSettings.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnSettings.Width = (int)(gv.ibbwidthR * gv.screenDensity);
            }
            if (btnCastOnMainMap == null)
            {
                btnCastOnMainMap = new IbbButton(gv, 0.8f);
                btnCastOnMainMap.HotKey = "C";
                btnCastOnMainMap.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(getResources(), R.drawable.btn_small);
                btnCastOnMainMap.Img2 = gv.cc.LoadBitmap("btnspell"); // BitmapFactory.decodeResource(getResources(), R.drawable.btnspell);
                btnCastOnMainMap.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(getResources(), R.drawable.btn_small_glow);
                //btnCastOnMainMap.X = 11 * gv.squareSize + padW * 0 + gv.oXshift;
                //btnCastOnMainMap.Y = 9 * gv.squareSize + +(int)(1.75 * pH);
                btnCastOnMainMap.X = gv.cc.pnlHotkeys.LocX + (hotkeyShift + 4) * gv.squareSize;
                btnCastOnMainMap.Y = gv.cc.pnlHotkeys.LocY + 0 * gv.squareSize + gv.pS;
                btnCastOnMainMap.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnCastOnMainMap.Width = (int)(gv.ibbwidthR * gv.screenDensity);
            }
            if (btnSave == null)
            {
                btnSave = new IbbButton(gv, 0.8f);
                btnSave.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(getResources(), R.drawable.btn_small);
                btnSave.ImgOff = gv.cc.LoadBitmap("btn_small_off");
                btnSave.Img2 = gv.cc.LoadBitmap("btndisk"); // BitmapFactory.decodeResource(getResources(), R.drawable.btndisk);
                btnSave.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(getResources(), R.drawable.btn_small_glow);
                //btnSave.X = 12 * gv.squareSize + padW * 0 + gv.oXshift;
                //btnSave.Y = 9 * gv.squareSize + +(int)(1.75 * pH);
                btnSave.X = gv.cc.pnlHotkeys.LocX + (hotkeyShift + 5) * gv.squareSize;
                btnSave.Y = gv.cc.pnlHotkeys.LocY + 0 * gv.squareSize + gv.pS;
                btnSave.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnSave.Width = (int)(gv.ibbwidthR * gv.screenDensity);
            }
        }
        public void setToggleButtonsStart()
        {
            int pW = (int)((float)gv.screenWidth / 100.0f);
            int pH = (int)((float)gv.screenHeight / 100.0f);
            int padW = gv.squareSize / 6;

            if (tglFullParty == null)
            {
                tglFullParty = new IbbToggleButton(gv);
                tglFullParty.ImgOn = gv.cc.LoadBitmap("tgl_fullparty_on");
                tglFullParty.ImgOff = gv.cc.LoadBitmap("tgl_fullparty_off");
                //tglFullParty.X = 0 * gv.squareSize + gv.oXshift + (gv.squareSize / 2);
                //tglFullParty.Y = 9 * (gv.squareSize) + (gv.squareSize / 2);
                tglFullParty.X = gv.cc.pnlToggles.LocX + 1 * gv.squareSize + gv.squareSize / 4;
                tglFullParty.Y = gv.cc.pnlToggles.LocY + 0 * gv.squareSize + gv.squareSize / 4 + gv.pS;
                tglFullParty.Height = (int)(gv.ibbheight / 2 * gv.screenDensity);
                tglFullParty.Width = (int)(gv.ibbwidthR / 2 * gv.screenDensity);
                tglFullParty.toggleOn = true;
            }
            if (tglMiniMap == null)
            {
                tglMiniMap = new IbbToggleButton(gv);
                tglMiniMap.ImgOn = gv.cc.LoadBitmap("tgl_minimap_on");
                tglMiniMap.ImgOff = gv.cc.LoadBitmap("tgl_minimap_off");
                //tglMiniMap.X = 4 * gv.squareSize + gv.oXshift + (gv.squareSize / 2);
                //tglMiniMap.Y = 9 * (gv.squareSize) + (gv.squareSize / 2);
                tglMiniMap.X = gv.cc.pnlToggles.LocX + 2 * gv.squareSize + gv.squareSize / 4;
                tglMiniMap.Y = gv.cc.pnlToggles.LocY + 2 * gv.squareSize + gv.squareSize / 4 + gv.pS;
                tglMiniMap.Height = (int)(gv.ibbheight / 2 * gv.screenDensity);
                tglMiniMap.Width = (int)(gv.ibbwidthR / 2 * gv.screenDensity);
                tglMiniMap.toggleOn = false;
            }
            if (tglGrid == null)
            {
                tglGrid = new IbbToggleButton(gv);
                tglGrid.ImgOn = gv.cc.LoadBitmap("tgl_grid_on");
                tglGrid.ImgOff = gv.cc.LoadBitmap("tgl_grid_off");
                //tglGrid.X = 1 * gv.squareSize + gv.oXshift + (gv.squareSize / 2);
                //tglGrid.Y = 9 * (gv.squareSize) + (gv.squareSize / 2);
                tglGrid.X = gv.cc.pnlToggles.LocX + 1 * gv.squareSize + gv.squareSize / 4;
                tglGrid.Y = gv.cc.pnlToggles.LocY + 1 * gv.squareSize + gv.squareSize / 4 + gv.pS;
                tglGrid.Height = (int)(gv.ibbheight / 2 * gv.screenDensity);
                tglGrid.Width = (int)(gv.ibbwidthR / 2 * gv.screenDensity);
                tglGrid.toggleOn = true;
            }
            if (tglClock == null)
            {
                tglClock = new IbbToggleButton(gv);
                tglClock.ImgOn = gv.cc.LoadBitmap("tgl_clock_on");
                tglClock.ImgOff = gv.cc.LoadBitmap("tgl_clock_off");
                //tglClock.X = 2 * gv.squareSize + gv.oXshift + (gv.squareSize / 2);
                //tglClock.Y = 9 * (gv.squareSize) + (gv.squareSize / 2);
                tglClock.X = gv.cc.pnlToggles.LocX + 3 * gv.squareSize + gv.squareSize / 4;
                tglClock.Y = gv.cc.pnlToggles.LocY + 2 * gv.squareSize + gv.squareSize / 4 + gv.pS;
                tglClock.Height = (int)(gv.ibbheight / 2 * gv.screenDensity);
                tglClock.Width = (int)(gv.ibbwidthR / 2 * gv.screenDensity);
                tglClock.toggleOn = true;
            }
            if (tglInteractionState == null)
            {
                tglInteractionState = new IbbToggleButton(gv);
                tglInteractionState.ImgOn = gv.cc.LoadBitmap("tgl_state_on");
                tglInteractionState.ImgOff = gv.cc.LoadBitmap("tgl_state_off");
                //tglInteractionState.X = 1 * gv.squareSize + gv.oXshift + (gv.squareSize / 2);
                //tglInteractionState.Y = 8 * (gv.squareSize) + (gv.squareSize / 2);
                tglInteractionState.X = gv.cc.pnlToggles.LocX + 3 * gv.squareSize + gv.squareSize / 4;
                tglInteractionState.Y = gv.cc.pnlToggles.LocY + 0 * gv.squareSize + gv.squareSize / 4 + gv.pS;
                tglInteractionState.Height = (int)(gv.ibbheight / 2 * gv.screenDensity);
                tglInteractionState.Width = (int)(gv.ibbwidthR / 2 * gv.screenDensity);
                tglInteractionState.toggleOn = false;
            }
            if (tglAvoidConversation == null)
            {
                tglAvoidConversation = new IbbToggleButton(gv);
                tglAvoidConversation.ImgOn = gv.cc.LoadBitmap("tgl_avoidConvo_on");
                tglAvoidConversation.ImgOff = gv.cc.LoadBitmap("tgl_avoidConvo_off");
                //tglAvoidConversation.X = 0 * gv.squareSize + gv.oXshift + (gv.squareSize / 2);
                //tglAvoidConversation.Y = 8 * (gv.squareSize) + (gv.squareSize / 2);
                tglAvoidConversation.X = gv.cc.pnlToggles.LocX + 2 * gv.squareSize + gv.squareSize / 4;
                tglAvoidConversation.Y = gv.cc.pnlToggles.LocY + 0 * gv.squareSize + gv.squareSize / 4 + gv.pS;
                tglAvoidConversation.Height = (int)(gv.ibbheight / 2 * gv.screenDensity);
                tglAvoidConversation.Width = (int)(gv.ibbwidthR / 2 * gv.screenDensity);
                tglAvoidConversation.toggleOn = false;
            }
        }

        //MAIN SCREEN
        public void resetMiniMapBitmap()
        {            
            int minimapSquareSizeInPixels = 4 * gv.squareSize / mod.currentArea.MapSizeX;
            int drawW = minimapSquareSizeInPixels * mod.currentArea.MapSizeX;
            int drawH = minimapSquareSizeInPixels * mod.currentArea.MapSizeY;
            using (System.Drawing.Bitmap surface = new System.Drawing.Bitmap(drawW, drawH))
            {
                using (Graphics device = Graphics.FromImage(surface))
                {
                    //draw background image first
                    if ((!mod.currentArea.ImageFileName.Equals("none")) && (gv.cc.bmpMap != null))
                    {
                        System.Drawing.Bitmap bg = gv.cc.LoadBitmapGDI(mod.currentArea.ImageFileName);
                        Rectangle srcBG = new Rectangle(0, 0, bg.Width, bg.Height);
                        Rectangle dstBG = new Rectangle(mod.currentArea.backgroundImageStartLocX * minimapSquareSizeInPixels, 
                                                        mod.currentArea.backgroundImageStartLocY * minimapSquareSizeInPixels, 
                                                        minimapSquareSizeInPixels * (bg.Width / 50), 
                                                        minimapSquareSizeInPixels * (bg.Height / 50));
                        device.DrawImage(bg, dstBG, srcBG, GraphicsUnit.Pixel);
                        bg.Dispose();
                        bg = null;
                    }
                    #region Draw Layer 1
                    for (int x = 0; x < mod.currentArea.MapSizeX; x++)
                    {
                        for (int y = 0; y < mod.currentArea.MapSizeY; y++)
                        {
                            Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];
                            Rectangle src = new Rectangle(0, 0, gv.cc.tileBitmapList[tile.Layer1Filename].PixelSize.Width, gv.cc.tileBitmapList[tile.Layer1Filename].PixelSize.Height);
                            float scalerX = gv.cc.tileBitmapList[tile.Layer1Filename].PixelSize.Width / 100;
                            float scalerY = gv.cc.tileBitmapList[tile.Layer1Filename].PixelSize.Height / 100;
                            int brX = (int)(minimapSquareSizeInPixels * scalerX);
                            int brY = (int)(minimapSquareSizeInPixels * scalerY);
                            Rectangle dst = new Rectangle(x * minimapSquareSizeInPixels, y * minimapSquareSizeInPixels, brX, brY);
                            device.DrawImage(gv.cc.tileGDIBitmapList[tile.Layer1Filename], dst, src, GraphicsUnit.Pixel);
                        }
                    }
                    #endregion
                    #region Draw Layer 2
                    for (int x = 0; x < mod.currentArea.MapSizeX; x++)
                    {
                        for (int y = 0; y < mod.currentArea.MapSizeY; y++)
                        {
                            Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];
                            Rectangle src = new Rectangle(0, 0, gv.cc.tileBitmapList[tile.Layer2Filename].PixelSize.Width, gv.cc.tileBitmapList[tile.Layer2Filename].PixelSize.Height);
                            float scalerX = gv.cc.tileBitmapList[tile.Layer2Filename].PixelSize.Width / 100;
                            float scalerY = gv.cc.tileBitmapList[tile.Layer2Filename].PixelSize.Height / 100;
                            int brX = (int)(minimapSquareSizeInPixels * scalerX);
                            int brY = (int)(minimapSquareSizeInPixels * scalerY);
                            Rectangle dst = new Rectangle(x * minimapSquareSizeInPixels, y * minimapSquareSizeInPixels, brX, brY);
                            device.DrawImage(gv.cc.tileGDIBitmapList[tile.Layer2Filename], dst, src, GraphicsUnit.Pixel);
                        }
                    }
                    #endregion
                    #region Draw Layer 3
                    for (int x = 0; x < mod.currentArea.MapSizeX; x++)
                    {
                        for (int y = 0; y < mod.currentArea.MapSizeY; y++)
                        {
                            Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];
                            Rectangle src = new Rectangle(0, 0, gv.cc.tileBitmapList[tile.Layer3Filename].PixelSize.Width, gv.cc.tileBitmapList[tile.Layer3Filename].PixelSize.Height);
                            float scalerX = gv.cc.tileBitmapList[tile.Layer3Filename].PixelSize.Width / 100;
                            float scalerY = gv.cc.tileBitmapList[tile.Layer3Filename].PixelSize.Height / 100;
                            int brX = (int)(minimapSquareSizeInPixels * scalerX);
                            int brY = (int)(minimapSquareSizeInPixels * scalerY);
                            Rectangle dst = new Rectangle(x * minimapSquareSizeInPixels, y * minimapSquareSizeInPixels, brX, brY);
                            device.DrawImage(gv.cc.tileGDIBitmapList[tile.Layer3Filename], dst, src, GraphicsUnit.Pixel);
                        }
                    }
                    #endregion
                    #region Draw Layer 4
                    for (int x = 0; x < mod.currentArea.MapSizeX; x++)
                    {
                        for (int y = 0; y < mod.currentArea.MapSizeY; y++)
                        {
                            Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];
                            Rectangle src = new Rectangle(0, 0, gv.cc.tileBitmapList[tile.Layer4Filename].PixelSize.Width, gv.cc.tileBitmapList[tile.Layer4Filename].PixelSize.Height);
                            float scalerX = gv.cc.tileBitmapList[tile.Layer4Filename].PixelSize.Width / 100;
                            float scalerY = gv.cc.tileBitmapList[tile.Layer4Filename].PixelSize.Height / 100;
                            int brX = (int)(minimapSquareSizeInPixels * scalerX);
                            int brY = (int)(minimapSquareSizeInPixels * scalerY);
                            Rectangle dst = new Rectangle(x * minimapSquareSizeInPixels, y * minimapSquareSizeInPixels, brX, brY);
                            device.DrawImage(gv.cc.tileGDIBitmapList[tile.Layer4Filename], dst, src, GraphicsUnit.Pixel);
                        }
                    }
                    #endregion
                    #region Draw Layer 5
                    for (int x = 0; x < mod.currentArea.MapSizeX; x++)
                    {
                        for (int y = 0; y < mod.currentArea.MapSizeY; y++)
                        {
                            Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];
                            Rectangle src = new Rectangle(0, 0, gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Width, gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Height);
                            float scalerX = gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Width / 100;
                            float scalerY = gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Height / 100;
                            int brX = (int)(minimapSquareSizeInPixels * scalerX);
                            int brY = (int)(minimapSquareSizeInPixels * scalerY);
                            Rectangle dst = new Rectangle(x * minimapSquareSizeInPixels, y * minimapSquareSizeInPixels, brX, brY);
                            device.DrawImage(gv.cc.tileGDIBitmapList[tile.Layer5Filename], dst, src, GraphicsUnit.Pixel);
                        }
                    }
                    #endregion
                    minimap = gv.cc.ConvertGDIBitmapToD2D((System.Drawing.Bitmap)surface.Clone());
                }
            }
        }
        public void redrawMain()
        {
       
            setExplored();
            if (!mod.currentArea.areaDark)
            {
                drawBottomFullScreenEffects();
                if ((!mod.currentArea.ImageFileName.Equals("none")) && (gv.cc.bmpMap != null))
                {
                    drawMap();
                }
                drawWorldMap();
                /*if (mod.currentArea.IsWorldMap)
                {
                    drawWorldMap();
                }
                else
                {
                    drawMap();
                }*/
                drawProps();
                if (mod.map_showGrid)
                {
                    tglGrid.toggleOn = true;
                    drawGrid();
                }
                else
                {
                    tglGrid.toggleOn = false;
                }
            }
            drawPlayer();
            if (!mod.currentArea.areaDark)
            {
                drawMovingProps();
            }
            drawMainMapFloatyText();
            if (!mod.currentArea.areaDark)
            {
                bool hideOverlayNeeded = false;
                if (mod.currentArea.UseDayNightCycle)
                {
                    drawOverlayTints();
                    hideOverlayNeeded = true;
                }

                //off for now, later :-)
                //if (mod.currentArea.useWeather)
                //{
                    //drawOverlayWeather();
                    //hideOverlayNeeded = true;
                //}

                if (hideOverlayNeeded)
                {
                    drawBlackTilesOverTints();
                    hideOverlayNeeded = false;
                }
                drawFogOfWar();
            }            
            drawFloatyTextPool();
            if (gv.mod.useSmoothMovement)
            {
                drawFloatyTextByPixelPool();
            }

            if (tglClock.toggleOn)
            {
                drawMainMapClockText();
            }
            if (mod.useUIBackground)
            {
                drawPanels();
            }
            drawTopFullScreenEffects();
            gv.drawLog();
            drawControls();
            drawMiniMap();
            drawPortraits();
        }
        public void drawPortraits()
        {
            if (mod.playerList.Count > 0)
            {
                gv.cc.ptrPc0.Img = mod.playerList[0].portrait;
                gv.cc.ptrPc0.TextHP = mod.playerList[0].hp + "/" + mod.playerList[0].hpMax;
                gv.cc.ptrPc0.TextSP = mod.playerList[0].sp + "/" + mod.playerList[0].spMax;
                if (gv.mod.selectedPartyLeader == 0) { gv.cc.ptrPc0.glowOn = true; }
                else { gv.cc.ptrPc0.glowOn = false; }
                gv.cc.ptrPc0.Draw();
            }
            if (mod.playerList.Count > 1)
            {
                gv.cc.ptrPc1.Img = mod.playerList[1].portrait;
                gv.cc.ptrPc1.TextHP = mod.playerList[1].hp + "/" + mod.playerList[1].hpMax;
                gv.cc.ptrPc1.TextSP = mod.playerList[1].sp + "/" + mod.playerList[1].spMax;
                if (gv.mod.selectedPartyLeader == 1) { gv.cc.ptrPc1.glowOn = true; }
                else { gv.cc.ptrPc1.glowOn = false; }
                gv.cc.ptrPc1.Draw();
            }
            if (mod.playerList.Count > 2)
            {
                gv.cc.ptrPc2.Img = mod.playerList[2].portrait;
                gv.cc.ptrPc2.TextHP = mod.playerList[2].hp + "/" + mod.playerList[2].hpMax;
                gv.cc.ptrPc2.TextSP = mod.playerList[2].sp + "/" + mod.playerList[2].spMax;
                if (gv.mod.selectedPartyLeader == 2) { gv.cc.ptrPc2.glowOn = true; }
                else { gv.cc.ptrPc2.glowOn = false; }
                gv.cc.ptrPc2.Draw();
            }
            if (mod.playerList.Count > 3)
            {
                gv.cc.ptrPc3.Img = mod.playerList[3].portrait;
                gv.cc.ptrPc3.TextHP = mod.playerList[3].hp + "/" + mod.playerList[3].hpMax;
                gv.cc.ptrPc3.TextSP = mod.playerList[3].sp + "/" + mod.playerList[3].spMax;
                if (gv.mod.selectedPartyLeader == 3) { gv.cc.ptrPc3.glowOn = true; }
                else { gv.cc.ptrPc3.glowOn = false; }
                gv.cc.ptrPc3.Draw();
            }
            if (mod.playerList.Count > 4)
            {
                gv.cc.ptrPc4.Img = mod.playerList[4].portrait;
                gv.cc.ptrPc4.TextHP = mod.playerList[4].hp + "/" + mod.playerList[4].hpMax;
                gv.cc.ptrPc4.TextSP = mod.playerList[4].sp + "/" + mod.playerList[4].spMax;
                if (gv.mod.selectedPartyLeader == 4) { gv.cc.ptrPc4.glowOn = true; }
                else { gv.cc.ptrPc4.glowOn = false; }
                gv.cc.ptrPc4.Draw();
            }
            if (mod.playerList.Count > 5)
            {
                gv.cc.ptrPc5.Img = mod.playerList[5].portrait;
                gv.cc.ptrPc5.TextHP = mod.playerList[5].hp + "/" + mod.playerList[5].hpMax;
                gv.cc.ptrPc5.TextSP = mod.playerList[5].sp + "/" + mod.playerList[5].spMax;
                if (gv.mod.selectedPartyLeader == 5) { gv.cc.ptrPc5.glowOn = true; }
                else { gv.cc.ptrPc5.glowOn = false; }
                gv.cc.ptrPc5.Draw();
            }
        }
        public void drawWorldMap()
        {
            int minX = mod.PlayerLocationX - gv.playerOffset - 2; //using -2 in case a large tile (3x3) needs to start off the visible map space to be seen
            if (minX < 0) { minX = 0; }
            int minY = mod.PlayerLocationY - gv.playerOffset - 2; //using -2 in case a large tile (3x3) needs to start off the visible map space to be seen
            if (minY < 0) { minY = 0; }

            int maxX = mod.PlayerLocationX + gv.playerOffset + 1;
            if (maxX > this.mod.currentArea.MapSizeX) { maxX = this.mod.currentArea.MapSizeX; }
            int maxY = mod.PlayerLocationY + gv.playerOffset + 1;
            if (maxY > this.mod.currentArea.MapSizeY) { maxY = this.mod.currentArea.MapSizeY; }

            #region Draw Layer 1
            for (int x = minX; x < maxX; x++)
            {
                for (int y = minY; y < maxY; y++)
                {
                    Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];
                    int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                    int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;
                    float scalerX = gv.cc.tileBitmapList[tile.Layer1Filename].PixelSize.Width / 100;
                    float scalerY = gv.cc.tileBitmapList[tile.Layer1Filename].PixelSize.Height / 100;
                    int brX = (int)(gv.squareSize * scalerX);
                    int brY = (int)(gv.squareSize * scalerY);
                                        
                    try
                    {
                        IbRect src = new IbRect(0, 0, gv.cc.tileBitmapList[tile.Layer1Filename].PixelSize.Width, gv.cc.tileBitmapList[tile.Layer1Filename].PixelSize.Height);
                        IbRect dst = new IbRect(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                        gv.DrawBitmap(gv.cc.tileBitmapList[tile.Layer1Filename], src, dst);
                    }
                    catch { }
                }
            }
            #endregion
            #region Draw Layer 2
            for (int x = minX; x < maxX; x++)
            {
                for (int y = minY; y < maxY; y++)
                {
                    Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];
                    int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                    int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;
                    float scalerX = gv.cc.tileBitmapList[tile.Layer2Filename].PixelSize.Width / 100;
                    float scalerY = gv.cc.tileBitmapList[tile.Layer2Filename].PixelSize.Height / 100;
                    int brX = (int)(gv.squareSize * scalerX);
                    int brY = (int)(gv.squareSize * scalerY);

                    try
                    {
                        IbRect src = new IbRect(0, 0, gv.cc.tileBitmapList[tile.Layer2Filename].PixelSize.Width, gv.cc.tileBitmapList[tile.Layer2Filename].PixelSize.Height);
                        IbRect dst = new IbRect(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                        gv.DrawBitmap(gv.cc.tileBitmapList[tile.Layer2Filename], src, dst);
                    }
                    catch { }
                }
            }
            #endregion
            #region Draw Layer 3
            for (int x = minX; x < maxX; x++)
            {
                for (int y = minY; y < maxY; y++)
                {
                    Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];
                    int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                    int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;
                    float scalerX = gv.cc.tileBitmapList[tile.Layer3Filename].PixelSize.Width / 100;
                    float scalerY = gv.cc.tileBitmapList[tile.Layer3Filename].PixelSize.Height / 100;
                    int brX = (int)(gv.squareSize * scalerX);
                    int brY = (int)(gv.squareSize * scalerY);

                    try
                    {
                        IbRect src = new IbRect(0, 0, gv.cc.tileBitmapList[tile.Layer3Filename].PixelSize.Width, gv.cc.tileBitmapList[tile.Layer3Filename].PixelSize.Height);
                        IbRect dst = new IbRect(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                        gv.DrawBitmap(gv.cc.tileBitmapList[tile.Layer3Filename], src, dst);
                    }
                    catch { }
                }
            }
            #endregion
            #region Draw Layer 4
            for (int x = minX; x < maxX; x++)
            {
                for (int y = minY; y < maxY; y++)
                {
                    Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];
                    int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                    int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;
                    float scalerX = gv.cc.tileBitmapList[tile.Layer4Filename].PixelSize.Width / 100;
                    float scalerY = gv.cc.tileBitmapList[tile.Layer4Filename].PixelSize.Height / 100;
                    int brX = (int)(gv.squareSize * scalerX);
                    int brY = (int)(gv.squareSize * scalerY);

                    try
                    {
                        IbRect src = new IbRect(0, 0, gv.cc.tileBitmapList[tile.Layer4Filename].PixelSize.Width, gv.cc.tileBitmapList[tile.Layer4Filename].PixelSize.Height);
                        IbRect dst = new IbRect(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                        gv.DrawBitmap(gv.cc.tileBitmapList[tile.Layer4Filename], src, dst);
                    }
                    catch { }
                }
            }
            #endregion
            #region Draw Layer 5
            for (int x = minX; x < maxX; x++)
            {
                for (int y = minY; y < maxY; y++)
                {
                    Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];
                    int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                    int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;
                    float scalerX = gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Width / 100;
                    float scalerY = gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Height / 100;
                    int brX = (int)(gv.squareSize * scalerX);
                    int brY = (int)(gv.squareSize * scalerY);

                    try
                    {
                        IbRect src = new IbRect(0, 0, gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Width, gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Height);
                        IbRect dst = new IbRect(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                        gv.DrawBitmap(gv.cc.tileBitmapList[tile.Layer5Filename], src, dst);
                    }
                    catch { }
                }
            }
            #endregion

            #region Draw Black Squares
            //draw black squares to make sure and hide any large tiles that have over drawn outside the visible map area
            int mapStartLocationInSquares = 6;
            int mapSizeInSquares = gv.playerOffset + gv.playerOffset + 1;
            int mapRightEndSquare = mapStartLocationInSquares + mapSizeInSquares;
            if (!gv.useLargeLayout) { mapStartLocationInSquares = 4; }
            IbRect srcBlackTile = new IbRect(0, 0, gv.cc.black_tile.PixelSize.Width, gv.cc.black_tile.PixelSize.Height);

            //draw left side squares
            for (int x = mapStartLocationInSquares - 2; x < mapStartLocationInSquares; x++)
            {
                for (int y = 0; y < mapSizeInSquares; y++)
                {                    
                    IbRect dst = new IbRect(x * gv.squareSize + gv.oXshift, y * gv.squareSize, gv.squareSize, gv.squareSize);
                    gv.DrawBitmap(gv.cc.black_tile, srcBlackTile, dst);
                }
            }
            //draw right side squares
            for (int x = mapRightEndSquare; x < mapRightEndSquare + 2; x++)
            {
                for (int y = 0; y < mapSizeInSquares; y++)
                {
                    IbRect dst = new IbRect(x * gv.squareSize + gv.oXshift, y * gv.squareSize, gv.squareSize, gv.squareSize);
                    gv.DrawBitmap(gv.cc.black_tile, srcBlackTile, dst);
                }
            }
            //draw top squares
            for (int x = mapStartLocationInSquares - 2; x < mapRightEndSquare + 2; x++)
            {
                IbRect dst = new IbRect(x * gv.squareSize + gv.oXshift, -1 * gv.squareSize, gv.squareSize, gv.squareSize);
                gv.DrawBitmap(gv.cc.black_tile, srcBlackTile, dst);
            }
            //draw bottom squares
            for (int x = mapStartLocationInSquares - 2; x < mapRightEndSquare + 2; x++)
            {
                for (int y = mapSizeInSquares; y < mapSizeInSquares + 2; y++)
                {
                    IbRect dst = new IbRect(x * gv.squareSize + gv.oXshift, y * gv.squareSize, gv.squareSize, gv.squareSize);
                    gv.DrawBitmap(gv.cc.black_tile, srcBlackTile, dst);
                }
            }
            //draw black tiles over large tiles when party is near edges of map
            drawBlackTilesOverTints();
            #endregion
        }

        public void drawTopFullScreenEffects()
        {
            #region dst tile preparation (min and max)  
            //set up teh min and max dst tiles to iterate through, ie draw on into the map area and that on a tile by tile basis 
            int minX = mod.PlayerLocationX - gv.playerOffset;
            if (minX < 0) { minX = 0; }
            int minY = mod.PlayerLocationY - gv.playerOffset;
            if (minY < 0) { minY = 0; }

            int maxX = mod.PlayerLocationX + gv.playerOffset + 1;
            if (maxX > this.mod.currentArea.MapSizeX) { maxX = this.mod.currentArea.MapSizeX; }
            int maxY = mod.PlayerLocationY + gv.playerOffset + 1;
            if (maxY > this.mod.currentArea.MapSizeY) { maxY = this.mod.currentArea.MapSizeY; }
            #endregion
 //hurgh
            #region Draw full screen layer 1
            //there will be six layers for effects usable by either the top (eg.sky) or bottom (eg sea) full scren draw methods 
            //I would guess that combined about 60.000 pix are ok for performance,so like 6 x 100x100 source bitmaps or fewer, but with higer resolution
            //that's for my laptop

            //check whether the layer1 is activated and set to top level
            if ((gv.mod.currentArea.useFullScreenEffectLayer1) && (gv.mod.currentArea.FullScreenEffectLayer1IsTop))
            {
               
                gv.cc.DisposeOfBitmap(ref fullScreenEffect1);
  
                    //these replace the normal, linear scroll in direction of vector x,y pattern
                    //in the toolset different values for overrides can be set than the defaults they come with
                    //this way an author can make use of the non-linear algorithms with different input parameters to bend their shape
                    //basically it works like the override would call scripts whose paratmeters can be set by the authors
                    //just with the added comfort that teh paarmeters ahve own fields in the toolset and descritive text
                    //also when just letting all override values sit at zero,the override will use its own defaults, working out of the box like e.g. snow

                #region override movement patterns

                    if (gv.mod.currentArea.directionalOverride1 == "randStraight")
                    {
                        //set up the default values and allow individiual override based on toolset values
                        float defaultOverrideSpeedX1 = 0.5f;
                        float defaultOverrideSpeedY1 = 0.5f;
                        int defaultOverrideDelayLimit1 = 15;
                        string defaultOverrideIsNoScrollSource1 = "False";

                        if (gv.mod.currentArea.overrideIsNoScrollSource1 == "")
                        {
                            gv.mod.currentArea.overrideIsNoScrollSource1 = defaultOverrideIsNoScrollSource1;
                        }

                        if (gv.mod.currentArea.overrideSpeedX1 != -100)
                        {
                            defaultOverrideSpeedX1 = gv.mod.currentArea.overrideSpeedX1;
                        }
                        if (gv.mod.currentArea.overrideSpeedY1 != -100)
                        {
                            defaultOverrideSpeedY1 = gv.mod.currentArea.overrideSpeedY1;
                        }
                        if (gv.mod.currentArea.overrideDelayLimit1 != -100)
                        {
                            defaultOverrideDelayLimit1 = gv.mod.currentArea.overrideDelayLimit1;
                        }
                   
                    gv.mod.currentArea.overrideDelayCounter1++;
                    if (gv.mod.currentArea.overrideDelayCounter1 > defaultOverrideDelayLimit1)
                    {

                        gv.mod.currentArea.overrideDelayCounter1 = 0;
                        int rollRandom = gv.sf.RandInt(8);
                        //right
                        if (rollRandom == 1)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = defaultOverrideSpeedX1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = 0.0f;
                        }
                        //left
                        if (rollRandom == 2)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = -defaultOverrideSpeedX1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = 0.0f;
                        }
                        //up
                        if (rollRandom == 3)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = defaultOverrideSpeedY1;
                        }
                        //down
                        if (rollRandom == 4)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = -defaultOverrideSpeedY1;
                        }
                        //up right
                        if (rollRandom == 5)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = defaultOverrideSpeedX1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = defaultOverrideSpeedY1;
                        }
                        //upleft
                        if (rollRandom == 6)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = -defaultOverrideSpeedX1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = defaultOverrideSpeedY1;
                        }
                        //downright
                        if (rollRandom == 7)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = defaultOverrideSpeedX1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = -defaultOverrideSpeedY1;
                        }
                        //downleft
                        if (rollRandom == 8)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = -defaultOverrideSpeedX1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = -defaultOverrideSpeedY1;
                        }
                    }
                    }

                    if (gv.mod.currentArea.directionalOverride1 == "clouds")
                    {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX1 = 0.5f;
                    float defaultOverrideSpeedY1 = 0.5f;
                    int defaultOverrideDelayLimit1 = 750;
                    string defaultOverrideIsNoScrollSource1 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource1 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource1 = defaultOverrideIsNoScrollSource1;
                    }

                    if (gv.mod.currentArea.overrideSpeedX1 != -100)
                    {
                        defaultOverrideSpeedX1 = gv.mod.currentArea.overrideSpeedX1;
                    }
                    if (gv.mod.currentArea.overrideSpeedY1 != -100)
                    {
                        defaultOverrideSpeedY1 = gv.mod.currentArea.overrideSpeedY1;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit1 != -100)
                    {
                        defaultOverrideDelayLimit1 = gv.mod.currentArea.overrideDelayLimit1;
                    }

                    gv.mod.currentArea.overrideDelayCounter1++;
                    if (gv.mod.currentArea.overrideDelayCounter1 > defaultOverrideDelayLimit1)
                    {

                        gv.mod.currentArea.overrideDelayCounter1 = 0;
                            //for x
                            int rollRandom = gv.sf.RandInt(100);
                            int rollRandom2 = gv.sf.RandInt(2);
                            int directional = 1;
                            if (rollRandom2 == 1)
                            {
                                rollRandom = rollRandom * -1;
                                directional = -1;
                            }
                            float decider = rollRandom / 100f;
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = ((0.25f * directional) + (decider * defaultOverrideSpeedX1 * 0.5f)) * (0.5f);

                            //for y
                            rollRandom = gv.sf.RandInt(100);
                            rollRandom2 = gv.sf.RandInt(2);
                            directional = 1;
                            if (rollRandom2 == 1)
                            {
                                rollRandom = rollRandom * -1;
                                directional = -1;
                            }
                            decider = rollRandom / 100f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = ((0.25f * directional) + (decider * defaultOverrideSpeedY1 * 0.5f)) * (0.5f);
                        }
                    }

                if (gv.mod.currentArea.directionalOverride1 == "fog")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX1 = 1.0f;
                    float defaultOverrideSpeedY1 = 1.0f;
                    int defaultOverrideDelayLimit1 = 110;
                    string defaultOverrideIsNoScrollSource1 = "True";

                    if (gv.mod.currentArea.overrideIsNoScrollSource1 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource1 = defaultOverrideIsNoScrollSource1;
                    }

                    if (gv.mod.currentArea.overrideSpeedX1 != -100)
                    {
                        defaultOverrideSpeedX1 = gv.mod.currentArea.overrideSpeedX1;
                    }
                    if (gv.mod.currentArea.overrideSpeedY1 != -100)
                    {
                        defaultOverrideSpeedY1 = gv.mod.currentArea.overrideSpeedY1;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit1 != -100)
                    {
                        defaultOverrideDelayLimit1 = gv.mod.currentArea.overrideDelayLimit1;
                    }

                    gv.mod.currentArea.overrideDelayCounter1++;
                    if (gv.mod.currentArea.overrideDelayCounter1 > defaultOverrideDelayLimit1)
                    {

                        gv.mod.currentArea.overrideDelayCounter1 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(100);
                        int directional = 1;
                        if (rollRandom2 >= 50)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedX1 = ((0.25f * directional) + (decider * defaultOverrideSpeedX1 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedX1 = ((0.075f * directional) + (decider * defaultOverrideSpeedX1 * 0.5f)) * (0.09f);

                        //for y
                        int rollRandom3  = gv.sf.RandInt(100);
                        int rollRandom4 = gv.sf.RandInt(100);
                        directional = 1;
                        if (rollRandom4 >= 50)
                        {
                            rollRandom3 = rollRandom3 * -1;
                            directional = -1;
                        }
                        decider = rollRandom3 / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedY1 = ((0.25f * directional) + (decider * defaultOverrideSpeedY1 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY1 = ((0.075f * directional) + (decider * defaultOverrideSpeedY1 * 0.5f)) * (0.09f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride1 == "snow")
                    {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX1 = 0.45f;
                    float defaultOverrideSpeedY1 = -0.55f;
                    int defaultOverrideDelayLimit1 = 470;
                    string defaultOverrideIsNoScrollSource1 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource1 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource1 = defaultOverrideIsNoScrollSource1;
                    }


                    if (gv.mod.currentArea.overrideSpeedX1 != -100)
                    {
                        defaultOverrideSpeedX1 = gv.mod.currentArea.overrideSpeedX1;
                    }
                    if (gv.mod.currentArea.overrideSpeedY1 != -100)
                    {
                        defaultOverrideSpeedY1 = gv.mod.currentArea.overrideSpeedY1;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit1 != -100)
                    {
                        defaultOverrideDelayLimit1 = gv.mod.currentArea.overrideDelayLimit1;
                    }

                    gv.mod.currentArea.overrideDelayCounter1++;
                    if (gv.mod.currentArea.overrideDelayCounter1 > defaultOverrideDelayLimit1)
                    {

                        gv.mod.currentArea.overrideDelayCounter1 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                            int rollRandom2 = gv.sf.RandInt(2);
                            int directional = 1;
                            if (rollRandom2 == 1)
                            {
                                rollRandom = rollRandom * -1;
                                directional = -1;
                            }
                            float decider = rollRandom / 100f;
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = ((0.15f * directional) + (decider * defaultOverrideSpeedX1 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY1 = defaultOverrideSpeedY1;
                        }
                    }

                if (gv.mod.currentArea.directionalOverride1 == "rain")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX1 = 0.5f;
                    float defaultOverrideSpeedY1 = -2.8f;
                    int defaultOverrideDelayLimit1 = 100;
                    string defaultOverrideIsNoScrollSource1 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource1 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource1 = defaultOverrideIsNoScrollSource1;
                    }

                    if (gv.mod.currentArea.overrideSpeedX1 != -100)
                    {
                        defaultOverrideSpeedX1 = gv.mod.currentArea.overrideSpeedX1;
                    }
                    if (gv.mod.currentArea.overrideSpeedY1 != -100)
                    {
                        defaultOverrideSpeedY1 = gv.mod.currentArea.overrideSpeedY1;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit1 != -100)
                    {
                        defaultOverrideDelayLimit1 = gv.mod.currentArea.overrideDelayLimit1;
                    }

                    gv.mod.currentArea.overrideDelayCounter1++;
                    if (gv.mod.currentArea.overrideDelayCounter1 > defaultOverrideDelayLimit1)
                    {

                        gv.mod.currentArea.overrideDelayCounter1 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            //rollRandom = rollRandom * -1;
                            //directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX1 = ((0.25f * directional) + (decider * defaultOverrideSpeedX1 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY1 = defaultOverrideSpeedY1;
                    }
                }

                if (gv.mod.currentArea.directionalOverride1 == "linear")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX1 = 1f;
                    float defaultOverrideSpeedY1 = 1f;
                    int defaultOverrideDelayLimit1 = 100;
                    string defaultOverrideIsNoScrollSource1 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource1 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource1 = defaultOverrideIsNoScrollSource1;
                    }

                    if (gv.mod.currentArea.overrideSpeedX1 != -100)
                    {
                        defaultOverrideSpeedX1 = gv.mod.currentArea.overrideSpeedX1;
                    }
                    if (gv.mod.currentArea.overrideSpeedY1 != -100)
                    {
                        defaultOverrideSpeedY1 = gv.mod.currentArea.overrideSpeedY1;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit1 != -100)
                    {
                        defaultOverrideDelayLimit1 = gv.mod.currentArea.overrideDelayLimit1;
                    }
                    gv.mod.currentArea.fullScreenAnimationSpeedX1 = defaultOverrideSpeedX1;
                    gv.mod.currentArea.fullScreenAnimationSpeedY1 = defaultOverrideSpeedY1;
                }


                #endregion

                if (gv.mod.currentArea.fullScreenEffectLayerIsActive1 == true)
                {
                    #region limited cycle animation
                    //check whether we got an effect that is supposed to happen only once in a while
                    if (gv.mod.currentArea.numberOfCyclesPerOccurence1 != 0)
                    {

                        //added speed
                        float speedComponentX = gv.mod.currentArea.fullScreenAnimationSpeedX1;
                        if (speedComponentX < 0)
                        {
                            speedComponentX *= -1;
                        }
                        float speedComponentY = gv.mod.currentArea.fullScreenAnimationSpeedY1;
                        if (speedComponentY < 0)
                        {
                            speedComponentY *= -1;
                        }
                        gv.mod.currentArea.fullScreenAnimationSpeed1 = speedComponentX + speedComponentY;

                        //based on subjective trial and error
                        if ((gv.mod.currentArea.fullScreenAnimationFrameCounter1 > (50f / (gv.mod.currentArea.fullScreenAnimationSpeed1 * gv.mod.allAnimationSpeedMultiplier) - 1)))
                        {
                            gv.mod.currentArea.cycleCounter1 += 1;
                            gv.mod.currentArea.fullScreenAnimationFrameCounter1 = 0;
                        }

                        //a little extra delay added by on intuition how long a cycle takes here
                        if (gv.mod.currentArea.cycleCounter1 >= (gv.mod.currentArea.numberOfCyclesPerOccurence1))
                        {
                            //turn the animation off, in common code's doudate method a chance per turn is rolled for turning on again
                            gv.mod.currentArea.fullScreenEffectLayerIsActive1 = false;
                            //counts how often/long the aniamtion is displayed before stop
                            gv.mod.currentArea.cycleCounter1 = 0;
                            //just keeping track how often render calls have run through
                            gv.mod.currentArea.fullScreenAnimationFrameCounter1 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeCounter1 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeFrameCounter1 = 1;
                        }

                        gv.mod.currentArea.fullScreenAnimationFrameCounter1 += 1;
                    }
                    #endregion

                    //if (gv.mod.currentArea.fullScreenEffectLayerIsActive1 == true)
                    //{
                        float fullScreenEffectOpacity = 1f;
                        #region opacity code
                        if (gv.mod.currentArea.useCyclicFade1)
                        {
                            //fade in within first cycle of cyclic animation
                            if ((gv.mod.currentArea.cycleCounter1 == 0) && (gv.mod.currentArea.numberOfCyclesPerOccurence1 != 0))
                            {
                                fullScreenEffectOpacity = 1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed1 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter1);
                            }

                            //fade out within last cycle of cyclic animation
                            if ((gv.mod.currentArea.cycleCounter1 == (gv.mod.currentArea.numberOfCyclesPerOccurence1 - 1)) && (gv.mod.currentArea.numberOfCyclesPerOccurence1 != 0))
                            {
                                fullScreenEffectOpacity = 1f - (1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed1 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter1));
                            }
                        }
                        #endregion

                        //use weather system per area specific later on
                        //utilizing weather type defined by area weather settings
                        //add check for square specific punch hole that prevents drawing weather, e.g. house inside or spaceship interior

                        #region only for shape changing animation
                        if (gv.mod.currentArea.isChanging1)
                        {
                            gv.mod.currentArea.changeCounter1 += (1 * gv.mod.allAnimationSpeedMultiplier);
                            if (gv.mod.currentArea.changeCounter1 > gv.mod.currentArea.changeLimit1)
                            {
                                gv.mod.currentArea.changeCounter1 = 0;
                                gv.mod.currentArea.changeFrameCounter1 += 1;
                                if (gv.mod.currentArea.changeFrameCounter1 > gv.mod.currentArea.changeNumberOfFrames1)
                                {
                                    gv.mod.currentArea.changeFrameCounter1 = 1;
                                }
                            }
                            fullScreenEffect1 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName1 + gv.mod.currentArea.changeFrameCounter1.ToString());
                        }
                        #endregion

                        else
                        {
                            fullScreenEffect1 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName1);
                        }

                        #region handle framecounter
                        //assuming a square shaped source here
                        float sizeOfWholeSource = fullScreenEffect1.PixelSize.Width;

                        //reading the frames moved and added up in the last seconds
                        float pixShiftOnThisFrameX = gv.mod.currentArea.fullScreenAnimationFrameCounterX1;
                        float pixShiftOnThisFrameY = gv.mod.currentArea.fullScreenAnimationFrameCounterY1;

                        //increase by this call's movement
                        pixShiftOnThisFrameX += (gv.mod.currentArea.fullScreenAnimationSpeedX1 * gv.mod.allAnimationSpeedMultiplier);
                        pixShiftOnThisFrameY += (gv.mod.currentArea.fullScreenAnimationSpeedY1 * gv.mod.allAnimationSpeedMultiplier);

                    if (gv.mod.currentArea.overrideIsNoScrollSource1 == "True")
                    {
                        if (pixShiftOnThisFrameX > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameX = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 *= -1;
                        }

                        if (pixShiftOnThisFrameY > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameY = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 *= -1;
                        }

                        if (pixShiftOnThisFrameX < 0)
                        {
                            pixShiftOnThisFrameX = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 *= -1;
                        }

                        if (pixShiftOnThisFrameY < 0)
                        {
                            pixShiftOnThisFrameY = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 *= -1;
                        }
                    }

                    //reset it in case it grwos too large (note: just to avoid an overflow in the far future)
                    //the actual reset happens later below
                    if (pixShiftOnThisFrameX >= ((2000 * gv.playerOffset) * gv.squareSize))
                        {
                            pixShiftOnThisFrameX = pixShiftOnThisFrameX - ((2000 * gv.playerOffset) * gv.squareSize);
                        }

                        if (pixShiftOnThisFrameY >= ((2000 * gv.playerOffset) * gv.squareSize))
                        {
                            pixShiftOnThisFrameY = pixShiftOnThisFrameY - ((2000 * gv.playerOffset) * gv.squareSize);
                        }

                        if (pixShiftOnThisFrameX <= ((-2000 * gv.playerOffset) * gv.squareSize))
                        {
                            pixShiftOnThisFrameX = pixShiftOnThisFrameX + ((2000 * gv.playerOffset) * gv.squareSize);
                        }

                        if (pixShiftOnThisFrameY <= ((-2000 * gv.playerOffset) * gv.squareSize))
                        {
                            pixShiftOnThisFrameY = pixShiftOnThisFrameY + ((2000 * gv.playerOffset) * gv.squareSize);
                        }

                        gv.mod.currentArea.fullScreenAnimationFrameCounterX1 = pixShiftOnThisFrameX;
                        gv.mod.currentArea.fullScreenAnimationFrameCounterY1 = pixShiftOnThisFrameY;
                        #endregion

                        #region iterate through the dst tiles
                        for (int x = minX; x < maxX; x++)
                        {
                            for (int y = minY; y < maxY; y++)
                            {
                                Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];

                                //each tile can block the effects run on the six effect channels, each e.g. simualting shelter from rain
                                if (!tile.blockFullScreenEffectLayer1)
                                {
                                    int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                                    int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;

                                    float scalerX = gv.cc.tileBitmapList[tile.Layer1Filename].PixelSize.Width / 100f;
                                    float scalerY = gv.cc.tileBitmapList[tile.Layer1Filename].PixelSize.Height / 100f;
                                    float brX = gv.squareSize * scalerX;
                                    float brY = gv.squareSize * scalerY;

                                    float numberOfPictureParts = gv.playerOffset * 2 + 1;

                                    #region is effect contained inside borders or always centered on party?
                                    //code section for handling borders of the area
                                    int modX = x;
                                    int modY = y;
                                    int modMinX = minX;
                                    int modMinY = minY;

                                    if (gv.mod.currentArea.containEffectInsideAreaBorders1)
                                    {
                                        //code for for always keeping the effect contained in the area box, break center on player near map border
                                        if ((mod.PlayerLocationX + 4) == this.mod.currentArea.MapSizeX)
                                        {
                                            modX += 1;
                                        }
                                        if ((mod.PlayerLocationX + 3) == this.mod.currentArea.MapSizeX)
                                        {
                                            modX += 2;
                                        }
                                        if ((mod.PlayerLocationX + 2) == this.mod.currentArea.MapSizeX)
                                        {
                                            modX += 3;
                                        }
                                        if ((mod.PlayerLocationX + 1) == this.mod.currentArea.MapSizeX)
                                        {
                                            modX += 4;
                                        }


                                        if ((mod.PlayerLocationY + 4) == this.mod.currentArea.MapSizeY)
                                        {
                                            modY += 1;
                                        }
                                        if ((mod.PlayerLocationY + 3) == this.mod.currentArea.MapSizeY)
                                        {
                                            modY += 2;
                                        }
                                        if ((mod.PlayerLocationY + 2) == this.mod.currentArea.MapSizeY)
                                        {
                                            modY += 3;
                                        }
                                        if ((mod.PlayerLocationY + 1) == this.mod.currentArea.MapSizeY)
                                        {
                                            modY += 4;
                                        }
                                    }

                                    else
                                    {
                                        //code for always centering the effect on player, even near map border (e.g. light source carried by party)
                                        if ((mod.PlayerLocationX - 3) == 0)
                                        {
                                            modMinX = -1;
                                        }
                                        if ((mod.PlayerLocationX - 2) == 0)
                                        {
                                            modMinX = -2;
                                        }
                                        if ((mod.PlayerLocationX - 1) == 0)
                                        {
                                            modMinX = -3;
                                        }
                                        if ((mod.PlayerLocationX) == 0)
                                        {
                                            modMinX = -4;
                                        }


                                        if ((mod.PlayerLocationY - 3) == 0)
                                        {
                                            modMinY = -1;
                                        }
                                        if ((mod.PlayerLocationY - 2) == 0)
                                        {
                                            modMinY = -2;
                                        }
                                        if ((mod.PlayerLocationY - 1) == 0)
                                        {
                                            modMinY = -3;
                                        }
                                        if ((mod.PlayerLocationY) == 0)
                                        {
                                            modMinY = -4;
                                        }
                                    }
                                    #endregion

                                    //get the correct chunk on source
                                    //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                    float floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                    float floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                #region handle border situations on source (bottom and right)     
                                //the following four sections help to set the top left x,y of our square incase we ae close to bottom or right border of source

                                if (gv.mod.currentArea.overrideIsNoScrollSource1 == "True")
                                {
                                    sizeOfWholeSource = 0.5f * sizeOfWholeSource;
                                    //get the correct chunk on source
                                    //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                    floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                    floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                    float smallSourceChunk = sizeOfWholeSource / numberOfPictureParts;
                                    sizeOfWholeSource = 2.0f * sizeOfWholeSource;
                                    /*
                                    //stop at border
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = 0;
                                        
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordY >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordY = sizeOfWholeSource - smallSourceChunk - 1;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = 0;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordX = sizeOfWholeSource - smallSourceChunk - 1;
                                    }
                                    */

                                }

                                else
                                {

                                    //leave source in negative direction (vertical)
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = (floatSourceChunkCoordY * -1f);
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                        floatSourceChunkCoordY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    }

                                    //leave source in positive direction (vertical)
                                    if (floatSourceChunkCoordY >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                    }

                                    //leave source in negative direction (horizontal)
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = (floatSourceChunkCoordX * -1f);
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                        floatSourceChunkCoordX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    }

                                    //leave source in positive direction (horizontal)
                                    if (floatSourceChunkCoordX >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                    }
                                }
                                    #endregion

                                    #region handle the four different draw situations, based on position of chunk on source
                                    //next task is to actaully draw up to four pieces of  square source to one target dst
                                    //let's go through the differdnt situations that can occur

                                    #region Situation 1 (complex, 4 to 1)
                                    //Situation 1 (most complex): touching four source squares, we are in the far low right corner
                                    //there will be two more 2 source square situations, one for x and one for y direction
                                    //also there's of course the standard situation that we just need one coherent source
                                    if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && ((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource1 != "True"))
                                    {

                                        //need to use parts four source chunks from four different source squares and draw them onto the dst square

                                        //first: top left corner
                                        float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                        float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                        float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                        float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                        float srcCoordY2 = floatSourceChunkCoordY;
                                        float srcCoordX2 = floatSourceChunkCoordX;

                                        try
                                        {
                                            IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                            IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                            gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                        }
                                        catch { }

                                        //second: top right corner
                                        float oldWidth = (brX * dstScalerX);
                                        availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                        availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                        dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                        srcCoordY2 = floatSourceChunkCoordY;
                                        srcCoordX2 = 0;

                                        try
                                        {
                                            IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                            IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * dstScalerX)), (brY * dstScalerY));
                                            gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                        }
                                        catch { }

                                        //third: bottom left corner
                                        float oldHeight = (brY * dstScalerY);
                                        availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                        availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                        dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                        srcCoordY2 = 0;
                                        srcCoordX2 = floatSourceChunkCoordX;

                                        try
                                        {
                                            IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                            IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldHeight, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                            gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                        }
                                        catch { }

                                        //fourth: bottom right corner
                                        oldWidth = (brX * dstScalerX);
                                        availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                        availableLengthY = availableLengthY;
                                        dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                        dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                        srcCoordY2 = 0;
                                        srcCoordX2 = 0;

                                        try
                                        {
                                            IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                            IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY + oldHeight, (brX * dstScalerX), (brY * dstScalerY));
                                            gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                        }
                                        catch { }

                                        continue;

                                    }
                                    #endregion

                                    #region Situation 2 (2 to 1, x near border)
                                    //Situation 2: only x is near right border, y is high/small enough
                                    else if (((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource)  && (gv.mod.currentArea.overrideIsNoScrollSource1 != "True"))
                                    {

                                        //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                        //first: left hand side
                                        float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                        float availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                        float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                        float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                        float srcCoordY2 = floatSourceChunkCoordY;
                                        float srcCoordX2 = floatSourceChunkCoordX;

                                        try
                                        {
                                            IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                            IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                            gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                        }
                                        catch { }

                                        //second: right hand side
                                        float oldWidth = (brX * dstScalerX);
                                        availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                        availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                        dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                        srcCoordY2 = floatSourceChunkCoordY;
                                        srcCoordX2 = 0;

                                        try
                                        {
                                            IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                            IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * (dstScalerX))), (brY * (dstScalerY)));
                                            gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                        }
                                        catch { }
                                        continue;

                                    }
                                    #endregion

                                    #region Situation 3 (2 to 1, y near border)
                                    //Situation 3: only y is near bottom border, x is left/small enough WIP
                                    else if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource1 != "True"))
                                    {

                                        //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                        //first: top square
                                        float availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                        float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                        float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                        float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                        float srcCoordY2 = floatSourceChunkCoordY;
                                        float srcCoordX2 = floatSourceChunkCoordX;

                                        try
                                        {
                                            IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                            IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                            gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                        }
                                        catch { }

                                        //second: bottom square
                                        float oldLength = 0;
                                        oldLength = (float)(brY * dstScalerY);
                                        availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                        availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                        dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                        srcCoordY2 = 0;
                                        srcCoordX2 = floatSourceChunkCoordX;

                                        try
                                        {
                                            IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                            IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldLength, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                            gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                        }
                                        catch { }
                                        continue;
                                    }
                                    #endregion

                                    #region Situation 4 (default, neither x or y near border)
                                    //Situation 4: the default situation, x and y are sufficiently distant from bottom and right border
                                    else
                                    {

                                        float srcCoordY2 = floatSourceChunkCoordY;
                                        float srcCoordX2 = floatSourceChunkCoordX;
                                        float sizeOfSourceChunk2 = 0;
                                        if (gv.mod.currentArea.overrideIsNoScrollSource1 != "True")
                                        {
                                            sizeOfSourceChunk2 = (sizeOfWholeSource / numberOfPictureParts);
                                        }
                                        else
                                        {
                                            sizeOfSourceChunk2 = ((sizeOfWholeSource * 0.5f) / numberOfPictureParts);
                                        }

                                    try
                                        {
                                            IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, sizeOfSourceChunk2, sizeOfSourceChunk2);
                                            IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                                            gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                        }
                                        catch { }

                                    }
                                    #endregion

                                }
                            }
                        }
                    }
                    #endregion
                
                }
            #endregion
            #endregion
            #region Draw full screen layer 2
            //there will be six layers for effects usable by either the top (eg.sky) or bottom (eg sea) full scren draw methods 
            //I would guess that combined about 60.000 pix are ok for performance,so like 6 x 100x100 source bitmaps or fewer, but with higer resolution
            //that's for my laptop

            //check whether the layer2 is activated and set to top level
            if ((gv.mod.currentArea.useFullScreenEffectLayer2) && (gv.mod.currentArea.FullScreenEffectLayer2IsTop))
            {

                gv.cc.DisposeOfBitmap(ref fullScreenEffect2);

                //these replace the normal, linear scroll in direction of vector x,y pattern
                //in the toolset different values for overrides can be set than the defaults they come with
                //this way an author can make use of the non-linear algorithms with different input parameters to bend their shape
                //basically it works like the override would call scripts whose paratmeters can be set by the authors
                //just with the added comfort that teh paarmeters ahve own fields in the toolset and descritive text
                //also when just letting all override values sit at zero,the override will use its own defaults, working out of the box like e.g. snow

                #region override movement patterns

                if (gv.mod.currentArea.directionalOverride2 == "randStraight")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX2 = 0.5f;
                    float defaultOverrideSpeedY1 = 0.5f;
                    int defaultOverrideDelayLimit2 = 15;
                    string defaultOverrideIsNoScrollSource2 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource2 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource2 = defaultOverrideIsNoScrollSource2;
                    }

                    if (gv.mod.currentArea.overrideSpeedX2 != -100)
                    {
                        defaultOverrideSpeedX2 = gv.mod.currentArea.overrideSpeedX2;
                    }
                    if (gv.mod.currentArea.overrideSpeedY1 != -100)
                    {
                        defaultOverrideSpeedY1 = gv.mod.currentArea.overrideSpeedY1;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit2 != -100)
                    {
                        defaultOverrideDelayLimit2 = gv.mod.currentArea.overrideDelayLimit2;
                    }

                    gv.mod.currentArea.overrideDelayCounter2++;
                    if (gv.mod.currentArea.overrideDelayCounter2 > defaultOverrideDelayLimit2)
                    {

                        gv.mod.currentArea.overrideDelayCounter2 = 0;
                        int rollRandom = gv.sf.RandInt(8);
                        //right
                        if (rollRandom == 1)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX2 = defaultOverrideSpeedX2;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = 0.0f;
                        }
                        //left
                        if (rollRandom == 2)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX2 = -defaultOverrideSpeedX2;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = 0.0f;
                        }
                        //up
                        if (rollRandom == 3)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX2 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = defaultOverrideSpeedY1;
                        }
                        //down
                        if (rollRandom == 4)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX2 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = -defaultOverrideSpeedY1;
                        }
                        //up right
                        if (rollRandom == 5)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX2 = defaultOverrideSpeedX2;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = defaultOverrideSpeedY1;
                        }
                        //upleft
                        if (rollRandom == 6)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX2 = -defaultOverrideSpeedX2;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = defaultOverrideSpeedY1;
                        }
                        //downright
                        if (rollRandom == 7)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX2 = defaultOverrideSpeedX2;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = -defaultOverrideSpeedY1;
                        }
                        //downleft
                        if (rollRandom == 8)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX2 = -defaultOverrideSpeedX2;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = -defaultOverrideSpeedY1;
                        }
                    }
                }

                if (gv.mod.currentArea.directionalOverride2 == "clouds")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX2 = 0.5f;
                    float defaultOverrideSpeedY1 = 0.5f;
                    int defaultOverrideDelayLimit2 = 750;
                    string defaultOverrideIsNoScrollSource2 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource2 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource2 = defaultOverrideIsNoScrollSource2;
                    }

                    if (gv.mod.currentArea.overrideSpeedX2 != -100)
                    {
                        defaultOverrideSpeedX2 = gv.mod.currentArea.overrideSpeedX2;
                    }
                    if (gv.mod.currentArea.overrideSpeedY1 != -100)
                    {
                        defaultOverrideSpeedY1 = gv.mod.currentArea.overrideSpeedY1;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit2 != -100)
                    {
                        defaultOverrideDelayLimit2 = gv.mod.currentArea.overrideDelayLimit2;
                    }

                    gv.mod.currentArea.overrideDelayCounter2++;
                    if (gv.mod.currentArea.overrideDelayCounter2 > defaultOverrideDelayLimit2)
                    {

                        gv.mod.currentArea.overrideDelayCounter2 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX2 = ((0.25f * directional) + (decider * defaultOverrideSpeedX2 * 0.5f)) * (0.5f);

                        //for y
                        rollRandom = gv.sf.RandInt(100);
                        rollRandom2 = gv.sf.RandInt(2);
                        directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedY1 = ((0.25f * directional) + (decider * defaultOverrideSpeedY1 * 0.5f)) * (0.5f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride2 == "fog")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX2 = 1.0f;
                    float defaultOverrideSpeedY1 = 1.0f;
                    int defaultOverrideDelayLimit2 = 110;
                    string defaultOverrideIsNoScrollSource2 = "True";

                    if (gv.mod.currentArea.overrideIsNoScrollSource2 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource2 = defaultOverrideIsNoScrollSource2;
                    }

                    if (gv.mod.currentArea.overrideSpeedX2 != -100)
                    {
                        defaultOverrideSpeedX2 = gv.mod.currentArea.overrideSpeedX2;
                    }
                    if (gv.mod.currentArea.overrideSpeedY1 != -100)
                    {
                        defaultOverrideSpeedY1 = gv.mod.currentArea.overrideSpeedY1;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit2 != -100)
                    {
                        defaultOverrideDelayLimit2 = gv.mod.currentArea.overrideDelayLimit2;
                    }

                    gv.mod.currentArea.overrideDelayCounter2++;
                    if (gv.mod.currentArea.overrideDelayCounter2 > defaultOverrideDelayLimit2)
                    {

                        gv.mod.currentArea.overrideDelayCounter2 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(100);
                        int directional = 1;
                        if (rollRandom2 >= 50)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedX2 = ((0.25f * directional) + (decider * defaultOverrideSpeedX2 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedX2 = ((0.075f * directional) + (decider * defaultOverrideSpeedX2 * 0.5f)) * (0.09f);

                        //for y
                        int rollRandom3 = gv.sf.RandInt(100);
                        int rollRandom4 = gv.sf.RandInt(100);
                        directional = 1;
                        if (rollRandom4 >= 50)
                        {
                            rollRandom3 = rollRandom3 * -1;
                            directional = -1;
                        }
                        decider = rollRandom3 / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedY1 = ((0.25f * directional) + (decider * defaultOverrideSpeedY1 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY1 = ((0.075f * directional) + (decider * defaultOverrideSpeedY1 * 0.5f)) * (0.09f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride2 == "snow")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX2 = 0.45f;
                    float defaultOverrideSpeedY1 = -0.55f;
                    int defaultOverrideDelayLimit2 = 470;
                    string defaultOverrideIsNoScrollSource2 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource2 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource2 = defaultOverrideIsNoScrollSource2;
                    }


                    if (gv.mod.currentArea.overrideSpeedX2 != -100)
                    {
                        defaultOverrideSpeedX2 = gv.mod.currentArea.overrideSpeedX2;
                    }
                    if (gv.mod.currentArea.overrideSpeedY1 != -100)
                    {
                        defaultOverrideSpeedY1 = gv.mod.currentArea.overrideSpeedY1;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit2 != -100)
                    {
                        defaultOverrideDelayLimit2 = gv.mod.currentArea.overrideDelayLimit2;
                    }

                    gv.mod.currentArea.overrideDelayCounter2++;
                    if (gv.mod.currentArea.overrideDelayCounter2 > defaultOverrideDelayLimit2)
                    {

                        gv.mod.currentArea.overrideDelayCounter2 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX2 = ((0.15f * directional) + (decider * defaultOverrideSpeedX2 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY1 = defaultOverrideSpeedY1;
                    }
                }

                if (gv.mod.currentArea.directionalOverride2 == "rain")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX2 = 0.5f;
                    float defaultOverrideSpeedY1 = -2.8f;
                    int defaultOverrideDelayLimit2 = 100;
                    string defaultOverrideIsNoScrollSource2 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource2 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource2 = defaultOverrideIsNoScrollSource2;
                    }

                    if (gv.mod.currentArea.overrideSpeedX2 != -100)
                    {
                        defaultOverrideSpeedX2 = gv.mod.currentArea.overrideSpeedX2;
                    }
                    if (gv.mod.currentArea.overrideSpeedY1 != -100)
                    {
                        defaultOverrideSpeedY1 = gv.mod.currentArea.overrideSpeedY1;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit2 != -100)
                    {
                        defaultOverrideDelayLimit2 = gv.mod.currentArea.overrideDelayLimit2;
                    }

                    gv.mod.currentArea.overrideDelayCounter2++;
                    if (gv.mod.currentArea.overrideDelayCounter2 > defaultOverrideDelayLimit2)
                    {

                        gv.mod.currentArea.overrideDelayCounter2 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            //rollRandom = rollRandom * -1;
                            //directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX2 = ((0.25f * directional) + (decider * defaultOverrideSpeedX2 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY1 = defaultOverrideSpeedY1;
                    }
                }

                if (gv.mod.currentArea.directionalOverride2 == "linear")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX2 = 1f;
                    float defaultOverrideSpeedY1 = 1f;
                    int defaultOverrideDelayLimit2 = 100;
                    string defaultOverrideIsNoScrollSource2 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource2 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource2 = defaultOverrideIsNoScrollSource2;
                    }

                    if (gv.mod.currentArea.overrideSpeedX2 != -100)
                    {
                        defaultOverrideSpeedX2 = gv.mod.currentArea.overrideSpeedX2;
                    }
                    if (gv.mod.currentArea.overrideSpeedY1 != -100)
                    {
                        defaultOverrideSpeedY1 = gv.mod.currentArea.overrideSpeedY1;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit2 != -100)
                    {
                        defaultOverrideDelayLimit2 = gv.mod.currentArea.overrideDelayLimit2;
                    }
                    gv.mod.currentArea.fullScreenAnimationSpeedX2 = defaultOverrideSpeedX2;
                    gv.mod.currentArea.fullScreenAnimationSpeedY1 = defaultOverrideSpeedY1;
                }


                #endregion

                if (gv.mod.currentArea.fullScreenEffectLayerIsActive2 == true)
                {
                    #region limited cycle animation
                    //check whether we got an effect that is supposed to happen only once in a while
                    if (gv.mod.currentArea.numberOfCyclesPerOccurence2 != 0)
                    {

                        //added speed
                        float speedComponentX = gv.mod.currentArea.fullScreenAnimationSpeedX2;
                        if (speedComponentX < 0)
                        {
                            speedComponentX *= -1;
                        }
                        float speedComponentY = gv.mod.currentArea.fullScreenAnimationSpeedY2;
                        if (speedComponentY < 0)
                        {
                            speedComponentY *= -1;
                        }
                        gv.mod.currentArea.fullScreenAnimationSpeed2 = speedComponentX + speedComponentY;

                        //based on subjective trial and error
                        if ((gv.mod.currentArea.fullScreenAnimationFrameCounter2 > (50f / (gv.mod.currentArea.fullScreenAnimationSpeed2 * gv.mod.allAnimationSpeedMultiplier) - 1)))
                        {
                            gv.mod.currentArea.cycleCounter2 += 1;
                            gv.mod.currentArea.fullScreenAnimationFrameCounter2 = 0;
                        }

                        //a little extra delay added by on intuition how long a cycle takes here
                        if (gv.mod.currentArea.cycleCounter2 >= (gv.mod.currentArea.numberOfCyclesPerOccurence2))
                        {
                            //turn the animation off, in common code's doudate method a chance per turn is rolled for turning on again
                            gv.mod.currentArea.fullScreenEffectLayerIsActive2 = false;
                            //counts how often/long the aniamtion is displayed before stop
                            gv.mod.currentArea.cycleCounter2 = 0;
                            //just keeping track how often render calls have run through
                            gv.mod.currentArea.fullScreenAnimationFrameCounter2 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeCounter2 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeFrameCounter2 = 1;
                        }

                        gv.mod.currentArea.fullScreenAnimationFrameCounter2 += 1;
                    }
                    #endregion

                    //if (gv.mod.currentArea.fullScreenEffectLayerIsActive2 == true)
                    //{
                    float fullScreenEffectOpacity = 1f;
                    #region opacity code
                    if (gv.mod.currentArea.useCyclicFade2)
                    {
                        //fade in within first cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter2 == 0) && (gv.mod.currentArea.numberOfCyclesPerOccurence2 != 0))
                        {
                            fullScreenEffectOpacity = 1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed2 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter2);
                        }

                        //fade out within last cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter2 == (gv.mod.currentArea.numberOfCyclesPerOccurence2 - 1)) && (gv.mod.currentArea.numberOfCyclesPerOccurence2 != 0))
                        {
                            fullScreenEffectOpacity = 1f - (1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed2 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter2));
                        }
                    }
                    #endregion

                    //use weather system per area specific later on
                    //utilizing weather type defined by area weather settings
                    //add check for square specific punch hole that prevents drawing weather, e.g. house inside or spaceship interior

                    #region only for shape changing animation
                    if (gv.mod.currentArea.isChanging2)
                    {
                        gv.mod.currentArea.changeCounter2 += (1 * gv.mod.allAnimationSpeedMultiplier);
                        if (gv.mod.currentArea.changeCounter2 > gv.mod.currentArea.changeLimit2)
                        {
                            gv.mod.currentArea.changeCounter2 = 0;
                            gv.mod.currentArea.changeFrameCounter2 += 1;
                            if (gv.mod.currentArea.changeFrameCounter2 > gv.mod.currentArea.changeNumberOfFrames2)
                            {
                                gv.mod.currentArea.changeFrameCounter2 = 1;
                            }
                        }
                        fullScreenEffect2 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName2 + gv.mod.currentArea.changeFrameCounter2.ToString());
                    }
                    #endregion

                    else
                    {
                        fullScreenEffect2 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName2);
                    }

                    #region handle framecounter
                    //assuming a square shaped source here
                    float sizeOfWholeSource = fullScreenEffect2.PixelSize.Width;

                    //reading the frames moved and added up in the last seconds
                    float pixShiftOnThisFrameX = gv.mod.currentArea.fullScreenAnimationFrameCounterX2;
                    float pixShiftOnThisFrameY = gv.mod.currentArea.fullScreenAnimationFrameCounterY1;

                    //increase by this call's movement
                    pixShiftOnThisFrameX += (gv.mod.currentArea.fullScreenAnimationSpeedX2 * gv.mod.allAnimationSpeedMultiplier);
                    pixShiftOnThisFrameY += (gv.mod.currentArea.fullScreenAnimationSpeedY1 * gv.mod.allAnimationSpeedMultiplier);

                    if (gv.mod.currentArea.overrideIsNoScrollSource2 == "True")
                    {
                        if (pixShiftOnThisFrameX > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameX = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedX2 *= -1;
                        }

                        if (pixShiftOnThisFrameY > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameY = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 *= -1;
                        }

                        if (pixShiftOnThisFrameX < 0)
                        {
                            pixShiftOnThisFrameX = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedX2 *= -1;
                        }

                        if (pixShiftOnThisFrameY < 0)
                        {
                            pixShiftOnThisFrameY = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 *= -1;
                        }
                    }

                    //reset it in case it grwos too large (note: just to avoid an overflow in the far future)
                    //the actual reset happens later below
                    if (pixShiftOnThisFrameX >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameX <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    gv.mod.currentArea.fullScreenAnimationFrameCounterX2 = pixShiftOnThisFrameX;
                    gv.mod.currentArea.fullScreenAnimationFrameCounterY1 = pixShiftOnThisFrameY;
                    #endregion

                    #region iterate through the dst tiles
                    for (int x = minX; x < maxX; x++)
                    {
                        for (int y = minY; y < maxY; y++)
                        {
                            Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];

                            //each tile can block the effects run on the six effect channels, each e.g. simualting shelter from rain
                            if (!tile.blockFullScreenEffectLayer2)
                            {
                                int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                                int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;

                                float scalerX = gv.cc.tileBitmapList[tile.Layer2Filename].PixelSize.Width / 100f;
                                float scalerY = gv.cc.tileBitmapList[tile.Layer2Filename].PixelSize.Height / 100f;
                                float brX = gv.squareSize * scalerX;
                                float brY = gv.squareSize * scalerY;

                                float numberOfPictureParts = gv.playerOffset * 2 + 1;

                                #region is effect contained inside borders or always centered on party?
                                //code section for handling borders of the area
                                int modX = x;
                                int modY = y;
                                int modMinX = minX;
                                int modMinY = minY;

                                if (gv.mod.currentArea.containEffectInsideAreaBorders2)
                                {
                                    //code for for always keeping the effect contained in the area box, break center on player near map border
                                    if ((mod.PlayerLocationX + 4) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 1;
                                    }
                                    if ((mod.PlayerLocationX + 3) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 2;
                                    }
                                    if ((mod.PlayerLocationX + 2) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 3;
                                    }
                                    if ((mod.PlayerLocationX + 1) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 4;
                                    }


                                    if ((mod.PlayerLocationY + 4) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 1;
                                    }
                                    if ((mod.PlayerLocationY + 3) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 2;
                                    }
                                    if ((mod.PlayerLocationY + 2) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 3;
                                    }
                                    if ((mod.PlayerLocationY + 1) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 4;
                                    }
                                }

                                else
                                {
                                    //code for always centering the effect on player, even near map border (e.g. light source carried by party)
                                    if ((mod.PlayerLocationX - 3) == 0)
                                    {
                                        modMinX = -1;
                                    }
                                    if ((mod.PlayerLocationX - 2) == 0)
                                    {
                                        modMinX = -2;
                                    }
                                    if ((mod.PlayerLocationX - 1) == 0)
                                    {
                                        modMinX = -3;
                                    }
                                    if ((mod.PlayerLocationX) == 0)
                                    {
                                        modMinX = -4;
                                    }


                                    if ((mod.PlayerLocationY - 3) == 0)
                                    {
                                        modMinY = -1;
                                    }
                                    if ((mod.PlayerLocationY - 2) == 0)
                                    {
                                        modMinY = -2;
                                    }
                                    if ((mod.PlayerLocationY - 1) == 0)
                                    {
                                        modMinY = -3;
                                    }
                                    if ((mod.PlayerLocationY) == 0)
                                    {
                                        modMinY = -4;
                                    }
                                }
                                #endregion

                                //get the correct chunk on source
                                //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                float floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                float floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                #region handle border situations on source (bottom and right)     
                                //the following four sections help to set the top left x,y of our square incase we ae close to bottom or right border of source

                                if (gv.mod.currentArea.overrideIsNoScrollSource2 == "True")
                                {
                                    sizeOfWholeSource = 0.5f * sizeOfWholeSource;
                                    //get the correct chunk on source
                                    //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                    floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                    floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                    float smallSourceChunk = sizeOfWholeSource / numberOfPictureParts;
                                    sizeOfWholeSource = 2.0f * sizeOfWholeSource;
                                    /*
                                    //stop at border
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = 0;
                                        
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordY >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordY = sizeOfWholeSource - smallSourceChunk - 1;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = 0;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordX = sizeOfWholeSource - smallSourceChunk - 1;
                                    }
                                    */

                                }

                                else
                                {

                                    //leave source in negative direction (vertical)
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = (floatSourceChunkCoordY * -1f);
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                        floatSourceChunkCoordY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    }

                                    //leave source in positive direction (vertical)
                                    if (floatSourceChunkCoordY >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                    }

                                    //leave source in negative direction (horizontal)
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = (floatSourceChunkCoordX * -1f);
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                        floatSourceChunkCoordX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    }

                                    //leave source in positive direction (horizontal)
                                    if (floatSourceChunkCoordX >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                    }
                                }
                                #endregion

                                #region handle the four different draw situations, based on position of chunk on source
                                //next task is to actaully draw up to four pieces of  square source to one target dst
                                //let's go through the differdnt situations that can occur

                                #region Situation 1 (complex, 4 to 1)
                                //Situation 1 (most complex): touching four source squares, we are in the far low right corner
                                //there will be two more 2 source square situations, one for x and one for y direction
                                //also there's of course the standard situation that we just need one coherent source
                                if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && ((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource2 != "True"))
                                {

                                    //need to use parts four source chunks from four different source squares and draw them onto the dst square

                                    //first: top left corner
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect2, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: top right corner
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * dstScalerX)), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect2, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //third: bottom left corner
                                    float oldHeight = (brY * dstScalerY);
                                    availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldHeight, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect2, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //fourth: bottom right corner
                                    oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY + oldHeight, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect2, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    continue;

                                }
                                #endregion

                                #region Situation 2 (2 to 1, x near border)
                                //Situation 2: only x is near right border, y is high/small enough
                                else if (((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource2 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: left hand side
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect2, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: right hand side
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * (dstScalerX))), (brY * (dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect2, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;

                                }
                                #endregion

                                #region Situation 3 (2 to 1, y near border)
                                //Situation 3: only y is near bottom border, x is left/small enough WIP
                                else if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource2 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: top square
                                    float availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect2, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: bottom square
                                    float oldLength = 0;
                                    oldLength = (float)(brY * dstScalerY);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldLength, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect2, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;
                                }
                                #endregion

                                #region Situation 4 (default, neither x or y near border)
                                //Situation 4: the default situation, x and y are sufficiently distant from bottom and right border
                                else
                                {

                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;
                                    float sizeOfSourceChunk2 = 0;
                                    if (gv.mod.currentArea.overrideIsNoScrollSource2 != "True")
                                    {
                                        sizeOfSourceChunk2 = (sizeOfWholeSource / numberOfPictureParts);
                                    }
                                    else
                                    {
                                        sizeOfSourceChunk2 = ((sizeOfWholeSource * 0.5f) / numberOfPictureParts);
                                    }

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, sizeOfSourceChunk2, sizeOfSourceChunk2);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                                        gv.DrawBitmap(fullScreenEffect2, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                }
                                #endregion

                            }
                        }
                    }
                }
                #endregion

            }
            #endregion
            #endregion
            #region Draw full screen layer 3
            //there will be six layers for effects usable by either the top (eg.sky) or bottom (eg sea) full scren draw methods 
            //I would guess that combined about 60.000 pix are ok for performance,so like 6 x 100x100 source bitmaps or fewer, but with higer resolution
            //that's for my laptop

            //check whether the layer3 is activated and set to top level
            if ((gv.mod.currentArea.useFullScreenEffectLayer3) && (gv.mod.currentArea.FullScreenEffectLayer3IsTop))
            {

                gv.cc.DisposeOfBitmap(ref fullScreenEffect3);

                //these replace the normal, linear scroll in direction of vector x,y pattern
                //in the toolset different values for overrides can be set than the defaults they come with
                //this way an author can make use of the non-linear algorithms with different input parameters to bend their shape
                //basically it works like the override would call scripts whose paratmeters can be set by the authors
                //just with the added comfort that teh paarmeters ahve own fields in the toolset and descritive text
                //also when just letting all override values sit at zero,the override will use its own defaults, working out of the box like e.g. snow

                #region override movement patterns

                if (gv.mod.currentArea.directionalOverride3 == "randStraight")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX3 = 0.5f;
                    float defaultOverrideSpeedY3 = 0.5f;
                    int defaultOverrideDelayLimit3 = 15;
                    string defaultOverrideIsNoScrollSource3 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource3 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource3 = defaultOverrideIsNoScrollSource3;
                    }

                    if (gv.mod.currentArea.overrideSpeedX3 != -100)
                    {
                        defaultOverrideSpeedX3 = gv.mod.currentArea.overrideSpeedX3;
                    }
                    if (gv.mod.currentArea.overrideSpeedY3 != -100)
                    {
                        defaultOverrideSpeedY3 = gv.mod.currentArea.overrideSpeedY3;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit3 != -100)
                    {
                        defaultOverrideDelayLimit3 = gv.mod.currentArea.overrideDelayLimit3;
                    }

                    gv.mod.currentArea.overrideDelayCounter3++;
                    if (gv.mod.currentArea.overrideDelayCounter3 > defaultOverrideDelayLimit3)
                    {

                        gv.mod.currentArea.overrideDelayCounter3 = 0;
                        int rollRandom = gv.sf.RandInt(8);
                        //right
                        if (rollRandom == 1)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX3 = defaultOverrideSpeedX3;
                            gv.mod.currentArea.fullScreenAnimationSpeedY3 = 0.0f;
                        }
                        //left
                        if (rollRandom == 2)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX3 = -defaultOverrideSpeedX3;
                            gv.mod.currentArea.fullScreenAnimationSpeedY3 = 0.0f;
                        }
                        //up
                        if (rollRandom == 3)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX3 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY3 = defaultOverrideSpeedY3;
                        }
                        //down
                        if (rollRandom == 4)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX3 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY3 = -defaultOverrideSpeedY3;
                        }
                        //up right
                        if (rollRandom == 5)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX3 = defaultOverrideSpeedX3;
                            gv.mod.currentArea.fullScreenAnimationSpeedY3 = defaultOverrideSpeedY3;
                        }
                        //upleft
                        if (rollRandom == 6)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX3 = -defaultOverrideSpeedX3;
                            gv.mod.currentArea.fullScreenAnimationSpeedY3 = defaultOverrideSpeedY3;
                        }
                        //downright
                        if (rollRandom == 7)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX3 = defaultOverrideSpeedX3;
                            gv.mod.currentArea.fullScreenAnimationSpeedY3 = -defaultOverrideSpeedY3;
                        }
                        //downleft
                        if (rollRandom == 8)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX3 = -defaultOverrideSpeedX3;
                            gv.mod.currentArea.fullScreenAnimationSpeedY3 = -defaultOverrideSpeedY3;
                        }
                    }
                }

                if (gv.mod.currentArea.directionalOverride3 == "clouds")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX3 = 0.5f;
                    float defaultOverrideSpeedY3 = 0.5f;
                    int defaultOverrideDelayLimit3 = 750;
                    string defaultOverrideIsNoScrollSource3 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource3 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource3 = defaultOverrideIsNoScrollSource3;
                    }

                    if (gv.mod.currentArea.overrideSpeedX3 != -100)
                    {
                        defaultOverrideSpeedX3 = gv.mod.currentArea.overrideSpeedX3;
                    }
                    if (gv.mod.currentArea.overrideSpeedY3 != -100)
                    {
                        defaultOverrideSpeedY3 = gv.mod.currentArea.overrideSpeedY3;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit3 != -100)
                    {
                        defaultOverrideDelayLimit3 = gv.mod.currentArea.overrideDelayLimit3;
                    }

                    gv.mod.currentArea.overrideDelayCounter3++;
                    if (gv.mod.currentArea.overrideDelayCounter3 > defaultOverrideDelayLimit3)
                    {

                        gv.mod.currentArea.overrideDelayCounter3 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX3 = ((0.25f * directional) + (decider * defaultOverrideSpeedX3 * 0.5f)) * (0.5f);

                        //for y
                        rollRandom = gv.sf.RandInt(100);
                        rollRandom2 = gv.sf.RandInt(2);
                        directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedY3 = ((0.25f * directional) + (decider * defaultOverrideSpeedY3 * 0.5f)) * (0.5f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride3 == "fog")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX3 = 1.0f;
                    float defaultOverrideSpeedY3 = 1.0f;
                    int defaultOverrideDelayLimit3 = 110;
                    string defaultOverrideIsNoScrollSource3 = "True";

                    if (gv.mod.currentArea.overrideIsNoScrollSource3 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource3 = defaultOverrideIsNoScrollSource3;
                    }

                    if (gv.mod.currentArea.overrideSpeedX3 != -100)
                    {
                        defaultOverrideSpeedX3 = gv.mod.currentArea.overrideSpeedX3;
                    }
                    if (gv.mod.currentArea.overrideSpeedY3 != -100)
                    {
                        defaultOverrideSpeedY3 = gv.mod.currentArea.overrideSpeedY3;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit3 != -100)
                    {
                        defaultOverrideDelayLimit3 = gv.mod.currentArea.overrideDelayLimit3;
                    }

                    gv.mod.currentArea.overrideDelayCounter3++;
                    if (gv.mod.currentArea.overrideDelayCounter3 > defaultOverrideDelayLimit3)
                    {

                        gv.mod.currentArea.overrideDelayCounter3 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(100);
                        int directional = 1;
                        if (rollRandom2 >= 50)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedX3 = ((0.25f * directional) + (decider * defaultOverrideSpeedX3 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedX3 = ((0.075f * directional) + (decider * defaultOverrideSpeedX3 * 0.5f)) * (0.09f);

                        //for y
                        int rollRandom3 = gv.sf.RandInt(100);
                        int rollRandom4 = gv.sf.RandInt(100);
                        directional = 1;
                        if (rollRandom4 >= 50)
                        {
                            rollRandom3 = rollRandom3 * -1;
                            directional = -1;
                        }
                        decider = rollRandom3 / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedY3 = ((0.25f * directional) + (decider * defaultOverrideSpeedY3 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY3 = ((0.075f * directional) + (decider * defaultOverrideSpeedY3 * 0.5f)) * (0.09f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride3 == "snow")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX3 = 0.45f;
                    float defaultOverrideSpeedY3 = -0.55f;
                    int defaultOverrideDelayLimit3 = 470;
                    string defaultOverrideIsNoScrollSource3 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource3 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource3 = defaultOverrideIsNoScrollSource3;
                    }


                    if (gv.mod.currentArea.overrideSpeedX3 != -100)
                    {
                        defaultOverrideSpeedX3 = gv.mod.currentArea.overrideSpeedX3;
                    }
                    if (gv.mod.currentArea.overrideSpeedY3 != -100)
                    {
                        defaultOverrideSpeedY3 = gv.mod.currentArea.overrideSpeedY3;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit3 != -100)
                    {
                        defaultOverrideDelayLimit3 = gv.mod.currentArea.overrideDelayLimit3;
                    }

                    gv.mod.currentArea.overrideDelayCounter3++;
                    if (gv.mod.currentArea.overrideDelayCounter3 > defaultOverrideDelayLimit3)
                    {

                        gv.mod.currentArea.overrideDelayCounter3 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX3 = ((0.15f * directional) + (decider * defaultOverrideSpeedX3 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY3 = defaultOverrideSpeedY3;
                    }
                }

                if (gv.mod.currentArea.directionalOverride3 == "rain")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX3 = 0.5f;
                    float defaultOverrideSpeedY3 = -2.8f;
                    int defaultOverrideDelayLimit3 = 100;
                    string defaultOverrideIsNoScrollSource3 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource3 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource3 = defaultOverrideIsNoScrollSource3;
                    }

                    if (gv.mod.currentArea.overrideSpeedX3 != -100)
                    {
                        defaultOverrideSpeedX3 = gv.mod.currentArea.overrideSpeedX3;
                    }
                    if (gv.mod.currentArea.overrideSpeedY3 != -100)
                    {
                        defaultOverrideSpeedY3 = gv.mod.currentArea.overrideSpeedY3;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit3 != -100)
                    {
                        defaultOverrideDelayLimit3 = gv.mod.currentArea.overrideDelayLimit3;
                    }

                    gv.mod.currentArea.overrideDelayCounter3++;
                    if (gv.mod.currentArea.overrideDelayCounter3 > defaultOverrideDelayLimit3)
                    {

                        gv.mod.currentArea.overrideDelayCounter3 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            //rollRandom = rollRandom * -1;
                            //directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX3 = ((0.25f * directional) + (decider * defaultOverrideSpeedX3 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY3 = defaultOverrideSpeedY3;
                    }
                }

                if (gv.mod.currentArea.directionalOverride3 == "linear")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX3 = 1f;
                    float defaultOverrideSpeedY3 = 1f;
                    int defaultOverrideDelayLimit3 = 100;
                    string defaultOverrideIsNoScrollSource3 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource3 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource3 = defaultOverrideIsNoScrollSource3;
                    }

                    if (gv.mod.currentArea.overrideSpeedX3 != -100)
                    {
                        defaultOverrideSpeedX3 = gv.mod.currentArea.overrideSpeedX3;
                    }
                    if (gv.mod.currentArea.overrideSpeedY3 != -100)
                    {
                        defaultOverrideSpeedY3 = gv.mod.currentArea.overrideSpeedY3;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit3 != -100)
                    {
                        defaultOverrideDelayLimit3 = gv.mod.currentArea.overrideDelayLimit3;
                    }
                    gv.mod.currentArea.fullScreenAnimationSpeedX3 = defaultOverrideSpeedX3;
                    gv.mod.currentArea.fullScreenAnimationSpeedY3 = defaultOverrideSpeedY3;
                }


                #endregion

                if (gv.mod.currentArea.fullScreenEffectLayerIsActive3 == true)
                {
                    #region limited cycle animation
                    //check whether we got an effect that is supposed to happen only once in a while
                    if (gv.mod.currentArea.numberOfCyclesPerOccurence3 != 0)
                    {

                        //added speed
                        float speedComponentX = gv.mod.currentArea.fullScreenAnimationSpeedX3;
                        if (speedComponentX < 0)
                        {
                            speedComponentX *= -1;
                        }
                        float speedComponentY = gv.mod.currentArea.fullScreenAnimationSpeedY3;
                        if (speedComponentY < 0)
                        {
                            speedComponentY *= -1;
                        }
                        gv.mod.currentArea.fullScreenAnimationSpeed3 = speedComponentX + speedComponentY;

                        //based on subjective trial and error
                        if ((gv.mod.currentArea.fullScreenAnimationFrameCounter3 > (50f / (gv.mod.currentArea.fullScreenAnimationSpeed3 * gv.mod.allAnimationSpeedMultiplier) - 1)))
                        {
                            gv.mod.currentArea.cycleCounter3 += 1;
                            gv.mod.currentArea.fullScreenAnimationFrameCounter3 = 0;
                        }

                        //a little extra delay added by on intuition how long a cycle takes here
                        if (gv.mod.currentArea.cycleCounter3 >= (gv.mod.currentArea.numberOfCyclesPerOccurence3))
                        {
                            //turn the animation off, in common code's doudate method a chance per turn is rolled for turning on again
                            gv.mod.currentArea.fullScreenEffectLayerIsActive3 = false;
                            //counts how often/long the aniamtion is displayed before stop
                            gv.mod.currentArea.cycleCounter3 = 0;
                            //just keeping track how often render calls have run through
                            gv.mod.currentArea.fullScreenAnimationFrameCounter3 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeCounter3 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeFrameCounter3 = 1;
                        }

                        gv.mod.currentArea.fullScreenAnimationFrameCounter3 += 1;
                    }
                    #endregion

                    //if (gv.mod.currentArea.fullScreenEffectLayerIsActive3 == true)
                    //{
                    float fullScreenEffectOpacity = 1f;
                    #region opacity code
                    if (gv.mod.currentArea.useCyclicFade3)
                    {
                        //fade in within first cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter3 == 0) && (gv.mod.currentArea.numberOfCyclesPerOccurence3 != 0))
                        {
                            fullScreenEffectOpacity = 1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed3 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter3);
                        }

                        //fade out within last cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter3 == (gv.mod.currentArea.numberOfCyclesPerOccurence3 - 1)) && (gv.mod.currentArea.numberOfCyclesPerOccurence3 != 0))
                        {
                            fullScreenEffectOpacity = 1f - (1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed3 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter3));
                        }
                    }
                    #endregion

                    //use weather system per area specific later on
                    //utilizing weather type defined by area weather settings
                    //add check for square specific punch hole that prevents drawing weather, e.g. house inside or spaceship interior

                    #region only for shape changing animation
                    if (gv.mod.currentArea.isChanging3)
                    {
                        gv.mod.currentArea.changeCounter3 += (1 * gv.mod.allAnimationSpeedMultiplier);
                        if (gv.mod.currentArea.changeCounter3 > gv.mod.currentArea.changeLimit3)
                        {
                            gv.mod.currentArea.changeCounter3 = 0;
                            gv.mod.currentArea.changeFrameCounter3 += 1;
                            if (gv.mod.currentArea.changeFrameCounter3 > gv.mod.currentArea.changeNumberOfFrames3)
                            {
                                gv.mod.currentArea.changeFrameCounter3 = 1;
                            }
                        }
                        fullScreenEffect3 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName3 + gv.mod.currentArea.changeFrameCounter3.ToString());
                    }
                    #endregion

                    else
                    {
                        fullScreenEffect3 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName3);
                    }

                    #region handle framecounter
                    //assuming a square shaped source here
                    float sizeOfWholeSource = fullScreenEffect3.PixelSize.Width;

                    //reading the frames moved and added up in the last seconds
                    float pixShiftOnThisFrameX = gv.mod.currentArea.fullScreenAnimationFrameCounterX3;
                    float pixShiftOnThisFrameY = gv.mod.currentArea.fullScreenAnimationFrameCounterY3;

                    //increase by this call's movement
                    pixShiftOnThisFrameX += (gv.mod.currentArea.fullScreenAnimationSpeedX3 * gv.mod.allAnimationSpeedMultiplier);
                    pixShiftOnThisFrameY += (gv.mod.currentArea.fullScreenAnimationSpeedY3 * gv.mod.allAnimationSpeedMultiplier);

                    if (gv.mod.currentArea.overrideIsNoScrollSource3 == "True")
                    {
                        if (pixShiftOnThisFrameX > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameX = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedX3 *= -1;
                        }

                        if (pixShiftOnThisFrameY > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameY = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY3 *= -1;
                        }

                        if (pixShiftOnThisFrameX < 0)
                        {
                            pixShiftOnThisFrameX = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedX3 *= -1;
                        }

                        if (pixShiftOnThisFrameY < 0)
                        {
                            pixShiftOnThisFrameY = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedY3 *= -1;
                        }
                    }

                    //reset it in case it grwos too large (note: just to avoid an overflow in the far future)
                    //the actual reset happens later below
                    if (pixShiftOnThisFrameX >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameX <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    gv.mod.currentArea.fullScreenAnimationFrameCounterX3 = pixShiftOnThisFrameX;
                    gv.mod.currentArea.fullScreenAnimationFrameCounterY3 = pixShiftOnThisFrameY;
                    #endregion

                    #region iterate through the dst tiles
                    for (int x = minX; x < maxX; x++)
                    {
                        for (int y = minY; y < maxY; y++)
                        {
                            Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];

                            //each tile can block the effects run on the six effect channels, each e.g. simualting shelter from rain
                            if (!tile.blockFullScreenEffectLayer3)
                            {
                                int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                                int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;

                                float scalerX = gv.cc.tileBitmapList[tile.Layer3Filename].PixelSize.Width / 100f;
                                float scalerY = gv.cc.tileBitmapList[tile.Layer3Filename].PixelSize.Height / 100f;
                                float brX = gv.squareSize * scalerX;
                                float brY = gv.squareSize * scalerY;

                                float numberOfPictureParts = gv.playerOffset * 2 + 1;

                                #region is effect contained inside borders or always centered on party?
                                //code section for handling borders of the area
                                int modX = x;
                                int modY = y;
                                int modMinX = minX;
                                int modMinY = minY;

                                if (gv.mod.currentArea.containEffectInsideAreaBorders3)
                                {
                                    //code for for always keeping the effect contained in the area box, break center on player near map border
                                    if ((mod.PlayerLocationX + 4) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 1;
                                    }
                                    if ((mod.PlayerLocationX + 3) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 2;
                                    }
                                    if ((mod.PlayerLocationX + 2) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 3;
                                    }
                                    if ((mod.PlayerLocationX + 1) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 4;
                                    }


                                    if ((mod.PlayerLocationY + 4) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 1;
                                    }
                                    if ((mod.PlayerLocationY + 3) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 2;
                                    }
                                    if ((mod.PlayerLocationY + 2) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 3;
                                    }
                                    if ((mod.PlayerLocationY + 1) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 4;
                                    }
                                }

                                else
                                {
                                    //code for always centering the effect on player, even near map border (e.g. light source carried by party)
                                    if ((mod.PlayerLocationX - 3) == 0)
                                    {
                                        modMinX = -1;
                                    }
                                    if ((mod.PlayerLocationX - 2) == 0)
                                    {
                                        modMinX = -2;
                                    }
                                    if ((mod.PlayerLocationX - 1) == 0)
                                    {
                                        modMinX = -3;
                                    }
                                    if ((mod.PlayerLocationX) == 0)
                                    {
                                        modMinX = -4;
                                    }


                                    if ((mod.PlayerLocationY - 3) == 0)
                                    {
                                        modMinY = -1;
                                    }
                                    if ((mod.PlayerLocationY - 2) == 0)
                                    {
                                        modMinY = -2;
                                    }
                                    if ((mod.PlayerLocationY - 1) == 0)
                                    {
                                        modMinY = -3;
                                    }
                                    if ((mod.PlayerLocationY) == 0)
                                    {
                                        modMinY = -4;
                                    }
                                }
                                #endregion

                                //get the correct chunk on source
                                //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                float floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                float floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                #region handle border situations on source (bottom and right)     
                                //the following four sections help to set the top left x,y of our square incase we ae close to bottom or right border of source

                                if (gv.mod.currentArea.overrideIsNoScrollSource3 == "True")
                                {
                                    sizeOfWholeSource = 0.5f * sizeOfWholeSource;
                                    //get the correct chunk on source
                                    //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                    floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                    floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                    float smallSourceChunk = sizeOfWholeSource / numberOfPictureParts;
                                    sizeOfWholeSource = 2.0f * sizeOfWholeSource;
                                    /*
                                    //stop at border
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = 0;
                                        
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordY >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordY = sizeOfWholeSource - smallSourceChunk - 1;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = 0;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordX = sizeOfWholeSource - smallSourceChunk - 1;
                                    }
                                    */

                                }

                                else
                                {

                                    //leave source in negative direction (vertical)
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = (floatSourceChunkCoordY * -1f);
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                        floatSourceChunkCoordY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    }

                                    //leave source in positive direction (vertical)
                                    if (floatSourceChunkCoordY >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                    }

                                    //leave source in negative direction (horizontal)
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = (floatSourceChunkCoordX * -1f);
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                        floatSourceChunkCoordX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    }

                                    //leave source in positive direction (horizontal)
                                    if (floatSourceChunkCoordX >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                    }
                                }
                                #endregion

                                #region handle the four different draw situations, based on position of chunk on source
                                //next task is to actaully draw up to four pieces of  square source to one target dst
                                //let's go through the differdnt situations that can occur

                                #region Situation 1 (complex, 4 to 1)
                                //Situation 1 (most complex): touching four source squares, we are in the far low right corner
                                //there will be two more 2 source square situations, one for x and one for y direction
                                //also there's of course the standard situation that we just need one coherent source
                                if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && ((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource3 != "True"))
                                {

                                    //need to use parts four source chunks from four different source squares and draw them onto the dst square

                                    //first: top left corner
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect3, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: top right corner
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * dstScalerX)), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect3, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //third: bottom left corner
                                    float oldHeight = (brY * dstScalerY);
                                    availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldHeight, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect3, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //fourth: bottom right corner
                                    oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY + oldHeight, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect3, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    continue;

                                }
                                #endregion

                                #region Situation 2 (2 to 1, x near border)
                                //Situation 2: only x is near right border, y is high/small enough
                                else if (((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource3 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: left hand side
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect3, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: right hand side
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * (dstScalerX))), (brY * (dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect3, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;

                                }
                                #endregion

                                #region Situation 3 (2 to 1, y near border)
                                //Situation 3: only y is near bottom border, x is left/small enough WIP
                                else if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource3 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: top square
                                    float availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect3, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: bottom square
                                    float oldLength = 0;
                                    oldLength = (float)(brY * dstScalerY);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldLength, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect3, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;
                                }
                                #endregion

                                #region Situation 4 (default, neither x or y near border)
                                //Situation 4: the default situation, x and y are sufficiently distant from bottom and right border
                                else
                                {

                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;
                                    float sizeOfSourceChunk2 = 0;
                                    if (gv.mod.currentArea.overrideIsNoScrollSource3 != "True")
                                    {
                                        sizeOfSourceChunk2 = (sizeOfWholeSource / numberOfPictureParts);
                                    }
                                    else
                                    {
                                        sizeOfSourceChunk2 = ((sizeOfWholeSource * 0.5f) / numberOfPictureParts);
                                    }

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, sizeOfSourceChunk2, sizeOfSourceChunk2);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                                        gv.DrawBitmap(fullScreenEffect3, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                }
                                #endregion

                            }
                        }
                    }
                }
                #endregion

            }
            #endregion
            #endregion
            #region Draw full screen layer 4
            //there will be six layers for effects usable by either the top (eg.sky) or bottom (eg sea) full scren draw methods 
            //I would guess that combined about 60.000 pix are ok for performance,so like 6 x 100x100 source bitmaps or fewer, but with higer resolution
            //that's for my laptop

            //check whether the layer4 is activated and set to top level
            if ((gv.mod.currentArea.useFullScreenEffectLayer4) && (gv.mod.currentArea.FullScreenEffectLayer4IsTop))
            {

                gv.cc.DisposeOfBitmap(ref fullScreenEffect4);

                //these replace the normal, linear scroll in direction of vector x,y pattern
                //in the toolset different values for overrides can be set than the defaults they come with
                //this way an author can make use of the non-linear algorithms with different input parameters to bend their shape
                //basically it works like the override would call scripts whose paratmeters can be set by the authors
                //just with the added comfort that teh paarmeters ahve own fields in the toolset and descritive text
                //also when just letting all override values sit at zero,the override will use its own defaults, working out of the box like e.g. snow

                #region override movement patterns

                if (gv.mod.currentArea.directionalOverride4 == "randStraight")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX4 = 0.5f;
                    float defaultOverrideSpeedY4 = 0.5f;
                    int defaultOverrideDelayLimit4 = 15;
                    string defaultOverrideIsNoScrollSource4 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource4 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource4 = defaultOverrideIsNoScrollSource4;
                    }

                    if (gv.mod.currentArea.overrideSpeedX4 != -100)
                    {
                        defaultOverrideSpeedX4 = gv.mod.currentArea.overrideSpeedX4;
                    }
                    if (gv.mod.currentArea.overrideSpeedY4 != -100)
                    {
                        defaultOverrideSpeedY4 = gv.mod.currentArea.overrideSpeedY4;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit4 != -100)
                    {
                        defaultOverrideDelayLimit4 = gv.mod.currentArea.overrideDelayLimit4;
                    }

                    gv.mod.currentArea.overrideDelayCounter4++;
                    if (gv.mod.currentArea.overrideDelayCounter4 > defaultOverrideDelayLimit4)
                    {

                        gv.mod.currentArea.overrideDelayCounter4 = 0;
                        int rollRandom = gv.sf.RandInt(8);
                        //right
                        if (rollRandom == 1)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX4 = defaultOverrideSpeedX4;
                            gv.mod.currentArea.fullScreenAnimationSpeedY4 = 0.0f;
                        }
                        //left
                        if (rollRandom == 2)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX4 = -defaultOverrideSpeedX4;
                            gv.mod.currentArea.fullScreenAnimationSpeedY4 = 0.0f;
                        }
                        //up
                        if (rollRandom == 3)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX4 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY4 = defaultOverrideSpeedY4;
                        }
                        //down
                        if (rollRandom == 4)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX4 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY4 = -defaultOverrideSpeedY4;
                        }
                        //up right
                        if (rollRandom == 5)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX4 = defaultOverrideSpeedX4;
                            gv.mod.currentArea.fullScreenAnimationSpeedY4 = defaultOverrideSpeedY4;
                        }
                        //upleft
                        if (rollRandom == 6)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX4 = -defaultOverrideSpeedX4;
                            gv.mod.currentArea.fullScreenAnimationSpeedY4 = defaultOverrideSpeedY4;
                        }
                        //downright
                        if (rollRandom == 7)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX4 = defaultOverrideSpeedX4;
                            gv.mod.currentArea.fullScreenAnimationSpeedY4 = -defaultOverrideSpeedY4;
                        }
                        //downleft
                        if (rollRandom == 8)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX4 = -defaultOverrideSpeedX4;
                            gv.mod.currentArea.fullScreenAnimationSpeedY4 = -defaultOverrideSpeedY4;
                        }
                    }
                }

                if (gv.mod.currentArea.directionalOverride4 == "clouds")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX4 = 0.5f;
                    float defaultOverrideSpeedY4 = 0.5f;
                    int defaultOverrideDelayLimit4 = 750;
                    string defaultOverrideIsNoScrollSource4 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource4 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource4 = defaultOverrideIsNoScrollSource4;
                    }

                    if (gv.mod.currentArea.overrideSpeedX4 != -100)
                    {
                        defaultOverrideSpeedX4 = gv.mod.currentArea.overrideSpeedX4;
                    }
                    if (gv.mod.currentArea.overrideSpeedY4 != -100)
                    {
                        defaultOverrideSpeedY4 = gv.mod.currentArea.overrideSpeedY4;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit4 != -100)
                    {
                        defaultOverrideDelayLimit4 = gv.mod.currentArea.overrideDelayLimit4;
                    }

                    gv.mod.currentArea.overrideDelayCounter4++;
                    if (gv.mod.currentArea.overrideDelayCounter4 > defaultOverrideDelayLimit4)
                    {

                        gv.mod.currentArea.overrideDelayCounter4 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX4 = ((0.25f * directional) + (decider * defaultOverrideSpeedX4 * 0.5f)) * (0.5f);

                        //for y
                        rollRandom = gv.sf.RandInt(100);
                        rollRandom2 = gv.sf.RandInt(2);
                        directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedY4 = ((0.25f * directional) + (decider * defaultOverrideSpeedY4 * 0.5f)) * (0.5f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride4 == "fog")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX4 = 1.0f;
                    float defaultOverrideSpeedY4 = 1.0f;
                    int defaultOverrideDelayLimit4 = 110;
                    string defaultOverrideIsNoScrollSource4 = "True";

                    if (gv.mod.currentArea.overrideIsNoScrollSource4 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource4 = defaultOverrideIsNoScrollSource4;
                    }

                    if (gv.mod.currentArea.overrideSpeedX4 != -100)
                    {
                        defaultOverrideSpeedX4 = gv.mod.currentArea.overrideSpeedX4;
                    }
                    if (gv.mod.currentArea.overrideSpeedY4 != -100)
                    {
                        defaultOverrideSpeedY4 = gv.mod.currentArea.overrideSpeedY4;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit4 != -100)
                    {
                        defaultOverrideDelayLimit4 = gv.mod.currentArea.overrideDelayLimit4;
                    }

                    gv.mod.currentArea.overrideDelayCounter4++;
                    if (gv.mod.currentArea.overrideDelayCounter4 > defaultOverrideDelayLimit4)
                    {

                        gv.mod.currentArea.overrideDelayCounter4 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(100);
                        int directional = 1;
                        if (rollRandom2 >= 50)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedX4 = ((0.25f * directional) + (decider * defaultOverrideSpeedX4 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedX4 = ((0.075f * directional) + (decider * defaultOverrideSpeedX4 * 0.5f)) * (0.09f);

                        //for y
                        int rollRandom3 = gv.sf.RandInt(100);
                        int rollRandom4 = gv.sf.RandInt(100);
                        directional = 1;
                        if (rollRandom4 >= 50)
                        {
                            rollRandom3 = rollRandom3 * -1;
                            directional = -1;
                        }
                        decider = rollRandom3 / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedY4 = ((0.25f * directional) + (decider * defaultOverrideSpeedY4 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY4 = ((0.075f * directional) + (decider * defaultOverrideSpeedY4 * 0.5f)) * (0.09f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride4 == "snow")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX4 = 0.45f;
                    float defaultOverrideSpeedY4 = -0.55f;
                    int defaultOverrideDelayLimit4 = 470;
                    string defaultOverrideIsNoScrollSource4 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource4 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource4 = defaultOverrideIsNoScrollSource4;
                    }


                    if (gv.mod.currentArea.overrideSpeedX4 != -100)
                    {
                        defaultOverrideSpeedX4 = gv.mod.currentArea.overrideSpeedX4;
                    }
                    if (gv.mod.currentArea.overrideSpeedY4 != -100)
                    {
                        defaultOverrideSpeedY4 = gv.mod.currentArea.overrideSpeedY4;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit4 != -100)
                    {
                        defaultOverrideDelayLimit4 = gv.mod.currentArea.overrideDelayLimit4;
                    }

                    gv.mod.currentArea.overrideDelayCounter4++;
                    if (gv.mod.currentArea.overrideDelayCounter4 > defaultOverrideDelayLimit4)
                    {

                        gv.mod.currentArea.overrideDelayCounter4 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX4 = ((0.15f * directional) + (decider * defaultOverrideSpeedX4 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY4 = defaultOverrideSpeedY4;
                    }
                }

                if (gv.mod.currentArea.directionalOverride4 == "rain")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX4 = 0.5f;
                    float defaultOverrideSpeedY4 = -2.8f;
                    int defaultOverrideDelayLimit4 = 100;
                    string defaultOverrideIsNoScrollSource4 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource4 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource4 = defaultOverrideIsNoScrollSource4;
                    }

                    if (gv.mod.currentArea.overrideSpeedX4 != -100)
                    {
                        defaultOverrideSpeedX4 = gv.mod.currentArea.overrideSpeedX4;
                    }
                    if (gv.mod.currentArea.overrideSpeedY4 != -100)
                    {
                        defaultOverrideSpeedY4 = gv.mod.currentArea.overrideSpeedY4;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit4 != -100)
                    {
                        defaultOverrideDelayLimit4 = gv.mod.currentArea.overrideDelayLimit4;
                    }

                    gv.mod.currentArea.overrideDelayCounter4++;
                    if (gv.mod.currentArea.overrideDelayCounter4 > defaultOverrideDelayLimit4)
                    {

                        gv.mod.currentArea.overrideDelayCounter4 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            //rollRandom = rollRandom * -1;
                            //directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX4 = ((0.25f * directional) + (decider * defaultOverrideSpeedX4 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY4 = defaultOverrideSpeedY4;
                    }
                }

                if (gv.mod.currentArea.directionalOverride4 == "linear")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX4 = 1f;
                    float defaultOverrideSpeedY4 = 1f;
                    int defaultOverrideDelayLimit4 = 100;
                    string defaultOverrideIsNoScrollSource4 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource4 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource4 = defaultOverrideIsNoScrollSource4;
                    }

                    if (gv.mod.currentArea.overrideSpeedX4 != -100)
                    {
                        defaultOverrideSpeedX4 = gv.mod.currentArea.overrideSpeedX4;
                    }
                    if (gv.mod.currentArea.overrideSpeedY4 != -100)
                    {
                        defaultOverrideSpeedY4 = gv.mod.currentArea.overrideSpeedY4;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit4 != -100)
                    {
                        defaultOverrideDelayLimit4 = gv.mod.currentArea.overrideDelayLimit4;
                    }
                    gv.mod.currentArea.fullScreenAnimationSpeedX4 = defaultOverrideSpeedX4;
                    gv.mod.currentArea.fullScreenAnimationSpeedY4 = defaultOverrideSpeedY4;
                }


                #endregion

                if (gv.mod.currentArea.fullScreenEffectLayerIsActive4 == true)
                {
                    #region limited cycle animation
                    //check whether we got an effect that is supposed to happen only once in a while
                    if (gv.mod.currentArea.numberOfCyclesPerOccurence4 != 0)
                    {

                        //added speed
                        float speedComponentX = gv.mod.currentArea.fullScreenAnimationSpeedX4;
                        if (speedComponentX < 0)
                        {
                            speedComponentX *= -1;
                        }
                        float speedComponentY = gv.mod.currentArea.fullScreenAnimationSpeedY4;
                        if (speedComponentY < 0)
                        {
                            speedComponentY *= -1;
                        }
                        gv.mod.currentArea.fullScreenAnimationSpeed4 = speedComponentX + speedComponentY;

                        //based on subjective trial and error
                        if ((gv.mod.currentArea.fullScreenAnimationFrameCounter4 > (50f / (gv.mod.currentArea.fullScreenAnimationSpeed4 * gv.mod.allAnimationSpeedMultiplier) - 1)))
                        {
                            gv.mod.currentArea.cycleCounter4 += 1;
                            gv.mod.currentArea.fullScreenAnimationFrameCounter4 = 0;
                        }

                        //a little extra delay added by on intuition how long a cycle takes here
                        if (gv.mod.currentArea.cycleCounter4 >= (gv.mod.currentArea.numberOfCyclesPerOccurence4))
                        {
                            //turn the animation off, in common code's doudate method a chance per turn is rolled for turning on again
                            gv.mod.currentArea.fullScreenEffectLayerIsActive4 = false;
                            //counts how often/long the aniamtion is displayed before stop
                            gv.mod.currentArea.cycleCounter4 = 0;
                            //just keeping track how often render calls have run through
                            gv.mod.currentArea.fullScreenAnimationFrameCounter4 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeCounter4 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeFrameCounter4 = 1;
                        }

                        gv.mod.currentArea.fullScreenAnimationFrameCounter4 += 1;
                    }
                    #endregion

                    //if (gv.mod.currentArea.fullScreenEffectLayerIsActive4 == true)
                    //{
                    float fullScreenEffectOpacity = 1f;
                    #region opacity code
                    if (gv.mod.currentArea.useCyclicFade4)
                    {
                        //fade in within first cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter4 == 0) && (gv.mod.currentArea.numberOfCyclesPerOccurence4 != 0))
                        {
                            fullScreenEffectOpacity = 1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed4 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter4);
                        }

                        //fade out within last cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter4 == (gv.mod.currentArea.numberOfCyclesPerOccurence4 - 1)) && (gv.mod.currentArea.numberOfCyclesPerOccurence4 != 0))
                        {
                            fullScreenEffectOpacity = 1f - (1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed4 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter4));
                        }
                    }
                    #endregion

                    //use weather system per area specific later on
                    //utilizing weather type defined by area weather settings
                    //add check for square specific punch hole that prevents drawing weather, e.g. house inside or spaceship interior

                    #region only for shape changing animation
                    if (gv.mod.currentArea.isChanging4)
                    {
                        gv.mod.currentArea.changeCounter4 += (1 * gv.mod.allAnimationSpeedMultiplier);
                        if (gv.mod.currentArea.changeCounter4 > gv.mod.currentArea.changeLimit4)
                        {
                            gv.mod.currentArea.changeCounter4 = 0;
                            gv.mod.currentArea.changeFrameCounter4 += 1;
                            if (gv.mod.currentArea.changeFrameCounter4 > gv.mod.currentArea.changeNumberOfFrames4)
                            {
                                gv.mod.currentArea.changeFrameCounter4 = 1;
                            }
                        }
                        fullScreenEffect4 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName4 + gv.mod.currentArea.changeFrameCounter4.ToString());
                    }
                    #endregion

                    else
                    {
                        fullScreenEffect4 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName4);
                    }

                    #region handle framecounter
                    //assuming a square shaped source here
                    float sizeOfWholeSource = fullScreenEffect4.PixelSize.Width;

                    //reading the frames moved and added up in the last seconds
                    float pixShiftOnThisFrameX = gv.mod.currentArea.fullScreenAnimationFrameCounterX4;
                    float pixShiftOnThisFrameY = gv.mod.currentArea.fullScreenAnimationFrameCounterY4;

                    //increase by this call's movement
                    pixShiftOnThisFrameX += (gv.mod.currentArea.fullScreenAnimationSpeedX4 * gv.mod.allAnimationSpeedMultiplier);
                    pixShiftOnThisFrameY += (gv.mod.currentArea.fullScreenAnimationSpeedY4 * gv.mod.allAnimationSpeedMultiplier);

                    if (gv.mod.currentArea.overrideIsNoScrollSource4 == "True")
                    {
                        if (pixShiftOnThisFrameX > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameX = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedX4 *= -1;
                        }

                        if (pixShiftOnThisFrameY > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameY = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY4 *= -1;
                        }

                        if (pixShiftOnThisFrameX < 0)
                        {
                            pixShiftOnThisFrameX = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedX4 *= -1;
                        }

                        if (pixShiftOnThisFrameY < 0)
                        {
                            pixShiftOnThisFrameY = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedY4 *= -1;
                        }
                    }

                    //reset it in case it grwos too large (note: just to avoid an overflow in the far future)
                    //the actual reset happens later below
                    if (pixShiftOnThisFrameX >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameX <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    gv.mod.currentArea.fullScreenAnimationFrameCounterX4 = pixShiftOnThisFrameX;
                    gv.mod.currentArea.fullScreenAnimationFrameCounterY4 = pixShiftOnThisFrameY;
                    #endregion

                    #region iterate through the dst tiles
                    for (int x = minX; x < maxX; x++)
                    {
                        for (int y = minY; y < maxY; y++)
                        {
                            Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];

                            //each tile can block the effects run on the six effect channels, each e.g. simualting shelter from rain
                            if (!tile.blockFullScreenEffectLayer4)
                            {
                                int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                                int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;

                                float scalerX = gv.cc.tileBitmapList[tile.Layer4Filename].PixelSize.Width / 100f;
                                float scalerY = gv.cc.tileBitmapList[tile.Layer4Filename].PixelSize.Height / 100f;
                                float brX = gv.squareSize * scalerX;
                                float brY = gv.squareSize * scalerY;

                                float numberOfPictureParts = gv.playerOffset * 2 + 1;

                                #region is effect contained inside borders or always centered on party?
                                //code section for handling borders of the area
                                int modX = x;
                                int modY = y;
                                int modMinX = minX;
                                int modMinY = minY;

                                if (gv.mod.currentArea.containEffectInsideAreaBorders4)
                                {
                                    //code for for always keeping the effect contained in the area box, break center on player near map border
                                    if ((mod.PlayerLocationX + 4) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 1;
                                    }
                                    if ((mod.PlayerLocationX + 3) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 2;
                                    }
                                    if ((mod.PlayerLocationX + 2) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 3;
                                    }
                                    if ((mod.PlayerLocationX + 1) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 4;
                                    }


                                    if ((mod.PlayerLocationY + 4) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 1;
                                    }
                                    if ((mod.PlayerLocationY + 3) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 2;
                                    }
                                    if ((mod.PlayerLocationY + 2) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 3;
                                    }
                                    if ((mod.PlayerLocationY + 1) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 4;
                                    }
                                }

                                else
                                {
                                    //code for always centering the effect on player, even near map border (e.g. light source carried by party)
                                    if ((mod.PlayerLocationX - 3) == 0)
                                    {
                                        modMinX = -1;
                                    }
                                    if ((mod.PlayerLocationX - 2) == 0)
                                    {
                                        modMinX = -2;
                                    }
                                    if ((mod.PlayerLocationX - 1) == 0)
                                    {
                                        modMinX = -3;
                                    }
                                    if ((mod.PlayerLocationX) == 0)
                                    {
                                        modMinX = -4;
                                    }


                                    if ((mod.PlayerLocationY - 3) == 0)
                                    {
                                        modMinY = -1;
                                    }
                                    if ((mod.PlayerLocationY - 2) == 0)
                                    {
                                        modMinY = -2;
                                    }
                                    if ((mod.PlayerLocationY - 1) == 0)
                                    {
                                        modMinY = -3;
                                    }
                                    if ((mod.PlayerLocationY) == 0)
                                    {
                                        modMinY = -4;
                                    }
                                }
                                #endregion

                                //get the correct chunk on source
                                //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                float floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                float floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                #region handle border situations on source (bottom and right)     
                                //the following four sections help to set the top left x,y of our square incase we ae close to bottom or right border of source

                                if (gv.mod.currentArea.overrideIsNoScrollSource4 == "True")
                                {
                                    sizeOfWholeSource = 0.5f * sizeOfWholeSource;
                                    //get the correct chunk on source
                                    //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                    floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                    floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                    float smallSourceChunk = sizeOfWholeSource / numberOfPictureParts;
                                    sizeOfWholeSource = 2.0f * sizeOfWholeSource;
                                    /*
                                    //stop at border
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = 0;
                                        
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordY >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordY = sizeOfWholeSource - smallSourceChunk - 1;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = 0;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordX = sizeOfWholeSource - smallSourceChunk - 1;
                                    }
                                    */

                                }

                                else
                                {

                                    //leave source in negative direction (vertical)
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = (floatSourceChunkCoordY * -1f);
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                        floatSourceChunkCoordY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    }

                                    //leave source in positive direction (vertical)
                                    if (floatSourceChunkCoordY >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                    }

                                    //leave source in negative direction (horizontal)
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = (floatSourceChunkCoordX * -1f);
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                        floatSourceChunkCoordX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    }

                                    //leave source in positive direction (horizontal)
                                    if (floatSourceChunkCoordX >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                    }
                                }
                                #endregion

                                #region handle the four different draw situations, based on position of chunk on source
                                //next task is to actaully draw up to four pieces of  square source to one target dst
                                //let's go through the differdnt situations that can occur

                                #region Situation 1 (complex, 4 to 1)
                                //Situation 1 (most complex): touching four source squares, we are in the far low right corner
                                //there will be two more 2 source square situations, one for x and one for y direction
                                //also there's of course the standard situation that we just need one coherent source
                                if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && ((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource4 != "True"))
                                {

                                    //need to use parts four source chunks from four different source squares and draw them onto the dst square

                                    //first: top left corner
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect4, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: top right corner
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * dstScalerX)), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect4, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //third: bottom left corner
                                    float oldHeight = (brY * dstScalerY);
                                    availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldHeight, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect4, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //fourth: bottom right corner
                                    oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY + oldHeight, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect4, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    continue;

                                }
                                #endregion

                                #region Situation 2 (2 to 1, x near border)
                                //Situation 2: only x is near right border, y is high/small enough
                                else if (((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource4 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: left hand side
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect4, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: right hand side
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * (dstScalerX))), (brY * (dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect4, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;

                                }
                                #endregion

                                #region Situation 3 (2 to 1, y near border)
                                //Situation 3: only y is near bottom border, x is left/small enough WIP
                                else if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource4 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: top square
                                    float availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect4, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: bottom square
                                    float oldLength = 0;
                                    oldLength = (float)(brY * dstScalerY);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldLength, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect4, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;
                                }
                                #endregion

                                #region Situation 4 (default, neither x or y near border)
                                //Situation 4: the default situation, x and y are sufficiently distant from bottom and right border
                                else
                                {

                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;
                                    float sizeOfSourceChunk2 = 0;
                                    if (gv.mod.currentArea.overrideIsNoScrollSource4 != "True")
                                    {
                                        sizeOfSourceChunk2 = (sizeOfWholeSource / numberOfPictureParts);
                                    }
                                    else
                                    {
                                        sizeOfSourceChunk2 = ((sizeOfWholeSource * 0.5f) / numberOfPictureParts);
                                    }

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, sizeOfSourceChunk2, sizeOfSourceChunk2);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                                        gv.DrawBitmap(fullScreenEffect4, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                }
                                #endregion

                            }
                        }
                    }
                }
                #endregion

            }
            #endregion
            #endregion
            #region Draw full screen layer 5
            //there will be six layers for effects usable by either the top (eg.sky) or bottom (eg sea) full scren draw methods 
            //I would guess that combined about 60.000 pix are ok for performance,so like 6 x 100x100 source bitmaps or fewer, but with higer resolution
            //that's for my laptop

            //check whether the layer5 is activated and set to top level
            if ((gv.mod.currentArea.useFullScreenEffectLayer5) && (gv.mod.currentArea.FullScreenEffectLayer5IsTop))
            {

                gv.cc.DisposeOfBitmap(ref fullScreenEffect5);

                //these replace the normal, linear scroll in direction of vector x,y pattern
                //in the toolset different values for overrides can be set than the defaults they come with
                //this way an author can make use of the non-linear algorithms with different input parameters to bend their shape
                //basically it works like the override would call scripts whose paratmeters can be set by the authors
                //just with the added comfort that teh paarmeters ahve own fields in the toolset and descritive text
                //also when just letting all override values sit at zero,the override will use its own defaults, working out of the box like e.g. snow

                #region override movement patterns

                if (gv.mod.currentArea.directionalOverride5 == "randStraight")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX5 = 0.5f;
                    float defaultOverrideSpeedY5 = 0.5f;
                    int defaultOverrideDelayLimit5 = 15;
                    string defaultOverrideIsNoScrollSource5 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource5 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource5 = defaultOverrideIsNoScrollSource5;
                    }

                    if (gv.mod.currentArea.overrideSpeedX5 != -100)
                    {
                        defaultOverrideSpeedX5 = gv.mod.currentArea.overrideSpeedX5;
                    }
                    if (gv.mod.currentArea.overrideSpeedY5 != -100)
                    {
                        defaultOverrideSpeedY5 = gv.mod.currentArea.overrideSpeedY5;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit5 != -100)
                    {
                        defaultOverrideDelayLimit5 = gv.mod.currentArea.overrideDelayLimit5;
                    }

                    gv.mod.currentArea.overrideDelayCounter5++;
                    if (gv.mod.currentArea.overrideDelayCounter5 > defaultOverrideDelayLimit5)
                    {

                        gv.mod.currentArea.overrideDelayCounter5 = 0;
                        int rollRandom = gv.sf.RandInt(8);
                        //right
                        if (rollRandom == 1)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX5 = defaultOverrideSpeedX5;
                            gv.mod.currentArea.fullScreenAnimationSpeedY5 = 0.0f;
                        }
                        //left
                        if (rollRandom == 2)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX5 = -defaultOverrideSpeedX5;
                            gv.mod.currentArea.fullScreenAnimationSpeedY5 = 0.0f;
                        }
                        //up
                        if (rollRandom == 3)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX5 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY5 = defaultOverrideSpeedY5;
                        }
                        //down
                        if (rollRandom == 4)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX5 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY5 = -defaultOverrideSpeedY5;
                        }
                        //up right
                        if (rollRandom == 5)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX5 = defaultOverrideSpeedX5;
                            gv.mod.currentArea.fullScreenAnimationSpeedY5 = defaultOverrideSpeedY5;
                        }
                        //upleft
                        if (rollRandom == 6)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX5 = -defaultOverrideSpeedX5;
                            gv.mod.currentArea.fullScreenAnimationSpeedY5 = defaultOverrideSpeedY5;
                        }
                        //downright
                        if (rollRandom == 7)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX5 = defaultOverrideSpeedX5;
                            gv.mod.currentArea.fullScreenAnimationSpeedY5 = -defaultOverrideSpeedY5;
                        }
                        //downleft
                        if (rollRandom == 8)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX5 = -defaultOverrideSpeedX5;
                            gv.mod.currentArea.fullScreenAnimationSpeedY5 = -defaultOverrideSpeedY5;
                        }
                    }
                }

                if (gv.mod.currentArea.directionalOverride5 == "clouds")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX5 = 0.5f;
                    float defaultOverrideSpeedY5 = 0.5f;
                    int defaultOverrideDelayLimit5 = 750;
                    string defaultOverrideIsNoScrollSource5 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource5 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource5 = defaultOverrideIsNoScrollSource5;
                    }

                    if (gv.mod.currentArea.overrideSpeedX5 != -100)
                    {
                        defaultOverrideSpeedX5 = gv.mod.currentArea.overrideSpeedX5;
                    }
                    if (gv.mod.currentArea.overrideSpeedY5 != -100)
                    {
                        defaultOverrideSpeedY5 = gv.mod.currentArea.overrideSpeedY5;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit5 != -100)
                    {
                        defaultOverrideDelayLimit5 = gv.mod.currentArea.overrideDelayLimit5;
                    }

                    gv.mod.currentArea.overrideDelayCounter5++;
                    if (gv.mod.currentArea.overrideDelayCounter5 > defaultOverrideDelayLimit5)
                    {

                        gv.mod.currentArea.overrideDelayCounter5 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX5 = ((0.25f * directional) + (decider * defaultOverrideSpeedX5 * 0.5f)) * (0.5f);

                        //for y
                        rollRandom = gv.sf.RandInt(100);
                        rollRandom2 = gv.sf.RandInt(2);
                        directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedY5 = ((0.25f * directional) + (decider * defaultOverrideSpeedY5 * 0.5f)) * (0.5f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride5 == "fog")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX5 = 1.0f;
                    float defaultOverrideSpeedY5 = 1.0f;
                    int defaultOverrideDelayLimit5 = 110;
                    string defaultOverrideIsNoScrollSource5 = "True";

                    if (gv.mod.currentArea.overrideIsNoScrollSource5 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource5 = defaultOverrideIsNoScrollSource5;
                    }

                    if (gv.mod.currentArea.overrideSpeedX5 != -100)
                    {
                        defaultOverrideSpeedX5 = gv.mod.currentArea.overrideSpeedX5;
                    }
                    if (gv.mod.currentArea.overrideSpeedY5 != -100)
                    {
                        defaultOverrideSpeedY5 = gv.mod.currentArea.overrideSpeedY5;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit5 != -100)
                    {
                        defaultOverrideDelayLimit5 = gv.mod.currentArea.overrideDelayLimit5;
                    }

                    gv.mod.currentArea.overrideDelayCounter5++;
                    if (gv.mod.currentArea.overrideDelayCounter5 > defaultOverrideDelayLimit5)
                    {

                        gv.mod.currentArea.overrideDelayCounter5 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(100);
                        int directional = 1;
                        if (rollRandom2 >= 50)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedX5 = ((0.25f * directional) + (decider * defaultOverrideSpeedX5 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedX5 = ((0.075f * directional) + (decider * defaultOverrideSpeedX5 * 0.5f)) * (0.09f);

                        //for y
                        int rollRandom3 = gv.sf.RandInt(100);
                        int rollRandom4 = gv.sf.RandInt(100);
                        directional = 1;
                        if (rollRandom4 >= 50)
                        {
                            rollRandom3 = rollRandom3 * -1;
                            directional = -1;
                        }
                        decider = rollRandom3 / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedY5 = ((0.25f * directional) + (decider * defaultOverrideSpeedY5 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY5 = ((0.075f * directional) + (decider * defaultOverrideSpeedY5 * 0.5f)) * (0.09f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride5 == "snow")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX5 = 0.45f;
                    float defaultOverrideSpeedY5 = -0.55f;
                    int defaultOverrideDelayLimit5 = 470;
                    string defaultOverrideIsNoScrollSource5 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource5 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource5 = defaultOverrideIsNoScrollSource5;
                    }


                    if (gv.mod.currentArea.overrideSpeedX5 != -100)
                    {
                        defaultOverrideSpeedX5 = gv.mod.currentArea.overrideSpeedX5;
                    }
                    if (gv.mod.currentArea.overrideSpeedY5 != -100)
                    {
                        defaultOverrideSpeedY5 = gv.mod.currentArea.overrideSpeedY5;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit5 != -100)
                    {
                        defaultOverrideDelayLimit5 = gv.mod.currentArea.overrideDelayLimit5;
                    }

                    gv.mod.currentArea.overrideDelayCounter5++;
                    if (gv.mod.currentArea.overrideDelayCounter5 > defaultOverrideDelayLimit5)
                    {

                        gv.mod.currentArea.overrideDelayCounter5 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX5 = ((0.15f * directional) + (decider * defaultOverrideSpeedX5 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY5 = defaultOverrideSpeedY5;
                    }
                }

                if (gv.mod.currentArea.directionalOverride5 == "rain")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX5 = 0.5f;
                    float defaultOverrideSpeedY5 = -2.8f;
                    int defaultOverrideDelayLimit5 = 100;
                    string defaultOverrideIsNoScrollSource5 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource5 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource5 = defaultOverrideIsNoScrollSource5;
                    }

                    if (gv.mod.currentArea.overrideSpeedX5 != -100)
                    {
                        defaultOverrideSpeedX5 = gv.mod.currentArea.overrideSpeedX5;
                    }
                    if (gv.mod.currentArea.overrideSpeedY5 != -100)
                    {
                        defaultOverrideSpeedY5 = gv.mod.currentArea.overrideSpeedY5;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit5 != -100)
                    {
                        defaultOverrideDelayLimit5 = gv.mod.currentArea.overrideDelayLimit5;
                    }

                    gv.mod.currentArea.overrideDelayCounter5++;
                    if (gv.mod.currentArea.overrideDelayCounter5 > defaultOverrideDelayLimit5)
                    {

                        gv.mod.currentArea.overrideDelayCounter5 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            //rollRandom = rollRandom * -1;
                            //directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX5 = ((0.25f * directional) + (decider * defaultOverrideSpeedX5 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY5 = defaultOverrideSpeedY5;
                    }
                }

                if (gv.mod.currentArea.directionalOverride5 == "linear")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX5 = 1f;
                    float defaultOverrideSpeedY5 = 1f;
                    int defaultOverrideDelayLimit5 = 100;
                    string defaultOverrideIsNoScrollSource5 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource5 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource5 = defaultOverrideIsNoScrollSource5;
                    }

                    if (gv.mod.currentArea.overrideSpeedX5 != -100)
                    {
                        defaultOverrideSpeedX5 = gv.mod.currentArea.overrideSpeedX5;
                    }
                    if (gv.mod.currentArea.overrideSpeedY5 != -100)
                    {
                        defaultOverrideSpeedY5 = gv.mod.currentArea.overrideSpeedY5;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit5 != -100)
                    {
                        defaultOverrideDelayLimit5 = gv.mod.currentArea.overrideDelayLimit5;
                    }
                    gv.mod.currentArea.fullScreenAnimationSpeedX5 = defaultOverrideSpeedX5;
                    gv.mod.currentArea.fullScreenAnimationSpeedY5 = defaultOverrideSpeedY5;
                }


                #endregion

                if (gv.mod.currentArea.fullScreenEffectLayerIsActive5 == true)
                {
                    #region limited cycle animation
                    //check whether we got an effect that is supposed to happen only once in a while
                    if (gv.mod.currentArea.numberOfCyclesPerOccurence5 != 0)
                    {

                        //added speed
                        float speedComponentX = gv.mod.currentArea.fullScreenAnimationSpeedX5;
                        if (speedComponentX < 0)
                        {
                            speedComponentX *= -1;
                        }
                        float speedComponentY = gv.mod.currentArea.fullScreenAnimationSpeedY5;
                        if (speedComponentY < 0)
                        {
                            speedComponentY *= -1;
                        }
                        gv.mod.currentArea.fullScreenAnimationSpeed5 = speedComponentX + speedComponentY;

                        //based on subjective trial and error
                        if ((gv.mod.currentArea.fullScreenAnimationFrameCounter5 > (50f / (gv.mod.currentArea.fullScreenAnimationSpeed5 * gv.mod.allAnimationSpeedMultiplier) - 1)))
                        {
                            gv.mod.currentArea.cycleCounter5 += 1;
                            gv.mod.currentArea.fullScreenAnimationFrameCounter5 = 0;
                        }

                        //a little extra delay added by on intuition how long a cycle takes here
                        if (gv.mod.currentArea.cycleCounter5 >= (gv.mod.currentArea.numberOfCyclesPerOccurence5))
                        {
                            //turn the animation off, in common code's doudate method a chance per turn is rolled for turning on again
                            gv.mod.currentArea.fullScreenEffectLayerIsActive5 = false;
                            //counts how often/long the aniamtion is displayed before stop
                            gv.mod.currentArea.cycleCounter5 = 0;
                            //just keeping track how often render calls have run through
                            gv.mod.currentArea.fullScreenAnimationFrameCounter5 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeCounter5 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeFrameCounter5 = 1;
                        }

                        gv.mod.currentArea.fullScreenAnimationFrameCounter5 += 1;
                    }
                    #endregion

                    //if (gv.mod.currentArea.fullScreenEffectLayerIsActive5 == true)
                    //{
                    float fullScreenEffectOpacity = 1f;
                    #region opacity code
                    if (gv.mod.currentArea.useCyclicFade5)
                    {
                        //fade in within first cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter5 == 0) && (gv.mod.currentArea.numberOfCyclesPerOccurence5 != 0))
                        {
                            fullScreenEffectOpacity = 1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed5 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter5);
                        }

                        //fade out within last cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter5 == (gv.mod.currentArea.numberOfCyclesPerOccurence5 - 1)) && (gv.mod.currentArea.numberOfCyclesPerOccurence5 != 0))
                        {
                            fullScreenEffectOpacity = 1f - (1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed5 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter5));
                        }
                    }

                    if (gv.mod.fullScreenEffectOpacityWeather != 1)
                    {
                        fullScreenEffectOpacity = gv.mod.fullScreenEffectOpacityWeather;
                    }

                    #endregion

                    //use weather system per area specific later on
                    //utilizing weather type defined by area weather settings
                    //add check for square specific punch hole that prevents drawing weather, e.g. house inside or spaceship interior

                    #region only for shape changing animation
                    if (gv.mod.currentArea.isChanging5)
                    {
                        gv.mod.currentArea.changeCounter5 += (1 * gv.mod.allAnimationSpeedMultiplier);
                        if (gv.mod.currentArea.changeCounter5 > gv.mod.currentArea.changeLimit5)
                        {
                            gv.mod.currentArea.changeCounter5 = 0;
                            gv.mod.currentArea.changeFrameCounter5 += 1;
                            if (gv.mod.currentArea.changeFrameCounter5 > gv.mod.currentArea.changeNumberOfFrames5)
                            {
                                gv.mod.currentArea.changeFrameCounter5 = 1;
                            }
                        }
                        fullScreenEffect5 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName5 + gv.mod.currentArea.changeFrameCounter5.ToString());
                    }
                    #endregion

                    else
                    {
                        fullScreenEffect5 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName5);
                    }

                    #region handle framecounter
                    //assuming a square shaped source here
                    float sizeOfWholeSource = fullScreenEffect5.PixelSize.Width;

                    //reading the frames moved and added up in the last seconds
                    float pixShiftOnThisFrameX = gv.mod.currentArea.fullScreenAnimationFrameCounterX5;
                    float pixShiftOnThisFrameY = gv.mod.currentArea.fullScreenAnimationFrameCounterY5;

                    //increase by this call's movement
                    pixShiftOnThisFrameX += (gv.mod.currentArea.fullScreenAnimationSpeedX5 * gv.mod.allAnimationSpeedMultiplier);
                    pixShiftOnThisFrameY += (gv.mod.currentArea.fullScreenAnimationSpeedY5 * gv.mod.allAnimationSpeedMultiplier);

                    if (gv.mod.currentArea.overrideIsNoScrollSource5 == "True")
                    {
                        if (pixShiftOnThisFrameX > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameX = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedX5 *= -1;
                        }

                        if (pixShiftOnThisFrameY > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameY = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY5 *= -1;
                        }

                        if (pixShiftOnThisFrameX < 0)
                        {
                            pixShiftOnThisFrameX = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedX5 *= -1;
                        }

                        if (pixShiftOnThisFrameY < 0)
                        {
                            pixShiftOnThisFrameY = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedY5 *= -1;
                        }
                    }

                    //reset it in case it grwos too large (note: just to avoid an overflow in the far future)
                    //the actual reset happens later below
                    if (pixShiftOnThisFrameX >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameX <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    gv.mod.currentArea.fullScreenAnimationFrameCounterX5 = pixShiftOnThisFrameX;
                    gv.mod.currentArea.fullScreenAnimationFrameCounterY5 = pixShiftOnThisFrameY;
                    #endregion

                    #region iterate through the dst tiles
                    for (int x = minX; x < maxX; x++)
                    {
                        for (int y = minY; y < maxY; y++)
                        {
                            Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];

                            //each tile can block the effects run on the six effect channels, each e.g. simualting shelter from rain
                            if (!tile.blockFullScreenEffectLayer5)
                            {
                                int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                                int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;

                                float scalerX = gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Width / 100f;
                                float scalerY = gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Height / 100f;
                                float brX = gv.squareSize * scalerX;
                                float brY = gv.squareSize * scalerY;

                                float numberOfPictureParts = gv.playerOffset * 2 + 1;

                                #region is effect contained inside borders or always centered on party?
                                //code section for handling borders of the area
                                int modX = x;
                                int modY = y;
                                int modMinX = minX;
                                int modMinY = minY;

                                if (gv.mod.currentArea.containEffectInsideAreaBorders5)
                                {
                                    //code for for always keeping the effect contained in the area box, break center on player near map border
                                    if ((mod.PlayerLocationX + 4) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 1;
                                    }
                                    if ((mod.PlayerLocationX + 3) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 2;
                                    }
                                    if ((mod.PlayerLocationX + 2) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 3;
                                    }
                                    if ((mod.PlayerLocationX + 1) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 4;
                                    }


                                    if ((mod.PlayerLocationY + 4) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 1;
                                    }
                                    if ((mod.PlayerLocationY + 3) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 2;
                                    }
                                    if ((mod.PlayerLocationY + 2) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 3;
                                    }
                                    if ((mod.PlayerLocationY + 1) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 4;
                                    }
                                }

                                else
                                {
                                    //code for always centering the effect on player, even near map border (e.g. light source carried by party)
                                    if ((mod.PlayerLocationX - 3) == 0)
                                    {
                                        modMinX = -1;
                                    }
                                    if ((mod.PlayerLocationX - 2) == 0)
                                    {
                                        modMinX = -2;
                                    }
                                    if ((mod.PlayerLocationX - 1) == 0)
                                    {
                                        modMinX = -3;
                                    }
                                    if ((mod.PlayerLocationX) == 0)
                                    {
                                        modMinX = -4;
                                    }


                                    if ((mod.PlayerLocationY - 3) == 0)
                                    {
                                        modMinY = -1;
                                    }
                                    if ((mod.PlayerLocationY - 2) == 0)
                                    {
                                        modMinY = -2;
                                    }
                                    if ((mod.PlayerLocationY - 1) == 0)
                                    {
                                        modMinY = -3;
                                    }
                                    if ((mod.PlayerLocationY) == 0)
                                    {
                                        modMinY = -4;
                                    }
                                }
                                #endregion

                                //get the correct chunk on source
                                //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                float floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                float floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                #region handle border situations on source (bottom and right)     
                                //the following four sections help to set the top left x,y of our square incase we ae close to bottom or right border of source

                                if (gv.mod.currentArea.overrideIsNoScrollSource5 == "True")
                                {
                                    sizeOfWholeSource = 0.5f * sizeOfWholeSource;
                                    //get the correct chunk on source
                                    //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                    floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                    floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                    float smallSourceChunk = sizeOfWholeSource / numberOfPictureParts;
                                    sizeOfWholeSource = 2.0f * sizeOfWholeSource;
                                    /*
                                    //stop at border
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = 0;
                                        
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordY >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordY = sizeOfWholeSource - smallSourceChunk - 1;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = 0;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordX = sizeOfWholeSource - smallSourceChunk - 1;
                                    }
                                    */

                                }

                                else
                                {

                                    //leave source in negative direction (vertical)
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = (floatSourceChunkCoordY * -1f);
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                        floatSourceChunkCoordY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    }

                                    //leave source in positive direction (vertical)
                                    if (floatSourceChunkCoordY >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                    }

                                    //leave source in negative direction (horizontal)
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = (floatSourceChunkCoordX * -1f);
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                        floatSourceChunkCoordX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    }

                                    //leave source in positive direction (horizontal)
                                    if (floatSourceChunkCoordX >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                    }
                                }
                                #endregion

                                #region handle the four different draw situations, based on position of chunk on source
                                //next task is to actaully draw up to four pieces of  square source to one target dst
                                //let's go through the differdnt situations that can occur

                                #region Situation 1 (complex, 4 to 1)
                                //Situation 1 (most complex): touching four source squares, we are in the far low right corner
                                //there will be two more 2 source square situations, one for x and one for y direction
                                //also there's of course the standard situation that we just need one coherent source
                                if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && ((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource5 != "True"))
                                {

                                    //need to use parts four source chunks from four different source squares and draw them onto the dst square

                                    //first: top left corner
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect5, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: top right corner
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * dstScalerX)), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect5, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //third: bottom left corner
                                    float oldHeight = (brY * dstScalerY);
                                    availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldHeight, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect5, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //fourth: bottom right corner
                                    oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY + oldHeight, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect5, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    continue;

                                }
                                #endregion

                                #region Situation 2 (2 to 1, x near border)
                                //Situation 2: only x is near right border, y is high/small enough
                                else if (((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource5 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: left hand side
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect5, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: right hand side
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * (dstScalerX))), (brY * (dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect5, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;

                                }
                                #endregion

                                #region Situation 3 (2 to 1, y near border)
                                //Situation 3: only y is near bottom border, x is left/small enough WIP
                                else if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource5 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: top square
                                    float availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect5, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: bottom square
                                    float oldLength = 0;
                                    oldLength = (float)(brY * dstScalerY);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldLength, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect5, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;
                                }
                                #endregion

                                #region Situation 4 (default, neither x or y near border)
                                //Situation 4: the default situation, x and y are sufficiently distant from bottom and right border
                                else
                                {

                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;
                                    float sizeOfSourceChunk2 = 0;
                                    if (gv.mod.currentArea.overrideIsNoScrollSource5 != "True")
                                    {
                                        sizeOfSourceChunk2 = (sizeOfWholeSource / numberOfPictureParts);
                                    }
                                    else
                                    {
                                        sizeOfSourceChunk2 = ((sizeOfWholeSource * 0.5f) / numberOfPictureParts);
                                    }

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, sizeOfSourceChunk2, sizeOfSourceChunk2);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                                        gv.DrawBitmap(fullScreenEffect5, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                }
                                #endregion

                            }
                        }
                    }
                }
                #endregion

            }
            #endregion
            #endregion
            #region Draw full screen layer 6
            //there will be six layers for effects usable by either the top (eg.sky) or bottom (eg sea) full scren draw methods 
            //I would guess that combined about 60.000 pix are ok for performance,so like 6 x 100x100 source bitmaps or fewer, but with higer resolution
            //that's for my laptop

            //check whether the layer6 is activated and set to top level
            if ((gv.mod.currentArea.useFullScreenEffectLayer6) && (gv.mod.currentArea.FullScreenEffectLayer6IsTop))
            {

                gv.cc.DisposeOfBitmap(ref fullScreenEffect6);

                //these replace the normal, linear scroll in direction of vector x,y pattern
                //in the toolset different values for overrides can be set than the defaults they come with
                //this way an author can make use of the non-linear algorithms with different input parameters to bend their shape
                //basically it works like the override would call scripts whose paratmeters can be set by the authors
                //just with the added comfort that teh paarmeters ahve own fields in the toolset and descritive text
                //also when just letting all override values sit at zero,the override will use its own defaults, working out of the box like e.g. snow

                #region override movement patterns

                if (gv.mod.currentArea.directionalOverride6 == "randStraight")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX6 = 0.5f;
                    float defaultOverrideSpeedY6 = 0.5f;
                    int defaultOverrideDelayLimit6 = 15;
                    string defaultOverrideIsNoScrollSource6 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource6 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource6 = defaultOverrideIsNoScrollSource6;
                    }

                    if (gv.mod.currentArea.overrideSpeedX6 != -100)
                    {
                        defaultOverrideSpeedX6 = gv.mod.currentArea.overrideSpeedX6;
                    }
                    if (gv.mod.currentArea.overrideSpeedY6 != -100)
                    {
                        defaultOverrideSpeedY6 = gv.mod.currentArea.overrideSpeedY6;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit6 != -100)
                    {
                        defaultOverrideDelayLimit6 = gv.mod.currentArea.overrideDelayLimit6;
                    }

                    gv.mod.currentArea.overrideDelayCounter6++;
                    if (gv.mod.currentArea.overrideDelayCounter6 > defaultOverrideDelayLimit6)
                    {

                        gv.mod.currentArea.overrideDelayCounter6 = 0;
                        int rollRandom = gv.sf.RandInt(8);
                        //right
                        if (rollRandom == 1)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX6 = defaultOverrideSpeedX6;
                            gv.mod.currentArea.fullScreenAnimationSpeedY6 = 0.0f;
                        }
                        //left
                        if (rollRandom == 2)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX6 = -defaultOverrideSpeedX6;
                            gv.mod.currentArea.fullScreenAnimationSpeedY6 = 0.0f;
                        }
                        //up
                        if (rollRandom == 3)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX6 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY6 = defaultOverrideSpeedY6;
                        }
                        //down
                        if (rollRandom == 4)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX6 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY6 = -defaultOverrideSpeedY6;
                        }
                        //up right
                        if (rollRandom == 5)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX6 = defaultOverrideSpeedX6;
                            gv.mod.currentArea.fullScreenAnimationSpeedY6 = defaultOverrideSpeedY6;
                        }
                        //upleft
                        if (rollRandom == 6)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX6 = -defaultOverrideSpeedX6;
                            gv.mod.currentArea.fullScreenAnimationSpeedY6 = defaultOverrideSpeedY6;
                        }
                        //downright
                        if (rollRandom == 7)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX6 = defaultOverrideSpeedX6;
                            gv.mod.currentArea.fullScreenAnimationSpeedY6 = -defaultOverrideSpeedY6;
                        }
                        //downleft
                        if (rollRandom == 8)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX6 = -defaultOverrideSpeedX6;
                            gv.mod.currentArea.fullScreenAnimationSpeedY6 = -defaultOverrideSpeedY6;
                        }
                    }
                }

                if (gv.mod.currentArea.directionalOverride6 == "clouds")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX6 = 0.5f;
                    float defaultOverrideSpeedY6 = 0.5f;
                    int defaultOverrideDelayLimit6 = 750;
                    string defaultOverrideIsNoScrollSource6 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource6 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource6 = defaultOverrideIsNoScrollSource6;
                    }

                    if (gv.mod.currentArea.overrideSpeedX6 != -100)
                    {
                        defaultOverrideSpeedX6 = gv.mod.currentArea.overrideSpeedX6;
                    }
                    if (gv.mod.currentArea.overrideSpeedY6 != -100)
                    {
                        defaultOverrideSpeedY6 = gv.mod.currentArea.overrideSpeedY6;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit6 != -100)
                    {
                        defaultOverrideDelayLimit6 = gv.mod.currentArea.overrideDelayLimit6;
                    }

                    gv.mod.currentArea.overrideDelayCounter6++;
                    if (gv.mod.currentArea.overrideDelayCounter6 > defaultOverrideDelayLimit6)
                    {

                        gv.mod.currentArea.overrideDelayCounter6 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX6 = ((0.25f * directional) + (decider * defaultOverrideSpeedX6 * 0.5f)) * (0.5f);

                        //for y
                        rollRandom = gv.sf.RandInt(100);
                        rollRandom2 = gv.sf.RandInt(2);
                        directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedY6 = ((0.25f * directional) + (decider * defaultOverrideSpeedY6 * 0.5f)) * (0.5f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride6 == "fog")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX6 = 1.0f;
                    float defaultOverrideSpeedY6 = 1.0f;
                    int defaultOverrideDelayLimit6 = 110;
                    string defaultOverrideIsNoScrollSource6 = "True";

                    if (gv.mod.currentArea.overrideIsNoScrollSource6 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource6 = defaultOverrideIsNoScrollSource6;
                    }

                    if (gv.mod.currentArea.overrideSpeedX6 != -100)
                    {
                        defaultOverrideSpeedX6 = gv.mod.currentArea.overrideSpeedX6;
                    }
                    if (gv.mod.currentArea.overrideSpeedY6 != -100)
                    {
                        defaultOverrideSpeedY6 = gv.mod.currentArea.overrideSpeedY6;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit6 != -100)
                    {
                        defaultOverrideDelayLimit6 = gv.mod.currentArea.overrideDelayLimit6;
                    }

                    gv.mod.currentArea.overrideDelayCounter6++;
                    if (gv.mod.currentArea.overrideDelayCounter6 > defaultOverrideDelayLimit6)
                    {

                        gv.mod.currentArea.overrideDelayCounter6 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(100);
                        int directional = 1;
                        if (rollRandom2 >= 50)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedX6 = ((0.25f * directional) + (decider * defaultOverrideSpeedX6 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedX6 = ((0.075f * directional) + (decider * defaultOverrideSpeedX6 * 0.5f)) * (0.09f);

                        //for y
                        int rollRandom3 = gv.sf.RandInt(100);
                        int rollRandom4 = gv.sf.RandInt(100);
                        directional = 1;
                        if (rollRandom4 >= 50)
                        {
                            rollRandom3 = rollRandom3 * -1;
                            directional = -1;
                        }
                        decider = rollRandom3 / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedY6 = ((0.25f * directional) + (decider * defaultOverrideSpeedY6 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY6 = ((0.075f * directional) + (decider * defaultOverrideSpeedY6 * 0.5f)) * (0.09f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride6 == "snow")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX6 = 0.45f;
                    float defaultOverrideSpeedY6 = -0.55f;
                    int defaultOverrideDelayLimit6 = 470;
                    string defaultOverrideIsNoScrollSource6 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource6 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource6 = defaultOverrideIsNoScrollSource6;
                    }


                    if (gv.mod.currentArea.overrideSpeedX6 != -100)
                    {
                        defaultOverrideSpeedX6 = gv.mod.currentArea.overrideSpeedX6;
                    }
                    if (gv.mod.currentArea.overrideSpeedY6 != -100)
                    {
                        defaultOverrideSpeedY6 = gv.mod.currentArea.overrideSpeedY6;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit6 != -100)
                    {
                        defaultOverrideDelayLimit6 = gv.mod.currentArea.overrideDelayLimit6;
                    }

                    gv.mod.currentArea.overrideDelayCounter6++;
                    if (gv.mod.currentArea.overrideDelayCounter6 > defaultOverrideDelayLimit6)
                    {

                        gv.mod.currentArea.overrideDelayCounter6 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX6 = ((0.15f * directional) + (decider * defaultOverrideSpeedX6 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY6 = defaultOverrideSpeedY6;
                    }
                }

                if (gv.mod.currentArea.directionalOverride6 == "rain")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX6 = 0.5f;
                    float defaultOverrideSpeedY6 = -2.8f;
                    int defaultOverrideDelayLimit6 = 100;
                    string defaultOverrideIsNoScrollSource6 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource6 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource6 = defaultOverrideIsNoScrollSource6;
                    }

                    if (gv.mod.currentArea.overrideSpeedX6 != -100)
                    {
                        defaultOverrideSpeedX6 = gv.mod.currentArea.overrideSpeedX6;
                    }
                    if (gv.mod.currentArea.overrideSpeedY6 != -100)
                    {
                        defaultOverrideSpeedY6 = gv.mod.currentArea.overrideSpeedY6;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit6 != -100)
                    {
                        defaultOverrideDelayLimit6 = gv.mod.currentArea.overrideDelayLimit6;
                    }

                    gv.mod.currentArea.overrideDelayCounter6++;
                    if (gv.mod.currentArea.overrideDelayCounter6 > defaultOverrideDelayLimit6)
                    {

                        gv.mod.currentArea.overrideDelayCounter6 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            //rollRandom = rollRandom * -1;
                            //directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX6 = ((0.25f * directional) + (decider * defaultOverrideSpeedX6 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY6 = defaultOverrideSpeedY6;
                    }
                }

                if (gv.mod.currentArea.directionalOverride6 == "linear")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX6 = 1f;
                    float defaultOverrideSpeedY6 = 1f;
                    int defaultOverrideDelayLimit6 = 100;
                    string defaultOverrideIsNoScrollSource6 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource6 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource6 = defaultOverrideIsNoScrollSource6;
                    }

                    if (gv.mod.currentArea.overrideSpeedX6 != -100)
                    {
                        defaultOverrideSpeedX6 = gv.mod.currentArea.overrideSpeedX6;
                    }
                    if (gv.mod.currentArea.overrideSpeedY6 != -100)
                    {
                        defaultOverrideSpeedY6 = gv.mod.currentArea.overrideSpeedY6;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit6 != -100)
                    {
                        defaultOverrideDelayLimit6 = gv.mod.currentArea.overrideDelayLimit6;
                    }
                    gv.mod.currentArea.fullScreenAnimationSpeedX6 = defaultOverrideSpeedX6;
                    gv.mod.currentArea.fullScreenAnimationSpeedY6 = defaultOverrideSpeedY6;
                }


                #endregion

                if (gv.mod.currentArea.fullScreenEffectLayerIsActive6 == true)
                {
                    #region limited cycle animation
                    //check whether we got an effect that is supposed to happen only once in a while
                    if (gv.mod.currentArea.numberOfCyclesPerOccurence6 != 0)
                    {

                        //added speed
                        float speedComponentX = gv.mod.currentArea.fullScreenAnimationSpeedX6;
                        if (speedComponentX < 0)
                        {
                            speedComponentX *= -1;
                        }
                        float speedComponentY = gv.mod.currentArea.fullScreenAnimationSpeedY6;
                        if (speedComponentY < 0)
                        {
                            speedComponentY *= -1;
                        }
                        gv.mod.currentArea.fullScreenAnimationSpeed6 = speedComponentX + speedComponentY;

                        //based on subjective trial and error
                        if ((gv.mod.currentArea.fullScreenAnimationFrameCounter6 > (50f / (gv.mod.currentArea.fullScreenAnimationSpeed6 * gv.mod.allAnimationSpeedMultiplier) - 1)))
                        {
                            gv.mod.currentArea.cycleCounter6 += 1;
                            gv.mod.currentArea.fullScreenAnimationFrameCounter6 = 0;
                        }

                        //a little extra delay added by on intuition how long a cycle takes here
                        if (gv.mod.currentArea.cycleCounter6 >= (gv.mod.currentArea.numberOfCyclesPerOccurence6))
                        {
                            //turn the animation off, in common code's doudate method a chance per turn is rolled for turning on again
                            gv.mod.currentArea.fullScreenEffectLayerIsActive6 = false;
                            //counts how often/long the aniamtion is displayed before stop
                            gv.mod.currentArea.cycleCounter6 = 0;
                            //just keeping track how often render calls have run through
                            gv.mod.currentArea.fullScreenAnimationFrameCounter6 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeCounter6 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeFrameCounter6 = 1;
                        }

                        gv.mod.currentArea.fullScreenAnimationFrameCounter6 += 1;
                    }
                    #endregion

                    //if (gv.mod.currentArea.fullScreenEffectLayerIsActive6 == true)
                    //{
                    float fullScreenEffectOpacity = 1f;
                    #region opacity code
                    if (gv.mod.currentArea.useCyclicFade6)
                    {
                        //fade in within first cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter6 == 0) && (gv.mod.currentArea.numberOfCyclesPerOccurence6 != 0))
                        {
                            fullScreenEffectOpacity = 1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed6 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter6);
                        }

                        //fade out within last cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter6 == (gv.mod.currentArea.numberOfCyclesPerOccurence6 - 1)) && (gv.mod.currentArea.numberOfCyclesPerOccurence6 != 0))
                        {
                            fullScreenEffectOpacity = 1f - (1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed6 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter6));
                        }
                    }
                    if (gv.mod.fullScreenEffectOpacityWeather != 1)
                    {
                        fullScreenEffectOpacity = gv.mod.fullScreenEffectOpacityWeather;
                    }
                    #endregion

                    //use weather system per area specific later on
                    //utilizing weather type defined by area weather settings
                    //add check for square specific punch hole that prevents drawing weather, e.g. house inside or spaceship interior

                    #region only for shape changing animation
                    if (gv.mod.currentArea.isChanging6)
                    {
                        gv.mod.currentArea.changeCounter6 += (1 * gv.mod.allAnimationSpeedMultiplier);
                        if (gv.mod.currentArea.changeCounter6 > gv.mod.currentArea.changeLimit6)
                        {
                            gv.mod.currentArea.changeCounter6 = 0;
                            gv.mod.currentArea.changeFrameCounter6 += 1;
                            if (gv.mod.currentArea.changeFrameCounter6 > gv.mod.currentArea.changeNumberOfFrames6)
                            {
                                gv.mod.currentArea.changeFrameCounter6 = 1;
                            }
                        }
                        fullScreenEffect6 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName6 + gv.mod.currentArea.changeFrameCounter6.ToString());
                    }
                    #endregion

                    else
                    {
                        fullScreenEffect6 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName6);
                    }

                    #region handle framecounter
                    //assuming a square shaped source here
                    float sizeOfWholeSource = fullScreenEffect6.PixelSize.Width;

                    //reading the frames moved and added up in the last seconds
                    float pixShiftOnThisFrameX = gv.mod.currentArea.fullScreenAnimationFrameCounterX6;
                    float pixShiftOnThisFrameY = gv.mod.currentArea.fullScreenAnimationFrameCounterY6;

                    //increase by this call's movement
                    pixShiftOnThisFrameX += (gv.mod.currentArea.fullScreenAnimationSpeedX6 * gv.mod.allAnimationSpeedMultiplier);
                    pixShiftOnThisFrameY += (gv.mod.currentArea.fullScreenAnimationSpeedY6 * gv.mod.allAnimationSpeedMultiplier);

                    if (gv.mod.currentArea.overrideIsNoScrollSource6 == "True")
                    {
                        if (pixShiftOnThisFrameX > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameX = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedX6 *= -1;
                        }

                        if (pixShiftOnThisFrameY > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameY = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY6 *= -1;
                        }

                        if (pixShiftOnThisFrameX < 0)
                        {
                            pixShiftOnThisFrameX = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedX6 *= -1;
                        }

                        if (pixShiftOnThisFrameY < 0)
                        {
                            pixShiftOnThisFrameY = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedY6 *= -1;
                        }
                    }

                    //reset it in case it grwos too large (note: just to avoid an overflow in the far future)
                    //the actual reset happens later below
                    if (pixShiftOnThisFrameX >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameX <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    gv.mod.currentArea.fullScreenAnimationFrameCounterX6 = pixShiftOnThisFrameX;
                    gv.mod.currentArea.fullScreenAnimationFrameCounterY6 = pixShiftOnThisFrameY;
                    #endregion

                    #region iterate through the dst tiles
                    for (int x = minX; x < maxX; x++)
                    {
                        for (int y = minY; y < maxY; y++)
                        {
                            Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];

                            //each tile can block the effects run on the six effect channels, each e.g. simualting shelter from rain
                            if (!tile.blockFullScreenEffectLayer6)
                            {
                                int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                                int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;

                                float scalerX = gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Width / 100f;
                                float scalerY = gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Height / 100f;
                                float brX = gv.squareSize * scalerX;
                                float brY = gv.squareSize * scalerY;

                                float numberOfPictureParts = gv.playerOffset * 2 + 1;

                                #region is effect contained inside borders or always centered on party?
                                //code section for handling borders of the area
                                int modX = x;
                                int modY = y;
                                int modMinX = minX;
                                int modMinY = minY;

                                if (gv.mod.currentArea.containEffectInsideAreaBorders6)
                                {
                                    //code for for always keeping the effect contained in the area box, break center on player near map border
                                    if ((mod.PlayerLocationX + 4) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 1;
                                    }
                                    if ((mod.PlayerLocationX + 3) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 2;
                                    }
                                    if ((mod.PlayerLocationX + 2) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 3;
                                    }
                                    if ((mod.PlayerLocationX + 1) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 4;
                                    }


                                    if ((mod.PlayerLocationY + 4) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 1;
                                    }
                                    if ((mod.PlayerLocationY + 3) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 2;
                                    }
                                    if ((mod.PlayerLocationY + 2) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 3;
                                    }
                                    if ((mod.PlayerLocationY + 1) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 4;
                                    }
                                }

                                else
                                {
                                    //code for always centering the effect on player, even near map border (e.g. light source carried by party)
                                    if ((mod.PlayerLocationX - 3) == 0)
                                    {
                                        modMinX = -1;
                                    }
                                    if ((mod.PlayerLocationX - 2) == 0)
                                    {
                                        modMinX = -2;
                                    }
                                    if ((mod.PlayerLocationX - 1) == 0)
                                    {
                                        modMinX = -3;
                                    }
                                    if ((mod.PlayerLocationX) == 0)
                                    {
                                        modMinX = -4;
                                    }


                                    if ((mod.PlayerLocationY - 3) == 0)
                                    {
                                        modMinY = -1;
                                    }
                                    if ((mod.PlayerLocationY - 2) == 0)
                                    {
                                        modMinY = -2;
                                    }
                                    if ((mod.PlayerLocationY - 1) == 0)
                                    {
                                        modMinY = -3;
                                    }
                                    if ((mod.PlayerLocationY) == 0)
                                    {
                                        modMinY = -4;
                                    }
                                }
                                #endregion

                                //get the correct chunk on source
                                //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                float floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                float floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                #region handle border situations on source (bottom and right)     
                                //the following four sections help to set the top left x,y of our square incase we ae close to bottom or right border of source

                                if (gv.mod.currentArea.overrideIsNoScrollSource6 == "True")
                                {
                                    sizeOfWholeSource = 0.5f * sizeOfWholeSource;
                                    //get the correct chunk on source
                                    //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                    floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                    floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                    float smallSourceChunk = sizeOfWholeSource / numberOfPictureParts;
                                    sizeOfWholeSource = 2.0f * sizeOfWholeSource;
                                    /*
                                    //stop at border
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = 0;
                                        
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordY >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordY = sizeOfWholeSource - smallSourceChunk - 1;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = 0;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordX = sizeOfWholeSource - smallSourceChunk - 1;
                                    }
                                    */

                                }

                                else
                                {

                                    //leave source in negative direction (vertical)
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = (floatSourceChunkCoordY * -1f);
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                        floatSourceChunkCoordY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    }

                                    //leave source in positive direction (vertical)
                                    if (floatSourceChunkCoordY >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                    }

                                    //leave source in negative direction (horizontal)
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = (floatSourceChunkCoordX * -1f);
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                        floatSourceChunkCoordX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    }

                                    //leave source in positive direction (horizontal)
                                    if (floatSourceChunkCoordX >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                    }
                                }
                                #endregion

                                #region handle the four different draw situations, based on position of chunk on source
                                //next task is to actaully draw up to four pieces of  square source to one target dst
                                //let's go through the differdnt situations that can occur

                                #region Situation 1 (complex, 4 to 1)
                                //Situation 1 (most complex): touching four source squares, we are in the far low right corner
                                //there will be two more 2 source square situations, one for x and one for y direction
                                //also there's of course the standard situation that we just need one coherent source
                                if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && ((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource6 != "True"))
                                {

                                    //need to use parts four source chunks from four different source squares and draw them onto the dst square

                                    //first: top left corner
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect6, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: top right corner
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * dstScalerX)), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect6, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //third: bottom left corner
                                    float oldHeight = (brY * dstScalerY);
                                    availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldHeight, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect6, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //fourth: bottom right corner
                                    oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY + oldHeight, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect6, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    continue;

                                }
                                #endregion

                                #region Situation 2 (2 to 1, x near border)
                                //Situation 2: only x is near right border, y is high/small enough
                                else if (((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource6 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: left hand side
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect6, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: right hand side
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * (dstScalerX))), (brY * (dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect6, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;

                                }
                                #endregion

                                #region Situation 3 (2 to 1, y near border)
                                //Situation 3: only y is near bottom border, x is left/small enough WIP
                                else if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource6 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: top square
                                    float availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect6, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: bottom square
                                    float oldLength = 0;
                                    oldLength = (float)(brY * dstScalerY);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldLength, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect6, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;
                                }
                                #endregion

                                #region Situation 4 (default, neither x or y near border)
                                //Situation 4: the default situation, x and y are sufficiently distant from bottom and right border
                                else
                                {

                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;
                                    float sizeOfSourceChunk2 = 0;
                                    if (gv.mod.currentArea.overrideIsNoScrollSource6 != "True")
                                    {
                                        sizeOfSourceChunk2 = (sizeOfWholeSource / numberOfPictureParts);
                                    }
                                    else
                                    {
                                        sizeOfSourceChunk2 = ((sizeOfWholeSource * 0.5f) / numberOfPictureParts);
                                    }

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, sizeOfSourceChunk2, sizeOfSourceChunk2);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                                        gv.DrawBitmap(fullScreenEffect6, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                }
                                #endregion

                            }
                        }
                    }
                }
                #endregion

            }
            #endregion
            #endregion
            #region Draw full screen layer 7
            //there will be six layers for effects usable by either the top (eg.sky) or bottom (eg sea) full scren draw methods 
            //I would guess that combined about 60.000 pix are ok for performance,so like 6 x 100x100 source bitmaps or fewer, but with higer resolution
            //that's for my laptop

            //check whether the layer7 is activated and set to top level
            if ((gv.mod.currentArea.useFullScreenEffectLayer7) && (gv.mod.currentArea.FullScreenEffectLayer7IsTop))
            {

                gv.cc.DisposeOfBitmap(ref fullScreenEffect7);

                //these replace the normal, linear scroll in direction of vector x,y pattern
                //in the toolset different values for overrides can be set than the defaults they come with
                //this way an author can make use of the non-linear algorithms with different input parameters to bend their shape
                //basically it works like the override would call scripts whose paratmeters can be set by the authors
                //just with the added comfort that teh paarmeters ahve own fields in the toolset and descritive text
                //also when just letting all override values sit at zero,the override will use its own defaults, working out of the box like e.g. snow

                #region override movement patterns

                if (gv.mod.currentArea.directionalOverride7 == "randStraight")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX7 = 0.5f;
                    float defaultOverrideSpeedY7 = 0.5f;
                    int defaultOverrideDelayLimit7 = 15;
                    string defaultOverrideIsNoScrollSource7 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource7 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource7 = defaultOverrideIsNoScrollSource7;
                    }

                    if (gv.mod.currentArea.overrideSpeedX7 != -100)
                    {
                        defaultOverrideSpeedX7 = gv.mod.currentArea.overrideSpeedX7;
                    }
                    if (gv.mod.currentArea.overrideSpeedY7 != -100)
                    {
                        defaultOverrideSpeedY7 = gv.mod.currentArea.overrideSpeedY7;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit7 != -100)
                    {
                        defaultOverrideDelayLimit7 = gv.mod.currentArea.overrideDelayLimit7;
                    }

                    gv.mod.currentArea.overrideDelayCounter7++;
                    if (gv.mod.currentArea.overrideDelayCounter7 > defaultOverrideDelayLimit7)
                    {

                        gv.mod.currentArea.overrideDelayCounter7 = 0;
                        int rollRandom = gv.sf.RandInt(8);
                        //right
                        if (rollRandom == 1)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX7 = defaultOverrideSpeedX7;
                            gv.mod.currentArea.fullScreenAnimationSpeedY7 = 0.0f;
                        }
                        //left
                        if (rollRandom == 2)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX7 = -defaultOverrideSpeedX7;
                            gv.mod.currentArea.fullScreenAnimationSpeedY7 = 0.0f;
                        }
                        //up
                        if (rollRandom == 3)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX7 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY7 = defaultOverrideSpeedY7;
                        }
                        //down
                        if (rollRandom == 4)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX7 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY7 = -defaultOverrideSpeedY7;
                        }
                        //up right
                        if (rollRandom == 5)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX7 = defaultOverrideSpeedX7;
                            gv.mod.currentArea.fullScreenAnimationSpeedY7 = defaultOverrideSpeedY7;
                        }
                        //upleft
                        if (rollRandom == 6)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX7 = -defaultOverrideSpeedX7;
                            gv.mod.currentArea.fullScreenAnimationSpeedY7 = defaultOverrideSpeedY7;
                        }
                        //downright
                        if (rollRandom == 7)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX7 = defaultOverrideSpeedX7;
                            gv.mod.currentArea.fullScreenAnimationSpeedY7 = -defaultOverrideSpeedY7;
                        }
                        //downleft
                        if (rollRandom == 8)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX7 = -defaultOverrideSpeedX7;
                            gv.mod.currentArea.fullScreenAnimationSpeedY7 = -defaultOverrideSpeedY7;
                        }
                    }
                }

                if (gv.mod.currentArea.directionalOverride7 == "clouds")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX7 = 0.5f;
                    float defaultOverrideSpeedY7 = 0.5f;
                    int defaultOverrideDelayLimit7 = 750;
                    string defaultOverrideIsNoScrollSource7 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource7 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource7 = defaultOverrideIsNoScrollSource7;
                    }

                    if (gv.mod.currentArea.overrideSpeedX7 != -100)
                    {
                        defaultOverrideSpeedX7 = gv.mod.currentArea.overrideSpeedX7;
                    }
                    if (gv.mod.currentArea.overrideSpeedY7 != -100)
                    {
                        defaultOverrideSpeedY7 = gv.mod.currentArea.overrideSpeedY7;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit7 != -100)
                    {
                        defaultOverrideDelayLimit7 = gv.mod.currentArea.overrideDelayLimit7;
                    }

                    gv.mod.currentArea.overrideDelayCounter7++;
                    if (gv.mod.currentArea.overrideDelayCounter7 > defaultOverrideDelayLimit7)
                    {

                        gv.mod.currentArea.overrideDelayCounter7 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX7 = ((0.25f * directional) + (decider * defaultOverrideSpeedX7 * 0.5f)) * (0.5f);

                        //for y
                        rollRandom = gv.sf.RandInt(100);
                        rollRandom2 = gv.sf.RandInt(2);
                        directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedY7 = ((0.25f * directional) + (decider * defaultOverrideSpeedY7 * 0.5f)) * (0.5f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride7 == "fog")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX7 = 1.0f;
                    float defaultOverrideSpeedY7 = 1.0f;
                    int defaultOverrideDelayLimit7 = 110;
                    string defaultOverrideIsNoScrollSource7 = "True";

                    if (gv.mod.currentArea.overrideIsNoScrollSource7 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource7 = defaultOverrideIsNoScrollSource7;
                    }

                    if (gv.mod.currentArea.overrideSpeedX7 != -100)
                    {
                        defaultOverrideSpeedX7 = gv.mod.currentArea.overrideSpeedX7;
                    }
                    if (gv.mod.currentArea.overrideSpeedY7 != -100)
                    {
                        defaultOverrideSpeedY7 = gv.mod.currentArea.overrideSpeedY7;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit7 != -100)
                    {
                        defaultOverrideDelayLimit7 = gv.mod.currentArea.overrideDelayLimit7;
                    }

                    gv.mod.currentArea.overrideDelayCounter7++;
                    if (gv.mod.currentArea.overrideDelayCounter7 > defaultOverrideDelayLimit7)
                    {

                        gv.mod.currentArea.overrideDelayCounter7 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(100);
                        int directional = 1;
                        if (rollRandom2 >= 50)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedX7 = ((0.25f * directional) + (decider * defaultOverrideSpeedX7 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedX7 = ((0.075f * directional) + (decider * defaultOverrideSpeedX7 * 0.5f)) * (0.09f);

                        //for y
                        int rollRandom3 = gv.sf.RandInt(100);
                        int rollRandom4 = gv.sf.RandInt(100);
                        directional = 1;
                        if (rollRandom4 >= 50)
                        {
                            rollRandom3 = rollRandom3 * -1;
                            directional = -1;
                        }
                        decider = rollRandom3 / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedY7 = ((0.25f * directional) + (decider * defaultOverrideSpeedY7 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY7 = ((0.075f * directional) + (decider * defaultOverrideSpeedY7 * 0.5f)) * (0.09f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride7 == "snow")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX7 = 0.45f;
                    float defaultOverrideSpeedY7 = -0.55f;
                    int defaultOverrideDelayLimit7 = 470;
                    string defaultOverrideIsNoScrollSource7 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource7 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource7 = defaultOverrideIsNoScrollSource7;
                    }


                    if (gv.mod.currentArea.overrideSpeedX7 != -100)
                    {
                        defaultOverrideSpeedX7 = gv.mod.currentArea.overrideSpeedX7;
                    }
                    if (gv.mod.currentArea.overrideSpeedY7 != -100)
                    {
                        defaultOverrideSpeedY7 = gv.mod.currentArea.overrideSpeedY7;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit7 != -100)
                    {
                        defaultOverrideDelayLimit7 = gv.mod.currentArea.overrideDelayLimit7;
                    }

                    gv.mod.currentArea.overrideDelayCounter7++;
                    if (gv.mod.currentArea.overrideDelayCounter7 > defaultOverrideDelayLimit7)
                    {

                        gv.mod.currentArea.overrideDelayCounter7 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX7 = ((0.15f * directional) + (decider * defaultOverrideSpeedX7 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY7 = defaultOverrideSpeedY7;
                    }
                }

                if (gv.mod.currentArea.directionalOverride7 == "rain")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX7 = 0.5f;
                    float defaultOverrideSpeedY7 = -2.8f;
                    int defaultOverrideDelayLimit7 = 100;
                    string defaultOverrideIsNoScrollSource7 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource7 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource7 = defaultOverrideIsNoScrollSource7;
                    }

                    if (gv.mod.currentArea.overrideSpeedX7 != -100)
                    {
                        defaultOverrideSpeedX7 = gv.mod.currentArea.overrideSpeedX7;
                    }
                    if (gv.mod.currentArea.overrideSpeedY7 != -100)
                    {
                        defaultOverrideSpeedY7 = gv.mod.currentArea.overrideSpeedY7;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit7 != -100)
                    {
                        defaultOverrideDelayLimit7 = gv.mod.currentArea.overrideDelayLimit7;
                    }

                    gv.mod.currentArea.overrideDelayCounter7++;
                    if (gv.mod.currentArea.overrideDelayCounter7 > defaultOverrideDelayLimit7)
                    {

                        gv.mod.currentArea.overrideDelayCounter7 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            //rollRandom = rollRandom * -1;
                            //directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX7 = ((0.25f * directional) + (decider * defaultOverrideSpeedX7 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY7 = defaultOverrideSpeedY7;
                    }
                }

                if (gv.mod.currentArea.directionalOverride7 == "linear")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX7 = 1f;
                    float defaultOverrideSpeedY7 = 1f;
                    int defaultOverrideDelayLimit7 = 100;
                    string defaultOverrideIsNoScrollSource7 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource7 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource7 = defaultOverrideIsNoScrollSource7;
                    }

                    if (gv.mod.currentArea.overrideSpeedX7 != -100)
                    {
                        defaultOverrideSpeedX7 = gv.mod.currentArea.overrideSpeedX7;
                    }
                    if (gv.mod.currentArea.overrideSpeedY7 != -100)
                    {
                        defaultOverrideSpeedY7 = gv.mod.currentArea.overrideSpeedY7;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit7 != -100)
                    {
                        defaultOverrideDelayLimit7 = gv.mod.currentArea.overrideDelayLimit7;
                    }
                    gv.mod.currentArea.fullScreenAnimationSpeedX7 = defaultOverrideSpeedX7;
                    gv.mod.currentArea.fullScreenAnimationSpeedY7 = defaultOverrideSpeedY7;
                }


                #endregion

                if (gv.mod.currentArea.fullScreenEffectLayerIsActive7 == true)
                {
                    #region limited cycle animation
                    //check whether we got an effect that is supposed to happen only once in a while
                    if (gv.mod.currentArea.numberOfCyclesPerOccurence7 != 0)
                    {

                        //added speed
                        float speedComponentX = gv.mod.currentArea.fullScreenAnimationSpeedX7;
                        if (speedComponentX < 0)
                        {
                            speedComponentX *= -1;
                        }
                        float speedComponentY = gv.mod.currentArea.fullScreenAnimationSpeedY7;
                        if (speedComponentY < 0)
                        {
                            speedComponentY *= -1;
                        }
                        gv.mod.currentArea.fullScreenAnimationSpeed7 = speedComponentX + speedComponentY;

                        //based on subjective trial and error
                        if ((gv.mod.currentArea.fullScreenAnimationFrameCounter7 > (50f / (gv.mod.currentArea.fullScreenAnimationSpeed7 * gv.mod.allAnimationSpeedMultiplier) - 1)))
                        {
                            gv.mod.currentArea.cycleCounter7 += 1;
                            gv.mod.currentArea.fullScreenAnimationFrameCounter7 = 0;
                        }

                        //a little extra delay added by on intuition how long a cycle takes here
                        if (gv.mod.currentArea.cycleCounter7 >= (gv.mod.currentArea.numberOfCyclesPerOccurence7))
                        {
                            //turn the animation off, in common code's doudate method a chance per turn is rolled for turning on again
                            gv.mod.currentArea.fullScreenEffectLayerIsActive7 = false;
                            //counts how often/long the aniamtion is displayed before stop
                            gv.mod.currentArea.cycleCounter7 = 0;
                            //just keeping track how often render calls have run through
                            gv.mod.currentArea.fullScreenAnimationFrameCounter7 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeCounter7 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeFrameCounter7 = 1;
                        }

                        gv.mod.currentArea.fullScreenAnimationFrameCounter7 += 1;
                    }
                    #endregion

                    //if (gv.mod.currentArea.fullScreenEffectLayerIsActive7 == true)
                    //{
                    float fullScreenEffectOpacity = 1f;
                    #region opacity code
                    if (gv.mod.currentArea.useCyclicFade7)
                    {
                        //fade in within first cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter7 == 0) && (gv.mod.currentArea.numberOfCyclesPerOccurence7 != 0))
                        {
                            fullScreenEffectOpacity = 1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed7 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter7);
                        }

                        //fade out within last cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter7 == (gv.mod.currentArea.numberOfCyclesPerOccurence7 - 1)) && (gv.mod.currentArea.numberOfCyclesPerOccurence7 != 0))
                        {
                            fullScreenEffectOpacity = 1f - (1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed7 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter7));
                        }
                    }
                    if (gv.mod.fullScreenEffectOpacityWeather != 1)
                    {
                        fullScreenEffectOpacity = gv.mod.fullScreenEffectOpacityWeather;
                    }
                    #endregion

                    //use weather system per area specific later on
                    //utilizing weather type defined by area weather settings
                    //add check for square specific punch hole that prevents drawing weather, e.g. house inside or spaceship interior

                    #region only for shape changing animation
                    if (gv.mod.currentArea.isChanging7)
                    {
                        gv.mod.currentArea.changeCounter7 += (1 * gv.mod.allAnimationSpeedMultiplier);
                        if (gv.mod.currentArea.changeCounter7 > gv.mod.currentArea.changeLimit7)
                        {
                            gv.mod.currentArea.changeCounter7 = 0;
                            gv.mod.currentArea.changeFrameCounter7 += 1;
                            if (gv.mod.currentArea.changeFrameCounter7 > gv.mod.currentArea.changeNumberOfFrames7)
                            {
                                gv.mod.currentArea.changeFrameCounter7 = 1;
                            }
                        }
                        fullScreenEffect7 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName7 + gv.mod.currentArea.changeFrameCounter7.ToString());
                    }
                    #endregion

                    else
                    {
                        fullScreenEffect7 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName7);
                    }

                    #region handle framecounter
                    //assuming a square shaped source here
                    float sizeOfWholeSource = fullScreenEffect7.PixelSize.Width;

                    //reading the frames moved and added up in the last seconds
                    float pixShiftOnThisFrameX = gv.mod.currentArea.fullScreenAnimationFrameCounterX7;
                    float pixShiftOnThisFrameY = gv.mod.currentArea.fullScreenAnimationFrameCounterY7;

                    //increase by this call's movement
                    pixShiftOnThisFrameX += (gv.mod.currentArea.fullScreenAnimationSpeedX7 * gv.mod.allAnimationSpeedMultiplier);
                    pixShiftOnThisFrameY += (gv.mod.currentArea.fullScreenAnimationSpeedY7 * gv.mod.allAnimationSpeedMultiplier);

                    if (gv.mod.currentArea.overrideIsNoScrollSource7 == "True")
                    {
                        if (pixShiftOnThisFrameX > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameX = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedX7 *= -1;
                        }

                        if (pixShiftOnThisFrameY > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameY = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY7 *= -1;
                        }

                        if (pixShiftOnThisFrameX < 0)
                        {
                            pixShiftOnThisFrameX = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedX7 *= -1;
                        }

                        if (pixShiftOnThisFrameY < 0)
                        {
                            pixShiftOnThisFrameY = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedY7 *= -1;
                        }
                    }

                    //reset it in case it grwos too large (note: just to avoid an overflow in the far future)
                    //the actual reset happens later below
                    if (pixShiftOnThisFrameX >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameX <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    gv.mod.currentArea.fullScreenAnimationFrameCounterX7 = pixShiftOnThisFrameX;
                    gv.mod.currentArea.fullScreenAnimationFrameCounterY7 = pixShiftOnThisFrameY;
                    #endregion

                    #region iterate through the dst tiles
                    for (int x = minX; x < maxX; x++)
                    {
                        for (int y = minY; y < maxY; y++)
                        {
                            Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];

                            //each tile can block the effects run on the six effect channels, each e.g. simualting shelter from rain
                            if (!tile.blockFullScreenEffectLayer7)
                            {
                                int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                                int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;

                                float scalerX = gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Width / 100f;
                                float scalerY = gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Height / 100f;
                                float brX = gv.squareSize * scalerX;
                                float brY = gv.squareSize * scalerY;

                                float numberOfPictureParts = gv.playerOffset * 2 + 1;

                                #region is effect contained inside borders or always centered on party?
                                //code section for handling borders of the area
                                int modX = x;
                                int modY = y;
                                int modMinX = minX;
                                int modMinY = minY;

                                if (gv.mod.currentArea.containEffectInsideAreaBorders7)
                                {
                                    //code for for always keeping the effect contained in the area box, break center on player near map border
                                    if ((mod.PlayerLocationX + 4) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 1;
                                    }
                                    if ((mod.PlayerLocationX + 3) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 2;
                                    }
                                    if ((mod.PlayerLocationX + 2) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 3;
                                    }
                                    if ((mod.PlayerLocationX + 1) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 4;
                                    }


                                    if ((mod.PlayerLocationY + 4) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 1;
                                    }
                                    if ((mod.PlayerLocationY + 3) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 2;
                                    }
                                    if ((mod.PlayerLocationY + 2) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 3;
                                    }
                                    if ((mod.PlayerLocationY + 1) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 4;
                                    }
                                }

                                else
                                {
                                    //code for always centering the effect on player, even near map border (e.g. light source carried by party)
                                    if ((mod.PlayerLocationX - 3) == 0)
                                    {
                                        modMinX = -1;
                                    }
                                    if ((mod.PlayerLocationX - 2) == 0)
                                    {
                                        modMinX = -2;
                                    }
                                    if ((mod.PlayerLocationX - 1) == 0)
                                    {
                                        modMinX = -3;
                                    }
                                    if ((mod.PlayerLocationX) == 0)
                                    {
                                        modMinX = -4;
                                    }


                                    if ((mod.PlayerLocationY - 3) == 0)
                                    {
                                        modMinY = -1;
                                    }
                                    if ((mod.PlayerLocationY - 2) == 0)
                                    {
                                        modMinY = -2;
                                    }
                                    if ((mod.PlayerLocationY - 1) == 0)
                                    {
                                        modMinY = -3;
                                    }
                                    if ((mod.PlayerLocationY) == 0)
                                    {
                                        modMinY = -4;
                                    }
                                }
                                #endregion

                                //get the correct chunk on source
                                //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                float floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                float floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                #region handle border situations on source (bottom and right)     
                                //the following four sections help to set the top left x,y of our square incase we ae close to bottom or right border of source

                                if (gv.mod.currentArea.overrideIsNoScrollSource7 == "True")
                                {
                                    sizeOfWholeSource = 0.5f * sizeOfWholeSource;
                                    //get the correct chunk on source
                                    //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                    floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                    floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                    float smallSourceChunk = sizeOfWholeSource / numberOfPictureParts;
                                    sizeOfWholeSource = 2.0f * sizeOfWholeSource;
                                    /*
                                    //stop at border
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = 0;
                                        
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordY >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordY = sizeOfWholeSource - smallSourceChunk - 1;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = 0;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordX = sizeOfWholeSource - smallSourceChunk - 1;
                                    }
                                    */

                                }

                                else
                                {

                                    //leave source in negative direction (vertical)
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = (floatSourceChunkCoordY * -1f);
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                        floatSourceChunkCoordY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    }

                                    //leave source in positive direction (vertical)
                                    if (floatSourceChunkCoordY >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                    }

                                    //leave source in negative direction (horizontal)
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = (floatSourceChunkCoordX * -1f);
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                        floatSourceChunkCoordX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    }

                                    //leave source in positive direction (horizontal)
                                    if (floatSourceChunkCoordX >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                    }
                                }
                                #endregion

                                #region handle the four different draw situations, based on position of chunk on source
                                //next task is to actaully draw up to four pieces of  square source to one target dst
                                //let's go through the differdnt situations that can occur

                                #region Situation 1 (complex, 4 to 1)
                                //Situation 1 (most complex): touching four source squares, we are in the far low right corner
                                //there will be two more 2 source square situations, one for x and one for y direction
                                //also there's of course the standard situation that we just need one coherent source
                                if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && ((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource7 != "True"))
                                {

                                    //need to use parts four source chunks from four different source squares and draw them onto the dst square

                                    //first: top left corner
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect7, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: top right corner
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * dstScalerX)), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect7, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //third: bottom left corner
                                    float oldHeight = (brY * dstScalerY);
                                    availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldHeight, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect7, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //fourth: bottom right corner
                                    oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY + oldHeight, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect7, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    continue;

                                }
                                #endregion

                                #region Situation 2 (2 to 1, x near border)
                                //Situation 2: only x is near right border, y is high/small enough
                                else if (((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource7 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: left hand side
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect7, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: right hand side
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * (dstScalerX))), (brY * (dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect7, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;

                                }
                                #endregion

                                #region Situation 3 (2 to 1, y near border)
                                //Situation 3: only y is near bottom border, x is left/small enough WIP
                                else if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource7 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: top square
                                    float availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect7, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: bottom square
                                    float oldLength = 0;
                                    oldLength = (float)(brY * dstScalerY);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldLength, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect7, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;
                                }
                                #endregion

                                #region Situation 4 (default, neither x or y near border)
                                //Situation 4: the default situation, x and y are sufficiently distant from bottom and right border
                                else
                                {

                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;
                                    float sizeOfSourceChunk2 = 0;
                                    if (gv.mod.currentArea.overrideIsNoScrollSource7 != "True")
                                    {
                                        sizeOfSourceChunk2 = (sizeOfWholeSource / numberOfPictureParts);
                                    }
                                    else
                                    {
                                        sizeOfSourceChunk2 = ((sizeOfWholeSource * 0.5f) / numberOfPictureParts);
                                    }

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, sizeOfSourceChunk2, sizeOfSourceChunk2);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                                        gv.DrawBitmap(fullScreenEffect7, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                }
                                #endregion

                            }
                        }
                    }
                }
                #endregion

            }
            #endregion
            #endregion
            #region Draw full screen layer 8
            //there will be six layers for effects usable by either the top (eg.sky) or bottom (eg sea) full scren draw methods 
            //I would guess that combined about 60.000 pix are ok for performance,so like 6 x 100X800 source bitmaps or fewer, but with higer resolution
            //that's for my laptop

            //check whether the layer8 is activated and set to top level
            if ((gv.mod.currentArea.useFullScreenEffectLayer8) && (gv.mod.currentArea.FullScreenEffectLayer8IsTop))
            {

                gv.cc.DisposeOfBitmap(ref fullScreenEffect8);

                //these replace the normal, linear scroll in direction of vector x,y pattern
                //in the toolset different values for overrides can be set than the defaults they come with
                //this way an author can make use of the non-linear algorithms with different input parameters to bend their shape
                //basically it works like the override would call scripts whose paratmeters can be set by the authors
                //just with the added comfort that teh paarmeters ahve own fields in the toolset and descritive text
                //also when just letting all override values sit at zero,the override will use its own defaults, working out of the box like e.g. snow

                #region override movement patterns

                if (gv.mod.currentArea.directionalOverride8 == "randStraight")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX8 = 0.5f;
                    float defaultOverrideSpeedY8 = 0.5f;
                    int defaultOverrideDelayLimit8 = 15;
                    string defaultOverrideIsNoScrollSource8 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource8 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource8 = defaultOverrideIsNoScrollSource8;
                    }

                    if (gv.mod.currentArea.overrideSpeedX8 != -100)
                    {
                        defaultOverrideSpeedX8 = gv.mod.currentArea.overrideSpeedX8;
                    }
                    if (gv.mod.currentArea.overrideSpeedY8 != -100)
                    {
                        defaultOverrideSpeedY8 = gv.mod.currentArea.overrideSpeedY8;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit8 != -100)
                    {
                        defaultOverrideDelayLimit8 = gv.mod.currentArea.overrideDelayLimit8;
                    }

                    gv.mod.currentArea.overrideDelayCounter8++;
                    if (gv.mod.currentArea.overrideDelayCounter8 > defaultOverrideDelayLimit8)
                    {

                        gv.mod.currentArea.overrideDelayCounter8 = 0;
                        int rollRandom = gv.sf.RandInt(8);
                        //right
                        if (rollRandom == 1)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX8 = defaultOverrideSpeedX8;
                            gv.mod.currentArea.fullScreenAnimationSpeedY8 = 0.0f;
                        }
                        //left
                        if (rollRandom == 2)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX8 = -defaultOverrideSpeedX8;
                            gv.mod.currentArea.fullScreenAnimationSpeedY8 = 0.0f;
                        }
                        //up
                        if (rollRandom == 3)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX8 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY8 = defaultOverrideSpeedY8;
                        }
                        //down
                        if (rollRandom == 4)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX8 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY8 = -defaultOverrideSpeedY8;
                        }
                        //up right
                        if (rollRandom == 5)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX8 = defaultOverrideSpeedX8;
                            gv.mod.currentArea.fullScreenAnimationSpeedY8 = defaultOverrideSpeedY8;
                        }
                        //upleft
                        if (rollRandom == 6)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX8 = -defaultOverrideSpeedX8;
                            gv.mod.currentArea.fullScreenAnimationSpeedY8 = defaultOverrideSpeedY8;
                        }
                        //downright
                        if (rollRandom == 7)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX8 = defaultOverrideSpeedX8;
                            gv.mod.currentArea.fullScreenAnimationSpeedY8 = -defaultOverrideSpeedY8;
                        }
                        //downleft
                        if (rollRandom == 8)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX8 = -defaultOverrideSpeedX8;
                            gv.mod.currentArea.fullScreenAnimationSpeedY8 = -defaultOverrideSpeedY8;
                        }
                    }
                }

                if (gv.mod.currentArea.directionalOverride8 == "clouds")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX8 = 0.5f;
                    float defaultOverrideSpeedY8 = 0.5f;
                    int defaultOverrideDelayLimit8 = 750;
                    string defaultOverrideIsNoScrollSource8 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource8 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource8 = defaultOverrideIsNoScrollSource8;
                    }

                    if (gv.mod.currentArea.overrideSpeedX8 != -100)
                    {
                        defaultOverrideSpeedX8 = gv.mod.currentArea.overrideSpeedX8;
                    }
                    if (gv.mod.currentArea.overrideSpeedY8 != -100)
                    {
                        defaultOverrideSpeedY8 = gv.mod.currentArea.overrideSpeedY8;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit8 != -100)
                    {
                        defaultOverrideDelayLimit8 = gv.mod.currentArea.overrideDelayLimit8;
                    }

                    gv.mod.currentArea.overrideDelayCounter8++;
                    if (gv.mod.currentArea.overrideDelayCounter8 > defaultOverrideDelayLimit8)
                    {

                        gv.mod.currentArea.overrideDelayCounter8 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX8 = ((0.25f * directional) + (decider * defaultOverrideSpeedX8 * 0.5f)) * (0.5f);

                        //for y
                        rollRandom = gv.sf.RandInt(100);
                        rollRandom2 = gv.sf.RandInt(2);
                        directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedY8 = ((0.25f * directional) + (decider * defaultOverrideSpeedY8 * 0.5f)) * (0.5f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride8 == "fog")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX8 = 1.0f;
                    float defaultOverrideSpeedY8 = 1.0f;
                    int defaultOverrideDelayLimit8 = 110;
                    string defaultOverrideIsNoScrollSource8 = "True";

                    if (gv.mod.currentArea.overrideIsNoScrollSource8 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource8 = defaultOverrideIsNoScrollSource8;
                    }

                    if (gv.mod.currentArea.overrideSpeedX8 != -100)
                    {
                        defaultOverrideSpeedX8 = gv.mod.currentArea.overrideSpeedX8;
                    }
                    if (gv.mod.currentArea.overrideSpeedY8 != -100)
                    {
                        defaultOverrideSpeedY8 = gv.mod.currentArea.overrideSpeedY8;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit8 != -100)
                    {
                        defaultOverrideDelayLimit8 = gv.mod.currentArea.overrideDelayLimit8;
                    }

                    gv.mod.currentArea.overrideDelayCounter8++;
                    if (gv.mod.currentArea.overrideDelayCounter8 > defaultOverrideDelayLimit8)
                    {

                        gv.mod.currentArea.overrideDelayCounter8 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(100);
                        int directional = 1;
                        if (rollRandom2 >= 50)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedX8 = ((0.25f * directional) + (decider * defaultOverrideSpeedX8 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedX8 = ((0.075f * directional) + (decider * defaultOverrideSpeedX8 * 0.5f)) * (0.09f);

                        //for y
                        int rollRandom3 = gv.sf.RandInt(100);
                        int rollRandom4 = gv.sf.RandInt(100);
                        directional = 1;
                        if (rollRandom4 >= 50)
                        {
                            rollRandom3 = rollRandom3 * -1;
                            directional = -1;
                        }
                        decider = rollRandom3 / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedY8 = ((0.25f * directional) + (decider * defaultOverrideSpeedY8 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY8 = ((0.075f * directional) + (decider * defaultOverrideSpeedY8 * 0.5f)) * (0.09f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride8 == "snow")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX8 = 0.45f;
                    float defaultOverrideSpeedY8 = -0.55f;
                    int defaultOverrideDelayLimit8 = 470;
                    string defaultOverrideIsNoScrollSource8 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource8 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource8 = defaultOverrideIsNoScrollSource8;
                    }


                    if (gv.mod.currentArea.overrideSpeedX8 != -100)
                    {
                        defaultOverrideSpeedX8 = gv.mod.currentArea.overrideSpeedX8;
                    }
                    if (gv.mod.currentArea.overrideSpeedY8 != -100)
                    {
                        defaultOverrideSpeedY8 = gv.mod.currentArea.overrideSpeedY8;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit8 != -100)
                    {
                        defaultOverrideDelayLimit8 = gv.mod.currentArea.overrideDelayLimit8;
                    }

                    gv.mod.currentArea.overrideDelayCounter8++;
                    if (gv.mod.currentArea.overrideDelayCounter8 > defaultOverrideDelayLimit8)
                    {

                        gv.mod.currentArea.overrideDelayCounter8 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX8 = ((0.15f * directional) + (decider * defaultOverrideSpeedX8 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY8 = defaultOverrideSpeedY8;
                    }
                }

                if (gv.mod.currentArea.directionalOverride8 == "rain")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX8 = 0.5f;
                    float defaultOverrideSpeedY8 = -2.8f;
                    int defaultOverrideDelayLimit8 = 100;
                    string defaultOverrideIsNoScrollSource8 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource8 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource8 = defaultOverrideIsNoScrollSource8;
                    }

                    if (gv.mod.currentArea.overrideSpeedX8 != -100)
                    {
                        defaultOverrideSpeedX8 = gv.mod.currentArea.overrideSpeedX8;
                    }
                    if (gv.mod.currentArea.overrideSpeedY8 != -100)
                    {
                        defaultOverrideSpeedY8 = gv.mod.currentArea.overrideSpeedY8;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit8 != -100)
                    {
                        defaultOverrideDelayLimit8 = gv.mod.currentArea.overrideDelayLimit8;
                    }

                    gv.mod.currentArea.overrideDelayCounter8++;
                    if (gv.mod.currentArea.overrideDelayCounter8 > defaultOverrideDelayLimit8)
                    {

                        gv.mod.currentArea.overrideDelayCounter8 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            //rollRandom = rollRandom * -1;
                            //directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX8 = ((0.25f * directional) + (decider * defaultOverrideSpeedX8 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY8 = defaultOverrideSpeedY8;
                    }
                }

                if (gv.mod.currentArea.directionalOverride8 == "linear")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX8 = 1f;
                    float defaultOverrideSpeedY8 = 1f;
                    int defaultOverrideDelayLimit8 = 100;
                    string defaultOverrideIsNoScrollSource8 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource8 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource8 = defaultOverrideIsNoScrollSource8;
                    }

                    if (gv.mod.currentArea.overrideSpeedX8 != -100)
                    {
                        defaultOverrideSpeedX8 = gv.mod.currentArea.overrideSpeedX8;
                    }
                    if (gv.mod.currentArea.overrideSpeedY8 != -100)
                    {
                        defaultOverrideSpeedY8 = gv.mod.currentArea.overrideSpeedY8;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit8 != -100)
                    {
                        defaultOverrideDelayLimit8 = gv.mod.currentArea.overrideDelayLimit8;
                    }
                    gv.mod.currentArea.fullScreenAnimationSpeedX8 = defaultOverrideSpeedX8;
                    gv.mod.currentArea.fullScreenAnimationSpeedY8 = defaultOverrideSpeedY8;
                }


                #endregion

                if (gv.mod.currentArea.fullScreenEffectLayerIsActive8 == true)
                {
                    #region limited cycle animation
                    //check whether we got an effect that is supposed to happen only once in a while
                    if (gv.mod.currentArea.numberOfCyclesPerOccurence8 != 0)
                    {

                        //added speed
                        float speedComponentX = gv.mod.currentArea.fullScreenAnimationSpeedX8;
                        if (speedComponentX < 0)
                        {
                            speedComponentX *= -1;
                        }
                        float speedComponentY = gv.mod.currentArea.fullScreenAnimationSpeedY8;
                        if (speedComponentY < 0)
                        {
                            speedComponentY *= -1;
                        }
                        gv.mod.currentArea.fullScreenAnimationSpeed8 = speedComponentX + speedComponentY;

                        //based on subjective trial and error
                        if ((gv.mod.currentArea.fullScreenAnimationFrameCounter8 > (50f / (gv.mod.currentArea.fullScreenAnimationSpeed8 * gv.mod.allAnimationSpeedMultiplier) - 1)))
                        {
                            gv.mod.currentArea.cycleCounter8 += 1;
                            gv.mod.currentArea.fullScreenAnimationFrameCounter8 = 0;
                        }

                        //a little extra delay added by on intuition how long a cycle takes here
                        if (gv.mod.currentArea.cycleCounter8 >= (gv.mod.currentArea.numberOfCyclesPerOccurence8))
                        {
                            //turn the animation off, in common code's doudate method a chance per turn is rolled for turning on again
                            gv.mod.currentArea.fullScreenEffectLayerIsActive8 = false;
                            //counts how often/long the aniamtion is displayed before stop
                            gv.mod.currentArea.cycleCounter8 = 0;
                            //just keeping track how often render calls have run through
                            gv.mod.currentArea.fullScreenAnimationFrameCounter8 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeCounter8 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeFrameCounter8 = 1;
                        }

                        gv.mod.currentArea.fullScreenAnimationFrameCounter8 += 1;
                    }
                    #endregion

                    //if (gv.mod.currentArea.fullScreenEffectLayerIsActive8 == true)
                    //{
                    float fullScreenEffectOpacity = 1f;
                    #region opacity code
                    if (gv.mod.currentArea.useCyclicFade8)
                    {
                        //fade in within first cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter8 == 0) && (gv.mod.currentArea.numberOfCyclesPerOccurence8 != 0))
                        {
                            fullScreenEffectOpacity = 1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed8 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter8);
                        }

                        //fade out within last cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter8 == (gv.mod.currentArea.numberOfCyclesPerOccurence8 - 1)) && (gv.mod.currentArea.numberOfCyclesPerOccurence8 != 0))
                        {
                            fullScreenEffectOpacity = 1f - (1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed8 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter8));
                        }
                    }
                    if (gv.mod.fullScreenEffectOpacityWeather != 1)
                    {
                        fullScreenEffectOpacity = gv.mod.fullScreenEffectOpacityWeather;
                    }
                    #endregion

                    //use weather system per area specific later on
                    //utilizing weather type defined by area weather settings
                    //add check for square specific punch hole that prevents drawing weather, e.g. house inside or spaceship interior

                    #region only for shape changing animation
                    if (gv.mod.currentArea.isChanging8)
                    {
                        gv.mod.currentArea.changeCounter8 += (1 * gv.mod.allAnimationSpeedMultiplier);
                        if (gv.mod.currentArea.changeCounter8 > gv.mod.currentArea.changeLimit8)
                        {
                            gv.mod.currentArea.changeCounter8 = 0;
                            gv.mod.currentArea.changeFrameCounter8 += 1;
                            if (gv.mod.currentArea.changeFrameCounter8 > gv.mod.currentArea.changeNumberOfFrames8)
                            {
                                gv.mod.currentArea.changeFrameCounter8 = 1;
                            }
                        }
                        fullScreenEffect8 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName8 + gv.mod.currentArea.changeFrameCounter8.ToString());
                    }
                    #endregion

                    else
                    {
                        fullScreenEffect8 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName8);
                    }

                    #region handle framecounter
                    //assuming a square shaped source here
                    float sizeOfWholeSource = fullScreenEffect8.PixelSize.Width;

                    //reading the frames moved and added up in the last seconds
                    float pixShiftOnThisFrameX = gv.mod.currentArea.fullScreenAnimationFrameCounterX8;
                    float pixShiftOnThisFrameY = gv.mod.currentArea.fullScreenAnimationFrameCounterY8;

                    //increase by this call's movement
                    pixShiftOnThisFrameX += (gv.mod.currentArea.fullScreenAnimationSpeedX8 * gv.mod.allAnimationSpeedMultiplier);
                    pixShiftOnThisFrameY += (gv.mod.currentArea.fullScreenAnimationSpeedY8 * gv.mod.allAnimationSpeedMultiplier);

                    if (gv.mod.currentArea.overrideIsNoScrollSource8 == "True")
                    {
                        if (pixShiftOnThisFrameX > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameX = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedX8 *= -1;
                        }

                        if (pixShiftOnThisFrameY > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameY = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY8 *= -1;
                        }

                        if (pixShiftOnThisFrameX < 0)
                        {
                            pixShiftOnThisFrameX = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedX8 *= -1;
                        }

                        if (pixShiftOnThisFrameY < 0)
                        {
                            pixShiftOnThisFrameY = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedY8 *= -1;
                        }
                    }

                    //reset it in case it grwos too large (note: just to avoid an overflow in the far future)
                    //the actual reset happens later below
                    if (pixShiftOnThisFrameX >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameX <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    gv.mod.currentArea.fullScreenAnimationFrameCounterX8 = pixShiftOnThisFrameX;
                    gv.mod.currentArea.fullScreenAnimationFrameCounterY8 = pixShiftOnThisFrameY;
                    #endregion

                    #region iterate through the dst tiles
                    for (int x = minX; x < maxX; x++)
                    {
                        for (int y = minY; y < maxY; y++)
                        {
                            Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];

                            //each tile can block the effects run on the six effect channels, each e.g. simualting shelter from rain
                            if (!tile.blockFullScreenEffectLayer8)
                            {
                                int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                                int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;

                                float scalerX = gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Width / 100f;
                                float scalerY = gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Height / 100f;
                                float brX = gv.squareSize * scalerX;
                                float brY = gv.squareSize * scalerY;

                                float numberOfPictureParts = gv.playerOffset * 2 + 1;

                                #region is effect contained inside borders or always centered on party?
                                //code section for handling borders of the area
                                int modX = x;
                                int modY = y;
                                int modMinX = minX;
                                int modMinY = minY;

                                if (gv.mod.currentArea.containEffectInsideAreaBorders8)
                                {
                                    //code for for always keeping the effect contained in the area box, break center on player near map border
                                    if ((mod.PlayerLocationX + 4) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 1;
                                    }
                                    if ((mod.PlayerLocationX + 3) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 2;
                                    }
                                    if ((mod.PlayerLocationX + 2) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 3;
                                    }
                                    if ((mod.PlayerLocationX + 1) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 4;
                                    }


                                    if ((mod.PlayerLocationY + 4) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 1;
                                    }
                                    if ((mod.PlayerLocationY + 3) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 2;
                                    }
                                    if ((mod.PlayerLocationY + 2) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 3;
                                    }
                                    if ((mod.PlayerLocationY + 1) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 4;
                                    }
                                }

                                else
                                {
                                    //code for always centering the effect on player, even near map border (e.g. light source carried by party)
                                    if ((mod.PlayerLocationX - 3) == 0)
                                    {
                                        modMinX = -1;
                                    }
                                    if ((mod.PlayerLocationX - 2) == 0)
                                    {
                                        modMinX = -2;
                                    }
                                    if ((mod.PlayerLocationX - 1) == 0)
                                    {
                                        modMinX = -3;
                                    }
                                    if ((mod.PlayerLocationX) == 0)
                                    {
                                        modMinX = -4;
                                    }


                                    if ((mod.PlayerLocationY - 3) == 0)
                                    {
                                        modMinY = -1;
                                    }
                                    if ((mod.PlayerLocationY - 2) == 0)
                                    {
                                        modMinY = -2;
                                    }
                                    if ((mod.PlayerLocationY - 1) == 0)
                                    {
                                        modMinY = -3;
                                    }
                                    if ((mod.PlayerLocationY) == 0)
                                    {
                                        modMinY = -4;
                                    }
                                }
                                #endregion

                                //get the correct chunk on source
                                //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                float floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                float floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                #region handle border situations on source (bottom and right)     
                                //the following four sections help to set the top left x,y of our square incase we ae close to bottom or right border of source

                                if (gv.mod.currentArea.overrideIsNoScrollSource8 == "True")
                                {
                                    sizeOfWholeSource = 0.5f * sizeOfWholeSource;
                                    //get the correct chunk on source
                                    //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                    floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                    floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                    float smallSourceChunk = sizeOfWholeSource / numberOfPictureParts;
                                    sizeOfWholeSource = 2.0f * sizeOfWholeSource;
                                    /*
                                    //stop at border
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = 0;
                                        
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordY >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordY = sizeOfWholeSource - smallSourceChunk - 1;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = 0;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordX = sizeOfWholeSource - smallSourceChunk - 1;
                                    }
                                    */

                                }

                                else
                                {

                                    //leave source in negative direction (vertical)
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = (floatSourceChunkCoordY * -1f);
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                        floatSourceChunkCoordY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    }

                                    //leave source in positive direction (vertical)
                                    if (floatSourceChunkCoordY >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                    }

                                    //leave source in negative direction (horizontal)
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = (floatSourceChunkCoordX * -1f);
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                        floatSourceChunkCoordX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    }

                                    //leave source in positive direction (horizontal)
                                    if (floatSourceChunkCoordX >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                    }
                                }
                                #endregion

                                #region handle the four different draw situations, based on position of chunk on source
                                //next task is to actaully draw up to four pieces of  square source to one target dst
                                //let's go through the differdnt situations that can occur

                                #region Situation 1 (complex, 4 to 1)
                                //Situation 1 (most complex): touching four source squares, we are in the far low right corner
                                //there will be two more 2 source square situations, one for x and one for y direction
                                //also there's of course the standard situation that we just need one coherent source
                                if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && ((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource8 != "True"))
                                {

                                    //need to use parts four source chunks from four different source squares and draw them onto the dst square

                                    //first: top left corner
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect8, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: top right corner
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * dstScalerX)), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect8, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //third: bottom left corner
                                    float oldHeight = (brY * dstScalerY);
                                    availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldHeight, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect8, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //fourth: bottom right corner
                                    oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY + oldHeight, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect8, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    continue;

                                }
                                #endregion

                                #region Situation 2 (2 to 1, x near border)
                                //Situation 2: only x is near right border, y is high/small enough
                                else if (((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource8 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: left hand side
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect8, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: right hand side
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * (dstScalerX))), (brY * (dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect8, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;

                                }
                                #endregion

                                #region Situation 3 (2 to 1, y near border)
                                //Situation 3: only y is near bottom border, x is left/small enough WIP
                                else if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource8 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: top square
                                    float availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect8, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: bottom square
                                    float oldLength = 0;
                                    oldLength = (float)(brY * dstScalerY);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldLength, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect8, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;
                                }
                                #endregion

                                #region Situation 4 (default, neither x or y near border)
                                //Situation 4: the default situation, x and y are sufficiently distant from bottom and right border
                                else
                                {

                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;
                                    float sizeOfSourceChunk2 = 0;
                                    if (gv.mod.currentArea.overrideIsNoScrollSource8 != "True")
                                    {
                                        sizeOfSourceChunk2 = (sizeOfWholeSource / numberOfPictureParts);
                                    }
                                    else
                                    {
                                        sizeOfSourceChunk2 = ((sizeOfWholeSource * 0.5f) / numberOfPictureParts);
                                    }

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, sizeOfSourceChunk2, sizeOfSourceChunk2);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                                        gv.DrawBitmap(fullScreenEffect8, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                }
                                #endregion

                            }
                        }
                    }
                }
                #endregion

            }
            #endregion
            #endregion
            #region Draw full screen layer 9
            //there will be six layers for effects usable by either the top (eg.sky) or bottom (eg sea) full scren draw methods 
            //I would guess that combined about 60.000 pix are ok for performance,so like 6 x 100X900 source bitmaps or fewer, but with higer resolution
            //that's for my laptop

            //check whether the layer9 is activated and set to top level
            if ((gv.mod.currentArea.useFullScreenEffectLayer9) && (gv.mod.currentArea.FullScreenEffectLayer9IsTop))
            {

                gv.cc.DisposeOfBitmap(ref fullScreenEffect9);

                //these replace the normal, linear scroll in direction of vector x,y pattern
                //in the toolset different values for overrides can be set than the defaults they come with
                //this way an author can make use of the non-linear algorithms with different input parameters to bend their shape
                //basically it works like the override would call scripts whose paratmeters can be set by the authors
                //just with the added comfort that teh paarmeters ahve own fields in the toolset and descritive text
                //also when just letting all override values sit at zero,the override will use its own defaults, working out of the box like e.g. snow

                #region override movement patterns

                if (gv.mod.currentArea.directionalOverride9 == "randStraight")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX9 = 0.5f;
                    float defaultOverrideSpeedY9 = 0.5f;
                    int defaultOverrideDelayLimit9 = 15;
                    string defaultOverrideIsNoScrollSource9 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource9 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource9 = defaultOverrideIsNoScrollSource9;
                    }

                    if (gv.mod.currentArea.overrideSpeedX9 != -100)
                    {
                        defaultOverrideSpeedX9 = gv.mod.currentArea.overrideSpeedX9;
                    }
                    if (gv.mod.currentArea.overrideSpeedY9 != -100)
                    {
                        defaultOverrideSpeedY9 = gv.mod.currentArea.overrideSpeedY9;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit9 != -100)
                    {
                        defaultOverrideDelayLimit9 = gv.mod.currentArea.overrideDelayLimit9;
                    }

                    gv.mod.currentArea.overrideDelayCounter9++;
                    if (gv.mod.currentArea.overrideDelayCounter9 > defaultOverrideDelayLimit9)
                    {

                        gv.mod.currentArea.overrideDelayCounter9 = 0;
                        int rollRandom = gv.sf.RandInt(8);
                        //right
                        if (rollRandom == 1)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX9 = defaultOverrideSpeedX9;
                            gv.mod.currentArea.fullScreenAnimationSpeedY9 = 0.0f;
                        }
                        //left
                        if (rollRandom == 2)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX9 = -defaultOverrideSpeedX9;
                            gv.mod.currentArea.fullScreenAnimationSpeedY9 = 0.0f;
                        }
                        //up
                        if (rollRandom == 3)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX9 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY9 = defaultOverrideSpeedY9;
                        }
                        //down
                        if (rollRandom == 4)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX9 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY9 = -defaultOverrideSpeedY9;
                        }
                        //up right
                        if (rollRandom == 5)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX9 = defaultOverrideSpeedX9;
                            gv.mod.currentArea.fullScreenAnimationSpeedY9 = defaultOverrideSpeedY9;
                        }
                        //upleft
                        if (rollRandom == 6)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX9 = -defaultOverrideSpeedX9;
                            gv.mod.currentArea.fullScreenAnimationSpeedY9 = defaultOverrideSpeedY9;
                        }
                        //downright
                        if (rollRandom == 7)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX9 = defaultOverrideSpeedX9;
                            gv.mod.currentArea.fullScreenAnimationSpeedY9 = -defaultOverrideSpeedY9;
                        }
                        //downleft
                        if (rollRandom == 8)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX9 = -defaultOverrideSpeedX9;
                            gv.mod.currentArea.fullScreenAnimationSpeedY9 = -defaultOverrideSpeedY9;
                        }
                    }
                }

                if (gv.mod.currentArea.directionalOverride9 == "clouds")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX9 = 0.5f;
                    float defaultOverrideSpeedY9 = 0.5f;
                    int defaultOverrideDelayLimit9 = 750;
                    string defaultOverrideIsNoScrollSource9 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource9 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource9 = defaultOverrideIsNoScrollSource9;
                    }

                    if (gv.mod.currentArea.overrideSpeedX9 != -100)
                    {
                        defaultOverrideSpeedX9 = gv.mod.currentArea.overrideSpeedX9;
                    }
                    if (gv.mod.currentArea.overrideSpeedY9 != -100)
                    {
                        defaultOverrideSpeedY9 = gv.mod.currentArea.overrideSpeedY9;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit9 != -100)
                    {
                        defaultOverrideDelayLimit9 = gv.mod.currentArea.overrideDelayLimit9;
                    }

                    gv.mod.currentArea.overrideDelayCounter9++;
                    if (gv.mod.currentArea.overrideDelayCounter9 > defaultOverrideDelayLimit9)
                    {

                        gv.mod.currentArea.overrideDelayCounter9 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX9 = ((0.25f * directional) + (decider * defaultOverrideSpeedX9 * 0.5f)) * (0.5f);

                        //for y
                        rollRandom = gv.sf.RandInt(100);
                        rollRandom2 = gv.sf.RandInt(2);
                        directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedY9 = ((0.25f * directional) + (decider * defaultOverrideSpeedY9 * 0.5f)) * (0.5f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride9 == "fog")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX9 = 1.0f;
                    float defaultOverrideSpeedY9 = 1.0f;
                    int defaultOverrideDelayLimit9 = 110;
                    string defaultOverrideIsNoScrollSource9 = "True";

                    if (gv.mod.currentArea.overrideIsNoScrollSource9 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource9 = defaultOverrideIsNoScrollSource9;
                    }

                    if (gv.mod.currentArea.overrideSpeedX9 != -100)
                    {
                        defaultOverrideSpeedX9 = gv.mod.currentArea.overrideSpeedX9;
                    }
                    if (gv.mod.currentArea.overrideSpeedY9 != -100)
                    {
                        defaultOverrideSpeedY9 = gv.mod.currentArea.overrideSpeedY9;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit9 != -100)
                    {
                        defaultOverrideDelayLimit9 = gv.mod.currentArea.overrideDelayLimit9;
                    }

                    gv.mod.currentArea.overrideDelayCounter9++;
                    if (gv.mod.currentArea.overrideDelayCounter9 > defaultOverrideDelayLimit9)
                    {

                        gv.mod.currentArea.overrideDelayCounter9 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(100);
                        int directional = 1;
                        if (rollRandom2 >= 50)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedX9 = ((0.25f * directional) + (decider * defaultOverrideSpeedX9 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedX9 = ((0.075f * directional) + (decider * defaultOverrideSpeedX9 * 0.5f)) * (0.09f);

                        //for y
                        int rollRandom3 = gv.sf.RandInt(100);
                        int rollRandom4 = gv.sf.RandInt(100);
                        directional = 1;
                        if (rollRandom4 >= 50)
                        {
                            rollRandom3 = rollRandom3 * -1;
                            directional = -1;
                        }
                        decider = rollRandom3 / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedY9 = ((0.25f * directional) + (decider * defaultOverrideSpeedY9 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY9 = ((0.075f * directional) + (decider * defaultOverrideSpeedY9 * 0.5f)) * (0.09f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride9 == "snow")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX9 = 0.45f;
                    float defaultOverrideSpeedY9 = -0.55f;
                    int defaultOverrideDelayLimit9 = 470;
                    string defaultOverrideIsNoScrollSource9 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource9 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource9 = defaultOverrideIsNoScrollSource9;
                    }


                    if (gv.mod.currentArea.overrideSpeedX9 != -100)
                    {
                        defaultOverrideSpeedX9 = gv.mod.currentArea.overrideSpeedX9;
                    }
                    if (gv.mod.currentArea.overrideSpeedY9 != -100)
                    {
                        defaultOverrideSpeedY9 = gv.mod.currentArea.overrideSpeedY9;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit9 != -100)
                    {
                        defaultOverrideDelayLimit9 = gv.mod.currentArea.overrideDelayLimit9;
                    }

                    gv.mod.currentArea.overrideDelayCounter9++;
                    if (gv.mod.currentArea.overrideDelayCounter9 > defaultOverrideDelayLimit9)
                    {

                        gv.mod.currentArea.overrideDelayCounter9 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX9 = ((0.15f * directional) + (decider * defaultOverrideSpeedX9 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY9 = defaultOverrideSpeedY9;
                    }
                }

                if (gv.mod.currentArea.directionalOverride9 == "rain")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX9 = 0.5f;
                    float defaultOverrideSpeedY9 = -2.8f;
                    int defaultOverrideDelayLimit9 = 100;
                    string defaultOverrideIsNoScrollSource9 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource9 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource9 = defaultOverrideIsNoScrollSource9;
                    }

                    if (gv.mod.currentArea.overrideSpeedX9 != -100)
                    {
                        defaultOverrideSpeedX9 = gv.mod.currentArea.overrideSpeedX9;
                    }
                    if (gv.mod.currentArea.overrideSpeedY9 != -100)
                    {
                        defaultOverrideSpeedY9 = gv.mod.currentArea.overrideSpeedY9;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit9 != -100)
                    {
                        defaultOverrideDelayLimit9 = gv.mod.currentArea.overrideDelayLimit9;
                    }

                    gv.mod.currentArea.overrideDelayCounter9++;
                    if (gv.mod.currentArea.overrideDelayCounter9 > defaultOverrideDelayLimit9)
                    {

                        gv.mod.currentArea.overrideDelayCounter9 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            //rollRandom = rollRandom * -1;
                            //directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX9 = ((0.25f * directional) + (decider * defaultOverrideSpeedX9 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY9 = defaultOverrideSpeedY9;
                    }
                }

                if (gv.mod.currentArea.directionalOverride9 == "linear")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX9 = 1f;
                    float defaultOverrideSpeedY9 = 1f;
                    int defaultOverrideDelayLimit9 = 100;
                    string defaultOverrideIsNoScrollSource9 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource9 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource9 = defaultOverrideIsNoScrollSource9;
                    }

                    if (gv.mod.currentArea.overrideSpeedX9 != -100)
                    {
                        defaultOverrideSpeedX9 = gv.mod.currentArea.overrideSpeedX9;
                    }
                    if (gv.mod.currentArea.overrideSpeedY9 != -100)
                    {
                        defaultOverrideSpeedY9 = gv.mod.currentArea.overrideSpeedY9;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit9 != -100)
                    {
                        defaultOverrideDelayLimit9 = gv.mod.currentArea.overrideDelayLimit9;
                    }
                    gv.mod.currentArea.fullScreenAnimationSpeedX9 = defaultOverrideSpeedX9;
                    gv.mod.currentArea.fullScreenAnimationSpeedY9 = defaultOverrideSpeedY9;
                }


                #endregion

                if (gv.mod.currentArea.fullScreenEffectLayerIsActive9 == true)
                {
                    #region limited cycle animation
                    //check whether we got an effect that is supposed to happen only once in a while
                    if (gv.mod.currentArea.numberOfCyclesPerOccurence9 != 0)
                    {

                        //added speed
                        float speedComponentX = gv.mod.currentArea.fullScreenAnimationSpeedX9;
                        if (speedComponentX < 0)
                        {
                            speedComponentX *= -1;
                        }
                        float speedComponentY = gv.mod.currentArea.fullScreenAnimationSpeedY9;
                        if (speedComponentY < 0)
                        {
                            speedComponentY *= -1;
                        }
                        gv.mod.currentArea.fullScreenAnimationSpeed9 = speedComponentX + speedComponentY;

                        //based on subjective trial and error
                        if ((gv.mod.currentArea.fullScreenAnimationFrameCounter9 > (50f / (gv.mod.currentArea.fullScreenAnimationSpeed9 * gv.mod.allAnimationSpeedMultiplier) - 1)))
                        {
                            gv.mod.currentArea.cycleCounter9 += 1;
                            gv.mod.currentArea.fullScreenAnimationFrameCounter9 = 0;
                        }

                        //a little extra delay added by on intuition how long a cycle takes here
                        if (gv.mod.currentArea.cycleCounter9 >= (gv.mod.currentArea.numberOfCyclesPerOccurence9))
                        {
                            //turn the animation off, in common code's doudate method a chance per turn is rolled for turning on again
                            gv.mod.currentArea.fullScreenEffectLayerIsActive9 = false;
                            //counts how often/long the aniamtion is displayed before stop
                            gv.mod.currentArea.cycleCounter9 = 0;
                            //just keeping track how often render calls have run through
                            gv.mod.currentArea.fullScreenAnimationFrameCounter9 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeCounter9 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeFrameCounter9 = 1;
                        }

                        gv.mod.currentArea.fullScreenAnimationFrameCounter9 += 1;
                    }
                    #endregion

                    //if (gv.mod.currentArea.fullScreenEffectLayerIsActive9 == true)
                    //{
                    float fullScreenEffectOpacity = 1f;
                    #region opacity code
                    if (gv.mod.currentArea.useCyclicFade9)
                    {
                        //fade in within first cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter9 == 0) && (gv.mod.currentArea.numberOfCyclesPerOccurence9 != 0))
                        {
                            fullScreenEffectOpacity = 1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed9 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter9);
                        }

                        //fade out within last cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter9 == (gv.mod.currentArea.numberOfCyclesPerOccurence9 - 1)) && (gv.mod.currentArea.numberOfCyclesPerOccurence9 != 0))
                        {
                            fullScreenEffectOpacity = 1f - (1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed9 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter9));
                        }
                    }
                    if (gv.mod.fullScreenEffectOpacityWeather != 1)
                    {
                        fullScreenEffectOpacity = gv.mod.fullScreenEffectOpacityWeather;
                    }
                    #endregion

                    //use weather system per area specific later on
                    //utilizing weather type defined by area weather settings
                    //add check for square specific punch hole that prevents drawing weather, e.g. house inside or spaceship interior

                    #region only for shape changing animation
                    if (gv.mod.currentArea.isChanging9)
                    {
                        gv.mod.currentArea.changeCounter9 += (1 * gv.mod.allAnimationSpeedMultiplier);
                        if (gv.mod.currentArea.changeCounter9 > gv.mod.currentArea.changeLimit9)
                        {
                            gv.mod.currentArea.changeCounter9 = 0;
                            gv.mod.currentArea.changeFrameCounter9 += 1;
                            if (gv.mod.currentArea.changeFrameCounter9 > gv.mod.currentArea.changeNumberOfFrames9)
                            {
                                gv.mod.currentArea.changeFrameCounter9 = 1;
                            }
                        }
                        fullScreenEffect9 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName9 + gv.mod.currentArea.changeFrameCounter9.ToString());
                    }
                    #endregion

                    else
                    {
                        fullScreenEffect9 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName9);
                    }

                    #region handle framecounter
                    //assuming a square shaped source here
                    float sizeOfWholeSource = fullScreenEffect9.PixelSize.Width;

                    //reading the frames moved and added up in the last seconds
                    float pixShiftOnThisFrameX = gv.mod.currentArea.fullScreenAnimationFrameCounterX9;
                    float pixShiftOnThisFrameY = gv.mod.currentArea.fullScreenAnimationFrameCounterY9;

                    //increase by this call's movement
                    pixShiftOnThisFrameX += (gv.mod.currentArea.fullScreenAnimationSpeedX9 * gv.mod.allAnimationSpeedMultiplier);
                    pixShiftOnThisFrameY += (gv.mod.currentArea.fullScreenAnimationSpeedY9 * gv.mod.allAnimationSpeedMultiplier);

                    if (gv.mod.currentArea.overrideIsNoScrollSource9 == "True")
                    {
                        if (pixShiftOnThisFrameX > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameX = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedX9 *= -1;
                        }

                        if (pixShiftOnThisFrameY > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameY = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY9 *= -1;
                        }

                        if (pixShiftOnThisFrameX < 0)
                        {
                            pixShiftOnThisFrameX = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedX9 *= -1;
                        }

                        if (pixShiftOnThisFrameY < 0)
                        {
                            pixShiftOnThisFrameY = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedY9 *= -1;
                        }
                    }

                    //reset it in case it grwos too large (note: just to avoid an overflow in the far future)
                    //the actual reset happens later below
                    if (pixShiftOnThisFrameX >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameX <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    gv.mod.currentArea.fullScreenAnimationFrameCounterX9 = pixShiftOnThisFrameX;
                    gv.mod.currentArea.fullScreenAnimationFrameCounterY9 = pixShiftOnThisFrameY;
                    #endregion

                    #region iterate through the dst tiles
                    for (int x = minX; x < maxX; x++)
                    {
                        for (int y = minY; y < maxY; y++)
                        {
                            Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];

                            //each tile can block the effects run on the six effect channels, each e.g. simualting shelter from rain
                            if (!tile.blockFullScreenEffectLayer9)
                            {
                                int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                                int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;

                                float scalerX = gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Width / 100f;
                                float scalerY = gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Height / 100f;
                                float brX = gv.squareSize * scalerX;
                                float brY = gv.squareSize * scalerY;

                                float numberOfPictureParts = gv.playerOffset * 2 + 1;

                                #region is effect contained inside borders or always centered on party?
                                //code section for handling borders of the area
                                int modX = x;
                                int modY = y;
                                int modMinX = minX;
                                int modMinY = minY;

                                if (gv.mod.currentArea.containEffectInsideAreaBorders9)
                                {
                                    //code for for always keeping the effect contained in the area box, break center on player near map border
                                    if ((mod.PlayerLocationX + 4) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 1;
                                    }
                                    if ((mod.PlayerLocationX + 3) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 2;
                                    }
                                    if ((mod.PlayerLocationX + 2) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 3;
                                    }
                                    if ((mod.PlayerLocationX + 1) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 4;
                                    }


                                    if ((mod.PlayerLocationY + 4) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 1;
                                    }
                                    if ((mod.PlayerLocationY + 3) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 2;
                                    }
                                    if ((mod.PlayerLocationY + 2) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 3;
                                    }
                                    if ((mod.PlayerLocationY + 1) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 4;
                                    }
                                }

                                else
                                {
                                    //code for always centering the effect on player, even near map border (e.g. light source carried by party)
                                    if ((mod.PlayerLocationX - 3) == 0)
                                    {
                                        modMinX = -1;
                                    }
                                    if ((mod.PlayerLocationX - 2) == 0)
                                    {
                                        modMinX = -2;
                                    }
                                    if ((mod.PlayerLocationX - 1) == 0)
                                    {
                                        modMinX = -3;
                                    }
                                    if ((mod.PlayerLocationX) == 0)
                                    {
                                        modMinX = -4;
                                    }


                                    if ((mod.PlayerLocationY - 3) == 0)
                                    {
                                        modMinY = -1;
                                    }
                                    if ((mod.PlayerLocationY - 2) == 0)
                                    {
                                        modMinY = -2;
                                    }
                                    if ((mod.PlayerLocationY - 1) == 0)
                                    {
                                        modMinY = -3;
                                    }
                                    if ((mod.PlayerLocationY) == 0)
                                    {
                                        modMinY = -4;
                                    }
                                }
                                #endregion

                                //get the correct chunk on source
                                //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                float floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                float floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                #region handle border situations on source (bottom and right)     
                                //the following four sections help to set the top left x,y of our square incase we ae close to bottom or right border of source

                                if (gv.mod.currentArea.overrideIsNoScrollSource9 == "True")
                                {
                                    sizeOfWholeSource = 0.5f * sizeOfWholeSource;
                                    //get the correct chunk on source
                                    //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                    floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                    floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                    float smallSourceChunk = sizeOfWholeSource / numberOfPictureParts;
                                    sizeOfWholeSource = 2.0f * sizeOfWholeSource;
                                    /*
                                    //stop at border
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = 0;
                                        
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordY >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordY = sizeOfWholeSource - smallSourceChunk - 1;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = 0;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordX = sizeOfWholeSource - smallSourceChunk - 1;
                                    }
                                    */

                                }

                                else
                                {

                                    //leave source in negative direction (vertical)
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = (floatSourceChunkCoordY * -1f);
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                        floatSourceChunkCoordY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    }

                                    //leave source in positive direction (vertical)
                                    if (floatSourceChunkCoordY >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                    }

                                    //leave source in negative direction (horizontal)
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = (floatSourceChunkCoordX * -1f);
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                        floatSourceChunkCoordX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    }

                                    //leave source in positive direction (horizontal)
                                    if (floatSourceChunkCoordX >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                    }
                                }
                                #endregion

                                #region handle the four different draw situations, based on position of chunk on source
                                //next task is to actaully draw up to four pieces of  square source to one target dst
                                //let's go through the differdnt situations that can occur

                                #region Situation 1 (complex, 4 to 1)
                                //Situation 1 (most complex): touching four source squares, we are in the far low right corner
                                //there will be two more 2 source square situations, one for x and one for y direction
                                //also there's of course the standard situation that we just need one coherent source
                                if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && ((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource9 != "True"))
                                {

                                    //need to use parts four source chunks from four different source squares and draw them onto the dst square

                                    //first: top left corner
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect9, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: top right corner
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * dstScalerX)), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect9, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //third: bottom left corner
                                    float oldHeight = (brY * dstScalerY);
                                    availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldHeight, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect9, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //fourth: bottom right corner
                                    oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY + oldHeight, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect9, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    continue;

                                }
                                #endregion

                                #region Situation 2 (2 to 1, x near border)
                                //Situation 2: only x is near right border, y is high/small enough
                                else if (((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource9 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: left hand side
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect9, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: right hand side
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * (dstScalerX))), (brY * (dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect9, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;

                                }
                                #endregion

                                #region Situation 3 (2 to 1, y near border)
                                //Situation 3: only y is near bottom border, x is left/small enough WIP
                                else if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource9 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: top square
                                    float availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect9, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: bottom square
                                    float oldLength = 0;
                                    oldLength = (float)(brY * dstScalerY);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldLength, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect9, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;
                                }
                                #endregion

                                #region Situation 4 (default, neither x or y near border)
                                //Situation 4: the default situation, x and y are sufficiently distant from bottom and right border
                                else
                                {

                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;
                                    float sizeOfSourceChunk2 = 0;
                                    if (gv.mod.currentArea.overrideIsNoScrollSource9 != "True")
                                    {
                                        sizeOfSourceChunk2 = (sizeOfWholeSource / numberOfPictureParts);
                                    }
                                    else
                                    {
                                        sizeOfSourceChunk2 = ((sizeOfWholeSource * 0.5f) / numberOfPictureParts);
                                    }

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, sizeOfSourceChunk2, sizeOfSourceChunk2);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                                        gv.DrawBitmap(fullScreenEffect9, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                }
                                #endregion

                            }
                        }
                    }
                }
                #endregion

            }
            #endregion
            #endregion
            #region Draw full screen layer 10
            //there will be six layers for effects usable by either the top (eg.sky) or bottom (eg sea) full scren draw methods 
            //I would guess that combined about 60.000 pix are ok for performance,so like 6 x 100X1000 source bitmaps or fewer, but with higer resolution
            //that's for my laptop

            //check whether the layer10 is activated and set to top level
            if ((gv.mod.currentArea.useFullScreenEffectLayer10) && (gv.mod.currentArea.FullScreenEffectLayer10IsTop))
            {

                gv.cc.DisposeOfBitmap(ref fullScreenEffect10);

                //these replace the normal, linear scroll in direction of vector x,y pattern
                //in the toolset different values for overrides can be set than the defaults they come with
                //this way an author can make use of the non-linear algorithms with different input parameters to bend their shape
                //basically it works like the override would call scripts whose paratmeters can be set by the authors
                //just with the added comfort that teh paarmeters ahve own fields in the toolset and descritive text
                //also when just letting all override values sit at zero,the override will use its own defaults, working out of the box like e.g. snow

                #region override movement patterns

                if (gv.mod.currentArea.directionalOverride10 == "randStraight")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX10 = 0.5f;
                    float defaultOverrideSpeedY10 = 0.5f;
                    int defaultOverrideDelayLimit10 = 15;
                    string defaultOverrideIsNoScrollSource10 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource10 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource10 = defaultOverrideIsNoScrollSource10;
                    }

                    if (gv.mod.currentArea.overrideSpeedX10 != -100)
                    {
                        defaultOverrideSpeedX10 = gv.mod.currentArea.overrideSpeedX10;
                    }
                    if (gv.mod.currentArea.overrideSpeedY10 != -100)
                    {
                        defaultOverrideSpeedY10 = gv.mod.currentArea.overrideSpeedY10;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit10 != -100)
                    {
                        defaultOverrideDelayLimit10 = gv.mod.currentArea.overrideDelayLimit10;
                    }

                    gv.mod.currentArea.overrideDelayCounter10++;
                    if (gv.mod.currentArea.overrideDelayCounter10 > defaultOverrideDelayLimit10)
                    {

                        gv.mod.currentArea.overrideDelayCounter10 = 0;
                        int rollRandom = gv.sf.RandInt(8);
                        //right
                        if (rollRandom == 1)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX10 = defaultOverrideSpeedX10;
                            gv.mod.currentArea.fullScreenAnimationSpeedY10 = 0.0f;
                        }
                        //left
                        if (rollRandom == 2)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX10 = -defaultOverrideSpeedX10;
                            gv.mod.currentArea.fullScreenAnimationSpeedY10 = 0.0f;
                        }
                        //up
                        if (rollRandom == 3)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX10 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY10 = defaultOverrideSpeedY10;
                        }
                        //down
                        if (rollRandom == 4)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX10 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY10 = -defaultOverrideSpeedY10;
                        }
                        //up right
                        if (rollRandom == 5)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX10 = defaultOverrideSpeedX10;
                            gv.mod.currentArea.fullScreenAnimationSpeedY10 = defaultOverrideSpeedY10;
                        }
                        //upleft
                        if (rollRandom == 6)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX10 = -defaultOverrideSpeedX10;
                            gv.mod.currentArea.fullScreenAnimationSpeedY10 = defaultOverrideSpeedY10;
                        }
                        //downright
                        if (rollRandom == 7)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX10 = defaultOverrideSpeedX10;
                            gv.mod.currentArea.fullScreenAnimationSpeedY10 = -defaultOverrideSpeedY10;
                        }
                        //downleft
                        if (rollRandom == 8)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX10 = -defaultOverrideSpeedX10;
                            gv.mod.currentArea.fullScreenAnimationSpeedY10 = -defaultOverrideSpeedY10;
                        }
                    }
                }

                if (gv.mod.currentArea.directionalOverride10 == "clouds")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX10 = 0.5f;
                    float defaultOverrideSpeedY10 = 0.5f;
                    int defaultOverrideDelayLimit10 = 750;
                    string defaultOverrideIsNoScrollSource10 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource10 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource10 = defaultOverrideIsNoScrollSource10;
                    }

                    if (gv.mod.currentArea.overrideSpeedX10 != -100)
                    {
                        defaultOverrideSpeedX10 = gv.mod.currentArea.overrideSpeedX10;
                    }
                    if (gv.mod.currentArea.overrideSpeedY10 != -100)
                    {
                        defaultOverrideSpeedY10 = gv.mod.currentArea.overrideSpeedY10;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit10 != -100)
                    {
                        defaultOverrideDelayLimit10 = gv.mod.currentArea.overrideDelayLimit10;
                    }

                    gv.mod.currentArea.overrideDelayCounter10++;
                    if (gv.mod.currentArea.overrideDelayCounter10 > defaultOverrideDelayLimit10)
                    {

                        gv.mod.currentArea.overrideDelayCounter10 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX10 = ((0.25f * directional) + (decider * defaultOverrideSpeedX10 * 0.5f)) * (0.5f);

                        //for y
                        rollRandom = gv.sf.RandInt(100);
                        rollRandom2 = gv.sf.RandInt(2);
                        directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedY10 = ((0.25f * directional) + (decider * defaultOverrideSpeedY10 * 0.5f)) * (0.5f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride10 == "fog")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX10 = 1.0f;
                    float defaultOverrideSpeedY10 = 1.0f;
                    int defaultOverrideDelayLimit10 = 110;
                    string defaultOverrideIsNoScrollSource10 = "True";

                    if (gv.mod.currentArea.overrideIsNoScrollSource10 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource10 = defaultOverrideIsNoScrollSource10;
                    }

                    if (gv.mod.currentArea.overrideSpeedX10 != -100)
                    {
                        defaultOverrideSpeedX10 = gv.mod.currentArea.overrideSpeedX10;
                    }
                    if (gv.mod.currentArea.overrideSpeedY10 != -100)
                    {
                        defaultOverrideSpeedY10 = gv.mod.currentArea.overrideSpeedY10;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit10 != -100)
                    {
                        defaultOverrideDelayLimit10 = gv.mod.currentArea.overrideDelayLimit10;
                    }

                    gv.mod.currentArea.overrideDelayCounter10++;
                    if (gv.mod.currentArea.overrideDelayCounter10 > defaultOverrideDelayLimit10)
                    {

                        gv.mod.currentArea.overrideDelayCounter10 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(100);
                        int directional = 1;
                        if (rollRandom2 >= 50)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedX10 = ((0.25f * directional) + (decider * defaultOverrideSpeedX10 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedX10 = ((0.075f * directional) + (decider * defaultOverrideSpeedX10 * 0.5f)) * (0.09f);

                        //for y
                        int rollRandom3 = gv.sf.RandInt(100);
                        int rollRandom4 = gv.sf.RandInt(100);
                        directional = 1;
                        if (rollRandom4 >= 50)
                        {
                            rollRandom3 = rollRandom3 * -1;
                            directional = -1;
                        }
                        decider = rollRandom3 / 100f;
                        //gv.mod.currentArea.fullScreenAnimationSpeedY10 = ((0.25f * directional) + (decider * defaultOverrideSpeedY10 * 0.5f)) * (0.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY10 = ((0.075f * directional) + (decider * defaultOverrideSpeedY10 * 0.5f)) * (0.09f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride10 == "snow")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX10 = 0.45f;
                    float defaultOverrideSpeedY10 = -0.55f;
                    int defaultOverrideDelayLimit10 = 470;
                    string defaultOverrideIsNoScrollSource10 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource10 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource10 = defaultOverrideIsNoScrollSource10;
                    }


                    if (gv.mod.currentArea.overrideSpeedX10 != -100)
                    {
                        defaultOverrideSpeedX10 = gv.mod.currentArea.overrideSpeedX10;
                    }
                    if (gv.mod.currentArea.overrideSpeedY10 != -100)
                    {
                        defaultOverrideSpeedY10 = gv.mod.currentArea.overrideSpeedY10;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit10 != -100)
                    {
                        defaultOverrideDelayLimit10 = gv.mod.currentArea.overrideDelayLimit10;
                    }

                    gv.mod.currentArea.overrideDelayCounter10++;
                    if (gv.mod.currentArea.overrideDelayCounter10 > defaultOverrideDelayLimit10)
                    {

                        gv.mod.currentArea.overrideDelayCounter10 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX10 = ((0.15f * directional) + (decider * defaultOverrideSpeedX10 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY10 = defaultOverrideSpeedY10;
                    }
                }

                if (gv.mod.currentArea.directionalOverride10 == "rain")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX10 = 0.5f;
                    float defaultOverrideSpeedY10 = -2.8f;
                    int defaultOverrideDelayLimit10 = 100;
                    string defaultOverrideIsNoScrollSource10 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource10 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource10 = defaultOverrideIsNoScrollSource10;
                    }

                    if (gv.mod.currentArea.overrideSpeedX10 != -100)
                    {
                        defaultOverrideSpeedX10 = gv.mod.currentArea.overrideSpeedX10;
                    }
                    if (gv.mod.currentArea.overrideSpeedY10 != -100)
                    {
                        defaultOverrideSpeedY10 = gv.mod.currentArea.overrideSpeedY10;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit10 != -100)
                    {
                        defaultOverrideDelayLimit10 = gv.mod.currentArea.overrideDelayLimit10;
                    }

                    gv.mod.currentArea.overrideDelayCounter10++;
                    if (gv.mod.currentArea.overrideDelayCounter10 > defaultOverrideDelayLimit10)
                    {

                        gv.mod.currentArea.overrideDelayCounter10 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            //rollRandom = rollRandom * -1;
                            //directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX10 = ((0.25f * directional) + (decider * defaultOverrideSpeedX10 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY10 = defaultOverrideSpeedY10;
                    }
                }

                if (gv.mod.currentArea.directionalOverride10 == "linear")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX10 = 1f;
                    float defaultOverrideSpeedY10 = 1f;
                    int defaultOverrideDelayLimit10 = 100;
                    string defaultOverrideIsNoScrollSource10 = "False";

                    if (gv.mod.currentArea.overrideIsNoScrollSource10 == "")
                    {
                        gv.mod.currentArea.overrideIsNoScrollSource10 = defaultOverrideIsNoScrollSource10;
                    }

                    if (gv.mod.currentArea.overrideSpeedX10 != -100)
                    {
                        defaultOverrideSpeedX10 = gv.mod.currentArea.overrideSpeedX10;
                    }
                    if (gv.mod.currentArea.overrideSpeedY10 != -100)
                    {
                        defaultOverrideSpeedY10 = gv.mod.currentArea.overrideSpeedY10;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit10 != -100)
                    {
                        defaultOverrideDelayLimit10 = gv.mod.currentArea.overrideDelayLimit10;
                    }
                    gv.mod.currentArea.fullScreenAnimationSpeedX10 = defaultOverrideSpeedX10;
                    gv.mod.currentArea.fullScreenAnimationSpeedY10 = defaultOverrideSpeedY10;
                }


                #endregion

                if (gv.mod.currentArea.fullScreenEffectLayerIsActive10 == true)
                {
                    #region limited cycle animation
                    //check whether we got an effect that is supposed to happen only once in a while
                    if (gv.mod.currentArea.numberOfCyclesPerOccurence10 != 0)
                    {

                        //added speed
                        float speedComponentX = gv.mod.currentArea.fullScreenAnimationSpeedX10;
                        if (speedComponentX < 0)
                        {
                            speedComponentX *= -1;
                        }
                        float speedComponentY = gv.mod.currentArea.fullScreenAnimationSpeedY10;
                        if (speedComponentY < 0)
                        {
                            speedComponentY *= -1;
                        }
                        gv.mod.currentArea.fullScreenAnimationSpeed10 = speedComponentX + speedComponentY;

                        //based on subjective trial and error
                        if ((gv.mod.currentArea.fullScreenAnimationFrameCounter10 > (50f / (gv.mod.currentArea.fullScreenAnimationSpeed10 * gv.mod.allAnimationSpeedMultiplier) - 1)))
                        {
                            gv.mod.currentArea.cycleCounter10 += 1;
                            gv.mod.currentArea.fullScreenAnimationFrameCounter10 = 0;
                        }

                        //a little extra delay added by on intuition how long a cycle takes here
                        if (gv.mod.currentArea.cycleCounter10 >= (gv.mod.currentArea.numberOfCyclesPerOccurence10))
                        {
                            //turn the animation off, in common code's doudate method a chance per turn is rolled for turning on again
                            gv.mod.currentArea.fullScreenEffectLayerIsActive10 = false;
                            //counts how often/long the aniamtion is displayed before stop
                            gv.mod.currentArea.cycleCounter10 = 0;
                            //just keeping track how often render calls have run through
                            gv.mod.currentArea.fullScreenAnimationFrameCounter10 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeCounter10 = 0;
                            //for changing a shape changing anim
                            gv.mod.currentArea.changeFrameCounter10 = 1;
                        }

                        gv.mod.currentArea.fullScreenAnimationFrameCounter10 += 1;
                    }
                    #endregion

                    //if (gv.mod.currentArea.fullScreenEffectLayerIsActive10 == true)
                    //{
                    float fullScreenEffectOpacity = 1f;
                    #region opacity code
                    if (gv.mod.currentArea.useCyclicFade10)
                    {
                        //fade in within first cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter10 == 0) && (gv.mod.currentArea.numberOfCyclesPerOccurence10 != 0))
                        {
                            fullScreenEffectOpacity = 1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed10 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter10);
                        }

                        //fade out within last cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter10 == (gv.mod.currentArea.numberOfCyclesPerOccurence10 - 1)) && (gv.mod.currentArea.numberOfCyclesPerOccurence10 != 0))
                        {
                            fullScreenEffectOpacity = 1f - (1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed10 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter10));
                        }
                    }
                    if (gv.mod.fullScreenEffectOpacityWeather != 1)
                    {
                        fullScreenEffectOpacity = gv.mod.fullScreenEffectOpacityWeather;
                    }
                    #endregion

                    //use weather system per area specific later on
                    //utilizing weather type defined by area weather settings
                    //add check for square specific punch hole that prevents drawing weather, e.g. house inside or spaceship interior

                    #region only for shape changing animation
                    if (gv.mod.currentArea.isChanging10)
                    {
                        gv.mod.currentArea.changeCounter10 += (1 * gv.mod.allAnimationSpeedMultiplier);
                        if (gv.mod.currentArea.changeCounter10 > gv.mod.currentArea.changeLimit10)
                        {
                            gv.mod.currentArea.changeCounter10 = 0;
                            gv.mod.currentArea.changeFrameCounter10 += 1;
                            if (gv.mod.currentArea.changeFrameCounter10 > gv.mod.currentArea.changeNumberOfFrames10)
                            {
                                gv.mod.currentArea.changeFrameCounter10 = 1;
                            }
                        }
                        fullScreenEffect10 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName10 + gv.mod.currentArea.changeFrameCounter10.ToString());
                    }
                    #endregion

                    else
                    {
                        fullScreenEffect10 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName10);
                    }

                    #region handle framecounter
                    //assuming a square shaped source here
                    float sizeOfWholeSource = fullScreenEffect10.PixelSize.Width;

                    //reading the frames moved and added up in the last seconds
                    float pixShiftOnThisFrameX = gv.mod.currentArea.fullScreenAnimationFrameCounterX10;
                    float pixShiftOnThisFrameY = gv.mod.currentArea.fullScreenAnimationFrameCounterY10;

                    //increase by this call's movement
                    pixShiftOnThisFrameX += (gv.mod.currentArea.fullScreenAnimationSpeedX10 * gv.mod.allAnimationSpeedMultiplier);
                    pixShiftOnThisFrameY += (gv.mod.currentArea.fullScreenAnimationSpeedY10 * gv.mod.allAnimationSpeedMultiplier);

                    if (gv.mod.currentArea.overrideIsNoScrollSource10 == "True")
                    {
                        if (pixShiftOnThisFrameX > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameX = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedX10 *= -1;
                        }

                        if (pixShiftOnThisFrameY > ((sizeOfWholeSource * 0.5f) - 1))
                        {
                            pixShiftOnThisFrameY = (sizeOfWholeSource * 0.5f) - 1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY10 *= -1;
                        }

                        if (pixShiftOnThisFrameX < 0)
                        {
                            pixShiftOnThisFrameX = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedX10 *= -1;
                        }

                        if (pixShiftOnThisFrameY < 0)
                        {
                            pixShiftOnThisFrameY = 0;
                            gv.mod.currentArea.fullScreenAnimationSpeedY10 *= -1;
                        }
                    }

                    //reset it in case it grwos too large (note: just to avoid an overflow in the far future)
                    //the actual reset happens later below
                    if (pixShiftOnThisFrameX >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameX <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    gv.mod.currentArea.fullScreenAnimationFrameCounterX10 = pixShiftOnThisFrameX;
                    gv.mod.currentArea.fullScreenAnimationFrameCounterY10 = pixShiftOnThisFrameY;
                    #endregion

                    #region iterate through the dst tiles
                    for (int x = minX; x < maxX; x++)
                    {
                        for (int y = minY; y < maxY; y++)
                        {
                            Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];

                            //each tile can block the effects run on the six effect channels, each e.g. simualting shelter from rain
                            if (!tile.blockFullScreenEffectLayer10)
                            {
                                int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                                int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;

                                float scalerX = gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Width / 100f;
                                float scalerY = gv.cc.tileBitmapList[tile.Layer5Filename].PixelSize.Height / 100f;
                                float brX = gv.squareSize * scalerX;
                                float brY = gv.squareSize * scalerY;

                                float numberOfPictureParts = gv.playerOffset * 2 + 1;

                                #region is effect contained inside borders or always centered on party?
                                //code section for handling borders of the area
                                int modX = x;
                                int modY = y;
                                int modMinX = minX;
                                int modMinY = minY;

                                if (gv.mod.currentArea.containEffectInsideAreaBorders10)
                                {
                                    //code for for always keeping the effect contained in the area box, break center on player near map border
                                    if ((mod.PlayerLocationX + 4) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 1;
                                    }
                                    if ((mod.PlayerLocationX + 3) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 2;
                                    }
                                    if ((mod.PlayerLocationX + 2) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 3;
                                    }
                                    if ((mod.PlayerLocationX + 1) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 4;
                                    }


                                    if ((mod.PlayerLocationY + 4) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 1;
                                    }
                                    if ((mod.PlayerLocationY + 3) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 2;
                                    }
                                    if ((mod.PlayerLocationY + 2) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 3;
                                    }
                                    if ((mod.PlayerLocationY + 1) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 4;
                                    }
                                }

                                else
                                {
                                    //code for always centering the effect on player, even near map border (e.g. light source carried by party)
                                    if ((mod.PlayerLocationX - 3) == 0)
                                    {
                                        modMinX = -1;
                                    }
                                    if ((mod.PlayerLocationX - 2) == 0)
                                    {
                                        modMinX = -2;
                                    }
                                    if ((mod.PlayerLocationX - 1) == 0)
                                    {
                                        modMinX = -3;
                                    }
                                    if ((mod.PlayerLocationX) == 0)
                                    {
                                        modMinX = -4;
                                    }


                                    if ((mod.PlayerLocationY - 3) == 0)
                                    {
                                        modMinY = -1;
                                    }
                                    if ((mod.PlayerLocationY - 2) == 0)
                                    {
                                        modMinY = -2;
                                    }
                                    if ((mod.PlayerLocationY - 1) == 0)
                                    {
                                        modMinY = -3;
                                    }
                                    if ((mod.PlayerLocationY) == 0)
                                    {
                                        modMinY = -4;
                                    }
                                }
                                #endregion

                                //get the correct chunk on source
                                //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                float floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                float floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                #region handle border situations on source (bottom and right)     
                                //the following four sections help to set the top left x,y of our square incase we ae close to bottom or right border of source

                                if (gv.mod.currentArea.overrideIsNoScrollSource10 == "True")
                                {
                                    sizeOfWholeSource = 0.5f * sizeOfWholeSource;
                                    //get the correct chunk on source
                                    //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                    floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                    floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                    float smallSourceChunk = sizeOfWholeSource / numberOfPictureParts;
                                    sizeOfWholeSource = 2.0f * sizeOfWholeSource;
                                    /*
                                    //stop at border
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = 0;
                                        
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordY >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordY = sizeOfWholeSource - smallSourceChunk - 1;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = 0;
                                    }

                                    //stop at border
                                    if (floatSourceChunkCoordX >= (sizeOfWholeSource - smallSourceChunk - 1))
                                    {
                                        floatSourceChunkCoordX = sizeOfWholeSource - smallSourceChunk - 1;
                                    }
                                    */

                                }

                                else
                                {

                                    //leave source in negative direction (vertical)
                                    if (floatSourceChunkCoordY < 0)
                                    {
                                        floatSourceChunkCoordY = (floatSourceChunkCoordY * -1f);
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                        floatSourceChunkCoordY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    }

                                    //leave source in positive direction (vertical)
                                    if (floatSourceChunkCoordY >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                    }

                                    //leave source in negative direction (horizontal)
                                    if (floatSourceChunkCoordX < 0)
                                    {
                                        floatSourceChunkCoordX = (floatSourceChunkCoordX * -1f);
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                        floatSourceChunkCoordX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    }

                                    //leave source in positive direction (horizontal)
                                    if (floatSourceChunkCoordX >= sizeOfWholeSource)
                                    {
                                        floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                    }
                                }
                                #endregion

                                #region handle the four different draw situations, based on position of chunk on source
                                //next task is to actaully draw up to four pieces of  square source to one target dst
                                //let's go through the differdnt situations that can occur

                                #region Situation 1 (complex, 4 to 1)
                                //Situation 1 (most complex): touching four source squares, we are in the far low right corner
                                //there will be two more 2 source square situations, one for x and one for y direction
                                //also there's of course the standard situation that we just need one coherent source
                                if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && ((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource10 != "True"))
                                {

                                    //need to use parts four source chunks from four different source squares and draw them onto the dst square

                                    //first: top left corner
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect10, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: top right corner
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * dstScalerX)), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect10, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //third: bottom left corner
                                    float oldHeight = (brY * dstScalerY);
                                    availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldHeight, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect10, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //fourth: bottom right corner
                                    oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY + oldHeight, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect10, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    continue;

                                }
                                #endregion

                                #region Situation 2 (2 to 1, x near border)
                                //Situation 2: only x is near right border, y is high/small enough
                                else if (((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource10 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: left hand side
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect10, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: right hand side
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * (dstScalerX))), (brY * (dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect10, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;

                                }
                                #endregion

                                #region Situation 3 (2 to 1, y near border)
                                //Situation 3: only y is near bottom border, x is left/small enough WIP
                                else if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && (gv.mod.currentArea.overrideIsNoScrollSource10 != "True"))
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: top square
                                    float availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect10, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: bottom square
                                    float oldLength = 0;
                                    oldLength = (float)(brY * dstScalerY);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldLength, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect10, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;
                                }
                                #endregion

                                #region Situation 4 (default, neither x or y near border)
                                //Situation 4: the default situation, x and y are sufficiently distant from bottom and right border
                                else
                                {

                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;
                                    float sizeOfSourceChunk2 = 0;
                                    if (gv.mod.currentArea.overrideIsNoScrollSource10 != "True")
                                    {
                                        sizeOfSourceChunk2 = (sizeOfWholeSource / numberOfPictureParts);
                                    }
                                    else
                                    {
                                        sizeOfSourceChunk2 = ((sizeOfWholeSource * 0.5f) / numberOfPictureParts);
                                    }

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, sizeOfSourceChunk2, sizeOfSourceChunk2);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                                        gv.DrawBitmap(fullScreenEffect10, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                }
                                #endregion

                            }
                        }
                    }
                }
                #endregion

            }
            #endregion
            #endregion
        }

        public void drawBottomFullScreenEffects()
        {
            #region dst tile preparation (min and max)  
            //set up teh min and max dst tiles to iterate through, ie draw on into the map area and that on a tile by tile basis 
            int minX = mod.PlayerLocationX - gv.playerOffset;
            if (minX < 0) { minX = 0; }
            int minY = mod.PlayerLocationY - gv.playerOffset;
            if (minY < 0) { minY = 0; }

            int maxX = mod.PlayerLocationX + gv.playerOffset + 1;
            if (maxX > this.mod.currentArea.MapSizeX) { maxX = this.mod.currentArea.MapSizeX; }
            int maxY = mod.PlayerLocationY + gv.playerOffset + 1;
            if (maxY > this.mod.currentArea.MapSizeY) { maxY = this.mod.currentArea.MapSizeY; }
            #endregion

            #region Draw full screen layer 1
            //there will be six layers for effects usable by either the top (eg.sky) or bottom (eg sea) full scren draw methods 
            //I would guess that combined about 60.000 pix are ok for performance,so like 6 x 100x100 source bitmaps or fewer, but with higer resolution
            //that's for my laptop
            if ((gv.mod.currentArea.useFullScreenEffectLayer1) && (!gv.mod.currentArea.FullScreenEffectLayer1IsTop))
            {

                gv.cc.DisposeOfBitmap(ref fullScreenEffect1);

                #region override movement patterns

                if (gv.mod.currentArea.directionalOverride1 == "randStraight")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX1 = 0.5f;
                    float defaultOverrideSpeedY1 = 0.5f;
                    int defaultOverrideDelayLimit1 = 15;

                    if (gv.mod.currentArea.overrideSpeedX1 != -100)
                    {
                        defaultOverrideSpeedX1 = gv.mod.currentArea.overrideSpeedX1;
                    }
                    if (gv.mod.currentArea.overrideSpeedY1 != -100)
                    {
                        defaultOverrideSpeedY1 = gv.mod.currentArea.overrideSpeedY1;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit1 != -100)
                    {
                        defaultOverrideDelayLimit1 = gv.mod.currentArea.overrideDelayLimit1;
                    }

                    gv.mod.currentArea.overrideDelayCounter1++;
                    if (gv.mod.currentArea.overrideDelayCounter1 > defaultOverrideDelayLimit1)
                    {

                        gv.mod.currentArea.overrideDelayCounter1 = 0;
                        int rollRandom = gv.sf.RandInt(8);
                        //right
                        if (rollRandom == 1)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = defaultOverrideSpeedX1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = 0.0f;
                        }
                        //left
                        if (rollRandom == 2)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = -defaultOverrideSpeedX1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = 0.0f;
                        }
                        //up
                        if (rollRandom == 3)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = defaultOverrideSpeedY1;
                        }
                        //down
                        if (rollRandom == 4)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = 0.0f;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = -defaultOverrideSpeedY1;
                        }
                        //up right
                        if (rollRandom == 5)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = defaultOverrideSpeedX1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = defaultOverrideSpeedY1;
                        }
                        //upleft
                        if (rollRandom == 6)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = -defaultOverrideSpeedX1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = defaultOverrideSpeedY1;
                        }
                        //downright
                        if (rollRandom == 7)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = defaultOverrideSpeedX1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = -defaultOverrideSpeedY1;
                        }
                        //downleft
                        if (rollRandom == 8)
                        {
                            gv.mod.currentArea.fullScreenAnimationSpeedX1 = -defaultOverrideSpeedX1;
                            gv.mod.currentArea.fullScreenAnimationSpeedY1 = -defaultOverrideSpeedY1;
                        }
                    }
                }

                if (gv.mod.currentArea.directionalOverride1 == "randOrganic")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX1 = 0.5f;
                    float defaultOverrideSpeedY1 = 0.5f;
                    int defaultOverrideDelayLimit1 = 15;

                    if (gv.mod.currentArea.overrideSpeedX1 != -100)
                    {
                        defaultOverrideSpeedX1 = gv.mod.currentArea.overrideSpeedX1;
                    }
                    if (gv.mod.currentArea.overrideSpeedY1 != -100)
                    {
                        defaultOverrideSpeedY1 = gv.mod.currentArea.overrideSpeedY1;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit1 != -100)
                    {
                        defaultOverrideDelayLimit1 = gv.mod.currentArea.overrideDelayLimit1;
                    }

                    gv.mod.currentArea.overrideDelayCounter1++;
                    if (gv.mod.currentArea.overrideDelayCounter1 > defaultOverrideDelayLimit1)
                    {

                        gv.mod.currentArea.overrideDelayCounter1 = 0;
                        //for x
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX1 = ((0.25f * directional) + (decider * defaultOverrideSpeedX1 * 0.5f)) * (0.5f);

                        //for y
                        rollRandom = gv.sf.RandInt(100);
                        rollRandom2 = gv.sf.RandInt(2);
                        directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedY1 = ((0.25f * directional) + (decider * defaultOverrideSpeedY1 * 0.5f)) * (0.5f);
                    }
                }

                if (gv.mod.currentArea.directionalOverride1 == "snow")
                {
                    //set up the default values and allow individiual override based on toolset values
                    float defaultOverrideSpeedX1 = 0.5f;
                    float defaultOverrideSpeedY1 = 0.5f;
                    int defaultOverrideDelayLimit1 = 15;

                    if (gv.mod.currentArea.overrideSpeedX1 != -100)
                    {
                        defaultOverrideSpeedX1 = gv.mod.currentArea.overrideSpeedX1;
                    }
                    if (gv.mod.currentArea.overrideSpeedY1 != -100)
                    {
                        defaultOverrideSpeedY1 = gv.mod.currentArea.overrideSpeedY1;
                    }
                    if (gv.mod.currentArea.overrideDelayLimit1 != -100)
                    {
                        defaultOverrideDelayLimit1 = gv.mod.currentArea.overrideDelayLimit1;
                    }

                    gv.mod.currentArea.overrideDelayCounter1++;
                    if (gv.mod.currentArea.overrideDelayCounter1 > defaultOverrideDelayLimit1)
                    {

                        gv.mod.currentArea.overrideDelayCounter1 = 0;
                        int rollRandom = gv.sf.RandInt(100);
                        int rollRandom2 = gv.sf.RandInt(2);
                        int directional = 1;
                        if (rollRandom2 == 1)
                        {
                            rollRandom = rollRandom * -1;
                            directional = -1;
                        }
                        float decider = rollRandom / 100f;
                        gv.mod.currentArea.fullScreenAnimationSpeedX1 = ((0.25f * directional) + (decider * defaultOverrideSpeedX1 * 0.5f)) * (1.5f);
                        gv.mod.currentArea.fullScreenAnimationSpeedY1 = defaultOverrideSpeedY1;
                    }
                }

                #endregion

                #region limited cycle animation
                //check whether we got an effect that is supposed to happen only once in a while
                if (gv.mod.currentArea.numberOfCyclesPerOccurence1 != 0)
                {

                    //added speed xx
                    float speedComponentX = gv.mod.currentArea.fullScreenAnimationSpeedX1;
                    if (speedComponentX < 0)
                    {
                        speedComponentX *= -1;
                    }
                    float speedComponentY = gv.mod.currentArea.fullScreenAnimationSpeedY1;
                    if (speedComponentY < 0)
                    {
                        speedComponentY *= -1;
                    }
                    gv.mod.currentArea.fullScreenAnimationSpeed1 = speedComponentX + speedComponentY;

                    //based on subjective trial and error
                    if ((gv.mod.currentArea.fullScreenAnimationFrameCounter1 > (50f / (gv.mod.currentArea.fullScreenAnimationSpeed1 * gv.mod.allAnimationSpeedMultiplier) - 1)))
                    {
                        gv.mod.currentArea.cycleCounter1 += 1;
                        gv.mod.currentArea.fullScreenAnimationFrameCounter1 = 0;
                    }

                    //a little extra delay added by on intuition how long a cycle takes here
                    if (gv.mod.currentArea.cycleCounter1 >= (gv.mod.currentArea.numberOfCyclesPerOccurence1))
                    {
                        //turn the animation off, in common code's doudate method a chance per turn is rolled for turning on again
                        gv.mod.currentArea.fullScreenEffectLayerIsActive1 = false;
                        //counts how often/long the aniamtion is displayed before stop
                        gv.mod.currentArea.cycleCounter1 = 0;
                        //just keeping track how often render calls have run through
                        gv.mod.currentArea.fullScreenAnimationFrameCounter1 = 0;
                        //for changing a shape changing anim
                        gv.mod.currentArea.changeCounter1 = 0;
                        //for changing a shape changing anim
                        gv.mod.currentArea.changeFrameCounter1 = 1;
                    }
                }
                #endregion

                if (gv.mod.currentArea.fullScreenEffectLayerIsActive1 == true)
                {
                    float fullScreenEffectOpacity = 1f;
                    #region opacity code
                    if (gv.mod.currentArea.useCyclicFade1)
                    {
                        //fade in within first cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter1 == 0) && (gv.mod.currentArea.numberOfCyclesPerOccurence1 != 0))
                        {
                            fullScreenEffectOpacity = 1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed1 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter1);
                        }

                        //fade out within last cycle of cyclic animation
                        if ((gv.mod.currentArea.cycleCounter1 == (gv.mod.currentArea.numberOfCyclesPerOccurence1 - 1)) && (gv.mod.currentArea.numberOfCyclesPerOccurence1 != 0))
                        {
                            fullScreenEffectOpacity = 1f - (1f / ((50f / ((float)gv.mod.currentArea.fullScreenAnimationSpeed1 * (float)gv.mod.allAnimationSpeedMultiplier)) / (float)gv.mod.currentArea.fullScreenAnimationFrameCounter1));
                        }
                    }
                    #endregion

                    //use weather system per area specific later on
                    //utilizing weather type defined by area weather settings
                    //add check for square specific punch hole that prevents drawing weather, e.g. house inside or spaceship interior

                    #region only for shape changing animation
                    if (gv.mod.currentArea.isChanging1)
                    {
                        gv.mod.currentArea.changeCounter1 += (1 * gv.mod.allAnimationSpeedMultiplier);
                        if (gv.mod.currentArea.changeCounter1 > gv.mod.currentArea.changeLimit1)
                        {
                            gv.mod.currentArea.changeCounter1 = 0;
                            gv.mod.currentArea.changeFrameCounter1 += 1;
                            if (gv.mod.currentArea.changeFrameCounter1 > gv.mod.currentArea.changeNumberOfFrames1)
                            {
                                gv.mod.currentArea.changeFrameCounter1 = 1;
                            }
                        }
                        fullScreenEffect1 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName1 + gv.mod.currentArea.changeFrameCounter1.ToString());
                    }
                    #endregion

                    else
                    {
                        fullScreenEffect1 = gv.cc.LoadBitmap(gv.mod.currentArea.fullScreenEffectLayerName1);
                    }

                    gv.mod.currentArea.fullScreenAnimationFrameCounter1 += 1;

                    #region handle framecounter
                    //assuming a square shaped source here
                    float sizeOfWholeSource = fullScreenEffect1.PixelSize.Width;

                    //reading the frames moved and added up in the last seconds
                    float pixShiftOnThisFrameX = gv.mod.currentArea.fullScreenAnimationFrameCounterX1;
                    float pixShiftOnThisFrameY = gv.mod.currentArea.fullScreenAnimationFrameCounterY1;

                    //increase by this call's movement
                    pixShiftOnThisFrameX += (gv.mod.currentArea.fullScreenAnimationSpeedX1 * gv.mod.allAnimationSpeedMultiplier);
                    pixShiftOnThisFrameY += (gv.mod.currentArea.fullScreenAnimationSpeedY1 * gv.mod.allAnimationSpeedMultiplier);

                    //reset it in case it grwos too large (note: just to avoid an overflow in the far future)
                    //the actual reset happens later below
                    if (pixShiftOnThisFrameX >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY >= ((2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY - ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameX <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameX = pixShiftOnThisFrameX + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    if (pixShiftOnThisFrameY <= ((-2000 * gv.playerOffset) * gv.squareSize))
                    {
                        pixShiftOnThisFrameY = pixShiftOnThisFrameY + ((2000 * gv.playerOffset) * gv.squareSize);
                    }

                    gv.mod.currentArea.fullScreenAnimationFrameCounterX1 = pixShiftOnThisFrameX;
                    gv.mod.currentArea.fullScreenAnimationFrameCounterY1 = pixShiftOnThisFrameY;
                    #endregion

                    #region iterate through the dst tiles
                    for (int x = minX; x < maxX; x++)
                    {
                        for (int y = minY; y < maxY; y++)
                        {
                            Tile tile = mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x];

                            //each tile can block the effects run on the six effect channels, each e.g. simualting shelter from rain
                            if (!tile.blockFullScreenEffectLayer1)
                            {
                                int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                                int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;

                                float scalerX = gv.cc.tileBitmapList[tile.Layer1Filename].PixelSize.Width / 100f;
                                float scalerY = gv.cc.tileBitmapList[tile.Layer1Filename].PixelSize.Height / 100f;
                                float brX = gv.squareSize * scalerX;
                                float brY = gv.squareSize * scalerY;

                                float numberOfPictureParts = gv.playerOffset * 2 + 1;

                                #region is effect contained inside borders or always centered on party?
                                //code section for handling borders of the area
                                int modX = x;
                                int modY = y;
                                int modMinX = minX;
                                int modMinY = minY;

                                if (gv.mod.currentArea.containEffectInsideAreaBorders1)
                                {
                                    //code for for always keeping the effect contained in the area box, break center on player near map border
                                    if ((mod.PlayerLocationX + 4) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 1;
                                    }
                                    if ((mod.PlayerLocationX + 3) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 2;
                                    }
                                    if ((mod.PlayerLocationX + 2) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 3;
                                    }
                                    if ((mod.PlayerLocationX + 1) == this.mod.currentArea.MapSizeX)
                                    {
                                        modX += 4;
                                    }


                                    if ((mod.PlayerLocationY + 4) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 1;
                                    }
                                    if ((mod.PlayerLocationY + 3) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 2;
                                    }
                                    if ((mod.PlayerLocationY + 2) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 3;
                                    }
                                    if ((mod.PlayerLocationY + 1) == this.mod.currentArea.MapSizeY)
                                    {
                                        modY += 4;
                                    }
                                }

                                else
                                {
                                    //code for always centering the effect on player, even near map border (e.g. light source carried by party)
                                    if ((mod.PlayerLocationX - 3) == 0)
                                    {
                                        modMinX = -1;
                                    }
                                    if ((mod.PlayerLocationX - 2) == 0)
                                    {
                                        modMinX = -2;
                                    }
                                    if ((mod.PlayerLocationX - 1) == 0)
                                    {
                                        modMinX = -3;
                                    }
                                    if ((mod.PlayerLocationX) == 0)
                                    {
                                        modMinX = -4;
                                    }


                                    if ((mod.PlayerLocationY - 3) == 0)
                                    {
                                        modMinY = -1;
                                    }
                                    if ((mod.PlayerLocationY - 2) == 0)
                                    {
                                        modMinY = -2;
                                    }
                                    if ((mod.PlayerLocationY - 1) == 0)
                                    {
                                        modMinY = -3;
                                    }
                                    if ((mod.PlayerLocationY) == 0)
                                    {
                                        modMinY = -4;
                                    }
                                }
                                #endregion

                                //get the correct chunk on source
                                //subject to movement of the animation expressed by pixShiftOnThisFrameX/Y
                                float floatSourceChunkCoordX = ((float)(modX - modMinX) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameX;
                                float floatSourceChunkCoordY = ((float)(modY - modMinY) / numberOfPictureParts) * sizeOfWholeSource + pixShiftOnThisFrameY;

                                #region handle border situations on source (bottom and right)     
                                //the following four sections help to set the top left x,y of our square incase we ae close to bottom or right border of source

                                //leave source in negative direction (vertical)
                                if (floatSourceChunkCoordY < 0)
                                {
                                    floatSourceChunkCoordY = (floatSourceChunkCoordY * -1f);
                                    floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                    floatSourceChunkCoordY = sizeOfWholeSource - floatSourceChunkCoordY;
                                }

                                //leave source in positive direction (vertical)
                                if (floatSourceChunkCoordY >= sizeOfWholeSource)
                                {
                                    floatSourceChunkCoordY = floatSourceChunkCoordY % sizeOfWholeSource;
                                }

                                //leave source in negative direction (horizontal)
                                if (floatSourceChunkCoordX < 0)
                                {
                                    floatSourceChunkCoordX = (floatSourceChunkCoordX * -1f);
                                    floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                    floatSourceChunkCoordX = sizeOfWholeSource - floatSourceChunkCoordX;
                                }

                                //leave source in positive direction (horizontal)
                                if (floatSourceChunkCoordX >= sizeOfWholeSource)
                                {
                                    floatSourceChunkCoordX = floatSourceChunkCoordX % sizeOfWholeSource;
                                }
                                #endregion

                                #region handle the four different draw situations, based on position of chunk on source
                                //next task is to actaully draw up to four pieces of  square source to one target dst
                                //let's go through the differdnt situations that can occur

                                #region Situation 1 (complex, 4 to 1)
                                //Situation 1 (most complex): touching four source squares, we are in the far low right corner
                                //there will be two more 2 source square situations, one for x and one for y direction
                                //also there's of course the standard situation that we just need one coherent source
                                if (((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource) && ((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource))
                                {

                                    //need to use parts four source chunks from four different source squares and draw them onto the dst square

                                    //first: top left corner
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: top right corner
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * dstScalerX)), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //third: bottom left corner
                                    float oldHeight = (brY * dstScalerY);
                                    availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldHeight, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //fourth: bottom right corner
                                    oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY + oldHeight, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    continue;

                                }
                                #endregion

                                #region Situation 2 (2 to 1, x near border)
                                //Situation 2: only x is near right border, y is high/small enough
                                else if ((floatSourceChunkCoordX + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource)
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: left hand side
                                    float availableLengthX = sizeOfWholeSource - floatSourceChunkCoordX;
                                    float availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: right hand side
                                    float oldWidth = (brX * dstScalerX);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts) - availableLengthX;
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts);
                                    dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = floatSourceChunkCoordY;
                                    srcCoordX2 = 0;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels + oldWidth, tlY, (brX - (brX * (dstScalerX))), (brY * (dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;

                                }
                                #endregion

                                #region Situation 3 (2 to 1, y near border)
                                //Situation 3: only y is near bottom border, x is left/small enough WIP
                                else if ((floatSourceChunkCoordY + (sizeOfWholeSource / numberOfPictureParts)) >= sizeOfWholeSource)
                                {

                                    //need to use parts of two source chunks from two different source squares and draw them onto the dst square

                                    //first: top square
                                    float availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    float availableLengthY = sizeOfWholeSource - floatSourceChunkCoordY;
                                    float dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    float dstScalerY = availableLengthY / (sizeOfWholeSource / numberOfPictureParts);
                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, (brX * dstScalerX), (brY * dstScalerY));
                                        gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                    //second: bottom square
                                    float oldLength = 0;
                                    oldLength = (float)(brY * dstScalerY);
                                    availableLengthX = (sizeOfWholeSource / numberOfPictureParts);
                                    availableLengthY = (sizeOfWholeSource / numberOfPictureParts) - availableLengthY;
                                    dstScalerX = availableLengthX / (sizeOfWholeSource / numberOfPictureParts);
                                    srcCoordY2 = 0;
                                    srcCoordX2 = floatSourceChunkCoordX;

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, availableLengthX, availableLengthY);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY + oldLength, (brX * dstScalerX), (brY - (brY * dstScalerY)));
                                        gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }
                                    continue;
                                }
                                #endregion

                                #region Situation 4 (default, neither x or y near border)
                                //Situation 4: the default situation, x and y are sufficiently distant from bottom and right border
                                else
                                {

                                    float srcCoordY2 = floatSourceChunkCoordY;
                                    float srcCoordX2 = floatSourceChunkCoordX;
                                    float sizeOfSourceChunk2 = (sizeOfWholeSource / numberOfPictureParts);

                                    try
                                    {
                                        IbRectF src = new IbRectF(srcCoordX2, srcCoordY2, sizeOfSourceChunk2, sizeOfSourceChunk2);
                                        IbRectF dst = new IbRectF(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                                        gv.DrawBitmap(fullScreenEffect1, src, dst, false, false, fullScreenEffectOpacity);
                                    }
                                    catch { }

                                }
                                #endregion

                            }
                        }
                    }
                }
                #endregion
            }
            #endregion
            #endregion
        }

        public void drawMap()
        {
            int srcUX = 0, srcUY = 0, srcDX = 0, srcDY = 0;
            int dstUX = 0, dstUY = 0, dstDX = 0, dstDY = 0;
            int bmpWidth = gv.cc.bmpMap.PixelSize.Width;
            int bmpHeight = gv.cc.bmpMap.PixelSize.Height;
            int mapSquareSize = 50;
            if (mod.PlayerLocationX < gv.playerOffset) //at left edge of map
            {
                srcUX = 0;
                srcDX = ((mod.PlayerLocationX + 1) * mapSquareSize) + (gv.playerOffset * mapSquareSize);
                dstUX = (gv.playerOffset * gv.squareSize) - (mod.PlayerLocationX * gv.squareSize);
                dstDX = dstUX + (int)(srcDX * 2 * gv.screenDensity);
            }
            else if ((mod.PlayerLocationX >= gv.playerOffset) && (mod.PlayerLocationX < (bmpWidth / mapSquareSize) - gv.playerOffset))
            {
                srcUX = (mod.PlayerLocationX * mapSquareSize) - (gv.playerOffset * mapSquareSize);
                srcDX = srcUX + (mapSquareSize * ((gv.playerOffset * 2) + 1));
                dstUX = 0;
                dstDX = gv.squareSize * ((gv.playerOffset * 2) + 1);
            }
            else //mod.PlayerLocationX >= width - 3  //at right edge of map
            {
                srcUX = (mod.PlayerLocationX * mapSquareSize) - (gv.playerOffset * mapSquareSize);
                srcDX = bmpWidth;
                dstUX = 0;
                dstDX = (int)(srcDX * 2 * gv.screenDensity) - (int)(srcUX * 2 * gv.screenDensity);
            }

            if (mod.PlayerLocationY < gv.playerOffset) //at top of map
            {
                srcUY = 0;
                srcDY = ((mod.PlayerLocationY + 1) * mapSquareSize) + (gv.playerOffset * mapSquareSize);
                dstUY = (gv.playerOffset * gv.squareSize) - (mod.PlayerLocationY * gv.squareSize);
                dstDY = dstUY + (int)(srcDY * 2 * gv.screenDensity);
            }
            else if ((mod.PlayerLocationY >= gv.playerOffset) && (mod.PlayerLocationY < (bmpHeight / mapSquareSize) - gv.playerOffset))
            {
                srcUY = (mod.PlayerLocationY * mapSquareSize) - (gv.playerOffset * mapSquareSize);
                srcDY = srcUY + (mapSquareSize * ((gv.playerOffset * 2) + 1));
                dstUY = 0;
                dstDY = gv.squareSize * ((gv.playerOffset * 2) + 1);
            }
            else //mod.PlayerLocationY >= height - 3  //at bottom of map
            {
                srcUY = (mod.PlayerLocationY * mapSquareSize) - (gv.playerOffset * mapSquareSize);
                srcDY = bmpHeight;
                dstUY = 0;
                dstDY = (int)(srcDY * 2 * gv.screenDensity) - (int)(srcUY * 2 * gv.screenDensity);
            }

            IbRect src = new IbRect(srcUX, srcUY, srcDX - srcUX, srcDY - srcUY);
            IbRect dst = new IbRect(dstUX + gv.oXshift + mapStartLocXinPixels, dstUY, dstDX - dstUX, dstDY - dstUY);
            gv.DrawBitmap(gv.cc.bmpMap, src, dst);
        }
        public void drawProps()
        {
            foreach (Prop p in mod.currentArea.Props)
            {
                if ((p.isShown) && (!p.isMover))
                {
                    if ((p.LocationX >= mod.PlayerLocationX - gv.playerOffset) && (p.LocationX <= mod.PlayerLocationX + gv.playerOffset)
                        && (p.LocationY >= mod.PlayerLocationY - gv.playerOffset) && (p.LocationY <= mod.PlayerLocationY + gv.playerOffset))
                    {
                        //prop X - playerX
                        int x = ((p.LocationX - mod.PlayerLocationX) * gv.squareSize) + (gv.playerOffset * gv.squareSize);
                        int y = ((p.LocationY - mod.PlayerLocationY) * gv.squareSize) + (gv.playerOffset * gv.squareSize);
                        int dstW = (int)(((float)p.token.PixelSize.Width / (float)gv.squareSizeInPixels) * (float)gv.squareSize);
                        int dstH = (int)(((float)p.token.PixelSize.Height / (float)gv.squareSizeInPixels) * (float)gv.squareSize);
                        int dstXshift = (dstW - gv.squareSize) / 2;
                        int dstYshift = (dstH - gv.squareSize) / 2;
                        IbRect src = new IbRect(0, 0, p.token.PixelSize.Width, p.token.PixelSize.Width);
                        IbRect dst = new IbRect(x + gv.oXshift + mapStartLocXinPixels - dstXshift, y - dstYshift, dstW, dstH);

                        if (gv.mod.currentArea.useSuperTinyProps)
                        {
                            dst = new IbRect((int)p.currentPixelPositionX + (int)(gv.squareSize * 3 / 8) - dstXshift, (int)p.currentPixelPositionY + (int)(gv.squareSize * 3 / 8) - dstYshift, (int)(dstW / 4), (int)(dstH / 4));
                        }
                        else if (gv.mod.currentArea.useMiniProps)
                        {
                            dst = new IbRect((int)p.currentPixelPositionX + (int)(gv.squareSize / 4) - dstXshift, (int)p.currentPixelPositionY + (int)(gv.squareSize / 4) - dstYshift, (int)(dstW / 2), (int)(dstH / 2));
                        }

                        gv.DrawBitmap(p.token, src, dst, !p.PropFacingLeft, false);

                        if (mod.showInteractionState == true)
                        {
                            if (!p.EncounterWhenOnPartySquare.Equals("none"))
                            {
                                Bitmap interactionStateIndicator = gv.cc.LoadBitmap("encounter_indicator");
                                src = new IbRect(0, 0, interactionStateIndicator.PixelSize.Width, interactionStateIndicator.PixelSize.Height);
                                gv.DrawBitmap(interactionStateIndicator, src, dst);
                                gv.cc.DisposeOfBitmap(ref interactionStateIndicator); 
                                continue;
                            }

                            if (p.unavoidableConversation)
                            {
                                Bitmap interactionStateIndicator = gv.cc.LoadBitmap("mandatory_conversation_indicator");
                                src = new IbRect(0, 0, interactionStateIndicator.PixelSize.Width, interactionStateIndicator.PixelSize.Height);
                                gv.DrawBitmap(interactionStateIndicator, src, dst);
                                gv.cc.DisposeOfBitmap(ref interactionStateIndicator);
                                continue;
                            }

                            if (!p.ConversationWhenOnPartySquare.Equals("none"))
                            {
                                Bitmap interactionStateIndicator = gv.cc.LoadBitmap("optional_conversation_indicator");
                                src = new IbRect(0, 0, interactionStateIndicator.PixelSize.Width, interactionStateIndicator.PixelSize.Height);
                                gv.DrawBitmap(interactionStateIndicator, src, dst);
                                gv.cc.DisposeOfBitmap(ref interactionStateIndicator);
                                continue;
                            }
                        }
                    }
                }
            }
        }
        public void drawMovingProps()
        {
            if (mod.useSmoothMovement == true)
            {
                foreach (Prop p in mod.currentArea.Props)
                {
                    if ((p.isShown) && (p.isMover))
                    {
                        if ((p.LocationX + 1 >= mod.PlayerLocationX - gv.playerOffset) && (p.LocationX - 1 <= mod.PlayerLocationX + gv.playerOffset)
                            && (p.LocationY + 1 >= mod.PlayerLocationY - gv.playerOffset) && (p.LocationY - 1 <= mod.PlayerLocationY + gv.playerOffset))
                        {
                            IbRect src = new IbRect(0, 0, p.token.PixelSize.Width, p.token.PixelSize.Width);
                            if (p.destinationPixelPositionXList.Count > 0)
                            {
                                if ((p.destinationPixelPositionXList[0] >= (p.currentPixelPositionX - 0)) && (p.destinationPixelPositionXList[0] <= (p.currentPixelPositionX + 0)))
                                {
                                    if (p.destinationPixelPositionYList[0] > p.currentPixelPositionY)
                                    {
                                        p.currentPixelPositionY += (gv.floatPixMovedPerTick * p.pixelMoveSpeed);
                                        if (p.currentPixelPositionY >= p.destinationPixelPositionYList[0])
                                        {
                                            p.currentPixelPositionY = p.destinationPixelPositionYList[0];
                                            p.destinationPixelPositionYList.RemoveAt(0);
                                            p.destinationPixelPositionXList.RemoveAt(0);
                                            
                                        }
                                    }
                                    else
                                    {
                                        p.currentPixelPositionY -= (gv.floatPixMovedPerTick * p.pixelMoveSpeed);
                                        if (p.currentPixelPositionY <= p.destinationPixelPositionYList[0])
                                        {
                                            p.currentPixelPositionY = p.destinationPixelPositionYList[0];
                                            p.destinationPixelPositionYList.RemoveAt(0);
                                            p.destinationPixelPositionXList.RemoveAt(0);
                                        }

                                    }
                                }
                                else if ((p.destinationPixelPositionYList[0] >= (p.currentPixelPositionY - 0)) && (p.destinationPixelPositionYList[0] <= (p.currentPixelPositionY + 0)))
                                {
                                    {
                                        if (p.destinationPixelPositionXList[0] > p.currentPixelPositionX)
                                        {
                                            p.currentPixelPositionX += (gv.floatPixMovedPerTick * p.pixelMoveSpeed);
                                            if (p.currentPixelPositionX >= p.destinationPixelPositionXList[0])
                                            {
                                                p.currentPixelPositionX = p.destinationPixelPositionXList[0];
                                                p.destinationPixelPositionXList.RemoveAt(0);
                                                p.destinationPixelPositionYList.RemoveAt(0);
                                            }
                                        }
                                        else
                                        {
                                            p.currentPixelPositionX -= (gv.floatPixMovedPerTick * p.pixelMoveSpeed);
                                            if (p.currentPixelPositionX <= p.destinationPixelPositionXList[0])
                                            {
                                                p.currentPixelPositionX = p.destinationPixelPositionXList[0];
                                                p.destinationPixelPositionXList.RemoveAt(0);
                                                p.destinationPixelPositionYList.RemoveAt(0);
                                            }                                   
                                        }
                                    }
                                }

                            }//end, set dst

                            int playerPositionXInPix = 0;
                            int playerPositionYInPix = 0;

                            if (p.destinationPixelPositionXList.Count <= 0)
                            {
                                p.destinationPixelPositionXList.Clear();
                                p.destinationPixelPositionXList = new List<int>();
                                p.destinationPixelPositionYList.Clear();
                                p.destinationPixelPositionYList = new List<int>();

                                //set the currentPixel position of the props
                                int xOffSetInSquares = p.LocationX - gv.mod.PlayerLocationX;
                                int yOffSetInSquares = p.LocationY - gv.mod.PlayerLocationY;
                                 playerPositionXInPix = gv.oXshift + gv.screenMainMap.mapStartLocXinPixels + (gv.playerOffset * gv.squareSize);
                                playerPositionYInPix = gv.playerOffset * gv.squareSize;

                                p.currentPixelPositionX = playerPositionXInPix + (xOffSetInSquares * gv.squareSize);
                                p.currentPixelPositionY = playerPositionYInPix + (yOffSetInSquares * gv.squareSize);
                            }


                            playerPositionXInPix = gv.oXshift + gv.screenMainMap.mapStartLocXinPixels + (gv.playerOffset * gv.squareSize);
                            playerPositionYInPix = gv.playerOffset * gv.squareSize + gv.oYshift;

                            float floatConvertedToSquareDistanceX = (p.currentPixelPositionX - playerPositionXInPix) / gv.squareSize;
                            int ConvertedToSquareDistanceX = (int)Math.Ceiling(floatConvertedToSquareDistanceX);

                            float floatConvertedToSquareDistanceY = (p.currentPixelPositionY - playerPositionYInPix) / gv.squareSize;
                            int ConvertedToSquareDistanceY = (int)Math.Ceiling(floatConvertedToSquareDistanceY);

                            int SquareThatPixIsOnX = mod.PlayerLocationX + ConvertedToSquareDistanceX;
                            int SquareThatPixIsOnY = mod.PlayerLocationY + ConvertedToSquareDistanceY;

                            int tileNumberOfPropSquare = SquareThatPixIsOnX + (SquareThatPixIsOnY * gv.mod.currentArea.MapSizeX);

                            //cast the pix position to int in order to draw it at nearly exact loc
                            int pixDistanceOfPropToPlayerX = ((int)p.currentPixelPositionX - playerPositionXInPix);
                            if (pixDistanceOfPropToPlayerX < 0)
                            {
                                pixDistanceOfPropToPlayerX *= -1;
                            }
                            int pixDistanceOfPropToPlayerY = ((int)p.currentPixelPositionY - playerPositionYInPix);
                            if (pixDistanceOfPropToPlayerY < 0)
                            {
                                pixDistanceOfPropToPlayerY *= -1;
                            }

                            if ((pixDistanceOfPropToPlayerX <= ((gv.playerOffset + 1) * gv.squareSize)) && (pixDistanceOfPropToPlayerY <= ((gv.playerOffset + 1) * gv.squareSize)))
                            {
                                int dstW = (int)(((float)p.token.PixelSize.Width / (float)gv.squareSizeInPixels) * (float)gv.squareSize);
                                int dstH = (int)(((float)p.token.PixelSize.Height / (float)gv.squareSizeInPixels) * (float)gv.squareSize);
                                int dstXshift = (dstW - gv.squareSize) / 2;
                                int dstYshift = (dstH - gv.squareSize) / 2;
                                IbRect dst = new IbRect((int)p.currentPixelPositionX - dstXshift, (int)p.currentPixelPositionY - dstYshift, dstW, dstH);

                                if (gv.mod.currentArea.useSuperTinyProps)
                                {
                                    dst = new IbRect((int)p.currentPixelPositionX + (int)(gv.squareSize * 3 /8) - dstXshift, (int)p.currentPixelPositionY + (int)(gv.squareSize * 3 / 8) - dstYshift, (int)(dstW / 4), (int)(dstH / 4));
                                }
                                else if (gv.mod.currentArea.useMiniProps)
                                {
                                    dst = new IbRect((int)p.currentPixelPositionX + (int)(gv.squareSize / 4) - dstXshift, (int)p.currentPixelPositionY + (int)(gv.squareSize / 4) - dstYshift, (int)(dstW / 2), (int)(dstH / 2));
                                }

                                gv.DrawBitmap(p.token, src, dst);

                                if (mod.showInteractionState == true)
                                {
                                    if (!p.EncounterWhenOnPartySquare.Equals("none"))
                                    {
                                        Bitmap interactionStateIndicator = gv.cc.LoadBitmap("encounter_indicator");
                                        src = new IbRect(0, 0, interactionStateIndicator.PixelSize.Width, interactionStateIndicator.PixelSize.Height);
                                        gv.DrawBitmap(interactionStateIndicator, src, dst);
                                        gv.cc.DisposeOfBitmap(ref interactionStateIndicator);
                                        continue;
                                    }

                                    if (p.unavoidableConversation)
                                    {
                                        Bitmap interactionStateIndicator = gv.cc.LoadBitmap("mandatory_conversation_indicator");
                                        src = new IbRect(0, 0, interactionStateIndicator.PixelSize.Width, interactionStateIndicator.PixelSize.Height);
                                        gv.DrawBitmap(interactionStateIndicator, src, dst);
                                        gv.cc.DisposeOfBitmap(ref interactionStateIndicator);
                                        continue;
                                    }

                                    if (!p.ConversationWhenOnPartySquare.Equals("none"))
                                    {
                                        Bitmap interactionStateIndicator = gv.cc.LoadBitmap("optional_conversation_indicator");
                                        src = new IbRect(0, 0, interactionStateIndicator.PixelSize.Width, interactionStateIndicator.PixelSize.Height);
                                        gv.DrawBitmap(interactionStateIndicator, src, dst);
                                        gv.cc.DisposeOfBitmap(ref interactionStateIndicator);
                                        continue;
                                    }
                                }
                            }

                        }
                    }
                }
                for (int i = 0; i < mod.currentArea.Tiles.Count; i++)
                {

                    float floatPositionY = i / mod.currentArea.MapSizeX;
                    int positionY = (int)Math.Floor(floatPositionY);
                    int positionX = i % mod.currentArea.MapSizeY;
                    int dist = 0;
                    int deltaX = (int)Math.Abs((positionX - mod.PlayerLocationX));
                    int deltaY = (int)Math.Abs((positionY - mod.PlayerLocationY));
                    if (deltaX > deltaY)
                    {
                        dist = deltaX;
                    }
                    else
                    {
                        dist = deltaY;
                    }
                    if ((dist == (gv.playerOffset + 1)) || (dist == (gv.playerOffset + 2)))
                    {
                        int squareInPixelsX = ((positionX - mod.PlayerLocationX) * gv.squareSize) + gv.oXshift + gv.screenMainMap.mapStartLocXinPixels + (gv.playerOffset * gv.squareSize);
                        int squareInPixelsY = ((positionY - mod.PlayerLocationY) * gv.squareSize) + (gv.playerOffset * gv.squareSize);
                        IbRect src2 = new IbRect(0, 0, gv.squareSize, gv.squareSize);
                        IbRect dst2 = new IbRect(squareInPixelsX, squareInPixelsY, gv.squareSize, gv.squareSize);
                        gv.DrawBitmap(gv.cc.black_tile, src2, dst2);
                    }
                }

            }
            else
            {
                foreach (Prop p in mod.currentArea.Props)
                {
                    if ((p.isShown) && (p.isMover))
                    {
                        if ((p.LocationX >= mod.PlayerLocationX - gv.playerOffset) && (p.LocationX <= mod.PlayerLocationX + gv.playerOffset)
                            && (p.LocationY >= mod.PlayerLocationY - gv.playerOffset) && (p.LocationY <= mod.PlayerLocationY + gv.playerOffset))
                        {
                            //prop X - playerX
                            int x = ((p.LocationX - mod.PlayerLocationX) * gv.squareSize) + (gv.playerOffset * gv.squareSize);
                            int y = ((p.LocationY - mod.PlayerLocationY) * gv.squareSize) + (gv.playerOffset * gv.squareSize);
                            int dstW = (int)(((float)p.token.PixelSize.Width / (float)gv.squareSizeInPixels) * (float)gv.squareSize);
                            int dstH = (int)(((float)p.token.PixelSize.Height / (float)gv.squareSizeInPixels) * (float)gv.squareSize);
                            int dstXshift = (dstW - gv.squareSize) / 2;
                            int dstYshift = (dstH - gv.squareSize) / 2;
                            IbRect src = new IbRect(0, 0, p.token.PixelSize.Width, p.token.PixelSize.Width);
                            IbRect dst = new IbRect(x + gv.oXshift + mapStartLocXinPixels - dstXshift, y - dstYshift, dstW, dstH);
                            gv.DrawBitmap(p.token, src, dst);

                            if (mod.showInteractionState)
                            {
                                if (!p.EncounterWhenOnPartySquare.Equals("none"))
                                {
                                    Bitmap interactionStateIndicator = gv.cc.LoadBitmap("encounter_indicator");
                                    src = new IbRect(0, 0, interactionStateIndicator.PixelSize.Width, interactionStateIndicator.PixelSize.Height);
                                    gv.DrawBitmap(interactionStateIndicator, src, dst);
                                    gv.cc.DisposeOfBitmap(ref interactionStateIndicator);
                                    continue;
                                }

                                if (p.unavoidableConversation)
                                {
                                    Bitmap interactionStateIndicator = gv.cc.LoadBitmap("mandatory_conversation_indicator");
                                    src = new IbRect(0, 0, interactionStateIndicator.PixelSize.Width, interactionStateIndicator.PixelSize.Height);
                                    gv.DrawBitmap(interactionStateIndicator, src, dst);
                                    gv.cc.DisposeOfBitmap(ref interactionStateIndicator);
                                    continue;
                                }

                                if (!p.ConversationWhenOnPartySquare.Equals("none"))
                                {
                                    Bitmap interactionStateIndicator = gv.cc.LoadBitmap("optional_conversation_indicator");
                                    src = new IbRect(0, 0, interactionStateIndicator.PixelSize.Width, interactionStateIndicator.PixelSize.Height);
                                    gv.DrawBitmap(interactionStateIndicator, src, dst);
                                    gv.cc.DisposeOfBitmap(ref interactionStateIndicator);
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }
        public void drawMiniMap()
        {
            //if ((mod.currentArea.IsWorldMap) && (tglMiniMap.toggleOn))
            if (tglMiniMap.toggleOn)
            {
                int pW = (int)((float)gv.screenWidth / 100.0f);
                int pH = (int)((float)gv.screenHeight / 100.0f);
                int shift = pW;
                //Bitmap minimap = gv.cc.LoadBitmap(mod.currentArea.Filename);

                //minimap should be 4 squares wide
                int minimapSquareSizeInPixels = 4 * gv.squareSize / mod.currentArea.MapSizeX;
                int drawW = minimapSquareSizeInPixels * mod.currentArea.MapSizeX;
                int drawH = minimapSquareSizeInPixels * mod.currentArea.MapSizeY;

                //int mapSqrX = minimap.PixelSize.Width / 5;
                //int mapSqrY = minimap.PixelSize.Height / 5;
                //int drawW = mapSqrX * pW / 2;
                //int drawH = mapSqrY * pW / 2;
                /*TODO
                    //draw a dark border
                    Paint pnt = new Paint();
                    pnt.setColor(Color.DKGRAY);
                    pnt.setStrokeWidth(pW * 2);
                    pnt.setStyle(Paint.Style.STROKE);	
                    canvas.drawRect(new Rect(gv.oXshift, pH, gv.oXshift + drawW + pW, pH + drawH + pW), pnt);
                */
                //draw minimap
                if (minimap == null) { resetMiniMapBitmap(); }
                IbRect src = new IbRect(0, 0, minimap.PixelSize.Width, minimap.PixelSize.Height);
                IbRect dst = new IbRect(pW, pH, drawW, drawH);
                gv.DrawBitmap(minimap, src, dst);

                //draw Fog of War
                if (mod.currentArea.UseMiniMapFogOfWar)
                {
                    for (int x = 0; x < this.mod.currentArea.MapSizeX; x++)
                    {
                        for (int y = 0; y < this.mod.currentArea.MapSizeY; y++)
                        {
                            int xx = x * minimapSquareSizeInPixels;
                            int yy = y * minimapSquareSizeInPixels;
                            src = new IbRect(0, 0, gv.cc.black_tile.PixelSize.Width, gv.cc.black_tile.PixelSize.Height);
                            dst = new IbRect(pW + xx, pH + yy, minimapSquareSizeInPixels, minimapSquareSizeInPixels);
                            if (!mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x].Visible)
                            {
                                gv.DrawBitmap(gv.cc.black_tile, src, dst);
                            }
                        }
                    }
                }
                                
	            //draw a location marker square RED
                int x2 = mod.PlayerLocationX * minimapSquareSizeInPixels;
                int y2 = mod.PlayerLocationY * minimapSquareSizeInPixels;
                src = new IbRect(0, 0, gv.cc.pc_dead.PixelSize.Width, gv.cc.pc_dead.PixelSize.Height);
                dst = new IbRect(pW + x2, pH + y2, minimapSquareSizeInPixels, minimapSquareSizeInPixels);
                gv.DrawBitmap(gv.cc.pc_dead, src, dst);	            
            }
        }

        public void drawPlayer()
        {
            if (mod.selectedPartyLeader >= mod.playerList.Count)
            {
                mod.selectedPartyLeader = 0;
            }
            int x = gv.playerOffset * gv.squareSize;
            int y = gv.playerOffset * gv.squareSize;
            int shift = gv.squareSize / 3;
            if (mod.currentArea.useMiniProps)
            {
                shift = (int)shift / 2;
            }
            else if (mod.currentArea.useSuperTinyProps)
            {
                shift = (int)shift / 4;
            }
                IbRect src = new IbRect(0, 0, mod.playerList[mod.selectedPartyLeader].token.PixelSize.Width, mod.playerList[mod.selectedPartyLeader].token.PixelSize.Width);
            IbRect dst = new IbRect(x + gv.oXshift + mapStartLocXinPixels, y, gv.squareSize, gv.squareSize);
            if (mod.showPartyToken)
            {

                if (mod.currentArea.useMiniProps)
                {
                    dst.Top += (int)(gv.squareSize * 1 / 8);
                    if (mod.playerList[mod.selectedPartyLeader].combatFacingLeft == true)
                    {
                        dst.Left += (int)(gv.squareSize / 4);
                    }
                    else
                    {
                        dst.Left -= (int)(gv.squareSize / 4);
                    }
                    dst.Height -= (int)(dst.Height / 2);
                    dst.Width -= (int)(dst.Width / 2);

                    /*dst.Top += (int)(gv.squareSize / 4);
                    dst.Left += (int)(gv.squareSize / 4);
                    dst.Height -= (int)(dst.Height / 2);
                    dst.Width -= (int)(dst.Width / 2);*/
                }
                else if (mod.currentArea.useSuperTinyProps)
                {
                    dst.Top += (int)(gv.squareSize * 1 / 8);
                    if (mod.playerList[mod.selectedPartyLeader].combatFacingLeft == true)
                    {
                        dst.Left += (int)(gv.squareSize * 3 / 8);
                    }
                    else
                    {
                        dst.Left -= (int)(gv.squareSize * 3 / 8);
                    }
                    dst.Height -= (int)(dst.Height * 3 / 4);
                    dst.Width -= (int)(dst.Width * 3 / 4);

                    /*dst.Top += (int)(gv.squareSize * 3 / 8);
                    dst.Left += (int)(gv.squareSize * 3 / 8);
                    dst.Height -= (int)(dst.Height / 4);
                    dst.Width -= (int)(dst.Width / 4);*/
                }

                gv.DrawBitmap(mod.partyTokenBitmap, src, dst, !mod.playerList[0].combatFacingLeft, false);
            }
            else
            {
                if ((tglFullParty.toggleOn) && (mod.playerList.Count > 1))
                {
                    if (mod.playerList[0].combatFacingLeft == true)
                    {
                        gv.oXshift = gv.oXshift + shift / 2;
                    }
                    else
                    {
                        gv.oXshift = gv.oXshift - shift / 2;
                    }
                    //gv.squareSize = gv.squareSize * 2 / 3;
                    int reducedSquareSize = gv.squareSize * 2 / 3;
                    for (int i = mod.playerList.Count - 1; i >= 0; i--)
                    {
                        if ((i == 0) && (i != mod.selectedPartyLeader))
                        {
                            dst = new IbRect(x + gv.oXshift + shift + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);

                            if (mod.currentArea.useMiniProps)
                            {
                                dst.Top += (int)(gv.squareSize * 1 / 8);
                                if (mod.playerList[mod.selectedPartyLeader].combatFacingLeft == true)
                                {
                                    dst.Left += (int)(gv.squareSize / 4);
                                }
                                else
                                {
                                    dst.Left -= (int)(gv.squareSize / 4);
                                }
                                dst.Height -= (int)(dst.Height / 2);
                                dst.Width -= (int)(dst.Width / 2);
                            }
                            else if (mod.currentArea.useSuperTinyProps)
                            {
                                dst.Top += (int)(gv.squareSize * 1 / 8);
                                if (mod.playerList[mod.selectedPartyLeader].combatFacingLeft == true)
                                {
                                    dst.Left += (int)(gv.squareSize * 3 / 8);
                                }
                                else
                                {
                                    dst.Left -= (int)(gv.squareSize * 3 / 8);
                                }
                                dst.Height -= (int)(dst.Height * 3 / 4);
                                dst.Width -= (int)(dst.Width * 3 / 4);
                            }

                            gv.DrawBitmap(mod.playerList[i].token, src, dst, !mod.playerList[i].combatFacingLeft, false);
                        }
                        if ((i == 1) && (i != mod.selectedPartyLeader))
                        {
                            dst = new IbRect(x + gv.oXshift - shift + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);

                            if (mod.currentArea.useMiniProps)
                            {
                                dst.Top += (int)(gv.squareSize * 1 / 8);
                                if (mod.playerList[mod.selectedPartyLeader].combatFacingLeft == true)
                                {
                                    dst.Left += (int)(gv.squareSize / 4);
                                }
                                else
                                {
                                    dst.Left -= (int)(gv.squareSize / 4);
                                }
                                dst.Height -= (int)(dst.Height / 2);
                                dst.Width -= (int)(dst.Width / 2);
                            }

                            else if (mod.currentArea.useSuperTinyProps)
                            {
                                dst.Top += (int)(gv.squareSize * 1 / 8);
                                if (mod.playerList[mod.selectedPartyLeader].combatFacingLeft == true)
                                {
                                    dst.Left += (int)(gv.squareSize * 3 / 8);
                                }
                                else
                                {
                                    dst.Left -= (int)(gv.squareSize * 3 / 8);
                                }
                                dst.Height -= (int)(dst.Height * 3 / 4);
                                dst.Width -= (int)(dst.Width * 3 / 4);
                            }

                            gv.DrawBitmap(mod.playerList[i].token, src, dst, !mod.playerList[i].combatFacingLeft, false);
                        }
                        if ((i == 2) && (i != mod.selectedPartyLeader))
                        {
                            if (mod.selectedPartyLeader == 0)
                            {
                                dst = new IbRect(x + gv.oXshift + (shift) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }
                            else if (mod.selectedPartyLeader == 1)
                            {
                                dst = new IbRect(x + gv.oXshift - (shift) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }
                            else
                            {
                                dst = new IbRect(x + gv.oXshift + (shift * 175 / 100) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }

                            if (mod.currentArea.useMiniProps)
                            {
                                    dst.Top += (int)(gv.squareSize * 1 / 8);
                                    if (mod.playerList[mod.selectedPartyLeader].combatFacingLeft == true)
                                    {
                                        dst.Left += (int)(gv.squareSize / 4);
                                    }
                                    else
                                    {
                                        dst.Left -= (int)(gv.squareSize / 4);
                                    }
                                    dst.Height -= (int)(dst.Height / 2);
                                    dst.Width -= (int)(dst.Width / 2);
                                }
                            else if (mod.currentArea.useSuperTinyProps)
                            {
                                dst.Top += (int)(gv.squareSize * 1 / 8);
                                if (mod.playerList[mod.selectedPartyLeader].combatFacingLeft == true)
                                {
                                    dst.Left += (int)(gv.squareSize * 3 / 8);
                                }
                                else
                                {
                                    dst.Left -= (int)(gv.squareSize * 3 / 8);
                                }
                                dst.Height -= (int)(dst.Height * 3 / 4);
                                dst.Width -= (int)(dst.Width * 3 / 4);
                            }

                            gv.DrawBitmap(mod.playerList[i].token, src, dst, !mod.playerList[i].combatFacingLeft, false);
                        }
                        if ((i == 3) && (i != mod.selectedPartyLeader))
                        {

                            if (mod.selectedPartyLeader == 0)
                            {
                                dst = new IbRect(x + gv.oXshift + (shift * 175 / 100) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }
                            else if (mod.selectedPartyLeader == 1)
                            {
                                dst = new IbRect(x + gv.oXshift + (shift * 175 / 100) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }
                            else if (mod.selectedPartyLeader == 2)
                            {
                                dst = new IbRect(x + gv.oXshift + (shift * 175 / 100) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }
                            else
                            {
                                dst = new IbRect(x + gv.oXshift - (shift * 175 / 100) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }

                            if (mod.currentArea.useMiniProps)
                            {
                                    dst.Top += (int)(gv.squareSize * 1 / 8);
                                    if (mod.playerList[mod.selectedPartyLeader].combatFacingLeft == true)
                                    {
                                        dst.Left += (int)(gv.squareSize / 4);
                                    }
                                    else
                                    {
                                        dst.Left -= (int)(gv.squareSize / 4);
                                    }
                                    dst.Height -= (int)(dst.Height / 2);
                                    dst.Width -= (int)(dst.Width / 2);
                                }
                            else if (mod.currentArea.useSuperTinyProps)
                            {
                                dst.Top += (int)(gv.squareSize * 1 / 8);
                                if (mod.playerList[mod.selectedPartyLeader].combatFacingLeft == true)
                                {
                                    dst.Left += (int)(gv.squareSize * 3 / 8);
                                }
                                else
                                {
                                    dst.Left -= (int)(gv.squareSize * 3 / 8);
                                }
                                dst.Height -= (int)(dst.Height * 3 / 4);
                                dst.Width -= (int)(dst.Width * 3 / 4);
                            }

                            gv.DrawBitmap(mod.playerList[i].token, src, dst, !mod.playerList[i].combatFacingLeft, false);
                        }
                        if ((i == 4) && (i != mod.selectedPartyLeader))
                        {
                            if (mod.selectedPartyLeader == 0)
                            {
                                dst = new IbRect(x + gv.oXshift - (shift * 175 / 100) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }
                            else if (mod.selectedPartyLeader == 1)
                            {
                                dst = new IbRect(x + gv.oXshift - (shift * 175 / 100) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }
                            else if (mod.selectedPartyLeader == 2)
                            {
                                dst = new IbRect(x + gv.oXshift - (shift * 175 / 100) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }
                            else if (mod.selectedPartyLeader == 3)
                            {
                                dst = new IbRect(x + gv.oXshift - (shift * 175 / 100) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }
                            else
                            {
                                dst = new IbRect(x + gv.oXshift + (shift * 250 / 100) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }

                            if (mod.currentArea.useMiniProps)
                            {
                                    dst.Top += (int)(gv.squareSize * 1 / 8);
                                    if (mod.playerList[mod.selectedPartyLeader].combatFacingLeft == true)
                                    {
                                        dst.Left += (int)(gv.squareSize / 4);
                                    }
                                    else
                                    {
                                        dst.Left -= (int)(gv.squareSize / 4);
                                    }
                                    dst.Height -= (int)(dst.Height / 2);
                                    dst.Width -= (int)(dst.Width / 2);
                                }
                            else if (mod.currentArea.useSuperTinyProps)
                            {
                                dst.Top += (int)(gv.squareSize * 1 / 8);
                                if (mod.playerList[mod.selectedPartyLeader].combatFacingLeft == true)
                                {
                                    dst.Left += (int)(gv.squareSize * 3 / 8);
                                }
                                else
                                {
                                    dst.Left -= (int)(gv.squareSize * 3 / 8);
                                }
                                dst.Height -= (int)(dst.Height * 3 / 4);
                                dst.Width -= (int)(dst.Width * 3 / 4);
                            }

                            gv.DrawBitmap(mod.playerList[i].token, src, dst, !mod.playerList[i].combatFacingLeft, false);
                        }

                        if ((i == 5) && (i != mod.selectedPartyLeader))
                        {
                            if (mod.selectedPartyLeader == 0)
                            {
                                dst = new IbRect(x + gv.oXshift + (shift * 250 / 100) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }
                            else if (mod.selectedPartyLeader == 1)
                            {
                                dst = new IbRect(x + gv.oXshift + (shift * 250 / 100) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }
                            else if (mod.selectedPartyLeader == 2)
                            {
                                dst = new IbRect(x + gv.oXshift + (shift * 250 / 100) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }
                            else if (mod.selectedPartyLeader == 3)
                            {
                                dst = new IbRect(x + gv.oXshift + (shift * 250 / 100) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }
                            else if (mod.selectedPartyLeader == 4)
                            {
                                dst = new IbRect(x + gv.oXshift + (shift * 250 / 100) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }
                            else
                            {
                                dst = new IbRect(x + gv.oXshift - (shift * 250 / 100) + mapStartLocXinPixels, y + reducedSquareSize * 47 / 100, reducedSquareSize, reducedSquareSize);
                            }

                            if (mod.currentArea.useMiniProps)
                            {
                                    dst.Top += (int)(gv.squareSize * 1 / 8);
                                    if (mod.playerList[mod.selectedPartyLeader].combatFacingLeft == true)
                                    {
                                        dst.Left += (int)(gv.squareSize / 4);
                                    }
                                    else
                                    {
                                        dst.Left -= (int)(gv.squareSize / 4);
                                    }
                                    dst.Height -= (int)(dst.Height / 2);
                                    dst.Width -= (int)(dst.Width / 2);
                                }
                            else if (mod.currentArea.useSuperTinyProps)
                            {
                                dst.Top += (int)(gv.squareSize * 1 / 8);
                                if (mod.playerList[mod.selectedPartyLeader].combatFacingLeft == true)
                                {
                                    dst.Left += (int)(gv.squareSize * 3 / 8);
                                }
                                else
                                {
                                    dst.Left -= (int)(gv.squareSize * 3 / 8);
                                }
                                dst.Height -= (int)(dst.Height * 3 / 4);
                                dst.Width -= (int)(dst.Width * 3 / 4);
                            }

                            gv.DrawBitmap(mod.playerList[i].token, src, dst, !mod.playerList[i].combatFacingLeft, false);
                        }
                    }
                    //gv.squareSize = gv.squareSize * 3 / 2;

                    if (mod.playerList[0].combatFacingLeft == true)
                    {
                        gv.oXshift = gv.oXshift - shift / 2;
                    }
                    else
                    {
                        gv.oXshift = gv.oXshift + shift / 2;
                        //if (mod.currentArea.useMiniProps)
                        //{
                        //gv.oXshift -= gv.squareSize;
                        //}
                        //else if (mod.currentArea.useSuperTinyProps)
                        //{

                        //}

                    }

                    //gv.oXshift = gv.oXshift + shift / 2;
                }
                //always draw party leader on top
                int storeShift = shift;
                shift = 0;
                if (mod.selectedPartyLeader == 0)
                {
                    if (tglFullParty.toggleOn)
                    {
                        dst = new IbRect(x + gv.oXshift + mapStartLocXinPixels, y, gv.squareSize, gv.squareSize);
                    }
                    else
                    {
                        dst = new IbRect(x + gv.oXshift + mapStartLocXinPixels, y, gv.squareSize, gv.squareSize);
                    }
                    //gv.DrawBitmap(mod.playerList[mod.selectedPartyLeader].token, src, dst, !mod.playerList[mod.selectedPartyLeader].combatFacingLeft, false);
                }
                else if (mod.selectedPartyLeader == 1)
                {
                    if (tglFullParty.toggleOn)
                    {
                        dst = new IbRect(x + gv.oXshift + shift + mapStartLocXinPixels, y, gv.squareSize, gv.squareSize);
                    }
                    else
                    {
                        dst = new IbRect(x + gv.oXshift + mapStartLocXinPixels, y, gv.squareSize, gv.squareSize);
                    }
                    //gv.DrawBitmap(mod.playerList[mod.selectedPartyLeader].token, src, dst, !mod.playerList[mod.selectedPartyLeader].combatFacingLeft, false);
                }
                else if (mod.selectedPartyLeader == 2)
                {
                    if (tglFullParty.toggleOn)
                    {
                        dst = new IbRect(x + gv.oXshift - shift + mapStartLocXinPixels, y, gv.squareSize, gv.squareSize);
                    }
                    else
                    {
                        dst = new IbRect(x + gv.oXshift + mapStartLocXinPixels, y, gv.squareSize, gv.squareSize);
                    }
                    //gv.DrawBitmap(mod.playerList[mod.selectedPartyLeader].token, src, dst, !mod.playerList[mod.selectedPartyLeader].combatFacingLeft, false);
                }
                else if (mod.selectedPartyLeader == 3)
                {
                    if (tglFullParty.toggleOn)
                    {
                        dst = new IbRect(x + gv.oXshift + (shift * 2) + mapStartLocXinPixels, y, gv.squareSize, gv.squareSize);
                    }
                    else
                    {
                        dst = new IbRect(x + gv.oXshift + mapStartLocXinPixels, y, gv.squareSize, gv.squareSize);
                    }
                    //gv.DrawBitmap(mod.playerList[mod.selectedPartyLeader].token, src, dst, !mod.playerList[mod.selectedPartyLeader].combatFacingLeft, false);
                }
                else if (mod.selectedPartyLeader == 4)
                {
                    if (tglFullParty.toggleOn)
                    {
                        dst = new IbRect(x + gv.oXshift - (shift * 2) + mapStartLocXinPixels, y, gv.squareSize, gv.squareSize);
                    }
                    else
                    {
                        dst = new IbRect(x + gv.oXshift + mapStartLocXinPixels, y, gv.squareSize, gv.squareSize);
                    }
                    //gv.DrawBitmap(mod.playerList[mod.selectedPartyLeader].token, src, dst, !mod.playerList[mod.selectedPartyLeader].combatFacingLeft, false);
                }
                else if (mod.selectedPartyLeader == 5)
                {
                    if (tglFullParty.toggleOn)
                    {
                        dst = new IbRect(x + gv.oXshift - (shift * 3) + mapStartLocXinPixels, y, gv.squareSize, gv.squareSize);
                    }
                    else
                    {
                        dst = new IbRect(x + gv.oXshift + mapStartLocXinPixels, y, gv.squareSize, gv.squareSize);
                    }
                    //gv.DrawBitmap(mod.playerList[mod.selectedPartyLeader].token, src, dst, !mod.playerList[mod.selectedPartyLeader].combatFacingLeft, false);
                }

                if (mod.currentArea.useMiniProps)
                {
                    dst.Top += (int)(gv.squareSize / 4);
                    if (mod.playerList[mod.selectedPartyLeader].combatFacingLeft == true)
                    {
                        dst.Left += (int)(gv.squareSize / 4);
                    }
                    else
                    {
                        dst.Left -= (int)(gv.squareSize / 4);
                    }
                    dst.Height -= (int)(dst.Height / 2);
                    dst.Width -= (int)(dst.Width / 2);
                }
                else if (mod.currentArea.useSuperTinyProps)
                {
                    dst.Top += (int)(gv.squareSize * 3 / 8);
                    if (mod.playerList[mod.selectedPartyLeader].combatFacingLeft == true)
                    {
                        dst.Left += (int)(gv.squareSize * 3 /8);
                    }
                    else
                    {
                        dst.Left -= (int)(gv.squareSize * 3 / 8);
                    }
                    dst.Height -= (int)(dst.Height * 3 / 4);
                    dst.Width -= (int)(dst.Width * 3 / 4);
                }
                gv.DrawBitmap(mod.playerList[mod.selectedPartyLeader].token, src, dst, !mod.playerList[mod.selectedPartyLeader].combatFacingLeft, false);
                shift = storeShift;
            }
        }
        public void drawGrid()
        {
            int minX = mod.PlayerLocationX - gv.playerOffset;
            if (minX < 0) { minX = 0; }
            int minY = mod.PlayerLocationY - gv.playerOffset;
            if (minY < 0) { minY = 0; }

            int maxX = mod.PlayerLocationX + gv.playerOffset + 1;
            if (maxX > this.mod.currentArea.MapSizeX) { maxX = this.mod.currentArea.MapSizeX; }
            int maxY = mod.PlayerLocationY + gv.playerOffset + 1;
            if (maxY > this.mod.currentArea.MapSizeY) { maxY = this.mod.currentArea.MapSizeY; }

            for (int x = minX; x < maxX; x++)
            {
                for (int y = minY; y < maxY; y++)
                {
                    int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                    int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;
                    int brX = gv.squareSize;
                    int brY = gv.squareSize;
                    IbRect src = new IbRect(0, 0, gv.cc.walkBlocked.PixelSize.Width, gv.cc.walkBlocked.PixelSize.Height);
                    IbRect dst = new IbRect(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                    if (mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x].LoSBlocked)
                    {
                        gv.DrawBitmap(gv.cc.losBlocked, src, dst);
                    }
                    if (mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x].Walkable != true)
                    {
                        gv.DrawBitmap(gv.cc.walkBlocked, src, dst);
                    }
                    else
                    {
                        gv.DrawBitmap(gv.cc.walkPass, src, dst);
                    }
                }
            }
        }
        public void drawMainMapFloatyText()
        {
            /*TODO
		    int txtH = (int)gv.floatyTextPaint.getTextSize();
		
		    gv.floatyTextPaint.setStyle(Paint.Style.FILL);
		    gv.floatyTextPaint.setColor(Color.BLACK);
		    for (int x = -2; x <= 2; x++)
		    {
			    for (int y = -2; y <= 2; y++)
			    {
				    canvas.drawText(gv.cc.floatyText, gv.cc.floatyTextLoc.X + gv.oXshift + x, gv.cc.floatyTextLoc.Y + txtH + y, gv.floatyTextPaint);				
			    }
		    }		
		    gv.floatyTextPaint.setStyle(Paint.Style.FILL);
		    gv.floatyTextPaint.setColor(Color.WHITE);
		    canvas.drawText(gv.cc.floatyText, gv.cc.floatyTextLoc.X + gv.oXshift, gv.cc.floatyTextLoc.Y + txtH, gv.floatyTextPaint);	
	        */
        }
        public void drawOverlayTints()
        {
            IbRect src = new IbRect(0, 0, gv.cc.tint_sunset.PixelSize.Width, gv.cc.tint_sunset.PixelSize.Height);
            IbRect dst = new IbRect(gv.oXshift + mapStartLocXinPixels, 0, (gv.squareSize * 9), (gv.squareSize * 9));
            int dawn = 5 * 60;
            int sunrise = 6 * 60;
            int day = 7 * 60;
            int sunset = 17 * 60;
            int dusk = 18 * 60;
            int night = 20 * 60;
            int time = gv.mod.WorldTime % 1440;
            if ((time >= dawn) && (time < sunrise))
            {
                gv.DrawBitmap(gv.cc.tint_dawn, src, dst);
            }
            else if ((time >= sunrise) && (time < day))
            {
                gv.DrawBitmap(gv.cc.tint_sunrise, src, dst);
            }
            else if ((time >= day) && (time < sunset))
            {
                //no tint for day
            }
            else if ((time >= sunset) && (time < dusk))
            {
                gv.DrawBitmap(gv.cc.tint_sunset, src, dst);
            }
            else if ((time >= dusk) && (time < night))
            {
                gv.DrawBitmap(gv.cc.tint_dusk, src, dst);
            }
            else if ((time >= night) || (time < dawn))
            {
                gv.DrawBitmap(gv.cc.tint_night, src, dst);
            }

        }

        //not used for now; later :-)
        /*public void drawOverlayWeather()
        {
            //memo to self: in second step do animation by drawing two partial rectangles of same source that change size with time, upper and lower rect, and cast to same target dst, but shifted
            //the source picture must be identical top and bottom lines, other wise we will see a clear dividing line
            //idea that one source bitmap can be used all itself to simulate scrolling down if called in shifting chunks
            //part that scrolls out of lower screen border appears again at top screen border
            //second memo to self: in game settings implement several speed settings for animation speed (pixel move per call multiplier) so that players can adjust prop anim and weatehr anim speed themselves
            //third memo to self: descripe current weather type next to current time in the game ui
            IbRect src = new IbRect(0, 0, gv.cc.tint_rain.PixelSize.Width, gv.cc.tint_rain.PixelSize.Height);
            IbRect dst = new IbRect(gv.oXshift + mapStartLocXinPixels, 0, (gv.squareSize * 9), (gv.squareSize * 9));
            int dawn = 5 * 60;
            int sunrise = 6 * 60;
            int day = 7 * 60;
            int sunset = 17 * 60;
            int dusk = 18 * 60;
            int night = 20 * 60;
            int time = gv.mod.WorldTime % 1440;
            if ((time >= dawn) && (time < sunrise))
            {
                gv.DrawBitmap(gv.cc.tint_dawn, src, dst);
            }
            else if ((time >= sunrise) && (time < day))
            {
                gv.DrawBitmap(gv.cc.tint_sunrise, src, dst);
            }
            else if ((time >= day) && (time < sunset))
            {
                //no tint for day
            }
            else if ((time >= sunset) && (time < dusk))
            {
                gv.DrawBitmap(gv.cc.tint_sunset, src, dst);
            }
            else if ((time >= dusk) && (time < night))
            {
                gv.DrawBitmap(gv.cc.tint_dusk, src, dst);
            }
            else if ((time >= night) || (time < dawn))
            {
                gv.DrawBitmap(gv.cc.tint_night, src, dst);
            }

        }*/
        
        public void drawMainMapClockText()
        {
            int timeofday = mod.WorldTime % (24 * 60);
            int hour = timeofday / 60;
            int minute = timeofday % 60;
            string sMinute = minute + "";
            if (minute < 10)
            {
                sMinute = "0" + minute;
            }

            int txtH = (int)gv.drawFontRegHeight;

            for (int x = -2; x <= 2; x++)
            {
                for (int y = -2; y <= 2; y++)
                {
                    gv.DrawText(hour + ":" + sMinute, new IbRect(gv.oXshift + x + mapStartLocXinPixels, 9 * gv.squareSize - txtH + y, 100, 100), 1.0f, Color.Black);
                }
            }
            gv.DrawText(hour + ":" + sMinute, new IbRect(gv.oXshift + mapStartLocXinPixels, 9 * gv.squareSize - txtH, 100, 100), 1.0f, Color.White);

        }
        public void drawFogOfWar()
        {
            int minX = mod.PlayerLocationX - gv.playerOffset;
            if (minX < 0) { minX = 0; }
            int minY = mod.PlayerLocationY - gv.playerOffset;
            if (minY < 0) { minY = 0; }

            int maxX = mod.PlayerLocationX + gv.playerOffset + 1;
            if (maxX > this.mod.currentArea.MapSizeX) { maxX = this.mod.currentArea.MapSizeX; }
            int maxY = mod.PlayerLocationY + gv.playerOffset + 1;
            if (maxY > this.mod.currentArea.MapSizeY) { maxY = this.mod.currentArea.MapSizeY; }

            for (int x = minX; x < maxX; x++)
            {
                for (int y = minY; y < maxY; y++)
                {
                    int tlX = (x - mod.PlayerLocationX + gv.playerOffset) * gv.squareSize;
                    int tlY = (y - mod.PlayerLocationY + gv.playerOffset) * gv.squareSize;
                    int brX = gv.squareSize;
                    int brY = gv.squareSize;
                    IbRect src = new IbRect(0, 0, gv.cc.black_tile.PixelSize.Width, gv.cc.black_tile.PixelSize.Height);
                    IbRect dst = new IbRect(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                    if (!mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x].Visible)
                    {
                        gv.DrawBitmap(gv.cc.black_tile, src, dst);
                    }
                }
            }
        }
        public void drawBlackTilesOverTints()
        {
            //at left edge
            if (mod.PlayerLocationX < 4)
            {
                drawColumnOfBlack(0);
            }
            if (mod.PlayerLocationX < 3)
            {
                drawColumnOfBlack(1);
            }
            if (mod.PlayerLocationX < 2)
            {
                drawColumnOfBlack(2);
            }
            if (mod.PlayerLocationX < 1)
            {
                drawColumnOfBlack(3);
            }
            //at top edge
            if (mod.PlayerLocationY < 4)
            {
                drawRowOfBlack(0);
            }
            if (mod.PlayerLocationY < 3)
            {
                drawRowOfBlack(1);
            }
            if (mod.PlayerLocationY < 2)
            {
                drawRowOfBlack(2);
            }
            if (mod.PlayerLocationY < 1)
            {
                drawRowOfBlack(3);
            }

            //at right edge
            if (mod.PlayerLocationX > mod.currentArea.MapSizeX - 5)
            {
                drawColumnOfBlack(8);
            }
            if (mod.PlayerLocationX > mod.currentArea.MapSizeX - 4)
            {
                drawColumnOfBlack(7);
            }
            if (mod.PlayerLocationX > mod.currentArea.MapSizeX - 3)
            {
                drawColumnOfBlack(6);
            }
            if (mod.PlayerLocationX > mod.currentArea.MapSizeX - 2)
            {
                drawColumnOfBlack(5);
            }

            //at bottom edge
            if (mod.PlayerLocationY > mod.currentArea.MapSizeY - 5)
            {
                drawRowOfBlack(8);
            }
            if (mod.PlayerLocationY > mod.currentArea.MapSizeY - 4)
            {
                drawRowOfBlack(7);
            }
            if (mod.PlayerLocationY > mod.currentArea.MapSizeY - 3)
            {
                drawRowOfBlack(6);
            }
            if (mod.PlayerLocationY > mod.currentArea.MapSizeY - 2)
            {
                drawRowOfBlack(5);
            }            
        }
        public void drawPanels()
        {
            gv.cc.pnlLog.Draw();
            gv.cc.pnlToggles.Draw();
            gv.cc.pnlPortraits.Draw();
            gv.cc.pnlArrows.Draw();
            gv.cc.pnlHotkeys.Draw();
        }
        public void drawControls()
        {
            gv.cc.ctrlUpArrow.Draw();
            gv.cc.ctrlDownArrow.Draw();
            gv.cc.ctrlLeftArrow.Draw();
            gv.cc.ctrlRightArrow.Draw();
            btnWait.Draw();
            gv.cc.tglSound.Draw();
            tglFullParty.Draw();
            //if (mod.currentArea.IsWorldMap)
            //{
                tglMiniMap.Draw();
            //}
            tglGrid.Draw();
            tglInteractionState.Draw();
            tglAvoidConversation.Draw();
            tglClock.Draw();

            //check for levelup available and switch button image
            checkLevelUpAvailable();

            btnParty.Draw();
            gv.cc.btnInventory.Draw();
            btnJournal.Draw();
            btnSettings.Draw();
            if (mod.allowSave)
            {
                btnSave.btnState = buttonState.Normal;
            }
            else
            {
                btnSave.btnState = buttonState.Off;
            }
            btnSave.Draw();
            btnCastOnMainMap.Draw();
        }
        public void drawFloatyTextPool()
        {
            if (floatyTextPool.Count > 0)
            {
                int txtH = (int)gv.drawFontRegHeight;
                int pH = (int)((float)gv.screenHeight / 200.0f);

                foreach (FloatyText ft in floatyTextPool)
                {
                    if (gv.cc.getDistance(ft.location, new Coordinate(mod.PlayerLastLocationX, mod.PlayerLocationY)) > 3)
                    {
                        continue; //out of range from view so skip drawing floaty message
                    }

                    //location.X should be the the props actual map location in squares (not screen location)
                    int xLoc = (ft.location.X + gv.playerOffset - mod.PlayerLocationX) * gv.squareSize;
                    int yLoc = ((ft.location.Y + gv.playerOffset - mod.PlayerLocationY) * gv.squareSize) - (pH * ft.z);

                    for (int x = -2; x <= 2; x++)
                    {
                        for (int y = -2; y <= 2; y++)
                        {
                            gv.DrawText(ft.value, new IbRect(xLoc + x + gv.oXshift + mapStartLocXinPixels, yLoc + y + txtH, gv.squareSize * 2, 1000), 0.8f, Color.Black);
                        }
                    }
                    Color colr = Color.Yellow;
                    if (ft.color.Equals("yellow"))
                    {
                        colr = Color.Yellow;
                    }
                    else if (ft.color.Equals("blue"))
                    {
                        colr = Color.Blue;
                    }
                    else if (ft.color.Equals("green"))
                    {
                        colr = Color.Lime;
                    }
                    else if (ft.color.Equals("red"))
                    {
                        colr = Color.Red;
                    }
                    else
                    {
                        colr = Color.White;
                    }
                    gv.DrawText(ft.value, new IbRect(xLoc + gv.oXshift + mapStartLocXinPixels, yLoc + txtH, gv.squareSize * 2, 1000), 0.8f, colr);
                }
            }
        }

        public void drawFloatyTextByPixelPool()
        {
            if (floatyTextByPixelPool.Count > 0)
            {
                int txtH = (int)gv.drawFontRegHeight;
                int pH = (int)((float)gv.screenHeight / 200.0f);

                foreach (FloatyTextByPixel ft in floatyTextByPixelPool)
                {

                    int playerPositionXInPix = gv.oXshift + gv.screenMainMap.mapStartLocXinPixels + (gv.playerOffset * gv.squareSize);
                    int playerPositionYInPix = gv.playerOffset * gv.squareSize + gv.oYshift;

                    float floatConvertedToSquareDistanceX = (ft.floatyCarrier2.currentPixelPositionX - playerPositionXInPix) / gv.squareSize;
                    int ConvertedToSquareDistanceX = (int)Math.Ceiling(floatConvertedToSquareDistanceX);

                    float floatConvertedToSquareDistanceY = (ft.floatyCarrier2.currentPixelPositionY - playerPositionYInPix) / gv.squareSize;
                    int ConvertedToSquareDistanceY = (int)Math.Ceiling(floatConvertedToSquareDistanceY);

                    int SquareThatPixIsOnX = mod.PlayerLocationX + ConvertedToSquareDistanceX;
                    int SquareThatPixIsOnY = mod.PlayerLocationY + ConvertedToSquareDistanceY;


                    if (gv.cc.getDistance(new Coordinate (SquareThatPixIsOnX, SquareThatPixIsOnY), new Coordinate(mod.PlayerLastLocationX, mod.PlayerLocationY)) > 3)
                    {
                        continue; //out of range from view so skip drawing floaty message
                    }

                    //location.X should be the the props actual map location in squares (not screen location)
                    int xLoc = (int)(ft.floatyCarrier2.currentPixelPositionX);
                    int yLoc = (int)(ft.floatyCarrier2.currentPixelPositionY) - (pH * ft.z);

                    for (int x = -2; x <= 2; x++)
                    {
                        for (int y = -2; y <= 2; y++)
                        {
                            gv.DrawText(ft.value, new IbRect(xLoc + x, yLoc + y + txtH, gv.squareSize * 2, 1000), 0.8f, Color.Black);
                        }
                    }
                    Color colr = Color.Yellow;
                    if (ft.color.Equals("yellow"))
                    {
                        colr = Color.Yellow;
                    }
                    else if (ft.color.Equals("blue"))
                    {
                        colr = Color.Blue;
                    }
                    else if (ft.color.Equals("green"))
                    {
                        colr = Color.Lime;
                    }
                    else if (ft.color.Equals("red"))
                    {
                        colr = Color.Red;
                    }
                    else
                    {
                        colr = Color.White;
                    }
                    gv.DrawText(ft.value, new IbRect(xLoc, yLoc + txtH, gv.squareSize * 2, 1000), 0.8f, colr);
                }
            }
        }

        public void drawColumnOfBlack(int col)
        {
            for (int y = 0; y < 9; y++)
            {
                int tlX = col * gv.squareSize;
                int tlY = y * gv.squareSize;
                int brX = gv.squareSize;
                int brY = gv.squareSize;
                IbRect src = new IbRect(0, 0, gv.cc.black_tile.PixelSize.Width, gv.cc.black_tile.PixelSize.Height);
                IbRect dst = new IbRect(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                gv.DrawBitmap(gv.cc.black_tile, src, dst);
            }
        }
        public void drawRowOfBlack(int row)
        {
            for (int x = 0; x < 9; x++)
            {
                int tlX = x * gv.squareSize;
                int tlY = row * gv.squareSize;
                int brX = gv.squareSize;
                int brY = gv.squareSize;
                IbRect src = new IbRect(0, 0, gv.cc.black_tile.PixelSize.Width, gv.cc.black_tile.PixelSize.Height);
                IbRect dst = new IbRect(tlX + gv.oXshift + mapStartLocXinPixels, tlY, brX, brY);
                gv.DrawBitmap(gv.cc.black_tile, src, dst);
            }
        }
                
        public void doFloatyTextLoop()
        {
            gv.postDelayed("doFloatyTextMainMap", 100);
        }
        public void doFloatyTextByPixelLoop()
        {
            gv.postDelayed("doFloatyTextMainMap", 100);
        }
        public void addFloatyText(int sqrX, int sqrY, String value, String color, int length)
        {
            floatyTextPool.Add(new FloatyText(sqrX, sqrY, value, color, length));
        }

        public void addFloatyText(Prop floatyCarrier, String value, String color, int length)
        {
            floatyTextByPixelPool.Add(new FloatyTextByPixel (floatyCarrier, value, color, length));
        }

        public void onTouchMain(MouseEventArgs e, MouseEventType.EventType eventType)
        {
            gv.cc.ctrlUpArrow.glowOn = false;
            gv.cc.ctrlDownArrow.glowOn = false;
            gv.cc.ctrlLeftArrow.glowOn = false;
            gv.cc.ctrlRightArrow.glowOn = false;
            btnParty.glowOn = false;
            gv.cc.btnInventory.glowOn = false;
            btnJournal.glowOn = false;
            btnSettings.glowOn = false;
            btnSave.glowOn = false;
            btnCastOnMainMap.glowOn = false;
            btnWait.glowOn = false;

            switch (eventType)
            {
                case MouseEventType.EventType.MouseDown:
                case MouseEventType.EventType.MouseMove:
                    int x = (int)e.X;
                    int y = (int)e.Y;

                    //Draw Floaty Text On Mouse Over Prop
                    int gridx = (int)e.X / gv.squareSize;
                    int gridy = (int)e.Y / gv.squareSize;
                    int actualX = mod.PlayerLocationX + (gridx - gv.playerOffset);
                    int actualY = mod.PlayerLocationY + (gridy - gv.playerOffset);
                    gv.cc.floatyText = "";
                    if (IsTouchInMapWindow(gridx, gridy))
                    {
                        foreach (Prop p in mod.currentArea.Props)
                        {
                            if ((p.LocationX == actualX) && (p.LocationY == actualY))
                            {
                                if (!p.MouseOverText.Equals("none"))
                                {
                                    gv.cc.floatyText = p.MouseOverText;
                                    gv.cc.floatyTextLoc = new Coordinate(gridx * gv.squareSize, gridy * gv.squareSize);
                                }
                            }
                        }
                    }


                    if (gv.cc.ctrlUpArrow.getImpact(x, y))
                    {
                        gv.cc.ctrlUpArrow.glowOn = true;
                    }
                    else if (gv.cc.ctrlDownArrow.getImpact(x, y))
                    {
                        gv.cc.ctrlDownArrow.glowOn = true;
                    }
                    else if (gv.cc.ctrlLeftArrow.getImpact(x, y))
                    {
                        gv.cc.ctrlLeftArrow.glowOn = true;
                    }
                    else if (gv.cc.ctrlRightArrow.getImpact(x, y))
                    {
                        gv.cc.ctrlRightArrow.glowOn = true;
                    }
                    else if (btnParty.getImpact(x, y))
                    {
                        btnParty.glowOn = true;
                    }
                    else if (gv.cc.btnInventory.getImpact(x, y))
                    {
                        gv.cc.btnInventory.glowOn = true;
                    }
                    else if (btnJournal.getImpact(x, y))
                    {
                        btnJournal.glowOn = true;
                    }
                    else if (btnSettings.getImpact(x, y))
                    {
                        btnSettings.glowOn = true;
                    }
                    else if (btnSave.getImpact(x, y))
                    {
                        if (mod.allowSave)
                        {
                            btnSave.glowOn = true;
                        }
                    }
                    else if (btnCastOnMainMap.getImpact(x, y))
                    {
                        btnCastOnMainMap.glowOn = true;
                    }
                    else if (btnWait.getImpact(x, y))
                    {
                        btnWait.glowOn = true;
                    }
                    break;

                case MouseEventType.EventType.MouseUp:
                    x = (int)e.X;
                    y = (int)e.Y;
                    int gridX = (int)e.X / gv.squareSize;
                    int gridY = (int)e.Y / gv.squareSize;
                    int actualx = mod.PlayerLocationX + (gridX - gv.playerOffset);
                    int actualy = mod.PlayerLocationY + (gridY - gv.playerOffset);


                    gv.cc.ctrlUpArrow.glowOn = false;
                    gv.cc.ctrlDownArrow.glowOn = false;
                    gv.cc.ctrlLeftArrow.glowOn = false;
                    gv.cc.ctrlRightArrow.glowOn = false;
                    btnParty.glowOn = false;
                    gv.cc.btnInventory.glowOn = false;
                    btnJournal.glowOn = false;
                    btnSettings.glowOn = false;
                    btnSave.glowOn = false;
                    btnCastOnMainMap.glowOn = false;
                    btnWait.glowOn = false;

                    if (tglGrid.getImpact(x, y))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        if (tglGrid.toggleOn)
                        {
                            tglGrid.toggleOn = false;
                            mod.map_showGrid = false;
                        }
                        else
                        {
                            tglGrid.toggleOn = true;
                            mod.map_showGrid = true;
                        }
                    }

                    if (tglInteractionState.getImpact(x, y))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        if (tglInteractionState.toggleOn)
                        {
                            tglInteractionState.toggleOn = false;
                            mod.showInteractionState = false;
                            gv.cc.addLogText("yellow", "Hide info about interaction state of NPC and creatures (encounter = red, mandatory conversation = orange and optional conversation = green");
                        }
                        else
                        {
                            tglInteractionState.toggleOn = true;
                            mod.showInteractionState = true;
                            gv.cc.addLogText("lime", "Show info about interaction state of NPC and creatures (encounter = red, mandatory conversation = orange and optional conversation = green");
                        }
                    }

                    if (tglAvoidConversation.getImpact(x, y))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        if (tglAvoidConversation.toggleOn)
                        {
                            tglAvoidConversation.toggleOn = false;
                            mod.avoidInteraction = false;
                            gv.cc.addLogText("lime", "Normal move mode: party does all possible conversations");
                        }
                        else
                        {
                            tglAvoidConversation.toggleOn = true;
                            mod.avoidInteraction = true;
                            gv.cc.addLogText("yellow", "In a hurry: Party is avoiding all conversations that are not mandatory");
                        }
                    }


                    if (tglClock.getImpact(x, y))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        if (tglClock.toggleOn)
                        {
                            tglClock.toggleOn = false;
                        }
                        else
                        {
                            tglClock.toggleOn = true;
                        }
                    }
                    if (gv.cc.tglSound.getImpact(x, y))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        if (gv.cc.tglSound.toggleOn)
                        {
                            gv.cc.tglSound.toggleOn = false;
                            mod.playMusic = false;
                            mod.playSoundFx = false;
                            gv.screenCombat.tglSoundFx.toggleOn = false;
                            gv.stopMusic();
                            gv.stopAmbient();
                            gv.cc.addLogText("lime", "Music Off, SoundFX Off");
                        }
                        else
                        {
                            gv.cc.tglSound.toggleOn = true;
                            mod.playMusic = true;
                            mod.playSoundFx = true;
                            gv.screenCombat.tglSoundFx.toggleOn = true;
                            gv.startMusic();
                            gv.startAmbient();
                            gv.cc.addLogText("lime", "Music On, SoundFX On");
                        }
                    }
                    if (tglFullParty.getImpact(x, y))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        if (tglFullParty.toggleOn)
                        {
                            tglFullParty.toggleOn = false;
                            gv.cc.addLogText("lime", "Show Party Leader");
                        }
                        else
                        {
                            tglFullParty.toggleOn = true;
                            gv.cc.addLogText("lime", "Show Full Party");
                        }
                    }
                    //if ((tglMiniMap.getImpact(x, y)) && (mod.currentArea.IsWorldMap))
                    if (tglMiniMap.getImpact(x, y))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        if (tglMiniMap.toggleOn)
                        {
                            tglMiniMap.toggleOn = false;
                            gv.cc.addLogText("lime", "Hide Mini Map");
                        }
                        else
                        {
                            tglMiniMap.toggleOn = true;
                            gv.cc.addLogText("lime", "Show Mini Map");
                        }
                    }
                    if ((gv.cc.ctrlUpArrow.getImpact(x, y)) || ((mod.PlayerLocationX == actualx) && ((mod.PlayerLocationY - 1) == actualy)))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        if (mod.PlayerLocationY > 0)
                        {
                            if (mod.currentArea.GetBlocked(mod.PlayerLocationX, mod.PlayerLocationY - 1) == false)
                            {
                                mod.PlayerLastLocationX = mod.PlayerLocationX;
                                mod.PlayerLastLocationY = mod.PlayerLocationY;
                                mod.PlayerLocationY--;
                                gv.cc.doUpdate();
                            }
                        }
                    }
                    else if ((gv.cc.ctrlDownArrow.getImpact(x, y)) || ((mod.PlayerLocationX == actualx) && ((mod.PlayerLocationY + 1) == actualy)))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        int mapheight = mod.currentArea.MapSizeY;
                        if (mod.PlayerLocationY < (mapheight - 1))
                        {
                            if (mod.currentArea.GetBlocked(mod.PlayerLocationX, mod.PlayerLocationY + 1) == false)
                            {
                                mod.PlayerLastLocationX = mod.PlayerLocationX;
                                mod.PlayerLastLocationY = mod.PlayerLocationY;
                                mod.PlayerLocationY++;
                                gv.cc.doUpdate();
                            }
                        }
                    }
                    else if ((gv.cc.ctrlLeftArrow.getImpact(x, y)) || (((mod.PlayerLocationX - 1) == actualx) && (mod.PlayerLocationY == actualy)))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        if (mod.PlayerLocationX > 0)
                        {
                            if (mod.currentArea.GetBlocked(mod.PlayerLocationX - 1, mod.PlayerLocationY) == false)
                            {
                                mod.PlayerLastLocationX = mod.PlayerLocationX;
                                mod.PlayerLastLocationY = mod.PlayerLocationY;
                                mod.PlayerLocationX--;
                                if (!mod.playerList[0].combatFacingLeft)
                                {
                                    //TODO							    //mod.partyTokenBitmap = gv.cc.flip(mod.partyTokenBitmap);
                                }
                                foreach (Player pc in mod.playerList)
                                {
                                    if (!pc.combatFacingLeft)
                                    {
                                        pc.combatFacingLeft = true;
                                    }
                                }
                                gv.cc.doUpdate();
                            }
                        }
                    }
                    else if ((gv.cc.ctrlRightArrow.getImpact(x, y)) || (((mod.PlayerLocationX + 1) == actualx) && (mod.PlayerLocationY == actualy)))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        int mapwidth = mod.currentArea.MapSizeX;
                        if (mod.PlayerLocationX < (mapwidth - 1))
                        {
                            if (mod.currentArea.GetBlocked(mod.PlayerLocationX + 1, mod.PlayerLocationY) == false)
                            {
                                mod.PlayerLastLocationX = mod.PlayerLocationX;
                                mod.PlayerLastLocationY = mod.PlayerLocationY;
                                mod.PlayerLocationX++;
                                if (mod.playerList[0].combatFacingLeft)
                                {
                                    //TODO							    mod.partyTokenBitmap = gv.cc.flip(mod.partyTokenBitmap);
                                }
                                foreach (Player pc in mod.playerList)
                                {
                                    if (pc.combatFacingLeft)
                                    {
                                        pc.combatFacingLeft = false;
                                    }
                                }
                                gv.cc.doUpdate();
                            }
                        }
                    }
                    else if (btnParty.getImpact(x, y))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        gv.screenParty.resetPartyScreen();
                        gv.screenType = "party";
                        gv.cc.tutorialMessageParty(false);
                    }
                    else if ((gv.cc.ptrPc0.getImpact(x, y)) && (mod.playerList.Count > 0))
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            mod.selectedPartyLeader = 0;
                            gv.cc.partyScreenPcIndex = 0;
                            gv.screenParty.resetPartyScreen();
                            gv.screenType = "party";
                            gv.cc.tutorialMessageParty(false);
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            mod.selectedPartyLeader = 0;
                            gv.cc.partyScreenPcIndex = 0;
                        }
                    }
                    else if ((gv.cc.ptrPc1.getImpact(x, y)) && (mod.playerList.Count > 1))
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            mod.selectedPartyLeader = 1;
                            gv.cc.partyScreenPcIndex = 1;
                            gv.screenParty.resetPartyScreen();
                            gv.screenType = "party";
                            gv.cc.tutorialMessageParty(false);
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            mod.selectedPartyLeader = 1;
                            gv.cc.partyScreenPcIndex = 1;
                        }
                    }
                    else if ((gv.cc.ptrPc2.getImpact(x, y)) && (mod.playerList.Count > 2))
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            mod.selectedPartyLeader = 2;
                            gv.cc.partyScreenPcIndex = 2;
                            gv.screenParty.resetPartyScreen();
                            gv.screenType = "party";
                            gv.cc.tutorialMessageParty(false);
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            mod.selectedPartyLeader = 2;
                            gv.cc.partyScreenPcIndex = 2;
                        }
                    }
                    else if ((gv.cc.ptrPc3.getImpact(x, y)) && (mod.playerList.Count > 3))
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            mod.selectedPartyLeader = 3;
                            gv.cc.partyScreenPcIndex = 3;
                            gv.screenParty.resetPartyScreen();
                            gv.screenType = "party";
                            gv.cc.tutorialMessageParty(false);
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            mod.selectedPartyLeader = 3;
                            gv.cc.partyScreenPcIndex = 3;
                        }
                    }
                    else if ((gv.cc.ptrPc4.getImpact(x, y)) && (mod.playerList.Count > 4))
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            mod.selectedPartyLeader = 4;
                            gv.cc.partyScreenPcIndex = 4;
                            gv.screenParty.resetPartyScreen();
                            gv.screenType = "party";
                            gv.cc.tutorialMessageParty(false);
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            mod.selectedPartyLeader = 4;
                            gv.cc.partyScreenPcIndex = 4;
                        }
                    }
                    else if ((gv.cc.ptrPc5.getImpact(x, y)) && (mod.playerList.Count > 5))
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            mod.selectedPartyLeader = 5;
                            gv.cc.partyScreenPcIndex = 5;
                            gv.screenParty.resetPartyScreen();
                            gv.screenType = "party";
                            gv.cc.tutorialMessageParty(false);
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            mod.selectedPartyLeader = 5;
                            gv.cc.partyScreenPcIndex = 5;
                        }
                    }
                    else if (gv.cc.btnInventory.getImpact(x, y))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        gv.screenType = "inventory";
                        gv.screenInventory.resetInventory();
                        gv.cc.tutorialMessageInventory(false);
                    }
                    else if (btnJournal.getImpact(x, y))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        gv.screenType = "journal";
                    }
                    else if (btnSettings.getImpact(x, y))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        gv.cc.doSettingsDialogs();
                    }
                    else if (btnSave.getImpact(x, y))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        if (mod.allowSave)
                        {
                            gv.cc.doSavesDialog();
                        }
                    }
                    else if (btnWait.getImpact(x, y))
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        gv.cc.doUpdate();
                    }
                    else if (btnCastOnMainMap.getImpact(x, y))
                    {

                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}

                        List<string> pcNames = new List<string>();
                        List<int> pcIndex = new List<int>();
                        pcNames.Add("cancel");

                        int cnt = 0;
                        foreach (Player p in mod.playerList)
                        {
                            if (hasMainMapTypeSpell(p))
                            {
                                pcNames.Add(p.name);
                                pcIndex.Add(cnt);
                            }
                            cnt++;
                        }

                        //If only one PC, do not show select PC dialog...just go to cast selector
                        if (pcIndex.Count == 1)
                        {
                            try
                            {
                                gv.screenCastSelector.castingPlayerIndex = pcIndex[0];
                                gv.screenCombat.spellSelectorIndex = 0;
                                gv.screenType = "mainMapCast";
                                return;
                            }
                            catch (Exception ex)
                            {
                                //print error
                                IBMessageBox.Show(gv, "error with Pc Selector screen: " + ex.ToString());
                                gv.errorLog(ex.ToString());
                                return;
                            }
                        }

                        using (ItemListSelector pcSel = new ItemListSelector(gv, pcNames, "Select Caster"))
                        {
                            pcSel.ShowDialog();

                            if (pcSel.selectedIndex > 0)
                            {
                                try
                                {
                                    gv.screenCastSelector.castingPlayerIndex = pcIndex[pcSel.selectedIndex - 1]; // pcIndex.get(item - 1);
                                    gv.screenCombat.spellSelectorIndex = 0;
                                    gv.screenType = "mainMapCast";
                                }
                                catch (Exception ex)
                                {
                                    IBMessageBox.Show(gv, "error with Pc Selector screen: " + ex.ToString());
                                    gv.errorLog(ex.ToString());
                                    //print error
                                }
                            }
                            else if (pcSel.selectedIndex == 0) // selected "cancel"
                            {
                                //do nothing
                            }
                        }
                    }
                    break;
            }
        }
        public void onKeyUp(Keys keyData)
        {
            if ((moveDelay()) && (finishedMove))
            {
                //game.lastPlayerLocation = new Point(game.playerPosition.X, game.playerPosition.Y);
                //int mapwidth = game.currentArea.MapSizeInSquares.Width;
                //int mapheight = game.currentArea.MapSizeInSquares.Height;
                if (keyData == Keys.Left | keyData == Keys.D4 | keyData == Keys.NumPad4)
                {
                    moveLeft();
                    //return true; //for the active control to see the keypress, return false 
                }
                else if (keyData == Keys.Right | keyData == Keys.D6 | keyData == Keys.NumPad6)
                {
                    moveRight();
                    //return true; //for the active control to see the keypress, return false 
                }
                else if (keyData == Keys.Up | keyData == Keys.D8 | keyData == Keys.NumPad8)
                {
                    moveUp();
                    //return true; //for the active control to see the keypress, return false 
                }
                else if (keyData == Keys.Down | keyData == Keys.D2 | keyData == Keys.NumPad2)
                {
                    moveDown();
                    //return true; //for the active control to see the keypress, return false 
                }
                else { }
            }
            if (keyData == Keys.Q)
            {
                if (mod.allowSave)
                {
                    gv.cc.QuickSave();
                    gv.cc.addLogText("lime", "Quicksave Completed");
                }
                else
                {
                    gv.cc.addLogText("red", "No save allowed at this time.");
                }
            }
            if (keyData == Keys.D)
            {
                if (gv.mod.debugMode)
                {
                    gv.mod.debugMode = false;
                    gv.cc.addLogText("lime", "DebugMode Turned Off");
                }
                else
                {
                    gv.mod.debugMode = true;
                    gv.cc.addLogText("lime", "DebugMode Turned On");
                }
            }
            if (keyData == Keys.I)
            {
                gv.screenType = "inventory";
                gv.screenInventory.resetInventory();
                gv.cc.tutorialMessageInventory(false);
            }
            if (keyData == Keys.J)
            {
                gv.screenType = "journal";
            }
            if (keyData == Keys.P)
            {
                /*int cntPCs = 0;
                foreach (IbbButton btn in gv.screenParty.btnPartyIndex)
                {
                    if (cntPCs < mod.playerList.Count)
                    {
                        btn.Img2 = gv.cc.LoadBitmap(mod.playerList[cntPCs].tokenFilename);
                    }
                    cntPCs++;
                }*/
                gv.screenParty.resetPartyScreen();
                gv.screenType = "party";
                gv.cc.tutorialMessageParty(false);
            }
            if (keyData == Keys.C)
            {
                List<string> pcNames = new List<string>();
                List<int> pcIndex = new List<int>();
                pcNames.Add("cancel");

                int cnt = 0;
                foreach (Player p in mod.playerList)
                {
                    if (hasMainMapTypeSpell(p))
                    {
                        pcNames.Add(p.name);
                        pcIndex.Add(cnt);
                    }
                    cnt++;
                }

                //If only one PC, do not show select PC dialog...just go to cast selector
                if (pcIndex.Count == 1)
                {
                    try
                    {
                        gv.screenCastSelector.castingPlayerIndex = pcIndex[0];
                        gv.screenCombat.spellSelectorIndex = 0;
                        gv.screenType = "mainMapCast";
                        return;
                    }
                    catch (Exception ex)
                    {
                        //print error
                        IBMessageBox.Show(gv, "error with Pc Selector screen: " + ex.ToString());
                        gv.errorLog(ex.ToString());
                        return;
                    }
                }

                using (ItemListSelector pcSel = new ItemListSelector(gv, pcNames, "Select Caster"))
                {
                    pcSel.ShowDialog();

                    if (pcSel.selectedIndex > 0)
                    {
                        try
                        {
                            gv.screenCastSelector.castingPlayerIndex = pcIndex[pcSel.selectedIndex - 1]; // pcIndex.get(item - 1);
                            gv.screenCombat.spellSelectorIndex = 0;
                            gv.screenType = "mainMapCast";
                        }
                        catch (Exception ex)
                        {
                            IBMessageBox.Show(gv, "error with Pc Selector screen: " + ex.ToString());
                            gv.errorLog(ex.ToString());
                            //print error
                        }
                    }
                    else if (pcSel.selectedIndex == 0) // selected "cancel"
                    {
                        //do nothing
                    }
                }
            }
        }
        private bool moveDelay()
        {
            long elapsed = DateTime.Now.Ticks - timeStamp;
            if (elapsed > 10000 * movementDelayInMiliseconds) //10,000 ticks in 1 ms
            {
                timeStamp = DateTime.Now.Ticks;
                return true;
            }
            return false;
        }
        private void moveLeft()
        {
            if (mod.PlayerLocationX > 0)
            {
                if (mod.currentArea.GetBlocked(mod.PlayerLocationX - 1, mod.PlayerLocationY) == false)
                {
                    mod.PlayerLastLocationX = mod.PlayerLocationX;
                    mod.PlayerLastLocationY = mod.PlayerLocationY;
                    mod.PlayerLocationX--;
                    if (!mod.playerList[0].combatFacingLeft)
                    {
                        //TODO                        mod.partyTokenBitmap = gv.cc.flip(mod.partyTokenBitmap);
                    }
                    foreach (Player pc in mod.playerList)
                    {
                        if (!pc.combatFacingLeft)
                        {
                            //TODO                            pc.token = gv.cc.flip(pc.token);
                            pc.combatFacingLeft = true;
                        }
                    }
                    gv.cc.doUpdate();
                }
            }
        }
        private void moveRight()
        {
            int mapwidth = mod.currentArea.MapSizeX;
            if (mod.PlayerLocationX < (mapwidth - 1))
            {
                if (mod.currentArea.GetBlocked(mod.PlayerLocationX + 1, mod.PlayerLocationY) == false)
                {
                    mod.PlayerLastLocationX = mod.PlayerLocationX;
                    mod.PlayerLastLocationY = mod.PlayerLocationY;
                    mod.PlayerLocationX++;
                    if (mod.playerList[0].combatFacingLeft)
                    {
                        //TODO                        mod.partyTokenBitmap = gv.cc.flip(mod.partyTokenBitmap);
                    }
                    foreach (Player pc in mod.playerList)
                    {
                        if (pc.combatFacingLeft)
                        {
                            //TODO                            pc.token = gv.cc.flip(pc.token);
                            pc.combatFacingLeft = false;
                        }
                    }
                    gv.cc.doUpdate();
                }
            }
        }
        private void moveUp()
        {
            if (mod.PlayerLocationY > 0)
            {
                if (mod.currentArea.GetBlocked(mod.PlayerLocationX, mod.PlayerLocationY - 1) == false)
                {
                    mod.PlayerLastLocationX = mod.PlayerLocationX;
                    mod.PlayerLastLocationY = mod.PlayerLocationY;
                    mod.PlayerLocationY--;
                    gv.cc.doUpdate();
                }
            }
        }
        private void moveDown()
        {
            int mapheight = mod.currentArea.MapSizeY;
            if (mod.PlayerLocationY < (mapheight - 1))
            {
                if (mod.currentArea.GetBlocked(mod.PlayerLocationX, mod.PlayerLocationY + 1) == false)
                {
                    mod.PlayerLastLocationX = mod.PlayerLocationX;
                    mod.PlayerLastLocationY = mod.PlayerLocationY;
                    mod.PlayerLocationY++;
                    gv.cc.doUpdate();
                }
            }
        }
        public List<string> wrapList(string str, int wrapLength)
        {
            if (str == null)
            {
                return null;
            }
            if (wrapLength < 1)
            {
                wrapLength = 1;
            }
            int inputLineLength = str.Length;
            int offset = 0;
            List<string> returnList = new List<string>();

            while ((inputLineLength - offset) > wrapLength)
            {
                if (str.ElementAt(offset) == ' ')
                {
                    offset++;
                    continue;
                }

                int spaceToWrapAt = str.LastIndexOf(' ', wrapLength + offset);

                if (spaceToWrapAt >= offset)
                {
                    // normal case
                    returnList.Add(str.Substring(offset, spaceToWrapAt));
                    offset = spaceToWrapAt + 1;
                }
                else
                {
                    // do not wrap really long word, just extend beyond limit
                    spaceToWrapAt = str.IndexOf(' ', wrapLength + offset);
                    if (spaceToWrapAt >= 0)
                    {
                        returnList.Add(str.Substring(offset, spaceToWrapAt));
                        offset = spaceToWrapAt + 1;
                    }
                    else
                    {
                        returnList.Add(str.Substring(offset));
                        offset = inputLineLength;
                    }
                }
            }

            // Whatever is left in line is short enough to just pass through
            returnList.Add(str.Substring(offset));
            return returnList;
        }
        private void setExplored()
        {
            int minX = mod.PlayerLocationX - 1;
            if (minX < 0) { minX = 0; }
            int minY = mod.PlayerLocationY - 1;
            if (minY < 0) { minY = 0; }

            int maxX = mod.PlayerLocationX + 1;
            if (maxX > this.mod.currentArea.MapSizeX - 1) { maxX = this.mod.currentArea.MapSizeX - 1; }
            int maxY = mod.PlayerLocationY + 1;
            if (maxY > this.mod.currentArea.MapSizeY - 1) { maxY = this.mod.currentArea.MapSizeY - 1; }

            for (int xx = minX; xx <= maxX; xx++)
            {
                for (int yy = minY; yy <= maxY; yy++)
                {
                    mod.currentArea.Tiles[yy * mod.currentArea.MapSizeX + xx].Visible = true;
                }
            }

            //check left
            int x = mod.PlayerLocationX - 1;
            int y = mod.PlayerLocationY;
            if ((x - 1 >= 0) && (!mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x].LoSBlocked))
            {
                if (y > 0)
                {
                    mod.currentArea.Tiles[(y - 1) * mod.currentArea.MapSizeX + (x - 1)].Visible = true;
                }
                mod.currentArea.Tiles[(y + 0) * mod.currentArea.MapSizeX + (x - 1)].Visible = true;
                if (y < this.mod.currentArea.MapSizeY - 1)
                {
                    mod.currentArea.Tiles[(y + 1) * mod.currentArea.MapSizeX + (x - 1)].Visible = true;
                }
            }
            //check right
            x = mod.PlayerLocationX + 1;
            y = mod.PlayerLocationY;
            if ((x + 1 < this.mod.currentArea.MapSizeX) && (!mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x].LoSBlocked))
            {
                if (y > 0)
                {
                    mod.currentArea.Tiles[(y - 1) * mod.currentArea.MapSizeX + (x + 1)].Visible = true;
                }
                mod.currentArea.Tiles[(y + 0) * mod.currentArea.MapSizeX + (x + 1)].Visible = true;
                if (y < this.mod.currentArea.MapSizeY - 1)
                {
                    mod.currentArea.Tiles[(y + 1) * mod.currentArea.MapSizeX + (x + 1)].Visible = true;
                }
            }
            //check up
            x = mod.PlayerLocationX;
            y = mod.PlayerLocationY - 1;
            if ((y - 1 >= 0) && (!mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x].LoSBlocked))
            {
                if (x < this.mod.currentArea.MapSizeX - 1)
                {
                    mod.currentArea.Tiles[(y - 1) * mod.currentArea.MapSizeX + (x + 1)].Visible = true;
                }
                mod.currentArea.Tiles[(y - 1) * mod.currentArea.MapSizeX + (x + 0)].Visible = true;
                if (x > 0)
                {
                    mod.currentArea.Tiles[(y - 1) * mod.currentArea.MapSizeX + (x - 1)].Visible = true;
                }
            }
            //check down
            x = mod.PlayerLocationX;
            y = mod.PlayerLocationY + 1;
            if ((y + 1 < this.mod.currentArea.MapSizeY) && (!mod.currentArea.Tiles[y * mod.currentArea.MapSizeX + x].LoSBlocked))
            {
                if (x < this.mod.currentArea.MapSizeX - 1)
                {
                    mod.currentArea.Tiles[(y + 1) * mod.currentArea.MapSizeX + (x + 1)].Visible = true;
                }
                mod.currentArea.Tiles[(y + 1) * mod.currentArea.MapSizeX + (x + 0)].Visible = true;
                if (x > 0)
                {
                    mod.currentArea.Tiles[(y + 1) * mod.currentArea.MapSizeX + (x - 1)].Visible = true;
                }
            }
        }
        public bool IsTouchInMapWindow(int sqrX, int sqrY)
        {
            //all input coordinates are in Screen Location, not Map Location
            if ((sqrX < 6) || (sqrY < 0))
            {
                return false;
            }
            if ((sqrX >= 15) || (sqrY >= 9))
            {
                return false;
            }
            return true;
        }
        public bool IsLineOfSightForEachCorner(Coordinate s, Coordinate e)
        {
            int spacer = 5;
            Coordinate start = new Coordinate((s.X * gv.squareSize) + (gv.squareSize / 2), (s.Y * gv.squareSize) + (gv.squareSize / 2));
            // top left
            if (IsVisibleLineOfSight(start, new Coordinate(e.X * gv.squareSize - spacer, e.Y * gv.squareSize - spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Coordinate(e.X * gv.squareSize + spacer, e.Y * gv.squareSize - spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Coordinate(e.X * gv.squareSize - spacer, e.Y * gv.squareSize + spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Coordinate(e.X * gv.squareSize + spacer, e.Y * gv.squareSize + spacer), e)) { return true; }
            // top right
            if (IsVisibleLineOfSight(start, new Coordinate(e.X * gv.squareSize + gv.squareSize - spacer, e.Y * gv.squareSize - spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Coordinate(e.X * gv.squareSize + gv.squareSize + spacer, e.Y * gv.squareSize - spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Coordinate(e.X * gv.squareSize + gv.squareSize - spacer, e.Y * gv.squareSize + spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Coordinate(e.X * gv.squareSize + gv.squareSize + spacer, e.Y * gv.squareSize + spacer), e)) { return true; }
            // bottom left
            if (IsVisibleLineOfSight(start, new Coordinate(e.X * gv.squareSize - spacer, e.Y * gv.squareSize + gv.squareSize - spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Coordinate(e.X * gv.squareSize + spacer, e.Y * gv.squareSize + gv.squareSize - spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Coordinate(e.X * gv.squareSize - spacer, e.Y * gv.squareSize + gv.squareSize + spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Coordinate(e.X * gv.squareSize + spacer, e.Y * gv.squareSize + gv.squareSize + spacer), e)) { return true; }
            // bottom right
            if (IsVisibleLineOfSight(start, new Coordinate(e.X * gv.squareSize + gv.squareSize - spacer, e.Y * gv.squareSize + gv.squareSize - spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Coordinate(e.X * gv.squareSize + gv.squareSize + spacer, e.Y * gv.squareSize + gv.squareSize - spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Coordinate(e.X * gv.squareSize + gv.squareSize - spacer, e.Y * gv.squareSize + gv.squareSize + spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Coordinate(e.X * gv.squareSize + gv.squareSize + spacer, e.Y * gv.squareSize + gv.squareSize + spacer), e)) { return true; }

            return false;
        }
        public bool IsVisibleLineOfSight(Coordinate s, Coordinate e, Coordinate endSquare)
        {
            // Bresenham Line algorithm
            // Creates a line from Begin to End starting at (x0,y0) and ending at (x1,y1)
            // where x0 less than x1 and y0 less than y1
            // AND line is less steep than it is wide (dx less than dy)    
            //Point start = new Point((s.X * _squareSize) + (_squareSize / 2), (s.Y * _squareSize) + (_squareSize / 2));
            //Point end = new Point((e.X * _squareSize) + (_squareSize / 2), (e.Y * _squareSize) + (_squareSize / 2));
            Coordinate start = s;
            Coordinate end = e;
            int deltax = Math.Abs(end.X - start.X);
            int deltay = Math.Abs(end.Y - start.Y);
            int ystep = 10;
            int xstep = 10;
            int gridx = 0;
            int gridy = 0;
            int gridXdelayed = s.X;
            int gridYdelayed = s.Y;

            //#region low angle version
            if (deltax > deltay) //Low Angle line
            {
                Coordinate nextPoint = start;
                int error = deltax / 2;

                if (end.Y < start.Y) { ystep = -1 * ystep; } //down and right or left

                if (end.X > start.X) //down and right
                {
                    for (int x = start.X; x <= end.X; x += xstep)
                    {
                        nextPoint.X = x;
                        error -= deltay;
                        if (error < 0)
                        {
                            nextPoint.Y += ystep;
                            error += deltax;
                        }
                        //do your checks here for LoS blocking
                        gridx = nextPoint.X / gv.squareSize;
                        gridy = nextPoint.Y / gv.squareSize;

                        if ((mod.currentArea.Tiles[gridy * mod.currentArea.MapSizeX + gridx].LoSBlocked) || (new Coordinate(gridXdelayed, gridYdelayed) == endSquare))
                        {
                            return false;
                        }
                        gridXdelayed = gridx;
                        gridYdelayed = gridy;
                    }
                }
                else //down and left
                {
                    for (int x = start.X; x >= end.X; x -= xstep)
                    {
                        nextPoint.X = x;
                        error -= deltay;
                        if (error < 0)
                        {
                            nextPoint.Y += ystep;
                            error += deltax;
                        }
                        //do your checks here for LoS blocking
                        gridx = nextPoint.X / gv.squareSize;
                        gridy = nextPoint.Y / gv.squareSize;
                        if ((mod.currentArea.Tiles[gridy * mod.currentArea.MapSizeX + gridx].LoSBlocked) || (new Coordinate(gridXdelayed, gridYdelayed) == endSquare))
                        {
                            return false;
                        }
                        gridXdelayed = gridx;
                        gridYdelayed = gridy;
                    }
                }
            }
            //#endregion

            //#region steep version
            else //Low Angle line
            {
                Coordinate nextPoint = start;
                int error = deltay / 2;

                if (end.X < start.X) { xstep = -1 * xstep; } //up and right or left

                if (end.Y > start.Y) //up and right
                {
                    for (int y = start.Y; y <= end.Y; y += ystep)
                    {
                        nextPoint.Y = y;
                        error -= deltax;
                        if (error < 0)
                        {
                            nextPoint.X += xstep;
                            error += deltay;
                        }
                        //do your checks here for LoS blocking
                        gridx = nextPoint.X / gv.squareSize;
                        gridy = nextPoint.Y / gv.squareSize;
                        if ((mod.currentArea.Tiles[gridy * mod.currentArea.MapSizeX + gridx].LoSBlocked) || (new Coordinate(gridXdelayed, gridYdelayed) == endSquare))
                        {
                            return false;
                        }
                        gridXdelayed = gridx;
                        gridYdelayed = gridy;
                    }
                }
                else //up and right
                {
                    for (int y = start.Y; y >= end.Y; y -= ystep)
                    {
                        nextPoint.Y = y;
                        error -= deltax;
                        if (error < 0)
                        {
                            nextPoint.X += xstep;
                            error += deltay;
                        }
                        //do your checks here for LoS blocking
                        gridx = nextPoint.X / gv.squareSize;
                        gridy = nextPoint.Y / gv.squareSize;
                        if ((mod.currentArea.Tiles[gridy * mod.currentArea.MapSizeX + gridx].LoSBlocked) || (new Coordinate(gridXdelayed, gridYdelayed) == endSquare))
                        {
                            return false;
                        }
                        gridXdelayed = gridx;
                        gridYdelayed = gridy;
                    }
                }
            }
            //#endregion

            return true;
        }
        public bool hasMainMapTypeSpell(Player pc)
        {
            foreach (string s in pc.knownSpellsTags)
            {
                Spell sp = mod.getSpellByTag(s);
                if ((sp.useableInSituation.Equals("Always")) || (sp.useableInSituation.Equals("OutOfCombat")))
                {
                    return true;
                }
            }
            return false;
        }
        public void checkLevelUpAvailable()
        {
            bool levelup = false;
            foreach (Player pc in mod.playerList)
            {
                if (pc.IsReadyToAdvanceLevel())
                {
                    levelup = true;
                }
            }
            if (levelup)
            {
                gv.cc.DisposeOfBitmap(ref btnParty.Img2);
                btnParty.Img2 = gv.cc.LoadBitmap("btnpartyplus");
            }
            else
            {
                gv.cc.DisposeOfBitmap(ref btnParty.Img2);
                btnParty.Img2 = gv.cc.LoadBitmap("btnparty");
            }
        }
    }
}
