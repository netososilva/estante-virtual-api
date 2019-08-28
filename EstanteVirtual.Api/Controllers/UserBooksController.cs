using System;
using EstanteVirtual.Api.Dto;
using EstanteVirtual.Bo.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstanteVirtual.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [RequireHttps]
    public class UserBooksController : ControllerBase
    {
        private readonly IUserBookBo _userBookBo;

        public UserBooksController(IUserBookBo userBookBo)
        {
            _userBookBo = userBookBo;
        }

        [HttpGet]
        [Route("{idUser}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int idUser)
        {
            try
            {
                var books = _userBookBo.BooksOfUser(idUser);

                if (books?.Count == 0)
                    return NoContent();

                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("notinlibrary/{idUser}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetIfNotInLibrary(int idUser)
        {
            try
            {
                var books = _userBookBo.BooksOfUserIfNotExistsInLibrary(idUser);

                if (books?.Count == 0)
                    return NoContent();

                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("find/{idUser}/{search}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Find(int idUser, string search)
        {
            try
            {
                var books = _userBookBo.BooksOfUser(idUser, search);

                if (books?.Count == 0)
                    return NoContent();

                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] UserBook userBook)
        {
            try
            {
                _userBookBo.Insert(userBook.IdUser, userBook.IdBook);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{idUser}/{idBook}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int idUser, int idBook)
        {
            try
            {
                _userBookBo.Remove(idUser, idBook);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
