using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace webAPI.Controllers
{
    [RoutePrefix("api/Managers")]
    public class ManagersController : ApiController
    {
        ComputerizedVotingEntities1 db = new ComputerizedVotingEntities1();

        //הזדהות במערכת לגבי מנהל ראשי
        [HttpGet]
        public IHttpActionResult FindHeadManager(string password, string userName)
        {
            //לקרוא לפונקציה שמצפינה את הסיסמא שהכניס
            //במקום ה-password להשתמש במשתנה שהוחזר החדש שמכיל את ההצפנה


            //חיפוש המנהל על פי שם משתמש וסיסמא
            //החזרת הסטטוס שלו
            string kindOfManager = db.Managers.Where(x => x.MPassword == password && x.MUserName == userName).FirstOrDefault().NumStatus;
            if (kindOfManager == "1")
                return Ok();
            return NotFound();
        }


        //הזדהות במערכת לגבי מנהל עיר
        [HttpGet]
        public IHttpActionResult FindCityManager(string password, string userName,string cityOfManager)
        {
            //לקרוא לפונקציה שמצפינה את הסיסמא שהכניס
            //במקום ה-password להשתמש במשתנה שהוחזר החדש שמכיל את ההצפנה


            //חיפוש המנהל על פי שם משתמש וסיסמא
            //החזרת הסטטוס שלו
            string kindOfManager = db.Managers.Where(x => x.MPassword == password && x.MUserName == userName).FirstOrDefault().NumStatus;
            if (kindOfManager == "2")
                return Ok();
            return NotFound();
        }


        //הזדהות במערכת לגבי מנהל קלפי
        [HttpGet]
        public IHttpActionResult FindBalotBoxManager(string password, string userName, string cityOfManager,string numBalotBox)
        {
            //לקרוא לפונקציה שמצפינה את הסיסמא שהכניס
            //במקום ה-password להשתמש במשתנה שהוחזר החדש שמכיל את ההצפנה


            //חיפוש המנהל על פי שם משתמש וסיסמא
            //החזרת הסטטוס שלו
            string kindOfManager = db.Managers.Where(x => x.MPassword == password && x.MUserName == userName).FirstOrDefault().NumStatus;
            if (kindOfManager == "3")
            {
                //שליפת קוד עיר לפי שם העיר שהוזנה
                var q = from c in db.City
                        where c.city == cityOfManager
                        select c.id;

                //שליפת האזרחים לפי קוד העיר 
                var nationalInBallotBox = from n in db.National
                                          where n.cityId ==Convert.ToInt32(q)
                                          select n;

                return Ok(nationalInBallotBox.ToList());
            }
            return NotFound();
        }

        #region מנהל ראשי
        //הפונקציה עובדת
        [HttpGet]
        [Route("allFactions")]
        // GET api/<controller>
        public IQueryable<Factions> AllFactions()//מחזיר את רשימת המפלגות לבחירת המנהל הראשי
        {
            return db.Factions;
        }

        // POST: api/categories 
        [HttpPost]
        [Route("postCityManager")]
        [ResponseType(typeof(Managers))]
        public IHttpActionResult PostCityManager(Managers cityManager)//הוספת מנהלי ערים חדשים
        {
         
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            
            //db.Managers.Add(cityManager);
            
            //db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = cityManager.MIdentity }, cityManager);
        }

        //[HttpGet]
        //[Route("votersResulst")]
        //public IEnumerable<Factions> VotersResulst()//צפייה בתוצאות ספירת קולות
        //{
            
        //}

        
        //בדיקת הפונקציה
        [HttpPost] //הוספת יום בחירות, קוד בחירות ושעת פתיחת קלפיות וסגירתם
        [ResponseType(typeof(Voting))]
        public IHttpActionResult PostVoting(Voting v)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Voting.Add(v);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = v.kodVote }, v); //מחזיר תשובה עם הקוד של המוצר והמוצר עצמו שנוסף למסד הנתונים
        }

        //בדיקת הפונקציה
        [HttpPut] 
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOkFaction(Factions f, int Id)//מעדכן שהמפלגה מאושרת
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Id != f.Id)
            {
                return BadRequest(); //הבקשה לא תקינה
            }
            db.Entry(f).State = EntityState.Modified; //הולך למסד הנתונים ומעדכן את המפלגה
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }


        #endregion

        #region מנהל עיר
        // GET api/<controller>
        [HttpGet]
        [Route("allBallotBoxManagers")]
        public List<Managers> AllBallotBoxManagers()//מחזיר את רשימת מנהלי קלפיות
        {
            var q= from m in db.Managers
                   where m.NumStatus.Equals("3")//מחפש את המנהלים שהסטטוס שלהם הוא 3 ז''א מנהלי קלפי
                   select m;
            return q.ToList();
        }


        // POST: api/categories 
        [ResponseType(typeof(Managers))]
        public IHttpActionResult PostBallotBoxManager(Managers addBallotBoxManager)//הוספת מנהל קלפי חדש
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Managers.Add(addBallotBoxManager);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = addBallotBoxManager.MIdentity }, addBallotBoxManager);
        }

        //// /GET api/<controller>
        //[Route("getNationalInCity/{cityName:string}")]// אין את ההתחלה של הניתוב כפי שמופיע בדף ההגדרות
        //[HttpGet]
        //[ResponseType(typeof(List<National>))]
        //public IHttpActionResult GetNationalInCity(string cityName)//מחזיר רשימת בוחרים בעיר מסוימת עד כה
        //{
        //    List<National> n = db.National.Where(x => x.city == cityName).ToList();
        //    if (n == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(n);
        //}

        //public IHttpActionResult GetOkNationalInCity(string cityName)//מחזיר רשימת בוחרים כשירה בעיר מסוימת
        //{
        //    if (db.City.Find(cityName) != null)//רק אם מצא עיר כזאת
        //    {
        //        return from c in db.National
        //               where c.city == cityName && c.IsChoose.Equals("false")
        //               select c;
        //      }
        //    else
        //    {
        //        return NotFound();

        //    }
        //}
        #endregion

        #region מנהל קלפי
        [HttpGet]
        //מחזיר אובייקט של אזרח על פי תעודת זהות
        [Route("getNational/{tz:string}")]
        public IQueryable<National> GetNational(string tz) 
        {
            var q = from m in db.National
                    where m.Identity.Equals(tz)
                    select m;
            return q;
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNationalToChoose(string identity)
        {
         
            var q = from m in db.National
                    where m.Identity.Equals(identity)
                    select new { m.IsChoose};
            
            if (q.Equals(0))
            {
                National n = new National();
                n.IsChoose=true;
                return Ok();
            }
            return NotFound();
        }

        #endregion
    }
}
