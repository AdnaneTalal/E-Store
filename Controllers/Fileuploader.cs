
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Hosting;


namespace E_Store.Controllers
{
    public class Fileuploader
    {
        private string Imagefilename;
        private string path;
        public string folder;

        public Fileuploader()
        {

        }

        public Fileuploader(HttpPostedFileBase file, string sf)
        {
            folder = sf;

            Imagefilename = Path.GetFileNameWithoutExtension(file.FileName) + DateTime.Now.ToString("MM_dd_yyyy_hh-mm-ss") + Path.GetExtension(file.FileName);

            path = HostingEnvironment.MapPath(folder) + Imagefilename;

            file.SaveAs(path);

        }

        public string names()
        {
            return Imagefilename;
        }

        public string pathes()
        {
            return path;
        }
    }
}