using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TileNator
{
    public partial class Form1 : Form
    {
        List<Tile> lTiles;
        Int32 iActiveTileID = -1;
                
        public Form1()
        {
            InitializeComponent();
            
            Helper.ExtractEmbeddedResource(Directory.GetCurrentDirectory(), "TileNator.res", "syspin.exe");

            lTiles = Helper.ImportTiles();

            UpdateMenuItemList(lTiles);
        }

        private void UpdateMenuItemList(List<Tile> lTiles)
        {
            lvMenuItems.Clear();

            foreach (Tile tile in lTiles)
                lvMenuItems.Items.Add(tile.strName);

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
                ((PictureBox)sender).Image = Image.FromFile(ofd.FileName);
        }

        private void lvMenuItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMenuItems.SelectedItems.Count > 0)
            {
                //Set active tile to selected tile
                iActiveTileID = lTiles.IndexOf(lTiles.Find(item => item.strName == lvMenuItems.SelectedItems[0].Text));

                //Display values of selected tile in UI
                tbMenuItemName.Text = lTiles[iActiveTileID].strName;
                tbMenuItemExe.Text = lTiles[iActiveTileID].psiTileApplication.FileName;
                tbMenuItemArgs.Text = lTiles[iActiveTileID].psiTileApplication.Arguments;
                pbLogo150px.Image = lTiles[iActiveTileID].bmpLogo150px;
                pbLogo70px.Image = lTiles[iActiveTileID].bmpLogo70px;

                //
                btnApply.Text = "Save";
                btnRemMenuItem.Enabled = true;
                btnPin.Enabled = true;
            }
            else
            {
                //Set active tile to NONE
                iActiveTileID = -1;

                //Clear all values in the UI
                tbMenuItemName.Text = "";
                tbMenuItemExe.Text = "";
                tbMenuItemArgs.Text = "";
                pbLogo150px.Image = null;
                pbLogo70px.Image = null;

                //
                btnApply.Text = "Add";
                btnRemMenuItem.Enabled = false;
                btnPin.Enabled = false;

            }

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (iActiveTileID < 0) //No Item selected
            {
                Tile tempTile = new Tile(Helper.GetFreeUniqueId(lTiles));
                tempTile.strName = tbMenuItemName.Text;
                tempTile.psiTileApplication.FileName = tbMenuItemExe.Text;
                tempTile.psiTileApplication.Arguments = tbMenuItemArgs.Text;
                tempTile.bmpLogo150px = (Bitmap)pbLogo150px.Image;
                tempTile.bmpLogo70px = (Bitmap)pbLogo70px.Image;

                //Save Active Tile to Disk
                tempTile.Save();

                //Add Tile to list
                lTiles.Add(tempTile);
                
                //Refresh Menu Item List
                UpdateMenuItemList(lTiles);
            }
            else //Item selected
            {
                //Write current values to active tile
                lTiles[iActiveTileID].strName = tbMenuItemName.Text;
                lTiles[iActiveTileID].psiTileApplication.FileName = tbMenuItemExe.Text;
                lTiles[iActiveTileID].psiTileApplication.Arguments = tbMenuItemArgs.Text;
                lTiles[iActiveTileID].bmpLogo150px = (Bitmap)pbLogo150px.Image;
                lTiles[iActiveTileID].bmpLogo70px = (Bitmap)pbLogo70px.Image;

                //Save Active Tile to Disk
                lTiles[iActiveTileID].Save();

                //Refresh Menu Item List
                UpdateMenuItemList(lTiles);
            }
        }

        private void btnRemMenuItem_Click(object sender, EventArgs e)
        {
            if (iActiveTileID < 0)
                return;

            //Delete active tile from Disk
            lTiles[iActiveTileID].Delete();

            //Remove active tile from list
            lTiles.Remove(lTiles[iActiveTileID]);
            
            //Refresh Menu Item List
            UpdateMenuItemList(lTiles);
        }

        private void btnPin_Click(object sender, EventArgs e)
        {
            lTiles[iActiveTileID].pin();
        }

        private void btnSelectMenuItemExe_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
                tbMenuItemExe.Text =  ofd.FileName;

        }
    }
}
