namespace LIBDBGUI
{
    partial class LibraryInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryInterface));
            this.LibraryTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ClientTable = new System.Windows.Forms.DataGridView();
            this.client_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client_num_books = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client_fines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_is_student = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.ToolStrip();
            this.ClientNewButton = new System.Windows.Forms.ToolStripButton();
            this.ClientDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.ClientSearchDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.ClientSearchByID = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientSearchByName = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientSearchBox = new System.Windows.Forms.ToolStripTextBox();
            this.ClientTableRefreshButton = new System.Windows.Forms.ToolStripButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bookTable = new System.Windows.Forms.DataGridView();
            this.book_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book_isbn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book_author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.publish_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_copies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_copies_out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.BMRefresh = new System.Windows.Forms.ToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.OutBookTable = new System.Windows.Forms.DataGridView();
            this.BookIDCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckOutDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.OutBooksRefreshButton = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.checkOutButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.BMSearch = new System.Windows.Forms.ToolStripButton();
            this.LibraryTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientTable)).BeginInit();
            this.Client.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookTable)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutBookTable)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LibraryTabs
            // 
            this.LibraryTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LibraryTabs.Controls.Add(this.tabPage1);
            this.LibraryTabs.Controls.Add(this.tabPage2);
            this.LibraryTabs.Controls.Add(this.tabPage3);
            this.LibraryTabs.Location = new System.Drawing.Point(193, 38);
            this.LibraryTabs.Margin = new System.Windows.Forms.Padding(4);
            this.LibraryTabs.Multiline = true;
            this.LibraryTabs.Name = "LibraryTabs";
            this.LibraryTabs.SelectedIndex = 0;
            this.LibraryTabs.Size = new System.Drawing.Size(1363, 825);
            this.LibraryTabs.TabIndex = 1;
            this.LibraryTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.LibraryTabs_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ClientTable);
            this.tabPage1.Controls.Add(this.Client);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1355, 796);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Clients";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ClientTable
            // 
            this.ClientTable.AllowUserToAddRows = false;
            this.ClientTable.AllowUserToDeleteRows = false;
            this.ClientTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ClientTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.client_id,
            this.client_name,
            this.client_num_books,
            this.client_fines,
            this.c_is_student});
            this.ClientTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ClientTable.Location = new System.Drawing.Point(4, 31);
            this.ClientTable.Margin = new System.Windows.Forms.Padding(4);
            this.ClientTable.MultiSelect = false;
            this.ClientTable.Name = "ClientTable";
            this.ClientTable.RowHeadersWidth = 51;
            this.ClientTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ClientTable.Size = new System.Drawing.Size(1347, 761);
            this.ClientTable.TabIndex = 1;
            this.ClientTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientTable_CellEndEdit);
            this.ClientTable.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ClientTable_CellMouseClick);
            // 
            // client_id
            // 
            this.client_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.client_id.HeaderText = "ID";
            this.client_id.MinimumWidth = 6;
            this.client_id.Name = "client_id";
            this.client_id.ReadOnly = true;
            // 
            // client_name
            // 
            this.client_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.client_name.HeaderText = "Name";
            this.client_name.MinimumWidth = 6;
            this.client_name.Name = "client_name";
            this.client_name.ReadOnly = true;
            // 
            // client_num_books
            // 
            this.client_num_books.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.client_num_books.HeaderText = "# Books";
            this.client_num_books.MinimumWidth = 6;
            this.client_num_books.Name = "client_num_books";
            this.client_num_books.ReadOnly = true;
            // 
            // client_fines
            // 
            this.client_fines.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.client_fines.HeaderText = "Fines";
            this.client_fines.MinimumWidth = 6;
            this.client_fines.Name = "client_fines";
            this.client_fines.ReadOnly = true;
            // 
            // c_is_student
            // 
            this.c_is_student.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_is_student.HeaderText = "Type";
            this.c_is_student.MinimumWidth = 6;
            this.c_is_student.Name = "c_is_student";
            this.c_is_student.ReadOnly = true;
            // 
            // Client
            // 
            this.Client.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Client.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Client.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClientNewButton,
            this.ClientDeleteButton,
            this.ClientSearchDropDown,
            this.ClientSearchBox,
            this.ClientTableRefreshButton});
            this.Client.Location = new System.Drawing.Point(4, 4);
            this.Client.Name = "Client";
            this.Client.Size = new System.Drawing.Size(1347, 27);
            this.Client.TabIndex = 0;
            this.Client.Text = "toolStrip2";
            // 
            // ClientNewButton
            // 
            this.ClientNewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ClientNewButton.Image = ((System.Drawing.Image)(resources.GetObject("ClientNewButton.Image")));
            this.ClientNewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClientNewButton.Name = "ClientNewButton";
            this.ClientNewButton.Size = new System.Drawing.Size(43, 24);
            this.ClientNewButton.Text = "New";
            this.ClientNewButton.Click += new System.EventHandler(this.ClientNewButton_Click);
            // 
            // ClientDeleteButton
            // 
            this.ClientDeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ClientDeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("ClientDeleteButton.Image")));
            this.ClientDeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClientDeleteButton.Name = "ClientDeleteButton";
            this.ClientDeleteButton.Size = new System.Drawing.Size(57, 24);
            this.ClientDeleteButton.Text = "Delete";
            this.ClientDeleteButton.Click += new System.EventHandler(this.ClientDeleteButton_Click);
            // 
            // ClientSearchDropDown
            // 
            this.ClientSearchDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ClientSearchDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClientSearchByID,
            this.ClientSearchByName});
            this.ClientSearchDropDown.Image = ((System.Drawing.Image)(resources.GetObject("ClientSearchDropDown.Image")));
            this.ClientSearchDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClientSearchDropDown.Name = "ClientSearchDropDown";
            this.ClientSearchDropDown.Size = new System.Drawing.Size(67, 24);
            this.ClientSearchDropDown.Text = "Search";
            // 
            // ClientSearchByID
            // 
            this.ClientSearchByID.Name = "ClientSearchByID";
            this.ClientSearchByID.Size = new System.Drawing.Size(152, 26);
            this.ClientSearchByID.Text = "By ID";
            this.ClientSearchByID.Click += new System.EventHandler(this.ClientSearchByID_Click);
            // 
            // ClientSearchByName
            // 
            this.ClientSearchByName.Name = "ClientSearchByName";
            this.ClientSearchByName.Size = new System.Drawing.Size(152, 26);
            this.ClientSearchByName.Text = "By Name";
            this.ClientSearchByName.Click += new System.EventHandler(this.ClientSearchByName_Click);
            // 
            // ClientSearchBox
            // 
            this.ClientSearchBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ClientSearchBox.Name = "ClientSearchBox";
            this.ClientSearchBox.Size = new System.Drawing.Size(132, 27);
            // 
            // ClientTableRefreshButton
            // 
            this.ClientTableRefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ClientTableRefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("ClientTableRefreshButton.Image")));
            this.ClientTableRefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClientTableRefreshButton.Name = "ClientTableRefreshButton";
            this.ClientTableRefreshButton.Size = new System.Drawing.Size(62, 24);
            this.ClientTableRefreshButton.Text = "Refresh";
            this.ClientTableRefreshButton.Click += new System.EventHandler(this.ClientTableRefreshButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bookTable);
            this.tabPage2.Controls.Add(this.toolStrip3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1355, 796);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Book Search";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bookTable
            // 
            this.bookTable.AllowUserToAddRows = false;
            this.bookTable.AllowUserToDeleteRows = false;
            this.bookTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.book_id,
            this.book_isbn,
            this.book_name,
            this.book_author,
            this.genre,
            this.publish_date,
            this.num_copies,
            this.num_copies_out});
            this.bookTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.bookTable.Location = new System.Drawing.Point(4, 31);
            this.bookTable.Margin = new System.Windows.Forms.Padding(4);
            this.bookTable.Name = "bookTable";
            this.bookTable.RowHeadersWidth = 51;
            this.bookTable.Size = new System.Drawing.Size(1347, 761);
            this.bookTable.TabIndex = 1;
            this.bookTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.bookTable_CellEndEdit);
            this.bookTable.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.bookTable_CellMouseClick);
            // 
            // book_id
            // 
            this.book_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.book_id.HeaderText = "ID";
            this.book_id.MinimumWidth = 6;
            this.book_id.Name = "book_id";
            // 
            // book_isbn
            // 
            this.book_isbn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.book_isbn.HeaderText = "ISBN";
            this.book_isbn.MinimumWidth = 6;
            this.book_isbn.Name = "book_isbn";
            // 
            // book_name
            // 
            this.book_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.book_name.HeaderText = "Name";
            this.book_name.MinimumWidth = 6;
            this.book_name.Name = "book_name";
            // 
            // book_author
            // 
            this.book_author.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.book_author.HeaderText = "Author";
            this.book_author.MinimumWidth = 6;
            this.book_author.Name = "book_author";
            // 
            // genre
            // 
            this.genre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.genre.HeaderText = "Genre";
            this.genre.MinimumWidth = 6;
            this.genre.Name = "genre";
            // 
            // publish_date
            // 
            this.publish_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.publish_date.HeaderText = "Date Published";
            this.publish_date.MinimumWidth = 6;
            this.publish_date.Name = "publish_date";
            // 
            // num_copies
            // 
            this.num_copies.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.num_copies.HeaderText = "Total Copies";
            this.num_copies.MinimumWidth = 6;
            this.num_copies.Name = "num_copies";
            // 
            // num_copies_out
            // 
            this.num_copies_out.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.num_copies_out.HeaderText = "Copies Checked Out";
            this.num_copies_out.MinimumWidth = 6;
            this.num_copies_out.Name = "num_copies_out";
            // 
            // toolStrip3
            // 
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BMRefresh,
            this.toolStripButton2,
            this.toolStripButton3,
            this.BMSearch});
            this.toolStrip3.Location = new System.Drawing.Point(4, 4);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(1347, 27);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // BMRefresh
            // 
            this.BMRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BMRefresh.Image = ((System.Drawing.Image)(resources.GetObject("BMRefresh.Image")));
            this.BMRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BMRefresh.Name = "BMRefresh";
            this.BMRefresh.Size = new System.Drawing.Size(62, 24);
            this.BMRefresh.Text = "Refresh";
            this.BMRefresh.Click += new System.EventHandler(this.BMRefresh_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.OutBookTable);
            this.tabPage3.Controls.Add(this.toolStrip2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1355, 796);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Checked Out Books";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // OutBookTable
            // 
            this.OutBookTable.AllowUserToAddRows = false;
            this.OutBookTable.AllowUserToDeleteRows = false;
            this.OutBookTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OutBookTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookIDCol,
            this.CheckOutDateCol,
            this.isbnCol,
            this.BookNameCol,
            this.ClientNameCol});
            this.OutBookTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutBookTable.Location = new System.Drawing.Point(4, 31);
            this.OutBookTable.Margin = new System.Windows.Forms.Padding(4);
            this.OutBookTable.Name = "OutBookTable";
            this.OutBookTable.RowHeadersWidth = 51;
            this.OutBookTable.Size = new System.Drawing.Size(1347, 761);
            this.OutBookTable.TabIndex = 1;
            // 
            // BookIDCol
            // 
            this.BookIDCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BookIDCol.HeaderText = "Book ID";
            this.BookIDCol.MinimumWidth = 6;
            this.BookIDCol.Name = "BookIDCol";
            // 
            // CheckOutDateCol
            // 
            this.CheckOutDateCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CheckOutDateCol.HeaderText = "Check Out Date";
            this.CheckOutDateCol.MinimumWidth = 6;
            this.CheckOutDateCol.Name = "CheckOutDateCol";
            // 
            // isbnCol
            // 
            this.isbnCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.isbnCol.HeaderText = "ISBN";
            this.isbnCol.MinimumWidth = 6;
            this.isbnCol.Name = "isbnCol";
            // 
            // BookNameCol
            // 
            this.BookNameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BookNameCol.HeaderText = "Name";
            this.BookNameCol.MinimumWidth = 6;
            this.BookNameCol.Name = "BookNameCol";
            // 
            // ClientNameCol
            // 
            this.ClientNameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClientNameCol.HeaderText = "Client Name";
            this.ClientNameCol.MinimumWidth = 6;
            this.ClientNameCol.Name = "ClientNameCol";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OutBooksRefreshButton});
            this.toolStrip2.Location = new System.Drawing.Point(4, 4);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1347, 27);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // OutBooksRefreshButton
            // 
            this.OutBooksRefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OutBooksRefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("OutBooksRefreshButton.Image")));
            this.OutBooksRefreshButton.ImageTransparentColor = System.Drawing.Color.LightSteelBlue;
            this.OutBooksRefreshButton.Name = "OutBooksRefreshButton";
            this.OutBooksRefreshButton.Size = new System.Drawing.Size(62, 24);
            this.OutBooksRefreshButton.Text = "Refresh";
            this.OutBooksRefreshButton.Click += new System.EventHandler(this.OutBooksRefreshButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkOutButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1589, 27);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // checkOutButton
            // 
            this.checkOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.checkOutButton.Image = ((System.Drawing.Image)(resources.GetObject("checkOutButton.Image")));
            this.checkOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkOutButton.Name = "checkOutButton";
            this.checkOutButton.Size = new System.Drawing.Size(80, 24);
            this.checkOutButton.Text = "Check Out";
            this.checkOutButton.Click += new System.EventHandler(this.checkOutButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(43, 24);
            this.toolStripButton2.Text = "New";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(57, 24);
            this.toolStripButton3.Text = "Delete";
            // 
            // BMSearch
            // 
            this.BMSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BMSearch.Image = ((System.Drawing.Image)(resources.GetObject("BMSearch.Image")));
            this.BMSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BMSearch.Name = "BMSearch";
            this.BMSearch.Size = new System.Drawing.Size(57, 24);
            this.BMSearch.Text = "Search";
            // 
            // LibraryInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1589, 876);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.LibraryTabs);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LibraryInterface";
            this.Text = "LibraryInterface";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.LibraryTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientTable)).EndInit();
            this.Client.ResumeLayout(false);
            this.Client.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookTable)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutBookTable)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton checkOutButton;
        private System.Windows.Forms.ToolStrip Client;
        private System.Windows.Forms.ToolStripButton ClientNewButton;
        private System.Windows.Forms.ToolStripButton ClientDeleteButton;
        private System.Windows.Forms.ToolStripTextBox ClientSearchBox;
        private System.Windows.Forms.ToolStripButton ClientTableRefreshButton;
        private System.Windows.Forms.DataGridView ClientTable;
        private System.Windows.Forms.TabControl LibraryTabs;
        private System.Windows.Forms.ToolStripMenuItem ClientSearchByID;
        private System.Windows.Forms.ToolStripMenuItem ClientSearchByName;
        private System.Windows.Forms.ToolStripDropDownButton ClientSearchDropDown;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.DataGridView OutBookTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookIDCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckOutDateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn isbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientNameCol;
        private System.Windows.Forms.ToolStripButton OutBooksRefreshButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn client_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn client_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn client_num_books;
        private System.Windows.Forms.DataGridViewTextBoxColumn client_fines;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_is_student;
        private System.Windows.Forms.DataGridView bookTable;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.DataGridViewTextBoxColumn book_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn book_isbn;
        private System.Windows.Forms.DataGridViewTextBoxColumn book_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn book_author;
        private System.Windows.Forms.DataGridViewTextBoxColumn genre;
        private System.Windows.Forms.DataGridViewTextBoxColumn publish_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_copies;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_copies_out;
        private System.Windows.Forms.ToolStripButton BMRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton BMSearch;
    }
}