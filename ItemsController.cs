using Microsoft.AspNetCore.Mvc;
using ToRead;

namespace ScalarExample;

/// <summary>
/// API for managing reading list items.
/// </summary>
/// <remarks>
/// This controller provides endpoints to create, retrieve, and list items
/// in a user's reading list. All items are stored in memory via the DataStore service.
/// </remarks>
[ApiController]
[Route("[controller]")]
public class ItemsController(DataStore dataStore) : ControllerBase
{
    /// <summary>
    /// Retrieves all items in the reading list.
    /// </summary>
    /// <returns>A list of all reading items.</returns>
    /// <response code="200">Returns the complete list of reading items.</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /items
    ///
    /// </remarks>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ReadItem>), StatusCodes.Status200OK)]
    public IActionResult ListItems() =>
        Ok(dataStore.GetAll());

    /// <summary>
    /// Retrieves a specific reading item by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier (GUID) of the reading item to retrieve.</param>
    /// <returns>The requested reading item if found.</returns>
    /// <response code="200">Returns the requested reading item.</response>
    /// <response code="404">If no item exists with the specified ID.</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /items/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// </remarks>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ReadItem), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetItemById([FromRoute] Guid id) =>
        dataStore.Get(id) is { } item ? Ok(item) : NotFound();

    /// <summary>
    /// Creates a new reading item in the list.
    /// </summary>
    /// <param name="request">The details of the reading item to create.</param>
    /// <returns>The newly created reading item with generated ID and timestamps.</returns>
    /// <response code="200">Returns the newly created reading item.</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /items
    ///     {
    ///        "title": "Understanding Async/Await in C#",
    ///        "description": "A deep dive into asynchronous programming patterns",
    ///        "url": "https://example.com/async-await-guide"
    ///     }
    ///
    /// The response will include the auto-generated ID and timestamps.
    /// </remarks>
    [HttpPost]
    [ProducesResponseType(typeof(ReadItem), StatusCodes.Status200OK)]
    public IActionResult CreateItem([FromBody] CreateItemRequest request)
    {
        var item = new ReadItem(request.Title, request.Description, request.Url);
        dataStore.Add(item);
        return Ok(item);
    }

    /// <summary>
    /// Request model for creating a new reading item.
    /// </summary>
    /// <param name="Title">The title of the content to read.</param>
    /// <param name="Description">A brief description or summary of the content.</param>
    /// <param name="Url">The URL where the content can be accessed.</param>
    /// <remarks>
    /// All fields are required when creating a new reading item.
    /// </remarks>
    public record CreateItemRequest(string Title, string Description, string Url);
}