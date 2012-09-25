// -----------------------------------------------------------------------
// <copyright file="Images.cs" company="">
// </copyright>
// -----------------------------------------------------------------------

namespace UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// </summary>
    public class Images
    {
        private int imageID;

        private string imagePath;

        private int userID;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        public int ImageID
        {
            get { return imageID; }
            set { imageID = value; }
        }

        public Images(int ImageID, string ImagePath, int UserID)
        {
            this.ImageID = ImageID;
            this.ImagePath = ImagePath;
            this.UserID = UserID;
        }

    }
}
