/*
 * Written By:      Douglas R. Reno
 * Date Created:    2022-02-01
 * Date Modified:   2022-02-21
 * Purpose:         Changes the resolution for Gruntz in a user-friendly GUI.
 * Project:         Gruntz Resolution Changer
 * File Name:       GruntzResolutionChanger.cs
 */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;

namespace Gruntz_Resolution_Changer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnResolution1;
		private System.Windows.Forms.Button btnResolution2;
		private System.Windows.Forms.Button btnResolution3;
		private System.Windows.Forms.Label aboutInfo;
        private Button btnExit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.btnResolution1 = new System.Windows.Forms.Button();
            this.btnResolution2 = new System.Windows.Forms.Button();
            this.btnResolution3 = new System.Windows.Forms.Button();
            this.aboutInfo = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Click a button to change the resolution";
            // 
            // btnResolution1
            // 
            this.btnResolution1.Location = new System.Drawing.Point(16, 40);
            this.btnResolution1.Name = "btnResolution1";
            this.btnResolution1.Size = new System.Drawing.Size(264, 45);
            this.btnResolution1.TabIndex = 1;
            this.btnResolution1.Text = "640x480";
            this.btnResolution1.Click += new System.EventHandler(this.btnResolution1_Click);
            // 
            // btnResolution2
            // 
            this.btnResolution2.Location = new System.Drawing.Point(16, 91);
            this.btnResolution2.Name = "btnResolution2";
            this.btnResolution2.Size = new System.Drawing.Size(264, 42);
            this.btnResolution2.TabIndex = 2;
            this.btnResolution2.Text = "800x600";
            this.btnResolution2.Click += new System.EventHandler(this.btnResolution2_Click);
            // 
            // btnResolution3
            // 
            this.btnResolution3.Location = new System.Drawing.Point(16, 139);
            this.btnResolution3.Name = "btnResolution3";
            this.btnResolution3.Size = new System.Drawing.Size(264, 41);
            this.btnResolution3.TabIndex = 3;
            this.btnResolution3.Text = "1024x768";
            this.btnResolution3.Click += new System.EventHandler(this.btnResolution3_Click);
            // 
            // aboutInfo
            // 
            this.aboutInfo.Location = new System.Drawing.Point(16, 257);
            this.aboutInfo.Name = "aboutInfo";
            this.aboutInfo.Size = new System.Drawing.Size(296, 48);
            this.aboutInfo.TabIndex = 4;
            this.aboutInfo.Text = "Created by Doug Reno in 2022. Version 1.0";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(16, 186);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(264, 43);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.aboutInfo);
            this.Controls.Add(this.btnResolution3);
            this.Controls.Add(this.btnResolution2);
            this.Controls.Add(this.btnResolution1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Gruntz Resolution Changer";
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		// Get a registry key from the game folder
		public static RegistryKey GetGameRegistryKey() 
		{
			// Windows 98 through XP:
			RegistryKey src = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Monolith Productions\\Gruntz\\1.0", RegistryKeyPermissionCheck.ReadWriteSubTree);

			if (src == null)
			{
				// We're on a 64-bit system, or on Windows Vista-11
				src = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Monolith Productions\\Gruntz\\1.0", RegistryKeyPermissionCheck.ReadWriteSubTree);
			}

			return src;
		}

		private static string GetRegistryEntry(string key)
		{
			// Swapping namespaces now!
			using (RegistryKey reg = GetGameRegistryKey())
			{
				if (reg != null) // Sanity check
				{
					object o = reg.GetValue(key);

					if (o != null)
					{
						return o.ToString();
					}
				}
			}

			return null;
		}

        private void CopyRegistryKey(RegistryKey src, RegistryKey dst)
        {
            // Copy the values using a foreach() loop
            foreach (string keyName in src.GetValueNames())
            {
                dst.SetValue(keyName, src.GetValue(keyName), src.GetValueKind(keyName));
            }

            // Copy each subkey now
            foreach (string keyName in src.GetSubKeyNames())
            {
                using (RegistryKey srcSubKey = src.OpenSubKey(keyName, false))
                {
                    RegistryKey dstSubKey = dst.CreateSubKey(keyName);
                    CopyRegistryKey(srcSubKey, dstSubKey);
                }
            }
        }

        private bool SetResolutionTo640x480()
        {
            using (RegistryKey src = GetGameRegistryKey())
            {
                // First, see if we can get to the registry keys for Gruntz
                if (src == null)
                {
                    MessageBox.Show("Error: Unable to find the registry keys for Gruntz.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return false;
                }

                // Now, let's check and see if this has been done already. Sanity check time!
                if (src.GetValue("Resolution").ToString() == "1")
                {
                    MessageBox.Show("Error: The resolution is already set to 640x480.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return false;
                }

                using (RegistryKey dst = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Monolith Productions\\Gruntz\\1.0"))
                {
                    // Copy the configuration data from HKLM to HKCU.
                    CopyRegistryKey(src, dst);

                    // Set the new values in *both* sides for now.
                    // TODO: Could be problematic in the future.
                    dst.SetValue("Resolution", 1);
                    src.SetValue("Resolution", 1);

                    return true;
                }
            }
        }

        private bool SetResolutionTo800x600()
        {
            using (RegistryKey src = GetGameRegistryKey())
            {
                if (src == null)
                {
                    MessageBox.Show("Error: Unable to find the registry keys for Gruntz.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return false;
                }

                // Now, let's check and see if this has been done already. Sanity check time!
                if (src.GetValue("Resolution").ToString() == "2")
                {
                    MessageBox.Show("Error: The resolution is already set to 800x600.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return false;
                }

                using (RegistryKey dst = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Monolith Productions\\Gruntz\\1.0"))
                {
                    // Copy the configuration data from HKLM to HKCU.
                    CopyRegistryKey(src, dst);

                    // Set the new values in *both* sides for now.
                    // TODO: Could be problematic in the future.
                    dst.SetValue("Resolution", 2);
                    src.SetValue("Resolution", 2);

                    return true;
                }
            }
        }

        private bool SetResolutionTo1024x768()
        {
            using (RegistryKey src = GetGameRegistryKey())
            {
                if (src == null)
                {
                    MessageBox.Show("Error: Unable to find the registry keys for Gruntz.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return false;
                }

                // Now, let's check and see if this has been done already. Sanity check time!
                if (src.GetValue("Resolution").ToString() == "3")
                {
                    MessageBox.Show("Error: The resolution is already set to 1024x768.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return false;
                }

                using (RegistryKey dst = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Monolith Productions\\Gruntz\\1.0"))
                {
                    // Copy the configuration data from HKLM to HKCU.
                    CopyRegistryKey(src, dst);

                    // Set the new values in *both* sides for now.
                    // TODO: Could be problematic in the future.
                    dst.SetValue("Resolution", 3);
                    src.SetValue("Resolution", 3);

                    return true;
                }
            }
        }

		private void btnResolution1_Click(object sender, System.EventArgs e)
		{
			if ((SetResolutionTo640x480()) == false) 
			{
				MessageBox.Show("Error: An error occurred while attempting to set the screen resolution.", 
								"Error", 
								MessageBoxButtons.OK, 
								MessageBoxIcon.Error);
			} 
			else 
			{
				MessageBox.Show("Changing the resolution to 640x480 was successful.", 
								"Success!", 
								MessageBoxButtons.OK, 
								MessageBoxIcon.Information);
			}
		}

        private void btnResolution2_Click(object sender, EventArgs e)
        {
            if ((SetResolutionTo800x600()) == false)
            {
                MessageBox.Show("Error: An error occurred while attempting to set the screen resolution.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Changing the resolution to 800x600 was successful.",
                                "Success!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void btnResolution3_Click(object sender, EventArgs e)
        {
            if ((SetResolutionTo1024x768()) == false)
            {
                MessageBox.Show("Error: An error occurred while attempting to set the screen resolution.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Changing the resolution to 1024x768 was successful.",
                                "Success!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
	}
}
