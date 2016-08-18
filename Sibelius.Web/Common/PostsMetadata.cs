using Sibelius.Web.Data;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Common
{
    public static class PostsMetadata
    {
        public static void ForIndex(dynamic ViewBag)
        {
            ViewBag.Title = "Posts! - The Science of Code";
            ViewBag.MainImage = Global.DefaultMainImg;
            ViewBag.MetaDescription = "Posts cortos sobre computacion, videojuegos, gamedev, appdev, software y hardware.";
            ViewBag.MetaKeywords = "computacion, software, programacion, desarrollo, software, hardware, crear videojuegos, gamedev, videojuegos indie, apps";
        }

        public static void ForSection(dynamic ViewBag, string name)
        {
            ViewBag.Section = name;
            ViewBag.Title = name + " - The Science of Code";
            ViewBag.MainImage = Global.DefaultMainImg;
            ViewBag.MetaDescription = "Posts sobre " + name;
            ViewBag.MetaKeywords = "posts, computación, artículos, tutoriales, " + name;
        }

        public static void ForPost(dynamic ViewBag, Post post)
        {
            ViewBag.Title = post.Title;
            ViewBag.MetaDescription = post.IntroHtml.GetPlainText();
            ViewBag.MetaKeywords = post.Tags;
            ViewBag.MainImage = post.ImageUrl;
        }
    }
}