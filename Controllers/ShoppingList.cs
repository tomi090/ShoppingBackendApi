using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingBackendApi.Models;

namespace ShoppingBackendApi.Controllers
{
    [Route("api/[controller]")]  //https://localhost:5001/api/shoppinglist
    [ApiController]
    public class ShoppingList : ControllerBase
    {
        private shoppingdbContext db = new shoppingdbContext();

        //get metodi joka hakee kaikki tuotteet mit� on lis�tty databaseen
        [HttpGet]
        public ActionResult GetAllItems()
        {
            List<Item> listaus = db.Items.ToList();
            //var listaus = db.Items.OrderBy(i => i.ItemName).ToList();
            //var pelit = db.Pelits.ToList();

            return Ok(listaus);

        }

        // tuotteen lis�ys
        [HttpPost]
        public ActionResult CreateNew([FromBody] Item x)
        {
            try
            {
                db.Items.Add(x);
                db.SaveChanges();

                return Ok("lis�ttiin tuote " + x.ItemName);
            }
            catch (Exception e)
            {
                return BadRequest("Tapahtui virhe. T�ss� lis�tietoa:" + e);
            }


        }
            //tuotteen poisto
            [HttpDelete]
            [Route("{id}")]
            public ActionResult DeleteItem(int id)
            {

                Item x = db.Items.Find(id);

                if (x != null) //jos tuote l�ytyy
                {
                    db.Items.Remove(x);
                    db.SaveChanges();
                    return Ok("Tuote '" + x.ItemName + "' poistettiin.");
                }
                else
                {
                    return NotFound("Ei l�ytyny tuotetta id:ll� " + id);
                }

            }

        }

    }