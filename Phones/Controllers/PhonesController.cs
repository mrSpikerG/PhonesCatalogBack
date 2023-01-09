using Microsoft.AspNetCore.Mvc;
using Phones.Controllers.Context;
using Phones.Models.Database;

namespace Phones.Controllers {
    [ApiController]
    //[Route("[controller]")]
    public class PhonesController : ControllerBase {


        public PhoneCatalogContext context;

        public PhonesController() {
            this.context = new PhoneCatalogContext();
        }

        [Route("Create")]
        [HttpPost()]
        public IActionResult PostNew(Phone item) {
            try {

                if (item.Price <= 0) {
                    return StatusCode(400);
                }

                this.context.Phones.Add(item);
                this.context.SaveChangesAsync();
                return Ok();
            } catch {
                return StatusCode(500);
            }
        }

        [Route("Read")]
        [HttpGet()]
        public IActionResult Get() {

            return Ok(this.context.Phones);
        }

        [Route("Update")]
        [HttpPost()]
        public IActionResult Update(int oldPhoneId, Phone newPhone) {
            try {
                if (!this.context.Phones.Any(x => x.PhoneId == oldPhoneId)) {
                    return StatusCode(404);
                }

                if (newPhone.Price <= 0) {
                    return StatusCode(400);
                }

                Phone item = this.context.Phones.First(x => x.PhoneId == oldPhoneId);
                item.Name = newPhone.Name;
                item.Price = newPhone.Price;
                item.PriceType = newPhone.PriceType;

                this.context.SaveChangesAsync();
                return Ok();
            } catch {
                return StatusCode(500);
            }
        }

        [Route("Delete")]
        [HttpPost()]
        public IActionResult Delete(int index) {
            try {
                if (!this.context.Phones.Any(x => x.PhoneId == index)) {
                    return StatusCode(404);
                }

                this.context.Phones.Remove(this.context.Phones.First(x => x.PhoneId == index));
                this.context.SaveChangesAsync();
                return Ok();
            } catch {
                return StatusCode(500);
            }
        }
    }
}