using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Backend;
using Backend.Model.UserModel;

namespace WebApplication.FeedbackFeature
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Status()
        {
            return Ok("Feedback controller is up and running");
        }

        [HttpPost]
        public IActionResult Add(NewFeedbackDTO dto)
        {
            if (!FeedbackValidation.isNewFeedbackValid(dto)) return BadRequest();

            return Ok(AppResources.getInstance().feedbackService.Create(FeedbackMapper.NewFeedbackDTOToFeedback(dto)));
        }

        [HttpGet("unpublished")]  //GET /api/feedback/unpublished
        public IActionResult GetUnpublishedFeedbacks()
        {
            List<Feedback> feedbacks = AppResources.getInstance().feedbackService.GetAllUnpublished();

            if (feedbacks == null) return NotFound();

            return Ok(feedbacks.Select(feedback => FeedbackMapper.FeedbackToFeedbackDto(feedback)).ToArray());

        }

        [HttpGet("published")]  //GET /api/feedback/published
        public IActionResult GetPublishedFeedbacks()
        {
            List<Feedback> feedbacks = AppResources.getInstance().feedbackService.GetAllPublished();

            if (feedbacks == null) return NotFound();

            return Ok(feedbacks.Select(feedback => FeedbackMapper.FeedbackToFeedbackDto(feedback)).ToArray());
        }

        [HttpPut]
        public IActionResult PublishFeedback([FromBody]long id)
        {
            AppResources.getInstance().feedbackService.Publish(id);
            return Ok();
        }
    }
}
