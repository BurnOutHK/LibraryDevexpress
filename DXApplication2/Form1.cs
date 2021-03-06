﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraTabbedMdi;
using DevExpress.XtraTab;
using LibraryDatabase;
using DevExpress.XtraGrid;


namespace DXApplication2
{
    public partial class Form1 : XtraForm
    {
        #region Properties
        public LibraryDbContext Db { get; set; }
        #endregion

        #region Custom Methods

        void RefillAllGrids()
        {
            // Grids on first panel
            DbHelper.FillGrid<Book>(gridBooks, Db.Books);
            DbHelper.FillGrid<Author>(gridAuthors, Db.Authors);
            DbHelper.FillGrid<Genre>(gridGenres, Db.Genres);
            DbHelper.FillGrid<Transaction>(gridTransactions, Db.Transactions);
            DbHelper.FillGrid<Customer>(gridCustomers, Db.Customers);

            // Grids on second panel
            DbHelper.FillGrid<Book>(gridBooks2, Db.Books);
            DbHelper.FillGrid<Author>(gridAuthors2, Db.Authors);
            DbHelper.FillGrid<Genre>(gridGenres2, Db.Genres);
            DbHelper.FillGrid<Transaction>(gridTransactions2, Db.Transactions);
            DbHelper.FillGrid<Customer>(gridCustomers2, Db.Customers);
        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(iSkins, true);
        }

        #endregion

        public Form1()
        {
            InitializeComponent();
            InitSkinGallery();
            Db = new LibraryDbContext();

            RefillAllGrids();
        }

        private void iExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void iShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splitContainerPanels.Panel2Collapsed = false;
        }

        private void iHide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splitContainerPanels.Panel2Collapsed = true;
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefillAllGrids();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("ნამდვილად გსურთ გასვლა?", "გასვლა", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void inboxItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            tabControl.SelectedTabPageIndex = 0;
        }

        private void outboxItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            tabControl.SelectedTabPageIndex = 1;
        }

        private void draftsItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            tabControl.SelectedTabPageIndex = 2;
        }

        private void tasksItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            tabControl.SelectedTabPageIndex = 3;
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            tabControl.SelectedTabPageIndex = 4;
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            XtraMessageBox.Show("ეს შესაძლებლობაც მალე დაემატება,\nმადლობა მოთმინებისთვის!");
        }
    }
}