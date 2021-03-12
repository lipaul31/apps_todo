using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApp.Web.Models;

namespace TodoApp.Web.Controllers.v1
{
    [ApiController]
    [Route("v1/todo")]
    [Produces("application/json")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get all Todo items
        /// </summary>
        /// <param name="filter">Optional filter to be applied</param>
        /// <returns>List of all todo items</returns>
        /// <response code="200">Returns the list of todo items</response>
        /// <response code="500">Unexpected error</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TodoItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromQuery]string filter)
        {
            var response = new List<TodoItemResponse>();
            
            return Ok(response);
        }

        /// <summary>
        /// Get a specific todo item
        /// </summary>
        /// <param name="id">Todo item id</param>
        /// <returns>A specific todo item</returns>
        /// <response code="200">Returns a specific todo item</response>
        /// <response code="404">It was not possible to find the given item</response>
        /// <response code="400">Request has is not valid with the given parameters</response>
        /// <response code="500">Unexpected error</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(TodoItemResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetailsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromRoute]long id)
        {
            var response = new TodoItemResponse();
            
            return Ok(response);
        }

        /// <summary>
        /// Add a new Todo item
        /// </summary>
        /// <param name="request">Todo item to be created</param>
        /// <returns>Returns a successfull status code if operation succeed</returns>
        /// <response code="201">Successfully created a todo item</response>
        /// <response code="400">Request has is not valid with the given parameters</response>
        /// <response code="500">Unexpected error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetailsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody]TodoItemCreateRequest request)
        {            
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Change state of a todo item
        /// </summary>
        /// <param name="id">Todo item id to be updated</param>
        /// <param name="state">Todo item new state</param>
        /// <returns>Returns a successfull status code if operation succeed</returns>
        /// <response code="204">Successfully update a todo item state</response>
        /// <response code="400">Request has is not valid with the given parameters</response>
        /// <response code="404">It was not possible to find the given item</response>
        /// <response code="500">Unexpected error</response>
        [HttpPatch]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetailsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetailsResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult ChangeState([FromRoute]long id, [FromBody]bool state)
        {            
            return NoContent();
        }

        /// <summary>
        /// Change state of a todo item
        /// </summary>
        /// <param name="id">Todo item id to be updated</param>
        /// <param name="request">Updated Todo item</param>
        /// <returns>Returns a successfull status code if operation succeed</returns>
        /// <response code="204">Successfully update a todo item</response>
        /// <response code="400">Request has is not valid with the given parameters</response>
        /// <response code="404">It was not possible to find the given item</response>
        /// <response code="500">Unexpected error</response>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetailsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetailsResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult Change([Required][FromRoute]long id, [FromBody]TodoItemPutRequest request)
        {         
            return NoContent();
        }

        /// <summary>
        /// Change state of a todo item
        /// </summary>
        /// <param name="id">Todo item id to be deleted</param>
        /// <returns>Returns a successfull status code if operation succeed</returns>
        /// <response code="204">Successfully update a todo item state</response>
        /// <response code="404">It was not possible to find the given item</response>
        /// <response code="500">Unexpected error</response>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetailsResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult Delete([FromRoute]long id)
        {            
            return NoContent();
        }
    }
}
