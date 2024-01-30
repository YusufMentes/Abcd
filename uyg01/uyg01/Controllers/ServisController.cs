using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using uyg01.ViewModel;

namespace uyg01.Controllers
{
    public class ServisController : ApiController
    {
        [HttpGet]
        [Route("api/test")]
        public string Deneme()
        {
            return "API test";
        }



        [HttpGet]
        [Route("api/yetkili")]
        [Authorize]
        public string yetkili()
        {
            return "Yetkili";
        }

        [HttpGet]
        [Route("api/sayiuret")]
        public int Sayi()
        {
            Random r = new Random();
            int s = r.Next(100);
            return s;
        }

        [HttpGet]
        [Route("api/isimliste")]
        public List<string> IsimListeYaz()
        {
            List<string> liste = new List<string>();
            liste.Add("Ali");
            liste.Add("Veli");
            liste.Add("Selami");
            liste.Add("Ayşe");
            liste.Add("Fatma");
            liste.Add("Hayriye");
            return liste;
        }


        [HttpGet]
        [Route("api/sayiliste")]
        public List<int> SayiListe()
        {
            List<int> liste = new List<int>();

            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int s = r.Next(100);
                liste.Add(s);
            }

            return liste;
        }

        [HttpGet]
        [Route("api/tekmiciftmi/{sayi}")]
        public string TekmiCiftmi(int sayi)
        {
            if (sayi % 2 == 0)
            {
                return "Sayı Çift";
            }
            else
            {
                return "Sayı Tek";
            }
        }

        [HttpGet]
        [Route("api/ortalama/{v}/{f}")]

        public double Ortalama(int v, int f)
        {
            double ort = (v * 0.4) + (f * 0.6);
            return Math.Round(ort, 2);

        }


        List<kayitModel> kayitlar = new List<kayitModel> {
            new kayitModel() {id=1,adsoyad="Ali",mail="ali@mail.com",yas=20 },
            new kayitModel() {id=2,adsoyad="Veli",mail="veli@mail.com",yas=210 },
            new kayitModel() {id=3,adsoyad="Selami",mail="selami@mail.com",yas=22 },
            new kayitModel() {id=4,adsoyad="Ayşe",mail="ayse@mail.com",yas=20 },
            new kayitModel() {id=5,adsoyad="Fatma",mail="fatma@mail.com",yas=21 },
            new kayitModel() {id=6,adsoyad="Hayriye",mail="hayriye@mail.com",yas=22 },
        };

        [HttpGet]
        [Route("api/kayitliste")]
        public List<kayitModel> KayitListe()
        {
            return kayitlar;
        }


        [HttpGet]
        [Route("api/kayit/{id}")]
        public kayitModel KayitById(int id)
        {
            kayitModel kayit=kayitlar.Where(s=>s.id==id).SingleOrDefault();
            return kayit;

        }
    }
}
