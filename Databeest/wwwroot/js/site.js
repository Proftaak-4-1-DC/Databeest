// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
 
// Show selected type of inbox like Inbox or Sent 

function showLeft(id) {
    $('#' + id).show();
    $('.inbox-hide').not('#' + id).hide();

    // Gives class selected to first mail in inbox / sent 
    $(".inbox-container").each(function( index ) {
        $(this).children().first().addClass("selected");
    });

    if (id == 'b1') {
        $('#' + 'i1').show();
        $('.mailbox-container').not('#' + 'i1').hide();
        
    }
    if (id == 'b2') {
        $('#' + 'i7').show();
        $('.mailbox-container').not('#' + 'i7').hide();  
    }
}

// Open selected mail on right side function
function MailOpen(id) {
    $('#' + id).show();
    $('.mailbox-container').not('#' + id).hide();
}