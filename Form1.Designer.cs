namespace StarWarsExplorer
{
    partial class Form1
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
            this.txtPlanetId = new System.Windows.Forms.TextBox();
            this.btnGetPlanet = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblClimate = new System.Windows.Forms.Label();
            this.lblGravity = new System.Windows.Forms.Label();
            this.lblTerrain = new System.Windows.Forms.Label();
            this.lblPopulation = new System.Windows.Forms.Label();
            this.lblBirthYear = new System.Windows.Forms.Label();
            this.lblMass = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.btnGetPerson = new System.Windows.Forms.Button();
            this.txtPersonId = new System.Windows.Forms.TextBox();
            this.lstStarships = new System.Windows.Forms.ListBox();
            this.lstSpecies = new System.Windows.Forms.ListBox();
            this.btnGetSpecies = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPlanetId
            // 
            this.txtPlanetId.Location = new System.Drawing.Point(76, 78);
            this.txtPlanetId.Name = "txtPlanetId";
            this.txtPlanetId.Size = new System.Drawing.Size(100, 20);
            this.txtPlanetId.TabIndex = 0;
            // 
            // btnGetPlanet
            // 
            this.btnGetPlanet.Location = new System.Drawing.Point(226, 78);
            this.btnGetPlanet.Name = "btnGetPlanet";
            this.btnGetPlanet.Size = new System.Drawing.Size(75, 23);
            this.btnGetPlanet.TabIndex = 1;
            this.btnGetPlanet.Text = "Get Planet";
            this.btnGetPlanet.UseVisualStyleBackColor = true;
            this.btnGetPlanet.Click += new System.EventHandler(this.btnGetPlanet_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(76, 128);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "label1";
            // 
            // lblClimate
            // 
            this.lblClimate.AutoSize = true;
            this.lblClimate.Location = new System.Drawing.Point(76, 162);
            this.lblClimate.Name = "lblClimate";
            this.lblClimate.Size = new System.Drawing.Size(35, 13);
            this.lblClimate.TabIndex = 3;
            this.lblClimate.Text = "label2";
            // 
            // lblGravity
            // 
            this.lblGravity.AutoSize = true;
            this.lblGravity.Location = new System.Drawing.Point(79, 194);
            this.lblGravity.Name = "lblGravity";
            this.lblGravity.Size = new System.Drawing.Size(35, 13);
            this.lblGravity.TabIndex = 4;
            this.lblGravity.Text = "label3";
            // 
            // lblTerrain
            // 
            this.lblTerrain.AutoSize = true;
            this.lblTerrain.Location = new System.Drawing.Point(79, 225);
            this.lblTerrain.Name = "lblTerrain";
            this.lblTerrain.Size = new System.Drawing.Size(35, 13);
            this.lblTerrain.TabIndex = 5;
            this.lblTerrain.Text = "label4";
            // 
            // lblPopulation
            // 
            this.lblPopulation.AutoSize = true;
            this.lblPopulation.Location = new System.Drawing.Point(76, 251);
            this.lblPopulation.Name = "lblPopulation";
            this.lblPopulation.Size = new System.Drawing.Size(35, 13);
            this.lblPopulation.TabIndex = 6;
            this.lblPopulation.Text = "label5";
            // 
            // lblBirthYear
            // 
            this.lblBirthYear.AutoSize = true;
            this.lblBirthYear.Location = new System.Drawing.Point(443, 228);
            this.lblBirthYear.Name = "lblBirthYear";
            this.lblBirthYear.Size = new System.Drawing.Size(35, 13);
            this.lblBirthYear.TabIndex = 12;
            this.lblBirthYear.Text = "label4";
            // 
            // lblMass
            // 
            this.lblMass.AutoSize = true;
            this.lblMass.Location = new System.Drawing.Point(443, 197);
            this.lblMass.Name = "lblMass";
            this.lblMass.Size = new System.Drawing.Size(35, 13);
            this.lblMass.TabIndex = 11;
            this.lblMass.Text = "label3";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(440, 165);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(35, 13);
            this.lblHeight.TabIndex = 10;
            this.lblHeight.Text = "label2";
            // 
            // lblPersonName
            // 
            this.lblPersonName.AutoSize = true;
            this.lblPersonName.Location = new System.Drawing.Point(440, 131);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.Size = new System.Drawing.Size(35, 13);
            this.lblPersonName.TabIndex = 9;
            this.lblPersonName.Text = "label1";
            // 
            // btnGetPerson
            // 
            this.btnGetPerson.Location = new System.Drawing.Point(590, 81);
            this.btnGetPerson.Name = "btnGetPerson";
            this.btnGetPerson.Size = new System.Drawing.Size(75, 23);
            this.btnGetPerson.TabIndex = 8;
            this.btnGetPerson.Text = "Get Person";
            this.btnGetPerson.UseVisualStyleBackColor = true;
            this.btnGetPerson.Click += new System.EventHandler(this.btnGetPerson_Click);
            // 
            // txtPersonId
            // 
            this.txtPersonId.Location = new System.Drawing.Point(440, 81);
            this.txtPersonId.Name = "txtPersonId";
            this.txtPersonId.Size = new System.Drawing.Size(100, 20);
            this.txtPersonId.TabIndex = 7;
            // 
            // lstStarships
            // 
            this.lstStarships.FormattingEnabled = true;
            this.lstStarships.Location = new System.Drawing.Point(590, 131);
            this.lstStarships.Name = "lstStarships";
            this.lstStarships.Size = new System.Drawing.Size(120, 95);
            this.lstStarships.TabIndex = 13;
            // 
            // lstSpecies
            // 
            this.lstSpecies.FormattingEnabled = true;
            this.lstSpecies.Location = new System.Drawing.Point(590, 303);
            this.lstSpecies.Name = "lstSpecies";
            this.lstSpecies.Size = new System.Drawing.Size(120, 95);
            this.lstSpecies.TabIndex = 14;
            this.lstSpecies.SelectedIndexChanged += new System.EventHandler(this.lstSpecies_SelectedIndexChanged);
            // 
            // btnGetSpecies
            // 
            this.btnGetSpecies.Location = new System.Drawing.Point(590, 264);
            this.btnGetSpecies.Name = "btnGetSpecies";
            this.btnGetSpecies.Size = new System.Drawing.Size(75, 23);
            this.btnGetSpecies.TabIndex = 15;
            this.btnGetSpecies.Text = "Get Species";
            this.btnGetSpecies.UseVisualStyleBackColor = true;
            this.btnGetSpecies.Click += new System.EventHandler(this.btnGetSpecies_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGetSpecies);
            this.Controls.Add(this.lstSpecies);
            this.Controls.Add(this.lstStarships);
            this.Controls.Add(this.lblBirthYear);
            this.Controls.Add(this.lblMass);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblPersonName);
            this.Controls.Add(this.btnGetPerson);
            this.Controls.Add(this.txtPersonId);
            this.Controls.Add(this.lblPopulation);
            this.Controls.Add(this.lblTerrain);
            this.Controls.Add(this.lblGravity);
            this.Controls.Add(this.lblClimate);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnGetPlanet);
            this.Controls.Add(this.txtPlanetId);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPlanetId;
        private System.Windows.Forms.Button btnGetPlanet;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblClimate;
        private System.Windows.Forms.Label lblGravity;
        private System.Windows.Forms.Label lblTerrain;
        private System.Windows.Forms.Label lblPopulation;
        private System.Windows.Forms.Label lblBirthYear;
        private System.Windows.Forms.Label lblMass;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblPersonName;
        private System.Windows.Forms.Button btnGetPerson;
        private System.Windows.Forms.TextBox txtPersonId;
        private System.Windows.Forms.ListBox lstStarships;
        private System.Windows.Forms.ListBox lstSpecies;
        private System.Windows.Forms.Button btnGetSpecies;
    }
}

