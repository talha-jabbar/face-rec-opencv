// -----------------------------------------------------------------------
// <copyright file="Person.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Person
    {
        private Users user;

        private List<Images> images;

        public List<Images> Images
        {
            get { return images; }
            set { images = value; }
        }

        public Users User
        {
            get { return user; }
            set { user = value; }
        }

        public Person(Users user, List<Images> images)
        {
            this.User = user;
            this.Images = images;
        }
    }
}
