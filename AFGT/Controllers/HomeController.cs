﻿using AFGT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AFGT.Controllers
{
    public class HomeController : Controller
    {
        private afgtEntities db = new afgtEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Data(DateTime Dia)
        {
            List<Models.Evento> Evento = new List<Models.Evento>();

            string TipoPesquisa = ""; 
            string ConteudoPesquisa = "";

            if (TipoPesquisa == "Genero")
            {
                return View(db.Eventos.Where(model => model.Data == Dia || Dia == null).ToList().Where(model => model.Artistas.GeneroMusical.NomeEstilo.ToLower() == ConteudoPesquisa.ToLower() || ConteudoPesquisa == null));
            }
            else
            {
                return View(db.Eventos.Where(model => model.Data == Dia || Dia == null).ToList().Where(model => model.Artistas.ToLower() == ConteudoPesquisa.ToLower() || ConteudoPesquisa == null));
            }
        }

        public ActionResult Local(String PointA)
        {
            List<Models.Evento> Evento = new List<Models.Evento>();

            string TipoPesquisa = ""//HttpRequest.Form.Get("search");
            string ConteudoPesquisa = ""///HttpRequest.Form.Get("search");

            if (TipoPesquisa == "Genero")
            {
                return View(db.Eventos.Where(model => model.Morada.Cidade.ToLower() == PointA.ToLower() || PointA == null).ToList().Where(model => model.Artistas.GeneroMusical.NomeEstilo.ToLower() == ConteudoPesquisa.ToLower() || ConteudoPesquisa == null));
            }
            else
            {
                return View(db.Eventos.Where(model => model.Morada.Cidade.ToLower() == PointA.ToLower() || PointA == null).ToList().Where(model => model.Artistas.ToLower() == ConteudoPesquisa.ToLower() || ConteudoPesquisa == null));
            }

        }
    }
}