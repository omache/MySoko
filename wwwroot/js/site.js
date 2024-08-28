// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Function to truncate description
function truncateDescription() {
  // Get the description element
  const descriptionElement = document.getElementById("itemDescription");

  // Get the current text content
  const descriptionText = descriptionElement.textContent;

  // Check if the description has more than 40 characters
  if (descriptionText.length > 40) {
    // Truncate the description and add "..."
    const truncatedText = descriptionText.substring(0, 40) + "...";
    // Update the element's text content
    descriptionElement.textContent = truncatedText;
  }
}

truncateDescription();
